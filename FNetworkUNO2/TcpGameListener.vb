Imports System.Net.sockets
Imports System.Threading

Public Class TcpGameListener
    Inherits GameListener

    Protected client As TcpClient

    Protected alive As Boolean
    Protected tosend As List(Of Object)
    Protected sendthread As Thread

    Protected readthread As Thread

    Protected stopconnection As Boolean = False
    Protected goodbyemessage As String = ""

    Public Sub New(ByVal controller As GameController, ByVal client As TcpClient)
        MyBase.new(controller)
        Me.client = client
        alive = True
        tosend = New List(Of Object)
        sendthread = New Thread(AddressOf socketsend)
        readthread = New Thread(AddressOf socketread)
        readthread.Start()
        'SendToClient(New GameSendChatText("Hallo", Me.name))
        sendthread.Start()
    End Sub

    Public Overrides Sub SendToClient(ByVal data As GameSendData)
        tosend.Add(data)
        'If sendthread.ThreadState <> ThreadState.Running Then
        '    sendthread.Start()
        'End If
        'If sendthread.ThreadState = ThreadState.WaitSleepJoin Then
        '    sendthread.Join()
        'End If
    End Sub
    Protected Sub socketsend()
        Try
            While True And Me.client IsNot Nothing
                If tosend.Count > 0 Then
                    Dim b As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    b = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    b.Serialize(client.GetStream(), tosend.Item(0))

                    'client.GetStream().Write(tosend.Item(0), 0, tosend.Item(0).lengthj)
                    tosend.RemoveAt(0)
                Else
                    'Thread.Sleep(Timeout.Infinite)
                    'Thread.CurrentThread.Join()
                    If stopconnection Then
                        If Me.goodbyemessage IsNot Nothing Then
                            Dim b As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            b = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                            b.Serialize(client.GetStream(), New GoodByeMessage(Me.goodbyemessage))
                        End If
                        Me.client.Close()
                        Me.controller.RemoveListener(Me, "")
                    End If
                    Thread.Sleep(15)
                End If
            End While
        Catch ex As IO.IOException
            Me.controller.RemoveListener(Me, "Verbinding ging verloren")
        Catch ex As ObjectDisposedException
            Me.controller.RemoveListener(Me, "")
        End Try
    End Sub
    Protected Sub socketread()
        Try
            While alive
                Dim b As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                b = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                Dim data As Object = b.Deserialize(client.GetStream())
                controller.SendToController(Me, data)
            End While
        Catch ex As Runtime.Serialization.SerializationException
            alive = False
            Me.controller.RemoveListener(Me, "Verbinding ging verloren")

        Catch ex As IO.IOException
            alive = False
            Me.controller.RemoveListener(Me, "Verbinding ging verloren")
        End Try
    End Sub
    Public Overrides Sub EndSending(ByVal msg As String)
        Me.stopconnection = True
        Me.goodbyemessage = msg
    End Sub
End Class
