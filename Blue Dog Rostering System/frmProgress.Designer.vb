<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgress))
        Me.barProgress = New System.Windows.Forms.ProgressBar()
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.lblJob = New System.Windows.Forms.Label()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'barProgress
        '
        Me.barProgress.Location = New System.Drawing.Point(12, 82)
        Me.barProgress.Maximum = 107
        Me.barProgress.Name = "barProgress"
        Me.barProgress.Size = New System.Drawing.Size(330, 23)
        Me.barProgress.Step = 1
        Me.barProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.barProgress.TabIndex = 0
        Me.barProgress.UseWaitCursor = True
        '
        'lblInformation
        '
        Me.lblInformation.Location = New System.Drawing.Point(12, 9)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(330, 19)
        Me.lblInformation.TabIndex = 4
        Me.lblInformation.Text = "This process may take a few seconds."
        Me.lblInformation.UseWaitCursor = True
        '
        'lblJob
        '
        Me.lblJob.Location = New System.Drawing.Point(12, 39)
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Size = New System.Drawing.Size(330, 19)
        Me.lblJob.TabIndex = 5
        Me.lblJob.UseWaitCursor = True
        '
        'lblTask
        '
        Me.lblTask.Location = New System.Drawing.Point(12, 58)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(330, 19)
        Me.lblTask.TabIndex = 6
        Me.lblTask.UseWaitCursor = True
        '
        'frmProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTask)
        Me.Controls.Add(Me.lblJob)
        Me.Controls.Add(Me.lblInformation)
        Me.Controls.Add(Me.barProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgress"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.UseWaitCursor = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents barProgress As ProgressBar
    Friend WithEvents lblInformation As Label
    Friend WithEvents lblJob As Label
    Friend WithEvents lblTask As Label
End Class
