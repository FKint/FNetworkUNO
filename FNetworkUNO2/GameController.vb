Public Class GameController
    Public Const cardsamount As Short = 108
    Public maxmembers As Short = 10
    Public listeners As List(Of GameListener)
    Public members As List(Of GameMember)
    Public openStack As List(Of UnoCard)
    Public hiddenStack As List(Of UnoCard)

    Protected host As ControllerHost

    Protected name As String = "Host"
    Protected gamebegon As Boolean

    'Public game As UnoGame

    Protected playerturn As GameMember
    Protected Friend WithEvents currtimer As Timer

    Protected waitingforplayer As Boolean = False
    Protected turntime As Integer
    Protected drawamount As Short = 0
    Protected rotateclockwise As Boolean = True
    Protected actionneeded As Boolean = True

    Protected currcolor As UnoCard.Colors

    Public Sub New(ByVal port As Integer)
        'ByVal game As UnoGame)
        'MyBase.New(game)
        'Me.game = game
        gamebegon = False
        listeners = New List(Of GameListener)
        members = New List(Of GameMember)
        openStack = New List(Of UnoCard)
        hiddenStack = New List(Of UnoCard)
        host = New ControllerHost(Me, port)
        host.StartAccepting()
        currtimer = New Timer()
        turntime = 20000

    End Sub
    Protected Sub Distributecards()
        openStack.Clear()
        hiddenStack.Clear()
        For Each player As GameMember In Me.members
            player.ClearCards()
        Next
        Dim tmplist As New List(Of UnoCard)
        For i As Integer = 0 To cardsamount - 1
            tmplist.Add(New UnoCard(i))
        Next
        Randomize(System.Environment.TickCount())
        Dim rnd As New Random()
        Dim nr As Integer
        While tmplist.Count > 0
            nr = rnd.Next()
            hiddenStack.Add(tmplist.Item(nr Mod tmplist.Count))
            tmplist.RemoveAt(nr Mod tmplist.Count)
        End While

        For r As Byte = 1 To 7
            For Each player As GameMember In Me.members
                'player.GiveCard(hiddenStack.Item(0))
                'hiddenStack.RemoveAt(0)
                GiveCards(player, 1, False)
            Next
        Next
        Do
            openStack.Add(hiddenStack.Item(0))
            hiddenStack.RemoveAt(0)
        Loop Until openStack.Item(openStack.Count - 1).type <> UnoCard.Types.BLANK And openStack.Item(openStack.Count - 1).type <> UnoCard.Types.DRAWTWO And openStack.Item(openStack.Count - 1).type <> UnoCard.Types.REVERSE And openStack.Item(openStack.Count - 1).type <> UnoCard.Types.SKIP And openStack.Item(openStack.Count - 1).type <> UnoCard.Types.WILD And openStack.Item(openStack.Count - 1).type <> UnoCard.Types.WILDDRAWFOUR
        Me.SetColor(openStack.Item(openStack.Count - 1).color)
        'End While
        'GameChanged()
    End Sub
    Public Sub Start()
        If Me.members.Count > 1 Then
            Distributecards()
            Me.gamebegon = True
            For Each listener As GameListener In Me.listeners
                listener.GameStarted()
            Next
            SetTurn(Me.members.Item(1))
            InformAboutGame()
        Else
            MsgBox("Er zijn niet genoeg spelers om het spel te starten.")
        End If

    End Sub
    Public Sub SetTurn(ByVal member As GameMember)
        Me.actionneeded = True
        Me.playerturn = member
        Me.waitingforplayer = True
        member.SendToClient(New YourTurnMessage(Me.turntime))
        Me.StartTimer(Me.turntime)

    End Sub
    Public Sub AddListener(ByVal listener As GameListener)
        Me.listeners.Add(listener)
        If Not listener.GetInfoGot Then
            listener.SendToClient(New AskInfoMessage())
        End If
        listener.SendToClient(New GameSendChatText("Welkom bij het spel. Indien u als speler wilt meedoen, kies 'Join'.", Me.name))
        InformAboutRoom()
        InformAboutGame(listener)
        'MsgBox("listener added")
    End Sub
    Public Sub InformAboutGame(Optional ByVal target As GameListener = Nothing)
        Dim info As GameInfo
        info = New GameInfo(New List(Of PlayerInfo), Me.openStack, currcolor, Me.hiddenStack.Count, Me.gamebegon)
        Dim id As Integer = 0
        For Each player As GameMember In Me.members
            Dim playerinfo As PlayerInfo = New PlayerInfo(id, player.Name, player.GetCardsAmount())
            'info.AddPlayer(id, player.Name, player.GetCardsAmount())
            info.AddPlayer(playerinfo)
            If player Is Me.playerturn Then
                info.CurrPlayerID = id
            End If
            id += 1
        Next
        If target Is Nothing Then
            For Each listener As GameListener In Me.listeners
                listener.SendToClient(info)
            Next
            Dim playerid As Integer = 0
            For Each player As GameMember In Me.members
                Dim playerinfo As FullPlayerInfo
                playerinfo = New FullPlayerInfo(playerid, player.Name, player.cards, player.Description)
                player.SendToClient(playerinfo)
                playerid += 1
            Next
        Else
            target.SendToClient(info)
        End If
    End Sub
    Public Sub ChatTextSent(ByVal text As String, ByVal sender As String)
        For Each listener As GameListener In Me.listeners
            listener.SendToClient(New GameSendChatText(text, sender))
        Next
    End Sub
    Public Sub SendToController(ByVal listener As GameListener, ByVal data As Object)
        If listeners.IndexOf(listener) >= 0 And listeners.IndexOf(listener) < listeners.Count Then
            If TypeOf (data) Is GameSendChatText Then
                'msgbox((data as gamesendchattext).Text)
                ' Dim t As String = CType(data, GameSendChatText).Text
                'dim text as gameSendChatText = (data as GameSendChatText)
                'MsgBox(t)
                ChatTextSent(CType(data, GameSendChatText).Text, listener.Name)
            ElseIf TypeOf (data) Is JoinRequest Then
                'If listener.GetInfoGot() Then
                '    If Me.members.Count < Me.maxmembers Then
                AddMember(listener)
                '    End If
                'End If
            ElseIf TypeOf (data) Is ListenerInfo Then
                Dim info As ListenerInfo = CType(data, ListenerInfo)
                info.ID = Me.listeners.IndexOf(listener)
                listener.SetInfo(info)
                InformAboutRoom()
            ElseIf TypeOf (data) Is SubmitCardMessage Then
                CardSubmitted(listener, CType(CType(data, SubmitCardMessage).card, UnoCard))

            End If
        Else
            MsgBox("Listener die niet in de lijst zit, zendt bericht")

        End If

    End Sub
    Public Sub CardSubmitted(ByVal src As GameListener, ByVal card As UnoCard)
        'For Each player As GameMember In Me.members
        'If player.listener Is src Then
        If src Is Me.playerturn.listener Then
            Dim opencard As UnoCard = Me.openStack.Item(openStack.Count - 1)
            If card IsNot Nothing Then
                'If card.color = opencard.color Or card.type = opencard.type Then
                '    If player.RemoveCard(card) Then
                '        AddCardToStack(card)
                '        NextPlayer()
                '    Else
                '        GiveCards(player, 4, True, "Foute Kaart.")

                '    End If
                '    Exit For
                'End If
                If card.IsValidCard() Then

                    If (Me.drawamount > 0 And opencard.type = card.type) Or (Me.drawamount = 0 And (opencard.type = card.type Or currcolor = card.color Or card.type = UnoCard.Types.WILD Or card.type = UnoCard.Types.WILDDRAWFOUR)) Then
                        If playerturn.RemoveCard(card) Then
                            Dim currplayer As GameMember = playerturn

                            AddCardToStack(card)
                            If currplayer.GetCardsAmount = 0 Then
                                Dim score As Integer = 0
                                For Each gamemember As GameMember In Me.members
                                    score += gamemember.CardsScore()
                                Next
                                currplayer.SendToClient(New YouWonMessage(score))
                                For Each gamemember As GameMember In Me.members
                                    If gamemember IsNot currplayer Then
                                        gamemember.SendToClient(New GameOverMessage(currplayer.Name, score))
                                    End If
                                Next
                                Me.gamebegon = False
                                InformAboutGame()
                            End If
                            '  NextPlayer()

                        Else
                            'GiveCards(playerturn, 4, True, "U bezit deze kaart niet")
                            playerturn.SendToClient(New NotYourCardMessage())
                            StillTurn(playerturn)
                        End If
                    Else
                        ' GiveCards(playerturn, 4, True, "Foute kaart.")
                        'If Me.drawamount > 0 Then
                        '    GiveCards(player, Me.drawamount, True, "+ -kaarten.")
                        '    Me.drawamount = 0
                        '    NextPlayer()
                        'Else
                        '    Me.drawamount = 0
                        'End If
                        playerturn.SendToClient(New WrongCardMessage())
                        StillTurn(playerturn)
                    End If
                Else
                    'GiveCards(playerturn, 4, True, "Foute kaart")
                    'playerturn.SendToClient(new StillYourTurnMessage())
                    playerturn.SendToClient(New WrongCardMessage())
                    StillTurn(playerturn)
                End If
            Else
                If (opencard.type = UnoCard.Types.DRAWTWO Or opencard.type = UnoCard.Types.WILDDRAWFOUR) And Me.drawamount > 0 Then
                    GiveCards(playerturn, Me.drawamount, True, "+ -kaarten.")
                    Me.drawamount = 0
                    actionneeded = False
                    NextPlayer()
                Else
                    Me.drawamount = 0
                    If actionneeded Then
                        GiveCards(playerturn, 1, True, "U kon geen kaart leggen.")
                        actionneeded = False
                        StillTurn(playerturn)
                    Else
                        NextPlayer()
                    End If

                End If

            End If
        Else
            For Each player As GameMember In Me.members
                If player.listener Is src Then
                    'GiveCards(player, 4, True, "Het is niet uw beurt.")
                    player.SendToClient(New NotYourTurnMessage())
                End If
            Next
            ' Exit For
        End If
        InformAboutGame()
    End Sub
    Protected Sub AddCardToStack(ByVal card As UnoCard)
        Me.openStack.Add(card)
        Me.currcolor = card.color
        Select Case card.type
            Case UnoCard.Types.DRAWTWO
                drawamount += 2
                NextPlayer()
            Case UnoCard.Types.REVERSE
                Me.ChangeDirection()
                If Me.members.Count > 2 Then
                    NextPlayer()
                Else
                    SetTurn(Me.playerturn)
                End If
            Case UnoCard.Types.BLANK
                MsgBox("Blanke kaart aan de stack toegevoegd.")
            Case UnoCard.Types.SKIP
                Me.NextPlayer(2)
            Case UnoCard.Types.WILD
                SetColor(card.GetNewColor())
                NextPlayer()
            Case UnoCard.Types.WILDDRAWFOUR
                drawamount += 4
                SetColor(card.GetNewColor())
                NextPlayer()
            Case Else
                NextPlayer()
        End Select
    End Sub
    Protected Sub SetColor(ByVal color As UnoCard.Colors)
        Me.currcolor = color
        For Each listener As GameListener In Me.listeners
            listener.SendToClient(New CurrColorChangedByWildCard(color))
        Next
    End Sub
    Protected Sub AddMember(ByVal listener As GameListener)
        If listener.GetInfoGot() Then
            If Me.members.Count < Me.maxmembers And Not Me.GameStarted() Then
                Dim newmember As GameMember = New GameMember(listener)
                members.Add(newmember)
                Dim confirmation As GameJoinedConfirmation = New GameJoinedConfirmation()
                newmember.SendToClient(confirmation)
                InformAboutRoom()
                InformAboutGame()
            End If
        End If
    End Sub
    Public Function GameStarted() As Boolean
        Return Me.gamebegon
    End Function
    Public Sub InformAboutRoom()
        Dim lstInfo As New List(Of ListenerInfo)
        For Each listener As GameListener In Me.listeners
            If listener.GetInfoGot() Then

                lstInfo.Add(New ListenerInfo(Me.listeners.IndexOf(listener), listener.Name(), listener.Participating(), listener.Description()))
            Else
                lstInfo.Add(New ListenerInfo(Me.listeners.IndexOf(listener), "nieuw", listener.Participating(), listener.Description()))
            End If
        Next
        Dim info As GameRoomInfo = New GameRoomInfo(lstInfo, Me.GameStarted())

        For Each listener As GameListener In Me.listeners
            listener.SendToClient(info)
        Next

    End Sub
    Public Sub StopGame(ByVal msg As String)
        'Dim gameinfo As FullGameInfo
        'Dim roominfo As RoomInfo = New RoomInfo(New List(Of GameListenerInfo))
        'gameinfo = New FullGameInfo(New List(Of PlayerInfo), Me.openStack, Me.hiddenStack, Me.gamebegon)
        'Dim id As Integer = 0
        'For Each player As GameMember In Me.members
        '    Dim playerinfo As PlayerInfo = New PlayerInfo(id, player.Name, player.GetCardsAmount())
        '    gameinfo.AddPlayer(playerinfo)
        '    id += 1
        'Next
        'Me.members.Item(0).SendToClient(New HostPromotion(gameinfo))
        'Dim newhost As String = Me.members.Item(0).HostName
        'dim newport as 
        Dim hostleftmsg As HostLeft = New HostLeft(msg)

        For Each listener As GameListener In Me.listeners
            listener.SendToClient(hostleftmsg)
            listener.EndSending(msg)
        Next
    End Sub

    Private Sub currtimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles currtimer.Tick
        If waitingforplayer Then
            'Me.playerturn.SendToClient(New TimeOutMessage())
            'Me.RemoveMember(playerturn, "Time-out")
            If actionneeded Then
                If Me.drawamount > 0 Then
                    GiveCards(playerturn, drawamount, True, "+ -kaarten")
                    drawamount = 0
                Else
                    GiveCards(playerturn, 1, True, "U kon geen kaart leggen.")
                End If
            End If
            NextPlayer()
        End If
        Me.currtimer.Stop()
    End Sub
    Public Sub RemoveMember(ByVal player As GameMember, ByVal msg As String)
        Me.members.Remove(player)
        RemoveListener(player.listener, msg)
    End Sub
    Public Sub RemoveListener(ByVal listener As GameListener, ByVal msg As String)
        For Each member As GameMember In Me.members
            If member.listener Is listener Then
                RemoveMember(member, "")
                Exit Sub
            End If
        Next
        Me.listeners.Remove(listener)
        listener.EndSending(msg)
        InformAboutRoom()
    End Sub
    Public Sub NextPlayer(Optional ByVal memberstep As Short = 1)
        NotYourTurnAnyMore(Me.playerturn)

        Dim ind As Short = (Me.members.IndexOf(Me.playerturn) + (memberstep * IIf(Me.rotateclockwise, 1, -1))) Mod Me.members.Count
        While ind < 0
            ind = Me.members.Count + ind
        End While
        SetTurn(Me.members.Item(ind))
    End Sub
    Public Sub StartTimer(ByVal interval As Integer)
        Me.currtimer.Stop()
        Me.currtimer.Interval = interval
        Me.currtimer.Start()
    End Sub
    Public Sub GiveCards(ByVal player As GameMember, ByVal amount As Short, ByVal warn As Boolean, Optional ByVal msg As String = "")
        Dim tokencards As List(Of UnoCard) = New List(Of UnoCard)
        For t As Short = 1 To amount
            CheckHiddenStack()
            player.GiveCard(Me.hiddenStack.Item(0))
            If warn Then
                tokencards.Add(hiddenStack.Item(0))
            End If
            hiddenStack.RemoveAt(0)
        Next
        If warn Then
            player.SendToClient(New TakeCards(tokencards, msg))
        End If
        InformAboutGame()
    End Sub
    Public Sub CheckHiddenStack()
        If Not Me.hiddenStack.Count > 0 Then
            For t As Short = 0 To openStack.Count - 2
                hiddenStack.Add(openStack.Item(0))
                openStack.RemoveAt(0)
            Next
        End If
    End Sub
    Protected Sub ChangeDirection()
        Me.rotateclockwise = Not Me.rotateclockwise
    End Sub
    Public Sub Disposed(Optional ByVal msg As String = "")
        Me.host.Dispose()
        For Each l As GameListener In Me.listeners
            l.EndSending(msg)
        Next

    End Sub
    Public Sub StillTurn(ByVal player As GameMember)
        Me.currtimer.Stop()
        Me.currtimer.Interval = 15000
        Me.currtimer.Start()
        player.SendToClient(New StillYourTurnMessage())
    End Sub
    Public Sub NotYourTurnAnyMore(ByVal player As GameMember)
        player.SendToClient(New NotYourTurnAnyMoreMessage())
    End Sub
End Class
