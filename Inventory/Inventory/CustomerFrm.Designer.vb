﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerFrm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Filter = New System.Windows.Forms.Button()
        Me.Button_delete = New System.Windows.Forms.Button()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.Button_Add = New System.Windows.Forms.Button()
        Me.Label_Showing_Pages = New System.Windows.Forms.Label()
        Me.Label_TotalRecord = New System.Windows.Forms.Label()
        Me.GridCustomer = New System.Windows.Forms.DataGridView()
        Me.labelCurrentPage = New System.Windows.Forms.Label()
        Me.LinkLabel_FirstPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_Previous = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_LastPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_NextPage = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Filter
        '
        Me.Filter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Filter.Location = New System.Drawing.Point(370, 443)
        Me.Filter.Name = "Filter"
        Me.Filter.Size = New System.Drawing.Size(113, 30)
        Me.Filter.TabIndex = 38
        Me.Filter.Text = "Filter Off"
        Me.Filter.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Filter.UseVisualStyleBackColor = True
        '
        'Button_delete
        '
        Me.Button_delete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_delete.Location = New System.Drawing.Point(251, 443)
        Me.Button_delete.Name = "Button_delete"
        Me.Button_delete.Size = New System.Drawing.Size(113, 30)
        Me.Button_delete.TabIndex = 37
        Me.Button_delete.Text = "Delete"
        Me.Button_delete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_delete.UseVisualStyleBackColor = True
        '
        'Button_Edit
        '
        Me.Button_Edit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Edit.Location = New System.Drawing.Point(132, 443)
        Me.Button_Edit.Name = "Button_Edit"
        Me.Button_Edit.Size = New System.Drawing.Size(113, 30)
        Me.Button_Edit.TabIndex = 36
        Me.Button_Edit.Text = "Edit"
        Me.Button_Edit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'Button_Add
        '
        Me.Button_Add.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Add.Location = New System.Drawing.Point(15, 443)
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Size = New System.Drawing.Size(113, 30)
        Me.Button_Add.TabIndex = 35
        Me.Button_Add.Text = "Add"
        Me.Button_Add.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Add.UseVisualStyleBackColor = True
        '
        'Label_Showing_Pages
        '
        Me.Label_Showing_Pages.AutoSize = True
        Me.Label_Showing_Pages.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Showing_Pages.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_Showing_Pages.Location = New System.Drawing.Point(738, 110)
        Me.Label_Showing_Pages.Name = "Label_Showing_Pages"
        Me.Label_Showing_Pages.Size = New System.Drawing.Size(103, 17)
        Me.Label_Showing_Pages.TabIndex = 34
        Me.Label_Showing_Pages.Text = "Showing page :"
        '
        'Label_TotalRecord
        '
        Me.Label_TotalRecord.AutoSize = True
        Me.Label_TotalRecord.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TotalRecord.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_TotalRecord.Location = New System.Drawing.Point(926, 110)
        Me.Label_TotalRecord.Name = "Label_TotalRecord"
        Me.Label_TotalRecord.Size = New System.Drawing.Size(100, 17)
        Me.Label_TotalRecord.TabIndex = 33
        Me.Label_TotalRecord.Text = "Total Records :"
        '
        'GridCustomer
        '
        Me.GridCustomer.AllowUserToAddRows = False
        Me.GridCustomer.AllowUserToDeleteRows = False
        Me.GridCustomer.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.NullValue = "Empty"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Cornsilk
        Me.GridCustomer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridCustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridCustomer.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridCustomer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridCustomer.ColumnHeadersHeight = 30
        Me.GridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridCustomer.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = "Empty"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridCustomer.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridCustomer.EnableHeadersVisualStyles = False
        Me.GridCustomer.Location = New System.Drawing.Point(15, 137)
        Me.GridCustomer.MultiSelect = False
        Me.GridCustomer.Name = "GridCustomer"
        Me.GridCustomer.ReadOnly = True
        Me.GridCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridCustomer.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridCustomer.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.GridCustomer.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GridCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCustomer.Size = New System.Drawing.Size(1049, 300)
        Me.GridCustomer.TabIndex = 32
        '
        'labelCurrentPage
        '
        Me.labelCurrentPage.AutoSize = True
        Me.labelCurrentPage.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentPage.Location = New System.Drawing.Point(99, 101)
        Me.labelCurrentPage.Name = "labelCurrentPage"
        Me.labelCurrentPage.Size = New System.Drawing.Size(25, 30)
        Me.labelCurrentPage.TabIndex = 31
        Me.labelCurrentPage.Text = "1"
        '
        'LinkLabel_FirstPage
        '
        Me.LinkLabel_FirstPage.AutoSize = True
        Me.LinkLabel_FirstPage.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_FirstPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_FirstPage.Location = New System.Drawing.Point(9, 97)
        Me.LinkLabel_FirstPage.Name = "LinkLabel_FirstPage"
        Me.LinkLabel_FirstPage.Size = New System.Drawing.Size(43, 30)
        Me.LinkLabel_FirstPage.TabIndex = 30
        Me.LinkLabel_FirstPage.TabStop = True
        Me.LinkLabel_FirstPage.Text = "<<"
        '
        'LinkLabel_Previous
        '
        Me.LinkLabel_Previous.AutoSize = True
        Me.LinkLabel_Previous.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_Previous.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_Previous.Location = New System.Drawing.Point(64, 97)
        Me.LinkLabel_Previous.Name = "LinkLabel_Previous"
        Me.LinkLabel_Previous.Size = New System.Drawing.Size(28, 30)
        Me.LinkLabel_Previous.TabIndex = 29
        Me.LinkLabel_Previous.TabStop = True
        Me.LinkLabel_Previous.Text = "<"
        '
        'LinkLabel_LastPage
        '
        Me.LinkLabel_LastPage.AutoSize = True
        Me.LinkLabel_LastPage.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_LastPage.Location = New System.Drawing.Point(161, 99)
        Me.LinkLabel_LastPage.Name = "LinkLabel_LastPage"
        Me.LinkLabel_LastPage.Size = New System.Drawing.Size(43, 30)
        Me.LinkLabel_LastPage.TabIndex = 28
        Me.LinkLabel_LastPage.TabStop = True
        Me.LinkLabel_LastPage.Text = ">>"
        '
        'LinkLabel_NextPage
        '
        Me.LinkLabel_NextPage.AutoSize = True
        Me.LinkLabel_NextPage.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_NextPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_NextPage.Location = New System.Drawing.Point(129, 98)
        Me.LinkLabel_NextPage.Name = "LinkLabel_NextPage"
        Me.LinkLabel_NextPage.Size = New System.Drawing.Size(28, 30)
        Me.LinkLabel_NextPage.TabIndex = 27
        Me.LinkLabel_NextPage.TabStop = True
        Me.LinkLabel_NextPage.Text = ">"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(403, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 25)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Master Customer"
        '
        'CustomerFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 494)
        Me.Controls.Add(Me.Filter)
        Me.Controls.Add(Me.Button_delete)
        Me.Controls.Add(Me.Button_Edit)
        Me.Controls.Add(Me.Button_Add)
        Me.Controls.Add(Me.Label_Showing_Pages)
        Me.Controls.Add(Me.Label_TotalRecord)
        Me.Controls.Add(Me.GridCustomer)
        Me.Controls.Add(Me.labelCurrentPage)
        Me.Controls.Add(Me.LinkLabel_FirstPage)
        Me.Controls.Add(Me.LinkLabel_Previous)
        Me.Controls.Add(Me.LinkLabel_LastPage)
        Me.Controls.Add(Me.LinkLabel_NextPage)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CustomerFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Customer"
        CType(Me.GridCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Filter As System.Windows.Forms.Button
    Friend WithEvents Button_delete As System.Windows.Forms.Button
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Button_Add As System.Windows.Forms.Button
    Friend WithEvents Label_Showing_Pages As System.Windows.Forms.Label
    Friend WithEvents Label_TotalRecord As System.Windows.Forms.Label
    Friend WithEvents GridCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents labelCurrentPage As System.Windows.Forms.Label
    Friend WithEvents LinkLabel_FirstPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_Previous As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_LastPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_NextPage As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
