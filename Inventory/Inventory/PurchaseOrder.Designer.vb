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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.kodeVendor = New System.Windows.Forms.TextBox()
        Me.MultiColumnComboBoxVendor = New MultiColumnComboBox.MultiColumnComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
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
        Me.Label2.Location = New System.Drawing.Point(7, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Supplier / Vendor"
        '
        'kodeVendor
        '
        Me.kodeVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kodeVendor.Location = New System.Drawing.Point(9, 54)
        Me.kodeVendor.Name = "kodeVendor"
        Me.kodeVendor.Size = New System.Drawing.Size(100, 25)
        Me.kodeVendor.TabIndex = 2
        '
        'MultiColumnComboBoxVendor
        '
        Me.MultiColumnComboBoxVendor.DisplayDataMember = Nothing
        Me.MultiColumnComboBoxVendor.DisplayDataSource = Nothing
        Me.MultiColumnComboBoxVendor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiColumnComboBoxVendor.Location = New System.Drawing.Point(115, 54)
        Me.MultiColumnComboBoxVendor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MultiColumnComboBoxVendor.Name = "MultiColumnComboBoxVendor"
        Me.MultiColumnComboBoxVendor.SaveDataMember = Nothing
        Me.MultiColumnComboBoxVendor.SaveDataSource = Nothing
        Me.MultiColumnComboBoxVendor.Size = New System.Drawing.Size(294, 25)
        Me.MultiColumnComboBoxVendor.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(357, 125)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'PurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 480)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.MultiColumnComboBoxVendor)
        Me.Controls.Add(Me.kodeVendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PurchaseOrder"
        Me.Text = "Purchase Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents kodeVendor As System.Windows.Forms.TextBox
    Friend WithEvents MultiColumnComboBoxVendor As MultiColumnComboBox.MultiColumnComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
