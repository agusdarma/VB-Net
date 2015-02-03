Imports MySql.Data.MySqlClient

Public Class ReceiveItems
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeSupplier As String
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub populateVendor()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier order by name_supplier asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            CmbVendor.DataSource = ds.Tables(0)
            CmbVendor.ValueMember = "kode_supplier"
            CmbVendor.DisplayMember = "name_supplier"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ReceiveItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxReceiptNo.Focus()
    End Sub
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim formNoSystem As String = "RI/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxFormNo.Text = formNoSystem


        Me.DataGridViewRI.ColumnCount = 6
        Me.DataGridViewRI.Columns(0).Name = "Kode Item"
        Me.DataGridViewRI.Columns(1).Name = "Nama Item"
        Me.DataGridViewRI.Columns(2).Name = "Qty"
        Me.DataGridViewRI.Columns(3).Name = "Satuan"
        Me.DataGridViewRI.Columns(4).Name = "PO Ref"
        Me.DataGridViewRI.Columns(5).Name = "Gudang"
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from receive_item_header order by id desc limit 0,1"
            Dim scalarCommand As New MySqlCommand(Sql, con)
            idPrimary = scalarCommand.ExecuteScalar()
            idPrimary = idPrimary + 1
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try
        Return idPrimary
    End Function

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
    End Sub

    Private Sub BtnSelectPo_Click(sender As Object, e As EventArgs) Handles BtnSelectPo.Click
        If CmbVendor.SelectedIndex = -1 Then
            MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbVendor.Focus()
            Return
        End If
        If TextBoxReceiptNo.Text = "" Then
            MessageBox.Show("Receipt No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxReceiptNo.Focus()
            Return
        End If
        kodeSupplier = CmbVendor.SelectedValue
        SearchPOForm.ShowDialog()
    End Sub
    Public Sub addSelectPOToList()
        Dim listPO = New List(Of PoVO)
        listPO = SearchPOForm.listSelectPo
        DataGridViewRI.Rows.Clear()
        If DataGridViewRI.Columns.Count = 7 Then
            DataGridViewRI.Columns.RemoveAt(DataGridViewRI.Columns.Count - 1)
        End If

        DataGridViewRI.Refresh()
        For Each item As PoVO In listPO
            findItemsByPONo(item.NOPO)
        Next
        Dim cmb As New DataGridViewComboBoxColumn()
        cmb.HeaderText = "Nama Gudang"
        cmb.Name = "CmbGudang"
        Dim dt As DataTable = New DataTable()
        dt = getListGudang()
        If dt.Rows.Count > 0 Then
            cmb.ValueMember = "id"
            cmb.DisplayMember = "nama_gudang"
            cmb.DataSource = dt
            cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewRI.Columns.Add(cmb)
            DataGridViewRI.Columns(5).Visible = False
            DataGridViewRI.Columns(2).DefaultCellStyle.BackColor = Color.Aquamarine
            For Each oItem As DataGridViewRow In DataGridViewRI.Rows
                oItem.Cells("CmbGudang").Value = CInt(oItem.Cells(5).Value)
                oItem.Cells(0).ReadOnly = True
                oItem.Cells(1).ReadOnly = True
                oItem.Cells(3).ReadOnly = True
                oItem.Cells(4).ReadOnly = True
            Next
        End If        
        DataGridViewRI.Refresh()
    End Sub
    Private Function getListGudang() As DataTable
        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select id,nama_gudang from gudang order by nama_gudang asc"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return publictable
    End Function
    Private Sub findItemsByPONo(poNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,g.id,ph.po_no from purchase_order_header ph left join purchase_order_detail pd on ph.id = pd.po_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.po_no ='" & poNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then                
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("po_no").ToString(), oRecord("id").ToString()}
                    DataGridViewRI.Rows.Add(row)
                Next                
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridViewRI_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRI.CellClick
        If e.ColumnIndex = 2 Then
            DataGridViewRI.ClearSelection()
            DataGridViewRI.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            ' Set the current cell to the cell in column 2, Row 0. 
            DataGridViewRI.CurrentCell = Me.DataGridViewRI(e.ColumnIndex, e.RowIndex)
            DataGridViewRI.BeginEdit(True)
            'ElseIf e.ColumnIndex = 6 Then
            '    DataGridViewRI.ClearSelection()
            '    DataGridViewRI.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            '    ' Set the current cell to the cell in column 1, Row 0. 
            '    DataGridViewRI.CurrentCell = Me.DataGridViewRI(e.ColumnIndex, e.RowIndex)
            '    DataGridViewRI.BeginEdit(True)
        End If
    End Sub

    Private Sub DataGridViewRI_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewRI.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
    End Sub

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierByKode(CmbVendor.SelectedValue)
    End Sub
    Private Function findSupplierByKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select address1,address2,kode_supplier,name_supplier from supplier where kode_supplier ='" & kode & "'"
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
End Class