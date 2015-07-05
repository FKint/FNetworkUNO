<System.Serializable()> Public Class SubmitCardMessage
    Inherits GameSendData
    Public card As UnoCard
    Public Sub New(ByVal card As UnoCard)
        Me.card = card
    End Sub
End Class
