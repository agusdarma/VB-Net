<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseOrder
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbVendor = New System.Windows.Forms.ComboBox()
        Me.CheckVendorTaxable = New System.Windows.Forms.CheckBox()
        Me.CheckInclusiveTax = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxPoNo = New System.Windows.Forms.TextBox()
        Me.DateTimePickerPoDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.alamatVendor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxShipTo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridViewPO = New System.Windows.Forms.DataGridView()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxValueDiskon = New System.Windows.Forms.TextBox()
        Me.TextBoxFreight = New System.Windows.Forms.TextBox()
        Me.lblPPN = New System.Windows.Forms.Label()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemAddRows = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDeleteRows = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxSubTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblPPnRp = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBoxTotalOrder = New System.Windows.Forms.TextBox()
        Me.TextBoxPPn = New System.Windows.Forms.TextBox()
        Me.TextBoxPctDiskon = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.TextBoxKodeSupplier = New System.Windows.Forms.TextBox()
        Me.TextBoxNamaSupplier = New System.Windows.Forms.TextBox()
        Me.SavePrint = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        CType(Me.DataGridViewPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Purchase Order (PO)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Supplier / Vendor"
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbVendor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(12, 54)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(378, 25)
        Me.CmbVendor.TabIndex = 5
        '
        'CheckVendorTaxable
        '
        Me.CheckVendorTaxable.AutoSize = True
        Me.CheckVendorTaxable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckVendorTaxable.Location = New System.Drawing.Point(493, 54)
        Me.CheckVendorTaxable.Name = "CheckVendorTaxable"
        Me.CheckVendorTaxable.Size = New System.Drawing.Size(132, 21)
        Me.CheckVendorTaxable.TabIndex = 3
        Me.CheckVendorTaxable.Text = "Vendor is Taxable"
        Me.CheckVendorTaxable.UseVisualStyleBackColor = True
        '
        'CheckInclusiveTax
        '
        Me.CheckInclusiveTax.AutoSize = True
        Me.CheckInclusiveTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckInclusiveTax.Location = New System.Drawing.Point(631, 53)
        Me.CheckInclusiveTax.Name = "CheckInclusiveTax"
        Me.CheckInclusiveTax.Size = New System.Drawing.Size(99, 21)
        Me.CheckInclusiveTax.TabIndex = 4
        Me.CheckInclusiveTax.Text = "Inclusive Tax"
        Me.CheckInclusiveTax.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(942, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "PO No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1099, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "PO Date"
        '
        'TextBoxPoNo
        '
        Me.TextBoxPoNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPoNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPoNo.Location = New System.Drawing.Point(915, 73)
        Me.TextBoxPoNo.Name = "TextBoxPoNo"
        Me.TextBoxPoNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPoNo.TabIndex = 1
        '
        'DateTimePickerPoDate
        '
        Me.DateTimePickerPoDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerPoDate.Location = New System.Drawing.Point(1028, 72)
        Me.DateTimePickerPoDate.Name = "DateTimePickerPoDate"
        Me.DateTimePickerPoDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerPoDate.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Address"
        '
        'alamatVendor
        '
        Me.alamatVendor.BackColor = System.Drawing.Color.LightGray
        Me.alamatVendor.Enabled = False
        Me.alamatVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alamatVendor.Location = New System.Drawing.Point(15, 102)
        Me.alamatVendor.Multiline = True
        Me.alamatVendor.Name = "alamatVendor"
        Me.alamatVendor.Size = New System.Drawing.Size(183, 111)
        Me.alamatVendor.TabIndex = 13
        Me.alamatVendor.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(204, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Ship To"
        '
        'TextBoxShipTo
        '
        Me.TextBoxShipTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxShipTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxShipTo.Location = New System.Drawing.Point(207, 102)
        Me.TextBoxShipTo.Multiline = True
        Me.TextBoxShipTo.Name = "TextBoxShipTo"
        Me.TextBoxShipTo.Size = New System.Drawing.Size(183, 111)
        Me.TextBoxShipTo.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Items"
        '
        'DataGridViewPO
        '
        Me.DataGridViewPO.AllowUserToAddRows = False
        Me.DataGridViewPO.AllowUserToDeleteRows = False
        Me.DataGridViewPO.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewPO.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewPO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewPO.ColumnHeadersHeight = 30
        Me.DataGridViewPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewPO.EnableHeadersVisualStyles = False
        Me.DataGridViewPO.Location = New System.Drawing.Point(15, 235)
        Me.DataGridViewPO.Name = "DataGridViewPO"
        Me.DataGridViewPO.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewPO.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewPO.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewPO.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewPO.TabIndex = 7
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(15, 408)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(375, 60)
        Me.TextBoxNotes.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 388)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Notes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(881, 389)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 17)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Sub Total :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(881, 420)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 17)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Diskon :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(881, 480)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 17)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Estimated Freight :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(881, 510)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Total Order :"
        '
        'TextBoxValueDiskon
        '
        Me.TextBoxValueDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxValueDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxValueDiskon.Location = New System.Drawing.Point(1034, 418)
        Me.TextBoxValueDiskon.Name = "TextBoxValueDiskon"
        Me.TextBoxValueDiskon.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxValueDiskon.TabIndex = 10
        Me.TextBoxValueDiskon.Text = "0"
        Me.TextBoxValueDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxFreight
        '
        Me.TextBoxFreight.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxFreight.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFreight.Location = New System.Drawing.Point(1034, 477)
        Me.TextBoxFreight.Name = "TextBoxFreight"
        Me.TextBoxFreight.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxFreight.TabIndex = 11
        Me.TextBoxFreight.Text = "0"
        Me.TextBoxFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(881, 448)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(68, 17)
        Me.lblPPN.TabIndex = 28
        Me.lblPPN.Text = "PPN 10% :"
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTax.Location = New System.Drawing.Point(1140, 511)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(81, 17)
        Me.lblTax.TabIndex = 30
        Me.lblTax.Text = "Tax included"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAddRows, Me.ToolStripMenuItemDeleteRows})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(139, 48)
        '
        'ToolStripMenuItemAddRows
        '
        Me.ToolStripMenuItemAddRows.Name = "ToolStripMenuItemAddRows"
        Me.ToolStripMenuItemAddRows.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemAddRows.Text = "Add Rows"
        '
        'ToolStripMenuItemDeleteRows
        '
        Me.ToolStripMenuItemDeleteRows.Name = "ToolStripMenuItemDeleteRows"
        Me.ToolStripMenuItemDeleteRows.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemDeleteRows.Text = "Delete Rows"
        '
        'TextBoxSubTotal
        '
        Me.TextBoxSubTotal.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxSubTotal.Enabled = False
        Me.TextBoxSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubTotal.Location = New System.Drawing.Point(1033, 388)
        Me.TextBoxSubTotal.Name = "TextBoxSubTotal"
        Me.TextBoxSubTotal.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSubTotal.TabIndex = 32
        Me.TextBoxSubTotal.TabStop = False
        Me.TextBoxSubTotal.Text = "0"
        Me.TextBoxSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1003, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 17)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Rp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1003, 422)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 17)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Rp"
        '
        'LblPPnRp
        '
        Me.LblPPnRp.AutoSize = True
        Me.LblPPnRp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPnRp.Location = New System.Drawing.Point(1003, 447)
        Me.LblPPnRp.Name = "LblPPnRp"
        Me.LblPPnRp.Size = New System.Drawing.Size(24, 17)
        Me.LblPPnRp.TabIndex = 35
        Me.LblPPnRp.Text = "Rp"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1003, 510)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 17)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Rp"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1003, 477)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 17)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Rp"
        '
        'TextBoxTotalOrder
        '
        Me.TextBoxTotalOrder.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxTotalOrder.Enabled = False
        Me.TextBoxTotalOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalOrder.Location = New System.Drawing.Point(1034, 507)
        Me.TextBoxTotalOrder.Name = "TextBoxTotalOrder"
        Me.TextBoxTotalOrder.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxTotalOrder.TabIndex = 38
        Me.TextBoxTotalOrder.TabStop = False
        Me.TextBoxTotalOrder.Text = "0"
        Me.TextBoxTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPPn
        '
        Me.TextBoxPPn.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxPPn.Enabled = False
        Me.TextBoxPPn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPPn.Location = New System.Drawing.Point(1034, 446)
        Me.TextBoxPPn.Name = "TextBoxPPn"
        Me.TextBoxPPn.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPPn.TabIndex = 39
        Me.TextBoxPPn.TabStop = False
        Me.TextBoxPPn.Text = "0"
        Me.TextBoxPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPctDiskon
        '
        Me.TextBoxPctDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPctDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPctDiskon.Location = New System.Drawing.Point(936, 418)
        Me.TextBoxPctDiskon.Name = "TextBoxPctDiskon"
        Me.TextBoxPctDiskon.Size = New System.Drawing.Size(35, 25)
        Me.TextBoxPctDiskon.TabIndex = 9
        Me.TextBoxPctDiskon.Text = "0"
        Me.TextBoxPctDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(977, 422)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 17)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "%"
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(840, 540)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 12
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(947, 540)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 13
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(1153, 540)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 14
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'TextBoxKodeSupplier
        '
        Me.TextBoxKodeSupplier.Location = New System.Drawing.Point(350, 13)
        Me.TextBoxKodeSupplier.Name = "TextBoxKodeSupplier"
        Me.TextBoxKodeSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeSupplier.TabIndex = 42
        Me.TextBoxKodeSupplier.Visible = False
        '
        'TextBoxNamaSupplier
        '
        Me.TextBoxNamaSupplier.Location = New System.Drawing.Point(231, 12)
        Me.TextBoxNamaSupplier.Name = "TextBoxNamaSupplier"
        Me.TextBoxNamaSupplier.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaSupplier.TabIndex = 43
        Me.TextBoxNamaSupplier.Visible = False
        '
        'SavePrint
        '
        Me.SavePrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrint.Location = New System.Drawing.Point(1046, 540)
        Me.SavePrint.Name = "SavePrint"
        Me.SavePrint.Size = New System.Drawing.Size(101, 31)
        Me.SavePrint.TabIndex = 44
        Me.SavePrint.Text = "Save n Print"
        Me.SavePrint.UseVisualStyleBackColor = True
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(1072, 4)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 45
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(1153, 4)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 46
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(468, 13)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 47
        Me.idPrimary.Visible = False
        '
        'PurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 583)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.SavePrint)
        Me.Controls.Add(Me.TextBoxNamaSupplier)
        Me.Controls.Add(Me.TextBoxKodeSupplier)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ButtonSaveClose)
        Me.Controls.Add(Me.ButtonSaveNew)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBoxPctDiskon)
        Me.Controls.Add(Me.TextBoxPPn)
        Me.Controls.Add(Me.TextBoxTotalOrder)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LblPPnRp)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBoxSubTotal)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.lblPPN)
        Me.Controls.Add(Me.TextBoxFreight)
        Me.Controls.Add(Me.TextBoxValueDiskon)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBoxNotes)
        Me.Controls.Add(Me.DataGridViewPO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxShipTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.alamatVendor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePickerPoDate)
        Me.Controls.Add(Me.TextBoxPoNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckInclusiveTax)
        Me.Controls.Add(Me.CheckVendorTaxable)
        Me.Controls.Add(Me.CmbVendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PurchaseOrder"
        Me.Text = "Purchase Order"
        CType(Me.DataGridViewPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents CheckVendorTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents CheckInclusiveTax As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPoNo As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerPoDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents alamatVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxShipTo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewPO As System.Windows.Forms.DataGridView
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxValueDiskon As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFreight As System.Windows.Forms.TextBox
    Friend WithEvents lblPPN As System.Windows.Forms.Label
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemAddRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDeleteRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBoxSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblPPnRp As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalOrder As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPPn As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPctDiskon As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents TextBoxKodeSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaSupplier As System.Windows.Forms.TextBox
    Friend WithEvents SavePrint As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
End Class
