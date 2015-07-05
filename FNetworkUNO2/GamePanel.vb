Imports System.ComponentModel
Imports System.Math


Public Class GamePanel
    Inherits Panel

    Public containingTab As TabPage = Nothing
    Public game As UnoGame = Nothing
    Public controller As GameController = Nothing
    Dim host As Boolean


    Friend WithEvents btnSendText As System.Windows.Forms.Button
    Friend WithEvents pnlActions As System.Windows.Forms.Panel
    Friend WithEvents pnlChat As System.Windows.Forms.Panel
    Friend WithEvents txtEnterText As System.Windows.Forms.TextBox
    Friend WithEvents txtChatbox As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents gameMembers As System.Windows.Forms.ListView
    Friend WithEvents btnJoinGame As System.Windows.Forms.Button
    Friend WithEvents btnStartGame As System.Windows.Forms.Button

    Public Shared imgBlank As Image
    Public Shared img0 As Image
    Public Shared img1 As Image
    Public Shared img2 As Image
    Public Shared img3 As Image
    Public Shared img4 As Image
    Public Shared img5 As Image
    Public Shared img6 As Image
    Public Shared img7 As Image
    Public Shared img8 As Image
    Public Shared img9 As Image
    Public Shared imgDrawTwo As Image
    Public Shared imgReverse As Image
    Public Shared imgSkip As Image
    Public Shared imgWild As Image
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Public Shared imgWildDrawFour As Image


    Private Sub InitializeComponent()
        Me.pnlStage = New System.Windows.Forms.Panel
        Me.gameMembers = New System.Windows.Forms.ListView
        Me.txtChatbox = New System.Windows.Forms.RichTextBox
        Me.txtEnterText = New System.Windows.Forms.TextBox
        Me.btnSendText = New System.Windows.Forms.Button
        Me.pnlActions = New System.Windows.Forms.Panel
        Me.btnJoinGame = New System.Windows.Forms.Button
        Me.btnStartGame = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.pnlChat = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        '        Me.btnConnect = New System.Windows.Forms.Button
        Me.pnlActions.SuspendLayout()
        Me.pnlChat.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlStage
        '
        Me.pnlStage.BackColor = System.Drawing.Color.MidnightBlue
        Me.pnlStage.Location = New System.Drawing.Point(200, 0)
        Me.pnlStage.Name = "pnlStage"
        Me.pnlStage.Size = New System.Drawing.Size(700, 500)
        Me.pnlStage.TabIndex = 0
        '
        'gameMembers
        '
        Me.gameMembers.Location = New System.Drawing.Point(0, 0)
        Me.gameMembers.Name = "gameMembers"
        Me.gameMembers.Size = New System.Drawing.Size(200, 250)
        Me.gameMembers.TabIndex = 0
        Me.gameMembers.UseCompatibleStateImageBehavior = False
        Me.gameMembers.View = System.Windows.Forms.View.List
        '
        'txtChatbox
        '
        Me.txtChatbox.Location = New System.Drawing.Point(75, 0)
        Me.txtChatbox.Name = "txtChatbox"
        Me.txtChatbox.Size = New System.Drawing.Size(825, 120)
        Me.txtChatbox.TabIndex = 0
        Me.txtChatbox.Text = ""
        '
        'txtEnterText
        '
        Me.txtEnterText.Location = New System.Drawing.Point(75, 120)
        Me.txtEnterText.Name = "txtEnterText"
        Me.txtEnterText.Size = New System.Drawing.Size(825, 20)
        Me.txtEnterText.TabIndex = 0
        '
        'btnSendText
        '
        Me.btnSendText.Location = New System.Drawing.Point(0, 0)
        Me.btnSendText.Name = "btnSendText"
        Me.btnSendText.Size = New System.Drawing.Size(75, 140)
        Me.btnSendText.TabIndex = 0
        Me.btnSendText.Text = "Button1"
        Me.btnSendText.UseVisualStyleBackColor = True
        '
        'pnlActions
        '
        Me.pnlActions.Controls.Add(Me.btnJoinGame)
        Me.pnlActions.Controls.Add(Me.btnStartGame)
        Me.pnlActions.Controls.Add(Me.btnConnect)
        Me.pnlActions.Location = New System.Drawing.Point(0, 250)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(200, 250)
        Me.pnlActions.TabIndex = 0
        '
        'btnJoinGame
        '
        Me.btnJoinGame.Location = New System.Drawing.Point(0, 0)
        Me.btnJoinGame.Name = "btnJoinGame"
        Me.btnJoinGame.Size = New System.Drawing.Size(100, 30)
        Me.btnJoinGame.TabIndex = 0
        Me.btnJoinGame.Text = "Join Game"
        '
        'btnStartGame
        '
        Me.btnStartGame.Location = New System.Drawing.Point(0, 0)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(100, 30)
        Me.btnStartGame.TabIndex = 1
        Me.btnStartGame.Text = "Start Game"

        '
        'pnlChat
        '
        Me.pnlChat.Controls.Add(Me.txtChatbox)
        Me.pnlChat.Controls.Add(Me.txtEnterText)
        Me.pnlChat.Controls.Add(Me.btnSendText)
        Me.pnlChat.Location = New System.Drawing.Point(0, 500)
        Me.pnlChat.Name = "pnlChat"
        Me.pnlChat.Size = New System.Drawing.Size(900, 150)
        Me.pnlChat.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.gameMembers)
        Me.pnlLeft.Controls.Add(Me.pnlActions)
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(200, 500)
        Me.pnlLeft.TabIndex = 0
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(0, 0)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(100, 30)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Verbind"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'GamePanel
        '
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlStage)
        Me.Controls.Add(Me.pnlChat)
        Me.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActions.ResumeLayout(False)
        Me.pnlChat.ResumeLayout(False)
        Me.pnlChat.PerformLayout()
        Me.pnlLeft.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlStage As System.Windows.Forms.Panel
    Public Sub New(ByVal container As TabPage, ByVal host As Boolean)
        MyBase.New()
        If GamePanel.imgBlank Is Nothing Then
            InitializeImages()
        End If
        Me.containingTab = container
        Me.InitializeComponent()
        UpdateControls()
        Me.host = host

    End Sub
    Public Function GetConnected() As Boolean
        If Me.game.controllerConnect IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub InitializeImages()
        GamePanel.imgBlank = My.Resources.blank
        GamePanel.img0 = My.Resources._0
        GamePanel.img1 = My.Resources._1
        GamePanel.img2 = My.Resources._2
        GamePanel.img3 = My.Resources._3
        GamePanel.img4 = My.Resources._4
        GamePanel.img5 = My.Resources._5
        GamePanel.img6 = My.Resources._6
        GamePanel.img7 = My.Resources._7
        GamePanel.img8 = My.Resources._8
        GamePanel.img9 = My.Resources._9
        GamePanel.imgDrawTwo = My.Resources.draw2
        GamePanel.imgReverse = My.Resources.reverse
        GamePanel.imgSkip = My.Resources.skip
        GamePanel.imgWild = My.Resources.wild
        GamePanel.imgWildDrawFour = My.Resources.wilddraw4
    End Sub
    Public Sub ChatBoxGameInfoAdd(ByVal text As String)
        Try
            If txtChatbox.InvokeRequired Then
                Dim d As New SetGameInfoCallback(AddressOf ChatBoxGameInfoAdd)
                Invoke(d, New Object() {text})
            Else
                Dim value As String = "Spel-info: " & text & vbCrLf
                Dim startind As Integer = Me.txtChatbox.TextLength
                Me.txtChatbox.AppendText(value)
                Me.txtChatbox.SelectionStart = startind
                Me.txtChatbox.SelectionLength = Me.txtChatbox.TextLength - Me.txtChatbox.SelectionStart
                Me.txtChatbox.SelectionFont = New Font(Me.txtChatbox.SelectionFont, FontStyle.Bold)
                Me.txtChatbox.SelectionLength = 0
                Me.txtChatbox.ScrollToCaret()

            End If
        Catch ex As InvalidOperationException
            'MsgBox("invalid operation in chatboxgameinfoadd")
        End Try
    End Sub
    Delegate Sub SetGameInfoCallback(ByVal text As String)

    Public Sub ChatBoxTextAdd(ByVal sender As String, ByVal text As String)
        Try
            If txtChatbox.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf ChatBoxTextAdd)
                Invoke(d, New Object() {sender, text})
            Else
                Dim value As String = sender & ": " & text & vbCrLf
                Me.txtChatbox.AppendText(value)
                Me.txtChatbox.ScrollToCaret()
            End If
        Catch ex As InvalidOperationException
            ' MsgBox("invalid operation in chatboxtextadd")
        End Try
    End Sub
    Delegate Sub SetTextCallback(ByVal sender As String, ByVal text As String)
    Delegate Sub UpdateControlsCallback()
    Public Sub UpdateControls()
        Try
            Me.btnConnect.visible = False
            Me.btnJoinGame.Visible = False
            Me.btnStartGame.Visible = False
            If Not Me.game Is Nothing Then
                If GetConnected() Then
                    Me.btnJoinGame.Visible = Not Me.game.playinstance.IsParticipating()
                    If Not controller Is Nothing Then
                        Me.btnStartGame.Visible = Me.game.playinstance.IsHost() And Not Me.controller.GameStarted()

                    End If
                Else
                    Me.btnConnect.visible = True
                End If
            Else
                Me.btnConnect.Visible = True
            End If
        Catch e As InvalidOperationException
            Invoke(New UpdateControlsCallback(AddressOf UpdateControls), New Object() {})
        End Try

    End Sub

    Private Sub btnStartGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartGame.Click
        If Not Me.game Is Nothing Then
            If Not controller Is Nothing And game.playinstance.IsHost() Then
                If Not controller.GameStarted() Then
                    controller.Start()
                End If
            End If
        End If
    End Sub

    Private Sub btnJoinGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJoinGame.Click
        If Not Me.game Is Nothing Then
            If Not Me.game.playinstance.IsParticipating() Then
                Me.game.JoinGame()
            End If
        End If
    End Sub
    Public Sub Start()
        Dim connector As GameControllerConnect = Nothing


        If host Then
            Dim port As Integer = 0
            While True
                While True
                    Try
                        port = CInt(InputBox("Voer het poortnummer in waarop u wilt luisteren.", "poortnummer", CStr(ControllerHost.serverport)))
                        Exit While
                    Catch ex As InvalidCastException
                        If MsgBox("U moet een geldig nummer invoeren. Wilt u nog eens proberen?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                            Exit Sub
                        End If
                    End Try
                End While
                Try
                    game = New UnoGame(Me, connector, host)
                    Me.controller = New GameController(port)

                    connector = New DirectGameControllerConnect(Me.controller, game)

                    Me.game.SetConnector(connector)
                    game.JoinGame()
                    UpdateControls()
                    Exit Sub
                Catch ex As Exception
                    game = Nothing
                    connector = Nothing
                    If MsgBox("Met de ingevoerde gegevens kan geen gamehost opgezet worden. Wilt u opnieuw proberen?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End Try
            End While
        Else
            Dim hostname As String = ""
            Dim port As Integer = 0
            While True
                hostname = InputBox("Geef de host op waarmee u verbinding wilt maken.", "Hostnaam", "localhost")
                While True
                    Try
                        port = CInt(InputBox("Geef de poort op waarmee u verbinding wilt maken.", "Poortnummer", CStr(ControllerHost.serverport)))
                        Exit While
                    Catch ex As InvalidCastException
                        If MsgBox("Het poortnummer dat u invulde is ongeldig, wilt u een nieuw getal invoeren?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                            Exit Sub
                        End If
                    End Try
                End While
                Try
                    game = New UnoGame(Me, connector, host)
                    connector = New TcpGameControllerConnect(Me.game, hostname, port)
                    Me.game.SetConnector(connector)

                    UpdateControls()
                    Exit Sub
                Catch ex As Exception
                    If MsgBox("Met de informatie die u invulde kan geen verbinding gemaakt worden met een host. Wilt u opnieuw proberen?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End Try
            End While
        End If
    End Sub
    Protected Delegate Sub SetRoomListenersCallback(ByVal listeners As List(Of ListenerInfo))
    Public Sub SetRoomListeners(ByVal listeners As List(Of ListenerInfo))
        If Me.gameMembers.InvokeRequired Then
            Dim d As New SetRoomListenersCallback(AddressOf SetRoomListeners)
            Invoke(d, New Object() {listeners})
        Else
            Me.gameMembers.Items.Clear()
            For Each info As ListenerInfo In listeners
                Dim item As ListViewItem
                item = New ListViewItem(CType(IIf(info.Participating, "*", ""), String) & info.Name)
                Me.gameMembers.Items.Add(item)
            Next
            Me.Update()
        End If
    End Sub
    Public Sub DrawGame(ByVal p As Panel, ByVal e As System.Windows.Forms.PaintEventArgs, ByVal game As GameInfo, Optional ByVal owninfo As FullPlayerInfo = Nothing)
        Dim g As Graphics = e.Graphics()
        If Not game Is Nothing Then
            If game.playing() Then


                Dim selfplayer As Boolean = Not owninfo Is Nothing

                Dim startx As Single
                Dim starty As Single
                starty = p.Height / 10
                startx = p.Width / 20
                Dim newwidth As Single = p.Width - startx * 2
                Dim newheight As Single = p.Height - starty * 2
                Dim otherplayersamount As Short = game.players.Count - CType(IIf(selfplayer, 1, 0), Short)
                If otherplayersamount > 0 Then
                    Dim widthperplayer As Single = newwidth / otherplayersamount
                    Dim heightperplayer As Single = newheight / 4
                    Dim begon As Boolean = False
                    Dim x As Single = startx
                    Dim y As Single = starty
                    For Each player As PlayerInfo In game.players
                        Dim curround As Boolean = False
                        If selfplayer Then
                            If player.ID = owninfo.ID Then
                                begon = True
                                curround = True
                            End If
                        Else
                            begon = True
                        End If
                        If begon And Not curround Then
                            DrawPlayer(g, x, y, widthperplayer, heightperplayer, player.CardsAmount)
                            x += widthperplayer
                        End If
                        '
                    Next
                    If selfplayer Then
                        For Each player As PlayerInfo In game.players
                            If player.ID = owninfo.ID Then
                                Exit For
                            End If
                            DrawPlayer(g, x, y, widthperplayer, heightperplayer, player.CardsAmount)
                            x += widthperplayer
                        Next

                    End If
                End If
                'Dim stackheight As Single = newheight / 4
                'Dim stackwidth As Single = stackheight * 2 / 3
                If game.HiddenPileAmount > 0 Then
                    Dim closedstackr As Rectangle = Me.GetClosedStackRectangle(newwidth, newheight / 4, startx + newwidth / 2, starty + newheight * 3 / 8)
                    g.FillRectangle(Brushes.White, closedstackr)
                End If
                If game.openpile.Count > 0 Then
                    Dim colorpen As Brush
                    Select Case game.openpile.Item(game.openpile.Count - 1).color
                        Case UnoCard.Colors.BLUE
                            colorpen = Brushes.Blue
                        Case UnoCard.Colors.GREEN
                            colorpen = Brushes.Green
                        Case UnoCard.Colors.RED
                            colorpen = Brushes.Red
                        Case UnoCard.Colors.YELLOW
                            colorpen = Brushes.Yellow
                        Case UnoCard.Colors.BLACK
                            colorpen = Brushes.Black
                        Case UnoCard.Colors.WHITE
                            colorpen = Brushes.White
                        Case Else
                            colorpen = Brushes.White
                    End Select
                    Dim openstackr As Rectangle = Me.GetOpenStackRectangle(newwidth, newheight / 4, startx + newwidth / 2, starty + newheight * 3 / 8)
                    g.FillRectangle(colorpen, openstackr)
                    g.DrawImage(GetCardImage(game.openpile.Item(game.openpile.Count - 1)), openstackr)
                End If
                If selfplayer Then
                    If TypeOf (Me.game.playinstance.info) Is FullPlayerInfo Then
                        Dim myinfo As FullPlayerInfo = Me.game.playinstance.info
                        If myinfo.CardsAmount > 0 Then
                            Dim rs As List(Of Rectangle) = Me.GetCardRectangles(p.Width / 2, p.Height * 3 / 4, p.Width, p.Height / 2, myinfo.cards.Count)
                            For i As Short = 0 To myinfo.cards.Count - 1
                                Dim card As UnoCard = myinfo.cards.Item(i)
                                Dim r As Rectangle = rs.Item(i)
                                Dim brush As Brush
                                Select Case card.color
                                    Case UnoCard.Colors.BLUE
                                        brush = Brushes.Blue
                                    Case UnoCard.Colors.GREEN
                                        brush = Brushes.Green
                                    Case UnoCard.Colors.RED
                                        brush = Brushes.Red
                                    Case UnoCard.Colors.YELLOW
                                        brush = Brushes.Yellow
                                    Case UnoCard.Colors.BLACK
                                        brush = Brushes.Black
                                    Case UnoCard.Colors.WHITE
                                        brush = Brushes.White
                                    Case Else
                                        brush = Brushes.White
                                End Select
                                g.FillRectangle(brush, r)

                                g.DrawImage(Me.GetCardImage(card), r)
                            Next
                        End If
                    End If
                End If
            Else
                drawNoGame(g, p)
            End If

        Else
            drawNoGame(g, p)
        End If
    End Sub
    Protected Function GetCardImage(ByVal card As UnoCard) As Image
        Dim img As Image
        Select Case card.type
            Case UnoCard.Types.BLANK
                img = GamePanel.imgBlank
            Case UnoCard.Types.DRAWTWO
                img = GamePanel.imgDrawTwo
            Case UnoCard.Types.EIGHT
                img = GamePanel.img8
            Case UnoCard.Types.FIVE
                img = GamePanel.img5
            Case UnoCard.Types.FOUR
                img = GamePanel.img4
            Case UnoCard.Types.NINE
                img = GamePanel.img9
            Case UnoCard.Types.ONE
                img = GamePanel.img1
            Case UnoCard.Types.SEVEN
                img = GamePanel.img7
            Case UnoCard.Types.SIX
                img = GamePanel.img6
            Case UnoCard.Types.THREE
                img = GamePanel.img3
            Case UnoCard.Types.TWO
                img = GamePanel.img2
            Case UnoCard.Types.ZERO
                img = GamePanel.img0
            Case UnoCard.Types.REVERSE
                img = GamePanel.imgReverse
            Case UnoCard.Types.SKIP
                img = GamePanel.imgSkip
            Case UnoCard.Types.WILD
                img = GamePanel.imgWild
            Case UnoCard.Types.WILDDRAWFOUR
                img = GamePanel.imgWildDrawFour
            Case Else
                img = GamePanel.imgBlank
        End Select
        Return img
    End Function
    Protected Sub DrawPlayer(ByVal g As Graphics, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal cardsamount As Short)
        Dim cardx, cardy, cardwidth, cardheight As Single
        If width * 1.5 < height Then
            cardwidth = width * 0.8
            cardheight = cardwidth * 1.5
        Else
            cardheight = height * 0.8
            cardwidth = cardheight * 2.0 / 3.0
        End If
        cardx = (width - cardwidth) / 2 + x
        cardy = y
        Dim card As Rectangle = New Rectangle(cardx, cardy, cardwidth, cardheight)
        g.FillRectangle(Brushes.White, card)
        'add uno-logo
        Dim f As StringFormat
        f = New StringFormat()
        f.Alignment = StringAlignment.Center
        g.DrawString(CStr(cardsamount), New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point, Nothing), Brushes.Red, x + width / 2, y + cardheight + (height - cardheight) / 2, f)

    End Sub


    Private Sub pnlStage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlStage.MouseDown

        If Me.game.GameStarted() Then
            If Me.game.playinstance.Turn Then

                Dim closedstack As Rectangle = Me.GetClosedStackRectangle(pnlStage.Width * 0.8, pnlStage.Height * 0.2, pnlStage.Width / 2, pnlStage.Height * 3 / 8)
                If closedstack.Contains(e.Location) Then
                    Me.game.playinstance.SubmitCard(Nothing)
                    Exit Sub
                End If
                Dim rectangles As List(Of Rectangle) = Me.GetCardRectangles(Me.pnlStage.Width / 2, Me.pnlStage.Height * 3 / 4, Me.pnlStage.Width, Me.pnlStage.Height / 2, Me.game.playinstance.CardsAmount)
                For i As Byte = 0 To rectangles.Count - 1
                    If rectangles.Item(i).Contains(e.Location) Then
                        Me.game.playinstance.SubmitCard(Me.game.playinstance.cards.Item(i))
                        Exit Sub

                    End If
                Next


            End If
        End If
    End Sub
    Private Sub drawNoGame(ByVal g As Graphics, ByVal p As Panel)

        Dim f As StringFormat = New StringFormat()

        f.Alignment = StringAlignment.Center
        g.DrawString("Geen spel beschikbaar", New Font("Arial", 60, FontStyle.Bold, GraphicsUnit.Pixel, Nothing), Brushes.Red, p.Width / 2, p.Height / 2 - 30, f)

    End Sub
    Private Sub pnlStage_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlStage.Paint
        If game IsNot Nothing Then
            Me.DrawGame(pnlStage, e, Me.game.info, CType(IIf(TypeOf (Me.game.playinstance.info) Is FullPlayerInfo, Me.game.playinstance.info, Nothing), FullPlayerInfo))
        Else
            Me.drawNoGame(e.Graphics(), pnlStage)
        End If
    End Sub

    Private Sub GamePanel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Me.controller IsNot Nothing Then
            Me.controller.Disposed("Quit")
        End If
        If Me.game IsNot Nothing Then
            Me.game.Disposed("Quit")
        End If
    End Sub

    Private Function GetCardRectangles(ByVal centerx As Single, ByVal centery As Single, ByVal width As Single, ByVal height As Single, ByVal cardsamount As Short) As List(Of Rectangle)
        Dim rectangles As New List(Of Rectangle)
        Dim cardwidth As Single = width / cardsamount
        Dim cardheight As Single = cardwidth * 1.5
        Dim cardsperrow As Short = cardsamount
        Dim rows As Short = 1
        If cardheight > height Then
            cardheight = height
            cardwidth = height * 2 / 3
        End If
        While True
            rows += 1
            Dim newcardheight As Single = height / rows
            Dim newcardwidth As Single = width / Math.Ceiling(cardsamount / rows)
            If newcardheight > newcardwidth * 1.5 Then
                newcardheight = newcardwidth * 1.5

                cardheight = newcardheight
                cardwidth = newcardwidth
                cardsperrow = Math.Ceiling(cardsamount / rows)
            Else
                rows -= 1
                Exit While
            End If
        End While
        Dim startx As Single = centerx - cardsperrow * cardwidth / 2
        Dim starty As Single = centery - Math.Ceiling(cardsamount / cardsperrow) * cardheight / 2
        For c As Short = 0 To cardsamount - 1
            Dim plus As Single = 0
            If cardsamount Mod cardsperrow <> 0 Then
                If (cardsamount + 1) \ (c + 1) = rows - 1 Then
                    plus = cardwidth / 2
                End If
            End If
            Dim r As New Rectangle(startx + (c Mod cardsperrow) * cardwidth + plus, starty + (c \ cardsperrow) * cardheight, cardwidth, cardheight)
            rectangles.Add(r)
        Next
        Return rectangles
    End Function
    Public Function GetClosedStackRectangle(ByVal width As Single, ByVal height As Single, ByVal centerx As Single, ByVal centery As Single) As Rectangle
        Dim r As Rectangle
        Dim rwidth As Single = height * 2 / 3
        Dim rheight As Single = height
        If rwidth > width / 3 Then
            rwidth = width / 3
            rheight = rwidth * 1.5
        End If
        If rwidth > width Then
            rwidth = width
            rheight = width * 1.5
        End If
        r = New Rectangle(centerx - rwidth * 1.5, centery - rheight / 2, rwidth, rheight)
        Return r
    End Function
    Public Function GetOpenStackRectangle(ByVal width As Single, ByVal height As Single, ByVal centerx As Single, ByVal centery As Single) As Rectangle
        Dim r As Rectangle
        Dim rwidth As Single = height * 2 / 3
        Dim rheight As Single = height
        If rwidth > width / 3 Then
            rwidth = width / 3
            rheight = rwidth * 1.5
        End If
        If rwidth > width Then
            rwidth = width
            rheight = width * 1.5
        End If
        r = New Rectangle(centerx + rwidth * 0.5, centery - rheight / 2, rwidth, rheight)
        Return r
    End Function

    Private Sub btnSendText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendText.Click
        SendChatText()
    End Sub
    Private Sub SendChatText()
        If Me.txtEnterText.TextLength > 0 Then
            Dim text As GameSendChatText = New GameSendChatText(txtEnterText.Text, Me.game.playinstance.Name)
            Me.game.SendToController(text)
            txtEnterText.Clear()
        End If

    End Sub

    Private Sub txtEnterText_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnterText.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            SendChatText()
        End If

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Start()
    End Sub
End Class