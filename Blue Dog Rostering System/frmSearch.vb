' Name:             Search Archive
' Purpose:          Search And sort archived rosters for shifts by employee name. Get basic statistics on employee. Save results to file.
' Author:           Jules Carboni
' Date Created:     14 May 2019
' Date Modified:    23 July 2019

Imports Excel = Microsoft.Office.Interop.Excel 'Import Excel functionality
Imports System.IO

Public Class frmSearch

    Const MAXSEARCH As Integer = 1000 'No limit requested by client, but because of the slow search algorithm used this maxsize was set. This limit should not be during the 5-year life of the program.

    Dim dayName As New Dictionary(Of Integer, String) From {{1, "Thursday"}, {2, "Friday"}, {3, "Saturday"}, {4, "Sunday"}, {5, "Monday"}, {6, "Tuesday"}, {7, "Wednesday"}} 'Dictionary to convert integer to name of the day

    Dim results As New List(Of resultStructure) 'For storing results
    Dim resultCount As Integer = 0 'Index for result record

    Private Structure resultStructure
        'Structure to store results
        Dim year As Integer
        Dim week As Integer '0 to 52
        Dim day As String
        Dim calDate As Date 'Calendar date
        Dim timeStart As String
        Dim timeFinish As String
        '24hr values for sorting and calculating
        Dim timeStartInt As Integer
        Dim timeFinishInt As Integer
        Dim duration As Integer 'Number of minutes
    End Structure

    ' Having considered both Quicksort And Selection Sort And Binary Search And Linear Search, I have chosen Not use the Quicksort Or the Binary Search because I don't need it as my data set contains less than one throusand elements and therefore my effeciency in terms of time is not affected that much.
    '
    ' This is the function that I would have considered
    '
    ' Function Quicksort(list, first, last)
    '     Begin
    '     If last > first Then
    '         Pivot = first element Of the array list
    ' 	  Left = first index Of the list
    ' 	  Right = last index Of the list
    '     While Left <= Right
    '             While list(Left) < pivot
    '                 Left = Left + 1
    '             End While
    '             While list(Right) > pivot
    '                 Right = Right - 1
    '             End While
    '             If Left <= Right Then
    '                 swap list(Left) With list(right)
    '	              Left = Left + 1
    '                 Right = Right – 1
    '             End If
    '         End While
    '         Quicksort(list, first, Right)
    '         Quicksort(list, Left, last)
    '     End If
    'End
    '
    'Function linearSearch(list, searchTerm):
    '    For index from 0 to lengthOf(list)
    '        If list(index) = searchTerm Then
    '            Return index
    '        End If
    '    End For
    '    Return -1
    'End Function    

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Populate combobox with all employee names

        Dim index As Integer
        For index = 0 To employeeCount - 1

            cmbEmployeeSearch.Items.Add(employeeData(index).nameFull)

        Next

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Search archive for worked shifts and diplay them in a list box (linear search)

        'Source: http://vb.net-informations.com/excel-2007/vb.net_excel_2007_open_file.htm
        'Source: https://stackoverflow.com/questions/21000965/check-to-see-if-sheet-exists-in-excel-and-record-result-as-boolean
        'Source: https://stackoverflow.com/questions/2483659/interop-type-cannot-be-embedded
        'Source: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/statements/for-next-statement

        'Display progress bar to let user know the program is responsive and processing
        frmProgress.Text = "Searching Roster Archive"
        frmProgress.barProgress.Value = 0
        frmProgress.barProgress.Maximum = 100
        frmProgress.lblJob.Text = "Setting up search:"
        frmProgress.lblTask.Text = "Opening Excel application"
        frmProgress.Show()

        Dim searchItem As String = cmbEmployeeSearch.Text 'Employee to search for
        results.Clear() 'Clear all prior results
        resultCount = 0

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet

        'Open archive file
        xlApp = New Excel.Application

        If xlApp Is Nothing Then
            MsgBox("Microsoft Excel is damaged or not installed on your system." & vbNewLine & "Please install Excel as it is required for this program to function." & vbNewLine & vbNewLine & "This program will close.", MsgBoxStyle.Critical, "Excel Not Installed")
            Application.Exit()

        Else

            If Not File.Exists(ROSTERARCHIVE) Then
                frmProgress.Close()
                MsgBox("No archived rosters to search.", MsgBoxStyle.Information, "No Archived Rosters")

            Else
                Try

                    frmProgress.lblTask.Text = "Opening Excel workbook"

                    xlWorkbook = xlApp.Workbooks.Open(ROSTERARCHIVE)

                    frmProgress.barProgress.Maximum = (xlWorkbook.Sheets.Count * 7 * 6) + 7 'Calculate and set to accurately display progress
                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblJob.Text = "Searching archive:"

                    For Each xlWorksheet In xlWorkbook.Sheets 'for each week...
                        'Open each roster within archive
                        xlWorksheet.Activate()

                        Dim day As Integer
                        Dim worker As Integer

                        Dim xlRange As Excel.Range
                        Dim shiftTimes As Object

                        For day = 1 To 7 'For Each day in roster
                            'Search each day of the week

                            For worker = 4 To 14 Step 2
                                'Search each worker assigned for that day

                                frmProgress.barProgress.PerformStep()
                                frmProgress.lblTask.Text = "Reading roster data (D:" & day.ToString("D2") & " S:" & worker.ToString("D2") & ")"

                                If CStr(xlWorksheet.Range(getLetter(day) & worker).Value) = searchItem Then
                                    'If found, store data in record

                                    'Source: https://stackoverflow.com/questions/38114793/how-to-extract-excel-sheet-name-from-workbook-using-vb-net
                                    'Source: https://www.dotnetperls.com/substring-vbnet
                                    'Source: https://stackoverflow.com/questions/23004274/vb-net-excel-worksheet-cells-value


                                    Dim shiftYear As Integer = 2019 + CInt(xlWorksheet.Name.Substring(1, 2))
                                    Dim shiftWeek As Integer = CInt(xlWorksheet.Name.Substring(5, 2))
                                    Dim shiftDay As String = dayName(day)
                                    Dim shiftCalDate As Date = calendarDate(shiftYear, shiftWeek, day)

                                    xlRange = CType(xlWorksheet.Cells(worker + 1, day), Excel.Range) 'Get shift times from corresponding cell
                                    shiftTimes = xlRange.Value()

                                    Dim shiftFinish As String
                                    Dim shiftStart As String = CStr(shiftTimes).Substring(0, 7)
                                    If shiftStart.Substring(shiftStart.Length - 1, 1) <> "m" Then 'If didn't get whole substring, try larger substring
                                        'Therefore start is big

                                        shiftStart = CStr(shiftTimes).Substring(0, 8)

                                        Try 'If input string too short, try smaller substring
                                            shiftFinish = CStr(shiftTimes).Substring(11, 8)
                                        Catch
                                            Try 'If not a valid time, handle as "close" time
                                                shiftFinish = CStr(shiftTimes).Substring(11, 7)
                                            Catch
                                                shiftFinish = "Close  "
                                            End Try
                                        End Try

                                    Else
                                        'Therefore start is small

                                        Try 'If input string too short, try smaller substring
                                            shiftFinish = CStr(shiftTimes).Substring(10, 8)
                                        Catch
                                            Try 'If not a valid time, handle as "close" time
                                                shiftFinish = CStr(shiftTimes).Substring(10, 7)
                                            Catch
                                                shiftFinish = "Close  "
                                            End Try
                                        End Try

                                    End If


                                    'Convert to minutes-since-midnight value
                                    Dim shiftStartInt As Integer = timeToMin(shiftStart)
                                    Dim shiftFinishInt As Integer = timeToMin(shiftFinish)
                                    Dim shiftDuration As Integer = shiftFinishInt - shiftStartInt

                                    'Add collected data to the record structure
                                    results.Add(New resultStructure With {
                                                .year = shiftYear,
                                                .week = shiftWeek,
                                                .day = shiftDay,
                                                .calDate = shiftCalDate,
                                                .timeStart = shiftStart,
                                                .timeFinish = shiftFinish,
                                                .timeStartInt = shiftStartInt,
                                                .timeFinishInt = shiftFinishInt,
                                                .duration = shiftDuration
                                                })

                                    resultCount += 1

                                End If

                            Next
                        Next
                    Next

                    'Display data in list box

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblJob.Text = "Displaying results:"
                    frmProgress.lblTask.Text = "Clearing list boxes"

                    lstShiftsWorked.Items.Clear()
                    lstDatesWorked.Items.Clear()

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblTask.Text = "Populating list boxes"

                    Dim index As Integer
                    For index = 0 To resultCount - 1

                        lstShiftsWorked.Items.Add(results(index).timeStart & " - " & results(index).timeFinish)
                        lstDatesWorked.Items.Add(results(index).calDate.ToString("dd/MM/yy ddd") & " (" & results(index).week & ")")

                    Next


                    'Display statistics
                    'Source: https://stackoverflow.com/questions/11118896/split-string-by-in-vb-net
                    'Source: https://stackoverflow.com/questions/1785403/vb-net-linq-query-getting-the-sum-of-all-values-for-a-specific-structure-member

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblJob.Text = "Displaying results:"
                    frmProgress.lblTask.Text = "Populating text boxes"

                    ''txtNameFirst.Text = searchItem.Split(CChar(" "))(0) & " " & searchItem.Split(CChar(" "))(1).Substring(0, 1)
                    txtName.Text = searchItem

                    Dim totalShifts As Integer = resultCount
                    Dim totalHours As Integer = CInt(Math.Round(results.Sum(Function(total) total.duration) / 60))

                    txtTotalShifts.Text = CStr(totalShifts)
                    txtTotalHours.Text = CStr(totalHours)

                    'Do not display times if employee has never started work
                    If totalHours = 0 Or totalShifts = 0 Then
                        txtEarliestTime.Text = "null"
                        txtLatestTime.Text = "null"
                    Else
                        txtEarliestTime.Text = minToTime(results.Min(Function(earliest) earliest.timeStartInt))
                        txtLatestTime.Text = minToTime(results.Max(Function(earliest) earliest.timeFinishInt))
                    End If

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblJob.Text = "Finishing up:"
                    frmProgress.lblTask.Text = "Enabling sorting and saving"

                    'Enable functions
                    btnSortResults.Enabled = True
                    btnSaveResults.Enabled = True

                    frmProgress.barProgress.PerformStep()
                    frmProgress.lblTask.Text = "Closing Excel workbook"

                    'Close file safely
                    xlWorkbook.Close(False)

                Catch ex As Exception
                    frmProgress.Close()
                MsgBox("Could not access existing roster archive file." & vbNewLine & "Error: " & ROSTERARCHIVE, MsgBoxStyle.Critical, "Error Loading Roster Archive")
                End Try

            End If

        End If

        frmProgress.barProgress.PerformStep()
        frmProgress.lblTask.Text = "Closing Excel application"

        'Close and release all objects
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkbook)
        releaseObject(xlWorksheet)

        frmProgress.Close()

    End Sub

    Private Sub btnSortResults_Click(sender As Object, e As EventArgs) Handles btnSortResults.Click
        'Sort results by shift start time (selection sort)

        'Declare variables
        Dim passNumber As Integer
        Dim smallestPos As Integer
        Dim position As Integer
        Dim temporary As resultStructure

        For passNumber = 0 To resultCount - 2 'Loop from beginning to last bit one element.

            'Find smallest element in unsorted range.
            smallestPos = passNumber 'Initialise smallest as leftmost unsorted element.

            'Loop through rest of unsorted range to find smallest
            For position = passNumber + 1 To resultCount - 1 'Loop from next unsorted to end.

                If results(position).timeStartInt < results(smallestPos).timeStartInt Then
                    smallestPos = position

                End If
            Next

            'If element as PassNumber isn’t smallest, move it to there (swap elements).
            If passNumber <> smallestPos Then

                temporary = results(smallestPos)
                results(smallestPos) = results(passNumber)
                results(passNumber) = temporary

            End If
            'At this point, List from 0 to PassNumber is sorted
        Next


        'Write sorted results to list boxes

        'Clear old order of results
        lstShiftsWorked.Items.Clear()
        lstDatesWorked.Items.Clear()

        Dim index As Integer
        For index = 0 To resultCount - 1

            lstShiftsWorked.Items.Add(results(index).timeStart & " - " & results(index).timeFinish)
            lstDatesWorked.Items.Add(results(index).calDate.ToString("dd/MM/yy ddd") & " (" & results(index).week & ")")

        Next


    End Sub

    Private Sub btnSaveResults_Click(sender As Object, e As EventArgs) Handles btnSaveResults.Click
        'Save search results (contents of comboboxes and textboxes) to a text file at a specified path.

        'Declare variables and show dialog
        Dim dlgResult As DialogResult = dlgSaveResults.ShowDialog()
        Dim filePath As String = dlgSaveResults.FileName
        Dim outputFile As StreamWriter

        If dlgResult = DialogResult.OK And filePath IsNot Nothing Then
            'If user has given a valid file path.

            Try

                outputFile = File.CreateText(filePath) 'Create/overwrite file for writing


                'Write data to file


                'Write statistics

                outputFile.WriteLine("Statistics for " & txtName.Text & " " & DateTime.Now.ToString("dd/MM/yy") & ":" & vbNewLine) 'Header
                outputFile.WriteLine("Total shifts:" & vbTab & vbTab & txtTotalShifts.Text)
                outputFile.WriteLine("Total hours:" & vbTab & vbTab & txtTotalHours.Text)
                outputFile.WriteLine("Earliest time:" & vbTab & vbTab & txtEarliestTime.Text)
                outputFile.WriteLine("Latest time:" & vbTab & vbTab & txtLatestTime.Text & vbNewLine)

                'Write shifts

                outputFile.WriteLine("Shift results for " & txtName.Text & " " & DateTime.Now.ToString("dd/MM/yy") & ":" & vbNewLine) 'Header

                Dim entry As Integer
                For entry = 0 To resultCount - 1 'Save each result found

                    outputFile.WriteLine(CStr(lstShiftsWorked.Items(entry)) & vbTab & CStr(lstDatesWorked.Items(entry)))

                Next

                outputFile.Close() 'Close file to maintain data integrity

                'Show success message
                MsgBox("Results successfully written to file." & vbNewLine & "File: " & filePath, MsgBoxStyle.Information, "Results Written to File")

            Catch ex As Exception
                'Show error message
                MsgBox("Error occurred in creating, opening or writing to the specified file. Results not written to file." & vbNewLine & vbNewLine & "Close any applications that may be using this file and try again.", MsgBoxStyle.Critical, "File Access Error")
            End Try

        ElseIf dlgResult <> DialogResult.Cancel Then
            'Show error message
            MsgBox("Bad file path selected. Results not written to file.", MsgBoxStyle.Critical, "File Path Error")
        End If


    End Sub

    Private Sub cmbEmployeeSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmployeeSearch.SelectedIndexChanged
        btnSearch.Enabled = True
    End Sub

    Private Sub btnOkSearch_Click(sender As Object, e As EventArgs) Handles btnOkSearch.Click
        'Close this form
        Me.Close()
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click
        MsgBox("To select an employee, use the drop-down box (above the 'Search Archive' button).", MsgBoxStyle.Information, "Not An Input")
    End Sub
End Class