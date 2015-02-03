Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

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
        idPrimary.Text = getPrimaryId().ToString
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
            cmb.ValueMember = "kode_gudang"
            cmb.DisplayMember = "nama_gudang"
            cmb.DataSource = dt
            cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewRI.Columns.Add(cmb)
            DataGridViewRI.Columns(5).Visible = False
            DataGridViewRI.Columns(2).DefaultCellStyle.BackColor = Color.Aquamarine
            For Each oItem As DataGridViewRow In DataGridViewRI.Rows
                oItem.Cells("CmbGudang").Value = oItem.Cells(5).Value
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
    Private Sub findItemsByPONo(poNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,g.kode_gudang,ph.po_no from purchase_order_header ph left join purchase_order_detail pd on ph.id = pd.po_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.po_no ='" & poNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("po_no").ToString(), oRecord("kode_gudang").ToString()}
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
                TextBoxKodeSupplier.Text = publictable.Rows(0).Item(2)
                TextBoxNamaSupplier.Text = publictable.Rows(0).Item(3)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function
    Private Function insertRI() As Integer
        Dim rowEffected As Integer = 0
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        Dim queryGetIdentity As String = "Select @@Identity"
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try

            'validasi
            If TextBoxReceiptNo.Text = "" Then
                MessageBox.Show("Receipt No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxReceiptNo.Focus()
                Return 0
            End If

            If CmbVendor.SelectedIndex = -1 Then
                MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbVendor.Focus()
                Return 0
            End If

            If DataGridViewRI.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert RI Header
            sql = "INSERT INTO receive_item_header(kode_supplier,nama_supplier,alamat_supplier,form_no,receipt_no,receive_date,ship_date,notes) VALUES (@kode_supplier,@nama_supplier,@alamat_supplier,@form_no,@receipt_no,@receive_date,@ship_date,@notes)"
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_supplier", TextBoxKodeSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@nama_supplier", TextBoxNamaSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@alamat_supplier", alamatVendor.Text)
            sqlCommand.Parameters.AddWithValue("@form_no", TextBoxFormNo.Text)
            sqlCommand.Parameters.AddWithValue("@receipt_no", TextBoxReceiptNo.Text)
            sqlCommand.Parameters.AddWithValue("@receive_date", DateTimePickerReceiveDate.Value)
            sqlCommand.Parameters.AddWithValue("@ship_date", DateTimePickerShipDate.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert RI Detail

            sqlCommand.Parameters.Add("@receive_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@qtyAwal", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@po_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@kode_gudang", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@updated_on", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@updated_by", MySqlDbType.VarChar)
            For Each oItem As DataGridViewRow In DataGridViewRI.Rows
                sql = "INSERT INTO receive_item_detail(receive_header_id,kode_item,nama_item,qty,satuan,po_no,kode_gudang) VALUES (@receive_header_id,@kode_item,@nama_item,@qty,@satuan,@po_no,@kode_gudang)"
                sqlCommand.CommandText = sql
                Dim PoNumber As String
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@receive_header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@satuan").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@po_no").Value = oItem.Cells(4).Value
                PoNumber = oItem.Cells(4).Value
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                sqlCommand.ExecuteNonQuery()

                ' update purchase order header ubah status menjadi 2 karena sudah di received barang nya
                sql = "UPDATE purchase_order_header SET status_po = 2 WHERE po_no = @po_no"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@po_no").Value = PoNumber
                sqlCommand.ExecuteNonQuery()


                ' cari qty awal tiap item di gudang 
                sql = "select qty from items_gudang where gudang_id = (select id from gudang where kode_gudang = @kode_gudang) and kode_item = @kode_item"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                Dim qtyAwal As Long
                qtyAwal = sqlCommand.ExecuteScalar()

                ' check di gudang sudah pernah ada apa belum barang yang di delivered, kalo belum ada insert kalo sudah update
                sql = "select count(*) from items_gudang where gudang_id = (select id from gudang where kode_gudang = @kode_gudang) and kode_item = @kode_item"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                Dim exist As Long ' 0 tidak exist, 1 exist
                exist = sqlCommand.ExecuteScalar()
                ' update stok barang di gudang mana  
                If exist > 0 Then
                    sql = "UPDATE items_gudang SET qty = @qtyAwal + @qty WHERE gudang_id = (select id from gudang where kode_gudang = @kode_gudang) AND kode_item = @kode_item"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                    sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@qtyAwal").Value = qtyAwal
                    sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                    sqlCommand.ExecuteNonQuery()
                Else
                    sql = "INSERT INTO items_gudang(gudang_id,kode_item,qty) VALUES ((select id from gudang where kode_gudang = @kode_gudang),@kode_item,@qtyAwal + @qty)"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                    sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@qtyAwal").Value = qtyAwal
                    sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                    sqlCommand.ExecuteNonQuery()
                End If


                ' cari qty awal tiap item  di master
                'sql = "select quantity from items WHERE kode_item = @kode_item"
                'sqlCommand.CommandText = sql
                'sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                'qtyAwal = sqlCommand.ExecuteScalar()

                ' update stok items, di sum dari semua gudang
                sql = "UPDATE items SET quantity = (select sum(qty) as jumlahTotItem from items_gudang where kode_item = @kode_item) ,updated_on = @updated_on ,updated_by = @updated_by WHERE kode_item = @kode_item"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@updated_on").Value = now
                'sqlCommand.Parameters("@qtyAwal").Value = qtyAwal
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

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        insertRI()
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub
    Private Sub clearAllFIeld()
        TextBoxKodeSupplier.Text = ""
        TextBoxNamaSupplier.Text = ""
        alamatVendor.Text = ""
        TextBoxFormNo.Text = ""
        TextBoxReceiptNo.Text = ""
        DataGridViewRI.Rows.Clear()
        TextBoxNotes.Text = ""
        CmbVendor.SelectedIndex = -1
    End Sub

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click
        insertRI()
        Me.Close()
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        insertRI()
        printRIByFormNo(TextBoxFormNo.Text)
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub printRIByFormNo(formNo As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Dim sqlSelectGeneral As String = "select rh.kode_supplier,rh.nama_supplier,rh.alamat_supplier,rh.form_no,rh.receipt_no,rh.receive_date,rh.ship_date,rh.notes,rd.kode_item,rd.nama_item,rd.qty"
        Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
        Try
            sql = sqlSelectGeneral + sqlSelectCompanyName + " from receive_item_header rh inner join receive_item_detail rd on rh.id = rd.receive_header_id where rh.form_no = @formNo"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@formNo", formNo)
            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukRI.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub PrevPO_Click(sender As Object, e As EventArgs) Handles PrevPO.Click
        findRIBySeqPrev(idPrimary.Text)
    End Sub
    Private Sub findRIBySeqPrev(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from receive_item_header rh inner join receive_item_detail rd on rh.id = rd.receive_header_id where rh.id < '" & idPrimary & "' order by rh.id desc limit 0,1"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            populateVendor()
            If publictable.Rows.Count > 0 Then
                ' Header
                If Not IsDBNull(publictable.Rows(0).Item(0)) Then
                    Me.idPrimary.Text = publictable.Rows(0).Item(0)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    CmbVendor.SelectedIndex = CmbVendor.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    alamatVendor.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxReceiptNo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    DateTimePickerReceiveDate.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(8)
                End If
                'Detail
                sql = "select * from receive_item_detail rd where rd.receive_header_id = '" & publictable.Rows(0).Item(0) & "' order by rd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewRI.Rows.Clear()
                DataGridViewRI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("po_no").ToString(), oRecord("kode_gudang").ToString()}
                    DataGridViewRI.Rows.Add(row)
                Next
                Dim cmb As New DataGridViewComboBoxColumn()
                cmb.HeaderText = "Nama Gudang"
                cmb.Name = "CmbGudang"
                Dim dt As DataTable = New DataTable()
                dt = getListGudang()
                If dt.Rows.Count > 0 Then
                    If DataGridViewRI.Columns.Count = 7 Then
                        DataGridViewRI.Columns.RemoveAt(DataGridViewRI.Columns.Count - 1)
                    End If
                    cmb.ValueMember = "kode_gudang"
                    cmb.DisplayMember = "nama_gudang"
                    cmb.DataSource = dt
                    cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DataGridViewRI.Columns.Add(cmb)
                    DataGridViewRI.Columns(5).Visible = False
                    DataGridViewRI.Columns(2).DefaultCellStyle.BackColor = Color.Aquamarine
                    For Each oItem As DataGridViewRow In DataGridViewRI.Rows
                        oItem.Cells("CmbGudang").Value = oItem.Cells(5).Value
                        oItem.Cells(0).ReadOnly = True
                        oItem.Cells(1).ReadOnly = True
                        oItem.Cells(3).ReadOnly = True
                        oItem.Cells(4).ReadOnly = True
                    Next
                End If
                DataGridViewRI.Refresh()
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
    Private Sub findRIBySeqNext(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from receive_item_header rh inner join receive_item_detail rd on rh.id = rd.receive_header_id where rh.id > '" & idPrimary & "' order by rh.id asc limit 0,1"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            populateVendor()
            If publictable.Rows.Count > 0 Then
                ' Header
                If Not IsDBNull(publictable.Rows(0).Item(0)) Then
                    Me.idPrimary.Text = publictable.Rows(0).Item(0)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    CmbVendor.SelectedIndex = CmbVendor.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    alamatVendor.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxReceiptNo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    DateTimePickerReceiveDate.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(8)
                End If
                'Detail
                sql = "select * from receive_item_detail rd where rd.receive_header_id = '" & publictable.Rows(0).Item(0) & "' order by rd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewRI.Rows.Clear()
                DataGridViewRI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("po_no").ToString(), oRecord("kode_gudang").ToString()}
                    DataGridViewRI.Rows.Add(row)
                Next
                Dim cmb As New DataGridViewComboBoxColumn()
                cmb.HeaderText = "Nama Gudang"
                cmb.Name = "CmbGudang"
                Dim dt As DataTable = New DataTable()
                dt = getListGudang()
                If dt.Rows.Count > 0 Then
                    If DataGridViewRI.Columns.Count = 7 Then
                        DataGridViewRI.Columns.RemoveAt(DataGridViewRI.Columns.Count - 1)
                    End If
                    cmb.ValueMember = "kode_gudang"
                    cmb.DisplayMember = "nama_gudang"
                    cmb.DataSource = dt
                    cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DataGridViewRI.Columns.Add(cmb)
                    DataGridViewRI.Columns(5).Visible = False
                    DataGridViewRI.Columns(2).DefaultCellStyle.BackColor = Color.Aquamarine
                    For Each oItem As DataGridViewRow In DataGridViewRI.Rows
                        oItem.Cells("CmbGudang").Value = oItem.Cells(5).Value
                        oItem.Cells(0).ReadOnly = True
                        oItem.Cells(1).ReadOnly = True
                        oItem.Cells(3).ReadOnly = True
                        oItem.Cells(4).ReadOnly = True
                    Next
                End If
                DataGridViewRI.Refresh()
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

    Private Sub NextPo_Click(sender As Object, e As EventArgs) Handles NextPo.Click
        findRIBySeqNext(idPrimary.Text)
    End Sub
End Class