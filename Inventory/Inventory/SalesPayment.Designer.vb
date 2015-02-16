<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesPayment
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.DataGridViewSP = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.DateTimePickerPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxSPNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaCustomer = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeCustomer = New System.Windows.Forms.TextBox()
        Me.alamatCustomer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewSP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(900, 459)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 115
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(804, 459)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 114
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(697, 459)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 113
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 439)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Notes"
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(21, 459)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(376, 60)
        Me.TextBoxNotes.TabIndex = 110
        '
        'DataGridViewSP
        '
        Me.DataGridViewSP.AllowUserToAddRows = False
        Me.DataGridViewSP.AllowUserToDeleteRows = False
        Me.DataGridViewSP.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewSP.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewSP.ColumnHeadersHeight = 30
        Me.DataGridViewSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewSP.EnableHeadersVisualStyles = False
        Me.DataGridViewSP.Location = New System.Drawing.Point(21, 241)
        Me.DataGridViewSP.Name = "DataGridViewSP"
        Me.DataGridViewSP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSP.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewSP.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSP.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewSP.Size = New System.Drawing.Size(952, 195)
        Me.DataGridViewSP.TabIndex = 109
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Items"
        '
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(909, 16)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 108
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(828, 16)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 107
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'DateTimePickerPaymentDate
        '
        Me.DateTimePickerPaymentDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerPaymentDate.Location = New System.Drawing.Point(773, 139)
        Me.DateTimePickerPaymentDate.Name = "DateTimePickerPaymentDate"
        Me.DateTimePickerPaymentDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerPaymentDate.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(832, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 17)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Payment Date"
        '
        'TextBoxSPNo
        '
        Me.TextBoxSPNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxSPNo.Enabled = False
        Me.TextBoxSPNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSPNo.Location = New System.Drawing.Point(824, 88)
        Me.TextBoxSPNo.Name = "TextBoxSPNo"
        Me.TextBoxSPNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSPNo.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(844, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Form No"
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(464, 16)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 102
        Me.idPrimary.Visible = False
        '
        'TextBoxNamaCustomer
        '
        Me.TextBoxNamaCustomer.Location = New System.Drawing.Point(227, 15)
        Me.TextBoxNamaCustomer.Name = "TextBoxNamaCustomer"
        Me.TextBoxNamaCustomer.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaCustomer.TabIndex = 101
        Me.TextBoxNamaCustomer.Visible = False
        '
        'TextBoxKodeCustomer
        '
        Me.TextBoxKodeCustomer.Location = New System.Drawing.Point(346, 16)
        Me.TextBoxKodeCustomer.Name = "TextBoxKodeCustomer"
        Me.TextBoxKodeCustomer.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeCustomer.TabIndex = 100
        Me.TextBoxKodeCustomer.Visible = False
        '
        'alamatCustomer
        '
        Me.alamatCustomer.BackColor = System.Drawing.Color.LightGray
        Me.alamatCustomer.Enabled = False
        Me.alamatCustomer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alamatCustomer.Location = New System.Drawing.Point(22, 108)
        Me.alamatCustomer.Multiline = True
        Me.alamatCustomer.Name = "alamatCustomer"
        Me.alamatCustomer.Size = New System.Drawing.Size(183, 111)
        Me.alamatCustomer.TabIndex = 99
        Me.alamatCustomer.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Address"
        '
        'CmbCustomer
        '
        Me.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(19, 60)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(378, 25)
        Me.CmbCustomer.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Customer / Konsumen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 25)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Sales Payment (SP)"
        '
        'SalesPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 529)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ButtonSaveClose)
        Me.Controls.Add(Me.ButtonSaveNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxNotes)
        Me.Controls.Add(Me.DataGridViewSP)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.DateTimePickerPaymentDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxSPNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.TextBoxNamaCustomer)
        Me.Controls.Add(Me.TextBoxKodeCustomer)
        Me.Controls.Add(Me.alamatCustomer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbCustomer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SalesPayment"
        Me.Text = "Sales Payment"
        CType(Me.DataGridViewSP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewSP As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents DateTimePickerPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSPNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaCustomer As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeCustomer As System.Windows.Forms.TextBox
    Friend WithEvents alamatCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
