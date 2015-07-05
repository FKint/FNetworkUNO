<System.Serializable()> Public Class TakeCards
    Inherits GameSendData
    Public cards As List(Of UnoCard)
    Public msg As String

    Public Sub New(ByVal cards As List(Of UnoCard), ByVal msg As String)
        Me.cards = cards
        Me.msg = msg
    End Sub

End Class
