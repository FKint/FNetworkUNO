<System.Serializable()> Public Class YourTurnMessage
    Inherits GameSendData
    Protected time As Integer
    Public Sub New(ByVal time As Integer)
        MyBase.new()
        Me.time = time
    End Sub

End Class
