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
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem, Me.ManageUserToolStripMenuItem, Me.ManageMasterToolStripMenuItem, Me.AboutToolStripMenuItem})
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
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.UserManagementToolStripMenuItem.Text = "User Management"
        '
        'GroupManagementToolStripMenuItem
        '
        Me.GroupManagementToolStripMenuItem.Name = "GroupManagementToolStripMenuItem"
        Me.GroupManagementToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.GroupManagementToolStripMenuItem.Text = "Group Management"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'ResetPasswordToolStripMenuItem
        '
        Me.ResetPasswordToolStripMenuItem.Name = "ResetPasswordToolStripMenuItem"
        Me.ResetPasswordToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ResetPasswordToolStripMenuItem.Text = "Reset Password"
        '
        'ManageMasterToolStripMenuItem
        '
        Me.ManageMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterItemToolStripMenuItem, Me.MasterVendorToolStripMenuItem, Me.MasterCustomerToolStripMenuItem, Me.MasterItemClassToolStripMenuItem, Me.MasterBankToolStripMenuItem, Me.MasterGLInterfaceAccountToolStripMenuItem, Me.MasterSatuanToolStripMenuItem, Me.MasterShippingViaToolStripMenuItem})
        Me.ManageMasterToolStripMenuItem.Name = "ManageMasterToolStripMenuItem"
        Me.ManageMasterToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.ManageMasterToolStripMenuItem.Text = "Manage Master"
        '
        'MasterItemToolStripMenuItem
        '
        Me.MasterItemToolStripMenuItem.Name = "MasterItemToolStripMenuItem"
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
        Me.MasterItemClassToolStripMenuItem.Name = "MasterItemClassToolStripMenuItem"
        Me.MasterItemClassToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterItemClassToolStripMenuItem.Text = "Master Item Class"
        '
        'MasterBankToolStripMenuItem
        '
        Me.MasterBankToolStripMenuItem.Name = "MasterBankToolStripMenuItem"
        Me.MasterBankToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterBankToolStripMenuItem.Text = "Master Bank"
        '
        'MasterGLInterfaceAccountToolStripMenuItem
        '
        Me.MasterGLInterfaceAccountToolStripMenuItem.Name = "MasterGLInterfaceAccountToolStripMenuItem"
        Me.MasterGLInterfaceAccountToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterGLInterfaceAccountToolStripMenuItem.Text = "Master GL Interface Account"
        '
        'MasterSatuanToolStripMenuItem
        '
        Me.MasterSatuanToolStripMenuItem.Name = "MasterSatuanToolStripMenuItem"
        Me.MasterSatuanToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterSatuanToolStripMenuItem.Text = "Master Satuan"
        '
        'MasterShippingViaToolStripMenuItem
        '
        Me.MasterShippingViaToolStripMenuItem.Name = "MasterShippingViaToolStripMenuItem"
        Me.MasterShippingViaToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MasterShippingViaToolStripMenuItem.Text = "Master Shipping Via"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
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

End Class
