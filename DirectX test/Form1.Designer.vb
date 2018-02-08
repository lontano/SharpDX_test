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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ButtonGameRun = New System.Windows.Forms.Button()
    Me.PanelContainer = New System.Windows.Forms.Panel()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.TimerReDraw = New System.Windows.Forms.Timer(Me.components)
    Me.ButtonMinitri = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'ButtonGameRun
    '
    Me.ButtonGameRun.Location = New System.Drawing.Point(12, 12)
    Me.ButtonGameRun.Name = "ButtonGameRun"
    Me.ButtonGameRun.Size = New System.Drawing.Size(51, 34)
    Me.ButtonGameRun.TabIndex = 1
    Me.ButtonGameRun.Text = "Run"
    Me.ButtonGameRun.UseVisualStyleBackColor = True
    '
    'PanelContainer
    '
    Me.PanelContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelContainer.Location = New System.Drawing.Point(12, 69)
    Me.PanelContainer.Name = "PanelContainer"
    Me.PanelContainer.Size = New System.Drawing.Size(436, 239)
    Me.PanelContainer.TabIndex = 2
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(454, 69)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(436, 239)
    Me.Panel1.TabIndex = 3
    '
    'TimerReDraw
    '
    Me.TimerReDraw.Enabled = True
    '
    'ButtonMinitri
    '
    Me.ButtonMinitri.Location = New System.Drawing.Point(209, 17)
    Me.ButtonMinitri.Name = "ButtonMinitri"
    Me.ButtonMinitri.Size = New System.Drawing.Size(78, 28)
    Me.ButtonMinitri.TabIndex = 4
    Me.ButtonMinitri.Text = "Mini tri"
    Me.ButtonMinitri.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(952, 574)
    Me.Controls.Add(Me.ButtonMinitri)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.PanelContainer)
    Me.Controls.Add(Me.ButtonGameRun)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents ButtonGameRun As Button
  Friend WithEvents PanelContainer As Panel
  Friend WithEvents Panel1 As Panel
  Friend WithEvents TimerReDraw As Timer
  Friend WithEvents ButtonMinitri As Button
End Class
