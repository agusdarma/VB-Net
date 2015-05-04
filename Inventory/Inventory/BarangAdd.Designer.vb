<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarangAdd
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.GeneralPage = New System.Windows.Forms.TabPage()
        Me.ComboBoxSupplier = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TotalCost = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cost = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.satuan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.qty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBoxGudang = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxKategori = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxStatus = New System.Windows.Forms.ComboBox()
        Me.NamaItem = New System.Windows.Forms.TextBox()
        Me.KodeItem = New System.Windows.Forms.TextBox()
        Me.RadioButtonService = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNonInventory = New System.Windows.Forms.RadioButton()
        Me.RadioButtonInventory = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Sales_PurchaseTab = New System.Windows.Forms.TabPage()
        Me.diskon = New System.Windows.Forms.TextBox()
        Me.salesPrice = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.GeneralPage.SuspendLayout()
        Me.Sales_PurchaseTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Add Barang dan Jasa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cancel.Location = New System.Drawing.Point(420, 434)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Button_Cancel.TabIndex = 11
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Location = New System.Drawing.Point(265, 434)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(75, 31)
        Me.Button_Save.TabIndex = 10
        Me.Button_Save.Text = "Save"
        Me.Button_Save.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.GeneralPage)
        Me.TabControl1.Controls.Add(Me.Sales_PurchaseTab)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(1, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(805, 385)
        Me.TabControl1.TabIndex = 19
        '
        'GeneralPage
        '
        Me.GeneralPage.Controls.Add(Me.Barcode)
        Me.GeneralPage.Controls.Add(Me.Label16)
        Me.GeneralPage.Controls.Add(Me.ComboBoxSupplier)
        Me.GeneralPage.Controls.Add(Me.Label15)
        Me.GeneralPage.Controls.Add(Me.TotalCost)
        Me.GeneralPage.Controls.Add(Me.Label11)
        Me.GeneralPage.Controls.Add(Me.Cost)
        Me.GeneralPage.Controls.Add(Me.Label10)
        Me.GeneralPage.Controls.Add(Me.satuan)
        Me.GeneralPage.Controls.Add(Me.Label9)
        Me.GeneralPage.Controls.Add(Me.qty)
        Me.GeneralPage.Controls.Add(Me.Label8)
        Me.GeneralPage.Controls.Add(Me.ComboBoxGudang)
        Me.GeneralPage.Controls.Add(Me.Label7)
        Me.GeneralPage.Controls.Add(Me.ComboBoxKategori)
        Me.GeneralPage.Controls.Add(Me.Label6)
        Me.GeneralPage.Controls.Add(Me.ComboBoxStatus)
        Me.GeneralPage.Controls.Add(Me.NamaItem)
        Me.GeneralPage.Controls.Add(Me.KodeItem)
        Me.GeneralPage.Controls.Add(Me.RadioButtonService)
        Me.GeneralPage.Controls.Add(Me.RadioButtonNonInventory)
        Me.GeneralPage.Controls.Add(Me.RadioButtonInventory)
        Me.GeneralPage.Controls.Add(Me.Label5)
        Me.GeneralPage.Controls.Add(Me.Label4)
        Me.GeneralPage.Controls.Add(Me.Label3)
        Me.GeneralPage.Controls.Add(Me.Label2)
        Me.GeneralPage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralPage.Location = New System.Drawing.Point(4, 26)
        Me.GeneralPage.Name = "GeneralPage"
        Me.GeneralPage.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralPage.Size = New System.Drawing.Size(797, 355)
        Me.GeneralPage.TabIndex = 0
        Me.GeneralPage.Text = "General"
        Me.GeneralPage.UseVisualStyleBackColor = True
        '
        'ComboBoxSupplier
        '
        Me.ComboBoxSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSupplier.FormattingEnabled = True
        Me.ComboBoxSupplier.Location = New System.Drawing.Point(90, 238)
        Me.ComboBoxSupplier.Name = "ComboBoxSupplier"
        Me.ComboBoxSupplier.Size = New System.Drawing.Size(262, 25)
        Me.ComboBoxSupplier.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(23, 241)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Supplier :"
        '
        'TotalCost
        '
        Me.TotalCost.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TotalCost.Enabled = False
        Me.TotalCost.Location = New System.Drawing.Point(523, 205)
        Me.TotalCost.Name = "TotalCost"
        Me.TotalCost.Size = New System.Drawing.Size(148, 25)
        Me.TotalCost.TabIndex = 99
        Me.TotalCost.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(443, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 17)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Total Cost :"
        '
        'Cost
        '
        Me.Cost.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Cost.Location = New System.Drawing.Point(523, 167)
        Me.Cost.Name = "Cost"
        Me.Cost.Size = New System.Drawing.Size(148, 25)
        Me.Cost.TabIndex = 9
        Me.Cost.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(476, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 17)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Cost :"
        '
        'satuan
        '
        Me.satuan.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.satuan.Location = New System.Drawing.Point(90, 277)
        Me.satuan.MaxLength = 5
        Me.satuan.Name = "satuan"
        Me.satuan.Size = New System.Drawing.Size(64, 25)
        Me.satuan.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 17)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Satuan :"
        '
        'qty
        '
        Me.qty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.qty.Location = New System.Drawing.Point(523, 133)
        Me.qty.Name = "qty"
        Me.qty.Size = New System.Drawing.Size(64, 25)
        Me.qty.TabIndex = 8
        Me.qty.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(454, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 17)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Quantity :"
        '
        'ComboBoxGudang
        '
        Me.ComboBoxGudang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxGudang.FormattingEnabled = True
        Me.ComboBoxGudang.Location = New System.Drawing.Point(90, 203)
        Me.ComboBoxGudang.Name = "ComboBoxGudang"
        Me.ComboBoxGudang.Size = New System.Drawing.Size(262, 25)
        Me.ComboBoxGudang.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Gudang :"
        '
        'ComboBoxKategori
        '
        Me.ComboBoxKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxKategori.FormattingEnabled = True
        Me.ComboBoxKategori.Location = New System.Drawing.Point(90, 168)
        Me.ComboBoxKategori.Name = "ComboBoxKategori"
        Me.ComboBoxKategori.Size = New System.Drawing.Size(262, 25)
        Me.ComboBoxKategori.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Kategori :"
        '
        'ComboBoxStatus
        '
        Me.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxStatus.FormattingEnabled = True
        Me.ComboBoxStatus.Location = New System.Drawing.Point(90, 133)
        Me.ComboBoxStatus.Name = "ComboBoxStatus"
        Me.ComboBoxStatus.Size = New System.Drawing.Size(144, 25)
        Me.ComboBoxStatus.TabIndex = 3
        '
        'NamaItem
        '
        Me.NamaItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NamaItem.Location = New System.Drawing.Point(90, 70)
        Me.NamaItem.Name = "NamaItem"
        Me.NamaItem.Size = New System.Drawing.Size(700, 25)
        Me.NamaItem.TabIndex = 2
        '
        'KodeItem
        '
        Me.KodeItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.KodeItem.Location = New System.Drawing.Point(90, 39)
        Me.KodeItem.Name = "KodeItem"
        Me.KodeItem.Size = New System.Drawing.Size(146, 25)
        Me.KodeItem.TabIndex = 1
        '
        'RadioButtonService
        '
        Me.RadioButtonService.AutoSize = True
        Me.RadioButtonService.Location = New System.Drawing.Point(361, 6)
        Me.RadioButtonService.Name = "RadioButtonService"
        Me.RadioButtonService.Size = New System.Drawing.Size(67, 21)
        Me.RadioButtonService.TabIndex = 96
        Me.RadioButtonService.TabStop = True
        Me.RadioButtonService.Text = "Service"
        Me.RadioButtonService.UseVisualStyleBackColor = True
        '
        'RadioButtonNonInventory
        '
        Me.RadioButtonNonInventory.AutoSize = True
        Me.RadioButtonNonInventory.Location = New System.Drawing.Point(219, 8)
        Me.RadioButtonNonInventory.Name = "RadioButtonNonInventory"
        Me.RadioButtonNonInventory.Size = New System.Drawing.Size(135, 21)
        Me.RadioButtonNonInventory.TabIndex = 97
        Me.RadioButtonNonInventory.TabStop = True
        Me.RadioButtonNonInventory.Text = "Non Inventory Part"
        Me.RadioButtonNonInventory.UseVisualStyleBackColor = True
        '
        'RadioButtonInventory
        '
        Me.RadioButtonInventory.AutoSize = True
        Me.RadioButtonInventory.Location = New System.Drawing.Point(90, 8)
        Me.RadioButtonInventory.Name = "RadioButtonInventory"
        Me.RadioButtonInventory.Size = New System.Drawing.Size(106, 21)
        Me.RadioButtonInventory.TabIndex = 98
        Me.RadioButtonInventory.TabStop = True
        Me.RadioButtonInventory.Text = "Inventory Part"
        Me.RadioButtonInventory.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Status :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nama Item :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Kode Item :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item Type :"
        '
        'Sales_PurchaseTab
        '
        Me.Sales_PurchaseTab.Controls.Add(Me.diskon)
        Me.Sales_PurchaseTab.Controls.Add(Me.salesPrice)
        Me.Sales_PurchaseTab.Controls.Add(Me.Label14)
        Me.Sales_PurchaseTab.Controls.Add(Me.Label13)
        Me.Sales_PurchaseTab.Controls.Add(Me.Label12)
        Me.Sales_PurchaseTab.Location = New System.Drawing.Point(4, 26)
        Me.Sales_PurchaseTab.Name = "Sales_PurchaseTab"
        Me.Sales_PurchaseTab.Padding = New System.Windows.Forms.Padding(3)
        Me.Sales_PurchaseTab.Size = New System.Drawing.Size(797, 355)
        Me.Sales_PurchaseTab.TabIndex = 1
        Me.Sales_PurchaseTab.Text = "Sales & Purchase"
        Me.Sales_PurchaseTab.UseVisualStyleBackColor = True
        '
        'diskon
        '
        Me.diskon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.diskon.Location = New System.Drawing.Point(115, 66)
        Me.diskon.Name = "diskon"
        Me.diskon.Size = New System.Drawing.Size(146, 25)
        Me.diskon.TabIndex = 17
        Me.diskon.Text = "0"
        '
        'salesPrice
        '
        Me.salesPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.salesPrice.Location = New System.Drawing.Point(115, 35)
        Me.salesPrice.Name = "salesPrice"
        Me.salesPrice.Size = New System.Drawing.Size(146, 25)
        Me.salesPrice.TabIndex = 16
        Me.salesPrice.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 17)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Diskon :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(27, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 17)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Sales Price :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Sales Information"
        '
        'Barcode
        '
        Me.Barcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Barcode.Location = New System.Drawing.Point(89, 101)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(265, 25)
        Me.Barcode.TabIndex = 100
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 17)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Barcode :"
        '
        'BarangAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 473)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BarangAdd"
        Me.Text = "Add Barang"
        Me.TabControl1.ResumeLayout(False)
        Me.GeneralPage.ResumeLayout(False)
        Me.GeneralPage.PerformLayout()
        Me.Sales_PurchaseTab.ResumeLayout(False)
        Me.Sales_PurchaseTab.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents GeneralPage As System.Windows.Forms.TabPage
    Friend WithEvents Sales_PurchaseTab As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonService As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNonInventory As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonInventory As System.Windows.Forms.RadioButton
    Friend WithEvents KodeItem As System.Windows.Forms.TextBox
    Friend WithEvents NamaItem As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKategori As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGudang As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents qty As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents satuan As System.Windows.Forms.TextBox
    Friend WithEvents Cost As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents diskon As System.Windows.Forms.TextBox
    Friend WithEvents salesPrice As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
