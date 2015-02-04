<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseInvoice
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaSupplier = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeSupplier = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckInclusiveTax = New System.Windows.Forms.CheckBox()
        Me.CheckVendorTaxable = New System.Windows.Forms.CheckBox()
        Me.CmbVendor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.alamatVendor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePickerShipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickerInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxFormNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridViewPI = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.SavePrint = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxPctDiskon = New System.Windows.Forms.TextBox()
        Me.TextBoxPPn = New System.Windows.Forms.TextBox()
        Me.TextBoxTotalOrder = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblPPnRp = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxSubTotal = New System.Windows.Forms.TextBox()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.lblPPN = New System.Windows.Forms.Label()
        Me.TextBoxValueDiskon = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.ComboBoxSelectType = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridViewPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(476, 18)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 51
        Me.idPrimary.Visible = False
        '
        'TextBoxNamaSupplier
        '
        Me.TextBoxNamaSupplier.Location = New System.Drawing.Point(239, 17)
        Me.TextBoxNamaSupplier.Name = "TextBoxNamaSupplier"
        Me.TextBoxNamaSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaSupplier.TabIndex = 50
        Me.TextBoxNamaSupplier.Visible = False
        '
        'TextBoxKodeSupplier
        '
        Me.TextBoxKodeSupplier.Location = New System.Drawing.Point(358, 18)
        Me.TextBoxKodeSupplier.Name = "TextBoxKodeSupplier"
        Me.TextBoxKodeSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeSupplier.TabIndex = 49
        Me.TextBoxKodeSupplier.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 25)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Purchase Invoice (PI)"
        '
        'CheckInclusiveTax
        '
        Me.CheckInclusiveTax.AutoSize = True
        Me.CheckInclusiveTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckInclusiveTax.Location = New System.Drawing.Point(672, 53)
        Me.CheckInclusiveTax.Name = "CheckInclusiveTax"
        Me.CheckInclusiveTax.Size = New System.Drawing.Size(99, 21)
        Me.CheckInclusiveTax.TabIndex = 7
        Me.CheckInclusiveTax.Text = "Inclusive Tax"
        Me.CheckInclusiveTax.UseVisualStyleBackColor = True
        '
        'CheckVendorTaxable
        '
        Me.CheckVendorTaxable.AutoSize = True
        Me.CheckVendorTaxable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckVendorTaxable.Location = New System.Drawing.Point(534, 54)
        Me.CheckVendorTaxable.Name = "CheckVendorTaxable"
        Me.CheckVendorTaxable.Size = New System.Drawing.Size(132, 21)
        Me.CheckVendorTaxable.TabIndex = 6
        Me.CheckVendorTaxable.Text = "Vendor is Taxable"
        Me.CheckVendorTaxable.UseVisualStyleBackColor = True
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbVendor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(15, 54)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(378, 25)
        Me.CmbVendor.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Supplier / Vendor"
        '
        'alamatVendor
        '
        Me.alamatVendor.BackColor = System.Drawing.Color.LightGray
        Me.alamatVendor.Enabled = False
        Me.alamatVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alamatVendor.Location = New System.Drawing.Point(17, 102)
        Me.alamatVendor.Multiline = True
        Me.alamatVendor.Name = "alamatVendor"
        Me.alamatVendor.Size = New System.Drawing.Size(183, 111)
        Me.alamatVendor.TabIndex = 57
        Me.alamatVendor.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Address"
        '
        'DateTimePickerShipDate
        '
        Me.DateTimePickerShipDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerShipDate.Location = New System.Drawing.Point(1021, 126)
        Me.DateTimePickerShipDate.Name = "DateTimePickerShipDate"
        Me.DateTimePickerShipDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerShipDate.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1084, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Ship Date"
        '
        'DateTimePickerInvoiceDate
        '
        Me.DateTimePickerInvoiceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerInvoiceDate.Location = New System.Drawing.Point(811, 126)
        Me.DateTimePickerInvoiceDate.Name = "DateTimePickerInvoiceDate"
        Me.DateTimePickerInvoiceDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerInvoiceDate.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(870, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Invoice Date"
        '
        'TextBoxInvoiceNo
        '
        Me.TextBoxInvoiceNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxInvoiceNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxInvoiceNo.Location = New System.Drawing.Point(1068, 75)
        Me.TextBoxInvoiceNo.Name = "TextBoxInvoiceNo"
        Me.TextBoxInvoiceNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxInvoiceNo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1081, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Invoice No"
        '
        'TextBoxFormNo
        '
        Me.TextBoxFormNo.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxFormNo.Enabled = False
        Me.TextBoxFormNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFormNo.Location = New System.Drawing.Point(862, 75)
        Me.TextBoxFormNo.Name = "TextBoxFormNo"
        Me.TextBoxFormNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxFormNo.TabIndex = 71
        Me.TextBoxFormNo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(882, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Form No"
        '
        'DataGridViewPI
        '
        Me.DataGridViewPI.AllowUserToAddRows = False
        Me.DataGridViewPI.AllowUserToDeleteRows = False
        Me.DataGridViewPI.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewPI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewPI.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewPI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewPI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewPI.ColumnHeadersHeight = 30
        Me.DataGridViewPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewPI.Enabled = False
        Me.DataGridViewPI.EnableHeadersVisualStyles = False
        Me.DataGridViewPI.Location = New System.Drawing.Point(13, 237)
        Me.DataGridViewPI.Name = "DataGridViewPI"
        Me.DataGridViewPI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewPI.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewPI.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewPI.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewPI.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewPI.TabIndex = 8
        Me.DataGridViewPI.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Items"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 390)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Notes"
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(17, 410)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(375, 60)
        Me.TextBoxNotes.TabIndex = 9
        '
        'SavePrint
        '
        Me.SavePrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrint.Location = New System.Drawing.Point(1046, 545)
        Me.SavePrint.Name = "SavePrint"
        Me.SavePrint.Size = New System.Drawing.Size(101, 31)
        Me.SavePrint.TabIndex = 14
        Me.SavePrint.Text = "Save n Print"
        Me.SavePrint.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(1153, 545)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(947, 545)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 13
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(840, 545)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 12
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(977, 427)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 17)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "%"
        '
        'TextBoxPctDiskon
        '
        Me.TextBoxPctDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPctDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPctDiskon.Location = New System.Drawing.Point(936, 423)
        Me.TextBoxPctDiskon.Name = "TextBoxPctDiskon"
        Me.TextBoxPctDiskon.Size = New System.Drawing.Size(35, 25)
        Me.TextBoxPctDiskon.TabIndex = 10
        Me.TextBoxPctDiskon.Text = "0"
        Me.TextBoxPctDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPPn
        '
        Me.TextBoxPPn.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxPPn.Enabled = False
        Me.TextBoxPPn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPPn.Location = New System.Drawing.Point(1034, 451)
        Me.TextBoxPPn.Name = "TextBoxPPn"
        Me.TextBoxPPn.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPPn.TabIndex = 98
        Me.TextBoxPPn.TabStop = False
        Me.TextBoxPPn.Text = "0"
        Me.TextBoxPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxTotalOrder
        '
        Me.TextBoxTotalOrder.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxTotalOrder.Enabled = False
        Me.TextBoxTotalOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalOrder.Location = New System.Drawing.Point(1034, 512)
        Me.TextBoxTotalOrder.Name = "TextBoxTotalOrder"
        Me.TextBoxTotalOrder.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxTotalOrder.TabIndex = 97
        Me.TextBoxTotalOrder.TabStop = False
        Me.TextBoxTotalOrder.Text = "0"
        Me.TextBoxTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1003, 515)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 17)
        Me.Label17.TabIndex = 96
        Me.Label17.Text = "Rp"
        '
        'LblPPnRp
        '
        Me.LblPPnRp.AutoSize = True
        Me.LblPPnRp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPnRp.Location = New System.Drawing.Point(1003, 452)
        Me.LblPPnRp.Name = "LblPPnRp"
        Me.LblPPnRp.Size = New System.Drawing.Size(24, 17)
        Me.LblPPnRp.TabIndex = 95
        Me.LblPPnRp.Text = "Rp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1003, 427)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 17)
        Me.Label15.TabIndex = 94
        Me.Label15.Text = "Rp"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1003, 396)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 17)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Rp"
        '
        'TextBoxSubTotal
        '
        Me.TextBoxSubTotal.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxSubTotal.Enabled = False
        Me.TextBoxSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubTotal.Location = New System.Drawing.Point(1033, 393)
        Me.TextBoxSubTotal.Name = "TextBoxSubTotal"
        Me.TextBoxSubTotal.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSubTotal.TabIndex = 92
        Me.TextBoxSubTotal.TabStop = False
        Me.TextBoxSubTotal.Text = "0"
        Me.TextBoxSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTax.Location = New System.Drawing.Point(1140, 516)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(81, 17)
        Me.lblTax.TabIndex = 91
        Me.lblTax.Text = "Tax included"
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(881, 453)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(68, 17)
        Me.lblPPN.TabIndex = 90
        Me.lblPPN.Text = "PPN 10% :"
        '
        'TextBoxValueDiskon
        '
        Me.TextBoxValueDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxValueDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxValueDiskon.Location = New System.Drawing.Point(1034, 423)
        Me.TextBoxValueDiskon.Name = "TextBoxValueDiskon"
        Me.TextBoxValueDiskon.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxValueDiskon.TabIndex = 11
        Me.TextBoxValueDiskon.Text = "0"
        Me.TextBoxValueDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(881, 515)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Total Order :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(881, 425)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 17)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Diskon :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(881, 394)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Sub Total :"
        '
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(1150, 9)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 102
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(1069, 9)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 101
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'ComboBoxSelectType
        '
        Me.ComboBoxSelectType.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxSelectType.DropDownHeight = 125
        Me.ComboBoxSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSelectType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxSelectType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSelectType.FormattingEnabled = True
        Me.ComboBoxSelectType.IntegralHeight = False
        Me.ComboBoxSelectType.Location = New System.Drawing.Point(400, 53)
        Me.ComboBoxSelectType.Name = "ComboBoxSelectType"
        Me.ComboBoxSelectType.Size = New System.Drawing.Size(121, 25)
        Me.ComboBoxSelectType.TabIndex = 5
        '
        'PurchaseInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 583)
        Me.Controls.Add(Me.ComboBoxSelectType)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.SavePrint)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ButtonSaveClose)
        Me.Controls.Add(Me.ButtonSaveNew)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBoxPctDiskon)
        Me.Controls.Add(Me.TextBoxPPn)
        Me.Controls.Add(Me.TextBoxTotalOrder)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LblPPnRp)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBoxSubTotal)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.lblPPN)
        Me.Controls.Add(Me.TextBoxValueDiskon)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxNotes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridViewPI)
        Me.Controls.Add(Me.DateTimePickerShipDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePickerInvoiceDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxInvoiceNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxFormNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.alamatVendor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CheckInclusiveTax)
        Me.Controls.Add(Me.CheckVendorTaxable)
        Me.Controls.Add(Me.CmbVendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.TextBoxNamaSupplier)
        Me.Controls.Add(Me.TextBoxKodeSupplier)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PurchaseInvoice"
        Me.Text = "Purchase Invoice"
        CType(Me.DataGridViewPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckInclusiveTax As System.Windows.Forms.CheckBox
    Friend WithEvents CheckVendorTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents alamatVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFormNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewPI As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents SavePrint As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPctDiskon As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPPn As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotalOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LblPPnRp As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents lblPPN As System.Windows.Forms.Label
    Friend WithEvents TextBoxValueDiskon As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents ComboBoxSelectType As System.Windows.Forms.ComboBox
End Class
