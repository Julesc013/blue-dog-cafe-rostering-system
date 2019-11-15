<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmData))
        Me.lstNameFull = New System.Windows.Forms.ListBox()
        Me.lblNameFull = New System.Windows.Forms.Label()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.lstPhoneNumber = New System.Windows.Forms.ListBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.lstEmailAddress = New System.Windows.Forms.ListBox()
        Me.lstCanClose = New System.Windows.Forms.ListBox()
        Me.btnEditAvailbility = New System.Windows.Forms.Button()
        Me.btnAddData = New System.Windows.Forms.Button()
        Me.lblSelectData = New System.Windows.Forms.Label()
        Me.btnRemoveData = New System.Windows.Forms.Button()
        Me.lblAvailabilityStored = New System.Windows.Forms.Label()
        Me.lstAvailabilityStored = New System.Windows.Forms.ListBox()
        Me.lblTitleData = New System.Windows.Forms.Label()
        Me.btnEditData = New System.Windows.Forms.Button()
        Me.lstColourCode = New System.Windows.Forms.ListBox()
        Me.lblOpenClose = New System.Windows.Forms.Label()
        Me.lblColourCode = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOkData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstNameFull
        '
        Me.lstNameFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNameFull.FormattingEnabled = True
        Me.lstNameFull.ItemHeight = 25
        Me.lstNameFull.Location = New System.Drawing.Point(12, 90)
        Me.lstNameFull.Name = "lstNameFull"
        Me.lstNameFull.Size = New System.Drawing.Size(226, 379)
        Me.lstNameFull.TabIndex = 5
        '
        'lblNameFull
        '
        Me.lblNameFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameFull.Location = New System.Drawing.Point(12, 58)
        Me.lblNameFull.Name = "lblNameFull"
        Me.lblNameFull.Size = New System.Drawing.Size(226, 25)
        Me.lblNameFull.TabIndex = 9
        Me.lblNameFull.Text = "Full Name"
        Me.lblNameFull.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPhoneNumber
        '
        Me.lblPhoneNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhoneNumber.Location = New System.Drawing.Point(244, 58)
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        Me.lblPhoneNumber.Size = New System.Drawing.Size(147, 25)
        Me.lblPhoneNumber.TabIndex = 13
        Me.lblPhoneNumber.Text = "Phone Number"
        Me.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstPhoneNumber
        '
        Me.lstPhoneNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPhoneNumber.FormattingEnabled = True
        Me.lstPhoneNumber.ItemHeight = 25
        Me.lstPhoneNumber.Location = New System.Drawing.Point(244, 90)
        Me.lstPhoneNumber.Name = "lstPhoneNumber"
        Me.lstPhoneNumber.Size = New System.Drawing.Size(147, 379)
        Me.lstPhoneNumber.TabIndex = 12
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailAddress.Location = New System.Drawing.Point(397, 58)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(363, 25)
        Me.lblEmailAddress.TabIndex = 15
        Me.lblEmailAddress.Text = "Email Address"
        Me.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstEmailAddress
        '
        Me.lstEmailAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEmailAddress.FormattingEnabled = True
        Me.lstEmailAddress.ItemHeight = 25
        Me.lstEmailAddress.Location = New System.Drawing.Point(397, 90)
        Me.lstEmailAddress.Name = "lstEmailAddress"
        Me.lstEmailAddress.Size = New System.Drawing.Size(363, 379)
        Me.lstEmailAddress.TabIndex = 14
        '
        'lstCanClose
        '
        Me.lstCanClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCanClose.FormattingEnabled = True
        Me.lstCanClose.ItemHeight = 25
        Me.lstCanClose.Location = New System.Drawing.Point(766, 90)
        Me.lstCanClose.Name = "lstCanClose"
        Me.lstCanClose.Size = New System.Drawing.Size(72, 379)
        Me.lstCanClose.TabIndex = 16
        '
        'btnEditAvailbility
        '
        Me.btnEditAvailbility.Enabled = False
        Me.btnEditAvailbility.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditAvailbility.Location = New System.Drawing.Point(526, 475)
        Me.btnEditAvailbility.Name = "btnEditAvailbility"
        Me.btnEditAvailbility.Size = New System.Drawing.Size(170, 37)
        Me.btnEditAvailbility.TabIndex = 2
        Me.btnEditAvailbility.Text = "Edit Availability"
        Me.btnEditAvailbility.UseVisualStyleBackColor = True
        '
        'btnAddData
        '
        Me.btnAddData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddData.Location = New System.Drawing.Point(12, 475)
        Me.btnAddData.Name = "btnAddData"
        Me.btnAddData.Size = New System.Drawing.Size(137, 37)
        Me.btnAddData.TabIndex = 0
        Me.btnAddData.Text = "Add"
        Me.btnAddData.UseVisualStyleBackColor = True
        '
        'lblSelectData
        '
        Me.lblSelectData.AutoSize = True
        Me.lblSelectData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectData.Location = New System.Drawing.Point(155, 481)
        Me.lblSelectData.Name = "lblSelectData"
        Me.lblSelectData.Size = New System.Drawing.Size(196, 25)
        Me.lblSelectData.TabIndex = 21
        Me.lblSelectData.Text = "Or select a name to..."
        Me.lblSelectData.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnRemoveData
        '
        Me.btnRemoveData.Enabled = False
        Me.btnRemoveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveData.Location = New System.Drawing.Point(702, 475)
        Me.btnRemoveData.Name = "btnRemoveData"
        Me.btnRemoveData.Size = New System.Drawing.Size(136, 37)
        Me.btnRemoveData.TabIndex = 3
        Me.btnRemoveData.Text = "Remove "
        Me.btnRemoveData.UseVisualStyleBackColor = True
        '
        'lblAvailabilityStored
        '
        Me.lblAvailabilityStored.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailabilityStored.Location = New System.Drawing.Point(756, 58)
        Me.lblAvailabilityStored.Name = "lblAvailabilityStored"
        Me.lblAvailabilityStored.Size = New System.Drawing.Size(171, 25)
        Me.lblAvailabilityStored.TabIndex = 24
        Me.lblAvailabilityStored.Text = "Availability Given?"
        Me.lblAvailabilityStored.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstAvailabilityStored
        '
        Me.lstAvailabilityStored.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAvailabilityStored.FormattingEnabled = True
        Me.lstAvailabilityStored.ItemHeight = 25
        Me.lstAvailabilityStored.Location = New System.Drawing.Point(844, 90)
        Me.lstAvailabilityStored.Name = "lstAvailabilityStored"
        Me.lstAvailabilityStored.Size = New System.Drawing.Size(72, 379)
        Me.lstAvailabilityStored.TabIndex = 23
        '
        'lblTitleData
        '
        Me.lblTitleData.Font = New System.Drawing.Font("Geometos", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleData.Location = New System.Drawing.Point(12, 22)
        Me.lblTitleData.Name = "lblTitleData"
        Me.lblTitleData.Size = New System.Drawing.Size(1020, 25)
        Me.lblTitleData.TabIndex = 25
        Me.lblTitleData.Text = "Stored Employee Data"
        Me.lblTitleData.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEditData
        '
        Me.btnEditData.Enabled = False
        Me.btnEditData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditData.Location = New System.Drawing.Point(357, 475)
        Me.btnEditData.Name = "btnEditData"
        Me.btnEditData.Size = New System.Drawing.Size(163, 37)
        Me.btnEditData.TabIndex = 1
        Me.btnEditData.Text = "Change Data"
        Me.btnEditData.UseVisualStyleBackColor = True
        '
        'lstColourCode
        '
        Me.lstColourCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstColourCode.FormattingEnabled = True
        Me.lstColourCode.ItemHeight = 25
        Me.lstColourCode.Location = New System.Drawing.Point(922, 90)
        Me.lstColourCode.Name = "lstColourCode"
        Me.lstColourCode.Size = New System.Drawing.Size(128, 379)
        Me.lstColourCode.TabIndex = 26
        '
        'lblOpenClose
        '
        Me.lblOpenClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpenClose.Location = New System.Drawing.Point(766, 33)
        Me.lblOpenClose.Name = "lblOpenClose"
        Me.lblOpenClose.Size = New System.Drawing.Size(150, 25)
        Me.lblOpenClose.TabIndex = 27
        Me.lblOpenClose.Text = "Can Close?"
        Me.lblOpenClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblColourCode
        '
        Me.lblColourCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColourCode.Location = New System.Drawing.Point(922, 33)
        Me.lblColourCode.Name = "lblColourCode"
        Me.lblColourCode.Size = New System.Drawing.Size(128, 50)
        Me.lblColourCode.TabIndex = 28
        Me.lblColourCode.Text = "Colour Code (RGB)"
        Me.lblColourCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(844, 475)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 37)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnOkData
        '
        Me.btnOkData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkData.Location = New System.Drawing.Point(922, 475)
        Me.btnOkData.Name = "btnOkData"
        Me.btnOkData.Size = New System.Drawing.Size(128, 37)
        Me.btnOkData.TabIndex = 4
        Me.btnOkData.Text = "Accept"
        Me.btnOkData.UseVisualStyleBackColor = True
        '
        'frmData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1062, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblColourCode)
        Me.Controls.Add(Me.lblOpenClose)
        Me.Controls.Add(Me.lstColourCode)
        Me.Controls.Add(Me.btnEditData)
        Me.Controls.Add(Me.lblTitleData)
        Me.Controls.Add(Me.lblAvailabilityStored)
        Me.Controls.Add(Me.lstAvailabilityStored)
        Me.Controls.Add(Me.btnRemoveData)
        Me.Controls.Add(Me.lblSelectData)
        Me.Controls.Add(Me.btnAddData)
        Me.Controls.Add(Me.btnOkData)
        Me.Controls.Add(Me.btnEditAvailbility)
        Me.Controls.Add(Me.lstCanClose)
        Me.Controls.Add(Me.lblEmailAddress)
        Me.Controls.Add(Me.lstEmailAddress)
        Me.Controls.Add(Me.lblPhoneNumber)
        Me.Controls.Add(Me.lstPhoneNumber)
        Me.Controls.Add(Me.lblNameFull)
        Me.Controls.Add(Me.lstNameFull)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Modify Employee Data"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstNameFull As ListBox
    Friend WithEvents lblNameFull As Label
    Friend WithEvents lblPhoneNumber As Label
    Friend WithEvents lstPhoneNumber As ListBox
    Friend WithEvents lblEmailAddress As Label
    Friend WithEvents lstEmailAddress As ListBox
    Friend WithEvents lstCanClose As ListBox
    Friend WithEvents btnEditAvailbility As Button
    Friend WithEvents btnAddData As Button
    Friend WithEvents lblSelectData As Label
    Friend WithEvents btnRemoveData As Button
    Friend WithEvents lblAvailabilityStored As Label
    Friend WithEvents lstAvailabilityStored As ListBox
    Friend WithEvents lblTitleData As Label
    Friend WithEvents btnEditData As Button
    Friend WithEvents lstColourCode As ListBox
    Friend WithEvents lblOpenClose As Label
    Friend WithEvents lblColourCode As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOkData As Button
End Class
