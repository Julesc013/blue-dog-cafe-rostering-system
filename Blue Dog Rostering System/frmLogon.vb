' Name:             Logon Dialogue
' Purpose:          Initial form; allows users to logon and shows version information.
' Author:           Jules Carboni
' Date Created:     15 May 2019
' Date Modified:    17 July 2019


Public Class frmLogon

    Private Sub frmLogon_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Display about information
        lblAboutProgram.Text = "Version " & VERSION & vbNewLine & "Jules Carboni, 2019"

        'Validation to ensure user knows their screen resolution is unexpected and the program may not by usable.
        'Get resolution
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        If screenHeight <> 1080 Or screenWidth <> 1920 Then 'If not expected resolution
            Dim resolutionError As String

            'Determine side-effects
            If screenHeight < 1080 Or screenWidth < 1920 Then
                resolutionError = "Your display is smaller. Some parts of the interface may not appear on screen and may be unusable."
            Else
                resolutionError = "Your display is larger. The usability of the program should not be affected."
            End If

            MsgBox("This program is designed to run on a 1920×1080 monitor." & vbNewLine & "It appears your monitor has a resolution of " & screenWidth & "×" & screenHeight & "." & vbNewLine & vbNewLine & resolutionError & vbNewLine & vbNewLine & "Use of this program will not cause harm to your system.", MsgBoxStyle.Exclamation, "Display Resolution Warning")
        End If

    End Sub

    Private Sub setNewPin(ByRef pinNew As String, ByVal userGroup As String)
        'Get new PIN from user via input boxes and validate.

        'Declare variables
        Dim pinRedo As String


        pinNew = InputBox("No PIN currently set." & vbNewLine & "Enter a new PIN for user group: " & userGroup, "Enter new PIN")


        While Not IsNumeric(pinNew) Or Len(pinNew) <> 4
            'while PIN is not numeric nor 4 digits

            pinNew = InputBox("No PIN currently set." & vbNewLine & "Enter a new PIN for user group: " & userGroup & vbNewLine & vbNewLine & "PIN must be numeric and 4 digits only.", "Enter new PIN")

        End While


        pinRedo = InputBox("No PIN currently set." & vbNewLine & "Re-enter the same PIN again to verify.", "Re-enter new PIN")


        While pinNew <> pinRedo
            'while new PINs dont match

            pinNew = InputBox("No PIN currently set." & vbNewLine & "Enter a new PIN for user group: " & userGroup & vbNewLine & vbNewLine & "PINs did not match.", "Enter new PIN")

            pinRedo = InputBox("No PIN currently set." & vbNewLine & "Re-enter the same PIN again to verify.", "Re-enter new PIN")

        End While


    End Sub

    Private Sub logon()
        'Show main form and hide this one.
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnLogon_Click(sender As Object, e As EventArgs) Handles btnLogon.Click
        'Validate to ensure PIN is correct before allowing logon

        'Get user-group and PIN
        userGroup = cmbUserLogon.Text
        Dim pinTry As String = txtPinLogon.Text
        Dim pinNew As String

        If userGroup = "Owner" Then

            If My.Settings.ownerEmail = "null" Or My.Settings.ownerPass = "null" Then
                'Get new email credentials from user via input boxes and validate.

                'Declare variables
                'Best regex for emails: (?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])
                Dim emailNew As String
                Dim passNew As String

                emailNew = InputBox("No email address currently set. An email address is required to send the rosters." & vbNewLine & "Enter a new email address.", "Enter New Email Address")

                While Not regexEmail.IsMatch(emailNew)
                    'while given email is not a valid email

                    emailNew = InputBox("No email address currently set. An email address is required to send the rosters." & vbNewLine & "Enter a new email address." & vbNewLine & vbNewLine & "Must be in the format: address@provider.com/.net/etc...", "Enter Email Address")

                End While

                passNew = InputBox("No email password currently set." & vbNewLine & "Enter the password for the email address entered prior.", "Enter Email Password")

                'Store the data in the settings
                My.Settings.ownerEmail = emailNew
                My.Settings.ownerPass = passNew

                'Show success message
                MsgBox("Successfully stored email address and password in settings." & vbNewLine & "Please attempt to log-on again (you will be prompted to enter a new PIN for your user account).", MsgBoxStyle.Information, "Email Entry Successful")

            Else

                If My.Settings.pinOwner = "null" Then 'If no PIN is set, create a new PIN

                    setNewPin(pinNew, userGroup) 'Call routine to get PIN from user

                    My.Settings.pinOwner = pinNew 'Save/set new PIN to user-group setting

                    logon()

                ElseIf pinTry = My.Settings.pinOwner Then 'If PIN exists and is a match, logon
                    logon()

                Else 'If PIN doesnt match, show error
                    MsgBox("PIN incorrect—does not match." & vbNewLine & "Must be four digits long and contain only numbers.", MsgBoxStyle.Exclamation, "PIN Incorrect.")
                End If

            End If

        ElseIf userGroup = "Chef/Manager" Then

            If My.Settings.ownerEmail = "null" Or My.Settings.ownerPass = "null" Then

                'If owner has not entered the email credentials, prevent use of the program.
                MsgBox("No email credentials are currently set." & vbNewLine & "The owner must enter a valid email address and password before the program can be used." & vbNewLine & "Please log-on as Owner first.", MsgBoxStyle.Exclamation, "No Email Credentials.")

            Else

                If My.Settings.pinChefManager = "null" Then 'If no PIN is set, create a new PIN

                    setNewPin(pinNew, userGroup) 'Call routine to get PIN from user

                    My.Settings.pinChefManager = pinNew 'Save/set new PIN to user-group setting

                    logon()

                ElseIf pinTry = My.Settings.pinChefManager Then 'If PIN exists and is a match, logon
                    logon()

                Else 'If PIN doesnt match, show error
                    MsgBox("PIN incorrect—does not match." & vbNewLine & "Must be four digits long and contain only numbers.", MsgBoxStyle.Exclamation, "PIN Incorrect.")
                End If

            End If

        End If

    End Sub

    Private Sub picLogoTwo_Click(sender As Object, e As EventArgs) Handles picLogoTwo.Click
        aboutProgram()
    End Sub

    Private Sub picLogoOne_Click(sender As Object, e As EventArgs) Handles picLogoOne.Click
        aboutProgram()
    End Sub

    Private Sub cmbUserLogon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserLogon.SelectedIndexChanged
        'Enable ability to log on once a user is selected
        btnLogon.Enabled = True
    End Sub

    Private Sub lblAboutProgram_Click(sender As Object, e As EventArgs) Handles lblAboutProgram.Click
        aboutProgram()
    End Sub
End Class