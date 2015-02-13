Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class SalesInvoice
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeCustomer As String
    Public type As String
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub SalesInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxFormNo.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from sales_invoice_header order by id desc limit 0,1"
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
        Dim formNoSystem As String = "SI/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxSalesInvoiceNo.Text = formNoSystem
        TextBoxFormNo.Focus()

        Me.DataGridViewSI.ColumnCount = 10
        Me.DataGridViewSI.Columns(0).Name = "Kode Item"
        Me.DataGridViewSI.Columns(1).Name = "Nama Item"
        Me.DataGridViewSI.Columns(2).Name = "Qty"
        Me.DataGridViewSI.Columns(3).Name = "Satuan"
        Me.DataGridViewSI.Columns(4).Name = "Harga Satuan"
        Me.DataGridViewSI.Columns(5).Name = "Diskon"
        Me.DataGridViewSI.Columns(6).Name = "Gudang"
        Me.DataGridViewSI.Columns(7).Name = "SO No"
        Me.DataGridViewSI.Columns(8).Name = "Delivery Order No"
        Me.DataGridViewSI.Columns(9).Name = "Total Harga"

        ComboBoxSelectType.Items.Clear()
        ComboBoxSelectType.Name = "CmbType"
        ComboBoxSelectType.Items.Add("Select SO")
        ComboBoxSelectType.Items.Add("Select DO")

        lblPPN.Visible = False
        LblPPnRp.Visible = False
        TextBoxPPn.Visible = False
        lblTax.Visible = False
        CheckInclusiveTax.Enabled = False
        If CheckCustTaxable.Checked = True Then
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

    Private Sub formatKolomNumeric()
        DataGridViewSI.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSI.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSI.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSI.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSI.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSI.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSI.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSI.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

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
            CmbCustomer.DataSource = ds.Tables(0)
            CmbCustomer.ValueMember = "kode_customer"
            CmbCustomer.DisplayMember = "name_customer"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub hitungSubTotalHarga()
        Dim totalharga As Long = 0
        'totalharga = DataGridViewPO.Rows(rowIdx).Cells(6).Value
        Dim str As String = ""
        For Each oItem As DataGridViewRow In DataGridViewSI.Rows
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

    Private Sub CmbCustomer_Click(sender As Object, e As EventArgs) Handles CmbCustomer.Click
        populateCust()
    End Sub

    Private Function findCustomerByKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select address1,address2,kode_customer,name_customer from customer where kode_customer ='" & kode & "'"
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

    Public Sub addSelectToList()
        Dim idx As Integer = DataGridViewSI.RowCount
        idx = idx - 1
        Dim listPO = New List(Of PoVO)
        listPO = SearchInvoiceForm.listSelectPo
        DataGridViewSI.Rows.Clear()
        If DataGridViewSI.Columns.Count = 11 Then
            DataGridViewSI.Columns.RemoveAt(DataGridViewSI.Columns.Count - 1)
        End If

        DataGridViewSI.Refresh()
        If type = "Select SO" Then
            For Each item As PoVO In listPO
                findItemsBySONo(item.NOPO)
            Next
            DataGridViewSI.Columns(7).Visible = True
            DataGridViewSI.Columns(8).Visible = False
        ElseIf type = "Select DO" Then
            For Each item As PoVO In listPO
                findItemsByDONo(item.NOPO)
            Next
            DataGridViewSI.Columns(7).Visible = False
            DataGridViewSI.Columns(8).Visible = True

        End If

        For Each oItem As DataGridViewRow In DataGridViewSI.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
            oItem.Cells(5).Value = CLng(oItem.Cells(5).Value)
        Next
        For Each oItem As DataGridViewRow In DataGridViewSI.Rows
            hitungTotalHarga(oItem.Index)
            formatKolomNumeric()
        Next
        hitungSubTotalHarga()
        calculatePctDiskon()
        If CheckCustTaxable.Checked = True Then
            hitungPPn()
        End If
        If CheckInclusiveTax.Checked = True Then
            hitungPPnInclusiveTax()
        End If
        DataGridViewSI.Refresh()
    End Sub

    Private Sub findItemsBySONo(soNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,i.default_price,i.default_diskon,'0', g.nama_gudang,ph.so_no,ph.diskon_pct,ph.cust_taxable,ph.inclusive_tax from sales_order_header ph left join sales_order_detail pd on ph.id = pd.so_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.so_no ='" & soNo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("default_price").ToString(), oRecord("default_diskon").ToString(), oRecord("nama_gudang").ToString(), oRecord("so_no").ToString()}
                    DataGridViewSI.Rows.Add(row)
                    TextBoxPctDiskon.Text = oRecord("diskon_pct")
                    If oRecord("cust_taxable") = 1 Then
                        CheckCustTaxable.Checked = True
                    Else
                        CheckCustTaxable.Checked = False
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

    Private Sub findItemsByDONo(DONo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,i.default_price,i.default_diskon,'0', g.nama_gudang,pd.so_no,ph.do_no from delivery_order_header ph left join delivery_order_detail pd on ph.id = pd.delivery_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.do_no ='" & DONo & "'"
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("default_price").ToString(), oRecord("default_diskon").ToString(), oRecord("nama_gudang").ToString(), oRecord("so_no").ToString(), oRecord("do_no").ToString()}
                    DataGridViewSI.Rows.Add(row)
                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim qty As Long
        Dim hargaSatuan As Long
        Dim hargaDiskon As Long
        qty = DataGridViewSI.Rows(rowIdx).Cells(2).Value
        hargaSatuan = DataGridViewSI.Rows(rowIdx).Cells(4).Value
        hargaDiskon = DataGridViewSI.Rows(rowIdx).Cells(5).Value
        Dim totalHarga As Long
        totalHarga = (qty * hargaSatuan) - (qty * hargaDiskon)
        DataGridViewSI.Rows(rowIdx).Cells(9).Value = totalHarga
    End Sub

    Private Sub CmbCustomer_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbCustomer.SelectionChangeCommitted
        findCustomerByKode(CmbCustomer.SelectedValue)
    End Sub

    Private Sub CheckCustTaxable_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckCustTaxable.CheckStateChanged
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

    Private Sub TextBoxSalesInvoiceNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSalesInvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePickerSalesInvoiceDate.Focus()
        End If
    End Sub

    Private Sub DateTimePickerSalesInvoiceDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerSalesInvoiceDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePickerShipDate.Focus()
        End If
    End Sub


    Private Sub DateTimePickerShipDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerShipDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckCustTaxable.Focus()
        End If
    End Sub

    Private Sub CheckCustTaxable_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckCustTaxable.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckInclusiveTax.Focus()
        End If
    End Sub

    Private Sub CheckInclusiveTax_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckInclusiveTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbCustomer.Focus()
        End If
    End Sub

    Private Sub ComboBoxSelectType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxSelectType.SelectionChangeCommitted
        If CmbCustomer.SelectedIndex = -1 Then
            MessageBox.Show("Customer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbCustomer.Focus()
            Return
        End If
        If TextBoxFormNo.Text = "" Then
            MessageBox.Show("Form No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxFormNo.Focus()
            Return
        End If
        type = ComboBoxSelectType.SelectedItem.ToString
        kodeCustomer = CmbCustomer.SelectedValue
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

    Private Function insertSI() As Integer
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
            If TextBoxSalesInvoiceNo.Text = "" Then
                MessageBox.Show("Sales Invoice No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxSalesInvoiceNo.Focus()
                Return 0
            End If

            If CmbCustomer.SelectedIndex = -1 Then
                MessageBox.Show("Customer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCustomer.Focus()
                Return 0
            End If

            If DataGridViewSI.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert SI Header
            sql = "INSERT INTO sales_invoice_header(kode_customer,nama_customer,bill_to,form_no,sales_invoice_no,sales_invoice_date,ship_date,notes,customer_taxable,inclusive_tax,sub_total,diskon_pct,diskon,tax_value,total_order,status_sales_invoice,created_by ) VALUES (@kode_customer,@nama_customer,@bill_to,@form_no,@sales_invoice_no,@sales_invoice_date,@ship_date,@notes,@customer_taxable,@inclusive_tax,@sub_total,@diskon_pct,@diskon,@tax_value,@total_order,@status_sales_invoice,@created_by)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_customer", TextBoxKodeCust.Text)
            sqlCommand.Parameters.AddWithValue("@nama_customer", TextBoxNamaCust.Text)
            sqlCommand.Parameters.AddWithValue("@bill_to", textBoxBillTo.Text)
            sqlCommand.Parameters.AddWithValue("@form_no", TextBoxFormNo.Text)
            sqlCommand.Parameters.AddWithValue("@sales_invoice_no", TextBoxSalesInvoiceNo.Text)
            sqlCommand.Parameters.AddWithValue("@sales_invoice_date", DateTimePickerSalesInvoiceDate.Value)
            sqlCommand.Parameters.AddWithValue("@ship_date", DateTimePickerShipDate.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            If CheckCustTaxable.Checked = True Then
                sqlCommand.Parameters.AddWithValue("@customer_taxable", 1)
            Else
                sqlCommand.Parameters.AddWithValue("@customer_taxable", 0)
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
            sqlCommand.Parameters.AddWithValue("@status_sales_invoice", 1)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert SI Detail

            sqlCommand.Parameters.Add("@sales_invoice_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@price_per_unit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@diskonDetail", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@price_total", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@kode_gudang", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@so_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@do_no", MySqlDbType.VarChar)
            For Each oItem As DataGridViewRow In DataGridViewSI.Rows
                sql = "INSERT INTO sales_invoice_detail(sales_invoice_header_id,kode_item,nama_item,qty,satuan,price_per_unit,diskon,price_total,kode_gudang,so_no,do_no) VALUES (@sales_invoice_header_id,@kode_item,@nama_item,@qty,@satuan,@price_per_unit,@diskonDetail,@price_total,@kode_gudang,@so_no,@do_no)"
                sqlCommand.CommandText = sql
                Dim SoNumber As String
                Dim DONumber As String
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@sales_invoice_header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@satuan").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@price_per_unit").Value = oItem.Cells(4).Value
                sqlCommand.Parameters("@diskonDetail").Value = oItem.Cells(5).Value
                sqlCommand.Parameters("@kode_gudang").Value = oItem.Cells(6).Value
                sqlCommand.Parameters("@so_no").Value = oItem.Cells(7).Value
                sqlCommand.Parameters("@do_no").Value = oItem.Cells(8).Value
                sqlCommand.Parameters("@price_total").Value = oItem.Cells(9).Value
                SoNumber = oItem.Cells(7).Value
                DONumber = oItem.Cells(8).Value
                sqlCommand.ExecuteNonQuery()

                If type = "Select SO" Then
                    ' update sales order header ubah status menjadi 3 karena sudah di invoicing barang nya
                    sql = "UPDATE sales_order_header SET status_so = 3 WHERE so_no = @so_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@so_no").Value = SoNumber
                    sqlCommand.ExecuteNonQuery()
                ElseIf type = "Select DO" Then
                    ' update table po status menjadi 3 dan update table receive item status ubah jadi 2
                    sql = "UPDATE sales_order_header SET status_so = 3 WHERE so_no = @so_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@so_no").Value = SoNumber
                    sqlCommand.ExecuteNonQuery()

                    sql = "UPDATE delivery_order_header SET status_delivery_order = 2 WHERE do_no = @do_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@do_no").Value = DONumber
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
        insertSI()
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub clearAllFIeld()
        TextBoxKodeCust.Text = ""
        TextBoxNamaCust.Text = ""
        TextBoxFormNo.Text = ""
        textBoxBillTo.Text = ""
        TextBoxSalesInvoiceNo.Text = ""
        CheckCustTaxable.Checked = False
        CheckInclusiveTax.Checked = False
        DataGridViewSI.Rows.Clear()
        TextBoxNotes.Text = ""
        TextBoxPctDiskon.Text = "0"
        TextBoxValueDiskon.Text = "0"
        TextBoxSalesInvoiceNo.Focus()
        TextBoxSubTotal.Text = "0"
        TextBoxPPn.Text = "0"
        TextBoxTotalOrder.Text = "0"
        CmbCustomer.SelectedIndex = -1
    End Sub

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click
        insertSI()
        Me.Close()
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        insertSI()
        'printPIByNoInvoice(TextBoxSalesInvoiceNo.Text)
        clearAllFIeld()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub printSIByNoInvoice(invoiceNo As String)
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

    Private Sub disableButton()
        ButtonSaveClose.Enabled = False
        ButtonSaveNew.Enabled = False
        SavePrint.Enabled = False
        Cancel.Enabled = False
        CheckCustTaxable.Enabled = False
        CheckInclusiveTax.Enabled = False
        TextBoxSalesInvoiceNo.Enabled = False
        TextBoxNotes.Enabled = False
    End Sub
    Private Sub enableButton()
        ButtonSaveClose.Enabled = True
        ButtonSaveNew.Enabled = True
        SavePrint.Enabled = True
        Cancel.Enabled = True
        CheckCustTaxable.Enabled = True
        CheckInclusiveTax.Enabled = True
        TextBoxSalesInvoiceNo.Enabled = True
        TextBoxNotes.Enabled = True
    End Sub

    Private Sub PrevPO_Click(sender As Object, e As EventArgs) Handles PrevPO.Click
        findSIBySeqPrev(idPrimary.Text)
    End Sub

    Private Sub findSIBySeqPrev(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select *,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier from sales_invoice_header ph inner join sales_invoice_detail pd on ph.id = pd.sales_invoice_header_id inner join customer s on s.kode_customer = ph.kode_customer where ph.id < '" & idPrimary & "' order by ph.id desc limit 0,1"
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
                    CmbCustomer.SelectedIndex = CmbCustomer.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(48)) Then
                    textBoxBillTo.Text = publictable.Rows(0).Item(48)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    TextBoxSalesInvoiceNo.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerSalesInvoiceDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(9)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(10)
                    If taxable = 1 Then
                        CheckCustTaxable.Checked = True
                    Else
                        CheckCustTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(11)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(12)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(14)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(14)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(15)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(15)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(16)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(16)
                End If
                'Detail
                sql = "select * from sales_invoice_detail pd where pd.sales_invoice_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewSI.Rows.Clear()
                DataGridViewSI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("so_no").ToString(), oRecord("do_no").ToString(), oRecord("price_total").ToString()}
                    DataGridViewSI.Rows.Add(row)
                    'row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString()}
                    'DataGridViewPI.Rows.Add(row)

                Next
                DataGridViewSI.Refresh()
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

    Private Sub findSIBySeqNext(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select *,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier from sales_invoice_header ph inner join sales_invoice_detail pd on ph.id = pd.sales_invoice_header_id inner join customer s on s.kode_customer = ph.kode_customer where ph.id > '" & idPrimary & "' order by ph.id asc limit 0,1"
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
                    CmbCustomer.SelectedIndex = CmbCustomer.FindStringExact(publictable.Rows(0).Item(2))
                End If
                If Not IsDBNull(publictable.Rows(0).Item(48)) Then
                    textBoxBillTo.Text = publictable.Rows(0).Item(48)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    TextBoxFormNo.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    TextBoxSalesInvoiceNo.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    DateTimePickerSalesInvoiceDate.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    DateTimePickerShipDate.Text = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(9)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(10)
                    If taxable = 1 Then
                        CheckCustTaxable.Checked = True
                    Else
                        CheckCustTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(11)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(12)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(14)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(14)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(15)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(15)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(16)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(16)
                End If
                'Detail
                sql = "select * from sales_invoice_detail pd where pd.sales_invoice_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewSI.Rows.Clear()
                DataGridViewSI.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("so_no").ToString(), oRecord("do_no").ToString(), oRecord("price_total").ToString()}
                    DataGridViewSI.Rows.Add(row)
                    'row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("kode_gudang").ToString(), oRecord("po_no").ToString()}
                    'DataGridViewPI.Rows.Add(row)

                Next
                DataGridViewSI.Refresh()
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

    Private Sub NextPo_Click(sender As Object, e As EventArgs) Handles NextPo.Click
        findSIBySeqNext(idPrimary.Text)
    End Sub
End Class