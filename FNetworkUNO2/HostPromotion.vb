<System.Serializable()> Public Class HostPromotion
    Inherits GameSendData

    Public info As FullGameInfo

    Public Sub New(ByVal info As FullGameInfo)
        Me.info = info
    End Sub
End Class
