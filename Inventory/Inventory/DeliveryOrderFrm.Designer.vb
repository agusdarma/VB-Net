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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeSupplier = New System.Windows.Forms.TextBox()
        Me.BtnSelectPo = New System.Windows.Forms.Button()
        Me.DateTimePickerShipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxReceiptNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxFormNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SavePrint = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.DataGridViewRI = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.alamatVendor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbVendor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxShipTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewRI, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'TextBoxNamaSupplier
        '
        Me.TextBoxNamaSupplier.Location = New System.Drawing.Point(224, 18)
        Me.TextBoxNamaSupplier.Name = "TextBoxNamaSupplier"
        Me.TextBoxNamaSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaSupplier.TabIndex = 98
        Me.TextBoxNamaSupplier.Visible = False
        '
        'TextBoxKodeSupplier
        '
        Me.TextBoxKodeSupplier.Location = New System.Drawing.Point(343, 19)
        Me.TextBoxKodeSupplier.Name = "TextBoxKodeSupplier"
        Me.TextBoxKodeSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeSupplier.TabIndex = 97
        Me.TextBoxKodeSupplier.Visible = False
        '
        'BtnSelectPo
        '
        Me.BtnSelectPo.BackColor = System.Drawing.Color.Blue
        Me.BtnSelectPo.ForeColor = System.Drawing.Color.White
        Me.BtnSelectPo.Location = New System.Drawing.Point(410, 60)
        Me.BtnSelectPo.Name = "BtnSelectPo"
        Me.BtnSelectPo.Size = New System.Drawing.Size(101, 31)
        Me.BtnSelectPo.TabIndex = 75
        Me.BtnSelectPo.Text = "Select SO"
        Me.BtnSelectPo.UseVisualStyleBackColor = False
        '
        'DateTimePickerShipDate
        '
        Me.DateTimePickerShipDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerShipDate.Location = New System.Drawing.Point(1030, 134)
        Me.DateTimePickerShipDate.Name = "DateTimePickerShipDate"
        Me.DateTimePickerShipDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerShipDate.TabIndex = 80
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
        'TextBoxReceiptNo
        '
        Me.TextBoxReceiptNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxReceiptNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxReceiptNo.Location = New System.Drawing.Point(1077, 83)
        Me.TextBoxReceiptNo.Name = "TextBoxReceiptNo"
        Me.TextBoxReceiptNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxReceiptNo.TabIndex = 73
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
        'TextBoxFormNo
        '
        Me.TextBoxFormNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxFormNo.Enabled = False
        Me.TextBoxFormNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFormNo.Location = New System.Drawing.Point(871, 83)
        Me.TextBoxFormNo.Name = "TextBoxFormNo"
        Me.TextBoxFormNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxFormNo.TabIndex = 76
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
        'DataGridViewRI
        '
        Me.DataGridViewRI.AllowUserToAddRows = False
        Me.DataGridViewRI.AllowUserToDeleteRows = False
        Me.DataGridViewRI.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewRI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewRI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewRI.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewRI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewRI.ColumnHeadersHeight = 30
        Me.DataGridViewRI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewRI.EnableHeadersVisualStyles = False
        Me.DataGridViewRI.Location = New System.Drawing.Point(17, 247)
        Me.DataGridViewRI.Name = "DataGridViewRI"
        Me.DataGridViewRI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRI.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewRI.RowHeadersVisible = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewRI.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewRI.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewRI.TabIndex = 77
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
        'alamatVendor
        '
        Me.alamatVendor.BackColor = System.Drawing.Color.LightGray
        Me.alamatVendor.Enabled = False
        Me.alamatVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alamatVendor.Location = New System.Drawing.Point(19, 111)
        Me.alamatVendor.Multiline = True
        Me.alamatVendor.Name = "alamatVendor"
        Me.alamatVendor.Size = New System.Drawing.Size(183, 111)
        Me.alamatVendor.TabIndex = 88
        Me.alamatVendor.TabStop = False
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
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbVendor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(16, 63)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(378, 25)
        Me.CmbVendor.TabIndex = 74
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
        Me.Controls.Add(Me.TextBoxNamaSupplier)
        Me.Controls.Add(Me.TextBoxKodeSupplier)
        Me.Controls.Add(Me.BtnSelectPo)
        Me.Controls.Add(Me.DateTimePickerShipDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxReceiptNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxFormNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SavePrint)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ButtonSaveClose)
        Me.Controls.Add(Me.ButtonSaveNew)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxNotes)
        Me.Controls.Add(Me.DataGridViewRI)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.alamatVendor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbVendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DeliveryOrderFrm"
        Me.Text = "Delivery Order"
        CType(Me.DataGridViewRI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelectPo As System.Windows.Forms.Button
    Friend WithEvents DateTimePickerShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFormNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SavePrint As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewRI As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents alamatVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxShipTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
