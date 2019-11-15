' Name:             Shifts Entry
' Purpose:          Add/remove shift-blocks and save to the data store.
' Author:           Jules Carboni
' Date Created:     14 May 2019
' Date Modified:    23 July 2019

Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel 'Import Excel functionality

Public Class frmShifts

    'Declare variables
    Dim shiftDataBackup As New List(Of shiftDataStrcuture)

    Sub populateList()

        lstShifts.Items.Clear() 'Clear list box

        'Declare variables
        Dim shiftNumber As Integer
        Dim shiftStart As String
        Dim shiftFinish As String

        For shiftNumber = 0 To shiftData.Count - 1
            'Get string containing shift and add it to the list box.

            shiftStart = minToTime(shiftData(shiftNumber).timeStart)
            shiftFinish = minToTime(shiftData(shiftNumber).timeFinish)

            lstShifts.Items.Add(shiftStart & " - " & shiftFinish)

        Next

    End Sub

    Private Sub frmData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Backup shift data records (for restoring if user presses cancel)
        shiftDataBackup = shiftData

        populateList() 'Populate the list box with all the stored shifts

    End Sub

    Private Sub btnAddShift_Click(sender As Object, e As EventArgs) Handles btnAddShift.Click
        'Get start and finish times from user and store that in the record structure (and update list box)

        'Declare variables
        Dim shiftNew As shiftDataStrcuture
        Dim shiftStart As String
        Dim shiftFinish As String

        Try

            'Get input from user and add it to the new shift

            shiftStart = InputBox("Enter the starting time for the new shift." & vbNewLine & "Format: hh:mm aa. Example: 9:30 am.", "New Shift Start Time", "hh:mm aa")
            shiftNew.timeStart = timeToMin(shiftStart)

            shiftFinish = InputBox("Enter the finishing time for the new shift." & vbNewLine & "Format: hh:mm aa. Example: 5:30 pm.", "New Shift Finish Time", "hh:mm aa")
            shiftNew.timeFinish = timeToMin(shiftFinish)

            'Do not add the shift if the finish time is earlier than the start time
            If shiftNew.timeFinish < shiftNew.timeStart Then

                'Show error message
                MsgBox("Shift finish time cannot be prior to shift start time." & vbNewLine & "No shift was added.", MsgBoxStyle.Exclamation, "Invalid Time Entry")

            Else

                'Add the new shift to the records and update vars

                shiftData.Add(shiftNew)
                shiftCount = shiftData.Count

                populateList() 'Repopulate entire listbox to ensure data parity

            End If

        Catch ex As Exception

            'If invalid data given, stop process of adding shift
            MsgBox("Entry was not a valid timestamp." & vbNewLine & "No shift was added.", MsgBoxStyle.Exclamation, "Invalid Time Entry")

        End Try

    End Sub

    Private Sub btnRemoveShift_Click(sender As Object, e As EventArgs) Handles btnRemoveShift.Click
        'Remove selected shift

        Dim index As Integer = lstShifts.SelectedIndex

        'Remove from records and update vars
        shiftData.RemoveAt(index)
        shiftCount = shiftData.Count

        'Repopulate entire listbox to ensure data parity
        populateList()

        'Update buttons
        btnRemoveShift.Enabled = False

    End Sub

    Private Sub lstShifts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstShifts.SelectedIndexChanged
        'When the user selects an existing shift-block, allow them to remove it.
        If lstShifts.SelectedItem IsNot Nothing Then
            btnRemoveShift.Enabled = True
        Else
            btnRemoveShift.Enabled = False
        End If
    End Sub

    Private Sub btnOkShifts_Click(sender As Object, e As EventArgs) Handles btnOkShifts.Click
        'Save new data to the Excel spreadsheet

        'Display progress bar to let user know the program is responsive and processing
        frmProgress.Text = "Saving Shifts"
        frmProgress.barProgress.Value = 0
        frmProgress.barProgress.Maximum = shiftCount + 6
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

            If Not File.Exists(SHIFTFILE) Then
                'Create file if it doesnt exist

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new shift workbook"

                xlWorkbook = xlApp.Workbooks.Add()

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Creating new shift worksheet"

                'Add sheet to file
                xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)
                xlWorksheet.Name = "Main"
                xlWorkbook.SaveAs(SHIFTFILE)

            Else
                'Add sheet existing file

                frmProgress.barProgress.Increment(2)
                frmProgress.lblTask.Text = "Creating new shift worksheet"

                xlWorkbook = xlApp.Workbooks.Open(SHIFTFILE)
                xlWorksheet = CType(xlWorkbook.Worksheets(1), Excel.Worksheet)

            End If


            xlWorksheet.Cells.NumberFormat = "@" 'Format all cells as text


            'Write shift data to the spreadsheet

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Writing shifts:"

            Dim shiftNumber As Integer
            For shiftNumber = 0 To shiftCount - 1

                frmProgress.barProgress.PerformStep()
                frmProgress.lblTask.Text = "Writing data to file (N:" & shiftNumber & ")"

                'Write the data
                xlWorksheet.Cells(1, shiftNumber + 1) = shiftData(shiftNumber).timeStart
                xlWorksheet.Cells(2, shiftNumber + 1) = shiftData(shiftNumber).timeFinish

            Next


            'Save changes to file

            frmProgress.barProgress.PerformStep()
            frmProgress.lblJob.Text = "Saving shifts:"
            frmProgress.lblTask.Text = "Saving changes to shift workbook"

            xlWorkbook.Save()


            'Close archive

            frmProgress.barProgress.PerformStep()
            frmProgress.lblTask.Text = "Closing suggestion workbook"

            xlWorkbook.Close(True)


            'Close progress bar

            frmProgress.barProgress.PerformStep()
            frmProgress.Close()


        Catch ex As Exception
            'Show error message
            frmProgress.Close()

            MsgBox("Could not access existing or create new shift file." & vbNewLine & "Please close any applications that may be using the file and restart this program." & vbNewLine & vbNewLine & "Error: " & SHIFTFILE, MsgBoxStyle.Critical, "Error Saving Shifts")

        End Try


        'Refresh shift data displayed in main form, then close this form

        mainReload()
        Me.Close()


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close this form without saving changes

        'Restore employee data records
        shiftData = shiftDataBackup

        'Refresh shift data displayed in main form, then close this form
        mainReload()
        Me.Close()
    End Sub

End Class