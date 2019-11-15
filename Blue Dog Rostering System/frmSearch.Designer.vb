<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.lblShiftsWorked = New System.Windows.Forms.Label()
        Me.lstShiftsWorked = New System.Windows.Forms.ListBox()
        Me.lblTitleSearch = New System.Windows.Forms.Label()
        Me.lblTotalShifts = New System.Windows.Forms.Label()
        Me.txtTotalShifts = New System.Windows.Forms.TextBox()
        Me.lblTotalHours = New System.Windows.Forms.Label()
        Me.txtTotalHours = New System.Windows.Forms.TextBox()
        Me.lblEmployeeSearch = New System.Windows.Forms.Label()
        Me.cmbEmployeeSearch = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblEarliestTime = New System.Windows.Forms.Label()
        Me.txtEarliestTime = New System.Windows.Forms.TextBox()
        Me.lblLatestTime = New System.Windows.Forms.Label()
        Me.txtLatestTime = New System.Windows.Forms.TextBox()
        Me.btnSortResults = New System.Windows.Forms.Button()
        Me.lblStatistics = New System.Windows.Forms.Label()
        Me.btnOkSearch = New System.Windows.Forms.Button()
        Me.btnSaveResults = New System.Windows.Forms.Button()
        Me.lblNameFirst = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.dlgSaveResults = New System.Windows.Forms.SaveFileDialog()
        Me.lstDatesWorked = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lblShiftsWorked
        '
        Me.lblShiftsWorked.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftsWorked.Location = New System.Drawing.Point(12, 62)
        Me.lblShiftsWorked.Name = "lblShiftsWorked"
        Me.lblShiftsWorked.Size = New System.Drawing.Size(363, 25)
        Me.lblShiftsWorked.TabIndex = 11
        Me.lblShiftsWorked.Text = "Search Results (Shifts Worked):"
        Me.lblShiftsWorked.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstShiftsWorked
        '
        Me.lstShiftsWorked.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShiftsWorked.FormattingEnabled = True
        Me.lstShiftsWorked.ItemHeight = 25
        Me.lstShiftsWorked.Location = New System.Drawing.Point(12, 95)
        Me.lstShiftsWorked.Name = "lstShiftsWorked"
        Me.lstShiftsWorked.Size = New System.Drawing.Size(184, 654)
        Me.lstShiftsWorked.TabIndex = 5
        '
        'lblTitleSearch
        '
        Me.lblTitleSearch.Font = New System.Drawing.Font("Geometos", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleSearch.Location = New System.Drawing.Point(12, 19)
        Me.lblTitleSearch.Name = "lblTitleSearch"
        Me.lblTitleSearch.Size = New System.Drawing.Size(645, 25)
        Me.lblTitleSearch.TabIndex = 14
        Me.lblTitleSearch.Text = "Search Archive / Shift History" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTitleSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalShifts
        '
        Me.lblTotalShifts.AutoSize = True
        Me.lblTotalShifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalShifts.Location = New System.Drawing.Point(381, 336)
        Me.lblTotalShifts.Name = "lblTotalShifts"
        Me.lblTotalShifts.Size = New System.Drawing.Size(112, 25)
        Me.lblTotalShifts.TabIndex = 16
        Me.lblTotalShifts.Text = "Total shifts:"
        Me.lblTotalShifts.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalShifts
        '
        Me.txtTotalShifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalShifts.Location = New System.Drawing.Point(513, 333)
        Me.txtTotalShifts.Name = "txtTotalShifts"
        Me.txtTotalShifts.ReadOnly = True
        Me.txtTotalShifts.Size = New System.Drawing.Size(139, 30)
        Me.txtTotalShifts.TabIndex = 7
        '
        'lblTotalHours
        '
        Me.lblTotalHours.AutoSize = True
        Me.lblTotalHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHours.Location = New System.Drawing.Point(381, 372)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(116, 25)
        Me.lblTotalHours.TabIndex = 18
        Me.lblTotalHours.Text = "Total hours:"
        Me.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalHours
        '
        Me.txtTotalHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHours.Location = New System.Drawing.Point(513, 369)
        Me.txtTotalHours.Name = "txtTotalHours"
        Me.txtTotalHours.ReadOnly = True
        Me.txtTotalHours.Size = New System.Drawing.Size(139, 30)
        Me.txtTotalHours.TabIndex = 8
        '
        'lblEmployeeSearch
        '
        Me.lblEmployeeSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeSearch.Location = New System.Drawing.Point(386, 62)
        Me.lblEmployeeSearch.Name = "lblEmployeeSearch"
        Me.lblEmployeeSearch.Size = New System.Drawing.Size(271, 25)
        Me.lblEmployeeSearch.TabIndex = 19
        Me.lblEmployeeSearch.Text = "Employee to Search:"
        Me.lblEmployeeSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbEmployeeSearch
        '
        Me.cmbEmployeeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmployeeSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeSearch.FormattingEnabled = True
        Me.cmbEmployeeSearch.Location = New System.Drawing.Point(386, 95)
        Me.cmbEmployeeSearch.Name = "cmbEmployeeSearch"
        Me.cmbEmployeeSearch.Size = New System.Drawing.Size(271, 33)
        Me.cmbEmployeeSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(386, 134)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(271, 37)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search Archive"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblEarliestTime
        '
        Me.lblEarliestTime.AutoSize = True
        Me.lblEarliestTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEarliestTime.Location = New System.Drawing.Point(381, 408)
        Me.lblEarliestTime.Name = "lblEarliestTime"
        Me.lblEarliestTime.Size = New System.Drawing.Size(123, 25)
        Me.lblEarliestTime.TabIndex = 23
        Me.lblEarliestTime.Text = "Earliest time:"
        Me.lblEarliestTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtEarliestTime
        '
        Me.txtEarliestTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEarliestTime.Location = New System.Drawing.Point(513, 405)
        Me.txtEarliestTime.Name = "txtEarliestTime"
        Me.txtEarliestTime.ReadOnly = True
        Me.txtEarliestTime.Size = New System.Drawing.Size(139, 30)
        Me.txtEarliestTime.TabIndex = 9
        '
        'lblLatestTime
        '
        Me.lblLatestTime.AutoSize = True
        Me.lblLatestTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLatestTime.Location = New System.Drawing.Point(381, 444)
        Me.lblLatestTime.Name = "lblLatestTime"
        Me.lblLatestTime.Size = New System.Drawing.Size(112, 25)
        Me.lblLatestTime.TabIndex = 25
        Me.lblLatestTime.Text = "Latest time:"
        Me.lblLatestTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtLatestTime
        '
        Me.txtLatestTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLatestTime.Location = New System.Drawing.Point(513, 441)
        Me.txtLatestTime.Name = "txtLatestTime"
        Me.txtLatestTime.ReadOnly = True
        Me.txtLatestTime.Size = New System.Drawing.Size(139, 30)
        Me.txtLatestTime.TabIndex = 10
        '
        'btnSortResults
        '
        Me.btnSortResults.Enabled = False
        Me.btnSortResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSortResults.Location = New System.Drawing.Point(386, 177)
        Me.btnSortResults.Name = "btnSortResults"
        Me.btnSortResults.Size = New System.Drawing.Size(271, 37)
        Me.btnSortResults.TabIndex = 2
        Me.btnSortResults.Text = "Sort Results"
        Me.btnSortResults.UseVisualStyleBackColor = True
        '
        'lblStatistics
        '
        Me.lblStatistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatistics.Location = New System.Drawing.Point(381, 262)
        Me.lblStatistics.Name = "lblStatistics"
        Me.lblStatistics.Size = New System.Drawing.Size(271, 25)
        Me.lblStatistics.TabIndex = 27
        Me.lblStatistics.Text = "Employee Result Stats:"
        Me.lblStatistics.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOkSearch
        '
        Me.btnOkSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkSearch.Location = New System.Drawing.Point(386, 712)
        Me.btnOkSearch.Name = "btnOkSearch"
        Me.btnOkSearch.Size = New System.Drawing.Size(271, 37)
        Me.btnOkSearch.TabIndex = 4
        Me.btnOkSearch.Text = "Close Search"
        Me.btnOkSearch.UseVisualStyleBackColor = True
        '
        'btnSaveResults
        '
        Me.btnSaveResults.Enabled = False
        Me.btnSaveResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveResults.Location = New System.Drawing.Point(386, 669)
        Me.btnSaveResults.Name = "btnSaveResults"
        Me.btnSaveResults.Size = New System.Drawing.Size(271, 37)
        Me.btnSaveResults.TabIndex = 3
        Me.btnSaveResults.Text = "Save Results to File"
        Me.btnSaveResults.UseVisualStyleBackColor = True
        '
        'lblNameFirst
        '
        Me.lblNameFirst.AutoSize = True
        Me.lblNameFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameFirst.Location = New System.Drawing.Point(381, 300)
        Me.lblNameFirst.Name = "lblNameFirst"
        Me.lblNameFirst.Size = New System.Drawing.Size(70, 25)
        Me.lblNameFirst.TabIndex = 33
        Me.lblNameFirst.Text = "Name:"
        Me.lblNameFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(513, 297)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(139, 30)
        Me.txtName.TabIndex = 6
        '
        'dlgSaveResults
        '
        Me.dlgSaveResults.DefaultExt = "txt"
        Me.dlgSaveResults.FileName = "Search_Results"
        Me.dlgSaveResults.Filter = "Text files|*.txt|All files|*.*"
        Me.dlgSaveResults.InitialDirectory = "%USERPROFILE%\Documents"
        Me.dlgSaveResults.RestoreDirectory = True
        Me.dlgSaveResults.Title = "Save Search Results"
        '
        'lstDatesWorked
        '
        Me.lstDatesWorked.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDatesWorked.FormattingEnabled = True
        Me.lstDatesWorked.ItemHeight = 25
        Me.lstDatesWorked.Location = New System.Drawing.Point(195, 95)
        Me.lstDatesWorked.Name = "lstDatesWorked"
        Me.lstDatesWorked.Size = New System.Drawing.Size(185, 654)
        Me.lstDatesWorked.TabIndex = 34
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 762)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstDatesWorked)
        Me.Controls.Add(Me.lblNameFirst)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnOkSearch)
        Me.Controls.Add(Me.btnSaveResults)
        Me.Controls.Add(Me.lblStatistics)
        Me.Controls.Add(Me.btnSortResults)
        Me.Controls.Add(Me.lblLatestTime)
        Me.Controls.Add(Me.txtLatestTime)
        Me.Controls.Add(Me.lblEarliestTime)
        Me.Controls.Add(Me.txtEarliestTime)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbEmployeeSearch)
        Me.Controls.Add(Me.lblEmployeeSearch)
        Me.Controls.Add(Me.lblTotalHours)
        Me.Controls.Add(Me.txtTotalHours)
        Me.Controls.Add(Me.lblTotalShifts)
        Me.Controls.Add(Me.txtTotalShifts)
        Me.Controls.Add(Me.lblTitleSearch)
        Me.Controls.Add(Me.lblShiftsWorked)
        Me.Controls.Add(Me.lstShiftsWorked)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Search Archived Rosters"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblShiftsWorked As Label
    Friend WithEvents lstShiftsWorked As ListBox
    Friend WithEvents lblTitleSearch As Label
    Friend WithEvents lblTotalShifts As Label
    Friend WithEvents txtTotalShifts As TextBox
    Friend WithEvents lblTotalHours As Label
    Friend WithEvents txtTotalHours As TextBox
    Friend WithEvents lblEmployeeSearch As Label
    Friend WithEvents cmbEmployeeSearch As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblEarliestTime As Label
    Friend WithEvents txtEarliestTime As TextBox
    Friend WithEvents lblLatestTime As Label
    Friend WithEvents txtLatestTime As TextBox
    Friend WithEvents btnSortResults As Button
    Friend WithEvents lblStatistics As Label
    Friend WithEvents btnOkSearch As Button
    Friend WithEvents btnSaveResults As Button
    Friend WithEvents lblNameFirst As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents dlgSaveResults As SaveFileDialog
    Friend WithEvents lstDatesWorked As ListBox
End Class
