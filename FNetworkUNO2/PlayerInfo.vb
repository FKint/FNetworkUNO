<System.Serializable()> Public Class PlayerInfo
    Inherits ListenerInfo

    ' Public name As String
    Protected amountcards As Short

    Public Sub New(ByVal id As Short, ByVal name As String, ByVal cardsamount As Short, Optional ByVal description As String = "")
        MyBase.new(id, name, True, description)
        Me.amountcards = cardsamount
    End Sub
    Public Overridable ReadOnly Property CardsAmount() As Short
        Get
            Return amountcards
        End Get
    End Property
End Class
