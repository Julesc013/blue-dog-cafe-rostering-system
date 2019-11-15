<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmShifts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShifts))
        Me.lstShifts = New System.Windows.Forms.ListBox()
        Me.btnAddShift = New System.Windows.Forms.Button()
        Me.btnRemoveShift = New System.Windows.Forms.Button()
        Me.lblRemoveShift = New System.Windows.Forms.Label()
        Me.btnOkShifts = New System.Windows.Forms.Button()
        Me.lblTitleShifts = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstShifts
        '
        Me.lstShifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShifts.FormattingEnabled = True
        Me.lstShifts.ItemHeight = 25
        Me.lstShifts.Location = New System.Drawing.Point(12, 52)
        Me.lstShifts.Name = "lstShifts"
        Me.lstShifts.Size = New System.Drawing.Size(225, 379)
        Me.lstShifts.TabIndex = 0
        '
        'btnAddShift
        '
        Me.btnAddShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddShift.Location = New System.Drawing.Point(248, 52)
        Me.btnAddShift.Name = "btnAddShift"
        Me.btnAddShift.Size = New System.Drawing.Size(143, 37)
        Me.btnAddShift.TabIndex = 0
        Me.btnAddShift.Text = "Add Shift"
        Me.btnAddShift.UseVisualStyleBackColor = True
        '
        'btnRemoveShift
        '
        Me.btnRemoveShift.Enabled = False
        Me.btnRemoveShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveShift.Location = New System.Drawing.Point(248, 145)
        Me.btnRemoveShift.Name = "btnRemoveShift"
        Me.btnRemoveShift.Size = New System.Drawing.Size(143, 37)
        Me.btnRemoveShift.TabIndex = 1
        Me.btnRemoveShift.Text = "Remove Shift"
        Me.btnRemoveShift.UseVisualStyleBackColor = True
        '
        'lblRemoveShift
        '
        Me.lblRemoveShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemoveShift.Location = New System.Drawing.Point(248, 92)
        Me.lblRemoveShift.Name = "lblRemoveShift"
        Me.lblRemoveShift.Size = New System.Drawing.Size(143, 50)
        Me.lblRemoveShift.TabIndex = 3
        Me.lblRemoveShift.Text = "Or select from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the list to..."
        Me.lblRemoveShift.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOkShifts
        '
        Me.btnOkShifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkShifts.Location = New System.Drawing.Point(248, 394)
        Me.btnOkShifts.Name = "btnOkShifts"
        Me.btnOkShifts.Size = New System.Drawing.Size(143, 37)
        Me.btnOkShifts.TabIndex = 3
        Me.btnOkShifts.Text = "Accept"
        Me.btnOkShifts.UseVisualStyleBackColor = True
        '
        'lblTitleShifts
        '
        Me.lblTitleShifts.Font = New System.Drawing.Font("Geometos", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleShifts.Location = New System.Drawing.Point(12, 15)
        Me.lblTitleShifts.Name = "lblTitleShifts"
        Me.lblTitleShifts.Size = New System.Drawing.Size(379, 25)
        Me.lblTitleShifts.TabIndex = 26
        Me.lblTitleShifts.Text = "Edit Shift-Blocks"
        Me.lblTitleShifts.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(248, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(143, 37)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'frmShifts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 444)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblTitleShifts)
        Me.Controls.Add(Me.btnOkShifts)
        Me.Controls.Add(Me.lblRemoveShift)
        Me.Controls.Add(Me.btnRemoveShift)
        Me.Controls.Add(Me.btnAddShift)
        Me.Controls.Add(Me.lstShifts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShifts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Shift Blocks"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstShifts As ListBox
    Friend WithEvents btnAddShift As Button
    Friend WithEvents btnRemoveShift As Button
    Friend WithEvents lblRemoveShift As Label
    Friend WithEvents btnOkShifts As Button
    Friend WithEvents lblTitleShifts As Label
    Friend WithEvents btnCancel As Button
End Class
