<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelCurrentPage = New System.Windows.Forms.Label()
        Me.LinkLabel_FirstPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_Previous = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_LastPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_NextPage = New System.Windows.Forms.LinkLabel()
        Me.Label_Showing_Pages = New System.Windows.Forms.Label()
        Me.Label_TotalRecord = New System.Windows.Forms.Label()
        Me.GridSupplier = New System.Windows.Forms.DataGridView()
        Me.Button_delete = New System.Windows.Forms.Button()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.Button_Add = New System.Windows.Forms.Button()
        CType(Me.GridSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(242, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Master Vendor/Supplier"
        '
        'labelCurrentPage
        '
        Me.labelCurrentPage.AutoSize = True
        Me.labelCurrentPage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentPage.Location = New System.Drawing.Point(76, 70)
        Me.labelCurrentPage.Name = "labelCurrentPage"
        Me.labelCurrentPage.Size = New System.Drawing.Size(15, 17)
        Me.labelCurrentPage.TabIndex = 18
        Me.labelCurrentPage.Text = "1"
        '
        'LinkLabel_FirstPage
        '
        Me.LinkLabel_FirstPage.AutoSize = True
        Me.LinkLabel_FirstPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_FirstPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_FirstPage.Location = New System.Drawing.Point(12, 66)
        Me.LinkLabel_FirstPage.Name = "LinkLabel_FirstPage"
        Me.LinkLabel_FirstPage.Size = New System.Drawing.Size(36, 25)
        Me.LinkLabel_FirstPage.TabIndex = 17
        Me.LinkLabel_FirstPage.TabStop = True
        Me.LinkLabel_FirstPage.Text = "<<"
        '
        'LinkLabel_Previous
        '
        Me.LinkLabel_Previous.AutoSize = True
        Me.LinkLabel_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_Previous.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_Previous.Location = New System.Drawing.Point(44, 66)
        Me.LinkLabel_Previous.Name = "LinkLabel_Previous"
        Me.LinkLabel_Previous.Size = New System.Drawing.Size(24, 25)
        Me.LinkLabel_Previous.TabIndex = 16
        Me.LinkLabel_Previous.TabStop = True
        Me.LinkLabel_Previous.Text = "<"
        '
        'LinkLabel_LastPage
        '
        Me.LinkLabel_LastPage.AutoSize = True
        Me.LinkLabel_LastPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_LastPage.Location = New System.Drawing.Point(124, 66)
        Me.LinkLabel_LastPage.Name = "LinkLabel_LastPage"
        Me.LinkLabel_LastPage.Size = New System.Drawing.Size(36, 25)
        Me.LinkLabel_LastPage.TabIndex = 15
        Me.LinkLabel_LastPage.TabStop = True
        Me.LinkLabel_LastPage.Text = ">>"
        '
        'LinkLabel_NextPage
        '
        Me.LinkLabel_NextPage.AutoSize = True
        Me.LinkLabel_NextPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_NextPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_NextPage.Location = New System.Drawing.Point(101, 66)
        Me.LinkLabel_NextPage.Name = "LinkLabel_NextPage"
        Me.LinkLabel_NextPage.Size = New System.Drawing.Size(24, 25)
        Me.LinkLabel_NextPage.TabIndex = 14
        Me.LinkLabel_NextPage.TabStop = True
        Me.LinkLabel_NextPage.Text = ">"
        '
        'Label_Showing_Pages
        '
        Me.Label_Showing_Pages.AutoSize = True
        Me.Label_Showing_Pages.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label_Showing_Pages.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_Showing_Pages.Location = New System.Drawing.Point(456, 71)
        Me.Label_Showing_Pages.Name = "Label_Showing_Pages"
        Me.Label_Showing_Pages.Size = New System.Drawing.Size(112, 19)
        Me.Label_Showing_Pages.TabIndex = 21
        Me.Label_Showing_Pages.Text = "Showing page :"
        '
        'Label_TotalRecord
        '
        Me.Label_TotalRecord.AutoSize = True
        Me.Label_TotalRecord.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label_TotalRecord.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_TotalRecord.Location = New System.Drawing.Point(644, 71)
        Me.Label_TotalRecord.Name = "Label_TotalRecord"
        Me.Label_TotalRecord.Size = New System.Drawing.Size(109, 19)
        Me.Label_TotalRecord.TabIndex = 20
        Me.Label_TotalRecord.Text = "Total Records :"
        '
        'GridSupplier
        '
        Me.GridSupplier.AllowUserToAddRows = False
        Me.GridSupplier.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle1.NullValue = "Empty"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Cornsilk
        Me.GridSupplier.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridSupplier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridSupplier.BackgroundColor = System.Drawing.Color.White
        Me.GridSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridSupplier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridSupplier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridSupplier.ColumnHeadersHeight = 40
        Me.GridSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = "Empty"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridSupplier.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridSupplier.GridColor = System.Drawing.Color.DarkOrange
        Me.GridSupplier.Location = New System.Drawing.Point(12, 124)
        Me.GridSupplier.MultiSelect = False
        Me.GridSupplier.Name = "GridSupplier"
        Me.GridSupplier.ReadOnly = True
        Me.GridSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridSupplier.Size = New System.Drawing.Size(753, 300)
        Me.GridSupplier.TabIndex = 19
        '
        'Button_delete
        '
        Me.Button_delete.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_delete.Location = New System.Drawing.Point(174, 430)
        Me.Button_delete.Name = "Button_delete"
        Me.Button_delete.Size = New System.Drawing.Size(75, 30)
        Me.Button_delete.TabIndex = 24
        Me.Button_delete.Text = "Delete"
        Me.Button_delete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_delete.UseVisualStyleBackColor = True
        '
        'Button_Edit
        '
        Me.Button_Edit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Edit.Location = New System.Drawing.Point(93, 430)
        Me.Button_Edit.Name = "Button_Edit"
        Me.Button_Edit.Size = New System.Drawing.Size(75, 30)
        Me.Button_Edit.TabIndex = 23
        Me.Button_Edit.Text = "Edit"
        Me.Button_Edit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'Button_Add
        '
        Me.Button_Add.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Add.Location = New System.Drawing.Point(12, 430)
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Size = New System.Drawing.Size(75, 30)
        Me.Button_Add.TabIndex = 22
        Me.Button_Add.Text = "Add"
        Me.Button_Add.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Add.UseVisualStyleBackColor = True
        '
        'SupplierFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 494)
        Me.Controls.Add(Me.Button_delete)
        Me.Controls.Add(Me.Button_Edit)
        Me.Controls.Add(Me.Button_Add)
        Me.Controls.Add(Me.Label_Showing_Pages)
        Me.Controls.Add(Me.Label_TotalRecord)
        Me.Controls.Add(Me.GridSupplier)
        Me.Controls.Add(Me.labelCurrentPage)
        Me.Controls.Add(Me.LinkLabel_FirstPage)
        Me.Controls.Add(Me.LinkLabel_Previous)
        Me.Controls.Add(Me.LinkLabel_LastPage)
        Me.Controls.Add(Me.LinkLabel_NextPage)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SupplierFrm"
        Me.Text = "Master Vendor/Supplier"
        CType(Me.GridSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents labelCurrentPage As System.Windows.Forms.Label
    Friend WithEvents LinkLabel_FirstPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_Previous As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_LastPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_NextPage As System.Windows.Forms.LinkLabel
    Friend WithEvents Label_Showing_Pages As System.Windows.Forms.Label
    Friend WithEvents Label_TotalRecord As System.Windows.Forms.Label
    Friend WithEvents GridSupplier As System.Windows.Forms.DataGridView
    Friend WithEvents Button_delete As System.Windows.Forms.Button
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Button_Add As System.Windows.Forms.Button
End Class
