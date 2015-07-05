<System.Serializable()> Public Class GameSendChatText
    Inherits GameSendData
    Protected data As String
    Protected sendername As String
    Public Sub New(ByVal text As String, ByVal sender As String)
        data = text
        Me.sendername = sender
    End Sub
    Public Property Text() As String
        Get
            Return data
        End Get
        Set(ByVal value As String)
            data = value
        End Set
    End Property
    Public Property Sender() As String
        Get
            Return sendername
        End Get
        Set(ByVal value As String)
            Me.sendername = value
        End Set
    End Property
End Class
