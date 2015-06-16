<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterItemClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterGLInterfaceAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterSatuanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterShippingViaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterGudangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceiveItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchasePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveryOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanItemPerGudangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanSalesOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanSalesRetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanHistorySalesByItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem, Me.ManageUserToolStripMenuItem, Me.ManageMasterToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.AboutToolStripMenuItem, Me.LaporanToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.LogoutToolStripMenuItem.Text = "Keluar"
        '
        'ManageUserToolStripMenuItem
        '
        Me.ManageUserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserManagementToolStripMenuItem, Me.GroupManagementToolStripMenuItem, Me.ChangePasswordToolStripMenuItem, Me.ResetPasswordToolStripMenuItem})
        Me.ManageUserToolStripMenuItem.Name = "ManageUserToolStripMenuItem"
        Me.ManageUserToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.ManageUserToolStripMenuItem.Text = "Manage User"
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.Image = CType(resources.GetObject("UserManagementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.UserManagementToolStripMenuItem.Text = "User Management"
        '
        'GroupManagementToolStripMenuItem
        '
        Me.GroupManagementToolStripMenuItem.Image = CType(resources.GetObject("GroupManagementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GroupManagementToolStripMenuItem.Name = "GroupManagementToolStripMenuItem"
        Me.GroupManagementToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GroupManagementToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.GroupManagementToolStripMenuItem.Text = "Group Management"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        Me.ChangePasswordToolStripMenuItem.Visible = False
        '
        'ResetPasswordToolStripMenuItem
        '
        Me.ResetPasswordToolStripMenuItem.Name = "ResetPasswordToolStripMenuItem"
        Me.ResetPasswordToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ResetPasswordToolStripMenuItem.Text = "Reset Password"
        Me.ResetPasswordToolStripMenuItem.Visible = False
        '
        'ManageMasterToolStripMenuItem
        '
        Me.ManageMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterItemToolStripMenuItem, Me.MasterVendorToolStripMenuItem, Me.MasterCustomerToolStripMenuItem, Me.MasterItemClassToolStripMenuItem, Me.MasterBankToolStripMenuItem, Me.MasterGLInterfaceAccountToolStripMenuItem, Me.MasterSatuanToolStripMenuItem, Me.MasterShippingViaToolStripMenuItem, Me.MasterGudangToolStripMenuItem, Me.GenerateReportToolsToolStripMenuItem})
        Me.ManageMasterToolStripMenuItem.Name = "ManageMasterToolStripMenuItem"
        Me.ManageMasterToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.ManageMasterToolStripMenuItem.Text = "Manage Master"
        '
        'MasterItemToolStripMenuItem
        '
        Me.MasterItemToolStripMenuItem.Image = CType(resources.GetObject("MasterItemToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MasterItemToolStripMenuItem.Name = "MasterItemToolStripMenuItem"
        Me.MasterItemToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MasterItemToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterItemToolStripMenuItem.Text = "Master Item"
        '
        'MasterVendorToolStripMenuItem
        '
        Me.MasterVendorToolStripMenuItem.Image = CType(resources.GetObject("MasterVendorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MasterVendorToolStripMenuItem.Name = "MasterVendorToolStripMenuItem"
        Me.MasterVendorToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.MasterVendorToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterVendorToolStripMenuItem.Text = "Master Vendor/Supplier"
        '
        'MasterCustomerToolStripMenuItem
        '
        Me.MasterCustomerToolStripMenuItem.Image = CType(resources.GetObject("MasterCustomerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MasterCustomerToolStripMenuItem.Name = "MasterCustomerToolStripMenuItem"
        Me.MasterCustomerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.MasterCustomerToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterCustomerToolStripMenuItem.Text = "Master Customer"
        '
        'MasterItemClassToolStripMenuItem
        '
        Me.MasterItemClassToolStripMenuItem.Image = CType(resources.GetObject("MasterItemClassToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MasterItemClassToolStripMenuItem.Name = "MasterItemClassToolStripMenuItem"
        Me.MasterItemClassToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.MasterItemClassToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterItemClassToolStripMenuItem.Text = "Master Item Class"
        '
        'MasterBankToolStripMenuItem
        '
        Me.MasterBankToolStripMenuItem.Name = "MasterBankToolStripMenuItem"
        Me.MasterBankToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterBankToolStripMenuItem.Text = "Master Bank"
        Me.MasterBankToolStripMenuItem.Visible = False
        '
        'MasterGLInterfaceAccountToolStripMenuItem
        '
        Me.MasterGLInterfaceAccountToolStripMenuItem.Name = "MasterGLInterfaceAccountToolStripMenuItem"
        Me.MasterGLInterfaceAccountToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterGLInterfaceAccountToolStripMenuItem.Text = "Master GL Interface Account"
        Me.MasterGLInterfaceAccountToolStripMenuItem.Visible = False
        '
        'MasterSatuanToolStripMenuItem
        '
        Me.MasterSatuanToolStripMenuItem.Name = "MasterSatuanToolStripMenuItem"
        Me.MasterSatuanToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterSatuanToolStripMenuItem.Text = "Master Satuan"
        Me.MasterSatuanToolStripMenuItem.Visible = False
        '
        'MasterShippingViaToolStripMenuItem
        '
        Me.MasterShippingViaToolStripMenuItem.Name = "MasterShippingViaToolStripMenuItem"
        Me.MasterShippingViaToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterShippingViaToolStripMenuItem.Text = "Master Shipping Via"
        Me.MasterShippingViaToolStripMenuItem.Visible = False
        '
        'MasterGudangToolStripMenuItem
        '
        Me.MasterGudangToolStripMenuItem.Image = CType(resources.GetObject("MasterGudangToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MasterGudangToolStripMenuItem.Name = "MasterGudangToolStripMenuItem"
        Me.MasterGudangToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MasterGudangToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterGudangToolStripMenuItem.Text = "Master Gudang"
        '
        'GenerateReportToolsToolStripMenuItem
        '
        Me.GenerateReportToolsToolStripMenuItem.Name = "GenerateReportToolsToolStripMenuItem"
        Me.GenerateReportToolsToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.GenerateReportToolsToolStripMenuItem.Text = "Generate Report Tools"
        Me.GenerateReportToolsToolStripMenuItem.Visible = False
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseToolStripMenuItem, Me.SalesToolStripMenuItem, Me.RetailToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseOrderToolStripMenuItem, Me.ReceiveItemsToolStripMenuItem, Me.PurchaseInvoiceToolStripMenuItem, Me.PurchasePaymentToolStripMenuItem})
        Me.PurchaseToolStripMenuItem.Enabled = False
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'PurchaseOrderToolStripMenuItem
        '
        Me.PurchaseOrderToolStripMenuItem.Image = CType(resources.GetObject("PurchaseOrderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PurchaseOrderToolStripMenuItem.Name = "PurchaseOrderToolStripMenuItem"
        Me.PurchaseOrderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.PurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.PurchaseOrderToolStripMenuItem.Text = "Purchase Order"
        '
        'ReceiveItemsToolStripMenuItem
        '
        Me.ReceiveItemsToolStripMenuItem.Image = CType(resources.GetObject("ReceiveItemsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReceiveItemsToolStripMenuItem.Name = "ReceiveItemsToolStripMenuItem"
        Me.ReceiveItemsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReceiveItemsToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.ReceiveItemsToolStripMenuItem.Text = "Receive Items"
        '
        'PurchaseInvoiceToolStripMenuItem
        '
        Me.PurchaseInvoiceToolStripMenuItem.Image = CType(resources.GetObject("PurchaseInvoiceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PurchaseInvoiceToolStripMenuItem.Name = "PurchaseInvoiceToolStripMenuItem"
        Me.PurchaseInvoiceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.PurchaseInvoiceToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.PurchaseInvoiceToolStripMenuItem.Text = "Purchase Invoice"
        '
        'PurchasePaymentToolStripMenuItem
        '
        Me.PurchasePaymentToolStripMenuItem.Image = CType(resources.GetObject("PurchasePaymentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PurchasePaymentToolStripMenuItem.Name = "PurchasePaymentToolStripMenuItem"
        Me.PurchasePaymentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.PurchasePaymentToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.PurchasePaymentToolStripMenuItem.Text = "Purchase Payment"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalesOrderToolStripMenuItem, Me.DeliveryOrderToolStripMenuItem, Me.SalesInvoiceToolStripMenuItem, Me.SalesReceiptToolStripMenuItem})
        Me.SalesToolStripMenuItem.Enabled = False
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'SalesOrderToolStripMenuItem
        '
        Me.SalesOrderToolStripMenuItem.Image = CType(resources.GetObject("SalesOrderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalesOrderToolStripMenuItem.Name = "SalesOrderToolStripMenuItem"
        Me.SalesOrderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.SalesOrderToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SalesOrderToolStripMenuItem.Text = "Sales Order"
        '
        'DeliveryOrderToolStripMenuItem
        '
        Me.DeliveryOrderToolStripMenuItem.Image = CType(resources.GetObject("DeliveryOrderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeliveryOrderToolStripMenuItem.Name = "DeliveryOrderToolStripMenuItem"
        Me.DeliveryOrderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.DeliveryOrderToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DeliveryOrderToolStripMenuItem.Text = "Delivery Order"
        '
        'SalesInvoiceToolStripMenuItem
        '
        Me.SalesInvoiceToolStripMenuItem.Image = CType(resources.GetObject("SalesInvoiceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalesInvoiceToolStripMenuItem.Name = "SalesInvoiceToolStripMenuItem"
        Me.SalesInvoiceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.SalesInvoiceToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SalesInvoiceToolStripMenuItem.Text = "Sales Invoice"
        '
        'SalesReceiptToolStripMenuItem
        '
        Me.SalesReceiptToolStripMenuItem.Image = CType(resources.GetObject("SalesReceiptToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalesReceiptToolStripMenuItem.Name = "SalesReceiptToolStripMenuItem"
        Me.SalesReceiptToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.SalesReceiptToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SalesReceiptToolStripMenuItem.Text = "Sales Receipt"
        '
        'RetailToolStripMenuItem
        '
        Me.RetailToolStripMenuItem.Name = "RetailToolStripMenuItem"
        Me.RetailToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.RetailToolStripMenuItem.Text = "Sales Retail"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        Me.AboutToolStripMenuItem.Visible = False
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanItemPerGudangToolStripMenuItem, Me.LaporanSalesOrderToolStripMenuItem, Me.LaporanSalesRetailToolStripMenuItem, Me.LaporanHistorySalesByItemToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'LaporanItemPerGudangToolStripMenuItem
        '
        Me.LaporanItemPerGudangToolStripMenuItem.Enabled = False
        Me.LaporanItemPerGudangToolStripMenuItem.Name = "LaporanItemPerGudangToolStripMenuItem"
        Me.LaporanItemPerGudangToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LaporanItemPerGudangToolStripMenuItem.Text = "Laporan Stok Item"
        '
        'LaporanSalesOrderToolStripMenuItem
        '
        Me.LaporanSalesOrderToolStripMenuItem.Enabled = False
        Me.LaporanSalesOrderToolStripMenuItem.Name = "LaporanSalesOrderToolStripMenuItem"
        Me.LaporanSalesOrderToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LaporanSalesOrderToolStripMenuItem.Text = "Laporan Sales Order"
        '
        'LaporanSalesRetailToolStripMenuItem
        '
        Me.LaporanSalesRetailToolStripMenuItem.Name = "LaporanSalesRetailToolStripMenuItem"
        Me.LaporanSalesRetailToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LaporanSalesRetailToolStripMenuItem.Text = "Laporan Sales Retail"
        '
        'LaporanHistorySalesByItemToolStripMenuItem
        '
        Me.LaporanHistorySalesByItemToolStripMenuItem.Enabled = False
        Me.LaporanHistorySalesByItemToolStripMenuItem.Name = "LaporanHistorySalesByItemToolStripMenuItem"
        Me.LaporanHistorySalesByItemToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LaporanHistorySalesByItemToolStripMenuItem.Text = "Laporan History Sales By Item"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainMenu"
        Me.Text = "Selamat Datang di Menu Utama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ManageUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterVendorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterItemClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterBankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterGLInterfaceAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterSatuanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterShippingViaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MasterGudangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateReportToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceiveItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchasePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeliveryOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanItemPerGudangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanSalesOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanSalesRetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanHistorySalesByItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
