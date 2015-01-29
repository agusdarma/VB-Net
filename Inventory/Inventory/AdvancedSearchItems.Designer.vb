<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedSearchItems
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
        Me.labelCurrentPage = New System.Windows.Forms.Label()
        Me.Label_Showing_Pages = New System.Windows.Forms.Label()
        Me.Label_TotalRecord = New System.Windows.Forms.Label()
        Me.LinkLabel_FirstPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_Previous = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_LastPage = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_NextPage = New System.Windows.Forms.LinkLabel()
        Me.GridItemSearch = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Filter = New System.Windows.Forms.Button()
        CType(Me.GridItemSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelCurrentPage
        '
        Me.labelCurrentPage.AutoSize = True
        Me.labelCurrentPage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentPage.Location = New System.Drawing.Point(79, 106)
        Me.labelCurrentPage.Name = "labelCurrentPage"
        Me.labelCurrentPage.Size = New System.Drawing.Size(15, 17)
        Me.labelCurrentPage.TabIndex = 28
        Me.labelCurrentPage.Text = "1"
        '
        'Label_Showing_Pages
        '
        Me.Label_Showing_Pages.AutoSize = True
        Me.Label_Showing_Pages.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label_Showing_Pages.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_Showing_Pages.Location = New System.Drawing.Point(451, 108)
        Me.Label_Showing_Pages.Name = "Label_Showing_Pages"
        Me.Label_Showing_Pages.Size = New System.Drawing.Size(112, 19)
        Me.Label_Showing_Pages.TabIndex = 26
        Me.Label_Showing_Pages.Text = "Showing page :"
        '
        'Label_TotalRecord
        '
        Me.Label_TotalRecord.AutoSize = True
        Me.Label_TotalRecord.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label_TotalRecord.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label_TotalRecord.Location = New System.Drawing.Point(639, 108)
        Me.Label_TotalRecord.Name = "Label_TotalRecord"
        Me.Label_TotalRecord.Size = New System.Drawing.Size(109, 19)
        Me.Label_TotalRecord.TabIndex = 25
        Me.Label_TotalRecord.Text = "Total Records :"
        '
        'LinkLabel_FirstPage
        '
        Me.LinkLabel_FirstPage.AutoSize = True
        Me.LinkLabel_FirstPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_FirstPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_FirstPage.Location = New System.Drawing.Point(15, 102)
        Me.LinkLabel_FirstPage.Name = "LinkLabel_FirstPage"
        Me.LinkLabel_FirstPage.Size = New System.Drawing.Size(36, 25)
        Me.LinkLabel_FirstPage.TabIndex = 24
        Me.LinkLabel_FirstPage.TabStop = True
        Me.LinkLabel_FirstPage.Text = "<<"
        '
        'LinkLabel_Previous
        '
        Me.LinkLabel_Previous.AutoSize = True
        Me.LinkLabel_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_Previous.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_Previous.Location = New System.Drawing.Point(47, 102)
        Me.LinkLabel_Previous.Name = "LinkLabel_Previous"
        Me.LinkLabel_Previous.Size = New System.Drawing.Size(24, 25)
        Me.LinkLabel_Previous.TabIndex = 23
        Me.LinkLabel_Previous.TabStop = True
        Me.LinkLabel_Previous.Text = "<"
        '
        'LinkLabel_LastPage
        '
        Me.LinkLabel_LastPage.AutoSize = True
        Me.LinkLabel_LastPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_LastPage.Location = New System.Drawing.Point(127, 102)
        Me.LinkLabel_LastPage.Name = "LinkLabel_LastPage"
        Me.LinkLabel_LastPage.Size = New System.Drawing.Size(36, 25)
        Me.LinkLabel_LastPage.TabIndex = 22
        Me.LinkLabel_LastPage.TabStop = True
        Me.LinkLabel_LastPage.Text = ">>"
        '
        'LinkLabel_NextPage
        '
        Me.LinkLabel_NextPage.AutoSize = True
        Me.LinkLabel_NextPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel_NextPage.ForeColor = System.Drawing.Color.Blue
        Me.LinkLabel_NextPage.Location = New System.Drawing.Point(104, 102)
        Me.LinkLabel_NextPage.Name = "LinkLabel_NextPage"
        Me.LinkLabel_NextPage.Size = New System.Drawing.Size(24, 25)
        Me.LinkLabel_NextPage.TabIndex = 21
        Me.LinkLabel_NextPage.TabStop = True
        Me.LinkLabel_NextPage.Text = ">"
        '
        'GridItemSearch
        '
        Me.GridItemSearch.AllowUserToAddRows = False
        Me.GridItemSearch.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle1.NullValue = "Empty"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Cornsilk
        Me.GridItemSearch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridItemSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridItemSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridItemSearch.BackgroundColor = System.Drawing.Color.White
        Me.GridItemSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridItemSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridItemSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridItemSearch.ColumnHeadersHeight = 40
        Me.GridItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridItemSearch.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = "Empty"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridItemSearch.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridItemSearch.GridColor = System.Drawing.Color.DarkOrange
        Me.GridItemSearch.Location = New System.Drawing.Point(1, 140)
        Me.GridItemSearch.MultiSelect = False
        Me.GridItemSearch.Name = "GridItemSearch"
        Me.GridItemSearch.ReadOnly = True
        Me.GridItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridItemSearch.Size = New System.Drawing.Size(776, 314)
        Me.GridItemSearch.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(249, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 28)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Advanced Search Items"
        '
        'Filter
        '
        Me.Filter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Filter.Location = New System.Drawing.Point(20, 69)
        Me.Filter.Name = "Filter"
        Me.Filter.Size = New System.Drawing.Size(113, 30)
        Me.Filter.TabIndex = 39
        Me.Filter.Text = "Filter Off"
        Me.Filter.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Filter.UseVisualStyleBackColor = True
        '
        'AdvancedSearchItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 453)
        Me.Controls.Add(Me.Filter)
        Me.Controls.Add(Me.labelCurrentPage)
        Me.Controls.Add(Me.Label_Showing_Pages)
        Me.Controls.Add(Me.Label_TotalRecord)
        Me.Controls.Add(Me.LinkLabel_FirstPage)
        Me.Controls.Add(Me.LinkLabel_Previous)
        Me.Controls.Add(Me.LinkLabel_LastPage)
        Me.Controls.Add(Me.LinkLabel_NextPage)
        Me.Controls.Add(Me.GridItemSearch)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AdvancedSearchItems"
        Me.Text = "Pilih Item"
        CType(Me.GridItemSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelCurrentPage As System.Windows.Forms.Label
    Friend WithEvents Label_Showing_Pages As System.Windows.Forms.Label
    Friend WithEvents Label_TotalRecord As System.Windows.Forms.Label
    Friend WithEvents LinkLabel_FirstPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_Previous As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_LastPage As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_NextPage As System.Windows.Forms.LinkLabel
    Friend WithEvents GridItemSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Filter As System.Windows.Forms.Button
End Class
