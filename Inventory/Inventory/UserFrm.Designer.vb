<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserFrm
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
        Me.GridUser = New System.Windows.Forms.DataGridView()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnLastpage = New System.Windows.Forms.Button()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(293, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Management"
        '
        'GridUser
        '
        Me.GridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUser.Location = New System.Drawing.Point(12, 52)
        Me.GridUser.Name = "GridUser"
        Me.GridUser.Size = New System.Drawing.Size(761, 223)
        Me.GridUser.TabIndex = 1
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(25, 282)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(75, 23)
        Me.btnFirst.TabIndex = 2
        Me.btnFirst.Text = "First Page"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnNextPage
        '
        Me.btnNextPage.Location = New System.Drawing.Point(106, 282)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Size = New System.Drawing.Size(75, 23)
        Me.btnNextPage.TabIndex = 3
        Me.btnNextPage.Text = "Next Page"
        Me.btnNextPage.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(187, 282)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.btnPrevious.TabIndex = 4
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnLastpage
        '
        Me.btnLastpage.Location = New System.Drawing.Point(268, 281)
        Me.btnLastpage.Name = "btnLastpage"
        Me.btnLastpage.Size = New System.Drawing.Size(75, 23)
        Me.btnLastpage.TabIndex = 5
        Me.btnLastpage.Text = "Last Page"
        Me.btnLastpage.UseVisualStyleBackColor = True
        '
        'UserFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 493)
        Me.Controls.Add(Me.btnLastpage)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNextPage)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.GridUser)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserFrm"
        Me.Text = "User Management"
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridUser As System.Windows.Forms.DataGridView
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnNextPage As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnLastpage As System.Windows.Forms.Button
End Class
