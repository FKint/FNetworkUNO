<System.Serializable()> Public Class GameOverMessage
    Inherits GameSendData
    Public player As String
    Public score As Short
    Public Sub New(ByVal player As String, ByVal score As Short)
        Me.player = player
        Me.score = score
    End Sub

End Class
