Public MustInherit Class GameControllerConnect
    Protected game As UnoGame
    Protected lstData As List(Of GameSendData)

    Public Sub New(ByVal game As UnoGame)
        Me.game = game
        lstData = New List(Of GameSendData)
    End Sub
    Public MustOverride Sub SendToController(ByVal data As Object)
    Public Sub SendToClient(ByVal data As GameSendData)
        If game IsNot Nothing Then
            While lstData.Count > 0
                game.SendToClient(lstData.Item(0))
                lstData.RemoveAt(0)
            End While
            game.SendToClient(data)
        Else
            lstData.Add(data)
        End If
    End Sub
    Public Sub JoinGame(Optional ByVal motivation As String = "")
        SendToController(New JoinRequest(motivation))
    End Sub
    Public Sub SendListenerInfo()
        SendToController(New ListenerInfo(-1, Me.game.playinstance.Name, Me.game.playinstance.IsParticipating(), Me.game.playinstance.Description))
    End Sub
    Public Overridable Sub EndConnection(Optional ByVal msg As String = "Quit")
        SendToController(New GoodByeMessage(msg))
        Me.game.ConnectionEnded()
    End Sub
    'Public MustOverride Sub connect()

End Class
