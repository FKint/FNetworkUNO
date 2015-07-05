<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbctrlGames = New System.Windows.Forms.TabControl
        Me.tbpgStart = New System.Windows.Forms.TabPage
        Me.btnHostGame = New System.Windows.Forms.Button
        Me.btnJoinGame = New System.Windows.Forms.Button
        Me.mainMenu = New System.Windows.Forms.MenuStrip
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseCurrentTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.JoinGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HostGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tbctrlGames.SuspendLayout()
        Me.tbpgStart.SuspendLayout()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbctrlGames
        '
        Me.tbctrlGames.Controls.Add(Me.tbpgStart)
        Me.tbctrlGames.Location = New System.Drawing.Point(0, 24)
        Me.tbctrlGames.Name = "tbctrlGames"
        Me.tbctrlGames.SelectedIndex = 0
        Me.tbctrlGames.Size = New System.Drawing.Size(907, 667)
        Me.tbctrlGames.TabIndex = 0
        '
        'tbpgStart
        '
        Me.tbpgStart.Controls.Add(Me.btnHostGame)
        Me.tbpgStart.Controls.Add(Me.btnJoinGame)
        Me.tbpgStart.Location = New System.Drawing.Point(4, 22)
        Me.tbpgStart.Name = "tbpgStart"
        Me.tbpgStart.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgStart.Size = New System.Drawing.Size(899, 641)
        Me.tbpgStart.TabIndex = 0
        Me.tbpgStart.Text = "Start"
        Me.tbpgStart.UseVisualStyleBackColor = True
        '
        'btnHostGame
        '
        Me.btnHostGame.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnHostGame.Location = New System.Drawing.Point(428, 150)
        Me.btnHostGame.Name = "btnHostGame"
        Me.btnHostGame.Size = New System.Drawing.Size(75, 23)
        Me.btnHostGame.TabIndex = 0
        Me.btnHostGame.Text = "Host  Game"
        Me.btnHostGame.UseVisualStyleBackColor = True
        '
        'btnJoinGame
        '
        Me.btnJoinGame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnJoinGame.Location = New System.Drawing.Point(428, 106)
        Me.btnJoinGame.Name = "btnJoinGame"
        Me.btnJoinGame.Size = New System.Drawing.Size(75, 23)
        Me.btnJoinGame.TabIndex = 0
        Me.btnJoinGame.Text = "Join Game"
        Me.btnJoinGame.UseVisualStyleBackColor = True
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(907, 24)
        Me.mainMenu.TabIndex = 1
        Me.mainMenu.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JoinGameToolStripMenuItem, Me.HostGameToolStripMenuItem, Me.CloseCurrentTabToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CloseCurrentTabToolStripMenuItem
        '
        Me.CloseCurrentTabToolStripMenuItem.Name = "CloseCurrentTabToolStripMenuItem"
        Me.CloseCurrentTabToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CloseCurrentTabToolStripMenuItem.Text = "Close current tab"
        '
        'JoinGameToolStripMenuItem
        '
        Me.JoinGameToolStripMenuItem.Name = "JoinGameToolStripMenuItem"
        Me.JoinGameToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.JoinGameToolStripMenuItem.Text = "Join Game"
        '
        'HostGameToolStripMenuItem
        '
        Me.HostGameToolStripMenuItem.Name = "HostGameToolStripMenuItem"
        Me.HostGameToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.HostGameToolStripMenuItem.Text = "Host Game"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 691)
        Me.Controls.Add(Me.tbctrlGames)
        Me.Controls.Add(Me.mainMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form1"
        Me.tbctrlGames.ResumeLayout(False)
        Me.tbpgStart.ResumeLayout(False)
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbctrlGames As System.Windows.Forms.TabControl
    Friend WithEvents tbpgStart As System.Windows.Forms.TabPage
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHostGame As System.Windows.Forms.Button
    Friend WithEvents btnJoinGame As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseCurrentTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JoinGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HostGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
