<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserEditFrm
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
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.UserCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_Group = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UserName
        '
        Me.UserName.Location = New System.Drawing.Point(114, 89)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(230, 20)
        Me.UserName.TabIndex = 11
        '
        'UserCode
        '
        Me.UserCode.Location = New System.Drawing.Point(114, 57)
        Me.UserCode.Name = "UserCode"
        Me.UserCode.ReadOnly = True
        Me.UserCode.Size = New System.Drawing.Size(230, 20)
        Me.UserCode.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 21)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "User Name :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "User Code :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(134, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Edit User"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ComboBox_Group
        '
        Me.ComboBox_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Group.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Group.FormattingEnabled = True
        Me.ComboBox_Group.Location = New System.Drawing.Point(114, 121)
        Me.ComboBox_Group.Name = "ComboBox_Group"
        Me.ComboBox_Group.Size = New System.Drawing.Size(230, 25)
        Me.ComboBox_Group.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 21)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Group :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cancel.Location = New System.Drawing.Point(269, 166)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Button_Cancel.TabIndex = 15
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Location = New System.Drawing.Point(114, 166)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(75, 31)
        Me.Button_Save.TabIndex = 14
        Me.Button_Save.Text = "Save"
        Me.Button_Save.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'UserEditFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 242)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.ComboBox_Group)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.UserCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserEditFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserName As System.Windows.Forms.TextBox
    Friend WithEvents UserCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Group As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
End Class
