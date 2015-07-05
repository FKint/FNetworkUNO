Imports System.Net.sockets
Imports System.threading
Public Class TcpGameControllerConnect
    Inherits GameControllerConnect

    Protected client As TcpClient

    Protected alive As Boolean
    Protected tosend As List(Of Object)
    Protected sendthread As Thread

    Protected readthread As Thread

    Public Sub New(ByVal game As UnoGame, ByVal hostname As String, Optional ByVal port As Integer = ControllerHost.serverport)
        MyBase.new(game)
        client = New TcpClient(hostname, port)

        alive = True
        tosend = New List(Of Object)
        sendthread = New Thread(AddressOf socketsend)
        readthread = New Thread(AddressOf socketread)
        readthread.Start()
        sendthread.Start()
    End Sub

    'Public Overrides Sub Send(ByVal data As GameSendData)

    'End Sub
    Protected Sub socketsend()
        Try
            While True
                If tosend.Count > 0 Then
                    Dim b As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    b = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    b.Serialize(client.GetStream(), tosend.Item(0))

                    'client.GetStream().Write(tosend.Item(0), 0, tosend.Item(0).lengthj)
                    tosend.RemoveAt(0)
                Else
                    'Thread.Sleep(Timeout.Infinite)
                    If alive Then
                        Thread.Sleep(15)
                    Else
                        client.Close()
                        Exit Sub
                    End If
                End If
            End While
        Catch ex As IO.IOException

        End Try
    End Sub
    Protected Sub socketread()
        Try
            While alive
                If Me.client IsNot Nothing Then
                    If Not client.GetStream().CanRead() Then
                        alive = False
                        Exit While
                    End If
                    Dim b As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    b = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    Dim data As Object = b.Deserialize(client.GetStream())
                    SendToClient(data)
                End If
            End While
        Catch ex As Runtime.Serialization.SerializationException
        Catch ex As InvalidOperationException
        Catch ex As IO.IOException

        End Try
    End Sub
    Public Overrides Sub SendToController(ByVal data As Object)
        tosend.Add(data)
        If sendthread.ThreadState = ThreadState.Suspended Then
            sendthread.Start()
            'ElseIf sendthread.ThreadState = ThreadState.WaitSleepJoin Then
            '    sendthread.Start()
        End If
    End Sub
    Public Overrides Sub EndConnection(Optional ByVal msg As String = "Quit")
        MyBase.EndConnection(msg)
        'Me.client.Close()
        alive = False
        'Me.game.Connection()
    End Sub
End Class
