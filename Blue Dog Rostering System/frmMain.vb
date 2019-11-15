' Name:             Main Roster Generation
' Purpose:          Creates and sends rosters. Provides buttons for accessing other forms (is root from).
' Author:           Jules Carboni
' Date Created:     14 May 2019
' Date Modified:    23 July 2019

Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports Excel = Microsoft.Office.Interop.Excel 'Import Excel functionality

Public Class frmMain

    Dim sideEffect As Boolean = False 'Used to prevent certain subroutines from executing if they are induced as a side effect of another operation.

    Private Sub getShifts(ByVal dayNumber As Integer, ByVal staffNumber As Integer, ByVal employeeName As String)
        'Populate combination boxes with compatible shifts for selected employee
        'dayNumber in range 1 to 7, and staffNumber in range 1 to 6.

        'Do not attempt to do procced if this function has been induced as a side effect of programatically changing a combination box's text
        If sideEffect = False Then

            'Find combination box to be modified
            'Source: https://www.daniweb.com/programming/software-development/threads/421591/want-to-find-all-textboxes-on-a-form
            'See globalVars.vb for panelList definition.

            Dim comboList() As ComboBox = panelList(dayNumber - 1).Controls.OfType(Of ComboBox)().OrderBy(Function(o) o.Name).ToArray() 'List of every combobox in that day's panel
            Dim comboBox As ComboBox = comboList(staffNumber - 1)

            comboBox.Items.Clear() 'Clear all items

            If employeeName = "" Then

                comboBox.Enabled = False 'Disable ability to use

            Else

                'Find employee's information in the record structure

                Dim employeeNames(employeeData.Count) As String
                Dim person As Integer
                For person = 0 To employeeData.Count - 1
                    'Create a list of all employee names
                    employeeNames(person) = employeeData(person).nameFull
                Next

                'Source: https://stackoverflow.com/questions/28998204/find-item-in-array-of-structure
                Dim employeeIndex As Integer = Array.IndexOf(employeeNames, employeeName)
                Dim employeeAvailabilityTemp As availabilityStructure = EmployeeAvailability(7 * employeeIndex + (dayNumber - 1))

                'Populate with all valid shifts
                Dim index As Integer
                For index = 0 To shiftCount - 1

                    Dim shiftStartInt As Integer = shiftData(index).timeStart
                    Dim shiftFinishInt As Integer = shiftData(index).timeFinish
                    Dim shiftStart As String = minToTime(shiftStartInt)
                    Dim shiftFinish As String = minToTime(shiftFinishInt)

                    If employeeAvailabilityTemp.timeStart <= shiftStartInt And employeeAvailabilityTemp.timeFinish >= shiftFinishInt Then
                        'If the selected employee can work this shift, add to items.

                        If employeeData(employeeIndex).canClose = True Or shiftFinish <> "Close" Then 'Check if finish time is "closing time"

                            comboBox.Items.Add(shiftStart & " - " & shiftFinish) 'Add to items

                        End If

                    End If

                Next

                'comboList(6 + staffNumber - 1).BackColor = employeeData(employeeIndex).colourCode 'Set colour of staff-member combination box

                comboBox.Enabled = True

            End If

        End If

    End Sub

    Private Sub sendEmail(ByVal recipientEmails() As String)
        'Send email with attachment
        'Source: https://stackoverflow.com/questions/4862649/vb-net-send-email
        'Source: https://stackoverflow.com/questions/9561995/sending-email-to-multiple-recipients-in-vb-net
        'Modifications: Hard-coded specific values

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Creating new message"

        'Create the mail message
        Dim mail As New MailMessage()

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Setting up SMTP server"

        'Setup the SMTP server
        Dim smtp As New SmtpClient()
        'Dim password As String = InputBox("Enter password for email account " & OWNEREMAIL & "." & vbNewLine & "This is required to send the message." & vbNewLine & vbNewLine & "Press cancel or return no string to proceed without sending.", "Enter Email Password") ''Get password for email (temporary, use OWNERPASSWORD in final version)

        smtp.Host = "smtp.gmail.com"
        smtp.Port = 587
        smtp.EnableSsl = True
        smtp.UseDefaultCredentials = False
        smtp.Credentials = New System.Net.NetworkCredential(My.Settings.ownerEmail, My.Settings.ownerPass)

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Addressing message to recipients"

        'Set the email addresses
        mail.From = New MailAddress(My.Settings.ownerEmail)
        Dim email As String
        For Each email In recipientEmails
            mail.To.Add(email)
        Next

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Setting subject and body text"

        'Set the content
        mail.Subject = "Work Roster for " & CStr(WEEKSTART) & " (" & WEEKNUMBER & ")"
        mail.Body = "Blue Dog Roster for week beginning " & CStr(WEEKSTART) & " (Week number " & WEEKNUMBER & ")"

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Sending the message now"

        smtp.Send(mail)


    End Sub

    Private Sub loadRoster(ByVal workbookFile As String, ByVal worksheetName As String)
        'Load the specified roster worksheet's data into the roster-creation-board

        'Declare variables
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        'Open Excel application
        xlApp = New Excel.Application

        If xlApp Is Nothing Then 'Check that the application was opened successfully

            frmProgress.Close()

            MsgBox("Microsoft Excel is damaged or not installed on your system." & vbNewLine & "Please install Excel as it is required for this program to function." & vbNewLine & vbNewLine & "This program will close.", MsgBoxStyle.Critical, "Excel Not Installed")
            Application.Exit()

        Else
            'Load data from files

            If File.Exists(workbookFile) Then


                Try
                    'Open workbook

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblTask.Text = "Opening Excel workbook"

                    xlWorkbook = xlApp.Workbooks.Open(workbookFile)

                    Try
                        'Open worksheet

                        frmProgress.barProgress.PerformStep()
                        frmProgress.lblTask.Text = "Opening Excel worksheet"

                        Try
                            'If name is invalid, use index of 1
                            xlWorksheet = CType(xlWorkbook.Worksheets(worksheetName), Excel.Worksheet)
                        Catch ex As Exception
                            xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
                            xlWorksheet.Name = worksheetName
                        End Try

                        'Warn the user if out-of-date data is being loaded
                        Dim showInvalidItem As Boolean = False
                        Dim messageInvalidItem As String = "Out-of-date data has been loaded into the roster creation board." & vbNewLine & "This includes old employee names, and shifts that no longer exist or match employee availability." & vbNewLine & vbNewLine & "Note: Every instance of invalid data is selected." & vbNewLine & "Stored employee data and availability and stored shifts have not been affected."


                        'Clear values in roster-creation-board

                        frmProgress.barProgress.PerformStep()
                        frmProgress.lblJob.Text = "Clearing roster:"
                        frmProgress.lblTask.Text = "Clearing current values"

                        For Each panel As Panel In panelList

                            Dim dayNumber As Integer = CInt(panel.Name.Substring(panel.Name.Length - 1)) 'Get number of day from name of label (1 to 7)

                            Dim comboList() As ComboBox = panelList(dayNumber - 1).Controls.OfType(Of ComboBox)().OrderBy(Function(f) f.Name).ToArray() 'List of every combobox in that day's panel

                            Dim staffNumber As Integer
                            For staffNumber = 1 To 6

                                Dim comboStaff As ComboBox = comboList(staffNumber - 1 + 6)
                                Dim comboShift As ComboBox = comboList(staffNumber - 1)

                                'Clear all comboboxes
                                comboStaff.Items.Clear()
                                comboShift.Items.Clear()
                                comboStaff.Text = Nothing
                                comboShift.Text = Nothing
                                'Disable shift comboboxes
                                comboShift.Enabled = False

                                frmProgress.barProgress.PerformStep()
                                frmProgress.lblTask.Text = "Clearing current values (D:" & dayNumber & " S:" & staffNumber & ")"

                            Next

                        Next


                        'Read data into roster-creation-board

                        frmProgress.barProgress.PerformStep()
                        frmProgress.lblJob.Text = "Reading roster:"
                        frmProgress.lblTask.Text = "Populating combination boxes"

                        'Repopulate comboboxes with employee name (they were cleared)
                        comboPopulate()

                        frmProgress.barProgress.PerformStep()
                        frmProgress.lblTask.Text = "Reading new values"

                        For Each panel As Panel In panelList

                            Dim dayNumber As Integer = CInt(panel.Name.Substring(panel.Name.Length - 1)) 'Get number of day from name of label (1 to 7)

                            Dim comboList() As ComboBox = panelList(dayNumber - 1).Controls.OfType(Of ComboBox)().OrderBy(Function(f) f.Name).ToArray() 'List of every combobox in that day's panel

                            Dim staffNumber As Integer
                            For staffNumber = 1 To 6

                                Dim staffCell As Integer = 2 * staffNumber + 2

                                'Write each staff member and their shift to the roster
                                Dim staffName As String = CStr(xlWorksheet.Range(getLetter(dayNumber) & staffCell).Text)

                                'If staff cell is not empty
                                If staffName <> "" Then

                                    Try

                                        Dim comboStaff As ComboBox = comboList(staffNumber - 1 + 6)
                                        Dim comboShift As ComboBox = comboList(staffNumber - 1)
                                        Dim shiftData As String = CStr(xlWorksheet.Range(getLetter(dayNumber) & staffCell + 1).Text)
                                        Dim isInvalidItem As Boolean = False 'Is the current item invalid, used in error reporting

                                        'If name or shift is not valid in current session, add it to the combobox and warn the user
                                        If Not comboStaff.Items.Contains(staffName) Then
                                            comboStaff.Items.Add(staffName)
                                            showInvalidItem = True
                                            isInvalidItem = True
                                        Else
                                            'If the name is in the list, get the corresponding shifts
                                            getShifts(dayNumber, staffNumber, staffName)
                                        End If

                                        If Not comboShift.Items.Contains(shiftData) Then
                                            comboShift.Items.Add(shiftData)
                                            showInvalidItem = True
                                            isInvalidItem = True
                                        End If

                                        'Load data
                                        sideEffect = True
                                        comboStaff.Text = staffName
                                        comboShift.Text = shiftData
                                        sideEffect = False

                                        'Enable shift combination box
                                        comboShift.Enabled = True

                                        frmProgress.barProgress.PerformStep()
                                        frmProgress.lblTask.Text = "Reading new values (D:" & dayNumber & " S:" & staffNumber & " I:" & CStr(isInvalidItem).Substring(0, 1) & ")"


                                    Catch ex As Exception

                                        Throw New System.ApplicationException("Internal write error") 'Throw error to be handled by each caller differently

                                    End Try

                                End If

                            Next

                        Next

                        'Show out-of-date data warning if neccessary
                        If showInvalidItem = True Then
                            frmProgress.Hide() 'Hide so user can read messagebox
                            MsgBox(messageInvalidItem, MsgBoxStyle.Information, "Out-of-Date Data Loaded")
                        End If

                    Catch ex As Exception

                        Throw New System.ApplicationException("Worksheet read error") 'Throw error to be handled by each caller differently

                    End Try

                    'Close file
                    xlWorkbook.Close(False)


                Catch ex As Exception

                    Throw New System.ApplicationException("Workbook open error") 'Throw error to be handled by each caller differently

                End Try


            Else

                Throw New System.ApplicationException("File does not exist") 'Throw error to be handled by each caller differently

            End If

        End If

    End Sub

    Private Sub saveRoster(ByVal xlWorkbook As Excel.Workbook, ByVal xlworksheet As Excel.Worksheet)
        'Load the specified roster worksheet's data into the roster-creation-board

        xlworksheet.Cells.NumberFormat = "@" 'Format all cells as text

        For Each panel As Panel In panelList
            'For each day of the week, write each combobox to the output file

            Dim dayNumber As Integer = CInt(panel.Name.Substring(panel.Name.Length - 1)) 'Get number of day from name of label (1 to 7)
            Dim staffNumber As Integer

            Dim comboList() As ComboBox = panelList(dayNumber - 1).Controls.OfType(Of ComboBox)().OrderBy(Function(o) o.Name).ToArray() 'List of every combobox in that day's panel

            For staffNumber = 1 To 6

                'Find employee's information location in the record structure
                'Source: https://stackoverflow.com/questions/28998204/find-item-in-array-of-structure
                Dim employeeName As String = comboList(staffNumber - 1 + 6).Text

                'Do not write if no staff assigned
                If employeeName <> "" Then

                    Dim employeeIndex As Integer = Array.IndexOf(employeeNames, employeeName)

                    Dim staffCell As Integer = 2 * staffNumber + 2 'Offset by 2x+2 for the header cells

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblTask.Text = "Writing roster data (D:" & dayNumber.ToString("D2") & " S:" & staffNumber.ToString("D2") & ")"

                    'Write each staff member and their shift to the roster
                    xlworksheet.Cells(staffCell, dayNumber) = employeeName
                    xlworksheet.Cells(staffCell + 1, dayNumber) = comboList(staffNumber - 1).Text

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblTask.Text = "Setting text colour (D:" & dayNumber.ToString("D2") & " S:" & staffNumber.ToString("D2") & ")"

                    'Format staff member name according to their colour code
                    xlworksheet.Range(getLetter(dayNumber) & CStr(staffCell)).Font.Color = employeeData(employeeIndex).colourCode

                Else

                    frmProgress.barProgress.Increment(2) 'Keep progress bar up to speed

                End If

            Next

        Next


        'Save changes to archive

        frmProgress.barProgress.PerformStep()
        frmProgress.lblJob.Text = "Saving roster:"
        frmProgress.lblTask.Text = "Saving changes to archive workbook"

        xlWorkbook.Save()


    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Check that the root folders exist, if not create it
        'Source: https://stackoverflow.com/questions/85996/how-do-i-create-a-folder-in-vb-if-it-doesnt-exist

        If Not Directory.Exists(FILEPATH) Then
            Directory.CreateDirectory(FILEPATH)
        End If
        If Not Directory.Exists(DATAPATH) Then
            Directory.CreateDirectory(DATAPATH)
        End If


        'Check that all necessary files exist and create them if they dont exist
        'Source: http://vb.net-informations.com/excel-2007/vb.net_excel_2007_create_file.htm

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet

        xlApp = New Excel.Application

        If xlApp Is Nothing Then
            'show error message
            MsgBox("Microsoft Excel is damaged or not installed on your system." & vbNewLine & "Please install Excel as it is required for this program to function." & vbNewLine & vbNewLine & "This program will close.", MsgBoxStyle.Critical, "Excel Not Installed")
            Application.Exit()

        Else

            'Load user data from files

            Try
                'Load Employee Data

                If File.Exists(EMPLOYEEFILE) Then

                    'Open and unprotect
                    xlWorkbook = xlApp.Workbooks.Open(EMPLOYEEFILE, Password:=MASTERPASS)
                    xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)

                    'Get employee data from file (while the data is not empty, i.e. until there is no more data) 
                    While CStr(xlWorksheet.Range(getLetter(employeeCount + 1) & "1").Text) <> ""

                        Dim letter As String = getLetter(employeeCount + 1) 'Convert integer to row of spreadsheet

                        'Get colour codes (assimilate values)
                        'Source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/05ad89db-e076-4253-b5f7-157c9527d22d/colorfromargb-overflow?forum=netfxbcl
                        Dim byteRed As Integer = CInt(xlWorksheet.Range(letter & "8").Text)
                        Dim byteGreen As Integer = CInt(xlWorksheet.Range(letter & "9").Text)
                        Dim byteBlue As Integer = CInt(xlWorksheet.Range(letter & "10").Text)

                        'Store data to records
                        employeeData.Add(New employeeDataStructure With {
                                         .nameFirst = CStr(xlWorksheet.Range(letter & "1").Text),
                                         .nameLast = CStr(xlWorksheet.Range(letter & "2").Text),
                                         .nameFull = CStr(xlWorksheet.Range(letter & "3").Text),
                                         .phoneNumber = CStr(xlWorksheet.Range(letter & "4").Text),
                                         .emailAddress = CStr(xlWorksheet.Range(letter & "5").Text),
                                         .canClose = CBool(xlWorksheet.Range(letter & "6").Text),
                                         .availabilityStored = CBool(xlWorksheet.Range(letter & "7").Text),
                                         .colourCode = Color.FromArgb(byteRed, byteGreen, byteBlue)
                                         })

                        employeeCount += 1 'Get next employee's data

                    End While

                Else

                    'Create new employee data file, save and protect it
                    xlWorkbook = xlApp.Workbooks.Add()
                    xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
                    xlWorksheet.Name = "Main"
                    xlWorkbook.SaveAs(EMPLOYEEFILE, Password:=MASTERPASS)

                End If

                'Protect and close
                xlWorkbook.Close(False)

            Catch ex As Exception
                MsgBox("Could not access existing or create new employee data file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & EMPLOYEEFILE, MsgBoxStyle.Critical, "Error Loading Employee Data")
            End Try


            Try
                'Load Availability Data

                If File.Exists(AVAILABILITYFILE) Then

                    'Open and unprotect
                    xlWorkbook = xlApp.Workbooks.Open(AVAILABILITYFILE, Password:=MASTERPASS)

                    Dim employeeIndex As Integer
                    For employeeIndex = 0 To employeeCount - 1 'Get each amployee's availability

                        If employeeData(employeeIndex).availabilityStored = True Then 'If the current employee has their availability stored.

                            'Open availability worksheet for the current employee
                            xlWorksheet = CType(xlWorkbook.Worksheets(employeeData(employeeIndex).nameFull), Excel.Worksheet)

                            Dim dayNumber As Integer
                            For dayNumber = 1 To 7 'Get for each day of the week

                                'Store data to records
                                Dim startTime As String = CStr(xlWorksheet.Range(getLetter(dayNumber) & "1").Text)
                                Dim finsihTime As String = cstr(xlWorksheet.Range(getLetter(dayNumber) & "2").Text)

                                If startTime = "" Or finsihTime = "" Then
                                    employeeAvailability.Add(New availabilityStructure With {
                                                 .timeStart = 0,
                                                 .timeFinish = 0
                                                 })

                                Else
                                    employeeAvailability.Add(New availabilityStructure With {
                                                 .timeStart = CInt(startTime),
                                                 .timeFinish = CInt(finsihTime)
                                                 })

                                End If
                            Next

                        Else
                            'Add placeholder/empty values

                            Dim dayNumber As Integer
                            For dayNumber = 1 To 7 'Get for each day of the week

                                employeeAvailability.Add(New availabilityStructure With {
                                                 .timeStart = 0,
                                                 .timeFinish = 0
                                                 })

                            Next

                            'Inform user that the employee just loaded has no availability (or invalid avialability) stored on file. It is required that employees have this data added for use in rosters.
                            MsgBox("No availability stored for " & employeeData(employeeIndex).nameFull & "." & vbNewLine & "Please enter employees' availability into the system via 'Modify Employee Data'.", MsgBoxStyle.Exclamation, "No Availability Stored")

                        End If

                    Next

                    'Close and protect
                    xlWorkbook.Close(False)

                Else

                    'Inform the user that users do not have their availabilities stored. It is required that employees have this data added for use in rosters.
                    MsgBox("No availability stored for any employee." & vbNewLine & "Please enter employees' availability into the system via 'Modify Employee Data'.", MsgBoxStyle.Exclamation, "No Availability On File")

                End If

            Catch ex As Exception
                'Show erroe message
                MsgBox("Could not access existing or create new availability data file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & AVAILABILITYFILE, MsgBoxStyle.Critical, "Error Loading Availability Data")
            End Try


            Try
                'Load Shift Data

                If File.Exists(SHIFTFILE) Then

                    'Open shift workbook
                    xlWorkbook = xlApp.Workbooks.Open(SHIFTFILE)
                    xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)

                    'Get shifts from file (while the shifts are not empty, i.e. until there are no more shifts) 
                    While CStr(xlWorksheet.Range(getLetter(shiftCount + 1) & "1").Text) <> ""

                        'Store shift in record structure
                        shiftData.Add(New shiftDataStrcuture With {
                                      .timeStart = CInt(xlWorksheet.Range(getLetter(shiftCount + 1) & "1").Text),
                                      .timeFinish = CInt(xlWorksheet.Range(getLetter(shiftCount + 1) & "2").Text)
                                      })

                        shiftCount += 1 'Get next shift

                    End While

                Else
                    'If no shift data file exists, create one.

                    xlWorkbook = xlApp.Workbooks.Add()
                    xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
                    xlWorksheet.Name = "Main"
                    xlWorkbook.SaveAs(SHIFTFILE)

                End If

                xlWorkbook.Close(False) 'Close shift file for data integrity

            Catch ex As Exception
                'Show error message
                MsgBox("Could not access existing or create new shift data file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & SHIFTFILE, MsgBoxStyle.Critical, "Error Loading Shift Data")
            End Try

        End If

        'Close and release all objects
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
        releaseObject(xlWorksheet)

        mainReload() 'Show/hide user-group-specific objects and functions, check if roster has been sent within the week, and populate combination boxes.

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        aboutProgram()
    End Sub

    Private Sub picLogo_Click(sender As Object, e As EventArgs) Handles picLogoMain.Click
        aboutProgram()
    End Sub

    Private Sub btnCloseApp_Click(sender As Object, e As EventArgs) Handles btnCloseApp.Click
        'Check if changes have been sent/saved then close
        'Source: https://stackoverflow.com/questions/2256909/messagebox-with-yesnocancel-no-cancel-triggers-same-event

        If rosterSentNow = False Then

            Dim rosterSentWeekMessage As String = ""
            If rosterSentWeek = False Then
                rosterSentWeekMessage = "not "
            End If

            Dim messageBoxResult As Integer
            messageBoxResult = MessageBox.Show("Roster has not been sent during the current session." & vbNewLine & "A roster has " & rosterSentWeekMessage & "been sent during this week." & vbNewLine & vbNewLine & "Quit without sending current changes?", "Changes Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If messageBoxResult = DialogResult.Yes Then
                Application.Exit()
            End If

        Else

            Application.Exit()

        End If

    End Sub

    Private Sub btnEditData_Click(sender As Object, e As EventArgs) Handles btnEditData.Click
        frmData.Show()
    End Sub

    Private Sub btnEditShifts_Click(sender As Object, e As EventArgs) Handles btnEditShifts.Click
        frmShifts.Show()
    End Sub

    Private Sub btnEditPIN_Click(sender As Object, e As EventArgs) Handles btnEditPin.Click
        'Change PIN for the currently logged-on user

        Dim pinTry As String
        Dim pinReal As String
        Dim pinNew As String
        Dim pinRedo As String

        'Fetch current pin from settings
        If userGroup = "Owner" Then
            pinReal = My.Settings.pinOwner
        Else
            pinReal = My.Settings.pinChefManager
        End If

        'Verify their old PIN
        pinTry = InputBox("Enter current/old PIN for user-group " & userGroup & ". [1/3]", "Enter Current PIN")

        While pinTry <> pinReal

            pinTry = InputBox("Enter current/old PIN for user-group " & userGroup & ". [1/3]" & vbNewLine & vbNewLine & "Previous attempt incorrect.", "Enter Current PIN")

        End While

        'Get their new PIN
        pinNew = InputBox("Enter new PIN for user-group " & userGroup & ". [2/3]" & vbNewLine & "Enter old PIN and no changes will be made.", "Enter New PIN")

        While Not IsNumeric(pinNew) Or Len(pinNew) <> 4
            'while PIN is not numeric nor 4 digits

            pinNew = InputBox("Enter a new PIN for user group: " & userGroup & ". [2/3]" & vbNewLine & vbNewLine & "PIN must be numeric and 4 digits only.", "Enter new PIN")

        End While

        pinRedo = InputBox("Confirm new PIN for user-group " & userGroup & ". [3/3]", "Confirm New PIN")

        While pinNew <> pinRedo Or Not IsNumeric(pinNew) Or Len(pinNew) <> 4

            pinNew = InputBox("Enter new PIN for user-group " & userGroup & ". [2/3]" & vbNewLine & vbNewLine & "PIN must be numeric and 4 digits only." & vbNewLine & "Previous attempt at confirmation failed.", "Enter New PIN")

            pinRedo = InputBox("Confirm new PIN for user-group " & userGroup & ". [3/3]" & vbNewLine & vbNewLine & "Previous attempt at confirmation failed.", "Confirm New PIN")

        End While

        'If new PIN is same as old PIN, don't change anything
        If pinNew = pinReal Then

            MsgBox("New PIN is the same as the current PIN." & vbNewLine & "PIN not changed (no errors).", MsgBoxStyle.Information, "PIN Not Changed")

        Else

            If userGroup = "Owner" Then
                My.Settings.pinOwner = pinNew
            Else
                My.Settings.pinChefManager = pinNew
            End If

            MsgBox("PIN successfully changed for user group " & userGroup & ".", MsgBoxStyle.Information, "PIN Successfully Changed")

        End If

    End Sub

    Private Sub btnLoadLast_Click(sender As Object, e As EventArgs) Handles btnLoadLast.Click
        'Load the most recently archived roster (if it was archived within the last week)

        Try

            'Display progress bar to let user know the program is responsive and processing
            frmProgress.Text = "Loading Last Roster"
            frmProgress.barProgress.Value = 0
            frmProgress.barProgress.Maximum = 49
            frmProgress.Show()
            frmProgress.lblJob.Text = "Setting up roster:"
            frmProgress.lblTask.Text = "Opening Excel application"

            loadRoster(ROSTERARCHIVE, ROSTERNAME)
            'No internal variables require updating, all done when roster is sent

            frmProgress.Close() 'Close progress bar

            MsgBox("Successfully loaded roster that was archived earlier this week (" & ROSTERNAME & ").", MsgBoxStyle.Information, "Successfully Loaded Roster") 'Report success

        Catch ex As System.ApplicationException

            frmProgress.Close() 'Close progress bar

            'Handle exceptions and display appropriate error messages
            Select Case ex.Message

                Case = "File does not exist"
                    MsgBox("Roster archive file does not exist. No archived rosters." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Exclamation, "File Does Not Exist")

                Case = "Workbook open error"
                    MsgBox("Roster archive file could not be opened. Error openeing workbook." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Critical, "File Could Not Be Opened")

                Case = "Worksheet read error"

                    'If no archive exists for current week, try opening week prior.
                    Try

                        'Display progress bar to let user know the program is responsive and processing
                        frmProgress.Text = "Archiving and Sending Roster"
                        frmProgress.barProgress.Value = 0
                        frmProgress.barProgress.Maximum = 49
                        frmProgress.Show()
                        frmProgress.lblJob.Text = "Setting up roster:"
                        frmProgress.lblTask.Text = "Opening Excel application"

                        loadRoster(ROSTERARCHIVE, ROSTERNAMELAST)
                        'No internal variables require updating, all done when roster is sent

                        frmProgress.Close() 'Close progress bar

                        MsgBox("Successfully loaded roster that was archived last week (" & ROSTERNAMELAST & ").", MsgBoxStyle.Information, "Successfully Loaded Roster")

                    Catch ex2 As System.ApplicationException

                        'Display appropriate error messages
                        Select Case ex2.Message

                            Case = "File does not exist"
                                MsgBox("Roster archive file does not exist. No archived rosters." & vbNewLine & vbNewLine & "Last week's roster could not be loaded.", MsgBoxStyle.Exclamation, "File Does Not Exist")

                            Case = "Workbook open error"
                                MsgBox("Roster archive file could not be opened. Error openeing workbook." & vbNewLine & vbNewLine & "Last week's roster could not be loaded.", MsgBoxStyle.Critical, "File Could Not Be Opened")

                            Case = "Worksheet read error"
                                MsgBox("No roster was archived last week. Worksheet " & ROSTERNAMELAST & " does not exist." & vbNewLine & vbNewLine & "Last week's roster could not be loaded.", MsgBoxStyle.Exclamation, "No Last Week Roster Archive")

                            Case = "Internal write error"
                                MsgBox("Failed to read data from worksheet " & ROSTERNAMELAST & " or failed to store data internally." & vbNewLine & vbNewLine & "Last week's roster could not be loaded.", MsgBoxStyle.Critical, "Failed to Read Data")

                        End Select

                    End Try

                Case = "Internal write error"
                    MsgBox("Failed to read data from worksheet " & ROSTERNAME & " or failed to store data internally." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Critical, "Failed to Read Data")

            End Select

        End Try

    End Sub

    Private Sub btnLoadSuggested_Click(sender As Object, e As EventArgs) Handles btnLoadSuggested.Click
        'Load the roster that was suggested by the chefs/managers

        Try

            'Display progress bar to let user know the program is responsive and processing
            frmProgress.Text = "Loading Suggested Roster"
            frmProgress.barProgress.Value = 0
            frmProgress.barProgress.Maximum = 49
            frmProgress.Show()
            frmProgress.lblJob.Text = "Setting up roster:"
            frmProgress.lblTask.Text = "Opening Excel application"

            loadRoster(ROSTERSUGGESTED, "Main")
            'No internal variables to update, all updated upon sending roster

            frmProgress.Close() 'Close progress bar

            MsgBox("Successfully loaded roster that was last suggested.", MsgBoxStyle.Information, "Successfully Loaded Roster") 'Report success

        Catch ex As System.ApplicationException

            frmProgress.Close() 'Close progress bar

            'Handle exceptions and display appropriate error messages
            Select Case ex.Message

                Case = "File does not exist"
                    MsgBox("Suggested roster file does not exist. No suggested roster." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Exclamation, "File Does Not Exist")

                Case = "Workbook open error"
                    MsgBox("Suggested roster file could not be opened. Error openeing workbook." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Critical, "File Could Not Be Opened")

                Case = "Worksheet read error"
                    MsgBox("No roster has been suggested. Worksheet does not exist." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Exclamation, "No Suggested Roster")

                Case = "Internal write error"
                    MsgBox("Failed to read data from worksheet " & ROSTERNAME & " or failed to store data internally." & vbNewLine & vbNewLine & "Roster could not be loaded.", MsgBoxStyle.Critical, "Failed to Read Data")

            End Select

        End Try

    End Sub

    Private Sub btnSuggestRoster_Click(sender As Object, e As EventArgs) Handles btnSuggestRoster.Click

        'Display progress bar to let user know the program is responsive and processing
        frmProgress.Text = "Suggesting Roster"
        frmProgress.barProgress.Value = 0
        frmProgress.barProgress.Maximum = 95
        frmProgress.Show()
        frmProgress.lblJob.Text = "Creating roster:"
        frmProgress.lblTask.Text = "Opening Excel application"


        'Check/create roster archive

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        'Open Excel application
        xlApp = New Excel.Application

        Try

            If Not File.Exists(ROSTERSUGGESTED) Then
                'Create file if it doesnt exist

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new suggestion workbook"

            Else
                'Add sheet existing file

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Rereating suggestion workbook"

                File.Delete(ROSTERSUGGESTED) 'Delete so that a new blank workbook is used for writing onto

            End If

            'Create new workbook
            xlWorkbook = xlApp.Workbooks.Add()

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Creating new suggestion worksheet"

            'Add sheet to workbook
            xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
            xlWorksheet.Name = "Main"
            xlWorkbook.SaveAs(ROSTERSUGGESTED) 'Save workbook as suggested roster


            'Write roster data to the spreadsheet and format it

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Preparing for data write"

            saveRoster(xlWorkbook, xlWorksheet)


            'Close archive

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Closing suggestion workbook"

            xlWorkbook.Close(True)

        Catch ex As Exception
            'Show error message
            frmProgress.Close()

            MsgBox("Could not access existing or create new suggested roster file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & ROSTERSUGGESTED, MsgBoxStyle.Critical, "Error Loading Suggested Roster")

        End Try


        'Update internal variables

        frmProgress.barProgress.PerformStep()
        frmProgress.lblJob.Text = "Finishing up:"
        frmProgress.lblTask.Text = "Updating internal variables"

        rosterSuggestedExists = File.Exists(ROSTERSUGGESTED)


        'Close progress bar after it is completed
        frmProgress.barProgress.PerformStep()
        frmProgress.Close()


        'Verify that the file exists
        If rosterSuggestedExists = True Then
            'Allow loading suggested roster only if it exists
            btnLoadSuggested.Enabled = True

            'Show confirmation message
            If MessageBox.Show("Roster successfully suggested and saved to a file." & vbNewLine & "Would you like to close the program?", "Successfully Suggested Roster", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

                Application.Exit()

            End If
        Else
            'If there was an error, report it
            MsgBox("Suggested roster file does not exist. Roster could not be suggested." & vbNewLine & "Error: " & ROSTERSUGGESTED, MsgBoxStyle.Critical, "Error Suggesting Roster")

            btnLoadSuggested.Enabled = False 'Just to double-check that it is disabled

        End If


    End Sub

    Private Sub btnSendRoster_Click(sender As Object, e As EventArgs) Handles btnSendRoster.Click

        'Display progress bar to let user know the program is responsive and processing
        frmProgress.Text = "Archiving and Sending Roster"
        frmProgress.barProgress.Value = 0
        frmProgress.barProgress.Maximum = 107
        frmProgress.Show()
        frmProgress.lblJob.Text = "Creating roster:"
        frmProgress.lblTask.Text = "Opening Excel application"


        'Check/create roster archive

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet
        'Open Excel application
        xlApp = New Excel.Application

        Try

            If Not File.Exists(ROSTERARCHIVE) Then
                'Create roster archive if it doesnt exist

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new archive workbook"

                xlWorkbook = xlApp.Workbooks.Add()

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new archive worksheet"

                'Add this week's roster to roster archive

                Try 'Try to open roster sheet for this week...
                    xlWorksheet = CType(xlWorkbook.Worksheets(ROSTERNAME), Excel.Worksheet)
                Catch ex As Exception 'If no roster archived (no sheet exists) for this week, create a sheet...
                    xlWorksheet = CType(xlWorkbook.Worksheets(xlWorkbook.Worksheets.Count), Excel.Worksheet) 'Focus latest roster so can add one after it
                    xlWorksheet = CType(xlWorkbook.Worksheets.Add(Count:=1), Excel.Worksheet)
                    xlWorksheet.Name = ROSTERNAME
                End Try

                xlWorkbook.SaveAs(ROSTERARCHIVE) 'Save new file

            Else
                'Add this week's roster to existing roster archive

                frmProgress.barProgress.Increment(2)
                frmProgress.lblTask.Text = "Creating new archive worksheet"

                xlWorkbook = xlApp.Workbooks.Open(ROSTERARCHIVE)

                'Add this week's roster to roster archive

                Try 'Try to open roster sheet for this week...
                    xlWorksheet = CType(xlWorkbook.Worksheets(ROSTERNAME), Excel.Worksheet)
                Catch ex As Exception 'If no roster archived (no sheet exists) for this week, create a sheet...
                    xlWorksheet = CType(xlWorkbook.Worksheets(xlWorkbook.Worksheets.Count), Excel.Worksheet) 'Focus latest roster so can add one after it
                    xlWorksheet = CType(xlWorkbook.Worksheets.Add(Count:=1), Excel.Worksheet)
                    xlWorksheet.Name = ROSTERNAME
                End Try

            End If


            'Clear/blank all cells for next roster to be written
            'Source: https://docs.microsoft.com/en-us/office/vba/api/excel.range.clear
            xlWorksheet.Range("A1:G15").Clear()


            'Format all cells
            'Source: https://social.msdn.microsoft.com/Forums/en-US/80be0b32-c613-4a6c-ae3e-611d28b0f74b/how-do-you-change-the-width-of-a-excel-cell-or-columns-in-vbnet?forum=vblanguage
            'Source: https://stackoverflow.com/questions/28915252/align-excel-cell-to-center-vb-xlcenter-is-not-declared

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Formatting roster:"
            frmProgress.lblTask.Text = "Global cell font"

            xlWorksheet.Range("A1", "G15").Font.Size = 7
            xlWorksheet.Range("A1", "G15").WrapText = True

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Global cell size"

            xlWorksheet.Range("A1", "G15").ColumnWidth = 11
            xlWorksheet.Range("A1", "G15").RowHeight = 16

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Header text alignment"

            'Set text alignment for each row
            xlWorksheet.Range("A1", "G15").HorizontalAlignment = Excel.Constants.xlCenter
            xlWorksheet.Range("A1", "G1").VerticalAlignment = Excel.Constants.xlBottom
            xlWorksheet.Range("A2", "G2").VerticalAlignment = Excel.Constants.xlTop
            xlWorksheet.Range("A3", "G3").VerticalAlignment = Excel.Constants.xlCenter

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Body text alignment"

            'Even rows = bottom aligned, odd rows = top aligned.
            Dim row As Integer
            For row = 4 To 14 Step 2
                xlWorksheet.Range("A" & CStr(row), "G" & CStr(row)).VerticalAlignment = Excel.Constants.xlBottom
            Next
            For row = 5 To 15 Step 2
                xlWorksheet.Range("A" & CStr(row), "G" & CStr(row)).VerticalAlignment = Excel.Constants.xlTop
            Next


            'Format headers

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Header cells merge"

            xlWorksheet.Range(xlWorksheet.Cells(1, 1), xlWorksheet.Cells(1, 7)).Merge()
            xlWorksheet.Range(xlWorksheet.Cells(2, 1), xlWorksheet.Cells(2, 7)).Merge()

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Days-of-the-week headings text style"

            xlWorksheet.Range("A3", "G3").Font.Bold = True
            xlWorksheet.Range("A3", "G3").Font.Italic = True

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Header text style"

            xlWorksheet.Range("A1").Font.Bold = True
            xlWorksheet.Range("A2").Font.Underline = True

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Header text colour"

            xlWorksheet.Range("A1").Font.Color = Color.DodgerBlue
            xlWorksheet.Range("A2").Font.Color = Color.DodgerBlue


            'Write headers to roster

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Writing roster:"
            frmProgress.lblTask.Text = "Header text and date"

            Dim yearNow As Integer = CInt(DateTime.Now.Year)

            xlWorksheet.Cells(1, 1) = "Blue Dog Café Roster"
            xlWorksheet.Cells(2, 1) = "Week " & WEEKNUMBER & ", " & CStr(yearNow) & " (" & calendarDate(yearNow, WEEKNUMBER, 1) & " - " & calendarDate(yearNow, WEEKNUMBER, 7) & ")"


            'Write day-of-the-week names to roster

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Days-of-the-week headings"

            xlWorksheet.Cells(3, 1) = "Thu"
            xlWorksheet.Cells(3, 2) = "Fri"
            xlWorksheet.Cells(3, 3) = "Sat"
            xlWorksheet.Cells(3, 4) = "Sun"
            xlWorksheet.Cells(3, 5) = "Mon"
            xlWorksheet.Cells(3, 6) = "Tue"
            xlWorksheet.Cells(3, 7) = "Wed"


            'Write roster data to the spreadsheet and format it

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Preparing for data write"

            saveRoster(xlWorkbook, xlWorksheet)


            'Export roster as PDF
            'Source: https://www.codeproject.com/Questions/1209578/Converting-excel-to-pdf-with-microsoft-interop-exc
            'Modifications: Hard-coded desired values and removed unnecesary code

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Exporting roster:"
            frmProgress.lblTask.Text = "Saving current roster as PDF"

            If Not xlWorkbook Is Nothing Then
                xlWorksheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, ROSTERARCHIVE, Excel.XlFixedFormatQuality.xlQualityStandard, True, True, 1, 1, False) ''Old page index: xlWorkbook.Sheets.Count
            End If


            'Close archive

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Closing roster archive workbook"

            xlWorkbook.Close(True)

        Catch ex As Exception
            'Show error message
            frmProgress.Close()

            MsgBox("Could not access existing or create new roster archive file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & ROSTERARCHIVE, MsgBoxStyle.Critical, "Error Loading Roster Archive")

        End Try


        'Send PDF of roster via email

        'Set up variables for confirmation message
        Dim messageSent As String = ""
        Dim messageArchive As String = ""
        Dim messageSentTitle As String = ""

        If rosterSentWeek = False Then

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Sending roster:"
            frmProgress.lblTask.Text = "Adding employees as recipients"

            Try

                Dim recipientList(employeeCount - 1) As String

                For employee As Integer = 0 To employeeCount - 1
                    'Add each employee's email to the recipient list

                    recipientList(employee) = employeeData(employee).emailAddress

                Next


                sendEmail(recipientList)


                'Update internal variables

                frmProgress.barProgress.PerformStep()
                frmProgress.lblJob.Text = "Finishing up:"
                frmProgress.lblTask.Text = "Updating internal variables"

                rosterSentNow = True
                rosterSentWeek = True
                My.Settings.rosterLastSent = DateTime.Now
                rosterLastSentWeek = DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(My.Settings.rosterLastSent, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DayOfWeek.Thursday)


                'Close progress bar after it is completed
                frmProgress.barProgress.PerformStep()
                frmProgress.Close()

                'Set confirmation message
                messageSentTitle = "Sent and "
                messageSent = "Roster successfully sent to " & recipientList.Length & " email addresses:" & vbNewLine & vbNewLine
                For Each email In recipientList
                    'Add each email to the message
                    messageSent += " " & email & vbNewLine
                Next
                messageSent += vbNewLine & vbNewLine
                messageArchive = "No rosters were overwritten."


            Catch ex As Exception
                'Show error message
                frmProgress.Close()

                MsgBox("Failed to send message containing roster via email." & vbNewLine & "Error: " & ex.ToString(), MsgBoxStyle.Critical, "Error Sending Roster Email")

            End Try


        Else

            'Close progress bar after it is completed
            frmProgress.barProgress.Increment(6)
            frmProgress.Close()

            'Set confirmation message
            messageArchive = "Previously sent roster was overwritten."

        End If


        'Offer to delete suggested roster

        Dim messageSuggested As String = ""

        If rosterSuggestedExists = True Then

            If MessageBox.Show("A suggested roster file exists. If you used this file to create the roster you just archived/sent, it is recommended that you delete it." & vbNewLine & vbNewLine & "Would you like to delete the suggested roster?", "Delete Suggested Roster?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

                Try
                    'Delete the roster and update internal variables
                    My.Computer.FileSystem.DeleteFile(ROSTERSUGGESTED)
                    rosterSuggestedExists = File.Exists(ROSTERSUGGESTED)

                    'Verify that the roster was deleted
                    If rosterSuggestedExists = False Then
                        'Update reporting message
                        messageSuggested = "Suggested roster file successfully deleted." & vbNewLine
                    Else
                        Throw New Exception 'To be caught to display correct error message
                    End If

                Catch ex As Exception
                    messageSuggested = "Suggested roster file could not be deleted (error)." & vbNewLine

                End Try

            Else
                'Update reporting message
                messageSuggested = "Suggested roster file was not deleted." & vbNewLine

            End If

        End If

        'Show confirmation message
        If MessageBox.Show(messageSent & "Roster for week " & WEEKNUMBER & " (" & WEEKSTART & ") sucessfully archived as " & ROSTERARCHIVE & "." & vbNewLine & vbNewLine & messageArchive & vbNewLine & messageSuggested & vbNewLine & "Would you like to close the program?", "Successfully " & messageSentTitle & "Archived", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

            Application.Exit()

        End If

    End Sub

    Private Sub btnSearchArchive_Click(sender As Object, e As EventArgs) Handles btnSearchArchive.Click
        frmSearch.Show()
    End Sub


    'Update shift combination box items when a staff member is selected...
    Private Sub cmbStaffThu1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu1.SelectedIndexChanged
        getShifts(1, 1, cmbStaffThu1.Text)
    End Sub
    Private Sub cmbStaffThu2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu2.SelectedIndexChanged
        getShifts(1, 2, cmbStaffThu2.Text)
    End Sub
    Private Sub cmbStaffThu3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu3.SelectedIndexChanged
        getShifts(1, 3, cmbStaffThu3.Text)
    End Sub
    Private Sub cmbStaffThu4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu4.SelectedIndexChanged
        getShifts(1, 4, cmbStaffThu4.Text)
    End Sub
    Private Sub cmbStaffThu5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu5.SelectedIndexChanged
        getShifts(1, 5, cmbStaffThu5.Text)
    End Sub
    Private Sub cmbStaffThu6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffThu6.SelectedIndexChanged
        getShifts(1, 6, cmbStaffThu6.Text)
    End Sub
    Private Sub cmbStaffFri1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri1.SelectedIndexChanged
        getShifts(2, 1, cmbStaffFri1.Text)
    End Sub
    Private Sub cmbStaffFri2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri2.SelectedIndexChanged
        getShifts(2, 2, cmbStaffFri2.Text)
    End Sub
    Private Sub cmbStaffFri3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri3.SelectedIndexChanged
        getShifts(2, 3, cmbStaffFri3.Text)
    End Sub
    Private Sub cmbStaffFri4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri4.SelectedIndexChanged
        getShifts(2, 4, cmbStaffFri4.Text)
    End Sub
    Private Sub cmbStaffFri5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri5.SelectedIndexChanged
        getShifts(2, 5, cmbStaffFri5.Text)
    End Sub
    Private Sub cmbStaffFri6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffFri6.SelectedIndexChanged
        getShifts(2, 6, cmbStaffFri6.Text)
    End Sub
    Private Sub cmbStaffSat1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat1.SelectedIndexChanged
        getShifts(3, 1, cmbStaffSat1.Text)
    End Sub
    Private Sub cmbStaffSat2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat2.SelectedIndexChanged
        getShifts(3, 2, cmbStaffSat2.Text)
    End Sub
    Private Sub cmbStaffSat3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat3.SelectedIndexChanged
        getShifts(3, 3, cmbStaffSat3.Text)
    End Sub
    Private Sub cmbStaffSat4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat4.SelectedIndexChanged
        getShifts(3, 4, cmbStaffSat4.Text)
    End Sub
    Private Sub cmbStaffSat5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat5.SelectedIndexChanged
        getShifts(3, 5, cmbStaffSat5.Text)
    End Sub
    Private Sub cmbStaffSat6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSat6.SelectedIndexChanged
        getShifts(3, 6, cmbStaffSat6.Text)
    End Sub
    Private Sub cmbStaffSun1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun1.SelectedIndexChanged
        getShifts(4, 1, cmbStaffSun1.Text)
    End Sub
    Private Sub cmbStaffSun2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun2.SelectedIndexChanged
        getShifts(4, 2, cmbStaffSun2.Text)
    End Sub
    Private Sub cmbStaffSun3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun3.SelectedIndexChanged
        getShifts(4, 3, cmbStaffSun3.Text)
    End Sub
    Private Sub cmbStaffSun4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun4.SelectedIndexChanged
        getShifts(4, 4, cmbStaffSun4.Text)
    End Sub
    Private Sub cmbStaffSun5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun5.SelectedIndexChanged
        getShifts(4, 5, cmbStaffSun5.Text)
    End Sub
    Private Sub cmbStaffSun6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffSun6.SelectedIndexChanged
        getShifts(4, 6, cmbStaffSun6.Text)
    End Sub
    Private Sub cmbStaffMon1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon1.SelectedIndexChanged
        getShifts(5, 1, cmbStaffMon1.Text)
    End Sub
    Private Sub cmbStaffMon2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon2.SelectedIndexChanged
        getShifts(5, 2, cmbStaffMon2.Text)
    End Sub
    Private Sub cmbStaffMon3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon3.SelectedIndexChanged
        getShifts(5, 3, cmbStaffMon3.Text)
    End Sub
    Private Sub cmbStaffMon4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon4.SelectedIndexChanged
        getShifts(5, 4, cmbStaffMon4.Text)
    End Sub
    Private Sub cmbStaffMon5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon5.SelectedIndexChanged
        getShifts(5, 5, cmbStaffMon5.Text)
    End Sub
    Private Sub cmbStaffMon6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffMon6.SelectedIndexChanged
        getShifts(5, 6, cmbStaffMon6.Text)
    End Sub
    Private Sub cmbStaffTue1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue1.SelectedIndexChanged
        getShifts(6, 1, cmbStaffTue1.Text)
    End Sub
    Private Sub cmbStaffTue2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue2.SelectedIndexChanged
        getShifts(6, 2, cmbStaffTue2.Text)
    End Sub
    Private Sub cmbStaffTue3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue3.SelectedIndexChanged
        getShifts(6, 3, cmbStaffTue3.Text)
    End Sub
    Private Sub cmbStaffTue4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue4.SelectedIndexChanged
        getShifts(6, 4, cmbStaffTue4.Text)
    End Sub
    Private Sub cmbStaffTue5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue5.SelectedIndexChanged
        getShifts(6, 5, cmbStaffTue5.Text)
    End Sub
    Private Sub cmbStaffTue6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffTue6.SelectedIndexChanged
        getShifts(6, 6, cmbStaffTue6.Text)
    End Sub
    Private Sub cmbStaffWed1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed1.SelectedIndexChanged
        getShifts(7, 1, cmbStaffWed1.Text)
    End Sub
    Private Sub cmbStaffWed2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed2.SelectedIndexChanged
        getShifts(7, 2, cmbStaffWed2.Text)
    End Sub
    Private Sub cmbStaffWed3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed3.SelectedIndexChanged
        getShifts(7, 3, cmbStaffWed3.Text)
    End Sub
    Private Sub cmbStaffWed4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed4.SelectedIndexChanged
        getShifts(7, 4, cmbStaffWed4.Text)
    End Sub
    Private Sub cmbStaffWed5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed5.SelectedIndexChanged
        getShifts(7, 5, cmbStaffWed5.Text)
    End Sub
    Private Sub cmbStaffWed6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStaffWed6.SelectedIndexChanged
        getShifts(7, 6, cmbStaffWed6.Text)
    End Sub

End Class
