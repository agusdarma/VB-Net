<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesOrderFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.idPrimary = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemAddRows = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDeleteRows = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextPo = New System.Windows.Forms.Button()
        Me.PrevPO = New System.Windows.Forms.Button()
        Me.SavePrint = New System.Windows.Forms.Button()
        Me.TextBoxNamaCust = New System.Windows.Forms.TextBox()
        Me.TextBoxKodeCust = New System.Windows.Forms.TextBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ButtonSaveClose = New System.Windows.Forms.Button()
        Me.ButtonSaveNew = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBoxPctDiskon = New System.Windows.Forms.TextBox()
        Me.TextBoxPPn = New System.Windows.Forms.TextBox()
        Me.TextBoxTotalOrder = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblPPnRp = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxSubTotal = New System.Windows.Forms.TextBox()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.lblPPN = New System.Windows.Forms.Label()
        Me.TextBoxFreight = New System.Windows.Forms.TextBox()
        Me.TextBoxValueDiskon = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxNotes = New System.Windows.Forms.TextBox()
        Me.DataGridViewSO = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxShipTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textBoxBillTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePickerSoDate = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxSoNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckInclusiveTax = New System.Windows.Forms.CheckBox()
        Me.CheckVendorTaxable = New System.Windows.Forms.CheckBox()
        Me.CmbCust = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxPoNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DateTimePickerShipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DataGridViewSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'idPrimary
        '
        Me.idPrimary.Location = New System.Drawing.Point(471, 17)
        Me.idPrimary.Name = "idPrimary"
        Me.idPrimary.Size = New System.Drawing.Size(100, 20)
        Me.idPrimary.TabIndex = 91
        Me.idPrimary.Visible = False
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
        'NextPo
        '
        Me.NextPo.BackColor = System.Drawing.Color.Lime
        Me.NextPo.Location = New System.Drawing.Point(1156, 8)
        Me.NextPo.Name = "NextPo"
        Me.NextPo.Size = New System.Drawing.Size(75, 23)
        Me.NextPo.TabIndex = 90
        Me.NextPo.Text = "Next"
        Me.NextPo.UseVisualStyleBackColor = False
        '
        'PrevPO
        '
        Me.PrevPO.BackColor = System.Drawing.Color.Lime
        Me.PrevPO.Location = New System.Drawing.Point(1075, 8)
        Me.PrevPO.Name = "PrevPO"
        Me.PrevPO.Size = New System.Drawing.Size(75, 23)
        Me.PrevPO.TabIndex = 89
        Me.PrevPO.Text = "Prev"
        Me.PrevPO.UseVisualStyleBackColor = False
        '
        'SavePrint
        '
        Me.SavePrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrint.Location = New System.Drawing.Point(1049, 544)
        Me.SavePrint.Name = "SavePrint"
        Me.SavePrint.Size = New System.Drawing.Size(101, 31)
        Me.SavePrint.TabIndex = 88
        Me.SavePrint.Text = "Save n Print"
        Me.SavePrint.UseVisualStyleBackColor = True
        '
        'TextBoxNamaCust
        '
        Me.TextBoxNamaCust.Location = New System.Drawing.Point(234, 16)
        Me.TextBoxNamaCust.Name = "TextBoxNamaCust"
        Me.TextBoxNamaCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaCust.TabIndex = 87
        Me.TextBoxNamaCust.Visible = False
        '
        'TextBoxKodeCust
        '
        Me.TextBoxKodeCust.Location = New System.Drawing.Point(353, 17)
        Me.TextBoxKodeCust.Name = "TextBoxKodeCust"
        Me.TextBoxKodeCust.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxKodeCust.TabIndex = 86
        Me.TextBoxKodeCust.Visible = False
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Cancel.Location = New System.Drawing.Point(1156, 544)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 67
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'ButtonSaveClose
        '
        Me.ButtonSaveClose.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonSaveClose.Location = New System.Drawing.Point(950, 544)
        Me.ButtonSaveClose.Name = "ButtonSaveClose"
        Me.ButtonSaveClose.Size = New System.Drawing.Size(93, 31)
        Me.ButtonSaveClose.TabIndex = 66
        Me.ButtonSaveClose.Text = "Save n Close"
        Me.ButtonSaveClose.UseVisualStyleBackColor = True
        '
        'ButtonSaveNew
        '
        Me.ButtonSaveNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSaveNew.Location = New System.Drawing.Point(843, 544)
        Me.ButtonSaveNew.Name = "ButtonSaveNew"
        Me.ButtonSaveNew.Size = New System.Drawing.Size(101, 31)
        Me.ButtonSaveNew.TabIndex = 64
        Me.ButtonSaveNew.Text = "Save n New"
        Me.ButtonSaveNew.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(980, 426)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 17)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "%"
        '
        'TextBoxPctDiskon
        '
        Me.TextBoxPctDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPctDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPctDiskon.Location = New System.Drawing.Point(939, 422)
        Me.TextBoxPctDiskon.Name = "TextBoxPctDiskon"
        Me.TextBoxPctDiskon.Size = New System.Drawing.Size(35, 25)
        Me.TextBoxPctDiskon.TabIndex = 60
        Me.TextBoxPctDiskon.Text = "0"
        Me.TextBoxPctDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxPPn
        '
        Me.TextBoxPPn.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxPPn.Enabled = False
        Me.TextBoxPPn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPPn.Location = New System.Drawing.Point(1037, 450)
        Me.TextBoxPPn.Name = "TextBoxPPn"
        Me.TextBoxPPn.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPPn.TabIndex = 84
        Me.TextBoxPPn.TabStop = False
        Me.TextBoxPPn.Text = "0"
        Me.TextBoxPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxTotalOrder
        '
        Me.TextBoxTotalOrder.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxTotalOrder.Enabled = False
        Me.TextBoxTotalOrder.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalOrder.Location = New System.Drawing.Point(1037, 511)
        Me.TextBoxTotalOrder.Name = "TextBoxTotalOrder"
        Me.TextBoxTotalOrder.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxTotalOrder.TabIndex = 83
        Me.TextBoxTotalOrder.TabStop = False
        Me.TextBoxTotalOrder.Text = "0"
        Me.TextBoxTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1006, 481)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 17)
        Me.Label18.TabIndex = 82
        Me.Label18.Text = "Rp"
        Me.Label18.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1006, 514)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 17)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "Rp"
        '
        'LblPPnRp
        '
        Me.LblPPnRp.AutoSize = True
        Me.LblPPnRp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPPnRp.Location = New System.Drawing.Point(1006, 451)
        Me.LblPPnRp.Name = "LblPPnRp"
        Me.LblPPnRp.Size = New System.Drawing.Size(24, 17)
        Me.LblPPnRp.TabIndex = 80
        Me.LblPPnRp.Text = "Rp"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1006, 426)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 17)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Rp"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1006, 395)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 17)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Rp"
        '
        'TextBoxSubTotal
        '
        Me.TextBoxSubTotal.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxSubTotal.Enabled = False
        Me.TextBoxSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubTotal.Location = New System.Drawing.Point(1036, 392)
        Me.TextBoxSubTotal.Name = "TextBoxSubTotal"
        Me.TextBoxSubTotal.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSubTotal.TabIndex = 77
        Me.TextBoxSubTotal.TabStop = False
        Me.TextBoxSubTotal.Text = "0"
        Me.TextBoxSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTax
        '
        Me.lblTax.AutoSize = True
        Me.lblTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTax.Location = New System.Drawing.Point(1143, 515)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(81, 17)
        Me.lblTax.TabIndex = 76
        Me.lblTax.Text = "Tax included"
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(884, 452)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(68, 17)
        Me.lblPPN.TabIndex = 75
        Me.lblPPN.Text = "PPN 10% :"
        '
        'TextBoxFreight
        '
        Me.TextBoxFreight.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxFreight.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFreight.Location = New System.Drawing.Point(1037, 481)
        Me.TextBoxFreight.Name = "TextBoxFreight"
        Me.TextBoxFreight.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxFreight.TabIndex = 62
        Me.TextBoxFreight.Text = "0"
        Me.TextBoxFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBoxFreight.Visible = False
        '
        'TextBoxValueDiskon
        '
        Me.TextBoxValueDiskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxValueDiskon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxValueDiskon.Location = New System.Drawing.Point(1037, 422)
        Me.TextBoxValueDiskon.Name = "TextBoxValueDiskon"
        Me.TextBoxValueDiskon.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxValueDiskon.TabIndex = 61
        Me.TextBoxValueDiskon.Text = "0"
        Me.TextBoxValueDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(884, 514)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 17)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "Total Order :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(884, 484)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 17)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Estimated Freight :"
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(884, 424)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 17)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "Diskon :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(884, 393)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 17)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Sub Total :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 392)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Notes"
        '
        'TextBoxNotes
        '
        Me.TextBoxNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxNotes.Location = New System.Drawing.Point(18, 412)
        Me.TextBoxNotes.Multiline = True
        Me.TextBoxNotes.Name = "TextBoxNotes"
        Me.TextBoxNotes.Size = New System.Drawing.Size(375, 60)
        Me.TextBoxNotes.TabIndex = 58
        '
        'DataGridViewSO
        '
        Me.DataGridViewSO.AllowUserToAddRows = False
        Me.DataGridViewSO.AllowUserToDeleteRows = False
        Me.DataGridViewSO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewSO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewSO.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewSO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewSO.ColumnHeadersHeight = 30
        Me.DataGridViewSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewSO.EnableHeadersVisualStyles = False
        Me.DataGridViewSO.Location = New System.Drawing.Point(18, 239)
        Me.DataGridViewSO.Name = "DataGridViewSO"
        Me.DataGridViewSO.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewSO.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewSO.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewSO.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewSO.Size = New System.Drawing.Size(1212, 150)
        Me.DataGridViewSO.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Items"
        '
        'TextBoxShipTo
        '
        Me.TextBoxShipTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxShipTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxShipTo.Location = New System.Drawing.Point(210, 106)
        Me.TextBoxShipTo.Multiline = True
        Me.TextBoxShipTo.Name = "TextBoxShipTo"
        Me.TextBoxShipTo.Size = New System.Drawing.Size(183, 111)
        Me.TextBoxShipTo.TabIndex = 55
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(207, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Ship To"
        '
        'textBoxBillTo
        '
        Me.textBoxBillTo.BackColor = System.Drawing.Color.LightGray
        Me.textBoxBillTo.Enabled = False
        Me.textBoxBillTo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBoxBillTo.Location = New System.Drawing.Point(18, 106)
        Me.textBoxBillTo.Multiline = True
        Me.textBoxBillTo.Name = "textBoxBillTo"
        Me.textBoxBillTo.Size = New System.Drawing.Size(183, 111)
        Me.textBoxBillTo.TabIndex = 65
        Me.textBoxBillTo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Bill To"
        '
        'DateTimePickerSoDate
        '
        Me.DateTimePickerSoDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerSoDate.Location = New System.Drawing.Point(1031, 76)
        Me.DateTimePickerSoDate.Name = "DateTimePickerSoDate"
        Me.DateTimePickerSoDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerSoDate.TabIndex = 51
        '
        'TextBoxSoNo
        '
        Me.TextBoxSoNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxSoNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSoNo.Location = New System.Drawing.Point(918, 77)
        Me.TextBoxSoNo.Name = "TextBoxSoNo"
        Me.TextBoxSoNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxSoNo.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1102, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "SO Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(945, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "SO No"
        '
        'CheckInclusiveTax
        '
        Me.CheckInclusiveTax.AutoSize = True
        Me.CheckInclusiveTax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckInclusiveTax.Location = New System.Drawing.Point(634, 57)
        Me.CheckInclusiveTax.Name = "CheckInclusiveTax"
        Me.CheckInclusiveTax.Size = New System.Drawing.Size(99, 21)
        Me.CheckInclusiveTax.TabIndex = 53
        Me.CheckInclusiveTax.Text = "Inclusive Tax"
        Me.CheckInclusiveTax.UseVisualStyleBackColor = True
        '
        'CheckVendorTaxable
        '
        Me.CheckVendorTaxable.AutoSize = True
        Me.CheckVendorTaxable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckVendorTaxable.Location = New System.Drawing.Point(484, 58)
        Me.CheckVendorTaxable.Name = "CheckVendorTaxable"
        Me.CheckVendorTaxable.Size = New System.Drawing.Size(145, 21)
        Me.CheckVendorTaxable.TabIndex = 52
        Me.CheckVendorTaxable.Text = "Customer is Taxable"
        Me.CheckVendorTaxable.UseVisualStyleBackColor = True
        '
        'CmbCust
        '
        Me.CmbCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.CmbCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCust.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCust.FormattingEnabled = True
        Me.CmbCust.Location = New System.Drawing.Point(15, 58)
        Me.CmbCust.Name = "CmbCust"
        Me.CmbCust.Size = New System.Drawing.Size(378, 25)
        Me.CmbCust.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Customer / Konsumen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 25)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Sales Order (SO)"
        '
        'TextBoxPoNo
        '
        Me.TextBoxPoNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxPoNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPoNo.Location = New System.Drawing.Point(917, 129)
        Me.TextBoxPoNo.Name = "TextBoxPoNo"
        Me.TextBoxPoNo.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxPoNo.TabIndex = 92
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(944, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 17)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "PO No"
        '
        'DateTimePickerShipDate
        '
        Me.DateTimePickerShipDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerShipDate.Location = New System.Drawing.Point(1031, 129)
        Me.DateTimePickerShipDate.Name = "DateTimePickerShipDate"
        Me.DateTimePickerShipDate.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePickerShipDate.TabIndex = 94
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1102, 109)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 17)
        Me.Label19.TabIndex = 95
        Me.Label19.Text = "Ship Date"
        '
        'SalesOrderFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 583)
        Me.Controls.Add(Me.DateTimePickerShipDate)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TextBoxPoNo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.idPrimary)
        Me.Controls.Add(Me.NextPo)
        Me.Controls.Add(Me.PrevPO)
        Me.Controls.Add(Me.SavePrint)
        Me.Controls.Add(Me.TextBoxNamaCust)
        Me.Controls.Add(Me.TextBoxKodeCust)
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
        Me.Controls.Add(Me.DataGridViewSO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxShipTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.textBoxBillTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePickerSoDate)
        Me.Controls.Add(Me.TextBoxSoNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckInclusiveTax)
        Me.Controls.Add(Me.CheckVendorTaxable)
        Me.Controls.Add(Me.CmbCust)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SalesOrderFrm"
        Me.Text = "Sales Order"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DataGridViewSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents idPrimary As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemAddRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDeleteRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextPo As System.Windows.Forms.Button
    Friend WithEvents PrevPO As System.Windows.Forms.Button
    Friend WithEvents SavePrint As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaCust As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeCust As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPctDiskon As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPPn As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotalOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LblPPnRp As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblTax As System.Windows.Forms.Label
    Friend WithEvents lblPPN As System.Windows.Forms.Label
    Friend WithEvents TextBoxFreight As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxValueDiskon As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNotes As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewSO As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxShipTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents textBoxBillTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerSoDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxSoNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckInclusiveTax As System.Windows.Forms.CheckBox
    Friend WithEvents CheckVendorTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents CmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPoNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
