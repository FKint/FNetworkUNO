<System.Serializable()> Public Class HostLeft
    Inherits GameSendData

    Protected msg As String
    'Protected token As String
    'Protected port As Integer
    'Protected newhost As String

    Public Sub New(ByVal msg As String)
        ', ByVal newhost As String, ByVal port As Integer

        Me.msg = msg
        'Me.token = ""
        'Me.newhost = newhost
        'Me.port = port
    End Sub
    'Public Sub New(ByVal hostleft As HostLeft, ByVal token As String)
    '    Me.msg = hostleft.msg
    '    Me.newhost = hostleft.newhost
    '    Me.port = hostleft.port
    '    Me.token = token
    'End Sub
End Class
