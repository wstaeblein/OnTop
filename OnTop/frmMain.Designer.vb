<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IniciarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PararToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ConfiguraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.TrayMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tray
        '
        Me.Tray.ContextMenuStrip = Me.TrayMenu
        Me.Tray.Icon = CType(resources.GetObject("Tray.Icon"), System.Drawing.Icon)
        Me.Tray.Text = "OnTop v1.0"
        Me.Tray.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IniciarToolStripMenuItem, Me.PararToolStripMenuItem, Me.ToolStripSeparator2, Me.ConfiguraçõesToolStripMenuItem, Me.ToolStripSeparator1, Me.SobreToolStripMenuItem, Me.TerminarToolStripMenuItem})
        Me.TrayMenu.Name = "TrayMenu"
        Me.TrayMenu.Size = New System.Drawing.Size(153, 148)
        '
        'IniciarToolStripMenuItem
        '
        Me.IniciarToolStripMenuItem.Enabled = False
        Me.IniciarToolStripMenuItem.Image = Global.OnTop.My.Resources.Resources.glyphicons_173_play
        Me.IniciarToolStripMenuItem.Name = "IniciarToolStripMenuItem"
        Me.IniciarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IniciarToolStripMenuItem.Text = "Iniciar"
        '
        'PararToolStripMenuItem
        '
        Me.PararToolStripMenuItem.Image = Global.OnTop.My.Resources.Resources.glyphicons_174_pause
        Me.PararToolStripMenuItem.Name = "PararToolStripMenuItem"
        Me.PararToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PararToolStripMenuItem.Text = "Parar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'ConfiguraçõesToolStripMenuItem
        '
        Me.ConfiguraçõesToolStripMenuItem.Image = Global.OnTop.My.Resources.Resources.glyphicons_136_cogwheel
        Me.ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        Me.ConfiguraçõesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Image = Global.OnTop.My.Resources.Resources.glyphicons_195_circle_info
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SobreToolStripMenuItem.Text = "Sobre"
        '
        'TerminarToolStripMenuItem
        '
        Me.TerminarToolStripMenuItem.Image = Global.OnTop.My.Resources.Resources.glyphicons_063_power
        Me.TerminarToolStripMenuItem.Name = "TerminarToolStripMenuItem"
        Me.TerminarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TerminarToolStripMenuItem.Text = "Terminar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OnTop"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(210, 40)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.ShowInTaskbar = False
        Me.TrayMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents IniciarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PararToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConfiguraçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
