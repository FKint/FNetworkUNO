<System.Serializable()> Public Class GameRoomInfo
    Inherits GameSendData
    Public listeners As List(Of ListenerInfo)
    Protected gamestarted As Boolean

    Public Sub New(ByVal listeners As List(Of ListenerInfo), ByVal gamestarted As Boolean)
        Me.listeners = listeners
        Me.gamestarted = gamestarted
    End Sub
End Class
