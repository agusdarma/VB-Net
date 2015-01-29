Imports MySql.Data.MySqlClient

Public Class PurchaseOrder
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Private Sub PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()

    End Sub
    Private Sub inisialisasi()
        DataGridViewPO.ColumnCount = 7
        DataGridViewPO.Columns(0).Name = "Kode Item"
        DataGridViewPO.Columns(1).Name = "Nama Item"
        DataGridViewPO.Columns(2).Name = "Qty"
        DataGridViewPO.Columns(3).Name = "Satuan"
        DataGridViewPO.Columns(4).Name = "Harga Satuan"
        DataGridViewPO.Columns(5).Name = "Diskon"
        DataGridViewPO.Columns(6).Name = "Total Harga"

        'Dim n As Integer = DataGridViewPO.Rows.Add()
        'DataGridViewPO.Rows(0).Cells(0).Value = "Mesin Cuci"
        'DataGridViewPO.Rows.Item(n).Cells(1).Value = "Nama Item"

        lblPPN.Visible = False
        LblPPNValue.Visible = False
        lblTax.Visible = False
        CheckInclusiveTax.Enabled = False
        If CheckVendorTaxable.Checked = True Then
            lblPPN.Visible = True
            LblPPNValue.Visible = True
            CheckInclusiveTax.Enabled = True
        Else
            lblPPN.Visible = False
            LblPPNValue.Visible = False
            lblTax.Visible = False
            CheckInclusiveTax.Enabled = False
            CheckInclusiveTax.Checked = False
            Exit Sub
        End If
        If CheckInclusiveTax.Checked = True Then
            lblPPN.Visible = True
            LblPPNValue.Visible = True
            lblTax.Visible = True
        End If
    End Sub

    Public Sub addItemToListPO(kodeItem As String, namaItem As String, satuan As String, price As String, diskon As String)
        Dim idx As Integer = DataGridViewPO.RowCount
        idx = idx - 1
        DataGridViewPO.Rows(idx).Cells(2).Selected = True
        DataGridViewPO.CurrentCell = Me.DataGridViewPO(2, idx)
        DataGridViewPO.Rows(idx).Cells(0).Value = kodeItem
        DataGridViewPO.Rows(idx).Cells(0).ReadOnly = True
        DataGridViewPO.Rows(idx).Cells(1).Value = namaItem
        DataGridViewPO.Rows(idx).Cells(1).ReadOnly = True
        DataGridViewPO.Rows(idx).Cells(2).Value = "1"
        DataGridViewPO.Rows(idx).Cells(3).Value = satuan
        DataGridViewPO.Rows(idx).Cells(4).Value = price
        DataGridViewPO.Rows(idx).Cells(5).Value = diskon        
    End Sub
    Private Sub populateVendor()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            CmbVendor.DataSource = ds.Tables(0)
            CmbVendor.ValueMember = "id"
            CmbVendor.DisplayMember = "name_supplier"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function findSupplierById(id As Integer) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select address1,address2 from supplier where id ='" & id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                alamatVendor.Text = publictable.Rows(0).Item(0) + " " + publictable.Rows(0).Item(1)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
    End Sub

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierById(CmbVendor.SelectedValue)
    End Sub

    Private Sub cmbVendorTaxable_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckVendorTaxable.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub CheckInclusiveTax_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckInclusiveTax.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub DataGridViewPO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPO.CellDoubleClick
        If e.ColumnIndex = 0 Then
            AdvancedSearchItems.Show()
        End If
    End Sub

    Private Sub DataGridViewPO_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPO.CellEndEdit
        If e.ColumnIndex = 0 Then
            AdvancedSearchItems.Show()
        End If
    End Sub

    Private Sub DataGridViewPO_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewPO.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.rowIndex = e.RowIndex
            Me.ContextMenuStrip1.Show(Me.DataGridViewPO, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteRows_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDeleteRows.Click
        Try
            If Not Me.DataGridViewPO.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridViewPO.Rows.RemoveAt(Me.rowIndex)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItemAddRows_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAddRows.Click
        DataGridViewPO.NotifyCurrentCellDirty(True)
        DataGridViewPO.ClearSelection()
    End Sub

    Private Sub DataGridViewPO_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewPO.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Try
                Dim iColumn As Integer = DataGridViewPO.CurrentCell.ColumnIndex
                Dim iRows As Integer = DataGridViewPO.CurrentCell.RowIndex
                DataGridViewPO.ClearSelection()
                DataGridViewPO.Rows(iRows).Cells(iColumn + 1).Selected = True
                ' Set the current cell to the cell in column 1, Row 0. 
                DataGridViewPO.CurrentCell = Me.DataGridViewPO(iColumn + 1, iRows)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show(DataGridViewPO.RowCount)
    End Sub
End Class