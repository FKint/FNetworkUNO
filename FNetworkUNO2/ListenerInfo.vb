<System.Serializable()> Public Class ListenerInfo
    Inherits GameSendData
    Protected listenername As String
    Protected listenerdescription As String
    Protected participant As Boolean
    Protected listenerid As Short
    Public Sub New(ByVal id As Short, ByVal name As String, ByVal participant As Boolean, Optional ByVal description As String = "")
        Me.listenername = name
        Me.listenerdescription = description
        Me.participant = participant
        Me.listenerid = id
    End Sub
    Public Property Name() As String
        Get
            Return listenername
        End Get
        Set(ByVal value As String)
            Me.listenername = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return listenerdescription
        End Get
        Set(ByVal value As String)
            Me.listenerdescription = value
        End Set
    End Property
    Public Property Participating() As Boolean
        Get
            Return Me.participant
        End Get
        Set(ByVal value As Boolean)
            Me.participant = value
        End Set
    End Property
    Public Property ID() As Short
        Get
            Return listenerid
        End Get
        Set(ByVal value As Short)
            Me.listenerid = value
        End Set
    End Property
End Class
