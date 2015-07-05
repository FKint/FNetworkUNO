<System.Serializable()> Public Class FullPlayerInfo
    Inherits PlayerInfo
    Public cards As List(Of UnoCard)
    Public Sub New(ByVal id As Short, ByVal name As String, ByVal cards As List(Of UnoCard), ByVal description As String)
        MyBase.New(id, name, cards.Count, description)
        Me.cards = cards
    End Sub
    Public Overrides ReadOnly Property CardsAmount() As Short
        Get
            Return cards.Count()
        End Get
    End Property
End Class
