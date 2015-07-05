<System.Serializable()> Public Class JoinRequest
    Inherits GameSendData
    Protected motivation As String

    Public Sub New(Optional ByVal motivation As String = "")
        Me.motivation = motivation
    End Sub
End Class
