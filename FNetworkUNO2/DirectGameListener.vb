Public Class DirectGameListener
    Inherits GameListener
    Public client As DirectGameControllerConnect

    Public Sub New(ByVal controller As GameController, ByVal client As DirectGameControllerConnect)
        MyBase.New(controller)
        Me.client = client
    End Sub

    Public Overrides Sub SendToClient(ByVal data As GameSendData)
        client.SendToClient(data)
    End Sub
    Public Overrides Sub EndSending(ByVal msg As String)
        SendToClient(New GoodByeMessage(msg))
        'client.EndConnection()
    End Sub
End Class
