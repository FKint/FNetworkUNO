Public Class Form1
    Private Sub joinGame()
        Dim tabpage As New TabPage
        tabpage.Text = "Uno"
        Me.tbctrlGames.TabPages.Add(tabpage)
        Me.tbctrlGames.SelectedTab = tabpage
        Dim panel As GamePanel = New GamePanel(tabpage, False)
        tabpage.Controls.Add(panel)
        panel.Start()
    End Sub
    Private Sub btnJoinGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoinGame.Click
        joinGame()
    End Sub
    Private Sub hostGame()
        Dim tabpage As New TabPage
        tabpage.Text = "Uno"
        Me.tbctrlGames.TabPages.Add(tabpage)
        Me.tbctrlGames.SelectedTab = tabpage
        Dim panel As GamePanel = New GamePanel(tabpage, True)
        tabpage.Controls.Add(panel)
        panel.Start()
    End Sub
    Private Sub btnHostGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHostGame.Click
        hostGame()
    End Sub

    Protected Delegate Sub AddTabCallBack(ByVal tabpage As TabPage)
    Protected Sub AddTabPage(ByVal tabpage As TabPage)
        Dim p As GamePanel = CType(tabpage.Controls(0), GamePanel)
        If p.txtChatbox.InvokeRequired Then
            Dim d As New AddTabCallBack(AddressOf AddTabPage)
            Invoke(d, New Object() {tabpage})
        Else
            tbctrlGames.TabPages.Add(tabpage)
            Me.tbctrlGames.SelectedTab = tabpage
        End If
    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'For Each p As TabPage In Me.tbctrlGames.TabPages
        '    If p.Controls.Count > 0 Then
        '        If TypeOf p.Controls.Item(0) Is GamePanel Then
        '            Dim gp As GamePanel = CType(p.Controls.Item(0), GamePanel)
        '            If Not gp.game Is Nothing Then
        '                gp.game.StopGame("Quit")
        '            End If
        '            If gp.controller IsNot Nothing Then
        '                gp.controller.StopGame("Quit")
        '            End If
        '        End If
        '    End If

        'Next
        Application.Exit()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
        Application.Exit()
    End Sub

    Private Sub CloseCurrentTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseCurrentTabToolStripMenuItem.Click
        Dim t As TabPage = Me.tbctrlGames.SelectedTab
        Me.tbctrlGames.TabPages.Remove(t)
        t.Dispose()
    End Sub

    Private Sub JoinGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JoinGameToolStripMenuItem.Click
        joinGame()
    End Sub

    Private Sub HostGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HostGameToolStripMenuItem.Click
        hostGame()
    End Sub
End Class
