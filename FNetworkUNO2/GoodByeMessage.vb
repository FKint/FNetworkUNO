<System.Serializable()> Public Class GoodByeMessage
    Inherits GameSendData
    Protected msg As String
    Public Sub New(ByVal msg As String)
        Me.msg = msg
    End Sub
End Class
