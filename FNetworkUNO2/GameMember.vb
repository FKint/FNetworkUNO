Public Class GameMember
    Public listener As GameListener

    Public cards As List(Of UnoCard)
    Protected playername As String

    Public Sub New(ByVal listener As GameListener)
        Me.listener = listener
        listener.Participating = True
        cards = New List(Of UnoCard)
    End Sub
    Public Sub ClearCards()
        cards.Clear()
    End Sub
    Public Sub GiveCard(ByVal card As UnoCard)
        cards.Add(card)
    End Sub
    Public Property Name() As String
        Get
            Return playername
        End Get
        Set(ByVal value As String)
            playername = value
        End Set
    End Property
    Public Function GetCardsAmount() As Integer
        Return cards.Count
    End Function
    Public Sub SendToClient(ByVal data As GameSendData)
        listener.SendToClient(data)
    End Sub
    Public Property Description() As String
        Get
            Return Me.listener.Description
        End Get
        Set(ByVal value As String)
            listener.Description = value
        End Set
    End Property
    Public Function RemoveCard(ByVal card As UnoCard) As Boolean
        'If Me.cards.IndexOf(card) >= 0 Or Me.cards.IndexOf(card) < Me.cards.Count Then
        '    Me.cards.Remove(card)
        '    Return True
        'End If
        'Return False
        For s As Short = 0 To cards.Count - 1 Step 1
            Dim tmpcard As UnoCard = Me.cards.Item(s)
            If tmpcard.type = card.type And tmpcard.color = card.color Then
                Me.cards.RemoveAt(s)
                Return True
            End If
        Next
        Return False
    End Function
    Public ReadOnly Property CardsScore() As Short
        Get
            Dim tmp As Short = 0
            For Each card As UnoCard In Me.cards
                tmp += card.Value()
            Next
            Return tmp
        End Get
    End Property
End Class
