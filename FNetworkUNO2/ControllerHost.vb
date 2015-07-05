Imports System.Net.Sockets
Imports System.Threading

Public Class ControllerHost
    Public Const serverport = 51342

    Protected listener As TcpListener
    Protected accepting As Boolean
    Protected acceptingthread As Thread

    Public controller As GameController
    Protected myport As Integer = serverport

    Public Sub New(ByVal controller As GameController, ByVal port As Integer)
        Me.controller = controller
        Me.myport = port
    End Sub
    Protected Sub AcceptClients()
        listener = New TcpListener(Net.IPAddress.Any, myport)
        listener.Start()
        While accepting
            Try
                AddClient(listener.AcceptTcpClient)
            Catch ex As SocketException
                If accepting Then
                    MsgBox("Fout bij toevoegen clients")
                End If
            End Try
        End While
    End Sub
    Public Sub StartAccepting()
        accepting = True
        acceptingthread = New Thread(AddressOf Me.AcceptClients)
        acceptingthread.Start()
    End Sub

    Public Sub AddClient(ByVal client As TcpClient)
        Dim listener As GameListener
        listener = New TcpGameListener(Me.controller, client)
        controller.AddListener(listener)
    End Sub
    Public Sub Dispose()
        Me.accepting = False
        Me.listener.Stop()
    End Sub
End Class
