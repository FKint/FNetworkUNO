Public Class UnoGame
    Public panel As GamePanel
    Public controllerConnect As GameControllerConnect

    Public playinstance As GameParticipant
    Public info As GameInfo
    Protected gamebegon As Boolean
    Public roominfo As GameRoomInfo
    Protected infoasked As Boolean = False

    Protected tosend As List(Of GameSendData)

    Public Sub New(ByVal panel As GamePanel, ByVal controllerConnect As GameControllerConnect, ByVal host As Boolean)
        'MyBase.New(controllerConnect)
        tosend = New List(Of GameSendData)
        gamebegon = False
        Me.panel = panel

        Me.controllerConnect = controllerConnect

        playinstance = New GameParticipant(Me, host)
        ' playinstance.Name = System.Net.Dns.GetHostEntry(System.Net.IPAddress.Loopback).HostName
        playinstance.Name = System.Net.Dns.GetHostName()
        info = New GameInfo(New List(Of PlayerInfo), New List(Of UnoCard), UnoCard.Colors.WHITE, 0, Me.gamebegon)

    End Sub
    Public Sub SendToClient(ByVal data As GameSendData)
        If TypeOf (data) Is GameSendChatText Then
            Dim chattext As GameSendChatText = CType(data, GameSendChatText)
            panel.ChatBoxTextAdd(chattext.Sender, chattext.Text)
        ElseIf TypeOf (data) Is FullPlayerInfo Then
            playinstance.SetInfo(CType(data, FullPlayerInfo))
            GameChanged()
        ElseIf TypeOf (data) Is GameJoinedConfirmation Then
            playinstance.SetParticipating(True)
            'Me.panel.ChatBoxTextAdd("Systeem", "U neemt nu deel aan het spel." & vbCrLf)
            Me.panel.ChatBoxGameInfoAdd("U neemt nu deel aan het spel.")
            PrivilegesChanged()
            GameChanged()
        ElseIf TypeOf (data) Is YouWonMessage Then
            Me.panel.ChatBoxGameInfoAdd("Gefeliciteerd, u hebt het spel gewonnen met " & CType(data, YouWonMessage).score & " punten.")
            ' GameChanged()
        ElseIf TypeOf (data) Is GameOverMessage Then
            Me.panel.ChatBoxGameInfoAdd("Speler " & CType(data, GameOverMessage).player & " won het spel met " & CType(data, GameOverMessage).score & " punten.")
        ElseIf TypeOf (data) Is GameInfo Then
            SetGameInfo(CType(data, GameInfo))
        ElseIf TypeOf (data) Is GameRoomInfo Then
            SetRoomInfo(CType(data, GameRoomInfo))
        ElseIf TypeOf (data) Is GameStartedMessage Then
            Me.gamebegon = True
            Me.panel.UpdateControls()
            GameChanged()
            Me.panel.ChatBoxGameInfoAdd("Het spel is begonnen.")
        ElseIf TypeOf (data) Is GoodByeMessage Then
            Me.panel.ChatBoxGameInfoAdd("De verbinding met de host is verbroken. Het spel kan bijgevolg niet worden verdergezet.")
        ElseIf TypeOf (data) Is YourTurnMessage Then
            Me.playinstance.Turn = True
            Me.panel.ChatBoxGameInfoAdd("Het is uw beurt.")
        ElseIf TypeOf (data) Is StillYourTurnMessage Then
            Me.playinstance.Turn = True
            Me.panel.ChatBoxGameInfoAdd("U bent nog steeds aan beurt.")
        ElseIf TypeOf (data) Is NotYourTurnAnyMoreMessage Then
            Me.playinstance.Turn = False
            Me.panel.ChatBoxGameInfoAdd("De beurt is doorgeschoven naar de volgende speler.")
        ElseIf TypeOf (data) Is AskInfoMessage Then
            ' Me.controllerConnect.SendListenerInfo()
            If controllerConnect Is Nothing Then
                infoasked = True
            Else
                controllerConnect.SendListenerInfo()
            End If
        ElseIf TypeOf (data) Is TakeCards Then
            Me.panel.ChatBoxGameInfoAdd("U kreeg " & CType(data, TakeCards).cards.Count & " nieuwe kaart" & CType(IIf(CType(data, TakeCards).cards.Count > 1, "en", ""), String) & "(" & CType(data, TakeCards).msg & ").")
        ElseIf TypeOf (data) Is CurrColorChangedByWildCard Then
            Me.panel.ChatBoxGameInfoAdd("Het nieuwe kleur is: " & CType(data, CurrColorChangedByWildCard).ColorName() & ".")
        ElseIf TypeOf (data) Is NotYourTurnMessage Then
            Me.panel.ChatBoxGameInfoAdd("Het is uw beurt niet.")
        ElseIf TypeOf (data) Is WrongCardMessage Then
            Me.panel.ChatBoxGameInfoAdd("Verkeerde kaart.")
        ElseIf TypeOf (data) Is NotYourCardMessage Then
            Me.panel.ChatBoxGameInfoAdd("U bezit deze kaart niet, volgens de host.")
        End If
    End Sub
    Public Sub SetConnector(ByVal connector As GameControllerConnect)
        Me.controllerConnect = connector
        'controllerConnect.Connect()
        'Me.controllerConnect.connect()
        If infoasked Then
            infoasked = False
            controllerConnect.SendListenerInfo()
        End If
        For Each data As GameSendData In Me.tosend
            controllerConnect.SendToController(data)
        Next
    End Sub
    Public Sub SetGameInfo(ByVal info As GameInfo)
        Me.info = info
        GameChanged()
    End Sub
    Public Sub JoinGame()
        SendToController(New ListenerInfo(-1, playinstance.Name(), playinstance.IsParticipating(), playinstance.Description()))
        SendToController(New JoinRequest(""))
    End Sub
    Public Sub SendToController(ByVal data As GameSendData)
        If Not controllerConnect Is Nothing Then
            controllerConnect.SendToController(data)
        Else
            tosend.Add(data)
        End If
    End Sub
    Public Function GameStarted() As Boolean
        Return Me.gamebegon
    End Function
    Public Sub PrivilegesChanged()
        If Not Me.panel Is Nothing Then
            Me.panel.UpdateControls()
        End If
    End Sub
    Public Sub SetRoomInfo(ByVal info As GameRoomInfo)
        Me.roominfo = info
        panel.SetRoomListeners(info.listeners)
        GameChanged()
    End Sub
    Public Sub GameChanged()
        'Me.panel.Update()
        Try
            Me.panel.Refresh()

        Catch ex As InvalidOperationException
            Dim d As New GameChangedCallback(AddressOf GameChanged)
            panel.Invoke(d, New Object() {})
        End Try
    End Sub
    Public Sub StopGame(ByVal msg As String)
        If Me.controllerConnect IsNot Nothing Then
            Me.controllerConnect.SendToController(New LeaveGameMessage(msg))
        End If
    End Sub
    Public Sub ConnectionEnded()
        'MsgBox("connectionEnded, werk verder")
        Me.panel.ChatBoxGameInfoAdd("De verbinding werd beëindigd, u kunt niet meer deelnemen aan het spel.")
    End Sub
    Public Delegate Sub GameChangedCallback()

    Public Sub Disposed(Optional ByVal msg As String = "")
        Me.controllerConnect.EndConnection(msg)
    End Sub
End Class
