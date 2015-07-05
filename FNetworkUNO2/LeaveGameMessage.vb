<System.Serializable()> Public Class LeaveGameMessage
    Inherits GameSendData
    Public msg As String
    Public Sub New(ByVal msg As String)
        Me.msg = msg
    End Sub
End Class
