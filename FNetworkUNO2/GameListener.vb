Public MustInherit Class GameListener
    Protected controller As GameController
    Protected listenername As String
    Protected listenerdescription As String
    Protected infogot As Boolean = False
    Dim participant As Boolean = False
    Public Sub New(ByVal controller As GameController)
        Me.controller = controller

    End Sub
    Public Sub GameStarted()
        SendToClient(New GameStartedMessage())
    End Sub
    Public MustOverride Sub SendToClient(ByVal data As GameSendData)
    Public Sub SetInfo(ByVal info As ListenerInfo)
        infogot = True
        Me.name = info.Name
        Me.listenerdescription = info.Description
    End Sub
    Public Function GetInfoGot() As Boolean
        Return infogot
    End Function
    Public Property Description() As String
        Get
            Return listenerdescription
        End Get
        Set(ByVal value As String)
            Me.listenerdescription = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return listenername
        End Get
        Set(ByVal value As String)
            Me.listenername = value
        End Set
    End Property
    Public Property Participating() As Boolean
        Get
            Return participant
        End Get
        Set(ByVal value As Boolean)
            Me.participant = value
        End Set
    End Property
    Public MustOverride Sub EndSending(ByVal msg As String)
End Class
