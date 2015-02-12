Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

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
            CmbCust.ValueMember = "id"
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


        Me.DataGridViewDO.ColumnCount = 6
        Me.DataGridViewDO.Columns(0).Name = "Kode Item"
        Me.DataGridViewDO.Columns(1).Name = "Nama Item"
        Me.DataGridViewDO.Columns(2).Name = "Qty"
        Me.DataGridViewDO.Columns(3).Name = "Satuan"
        Me.DataGridViewDO.Columns(4).Name = "SO Ref"
        Me.DataGridViewDO.Columns(5).Name = "Gudang"
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
        kodeCustomer = TextBoxKodeCust.Text
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
            sqlCommand.Parameters.Add("@kode_gudang", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@updated_on", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@updated_by", MySqlDbType.VarChar)
            For Each oItem As DataGridViewRow In DataGridViewDO.Rows
                sql = "INSERT INTO delivery_order_detail(delivery_header_id,kode_item,nama_item,qty,satuan,so_no,kode_gudang) VALUES (@delivery_header_id,@kode_item,@nama_item,@qty,@satuan,@so_no,@kode_gudang)"
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
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                sqlCommand.ExecuteNonQuery()

                ' update sales order header ubah status menjadi 2 karena sudah di delivery barang nya
                sql = "UPDATE sales_order_header SET status_so = 2 WHERE so_no = @so_no"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@so_no").Value = SoNumber
                sqlCommand.ExecuteNonQuery()

                'cari gudang id dari kode gudang yang dipilih
                sql = "select id from gudang where kode_gudang = @kode_gudang"
                Dim idGudang As Long
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                idGudang = sqlCommand.ExecuteScalar()

                sql = "select qty from items_gudang where gudang_id = @gudang_id and kode_item = @kode_item"
                Dim stockAvailable As Long
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@gudang_id").Value = idGudang
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                stockAvailable = sqlCommand.ExecuteScalar()

                If (stockAvailable - CLng(oItem.Cells(2).Value)) > 0 Then
                    sql = "UPDATE items_gudang SET qty = @stockAvailable - @qty WHERE gudang_id = @gudang_id AND kode_item = @kode_item"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@gudang_id").Value = idGudang
                    sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@stockAvailable").Value = stockAvailable
                    sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                    sqlCommand.ExecuteNonQuery()

                    ' update stok items, di sum dari semua gudang
                    sql = "UPDATE items SET quantity = (select sum(qty) as jumlahTotItem from items_gudang where kode_item = @kode_item) ,updated_on = @updated_on ,updated_by = @updated_by WHERE kode_item = @kode_item"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@updated_on").Value = now
                    sqlCommand.Parameters("@updated_by").Value = session.Code
                    sqlCommand.ExecuteNonQuery()
                Else
                    MessageBox.Show("Stok Kosong untuk Item ini!" & vbNewLine & " Kode Item : " + oItem.Cells(0).Value & vbNewLine & " Sisa Stok di gudang : " + CStr(stockAvailable), "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return rowEffected = 0
                End If
                
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
    Private Function getListGudang() As DataTable
        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select kode_gudang,nama_gudang from gudang order by nama_gudang asc"
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
    Public Sub addSelectSOToList()
        Dim listPO = New List(Of PoVO)
        listPO = SearchSOForm.listSelectPo
        DataGridViewDO.Rows.Clear()
        If DataGridViewDO.Columns.Count = 7 Then
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
        Dim cmb As New DataGridViewComboBoxColumn()
        cmb.HeaderText = "Nama Gudang"
        cmb.Name = "CmbGudang"
        Dim dt As DataTable = New DataTable()
        dt = getListGudang()
        If dt.Rows.Count > 0 Then
            cmb.ValueMember = "kode_gudang"
            cmb.DisplayMember = "nama_gudang"
            cmb.DataSource = dt
            cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewDO.Columns.Add(cmb)
            DataGridViewDO.Columns(5).Visible = False
            DataGridViewDO.Columns(2).DefaultCellStyle.BackColor = Color.Aquamarine
            For Each oItem As DataGridViewRow In DataGridViewDO.Rows
                oItem.Cells("CmbGudang").Value = oItem.Cells(5).Value
                oItem.Cells(0).ReadOnly = True
                oItem.Cells(1).ReadOnly = True
                oItem.Cells(3).ReadOnly = True
                oItem.Cells(4).ReadOnly = True
            Next
        End If
        DataGridViewDO.Refresh()
    End Sub
    Private Sub findItemsBySONo(soNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,ph.so_no,g.kode_gudang from sales_order_header ph left join sales_order_detail pd on ph.id = pd.so_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.so_no ='" & soNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("so_no").ToString(), oRecord("kode_gudang").ToString()}
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
            printDOByDONo(TextBoxDeliveryNo.Text)
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        End If

    End Sub
    Private Sub printDOByDONo(DONo As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Dim sqlSelectGeneral As String = "select ph.po_no,ph.do_no,ph.delivery_date,ph.bill_to,ph.ship_to, ph.nama_customer ,pd.kode_item,pd.nama_item,pd.qty,pd.satuan, ph.notes"
        Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
        Try
            sql = sqlSelectGeneral + sqlSelectCompanyName + " from  delivery_order_header ph inner join delivery_order_detail pd on ph.id = pd.delivery_header_id where ph.do_no = @dono"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@dono", DONo)
            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukDO.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
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

    Private Sub PrevPO_Click(sender As Object, e As EventArgs) Handles PrevPO.Click
        findDOBySeqPrev(idPrimary.Text)
    End Sub
    Private Sub findDOBySeqPrev(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from delivery_order_header rh inner join delivery_order_detail rd on rh.id = rd.delivery_header_id where rh.id < '" & idPrimary & "' order by rh.id desc limit 0,1"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            populateCust()
            If publictable.Rows.Count > 0 Then
                ' Header
                If Not IsDBNull(publictable.Rows(0).Item(0)) Then
                    Me.idPrimary.Text = publictable.Rows(0).Item(0)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    CmbCust.SelectedIndex = CmbCust.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    textBoxBillTo.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxShipTo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxPONo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    TextBoxDeliveryNo.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerDeliveryDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(8)
                End If
                'Detail
                sql = "select * from delivery_order_detail rd where rd.delivery_header_id = '" & publictable.Rows(0).Item(0) & "' order by rd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewDO.Rows.Clear()
                DataGridViewDO.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("so_no").ToString()}
                    DataGridViewDO.Rows.Add(row)
                Next
                DataGridViewDO.Refresh()
                disableButton()
            Else
                MessageBox.Show("This is first data", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub NextPo_Click(sender As Object, e As EventArgs) Handles NextPo.Click
        findDOBySeqNext(idPrimary.Text)
    End Sub
    Private Sub findDOBySeqNext(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from delivery_order_header rh inner join delivery_order_detail rd on rh.id = rd.delivery_header_id where rh.id > '" & idPrimary & "' order by rh.id asc limit 0,1"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            populateCust()
            If publictable.Rows.Count > 0 Then
                ' Header
                If Not IsDBNull(publictable.Rows(0).Item(0)) Then
                    Me.idPrimary.Text = publictable.Rows(0).Item(0)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    CmbCust.SelectedIndex = CmbCust.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    textBoxBillTo.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxShipTo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxPONo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    TextBoxDeliveryNo.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerDeliveryDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(8)
                End If
                'Detail
                sql = "select * from delivery_order_detail rd where rd.delivery_header_id = '" & publictable.Rows(0).Item(0) & "' order by rd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewDO.Rows.Clear()
                DataGridViewDO.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("so_no").ToString()}
                    DataGridViewDO.Rows.Add(row)
                Next
                DataGridViewDO.Refresh()
                disableButton()
            Else
                MessageBox.Show("This is last data", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                clearAllFIeld()
                inisialisasi()
                Me.idPrimary.Text = getPrimaryId().ToString
                enableButton()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class