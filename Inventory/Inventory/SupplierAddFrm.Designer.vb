<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierAddFrm
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
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.cp = New System.Windows.Forms.TextBox()
        Me.SupplierName = New System.Windows.Forms.TextBox()
        Me.SupplierCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.address1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.address2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.city = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.phone = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.hp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.fax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.website = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.disc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.credit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.npwp = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cancel.Location = New System.Drawing.Point(420, 397)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Button_Cancel.TabIndex = 16
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Location = New System.Drawing.Point(265, 397)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(75, 31)
        Me.Button_Save.TabIndex = 15
        Me.Button_Save.Text = "Save"
        Me.Button_Save.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'cp
        '
        Me.cp.Location = New System.Drawing.Point(139, 267)
        Me.cp.Name = "cp"
        Me.cp.Size = New System.Drawing.Size(567, 20)
        Me.cp.TabIndex = 12
        '
        'SupplierName
        '
        Me.SupplierName.Location = New System.Drawing.Point(136, 95)
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.Size = New System.Drawing.Size(570, 20)
        Me.SupplierName.TabIndex = 3
        '
        'SupplierCode
        '
        Me.SupplierCode.Location = New System.Drawing.Point(136, 63)
        Me.SupplierCode.Name = "SupplierCode"
        Me.SupplierCode.Size = New System.Drawing.Size(205, 20)
        Me.SupplierCode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 265)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 21)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Contact Person * :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 21)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Supplier Name * :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 21)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Supplier Code * :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Add Vendor/Supplier"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'address1
        '
        Me.address1.Location = New System.Drawing.Point(136, 121)
        Me.address1.Name = "address1"
        Me.address1.Size = New System.Drawing.Size(570, 20)
        Me.address1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(49, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 21)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Address 1 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'address2
        '
        Me.address2.Location = New System.Drawing.Point(137, 149)
        Me.address2.Name = "address2"
        Me.address2.Size = New System.Drawing.Size(570, 20)
        Me.address2.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 21)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Address 2 :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'city
        '
        Me.city.Location = New System.Drawing.Point(136, 182)
        Me.city.Name = "city"
        Me.city.Size = New System.Drawing.Size(205, 20)
        Me.city.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(89, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 21)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "City :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'phone
        '
        Me.phone.Location = New System.Drawing.Point(429, 182)
        Me.phone.Name = "phone"
        Me.phone.Size = New System.Drawing.Size(277, 20)
        Me.phone.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(362, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 21)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Phone :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'hp
        '
        Me.hp.Location = New System.Drawing.Point(429, 210)
        Me.hp.Name = "hp"
        Me.hp.Size = New System.Drawing.Size(277, 20)
        Me.hp.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(386, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 21)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "HP :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fax
        '
        Me.fax.Location = New System.Drawing.Point(429, 236)
        Me.fax.Name = "fax"
        Me.fax.Size = New System.Drawing.Size(277, 20)
        Me.fax.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(384, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 21)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Fax :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(138, 211)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(202, 20)
        Me.email.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(78, 210)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 21)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Email :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'website
        '
        Me.website.Location = New System.Drawing.Point(138, 239)
        Me.website.Name = "website"
        Me.website.Size = New System.Drawing.Size(202, 20)
        Me.website.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(61, 238)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 21)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Website :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'disc
        '
        Me.disc.Location = New System.Drawing.Point(139, 295)
        Me.disc.Name = "disc"
        Me.disc.Size = New System.Drawing.Size(567, 20)
        Me.disc.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(68, 292)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 21)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Diskon :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'credit
        '
        Me.credit.Location = New System.Drawing.Point(140, 324)
        Me.credit.Name = "credit"
        Me.credit.Size = New System.Drawing.Size(566, 20)
        Me.credit.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(34, 323)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 21)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Credit Term :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'npwp
        '
        Me.npwp.Location = New System.Drawing.Point(428, 61)
        Me.npwp.Name = "npwp"
        Me.npwp.Size = New System.Drawing.Size(279, 20)
        Me.npwp.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(362, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 21)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "NPWP :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SupplierAddFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 473)
        Me.Controls.Add(Me.npwp)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.credit)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.disc)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.website)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.email)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.fax)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.hp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.phone)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.city)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.address2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.address1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.cp)
        Me.Controls.Add(Me.SupplierName)
        Me.Controls.Add(Me.SupplierCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SupplierAddFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Vendor/Supplier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents cp As System.Windows.Forms.TextBox
    Friend WithEvents SupplierName As System.Windows.Forms.TextBox
    Friend WithEvents SupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents address1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents address2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents city As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents phone As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents hp As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents fax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents website As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents disc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents credit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents npwp As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
