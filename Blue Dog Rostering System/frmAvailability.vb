' Name:             Availability Entry
' Purpose:          Add/edit employee's availability and save to data store.
' Author:           Jules Carboni
' Date Created:     14 May 2019
' Date Modified:    23 July 2019

Public Class frmAvailability

    'Declare variables
    Dim employeeAvailabilityBackup As New List(Of availabilityStructure)
    Dim employeeIndex As Integer = frmData.employeeSelectedIndex
    Dim employeeName As String = frmData.employeeSelected

    Private Sub frmAvailability_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Add optiosn to combination boxes
        For Each comboBox In Me.Controls.OfType(Of ComboBox)()

            comboBox.Items.Add("12:00 am")
            comboBox.Items.Add("12:30 am")
            comboBox.Items.Add("1:00 am")
            comboBox.Items.Add("1:30 am")
            comboBox.Items.Add("2:00 am")
            comboBox.Items.Add("2:30 am")
            comboBox.Items.Add("3:00 am")
            comboBox.Items.Add("3:30 am")
            comboBox.Items.Add("4:00 am")
            comboBox.Items.Add("4:30 am")
            comboBox.Items.Add("5:00 am")
            comboBox.Items.Add("5:30 am")
            comboBox.Items.Add("6:00 am")
            comboBox.Items.Add("6:30 am")
            comboBox.Items.Add("7:00 am")
            comboBox.Items.Add("7:30 am")
            comboBox.Items.Add("8:00 am")
            comboBox.Items.Add("8:30 am")
            comboBox.Items.Add("9:00 am")
            comboBox.Items.Add("9:30 am")
            comboBox.Items.Add("10:00 am")
            comboBox.Items.Add("10:30 am")
            comboBox.Items.Add("11:00 am")
            comboBox.Items.Add("11:30 am")
            comboBox.Items.Add("12:00 pm")
            comboBox.Items.Add("12:30 pm")
            comboBox.Items.Add("1:00 pm")
            comboBox.Items.Add("1:30 pm")
            comboBox.Items.Add("2:00 pm")
            comboBox.Items.Add("2:30 pm")
            comboBox.Items.Add("3:00 pm")
            comboBox.Items.Add("3:30 pm")
            comboBox.Items.Add("4:00 pm")
            comboBox.Items.Add("4:30 pm")
            comboBox.Items.Add("5:00 pm")
            comboBox.Items.Add("5:30 pm")
            comboBox.Items.Add("6:00 pm")
            comboBox.Items.Add("6:30 pm")
            comboBox.Items.Add("7:00 pm")
            comboBox.Items.Add("7:30 pm")
            comboBox.Items.Add("8:00 pm")
            comboBox.Items.Add("8:30 pm")
            comboBox.Items.Add("9:00 pm")
            comboBox.Items.Add("9:30 pm")
            comboBox.Items.Add("10:00 pm")
            comboBox.Items.Add("10:30 pm")
            comboBox.Items.Add("11:00 pm")
            comboBox.Items.Add("11:30 pm")
            comboBox.Items.Add("Close")

        Next

        'Backup employee availability records (for restoring if user presses cancel)
        employeeAvailabilityBackup = employeeAvailability

        'Update title text to match selected employee
        lblTitleAvailability.Text = employeeName & "'s Availability"

        'Populate text boxes from records
        cmbThursdayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 0).timeStart)
        cmbThursdayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 0).timeFinish)
        cmbFridayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 1).timeStart)
        cmbFridayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 1).timeFinish)
        cmbSaturdayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 2).timeStart)
        cmbSaturdayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 2).timeFinish)
        cmbSundayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 3).timeStart)
        cmbSundayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 3).timeFinish)
        cmbMondayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 4).timeStart)
        cmbMondayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 4).timeFinish)
        cmbTuesdayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 5).timeStart)
        cmbTuesdayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 5).timeFinish)
        cmbWednesdayStart.Text = minToTime(employeeAvailability(7 * employeeIndex + 6).timeStart)
        cmbWednesdayFinish.Text = minToTime(employeeAvailability(7 * employeeIndex + 6).timeFinish)

    End Sub

    Private Sub btnOkAvailability_Click(sender As Object, e As EventArgs) Handles btnOkAvailability.Click

        'Store new values in records (they will be saved later)

        'Use temporary variable to satisfy VB value assigning conditions
        Dim dayTemp As Integer = 7 * employeeIndex
        Dim availabilityTemp As availabilityStructure = employeeAvailability(dayTemp)

        Try

            availabilityTemp.timeStart = timeToMin(cmbThursdayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbThursdayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbFridayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbFridayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbSaturdayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbSaturdayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbSundayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbSundayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbMondayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbMondayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbTuesdayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbTuesdayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

            dayTemp += 1
            availabilityTemp = employeeAvailability(dayTemp)
            availabilityTemp.timeStart = timeToMin(cmbWednesdayStart.Text)
            availabilityTemp.timeFinish = timeToMin(cmbWednesdayFinish.Text)
            If availabilityTemp.timeStart > availabilityTemp.timeFinish Then
                Throw New Exception("Finish earlier than start.") 'If shift finishes before it starts, throw error.
            End If
            employeeAvailability(dayTemp) = availabilityTemp

        Catch ex As Exception

            If ex.Message = "Finish earlier than start." Then

                MsgBox("Availability could not be saved due to a shift ending before it has begun. Start times must be earlier than finish times." & vbNewLine & "Please correct this error and try again.", MsgBoxStyle.Critical, "Invalid Time Entry")

            Else

                MsgBox("Availability could not be saved due to an erroneous time entry. All times should be in the format: hh:mm am/pm." & vbNewLine & "Please correct this error and try again.", MsgBoxStyle.Critical, "Invalid Time Entry")

            End If

            Exit Sub 'Do not proceed with saving data

        End Try


        'Determine if the data set is complete, if it is then availability has been fully submitted for that employee.
        Dim blankField As Boolean = False

        Dim dayIndex As Integer
        For dayIndex = 7 * employeeIndex To 7 * employeeIndex + 6

            If EmployeeAvailability(dayIndex).timeStart = 0 Or EmployeeAvailability(dayIndex).timeFinish = 0 Then
                blankField = True
            End If

        Next


        'Update variables and inform users of changes
        Dim employeeDataTemp As employeeDataStructure = employeeData(employeeIndex) 'Get employee data from array

        'Modify employee data and warn user of incompleteness
        If blankField = True Then
            employeeDataTemp.availabilityStored = False
            MsgBox("Availability has not been supplied in full." & vbNewLine & employeeName & "'s availability is considered 'not stored'.", MsgBoxStyle.Exclamation, "Availability Not Complete")
        Else
            employeeDataTemp.availabilityStored = True
        End If

        employeeData(employeeIndex) = employeeDataTemp 'Write back to array


        'Inform users that they must OK changes in data form for availability changes to be saved
        MsgBox("Availability has been recorded and is ready for saving." & vbNewLine & "For these changes to take effect, you must accept your employee data changes.", MsgBoxStyle.Information, "Availability Ready For Saving")


        'Refresh employee data displayed in main form, then close this form
        frmData.populateLists()
        Me.Close()

    End Sub

    Private Sub btnCancelAvailability_Click(sender As Object, e As EventArgs) Handles btnCancelAvailability.Click
        'Close without saving changes to file

        'Restore employee data records
        employeeAvailability = employeeAvailabilityBackup

        'Refresh employee data displayed in main form, then close this form
        frmData.populateLists()
        Me.Close()

    End Sub

End Class