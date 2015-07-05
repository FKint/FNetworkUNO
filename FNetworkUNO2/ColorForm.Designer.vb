<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rbtBlue = New System.Windows.Forms.RadioButton
        Me.rbtYellow = New System.Windows.Forms.RadioButton
        Me.rbtGreen = New System.Windows.Forms.RadioButton
        Me.rbtRed = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(69, 138)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtRed)
        Me.Panel1.Controls.Add(Me.rbtGreen)
        Me.Panel1.Controls.Add(Me.rbtYellow)
        Me.Panel1.Controls.Add(Me.rbtBlue)
        Me.Panel1.Location = New System.Drawing.Point(12, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 94)
        Me.Panel1.TabIndex = 1
        '
        'rbtBlue
        '
        Me.rbtBlue.AutoSize = True
        Me.rbtBlue.Checked = True
        Me.rbtBlue.Location = New System.Drawing.Point(12, 3)
        Me.rbtBlue.Name = "rbtBlue"
        Me.rbtBlue.Size = New System.Drawing.Size(54, 17)
        Me.rbtBlue.TabIndex = 0
        Me.rbtBlue.TabStop = True
        Me.rbtBlue.Text = "Blauw"
        Me.rbtBlue.UseVisualStyleBackColor = True
        '
        'rbtYellow
        '
        Me.rbtYellow.AutoSize = True
        Me.rbtYellow.Location = New System.Drawing.Point(12, 26)
        Me.rbtYellow.Name = "rbtYellow"
        Me.rbtYellow.Size = New System.Drawing.Size(47, 17)
        Me.rbtYellow.TabIndex = 0
        Me.rbtYellow.Text = "Geel"
        Me.rbtYellow.UseVisualStyleBackColor = True
        '
        'rbtGreen
        '
        Me.rbtGreen.AutoSize = True
        Me.rbtGreen.Location = New System.Drawing.Point(12, 49)
        Me.rbtGreen.Name = "rbtGreen"
        Me.rbtGreen.Size = New System.Drawing.Size(54, 17)
        Me.rbtGreen.TabIndex = 0
        Me.rbtGreen.Text = "Groen"
        Me.rbtGreen.UseVisualStyleBackColor = True
        '
        'rbtRed
        '
        Me.rbtRed.AutoSize = True
        Me.rbtRed.Location = New System.Drawing.Point(12, 72)
        Me.rbtRed.Name = "rbtRed"
        Me.rbtRed.Size = New System.Drawing.Size(51, 17)
        Me.rbtRed.TabIndex = 0
        Me.rbtRed.Text = "Rood"
        Me.rbtRed.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Kies het nieuwe kleur:"
        '
        'ColorForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(227, 179)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColorForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ColorForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtGreen As System.Windows.Forms.RadioButton
    Friend WithEvents rbtYellow As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBlue As System.Windows.Forms.RadioButton
    Friend WithEvents rbtRed As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
