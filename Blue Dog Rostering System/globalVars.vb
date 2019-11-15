' Name:             Global Variables and Subroutines
' Purpose:          Stores all the global varibales and subroutines used in multiple forms throughout the program.
' Author:           Jules Carboni
' Date Created:     29 May 2019
' Date Modified:    21 July 2019

Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions

Module globalVars

    'Decalare global variables

    Public Const VERSION As String = "1.5"
    Public Const VERSIONDATE As String = "6 August 2019"
    Public Const MASTERPASS As String = "UiNdY9yIwt7F" 'Key used to encrypt data files


    'File paths (cannot be define as literal constants, so defined as readonly)
    Public ReadOnly FILEPATH As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Roster_System"
    Public ReadOnly DATAPATH As String = FILEPATH & "\Data"

    'Paths to files that store user data used in program
    Public ReadOnly EMPLOYEEFILE As String = DATAPATH & "\Employees.xlsx"
    Public ReadOnly AVAILABILITYFILE As String = DATAPATH & "\Availability.xlsx"
    Public ReadOnly SHIFTFILE As String = DATAPATH & "\Shifts.xlsx"

    'Paths to output rosters created by the program
    Public ReadOnly ROSTERARCHIVE As String = FILEPATH & "\Roster_Archive.xlsx"
    Public ReadOnly ROSTERLATEST As String = FILEPATH & "\Roster_Latest.pdf" 'Exported roster to send
    Public ReadOnly ROSTERSUGGESTED As String = FILEPATH & "\Roster_Suggested.xlsx" 'Roster suggested by chef/managers

    'Get year and week numbers for use in program control
    'Source: https://stackoverflow.com/questions/5560019/vb-net-get-only-year-from-date
    'Source: https://stackoverflow.com/questions/12712300/get-the-week-number-of-the-year-counting-from-a-given-date-in-vb
    'Changes: Subtracted 2019 from current year to get index-based year

    Public ReadOnly YEARNUMBER As Integer = Date.Today.Year - 2019 'Index of years elapsed since 2019 (0-indexed)
    Public ReadOnly WEEKNUMBER As Integer = (DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(DateTime.Now, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DayOfWeek.Thursday) - 1) 'Number of current week (starting with first Thursday of the year) (1-indexed)

    Public ReadOnly WEEKSTART As Date = calendarDate(Date.Today.Year, WEEKNUMBER, 1)

    Public ReadOnly ROSTERNAME As String = "Y" & YEARNUMBER.ToString("D2") & "_W" & WEEKNUMBER.ToString("D2") 'Roster for this week
    Public ReadOnly ROSTERNAMELAST As String = "Y" & YEARNUMBER.ToString("D2") & "_W" & (WEEKNUMBER - 1).ToString("D2") 'Roster for last week


    'Record structures to store user data
    Public Const MAXEMPLOYEE As Integer = 40
    Public Const MAXSHIFT As Integer = 20

    Public employeeCount As Integer = 0
    Public shiftCount As Integer = 0

    Public Structure employeeDataStructure

        Public nameFirst As String
        Public nameLast As String
        Public nameFull As String
        Public phoneNumber As String
        Public emailAddress As String
        Public canClose As Boolean
        Public availabilityStored As Boolean
        Public colourCode As Color
        'Public availability() As availabilityStructure 'For each day of the week

        ''Public timeStart() As Integer
        ''Public timeFinish() As Integer

    End Structure

    Public Structure availabilityStructure
        Public timeStart As Integer
        Public timeFinish As Integer
    End Structure

    Public Structure shiftDataStrcuture
        Public timeStart As Integer
        Public timeFinish As Integer
    End Structure

    Public employeeData As New List(Of employeeDataStructure)
    Public employeeAvailability As New List(Of availabilityStructure) 'Each employee has 7 days to populate
    Public shiftData As New List(Of shiftDataStrcuture)

    Public employeeNames(0) As String 'Redim later


    'Regular expressions
    'Source: https://stackoverflow.com/questions/369543/validating-e-mail-with-regular-expression-vb-net
    Public regexEmail As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
    Public regexName As New Regex("^[A-Za-z]+$")

    Public panelList() As Panel = frmMain.pnlRoster.Controls.OfType(Of Panel)().OrderBy(Function(o) o.Name).ToArray() 'list of each day of the week

    Public userGroup As String


    'Internal variables to control program functionality

    Public rosterSentNow As Boolean = False 'Has roster been sent in this program session
    Public rosterSentWeek As Boolean 'Has roster been sent in the last week (assigned in mainReload)

    Public rosterLastSentWeek As Integer = DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(My.Settings.rosterLastSent, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DayOfWeek.Thursday)

    Public rosterSuggestedExists As Boolean = File.Exists(ROSTERSUGGESTED)


    'Declare global subroutines

    Sub aboutProgram()
        MsgBox("Blue Dog Cafe Rostering System" & vbNewLine & "Version " & VERSION & " (" & VERSIONDATE & ")" & vbNewLine & "Jules Carboni, 2019" & vbNewLine & vbNewLine & "Program data and rosters (including archive) saved in:" & vbNewLine & FILEPATH & vbNewLine & vbNewLine & "Program settings saved in:" & vbNewLine & My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, MsgBoxStyle.Information, "About Rostering System")
    End Sub

    Sub releaseObject(ByVal obj As Object)
        'Post-close clean-up of excel objects
        'Source: http://vb.net-informations.com/excel-2007/vb.net_excel_2007_create_file.htm
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Sub comboPopulate()
        'Populate combination boxes wiht employee and shift data
        'Source: https://stackoverflow.com/questions/30604633/loop-through-textboxes-in-vb-net

        For Each panelDay As Panel In frmMain.pnlRoster.Controls.OfType(Of Panel)() 'For each panel/day in the roster
            For Each comboBox As ComboBox In panelDay.Controls.OfType(Of ComboBox)() 'For each staff slot

                If comboBox.Name.Contains("Staff") Then 'Ignore non-staff/shift comboboxes

                    comboBox.Items.Clear() 'Clear existing items

                    comboBox.Items.Add("") 'Empty selection for 'no staff member'

                    Dim index As Integer
                    For index = 0 To employeeCount - 1
                        comboBox.Items.Add(employeeData(index).nameFull)
                    Next

                Else

                    comboBox.Enabled = False 'Disable all non-staff/shift comboboxes

                End If

            Next
        Next

    End Sub

    Sub mainReload()

        'Included in frmMain_Load subroutine

        'Show/hide user-group-specific objects and functions
        '(Default values have been set in the object properties)

        'Check if roster has been sent within the week
        If WEEKNUMBER = rosterLastSentWeek Then
            rosterSentWeek = True
        Else
            rosterSentWeek = False
        End If

        If rosterSuggestedExists = True Then
            'Allow loading suggested roster only if it exists
            frmMain.btnLoadSuggested.Enabled = True
        End If

        If userGroup = "Chef/Manager" Then
            frmMain.btnSuggestRoster.Visible = True

            frmMain.btnEditData.Visible = False
            frmMain.btnEditShifts.Visible = False
            frmMain.btnSearchArchive.Visible = False

            If rosterSentWeek = False Then
                frmMain.btnSendRoster.Enabled = False
            End If
        End If

        'Create a list of all employee names for finding their index.
        ReDim employeeNames(employeeData.Count - 1)
        Array.Clear(employeeNames, 0, employeeNames.Length) 'Clear entire array

        Dim person As Integer
        For person = 0 To employeeData.Count - 1
            'Populate array
            employeeNames(person) = employeeData(person).nameFull
        Next

        comboPopulate() 'Populate comboboxes

    End Sub

    Function getLetter(columnNumber As Integer) As String
        'Convert integer to letter of the alphabet
        'Source: https://stackoverflow.com/questions/31974538/converting-numbers-to-excel-letter-column-vb-net
        'Modifications: None, it's perfect.
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function

    Function timeToMin(ByVal input As String) As Integer
        'Converts a formatted timestamp to a value of minutes-since-midnight
        'input in format "HH:mm MM"

        Dim minutes As Integer = -1 'Initialise to default "-1"

        If input.Substring(0, 5).ToLower = "close" Then 'Substring to ignore padding added for display boxes
            'If string is "close", it should be handled as 12am (1440).
            Return 1440

        Else

            'Cannot type cast the ":" to integer, so we must exclude it from the strings
            Dim offset As Integer
            If input.Substring(2, 1) = ":" Then
                'For 10 to 12 o'clock...
                offset = 1
            Else
                'For 1 to 9 o'clock...
                offset = 0
            End If

            minutes = CInt(input.Substring(0, 1 + offset)) * 60 + CInt(input.Substring(2 + offset, 2))

            If input.Substring(5 + offset, 2) = "pm" And input.Substring(0, 2) <> "12" Then
                minutes += 12 * 60 'If time is after 12pm, add 12 hours
            ElseIf input.Substring(5 + offset, 2) = "am" And input.Substring(0, 2) = "12" Then
                minutes -= 12 * 60 'If time is 12am, hours = 0
            End If

            Return minutes

        End If

    End Function

    Function minToTime(ByVal input As Integer) As String
        'Converts value of minutes-since-midnight to a formatted timestamp
        'input normally less than 1440 

        If input < 0 Then
            Throw New Exception("Input cannot be negative.")
        Else

            Dim hours As Integer
            Dim minutes As Integer
            Dim meridiem As String

            hours = CInt(Math.Floor(input / 60))
            minutes = CInt(input Mod 60)

            If hours < 12 Then
                meridiem = "am"
                If hours = 0 Then
                    hours = 12
                End If
            ElseIf hours < 24 Then
                meridiem = "pm"
                If hours > 12 Then
                    hours -= 12
                End If
            Else
                Return "Close" 'midnight or beyond is treated as a "late close"
            End If

            Dim tempRet As String = hours.ToString & ":" & minutes.ToString("D2") & " " & meridiem
            Return tempRet

        End If

    End Function

    Function calendarDate(ByVal year As Integer, ByVal week As Integer, ByVal day As Integer) As Date
        'Convert week and day to calendar date
        'Source: https://stackoverflow.com/questions/20084890/how-to-get-starting-date-in-a-week-based-on-week-number-using-vb-net
        'Modifications: Hard-coded Thursday as first day of the week, and added ability to set day within week.

        Dim calDate As Date = New Date(year, 1, 1)

        'Set calDate to be the Monday of the first week of that year
        If calDate.DayOfWeek > 4 Then
            calDate = calDate.AddDays(7 - calDate.DayOfWeek)
        Else
            calDate = calDate.AddDays(-calDate.DayOfWeek)
        End If

        calDate = calDate.AddDays(DayOfWeek.Thursday) 'Offset for first day of the week
        calDate = calDate.AddDays(7 * (week - 1)) 'Count to week
        calDate = calDate.AddDays(day - 1) 'Count to day within week

        Return calDate

    End Function


End Module
