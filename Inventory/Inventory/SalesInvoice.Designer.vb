<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesInvoice
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
        Me.ComboBoxSelectType = New System.Windows.Forms.ComboBox()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridViewSI = New System.Windows.Forms.DataGridView()
        Me.DateTimePickerShipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickerSalesInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxFormNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxSalesInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textBoxBillTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckInclusiveTax = New System.Windows.Forms.CheckBox()
        Me.CheckCustTaxable = New System.Windows.Forms.CheckBox()
        Me.CmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaCust = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeCust = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewSI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ComboBoxSelectType.Location = New System.Drawing.Point(399, 52)
        Me.ComboBoxSelectType.Name = "ComboBoxSelectType"
        Me.ComboBoxSelectType.Size = New System.Drawing.Size(121, 25)
        Me.ComboBoxSelectType.TabIndex = 107
        '
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(1149, 8)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 146
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(1068, 8)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 145
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'SavePrint
        '
        Me.SavePrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrint.Location = New System.Drawing.Point(1045, 544)
        Me.SavePrint.Name = "SavePrint"
        Me.SavePrint.Size = New System.Drawing.Size(101, 31)
        Me.SavePrint.TabIndex = 116
        Me.SavePrint.Text = "Save n Print"
        Me.SavePrint.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(1152, 544)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 117
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(946, 544)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 115
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(839, 544)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 114
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(976, 426)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 17)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "%"
        '
        'TextBoxPctDiskon
        '
        Me.TextBoxPctDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPctDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPctDiskon.Location = New System.Drawing.Point(935, 422)
        Me.TextBoxPctDiskon.Name = "TextBoxPctDiskon"
        Me.TextBoxPctDiskon.Size = New System.Drawing.Size(35, 25)
        Me.TextBoxPctDiskon.TabIndex = 112
        Me.TextBoxPctDiskon.Text = "0"
        Me.TextBoxPctDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPPn
        '
        Me.TextBoxPPn.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxPPn.Enabled = False
        Me.TextBoxPPn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPPn.Location = New System.Drawing.Point(1033, 450)
        Me.TextBoxPPn.Name = "TextBoxPPn"
        Me.TextBoxPPn.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPPn.TabIndex = 143
        Me.TextBoxPPn.TabStop = False
        Me.TextBoxPPn.Text = "0"
        Me.TextBoxPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxTotalOrder
        '
        Me.TextBoxTotalOrder.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxTotalOrder.Enabled = False
        Me.TextBoxTotalOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalOrder.Location = New System.Drawing.Point(1033, 511)
        Me.TextBoxTotalOrder.Name = "TextBoxTotalOrder"
        Me.TextBoxTotalOrder.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxTotalOrder.TabIndex = 142
        Me.TextBoxTotalOrder.TabStop = False
        Me.TextBoxTotalOrder.Text = "0"
        Me.TextBoxTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1002, 514)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 17)
        Me.Label17.TabIndex = 141
        Me.Label17.Text = "Rp"
        '
        'LblPPnRp
        '
        Me.LblPPnRp.AutoSize = True
        Me.LblPPnRp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPnRp.Location = New System.Drawing.Point(1002, 451)
        Me.LblPPnRp.Name = "LblPPnRp"
        Me.LblPPnRp.Size = New System.Drawing.Size(24, 17)
        Me.LblPPnRp.TabIndex = 140
        Me.LblPPnRp.Text = "Rp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1002, 426)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 17)
        Me.Label15.TabIndex = 139
        Me.Label15.Text = "Rp"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1002, 395)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 17)
        Me.Label13.TabIndex = 138
        Me.Label13.Text = "Rp"
        '
        'TextBoxSubTotal
        '
        Me.TextBoxSubTotal.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxSubTotal.Enabled = False
        Me.TextBoxSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubTotal.Location = New System.Drawing.Point(1032, 392)
        Me.TextBoxSubTotal.Name = "TextBoxSubTotal"
        Me.TextBoxSubTotal.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSubTotal.TabIndex = 137
        Me.TextBoxSubTotal.TabStop = False
        Me.TextBoxSubTotal.Text = "0"
        Me.TextBoxSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTax.Location = New System.Drawing.Point(1139, 515)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(81, 17)
        Me.lblTax.TabIndex = 136
        Me.lblTax.Text = "Tax included"
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(880, 452)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(68, 17)
        Me.lblPPN.TabIndex = 135
        Me.lblPPN.Text = "PPN 10% :"
        '
        'TextBoxValueDiskon
        '
        Me.TextBoxValueDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxValueDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxValueDiskon.Location = New System.Drawing.Point(1033, 422)
        Me.TextBoxValueDiskon.Name = "TextBoxValueDiskon"
        Me.TextBoxValueDiskon.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxValueDiskon.TabIndex = 113
        Me.TextBoxValueDiskon.Text = "0"
        Me.TextBoxValueDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(880, 514)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Total Order :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(880, 424)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 17)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Diskon :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(880, 393)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Sub Total :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 389)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Notes"
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(16, 409)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(375, 60)
        Me.TextBoxNotes.TabIndex = 111
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 130
        Me.Label7.Text = "Items"
        '
        'DataGridViewSI
        '
        Me.DataGridViewSI.AllowUserToAddRows = False
        Me.DataGridViewSI.AllowUserToDeleteRows = False
        Me.DataGridViewSI.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewSI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewSI.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewSI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewSI.ColumnHeadersHeight = 30
        Me.DataGridViewSI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewSI.Enabled = False
        Me.DataGridViewSI.EnableHeadersVisualStyles = False
        Me.DataGridViewSI.Location = New System.Drawing.Point(12, 236)
        Me.DataGridViewSI.Name = "DataGridViewSI"
        Me.DataGridViewSI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSI.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewSI.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSI.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewSI.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewSI.TabIndex = 110
        Me.DataGridViewSI.TabStop = False
        '
        'DateTimePickerShipDate
        '
        Me.DateTimePickerShipDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerShipDate.Location = New System.Drawing.Point(1020, 125)
        Me.DateTimePickerShipDate.Name = "DateTimePickerShipDate"
        Me.DateTimePickerShipDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerShipDate.TabIndex = 105
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1083, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Ship Date"
        '
        'DateTimePickerSalesInvoiceDate
        '
        Me.DateTimePickerSalesInvoiceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerSalesInvoiceDate.Location = New System.Drawing.Point(810, 125)
        Me.DateTimePickerSalesInvoiceDate.Name = "DateTimePickerSalesInvoiceDate"
        Me.DateTimePickerSalesInvoiceDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerSalesInvoiceDate.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(856, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 17)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Sales Invoice Date"
        '
        'TextBoxFormNo
        '
        Me.TextBoxFormNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxFormNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFormNo.Location = New System.Drawing.Point(1067, 74)
        Me.TextBoxFormNo.Name = "TextBoxFormNo"
        Me.TextBoxFormNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxFormNo.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1080, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 17)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Form No"
        '
        'TextBoxSalesInvoiceNo
        '
        Me.TextBoxSalesInvoiceNo.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxSalesInvoiceNo.Enabled = False
        Me.TextBoxSalesInvoiceNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSalesInvoiceNo.Location = New System.Drawing.Point(861, 74)
        Me.TextBoxSalesInvoiceNo.Name = "TextBoxSalesInvoiceNo"
        Me.TextBoxSalesInvoiceNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSalesInvoiceNo.TabIndex = 125
        Me.TextBoxSalesInvoiceNo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(857, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 17)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Sales Invoice No"
        '
        'textBoxBillTo
        '
        Me.textBoxBillTo.BackColor = System.Drawing.Color.LightGray
        Me.textBoxBillTo.Enabled = False
        Me.textBoxBillTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBoxBillTo.Location = New System.Drawing.Point(16, 101)
        Me.textBoxBillTo.Multiline = True
        Me.textBoxBillTo.Name = "textBoxBillTo"
        Me.textBoxBillTo.Size = New System.Drawing.Size(183, 111)
        Me.textBoxBillTo.TabIndex = 124
        Me.textBoxBillTo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "Bill To"
        '
        'CheckInclusiveTax
        '
        Me.CheckInclusiveTax.AutoSize = True
        Me.CheckInclusiveTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckInclusiveTax.Location = New System.Drawing.Point(678, 52)
        Me.CheckInclusiveTax.Name = "CheckInclusiveTax"
        Me.CheckInclusiveTax.Size = New System.Drawing.Size(99, 21)
        Me.CheckInclusiveTax.TabIndex = 109
        Me.CheckInclusiveTax.Text = "Inclusive Tax"
        Me.CheckInclusiveTax.UseVisualStyleBackColor = True
        '
        'CheckCustTaxable
        '
        Me.CheckCustTaxable.AutoSize = True
        Me.CheckCustTaxable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckCustTaxable.Location = New System.Drawing.Point(533, 53)
        Me.CheckCustTaxable.Name = "CheckCustTaxable"
        Me.CheckCustTaxable.Size = New System.Drawing.Size(145, 21)
        Me.CheckCustTaxable.TabIndex = 108
        Me.CheckCustTaxable.Text = "Customer is Taxable"
        Me.CheckCustTaxable.UseVisualStyleBackColor = True
        '
        'CmbCustomer
        '
        Me.CmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCustomer.FormattingEnabled = True
        Me.CmbCustomer.Location = New System.Drawing.Point(14, 53)
        Me.CmbCustomer.Name = "CmbCustomer"
        Me.CmbCustomer.Size = New System.Drawing.Size(378, 25)
        Me.CmbCustomer.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Customer / Konsumen"
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(475, 17)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 121
        Me.idPrimary.Visible = False
        '
        'TextBoxNamaCust
        '
        Me.TextBoxNamaCust.Location = New System.Drawing.Point(238, 16)
        Me.TextBoxNamaCust.Name = "TextBoxNamaCust"
        Me.TextBoxNamaCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaCust.TabIndex = 120
        Me.TextBoxNamaCust.Visible = False
        '
        'TextBoxKodeCust
        '
        Me.TextBoxKodeCust.Location = New System.Drawing.Point(357, 17)
        Me.TextBoxKodeCust.Name = "TextBoxKodeCust"
        Me.TextBoxKodeCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeCust.TabIndex = 119
        Me.TextBoxKodeCust.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 25)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Sales Invoice (SI)"
        '
        'SalesInvoice
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
        Me.Controls.Add(Me.DataGridViewSI)
        Me.Controls.Add(Me.DateTimePickerShipDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePickerSalesInvoiceDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxFormNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxSalesInvoiceNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.textBoxBillTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CheckInclusiveTax)
        Me.Controls.Add(Me.CheckCustTaxable)
        Me.Controls.Add(Me.CmbCustomer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.TextBoxNamaCust)
        Me.Controls.Add(Me.TextBoxKodeCust)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SalesInvoice"
        Me.Text = "Sales Invoice"
        CType(Me.DataGridViewSI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxSelectType As System.Windows.Forms.ComboBox
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewSI As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePickerShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerSalesInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFormNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSalesInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents textBoxBillTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckInclusiveTax As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCustTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents CmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaCust As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeCust As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
