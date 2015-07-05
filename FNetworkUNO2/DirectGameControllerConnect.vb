Public Class DirectGameControllerConnect
    Inherits GameControllerConnect
    Public controller As GameController
    Public listener As DirectGameListener
    Public Sub New(ByVal controller As GameController, ByVal game As UnoGame)
        MyBase.New(game)
        Me.controller = controller
        listener = New DirectGameListener(controller, Me)
        'listener = Nothing
        controller.AddListener(listener)
        'Me.SendListenerInfo()
    End Sub

    Public Overrides Sub SendToController(ByVal data As Object)
        controller.SendToController(listener, data)
    End Sub
    'Public Overrides Sub EndConnection()
    '    Me.game.ConnectionEnded()
    'End Sub
    'Public Sub Connect()
    '    listener = New DirectGameListener(controller, Me)
    '    controller.AddListener(listener)
    'End Sub
End Class
