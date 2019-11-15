' Name:             Data Entry
' Purpose:          Add/edit/remove employee data from the data store.
' Author:           Jules Carboni
' Date Created:     14 May 2019
' Date Modified:    17 July 2019

Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel 'Import Excel functionality

Public Class frmData

    'Declare variables for use in this form and availability form
    Dim employeeDataBackup As New List(Of employeeDataStructure)

    Public employeeSelected As String
    Public employeeSelectedIndex As Integer

    Sub populateLists()
        'Populate list boxes

        'Clear list boxes
        lstNameFull.Items.Clear()
        lstPhoneNumber.Items.Clear()
        lstEmailAddress.Items.Clear()
        lstCanClose.Items.Clear()
        lstAvailabilityStored.Items.Clear()
        lstColourCode.Items.Clear()

        'Add each employee's data
        Dim index As Integer
        For index = 0 To employeeCount - 1

            lstNameFull.Items.Add(employeeData(index).nameFull)
            lstPhoneNumber.Items.Add(employeeData(index).phoneNumber)
            lstEmailAddress.Items.Add(employeeData(index).emailAddress)
            lstCanClose.Items.Add(employeeData(index).canClose)
            lstAvailabilityStored.Items.Add(employeeData(index).availabilityStored)
            lstColourCode.Items.Add(employeeData(index).colourCode)

        Next

    End Sub

    Private Sub frmData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Backup employee data records (for restoring if user presses cancel)
        employeeDataBackup = employeeData

        'Populate list boxes
        populateLists()

    End Sub

    Private Sub btnAddData_Click(sender As Object, e As EventArgs) Handles btnAddData.Click
        'Get all data points from user and store that in the record structure (and update list box)

        ''Dim regular expressions
        Dim dlgColour As New ColorDialog

        'Variables for new record
        Dim nameFirst As String
        Dim nameLast As String
        Dim nameFull As String
        Dim phoneNumber As String
        Dim emailAddress As String
        Dim canClose As Boolean
        Dim colourCode As Color

        Try

            'Get input from user and add it to the new shift

            nameFirst = InputBox("Enter the employee's first name." & vbNewLine & "No special characters. Example: John", "New Employee First Name")
            If nameFirst = "" Then
                Throw New Exception("First name empty.")
            ElseIf Not regexName.IsMatch(nameFirst) Then
                Throw New Exception("First name not letters only.")
            End If

            nameLast = InputBox("Enter the employee's last name." & vbNewLine & "No special characters. Example: Smith", "New Employee Last Name")
            If nameLast = "" Then
                Throw New Exception("Last name empty.")
            ElseIf Not regexName.IsMatch(nameLast) Then
                Throw New Exception("Last name not letters only.")
            End If

            nameFull = nameFirst & " " & nameLast

            phoneNumber = InputBox("Enter the employee's phone number." & vbNewLine & "Numbers only. Example: 0400123456", "New Employee Phone Number")
            If phoneNumber = "" Then
                Throw New Exception("Phone number empty.")
                'Too many different formats of phone number to validate via regex.
            End If

            emailAddress = InputBox("Enter the employee's email address." & vbNewLine & "Full address required. Example: recipient@mailprovider.com", "New Employee Email Address")
            If emailAddress = "" Then
                Throw New Exception("Email address empty.")
            ElseIf Not regexEmail.IsMatch(emailAddress) Then
                Throw New Exception("Email address not valid.")
            End If

            'Get ability for employee to close shop
            If MessageBox.Show("Is the employee allowed to close up the shop?", "New Employee Can Close?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                canClose = True
            Else
                canClose = False
            End If

            'Get colour code
            'Source: https://stackoverflow.com/questions/33886090/convert-string-to-color-vb-net
            If dlgColour.ShowDialog = Windows.Forms.DialogResult.OK Then
                colourCode = dlgColour.Color
            Else 'If selection invalid, throw error
                Throw New Exception("Colour selection not valid.")
            End If
            dlgColour.Dispose() 'Remove dialog completely


            'Store in records
            employeeData.Add(New employeeDataStructure With {
                .nameFirst = nameFirst,
                .nameLast = nameLast,
                .nameFull = nameFull,
                .phoneNumber = phoneNumber,
                .emailAddress = emailAddress,
                .canClose = canClose,
                .availabilityStored = False,
                .colourCode = colourCode
                             })

            'Update variables
            employeeCount = employeeData.Count
            'Resize availability array
            Dim day As Integer
            For day = 1 To 7
                'Add each datum
                employeeAvailability.Add(New availabilityStructure With {
                                 .timeStart = Nothing,
                                 .timeFinish = Nothing
                                 })
            Next


            'Notify user that no availability is stored
            MsgBox("No availability stored for employee " & nameFull & "." & vbNewLine & "Add availability by clicking 'Edit Availability'.", MsgBoxStyle.Information, "No Availability Stored")

            populateLists() 'Repopulate entire listbox to ensure data parity

        Catch ex As Exception

            'If invalid data given, stop process of adding shift
            MsgBox(ex.Message & vbNewLine & "No employee data was added.", MsgBoxStyle.Exclamation, "Invalid Entry")

        End Try

        'Update buttons
        btnEditData.Enabled = False
        btnEditAvailbility.Enabled = False
        btnRemoveData.Enabled = False

    End Sub

    Private Sub btnEditData_Click(sender As Object, e As EventArgs) Handles btnEditData.Click
        'Get all data points from user and store that in the record structure (and update list box)

        ''Dim regular expressions
        Dim dlgColour As New ColorDialog

        'Variables for new record
        Dim employeeDataCurrent As employeeDataStructure = employeeData(employeeSelectedIndex)

        Dim phoneNumber As String = employeeDataCurrent.phoneNumber
        Dim emailAddress As String = employeeDataCurrent.emailAddress
        Dim canClose As Boolean = employeeDataCurrent.canClose
        Dim colourCode As Color = employeeDataCurrent.colourCode

        Try

            'Get input from user and add it to the new shift

            phoneNumber = InputBox("Enter the employee's phone number." & vbNewLine & "Numbers only. Example: 0400123456" & vbNewLine & vbNewLine & "Current value: " & employeeDataCurrent.phoneNumber & vbNewLine & "Leave field blank to keep current value.", "Change Employee Phone Number")
            If phoneNumber = "" Then
                phoneNumber = employeeDataCurrent.phoneNumber
                'Too many different formats of phone number to validate via regex.
            End If

            emailAddress = InputBox("Enter the employee's email address." & vbNewLine & "Full address required. Example: recipient@mailprovider.com" & vbNewLine & vbNewLine & "Current value: " & employeeDataCurrent.emailAddress & vbNewLine & "Leave field blank to keep current value.", "Change Employee Email Address")
            If emailAddress = "" Then
                emailAddress = employeeDataCurrent.emailAddress
            ElseIf Not regexEmail.IsMatch(emailAddress) Then
                Throw New Exception("Email address not valid.")
            End If

            'Get ability for employee to close shop
            If MessageBox.Show("Is the employee allowed to close up the shop?" & vbNewLine & "Current value: " & CStr(employeeDataCurrent.canClose), "Change Employee Can Close?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                canClose = True
            Else
                canClose = False
            End If

            'Get colour code
            'Source: https://stackoverflow.com/questions/33886090/convert-string-to-color-vb-net
            If dlgColour.ShowDialog = Windows.Forms.DialogResult.OK Then
                colourCode = dlgColour.Color
            Else 'If selection invalid, do not change
                MsgBox("Colour selected was invalid." & vbNewLine & "Employee colour code not changed.", MsgBoxStyle.Exclamation, "Invalid Colour")
            End If
            dlgColour.Dispose() 'Remove dialog completely


            'Store in records
            employeeDataCurrent.phoneNumber = phoneNumber
            employeeDataCurrent.emailAddress = emailAddress
            employeeDataCurrent.canClose = canClose
            employeeDataCurrent.colourCode = colourCode

            employeeData(employeeSelectedIndex) = employeeDataCurrent

            populateLists() 'Repopulate entire listbox to ensure data parity

        Catch ex As Exception

            'If invalid data given, stop process of adding shift
            MsgBox(ex.Message & vbNewLine & "No employee data was changed.", MsgBoxStyle.Exclamation, "Invalid Entry")

        End Try

        'Update buttons
        btnEditData.Enabled = False
        btnEditAvailbility.Enabled = False
        btnRemoveData.Enabled = False

    End Sub

    Private Sub btnRemoveData_Click(sender As Object, e As EventArgs) Handles btnRemoveData.Click
        'Remove selected data

        'Double-check with the user that they want to remove this entry
        If MessageBox.Show("Are you sure you want to remove the data record for " & employeeSelected & "?" & vbNewLine & "This action cannot be undone.", "Confirm Removal of Record", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim index As Integer = employeeSelectedIndex

            'Remove from records and update vars
            employeeData.RemoveAt(index)
            employeeCount = employeeData.Count
            'Resize availability array
            Dim day As Integer
            For day = 1 To 7
                employeeAvailability.RemoveAt(7 * index + (day - 1))
            Next

            'Repopulate entire listbox to ensure data parity
            populateLists()

            'Update buttons
            btnEditData.Enabled = False
            btnEditAvailbility.Enabled = False
            btnRemoveData.Enabled = False

        End If

    End Sub

    Private Sub btnEditAvailbility_Click(sender As Object, e As EventArgs) Handles btnEditAvailbility.Click
        frmAvailability.Show() 'show child form

        'Update buttons
        btnEditData.Enabled = False
        btnEditAvailbility.Enabled = False
        btnRemoveData.Enabled = False
    End Sub

    Private Sub btnOkData_Click(sender As Object, e As EventArgs) Handles btnOkData.Click
        'Save new data to the Excel spreadsheet (and convert colourCode to its RGB components for storage).

        'Display progress bar to let user know the program is responsive and processing
        frmProgress.Text = "Saving Employee Data"
        frmProgress.barProgress.Value = 0
        frmProgress.barProgress.Maximum = employeeCount + (7 * employeeCount) + 14
        frmProgress.Show()
        frmProgress.lblJob.Text = "Setting up:"
        frmProgress.lblTask.Text = "Opening Excel application"


        'Check file exists

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        'Open Excel application
        xlApp = New Excel.Application

        Try

            If Not File.Exists(EMPLOYEEFILE) Then
                'Create file if it doesnt exist

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new employee data workbook"

                'Add now workbook
                xlWorkbook = xlApp.Workbooks.Add()

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new employee data worksheet"

                'Add sheet to file
                xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
                xlWorksheet.Name = "Main"
                xlWorkbook.SaveAs(EMPLOYEEFILE, Password:=MASTERPASS)

            Else
                'Add sheet existing file

                frmProgress.barProgress.Increment(2)
                frmProgress.lblTask.Text = "Creating new employee data worksheet"

                'Open and unprotect workbook
                xlWorkbook = xlApp.Workbooks.Open(EMPLOYEEFILE, Password:=MASTERPASS)

                xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)

            End If


            xlWorksheet.Cells.NumberFormat = "@" 'Format all cells as text


            'Write employee data to the spreadsheet

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Writing data:"

            Dim employeeNumber As Integer
            For employeeNumber = 0 To employeeCount - 1

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Writing employee data to file (N:" & employeeNumber & ")"

                'Write the data
                xlWorksheet.Cells(1, employeeNumber + 1) = employeeData(employeeNumber).nameFirst
                xlWorksheet.Cells(2, employeeNumber + 1) = employeeData(employeeNumber).nameLast
                xlWorksheet.Cells(3, employeeNumber + 1) = employeeData(employeeNumber).nameFull
                xlWorksheet.Cells(4, employeeNumber + 1) = employeeData(employeeNumber).phoneNumber
                xlWorksheet.Cells(5, employeeNumber + 1) = employeeData(employeeNumber).emailAddress
                xlWorksheet.Cells(6, employeeNumber + 1) = employeeData(employeeNumber).canClose
                xlWorksheet.Cells(7, employeeNumber + 1) = employeeData(employeeNumber).availabilityStored
                'Split colour into red green and blue components
                Dim colour As Color = employeeData(employeeNumber).colourCode
                xlWorksheet.Cells(8, employeeNumber + 1) = colour.R.ToString
                xlWorksheet.Cells(9, employeeNumber + 1) = colour.G.ToString
                xlWorksheet.Cells(10, employeeNumber + 1) = colour.B.ToString

            Next


            'Save changes to file

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Saving data:"
            frmProgress.lblTask.Text = "Saving changes to employee data workbook"

            xlWorkbook.Save()


            'Protect and close archive

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Closing employee data workbook"

            xlWorkbook.Close(True)


        Catch ex As Exception
            'Show error message
            frmProgress.Close()

            MsgBox("Could not access existing or create new employee data file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & EMPLOYEEFILE, MsgBoxStyle.Critical, "Error Saving Employee Data")

        End Try


        'Save availability data to file

        frmProgress.barProgress.PerformStep()
        frmProgress.Text = "Saving Availability Data"
        frmProgress.lblJob.Text = "Setting up:"
        frmProgress.lblTask.Text = "Opening Excel application"


        'Check file exists

        'Open Excel application
        xlApp = New Excel.Application

        'Try

        If Not File.Exists(AVAILABILITYFILE) Then
            'Create file if it doesnt exist

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Creating new availability data workbook"

            xlWorkbook = xlApp.Workbooks.Add()

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Creating new availability data worksheet"

            'Add sheet to file
            xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
            ''xlWorksheet.Name = "Main"
            xlWorkbook.SaveAs(AVAILABILITYFILE, Password:=MASTERPASS)

        Else
            'Delete and recreate file if it does exist

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Recreating availability data workbook"

            File.Delete(AVAILABILITYFILE)
            xlWorkbook = xlApp.Workbooks.Add()

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Creating new availability data worksheet"

            'Add sheet to file
            xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
            ''xlWorksheet.Name = "Main"
            xlWorkbook.SaveAs(AVAILABILITYFILE, Password:=MASTERPASS)

        End If

        'Add the neccesary amount of worksheets to the file
        Try
            xlWorksheet = CType(xlWorkbook.Worksheets.Add(Count:=employeeCount - 1), Excel.Worksheet)
        Catch
            Exit Try 'If not adding eny sheets, skip
        End Try

        'Write availability data to the spreadsheet

        frmProgress.barProgress.PerformStep()
        frmProgress.lblJob.Text = "Writing data:"

        Dim employeeIndex As Integer
        For employeeIndex = 0 To employeeCount - 1 'Get each amployee's availability

            xlWorksheet = CType(xlWorkbook.Worksheets(employeeIndex + 1), Excel.Worksheet)
            xlWorksheet.Name = employeeData(employeeIndex).nameFull

            Dim dayNumber As Integer
            For dayNumber = 1 To 7 'Get for each day of the week

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Writing availability data to file (N:" & employeeIndex & " D:" & dayNumber & ")"

                'Write the data
                xlWorksheet.Cells(1, dayNumber) = employeeAvailability(7 * employeeIndex + (dayNumber - 1)).timeStart
                xlWorksheet.Cells(2, dayNumber) = employeeAvailability(7 * employeeIndex + (dayNumber - 1)).timeFinish

            Next

        Next


        'Save changes to file

        frmProgress.barProgress.PerformStep()
        frmProgress.lblJob.Text = "Saving data:"
        frmProgress.lblTask.Text = "Saving changes to availability data workbook"

        xlWorkbook.Save()


        'Protect and close file

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Closing availability data workbook"

        xlWorkbook.Close(True)


        'Close progress bar

        frmProgress.barProgress.PerformStep()
        frmProgress.Close()


        'Catch ex As Exception
        '    'Show error message
        '    frmProgress.Close()

        '    MsgBox("Could not access existing or create new availability data file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & AVAILABILITYFILE, MsgBoxStyle.Critical, "Error Saving Availability Data")

        'End Try


        'Refresh shift data displayed in main form, then close this form

        mainReload()
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close without saving changes

        'Restore employee data records
        employeeData = employeeDataBackup

        'Refresh shift data displayed in main form, then close this form
        mainReload()
        Me.Close()

    End Sub

    Private Sub lstNameFull_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstNameFull.SelectedIndexChanged
        'When the user selects an existing employee, allow them to edit or remove it.
        employeeSelected = CStr(lstNameFull.SelectedItem)
        employeeSelectedIndex = CInt(lstNameFull.SelectedIndex)

        If employeeSelected IsNot Nothing Then
            btnEditData.Enabled = True
            btnEditAvailbility.Enabled = True
            btnRemoveData.Enabled = True
        Else
            btnEditData.Enabled = False
            btnEditAvailbility.Enabled = False
            btnRemoveData.Enabled = False
        End If
    End Sub

End Class