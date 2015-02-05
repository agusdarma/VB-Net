Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class PurchaseInvoice
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeSupplier As String
    Public type As String
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
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from purchase_invoice_header order by id desc limit 0,1"
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

    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim qty As Long
        Dim hargaSatuan As Long
        Dim hargaDiskon As Long
        qty = DataGridViewPI.Rows(rowIdx).Cells(2).Value
        hargaSatuan = DataGridViewPI.Rows(rowIdx).Cells(4).Value
        hargaDiskon = DataGridViewPI.Rows(rowIdx).Cells(5).Value
        Dim totalHarga As Long
        totalHarga = (qty * hargaSatuan) - (qty * hargaDiskon)
        DataGridViewPI.Rows(rowIdx).Cells(9).Value = totalHarga
    End Sub

    Public Sub addSelectToList()
        Dim idx As Integer = DataGridViewPI.RowCount
        idx = idx - 1
        Dim listPO = New List(Of PoVO)
        listPO = SearchInvoiceForm.listSelectPo
        DataGridViewPI.Rows.Clear()
        If DataGridViewPI.Columns.Count = 11 Then
            DataGridViewPI.Columns.RemoveAt(DataGridViewPI.Columns.Count - 1)
        End If

        DataGridViewPI.Refresh()
        If type = "Select PO" Then
            For Each item As PoVO In listPO
                findItemsByPONo(item.NOPO)
            Next
            DataGridViewPI.Columns(7).Visible = True
            DataGridViewPI.Columns(8).Visible = False
        ElseIf type = "Select RI" Then
            For Each item As PoVO In listPO
                findItemsByRINo(item.NOPO)
            Next
            DataGridViewPI.Columns(7).Visible = False
            DataGridViewPI.Columns(8).Visible = True

        End If

        For Each oItem As DataGridViewRow In DataGridViewPI.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
            oItem.Cells(5).Value = CLng(oItem.Cells(5).Value)
        Next
        For Each oItem As DataGridViewRow In DataGridViewPI.Rows
            hitungTotalHarga(oItem.Index)
            formatKolomNumeric()
        Next
        hitungSubTotalHarga()
        calculatePctDiskon()
        If CheckVendorTaxable.Checked = True Then
            hitungPPn()
        End If
        If CheckInclusiveTax.Checked = True Then
            hitungPPnInclusiveTax()
        End If
        DataGridViewPI.Refresh()
    End Sub
    Private Sub findItemsByPONo(poNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,i.default_price,i.default_diskon,'0', g.nama_gudang,ph.po_no,ph.diskon_pct,ph.supplier_taxable,ph.inclusive_tax from purchase_order_header ph left join purchase_order_detail pd on ph.id = pd.po_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.po_no ='" & poNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("default_price").ToString(), oRecord("default_diskon").ToString(), oRecord("nama_gudang").ToString(), oRecord("po_no").ToString()}
                    DataGridViewPI.Rows.Add(row)
                    TextBoxPctDiskon.Text = oRecord("diskon_pct")
                    If oRecord("supplier_taxable") = 1 Then
                        CheckVendorTaxable.Checked = True            
                    Else
                        CheckVendorTaxable.Checked = False
                    End If
                    If oRecord("inclusive_tax") = 1 Then
                        CheckInclusiveTax.Checked = True                       
                    Else
                        CheckInclusiveTax.Checked = False
                    End If


                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub findItemsByRINo(RINo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,i.default_price,i.default_diskon,'0', g.nama_gudang,pd.po_no,ph.form_no from receive_item_header ph left join receive_item_detail pd on ph.id = pd.receive_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.form_no ='" & RINo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("default_price").ToString(), oRecord("default_diskon").ToString(), oRecord("nama_gudang").ToString(), oRecord("po_no").ToString(), oRecord("form_no").ToString()}
                    DataGridViewPI.Rows.Add(row)
                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim formNoSystem As String = "PI/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxFormNo.Text = formNoSystem
        TextBoxInvoiceNo.Focus()

        Me.DataGridViewPI.ColumnCount = 10
        Me.DataGridViewPI.Columns(0).Name = "Kode Item"
        Me.DataGridViewPI.Columns(1).Name = "Nama Item"
        Me.DataGridViewPI.Columns(2).Name = "Qty"
        Me.DataGridViewPI.Columns(3).Name = "Satuan"
        Me.DataGridViewPI.Columns(4).Name = "Harga Satuan"
        Me.DataGridViewPI.Columns(5).Name = "Diskon"
        Me.DataGridViewPI.Columns(6).Name = "Gudang"
        Me.DataGridViewPI.Columns(7).Name = "PO No"
        Me.DataGridViewPI.Columns(8).Name = "Receive Item No"
        Me.DataGridViewPI.Columns(9).Name = "Total Harga"

        ComboBoxSelectType.Items.Clear()
        ComboBoxSelectType.Name = "CmbType"
        ComboBoxSelectType.Items.Add("Select PO")
        ComboBoxSelectType.Items.Add("Select RI")

        lblPPN.Visible = False
        LblPPnRp.Visible = False
        TextBoxPPn.Visible = False
        lblTax.Visible = False
        CheckInclusiveTax.Enabled = False
        If CheckVendorTaxable.Checked = True Then
            lblPPN.Visible = True
            LblPPnRp.Visible = True
            TextBoxPPn.Visible = True
            CheckInclusiveTax.Enabled = True
            hitungPPn()
            calculateTotalOrder()
        Else
            lblPPN.Visible = False
            LblPPnRp.Visible = False
            TextBoxPPn.Visible = False
            lblTax.Visible = False
            CheckInclusiveTax.Enabled = False
            CheckInclusiveTax.Checked = False
            clearHitungPPn()
            calculateTotalOrder()
            Exit Sub
        End If
        If CheckInclusiveTax.Checked = True Then
            lblPPN.Visible = True
            LblPPnRp.Visible = True
            TextBoxPPn.Visible = True
            lblTax.Visible = True
            hitungPPnInclusiveTax()
        End If
    End Sub
    Private Sub hitungSubTotalHarga()
        Dim totalharga As Long = 0
        'totalharga = DataGridViewPO.Rows(rowIdx).Cells(6).Value
        Dim str As String = ""
        For Each oItem As DataGridViewRow In DataGridViewPI.Rows
            totalharga = totalharga + oItem.Cells(9).Value
        Next
        Dim subTotal As Long = totalharga
        TextBoxSubTotal.Text = FormatNumber(subTotal.ToString, 0, TriState.True)
        calculatePctDiskon()
        calculateTotalOrder()
    End Sub
    Private Sub calculatePctDiskon()
        If TextBoxPctDiskon.Text = "" Then
            TextBoxPctDiskon.Text = 0
        End If
        Dim pctPersen As Long = CLng(TextBoxPctDiskon.Text)
        Dim subTotal As Long = CLng(TextBoxSubTotal.Text)
        Dim pctValue As Long = subTotal * (pctPersen / 100)
        TextBoxValueDiskon.Text = FormatNumber(pctValue.ToString, 0, TriState.True)
        hitungPPn()
    End Sub
    Private Sub calculateTotalOrder()
        Dim subTotal As Long = CLng(TextBoxSubTotal.Text)
        Dim valueDiskon As Long = CLng(TextBoxValueDiskon.Text)
        Dim ppnValue As Long = CLng(TextBoxPPn.Text)
        Dim totalOrder As Long
        If TextBoxPPn.Visible = False Then
            ppnValue = 0
        End If
        If CheckInclusiveTax.Checked Then
            totalOrder = (subTotal - valueDiskon)
        Else
            totalOrder = (subTotal - valueDiskon) + (ppnValue)
        End If
        TextBoxTotalOrder.Text = FormatNumber(totalOrder.ToString, 0, TriState.True)
    End Sub
    Private Sub hitungPPn()
        Dim subTotal As Long = 0
        Dim valueDiskon As Long = 0
        Dim ppn As Long = 0
        subTotal = CLng(TextBoxSubTotal.Text)
        valueDiskon = CLng(TextBoxValueDiskon.Text)
        ppn = (subTotal - valueDiskon) * 0.1
        TextBoxPPn.Text = FormatNumber(ppn.ToString, 0, TriState.True)
    End Sub
    Private Sub hitungPPnInclusiveTax()
        Dim subTotal As Long = 0
        Dim valueDiskon As Long = 0
        Dim ppn As Long = 0
        subTotal = CLng(TextBoxSubTotal.Text)
        valueDiskon = CLng(TextBoxValueDiskon.Text)
        ppn = (subTotal - valueDiskon) * (10 / 110)
        TextBoxPPn.Text = FormatNumber(ppn.ToString, 0, TriState.True)
    End Sub
    Private Sub clearHitungPPn()
        TextBoxPPn.Text = FormatNumber("0", 0, TriState.True)
    End Sub
    Private Sub PurchaseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxInvoiceNo.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub formatKolomNumeric()
        DataGridViewPI.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
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

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierByKode(CmbVendor.SelectedValue)
    End Sub

    Private Sub CheckVendorTaxable_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckVendorTaxable.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub CheckInclusiveTax_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckInclusiveTax.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub TextBoxValueDiskon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxValueDiskon.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
            If TextBoxValueDiskon.Text = "" Then
                TextBoxValueDiskon.Text = 0
                TextBoxPctDiskon.Text = 0
            End If
            TextBoxValueDiskon.Text = FormatNumber(TextBoxValueDiskon.Text.ToString, 0, TriState.True)
            If CheckInclusiveTax.Checked Then
                hitungPPnInclusiveTax()
            Else
                hitungPPn()
            End If
            calculateTotalOrder()
            ButtonSaveNew.Focus()
        End If
    End Sub

    Private Sub TextBoxValueDiskon_Leave(sender As Object, e As EventArgs) Handles TextBoxValueDiskon.Leave
        TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
        If TextBoxValueDiskon.Text = "" Then
            TextBoxValueDiskon.Text = 0
            TextBoxPctDiskon.Text = 0
        End If
        TextBoxValueDiskon.Text = FormatNumber(TextBoxValueDiskon.Text.ToString, 0, TriState.True)
        If CheckInclusiveTax.Checked Then
            hitungPPnInclusiveTax()
        Else
            hitungPPn()
        End If
        calculateTotalOrder()
    End Sub

    Private Sub TextBoxInvoiceNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxInvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePickerInvoiceDate.Focus()
        End If
    End Sub

    Private Sub DateTimePickerInvoiceDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerInvoiceDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePickerShipDate.Focus()
        End If
    End Sub

    Private Sub DateTimePickerShipDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerShipDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckVendorTaxable.Focus()
        End If
    End Sub

    Private Sub CheckVendorTaxable_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckVendorTaxable.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckInclusiveTax.Focus()
        End If
    End Sub

    Private Sub CheckInclusiveTax_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckInclusiveTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbVendor.Focus()
        End If
    End Sub

    Private Sub ComboBoxSelectType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxSelectType.SelectionChangeCommitted
        If CmbVendor.SelectedIndex = -1 Then
            MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbVendor.Focus()
            Return
        End If
        If TextBoxInvoiceNo.Text = "" Then
            MessageBox.Show("Invoice No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxInvoiceNo.Focus()
            Return
        End If
        type = ComboBoxSelectType.SelectedItem.ToString
        kodeSupplier = CmbVendor.SelectedValue
        SearchInvoiceForm.ShowDialog()
    End Sub

    Private Sub TextBoxPctDiskon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPctDiskon.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            calculatePctDiskon()
            calculateTotalOrder()
            TextBoxValueDiskon.Focus()
            TextBoxValueDiskon.SelectAll()
            TextBoxValueDiskon.TextAlign = HorizontalAlignment.Left
            If CheckInclusiveTax.Checked Then
                hitungPPnInclusiveTax()
            Else
                hitungPPn()
            End If
            calculateTotalOrder()
        End If
    End Sub

    Private Sub TextBoxPctDiskon_Leave(sender As Object, e As EventArgs) Handles TextBoxPctDiskon.Leave
        calculatePctDiskon()
        calculateTotalOrder()
        TextBoxValueDiskon.Focus()
        TextBoxValueDiskon.SelectAll()
        TextBoxValueDiskon.TextAlign = HorizontalAlignment.Left
        If CheckInclusiveTax.Checked Then
            hitungPPnInclusiveTax()
        Else
            hitungPPn()
        End If
        calculateTotalOrder()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub removeSeparator(txtBox As TextBox)
        Dim temp As String
        temp = txtBox.Text
        temp = temp.Replace(",", "")
        txtBox.Text = temp
    End Sub
    Private Sub removeSeparatorBeforeInsert()
        removeSeparator(TextBoxPPn)
        removeSeparator(TextBoxPctDiskon)
        removeSeparator(TextBoxSubTotal)
        removeSeparator(TextBoxTotalOrder)
        removeSeparator(TextBoxValueDiskon)
    End Sub
    Private Function insertPI() As Integer
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
            If TextBoxInvoiceNo.Text = "" Then
                MessageBox.Show("Invoice No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxInvoiceNo.Focus()
                Return 0
            End If

            If CmbVendor.SelectedIndex = -1 Then
                MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbVendor.Focus()
                Return 0
            End If

            If DataGridViewPI.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert PI Header
            sql = "INSERT INTO purchase_invoice_header(kode_supplier,nama_supplier,form_no,invoice_no,invoice_date,ship_date,notes,supplier_taxable,inclusive_tax,sub_total,diskon_pct,diskon,tax_value,total_order,status_invoice,created_by ) VALUES (@kode_supplier,@nama_supplier,@form_no,@invoice_no,@invoice_date,@ship_date,@notes,@supplier_taxable,@inclusive_tax,@sub_total,@diskon_pct,@diskon,@tax_value,@total_order,@status_invoice,@created_by)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_supplier", TextBoxKodeSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@nama_supplier", TextBoxNamaSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@form_no", TextBoxFormNo.Text)
            sqlCommand.Parameters.AddWithValue("@invoice_no", TextBoxInvoiceNo.Text)
            sqlCommand.Parameters.AddWithValue("@invoice_date", DateTimePickerInvoiceDate.Value)
            sqlCommand.Parameters.AddWithValue("@ship_date", DateTimePickerShipDate.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            If CheckVendorTaxable.Checked = True Then
                sqlCommand.Parameters.AddWithValue("@supplier_taxable", 1)
            Else
                sqlCommand.Parameters.AddWithValue("@supplier_taxable", 0)
            End If
            If CheckInclusiveTax.Checked = True Then
                sqlCommand.Parameters.AddWithValue("@inclusive_tax", 1)
            Else
                sqlCommand.Parameters.AddWithValue("@inclusive_tax", 0)
            End If
            sqlCommand.Parameters.AddWithValue("@sub_total", TextBoxSubTotal.Text)
            sqlCommand.Parameters.AddWithValue("@diskon", TextBoxValueDiskon.Text)
            sqlCommand.Parameters.AddWithValue("@diskon_pct", TextBoxPctDiskon.Text)
            sqlCommand.Parameters.AddWithValue("@tax_value", TextBoxPPn.Text)
            sqlCommand.Parameters.AddWithValue("@total_order", TextBoxTotalOrder.Text)
            sqlCommand.Parameters.AddWithValue("@status_invoice", 1)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert PI Detail

            sqlCommand.Parameters.Add("@purchase_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@price_per_unit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@diskonDetail", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@price_total", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@kode_gudang", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@po_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@receive_no", MySqlDbType.VarChar)
            For Each oItem As DataGridViewRow In DataGridViewPI.Rows
                sql = "INSERT INTO purchase_invoice_detail(purchase_header_id,kode_item,nama_item,qty,satuan,price_per_unit,diskon,price_total,kode_gudang,po_no,receive_no) VALUES (@purchase_header_id,@kode_item,@nama_item,@qty,@satuan,@price_per_unit,@diskonDetail,@price_total,@kode_gudang,@po_no,@receive_no)"
                sqlCommand.CommandText = sql
                Dim PoNumber As String
                Dim RINumber As String
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@purchase_header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@satuan").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@price_per_unit").Value = oItem.Cells(4).Value
                sqlCommand.Parameters("@diskonDetail").Value = oItem.Cells(5).Value
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                sqlCommand.Parameters("@po_no").Value = oItem.Cells(7).Value
                sqlCommand.Parameters("@receive_no").Value = oItem.Cells(8).Value
                sqlCommand.Parameters("@price_total").Value = oItem.Cells(9).Value
                PoNumber = oItem.Cells(7).Value
                RINumber = oItem.Cells(8).Value
                sqlCommand.ExecuteNonQuery()

                If type = "Select PO" Then
                    ' update purchase order header ubah status menjadi 3 karena sudah di invoicing barang nya
                    sql = "UPDATE purchase_order_header SET status_po = 3 WHERE po_no = @po_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@po_no").Value = PoNumber
                    sqlCommand.ExecuteNonQuery()
                ElseIf type = "Select RI" Then
                    ' update table po status menjadi 3 dan update table receive item status ubah jadi 2
                    sql = "UPDATE purchase_order_header SET status_po = 3 WHERE po_no = @po_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@po_no").Value = PoNumber
                    sqlCommand.ExecuteNonQuery()

                    sql = "UPDATE receive_item_header SET status_receive_item = 2 WHERE form_no = @form_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@form_no").Value = RINumber
                    sqlCommand.ExecuteNonQuery()
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
    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        insertPI()
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub
    Private Sub clearAllFIeld()
        TextBoxKodeSupplier.Text = ""
        TextBoxNamaSupplier.Text = ""
        alamatVendor.Text = ""
        TextBoxInvoiceNo.Text = ""
        CheckVendorTaxable.Checked = False
        CheckInclusiveTax.Checked = False
        DataGridViewPI.Rows.Clear()
        TextBoxNotes.Text = ""
        TextBoxPctDiskon.Text = "0"
        TextBoxValueDiskon.Text = "0"
        TextBoxInvoiceNo.Focus()
        TextBoxSubTotal.Text = "0"
        TextBoxPPn.Text = "0"
        TextBoxTotalOrder.Text = "0"
        CmbVendor.SelectedIndex = -1
    End Sub

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click
        insertPI()
        Me.Close()
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        insertPI()
        printPIByNoInvoice(TextBoxFormNo.Text)
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub printPIByNoInvoice(invoiceNo As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Dim sqlSelectGeneral As String = "select ph.nama_supplier,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier,ph.form_no,ph.invoice_no,ph.invoice_date,ph.ship_date,ph.sub_total,ph.diskon,ph.tax_value,ph.total_order,pd.kode_item,pd.nama_item,pd.qty,pd.price_per_unit,pd.diskon,pd.price_total"
        Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
        Try
            sql = sqlSelectGeneral + sqlSelectCompanyName + " from purchase_invoice_header ph inner join purchase_invoice_detail pd on ph.id = pd.purchase_header_id inner join supplier s on s.kode_supplier = ph.kode_supplier where ph.form_no = @form_no"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@form_no", invoiceNo)
            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukPI.rpt")
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
        findPIBySeqPrev(idPrimary.Text)
    End Sub
    Private Sub disableButton()
        ButtonSaveClose.Enabled = False
        ButtonSaveNew.Enabled = False
        SavePrint.Enabled = False
        Cancel.Enabled = False
        CheckVendorTaxable.Enabled = False
        CheckInclusiveTax.Enabled = False
        TextBoxInvoiceNo.Enabled = False
    End Sub
    Private Sub enableButton()
        ButtonSaveClose.Enabled = True
        ButtonSaveNew.Enabled = True
        SavePrint.Enabled = True
        Cancel.Enabled = True
        CheckVendorTaxable.Enabled = True
        CheckInclusiveTax.Enabled = True
        TextBoxInvoiceNo.Enabled = True
    End Sub

    Private Sub NextPo_Click(sender As Object, e As EventArgs) Handles NextPo.Click
        findPIBySeqNext(idPrimary.Text)
    End Sub
    Private Sub findPIBySeqPrev(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select *,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier from purchase_invoice_header ph inner join purchase_invoice_detail pd on ph.id = pd.purchase_header_id inner join supplier s on s.kode_supplier = ph.kode_supplier where ph.id < '" & idPrimary & "' order by ph.id desc limit 0,1"
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
                If Not IsDBNull(publictable.Rows(0).Item(48)) Then
                    alamatVendor.Text = publictable.Rows(0).Item(48)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxInvoiceNo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    DateTimePickerInvoiceDate.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(8)
                    If taxable = 1 Then
                        CheckVendorTaxable.Checked = True
                    Else
                        CheckVendorTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(9)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(10)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(11)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(12)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(14)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(14)
                End If
                'Detail
                sql = "select * from purchase_invoice_detail pd where pd.purchase_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewPI.Rows.Clear()
                DataGridViewPI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString(), oRecord("receive_no").ToString(), oRecord("price_total").ToString()}
                    DataGridViewPI.Rows.Add(row)
                    'row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString()}
                    'DataGridViewPI.Rows.Add(row)
                    
                Next
                DataGridViewPI.Refresh()
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

    Private Sub findPIBySeqNext(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select *,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier from purchase_invoice_header ph inner join purchase_invoice_detail pd on ph.id = pd.purchase_header_id inner join supplier s on s.kode_supplier = ph.kode_supplier where ph.id > '" & idPrimary & "' order by ph.id asc limit 0,1"
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
                If Not IsDBNull(publictable.Rows(0).Item(48)) Then
                    alamatVendor.Text = publictable.Rows(0).Item(48)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    TextBoxInvoiceNo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    DateTimePickerInvoiceDate.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(8)
                    If taxable = 1 Then
                        CheckVendorTaxable.Checked = True
                    Else
                        CheckVendorTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(9)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(10)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(11)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(12)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(14)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(14)
                End If
                'Detail
                sql = "select * from purchase_invoice_detail pd where pd.purchase_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewPI.Rows.Clear()
                DataGridViewPI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString(), oRecord("receive_no").ToString(), oRecord("price_total").ToString()}
                    DataGridViewPI.Rows.Add(row)
                    'row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString()}
                    'DataGridViewPI.Rows.Add(row)

                Next
                DataGridViewPI.Refresh()
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