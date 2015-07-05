Public Class GameParticipant
    Protected participating As Boolean

    'Protected participantname As String
    'Protected participantdescription As String
    'Protected participantid As Short
    Public info As ListenerInfo
    Public cards As List(Of UnoCard)
    'Protected cards As List(Of UnoCard)

    Public game As UnoGame
    Protected host As Boolean
    Protected myturn As Boolean = False

    Public Sub New(ByVal game As UnoGame, ByVal host As Boolean, Optional ByVal info As ListenerInfo = Nothing)
        Me.game = game
        Me.host = host
        cards = New List(Of UnoCard)
        'Me.participantname = ""
        'Me.participantdescription = ""
        'Me.info = info
        'participating = False
        If info Is Nothing Then
            info = New ListenerInfo(-1, "", False, "")
        End If
        SetInfo(info)

    End Sub
    Public Sub SetInfo(ByVal info As ListenerInfo)
        'Me.participantname = info.Name
        'Me.participantdescription = info.Description
        'Me.cards = info.cards
        Me.info = info
        If TypeOf (info) Is FullPlayerInfo Then
            Me.cards = CType(info, FullPlayerInfo).cards
        End If
    End Sub
    Public Sub SetParticipating(ByVal participating As Boolean)
        Me.participating = participating
    End Sub
    Public Property Name() As String
        Get
            Return info.Name
        End Get
        Set(ByVal value As String)
            info.Name = value
            game.SendToController(info)
        End Set
    End Property
    Public Property Description() As String
        Get
            Return info.Description
        End Get
        Set(ByVal value As String)
            Me.info.Description = value
            game.SendToController(info)
        End Set
    End Property
    Public Function IsParticipating() As Boolean
        Return participating
    End Function
    Public Function IsHost() As Boolean
        Return host
    End Function
    Public Property ID() As Short
        Get
            Return info.ID
        End Get
        Set(ByVal value As Short)
            Me.info.ID = value
        End Set
    End Property
    Public Property Turn() As Boolean
        Get
            Return myturn
        End Get
        Set(ByVal value As Boolean)
            Me.myturn = value
            Me.game.GameChanged()
        End Set
    End Property
    Public Sub SubmitCard(ByVal card As UnoCard)
        ' MsgBox("werk verder aan submitcard in gameparticipant")
        If Me.game.playinstance.Turn Then
            If card IsNot Nothing Then
                If (card.type = UnoCard.Types.WILD Or card.type = UnoCard.Types.WILDDRAWFOUR) And card.newcolor <> UnoCard.Colors.BLUE And card.newcolor <> UnoCard.Colors.GREEN And card.newcolor <> UnoCard.Colors.RED And card.newcolor <> UnoCard.Colors.YELLOW Then
                    Dim d As New ColorForm()
                    If d.ShowDialog() = DialogResult.OK Then
                        If d.rbtBlue.Checked Then
                            card.newcolor = UnoCard.Colors.BLUE
                        ElseIf d.rbtGreen.Checked Then
                            card.newcolor = UnoCard.Colors.GREEN
                        ElseIf d.rbtRed.Checked Then
                            card.newcolor = UnoCard.Colors.RED
                        ElseIf d.rbtYellow.Checked Then
                            card.newcolor = UnoCard.Colors.YELLOW
                        End If
                    Else
                        Exit Sub
                    End If

                End If
            End If
            Me.game.playinstance.Turn = False
            Me.game.SendToController(New SubmitCardMessage(card))
        End If
    End Sub
    Public ReadOnly Property CardsAmount() As Byte
        Get
            Return cards.Count()
        End Get
    End Property
End Class
