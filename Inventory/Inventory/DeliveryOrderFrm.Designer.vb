<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliveryOrderFrm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaCust = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeCust = New System.Windows.Forms.TextBox()
        Me.BtnSelectSO = New System.Windows.Forms.Button()
        Me.DateTimePickerDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxDeliveryNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxPONo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SavePrint = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.DataGridViewDO = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.textBoxBillTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbCust = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxShipTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewDO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(461, 19)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 99
        Me.idPrimary.Visible = False
        '
        'TextBoxNamaCust
        '
        Me.TextBoxNamaCust.Location = New System.Drawing.Point(224, 18)
        Me.TextBoxNamaCust.Name = "TextBoxNamaCust"
        Me.TextBoxNamaCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaCust.TabIndex = 98
        Me.TextBoxNamaCust.Visible = False
        '
        'TextBoxKodeCust
        '
        Me.TextBoxKodeCust.Location = New System.Drawing.Point(343, 19)
        Me.TextBoxKodeCust.Name = "TextBoxKodeCust"
        Me.TextBoxKodeCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeCust.TabIndex = 97
        Me.TextBoxKodeCust.Visible = False
        '
        'BtnSelectSO
        '
        Me.BtnSelectSO.BackColor = System.Drawing.Color.Blue
        Me.BtnSelectSO.ForeColor = System.Drawing.Color.White
        Me.BtnSelectSO.Location = New System.Drawing.Point(410, 60)
        Me.BtnSelectSO.Name = "BtnSelectSO"
        Me.BtnSelectSO.Size = New System.Drawing.Size(101, 31)
        Me.BtnSelectSO.TabIndex = 75
        Me.BtnSelectSO.Text = "Select SO"
        Me.BtnSelectSO.UseVisualStyleBackColor = False
        '
        'DateTimePickerDeliveryDate
        '
        Me.DateTimePickerDeliveryDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerDeliveryDate.Location = New System.Drawing.Point(1030, 134)
        Me.DateTimePickerDeliveryDate.Name = "DateTimePickerDeliveryDate"
        Me.DateTimePickerDeliveryDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerDeliveryDate.TabIndex = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1093, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 17)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Delivery Date"
        '
        'TextBoxDeliveryNo
        '
        Me.TextBoxDeliveryNo.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxDeliveryNo.Enabled = False
        Me.TextBoxDeliveryNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDeliveryNo.Location = New System.Drawing.Point(1077, 83)
        Me.TextBoxDeliveryNo.Name = "TextBoxDeliveryNo"
        Me.TextBoxDeliveryNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxDeliveryNo.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1090, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Delivery No"
        '
        'TextBoxPONo
        '
        Me.TextBoxPONo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPONo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPONo.Location = New System.Drawing.Point(871, 83)
        Me.TextBoxPONo.Name = "TextBoxPONo"
        Me.TextBoxPONo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPONo.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(891, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "PO No"
        '
        'SavePrint
        '
        Me.SavePrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrint.Location = New System.Drawing.Point(1043, 449)
        Me.SavePrint.Name = "SavePrint"
        Me.SavePrint.Size = New System.Drawing.Size(101, 31)
        Me.SavePrint.TabIndex = 83
        Me.SavePrint.Text = "Save n Print"
        Me.SavePrint.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(1150, 449)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 84
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(944, 449)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 82
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(837, 449)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 81
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Notes"
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(17, 420)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(375, 60)
        Me.TextBoxNotes.TabIndex = 78
        '
        'DataGridViewDO
        '
        Me.DataGridViewDO.AllowUserToAddRows = False
        Me.DataGridViewDO.AllowUserToDeleteRows = False
        Me.DataGridViewDO.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewDO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewDO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewDO.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewDO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewDO.ColumnHeadersHeight = 30
        Me.DataGridViewDO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewDO.EnableHeadersVisualStyles = False
        Me.DataGridViewDO.Location = New System.Drawing.Point(17, 247)
        Me.DataGridViewDO.Name = "DataGridViewDO"
        Me.DataGridViewDO.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDO.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewDO.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewDO.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewDO.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewDO.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Items"
        '
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(1154, 12)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 90
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(1073, 12)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 89
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'textBoxBillTo
        '
        Me.textBoxBillTo.BackColor = System.Drawing.Color.LightGray
        Me.textBoxBillTo.Enabled = False
        Me.textBoxBillTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBoxBillTo.Location = New System.Drawing.Point(19, 111)
        Me.textBoxBillTo.Multiline = True
        Me.textBoxBillTo.Name = "textBoxBillTo"
        Me.textBoxBillTo.Size = New System.Drawing.Size(183, 111)
        Me.textBoxBillTo.TabIndex = 88
        Me.textBoxBillTo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Bill To"
        '
        'CmbCust
        '
        Me.CmbCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCust.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCust.FormattingEnabled = True
        Me.CmbCust.Location = New System.Drawing.Point(16, 63)
        Me.CmbCust.Name = "CmbCust"
        Me.CmbCust.Size = New System.Drawing.Size(378, 25)
        Me.CmbCust.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Customer / Konsumen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 25)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Delivery Order (DO)"
        '
        'TextBoxShipTo
        '
        Me.TextBoxShipTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxShipTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxShipTo.Location = New System.Drawing.Point(211, 111)
        Me.TextBoxShipTo.Multiline = True
        Me.TextBoxShipTo.Name = "TextBoxShipTo"
        Me.TextBoxShipTo.Size = New System.Drawing.Size(183, 111)
        Me.TextBoxShipTo.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(208, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Ship To"
        '
        'DeliveryOrderFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 493)
        Me.Controls.Add(Me.TextBoxShipTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.TextBoxNamaCust)
        Me.Controls.Add(Me.TextBoxKodeCust)
        Me.Controls.Add(Me.BtnSelectSO)
        Me.Controls.Add(Me.DateTimePickerDeliveryDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxDeliveryNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxPONo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SavePrint)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ButtonSaveClose)
        Me.Controls.Add(Me.ButtonSaveNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxNotes)
        Me.Controls.Add(Me.DataGridViewDO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.textBoxBillTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbCust)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DeliveryOrderFrm"
        Me.Text = "Delivery Order"
        CType(Me.DataGridViewDO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaCust As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeCust As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelectSO As System.Windows.Forms.Button
    Friend WithEvents DateTimePickerDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDeliveryNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SavePrint As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewDO As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents textBoxBillTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxShipTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
