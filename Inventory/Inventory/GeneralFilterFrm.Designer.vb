<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneralFilterFrm
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbField = New System.Windows.Forms.ComboBox()
        Me.CmbCondition = New System.Windows.Forms.ComboBox()
        Me.InputValue = New System.Windows.Forms.TextBox()
        Me.Search = New System.Windows.Forms.Button()
        Me.ClearFIlter = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AddFIlter = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Field :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(4, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select Condition :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(9, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Input Value :"
        '
        'CmbField
        '
        Me.CmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbField.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CmbField.FormattingEnabled = True
        Me.CmbField.Location = New System.Drawing.Point(137, 18)
        Me.CmbField.Name = "CmbField"
        Me.CmbField.Size = New System.Drawing.Size(278, 29)
        Me.CmbField.TabIndex = 3
        '
        'CmbCondition
        '
        Me.CmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCondition.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CmbCondition.FormattingEnabled = True
        Me.CmbCondition.Location = New System.Drawing.Point(137, 52)
        Me.CmbCondition.Name = "CmbCondition"
        Me.CmbCondition.Size = New System.Drawing.Size(278, 29)
        Me.CmbCondition.TabIndex = 4
        '
        'InputValue
        '
        Me.InputValue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.InputValue.Location = New System.Drawing.Point(137, 85)
        Me.InputValue.Name = "InputValue"
        Me.InputValue.Size = New System.Drawing.Size(278, 29)
        Me.InputValue.TabIndex = 5
        '
        'Search
        '
        Me.Search.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Search.Location = New System.Drawing.Point(61, 265)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 34)
        Me.Search.TabIndex = 7
        Me.Search.Text = "Search"
        Me.Search.UseVisualStyleBackColor = True
        '
        'ClearFIlter
        '
        Me.ClearFIlter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ClearFIlter.Location = New System.Drawing.Point(164, 265)
        Me.ClearFIlter.Name = "ClearFIlter"
        Me.ClearFIlter.Size = New System.Drawing.Size(75, 34)
        Me.ClearFIlter.TabIndex = 8
        Me.ClearFIlter.Text = "Clear FIlter"
        Me.ClearFIlter.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ClearFIlter.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Cancel.Location = New System.Drawing.Point(285, 265)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 34)
        Me.Cancel.TabIndex = 9
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Filter By :"
        '
        'AddFIlter
        '
        Me.AddFIlter.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.AddFIlter.Location = New System.Drawing.Point(160, 120)
        Me.AddFIlter.Name = "AddFIlter"
        Me.AddFIlter.Size = New System.Drawing.Size(101, 34)
        Me.AddFIlter.TabIndex = 6
        Me.AddFIlter.Text = "Add FIlter"
        Me.AddFIlter.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 21
        Me.ListBox1.Location = New System.Drawing.Point(85, 161)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(330, 88)
        Me.ListBox1.TabIndex = 12
        '
        'GeneralFilterFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 307)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.AddFIlter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.ClearFIlter)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.InputValue)
        Me.Controls.Add(Me.CmbCondition)
        Me.Controls.Add(Me.CmbField)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GeneralFilterFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filter Master Supplier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbField As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents InputValue As System.Windows.Forms.TextBox
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents ClearFIlter As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AddFIlter As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
