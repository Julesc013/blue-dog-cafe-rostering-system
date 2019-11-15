<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogon))
        Me.lblTitleLogon = New System.Windows.Forms.Label()
        Me.cmbUserLogon = New System.Windows.Forms.ComboBox()
        Me.lblUserLogon = New System.Windows.Forms.Label()
        Me.lblPinLogon = New System.Windows.Forms.Label()
        Me.txtPinLogon = New System.Windows.Forms.TextBox()
        Me.lblAboutProgram = New System.Windows.Forms.Label()
        Me.btnLogon = New System.Windows.Forms.Button()
        Me.picLogoTwo = New System.Windows.Forms.PictureBox()
        Me.picLogoOne = New System.Windows.Forms.PictureBox()
        CType(Me.picLogoTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogoOne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitleLogon
        '
        Me.lblTitleLogon.Font = New System.Drawing.Font("Geometos", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitleLogon.Location = New System.Drawing.Point(138, 54)
        Me.lblTitleLogon.Name = "lblTitleLogon"
        Me.lblTitleLogon.Size = New System.Drawing.Size(434, 38)
        Me.lblTitleLogon.TabIndex = 6
        Me.lblTitleLogon.Text = "Roster Creation System"
        Me.lblTitleLogon.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbUserLogon
        '
        Me.cmbUserLogon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserLogon.FormattingEnabled = True
        Me.cmbUserLogon.Items.AddRange(New Object() {"Owner", "Chef/Manager"})
        Me.cmbUserLogon.Location = New System.Drawing.Point(301, 136)
        Me.cmbUserLogon.Name = "cmbUserLogon"
        Me.cmbUserLogon.Size = New System.Drawing.Size(218, 33)
        Me.cmbUserLogon.TabIndex = 0
        '
        'lblUserLogon
        '
        Me.lblUserLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserLogon.Location = New System.Drawing.Point(188, 139)
        Me.lblUserLogon.Name = "lblUserLogon"
        Me.lblUserLogon.Size = New System.Drawing.Size(107, 25)
        Me.lblUserLogon.TabIndex = 22
        Me.lblUserLogon.Text = "Log-on as:"
        Me.lblUserLogon.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPinLogon
        '
        Me.lblPinLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPinLogon.Location = New System.Drawing.Point(188, 178)
        Me.lblPinLogon.Name = "lblPinLogon"
        Me.lblPinLogon.Size = New System.Drawing.Size(107, 25)
        Me.lblPinLogon.TabIndex = 23
        Me.lblPinLogon.Text = "PIN:"
        Me.lblPinLogon.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPinLogon
        '
        Me.txtPinLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPinLogon.Location = New System.Drawing.Point(301, 175)
        Me.txtPinLogon.MaxLength = 4
        Me.txtPinLogon.Name = "txtPinLogon"
        Me.txtPinLogon.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPinLogon.Size = New System.Drawing.Size(218, 30)
        Me.txtPinLogon.TabIndex = 1
        '
        'lblAboutProgram
        '
        Me.lblAboutProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutProgram.Location = New System.Drawing.Point(193, 342)
        Me.lblAboutProgram.Name = "lblAboutProgram"
        Me.lblAboutProgram.Size = New System.Drawing.Size(326, 41)
        Me.lblAboutProgram.TabIndex = 25
        Me.lblAboutProgram.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnLogon
        '
        Me.btnLogon.Enabled = False
        Me.btnLogon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogon.Location = New System.Drawing.Point(193, 258)
        Me.btnLogon.Name = "btnLogon"
        Me.btnLogon.Size = New System.Drawing.Size(326, 37)
        Me.btnLogon.TabIndex = 3
        Me.btnLogon.Text = "Log-on"
        Me.btnLogon.UseVisualStyleBackColor = True
        '
        'picLogoTwo
        '
        Me.picLogoTwo.Image = Global.WindowsApp1.My.Resources.Resources.logo
        Me.picLogoTwo.Location = New System.Drawing.Point(578, 12)
        Me.picLogoTwo.Name = "picLogoTwo"
        Me.picLogoTwo.Size = New System.Drawing.Size(120, 120)
        Me.picLogoTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoTwo.TabIndex = 26
        Me.picLogoTwo.TabStop = False
        '
        'picLogoOne
        '
        Me.picLogoOne.Image = Global.WindowsApp1.My.Resources.Resources.logo
        Me.picLogoOne.Location = New System.Drawing.Point(12, 12)
        Me.picLogoOne.Name = "picLogoOne"
        Me.picLogoOne.Size = New System.Drawing.Size(120, 120)
        Me.picLogoOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoOne.TabIndex = 5
        Me.picLogoOne.TabStop = False
        '
        'frmLogon
        '
        Me.AcceptButton = Me.btnLogon
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 392)
        Me.Controls.Add(Me.btnLogon)
        Me.Controls.Add(Me.picLogoTwo)
        Me.Controls.Add(Me.lblAboutProgram)
        Me.Controls.Add(Me.txtPinLogon)
        Me.Controls.Add(Me.lblPinLogon)
        Me.Controls.Add(Me.lblUserLogon)
        Me.Controls.Add(Me.cmbUserLogon)
        Me.Controls.Add(Me.lblTitleLogon)
        Me.Controls.Add(Me.picLogoOne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLogon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rostering System Log-on"
        CType(Me.picLogoTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogoOne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitleLogon As Label
    Friend WithEvents picLogoOne As PictureBox
    Friend WithEvents cmbUserLogon As ComboBox
    Friend WithEvents lblUserLogon As Label
    Friend WithEvents lblPinLogon As Label
    Friend WithEvents txtPinLogon As TextBox
    Friend WithEvents lblAboutProgram As Label
    Friend WithEvents picLogoTwo As PictureBox
    Friend WithEvents btnLogon As Button
End Class
