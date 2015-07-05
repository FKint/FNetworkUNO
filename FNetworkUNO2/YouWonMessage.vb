<System.Serializable()> Public Class YouWonMessage
    Inherits GameSendData
    Public score As Short
    Public Sub New(ByVal score As Short)
        Me.score = score
    End Sub

End Class
