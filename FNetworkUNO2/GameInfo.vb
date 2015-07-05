<System.Serializable()> Public Class GameInfo
    Inherits GameSendData

    Public players As List(Of PlayerInfo)
    Public openpile As List(Of UnoCard)
    Public currcolor As UnoCard.Colors
    Protected hiddenpile As Short
    Protected gameplaying As Boolean

    Protected currplayer As Short = -1
    Public Sub New(ByVal players As List(Of PlayerInfo), ByVal openpile As List(Of UnoCard), ByVal currcolor As UnoCard.Colors, ByVal hiddenpile As Short, ByVal playing As Boolean)
        Me.players = players
        Me.openpile = openpile
        Me.currcolor = currcolor
        Me.hiddenpile = hiddenpile
        gameplaying = playing
    End Sub
    Public Sub AddPlayer(ByVal info As PlayerInfo)
        players.Add(info)
    End Sub
    Public Property playing() As Boolean
        Get
            Return gameplaying
        End Get
        Set(ByVal value As Boolean)
            Me.gameplaying = value
        End Set
    End Property
    Public ReadOnly Property HiddenPileAmount() As Short
        Get
            Return hiddenpile
        End Get
    End Property
    Public Property CurrPlayerID() As Short
        Get
            Return Me.currplayer
        End Get
        Set(ByVal value As Short)
            Me.currplayer = value

        End Set
    End Property
End Class
