Imports MySql.Data.MySqlClient

Public Class DeliveryOrderFrm
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeCustomer As String
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub populateCust()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from customer order by name_customer asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "customer")
            con.Close()
            CmbCust.DataSource = ds.Tables(0)
            CmbCust.ValueMember = "kode_customer"
            CmbCust.DisplayMember = "name_customer"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from delivery_order_header order by id desc limit 0,1"
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
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim formNoSystem As String = "DO/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxDeliveryNo.Text = formNoSystem


        Me.DataGridViewDO.ColumnCount = 5
        Me.DataGridViewDO.Columns(0).Name = "Kode Item"
        Me.DataGridViewDO.Columns(1).Name = "Nama Item"
        Me.DataGridViewDO.Columns(2).Name = "Qty"
        Me.DataGridViewDO.Columns(3).Name = "Satuan"
        Me.DataGridViewDO.Columns(4).Name = "SO Ref"
    End Sub
    Private Sub DeliveryOrderFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxPONo.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub CmbCust_Click(sender As Object, e As EventArgs) Handles CmbCust.Click
        populateCust()
    End Sub

    Private Sub BtnSelectSO_Click(sender As Object, e As EventArgs) Handles BtnSelectSO.Click
        If CmbCust.SelectedIndex = -1 Then
            MessageBox.Show("Customer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbCust.Focus()
            Return
        End If
        If TextBoxPONo.Text = "" Then
            MessageBox.Show("PO No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxPONo.Focus()
            Return
        End If
        kodeCustomer = CmbCust.SelectedValue
        SearchSOForm.ShowDialog()
    End Sub

    Private Function insertDO() As Integer
        Dim rowEffected As Integer = 0
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        Dim queryGetIdentity As String = "Select @@Identity"
        Dim publictable As New DataTable
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try

            'validasi
            If TextBoxPONo.Text = "" Then
                MessageBox.Show("PO No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxPONo.Focus()
                Return 0
            End If

            If CmbCust.SelectedIndex = -1 Then
                MessageBox.Show("CUstomer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCust.Focus()
                Return 0
            End If

            If DataGridViewDO.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert DO Header
            sql = "INSERT INTO delivery_order_header(kode_customer,nama_customer,bill_to,ship_to,po_no,do_no,delivery_date,notes,status_delivery_order,created_by) VALUES (@kode_customer,@nama_customer,@bill_to,@ship_to,@po_no,@do_no,@delivery_date,@notes,@status_delivery_order,@created_by)"
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_customer", TextBoxKodeCust.Text)
            sqlCommand.Parameters.AddWithValue("@nama_customer", TextBoxNamaCust.Text)
            sqlCommand.Parameters.AddWithValue("@bill_to", textBoxBillTo.Text)
            sqlCommand.Parameters.AddWithValue("@ship_to", TextBoxShipTo.Text)
            sqlCommand.Parameters.AddWithValue("@po_no", TextBoxPONo.Text)
            sqlCommand.Parameters.AddWithValue("@do_no", TextBoxDeliveryNo.Text)
            sqlCommand.Parameters.AddWithValue("@delivery_date", DateTimePickerDeliveryDate.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            sqlCommand.Parameters.AddWithValue("@status_delivery_order", 1)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert DO Detail

            sqlCommand.Parameters.Add("@delivery_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@stockAvailable", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@gudang_id", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@so_no", MySqlDbType.VarChar)
            For Each oItem As DataGridViewRow In DataGridViewDO.Rows
                sql = "INSERT INTO delivery_order_detail(delivery_header_id,kode_item,nama_item,qty,satuan,so_no) VALUES (@delivery_header_id,@kode_item,@nama_item,@qty,@satuan,@so_no)"
                sqlCommand.CommandText = sql
                Dim SoNumber As String
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@delivery_header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@satuan").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@so_no").Value = oItem.Cells(4).Value
                SoNumber = oItem.Cells(4).Value
                sqlCommand.ExecuteNonQuery()

                ' update sales order header ubah status menjadi 2 karena sudah di delivery barang nya
                sql = "UPDATE sales_order_header SET status_so = 2 WHERE so_no = @so_no"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@so_no").Value = SoNumber
                sqlCommand.ExecuteNonQuery()


                ' cari dan update stok yg ada di gudang default dahulu, di cek dari item tsb default gudang nya dimana, jika stok di gudang default abis maka cek stok di gudang yang lain. 
                sql = "select ig.* from items_gudang ig inner join items i on ig.kode_item = i.kode_item  where ig.kode_item = @kode_item and ig.gudang_id = i.gudang_id "
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                da.SelectCommand = sqlCommand
                da.Fill(publictable)
                Dim stockAvailable As Long = 0
                If publictable.Rows.Count > 0 Then
                    For Each oRecord As Object In publictable.Rows
                        'row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("so_no").ToString()}
                        stockAvailable = oRecord("qty")
                        If stockAvailable > 0 Then
                            Dim gudangId As Integer
                            gudangId = oRecord("gudang_id")
                            sql = "UPDATE items_gudang SET qty = @stockAvailable - @qty WHERE gudang_id = @gudang_id AND kode_item = @kode_item"
                            sqlCommand.CommandText = sql
                            sqlCommand.Parameters("@gudang_id").Value = gudangId
                            sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                            sqlCommand.Parameters("@stockAvailable").Value = stockAvailable
                            sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                            sqlCommand.ExecuteNonQuery()
                        Else
                            sql = "select * from items_gudang where kode_item = @kode_item and qty > 0 limit 0,1 "
                            sqlCommand.CommandText = sql
                            sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                            da.SelectCommand = sqlCommand
                            da.Fill(publictable)
                            If publictable.Rows.Count > 0 Then
                                For Each oRecord2 As Object In publictable.Rows
                                    stockAvailable = oRecord2("qty")
                                    If stockAvailable > 0 Then
                                        Dim gudangId As Integer
                                        gudangId = oRecord("gudang_id")
                                        sql = "UPDATE items_gudang SET qty = @stockAvailable - @qty WHERE gudang_id = @gudang_id AND kode_item = @kode_item"
                                        sqlCommand.CommandText = sql
                                        sqlCommand.Parameters("@gudang_id").Value = gudangId
                                        sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                                        sqlCommand.Parameters("@stockAvailable").Value = stockAvailable
                                        sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                                        sqlCommand.ExecuteNonQuery()
                                    Else
                                        MessageBox.Show("Stok Kosong untuk Item ini!", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return rowEffected = 0
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If

                ' update stok items, di sum dari semua gudang
                sql = "UPDATE items SET quantity = (select sum(qty) as jumlahTotItem from items_gudang where kode_item = @kode_item) ,updated_on = @updated_on ,updated_by = @updated_by WHERE kode_item = @kode_item"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@updated_on").Value = now
                sqlCommand.Parameters("@updated_by").Value = session.Code
                sqlCommand.ExecuteNonQuery()
            Next

            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
    Public Sub addSelectSOToList()
        Dim listPO = New List(Of PoVO)
        listPO = SearchSOForm.listSelectPo
        DataGridViewDO.Rows.Clear()
        If DataGridViewDO.Columns.Count = 6 Then
            DataGridViewDO.Columns.RemoveAt(DataGridViewDO.Columns.Count - 1)
        End If

        DataGridViewDO.Refresh()
        For Each item As PoVO In listPO
            findItemsBySONo(item.NOPO)
        Next
        For Each oItem As DataGridViewRow In DataGridViewDO.Rows
            oItem.Cells(0).ReadOnly = True
            oItem.Cells(1).ReadOnly = True
            oItem.Cells(3).ReadOnly = True
            oItem.Cells(4).ReadOnly = True
        Next
        DataGridViewDO.Refresh()
    End Sub
    Private Sub findItemsBySONo(soNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,ph.so_no from sales_order_header ph left join sales_order_detail pd on ph.id = pd.so_header_id left join items i on i.kode_item = pd.kode_item where ph.so_no ='" & soNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("so_no").ToString()}
                    DataGridViewDO.Rows.Add(row)
                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridViewDO_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDO.CellClick
        If e.ColumnIndex = 2 Then
            DataGridViewDO.ClearSelection()
            DataGridViewDO.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            ' Set the current cell to the cell in column 2, Row 0. 
            DataGridViewDO.CurrentCell = Me.DataGridViewDO(e.ColumnIndex, e.RowIndex)
            DataGridViewDO.BeginEdit(True)

        End If
    End Sub

    Private Sub DataGridViewDO_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewDO.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
    End Sub

    Private Function findCustomerById(id As Integer) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select address1,address2,kode_customer,name_customer from customer where id ='" & id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                textBoxBillTo.Text = publictable.Rows(0).Item(0) + " " + publictable.Rows(0).Item(1)
                TextBoxKodeCust.Text = publictable.Rows(0).Item(2)
                TextBoxNamaCust.Text = publictable.Rows(0).Item(3)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbCust_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbCust.SelectionChangeCommitted
        findCustomerById(CmbCust.SelectedValue)
    End Sub

    Private Sub clearAllFIeld()
        TextBoxKodeCust.Text = ""
        TextBoxNamaCust.Text = ""
        textBoxBillTo.Text = ""
        TextBoxShipTo.Text = ""
        TextBoxPONo.Text = ""
        TextBoxDeliveryNo.Text = ""
        DataGridViewDO.Rows.Clear()
        TextBoxNotes.Text = ""
        CmbCust.SelectedIndex = -1
    End Sub

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click
        Dim temp As Integer = insertDO()
        If temp <> 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        Dim temp As Integer = insertDO()
        If temp <> 0 Then
            'printRIByFormNo(TextBoxFormNo.Text)
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        End If
        
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub disableButton()
        ButtonSaveClose.Enabled = False
        ButtonSaveNew.Enabled = False
        SavePrint.Enabled = False
        Cancel.Enabled = False
    End Sub
    Private Sub enableButton()
        ButtonSaveClose.Enabled = True
        ButtonSaveNew.Enabled = True
        SavePrint.Enabled = True
        Cancel.Enabled = True
    End Sub

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        Dim temp As Integer = insertDO()
        If temp <> 0 Then
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        End If
    End Sub
End Class