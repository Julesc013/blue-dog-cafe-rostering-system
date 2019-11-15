<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvailability
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAvailability))
        Me.lblThursday = New System.Windows.Forms.Label()
        Me.lblTitleAvailability = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOkAvailability = New System.Windows.Forms.Button()
        Me.btnCancelAvailability = New System.Windows.Forms.Button()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.cmbThursdayStart = New System.Windows.Forms.ComboBox()
        Me.cmbThursdayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbFridayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbFridayStart = New System.Windows.Forms.ComboBox()
        Me.cmbSaturdayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbSaturdayStart = New System.Windows.Forms.ComboBox()
        Me.cmbSundayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbSundayStart = New System.Windows.Forms.ComboBox()
        Me.cmbMondayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbMondayStart = New System.Windows.Forms.ComboBox()
        Me.cmbTuesdayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbTuesdayStart = New System.Windows.Forms.ComboBox()
        Me.cmbWednesdayFinish = New System.Windows.Forms.ComboBox()
        Me.cmbWednesdayStart = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblThursday
        '
        Me.lblThursday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThursday.Location = New System.Drawing.Point(120, 57)
        Me.lblThursday.Name = "lblThursday"
        Me.lblThursday.Size = New System.Drawing.Size(118, 25)
        Me.lblThursday.TabIndex = 10
        Me.lblThursday.Text = "Thursday"
        Me.lblThursday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleAvailability
        '
        Me.lblTitleAvailability.Font = New System.Drawing.Font("Geometos", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleAvailability.Location = New System.Drawing.Point(12, 22)
        Me.lblTitleAvailability.Name = "lblTitleAvailability"
        Me.lblTitleAvailability.Size = New System.Drawing.Size(976, 25)
        Me.lblTitleAvailability.TabIndex = 13
        Me.lblTitleAvailability.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Friday"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(492, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 25)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Sunday"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(368, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 25)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Saturday"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(864, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 25)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Wednesday"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(740, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 25)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Tuesday"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(616, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 25)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Monday"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOkAvailability
        '
        Me.btnOkAvailability.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAvailability.Location = New System.Drawing.Point(864, 176)
        Me.btnOkAvailability.Name = "btnOkAvailability"
        Me.btnOkAvailability.Size = New System.Drawing.Size(118, 37)
        Me.btnOkAvailability.TabIndex = 1
        Me.btnOkAvailability.Text = "Accept"
        Me.btnOkAvailability.UseVisualStyleBackColor = True
        '
        'btnCancelAvailability
        '
        Me.btnCancelAvailability.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelAvailability.Location = New System.Drawing.Point(740, 176)
        Me.btnCancelAvailability.Name = "btnCancelAvailability"
        Me.btnCancelAvailability.Size = New System.Drawing.Size(118, 37)
        Me.btnCancelAvailability.TabIndex = 0
        Me.btnCancelAvailability.Text = "Cancel"
        Me.btnCancelAvailability.UseVisualStyleBackColor = True
        Me.btnCancelAvailability.Visible = False
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartTime.Location = New System.Drawing.Point(6, 92)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(108, 25)
        Me.lblStartTime.TabIndex = 34
        Me.lblStartTime.Text = "Start Time:"
        Me.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndTime.Location = New System.Drawing.Point(12, 131)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(102, 25)
        Me.lblEndTime.TabIndex = 35
        Me.lblEndTime.Text = "End Time:"
        Me.lblEndTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbThursdayStart
        '
        Me.cmbThursdayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbThursdayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbThursdayStart.FormattingEnabled = True
        Me.cmbThursdayStart.Location = New System.Drawing.Point(120, 89)
        Me.cmbThursdayStart.Name = "cmbThursdayStart"
        Me.cmbThursdayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbThursdayStart.TabIndex = 36
        '
        'cmbThursdayFinish
        '
        Me.cmbThursdayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbThursdayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbThursdayFinish.FormattingEnabled = True
        Me.cmbThursdayFinish.Location = New System.Drawing.Point(120, 128)
        Me.cmbThursdayFinish.Name = "cmbThursdayFinish"
        Me.cmbThursdayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbThursdayFinish.TabIndex = 37
        '
        'cmbFridayFinish
        '
        Me.cmbFridayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFridayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFridayFinish.FormattingEnabled = True
        Me.cmbFridayFinish.Location = New System.Drawing.Point(244, 128)
        Me.cmbFridayFinish.Name = "cmbFridayFinish"
        Me.cmbFridayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbFridayFinish.TabIndex = 39
        '
        'cmbFridayStart
        '
        Me.cmbFridayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFridayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFridayStart.FormattingEnabled = True
        Me.cmbFridayStart.Location = New System.Drawing.Point(244, 89)
        Me.cmbFridayStart.Name = "cmbFridayStart"
        Me.cmbFridayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbFridayStart.TabIndex = 38
        '
        'cmbSaturdayFinish
        '
        Me.cmbSaturdayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSaturdayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSaturdayFinish.FormattingEnabled = True
        Me.cmbSaturdayFinish.Location = New System.Drawing.Point(368, 128)
        Me.cmbSaturdayFinish.Name = "cmbSaturdayFinish"
        Me.cmbSaturdayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbSaturdayFinish.TabIndex = 41
        '
        'cmbSaturdayStart
        '
        Me.cmbSaturdayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSaturdayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSaturdayStart.FormattingEnabled = True
        Me.cmbSaturdayStart.Location = New System.Drawing.Point(368, 89)
        Me.cmbSaturdayStart.Name = "cmbSaturdayStart"
        Me.cmbSaturdayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbSaturdayStart.TabIndex = 40
        '
        'cmbSundayFinish
        '
        Me.cmbSundayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSundayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSundayFinish.FormattingEnabled = True
        Me.cmbSundayFinish.Location = New System.Drawing.Point(492, 128)
        Me.cmbSundayFinish.Name = "cmbSundayFinish"
        Me.cmbSundayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbSundayFinish.TabIndex = 43
        '
        'cmbSundayStart
        '
        Me.cmbSundayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSundayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSundayStart.FormattingEnabled = True
        Me.cmbSundayStart.Location = New System.Drawing.Point(492, 89)
        Me.cmbSundayStart.Name = "cmbSundayStart"
        Me.cmbSundayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbSundayStart.TabIndex = 42
        '
        'cmbMondayFinish
        '
        Me.cmbMondayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMondayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMondayFinish.FormattingEnabled = True
        Me.cmbMondayFinish.Location = New System.Drawing.Point(616, 128)
        Me.cmbMondayFinish.Name = "cmbMondayFinish"
        Me.cmbMondayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbMondayFinish.TabIndex = 45
        '
        'cmbMondayStart
        '
        Me.cmbMondayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMondayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMondayStart.FormattingEnabled = True
        Me.cmbMondayStart.Location = New System.Drawing.Point(616, 89)
        Me.cmbMondayStart.Name = "cmbMondayStart"
        Me.cmbMondayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbMondayStart.TabIndex = 44
        '
        'cmbTuesdayFinish
        '
        Me.cmbTuesdayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTuesdayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTuesdayFinish.FormattingEnabled = True
        Me.cmbTuesdayFinish.Location = New System.Drawing.Point(740, 128)
        Me.cmbTuesdayFinish.Name = "cmbTuesdayFinish"
        Me.cmbTuesdayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbTuesdayFinish.TabIndex = 47
        '
        'cmbTuesdayStart
        '
        Me.cmbTuesdayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTuesdayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTuesdayStart.FormattingEnabled = True
        Me.cmbTuesdayStart.Location = New System.Drawing.Point(740, 89)
        Me.cmbTuesdayStart.Name = "cmbTuesdayStart"
        Me.cmbTuesdayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbTuesdayStart.TabIndex = 46
        '
        'cmbWednesdayFinish
        '
        Me.cmbWednesdayFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWednesdayFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWednesdayFinish.FormattingEnabled = True
        Me.cmbWednesdayFinish.Location = New System.Drawing.Point(864, 128)
        Me.cmbWednesdayFinish.Name = "cmbWednesdayFinish"
        Me.cmbWednesdayFinish.Size = New System.Drawing.Size(118, 33)
        Me.cmbWednesdayFinish.TabIndex = 49
        '
        'cmbWednesdayStart
        '
        Me.cmbWednesdayStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWednesdayStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWednesdayStart.FormattingEnabled = True
        Me.cmbWednesdayStart.Location = New System.Drawing.Point(864, 89)
        Me.cmbWednesdayStart.Name = "cmbWednesdayStart"
        Me.cmbWednesdayStart.Size = New System.Drawing.Size(118, 33)
        Me.cmbWednesdayStart.TabIndex = 48
        '
        'frmAvailability
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 225)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbWednesdayFinish)
        Me.Controls.Add(Me.cmbWednesdayStart)
        Me.Controls.Add(Me.cmbTuesdayFinish)
        Me.Controls.Add(Me.cmbTuesdayStart)
        Me.Controls.Add(Me.cmbMondayFinish)
        Me.Controls.Add(Me.cmbMondayStart)
        Me.Controls.Add(Me.cmbSundayFinish)
        Me.Controls.Add(Me.cmbSundayStart)
        Me.Controls.Add(Me.cmbSaturdayFinish)
        Me.Controls.Add(Me.cmbSaturdayStart)
        Me.Controls.Add(Me.cmbFridayFinish)
        Me.Controls.Add(Me.cmbFridayStart)
        Me.Controls.Add(Me.cmbThursdayFinish)
        Me.Controls.Add(Me.cmbThursdayStart)
        Me.Controls.Add(Me.lblEndTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.btnCancelAvailability)
        Me.Controls.Add(Me.btnOkAvailability)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitleAvailability)
        Me.Controls.Add(Me.lblThursday)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAvailability"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Modify Employee Availability"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblThursday As Label
    Friend WithEvents lblTitleAvailability As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnOkAvailability As Button
    Friend WithEvents btnCancelAvailability As Button
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblEndTime As Label
    Friend WithEvents cmbThursdayStart As ComboBox
    Friend WithEvents cmbThursdayFinish As ComboBox
    Friend WithEvents cmbFridayFinish As ComboBox
    Friend WithEvents cmbFridayStart As ComboBox
    Friend WithEvents cmbSaturdayFinish As ComboBox
    Friend WithEvents cmbSaturdayStart As ComboBox
    Friend WithEvents cmbSundayFinish As ComboBox
    Friend WithEvents cmbSundayStart As ComboBox
    Friend WithEvents cmbMondayFinish As ComboBox
    Friend WithEvents cmbMondayStart As ComboBox
    Friend WithEvents cmbTuesdayFinish As ComboBox
    Friend WithEvents cmbTuesdayStart As ComboBox
    Friend WithEvents cmbWednesdayFinish As ComboBox
    Friend WithEvents cmbWednesdayStart As ComboBox
End Class
