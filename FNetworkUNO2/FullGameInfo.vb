<System.Serializable()> Public Class FullGameInfo
    Inherits GameInfo
    Public hiddencards As List(Of UnoCard)
    Public Sub New(ByVal players As List(Of PlayerInfo), ByVal openpile As List(Of UnoCard), ByVal color As UnoCard.Colors, ByVal hiddenpile As List(Of UnoCard), ByVal playing As Boolean)
        MyBase.New(players, openpile, color, hiddenpile.Count, playing)
        Me.hiddencards = hiddenpile
    End Sub
End Class
