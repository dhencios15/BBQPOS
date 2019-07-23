<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.mainPanel = New System.Windows.Forms.Panel()
        Me.homePanel = New System.Windows.Forms.Panel()
        Me.reportsPanel = New System.Windows.Forms.Panel()
        Me.settingsPanel = New System.Windows.Forms.Panel()
        Me.mainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(1112, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 40)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Location = New System.Drawing.Point(12, 12)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(56, 40)
        Me.btnHome.TabIndex = 9
        Me.btnHome.Text = "HOME"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(74, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(56, 40)
        Me.btnSettings.TabIndex = 10
        Me.btnSettings.Text = "SETTING"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(136, 12)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(56, 40)
        Me.btnReport.TabIndex = 11
        Me.btnReport.Text = "REPORT"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'mainPanel
        '
        Me.mainPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mainPanel.Controls.Add(Me.homePanel)
        Me.mainPanel.Controls.Add(Me.reportsPanel)
        Me.mainPanel.Controls.Add(Me.settingsPanel)
        Me.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.mainPanel.Location = New System.Drawing.Point(0, 70)
        Me.mainPanel.Name = "mainPanel"
        Me.mainPanel.Size = New System.Drawing.Size(1156, 606)
        Me.mainPanel.TabIndex = 0
        '
        'homePanel
        '
        Me.homePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.homePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.homePanel.Location = New System.Drawing.Point(0, 0)
        Me.homePanel.Name = "homePanel"
        Me.homePanel.Size = New System.Drawing.Size(1154, 604)
        Me.homePanel.TabIndex = 4
        '
        'reportsPanel
        '
        Me.reportsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.reportsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportsPanel.Location = New System.Drawing.Point(0, 0)
        Me.reportsPanel.Name = "reportsPanel"
        Me.reportsPanel.Size = New System.Drawing.Size(1154, 604)
        Me.reportsPanel.TabIndex = 3
        '
        'settingsPanel
        '
        Me.settingsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.settingsPanel.Location = New System.Drawing.Point(0, 0)
        Me.settingsPanel.Name = "settingsPanel"
        Me.settingsPanel.Size = New System.Drawing.Size(1154, 604)
        Me.settingsPanel.TabIndex = 4
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1156, 676)
        Me.Controls.Add(Me.mainPanel)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.mainPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents mainPanel As Panel
    Friend WithEvents homePanel As Panel
    Friend WithEvents reportsPanel As Panel
    Friend WithEvents settingsPanel As Panel
End Class
