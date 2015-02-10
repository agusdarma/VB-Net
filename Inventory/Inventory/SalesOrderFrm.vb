Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class SalesOrderFrm
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
    Private Sub SalesOrderFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxPoNo.Focus()
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
            Sql = "select id from sales_order_header order by id desc limit 0,1"
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
        Dim freight As Long = CLng(TextBoxFreight.Text)
        Dim totalOrder As Long
        If TextBoxPPn.Visible = False Then
            ppnValue = 0
        End If
        If CheckInclusiveTax.Checked Then
            totalOrder = (subTotal - valueDiskon) + freight
        Else
            totalOrder = (subTotal - valueDiskon) + (ppnValue + freight)
        End If
        TextBoxTotalOrder.Text = FormatNumber(totalOrder.ToString, 0, TriState.True)
    End Sub

    Private Sub hitungSubTotalHarga()
        Dim totalharga As Long = 0
        'totalharga = DataGridViewPO.Rows(rowIdx).Cells(6).Value
        Dim str As String = ""
        For Each oItem As DataGridViewRow In DataGridViewSO.Rows
            totalharga = totalharga + oItem.Cells(6).Value
        Next
        Dim subTotal As Long = totalharga
        TextBoxSubTotal.Text = FormatNumber(subTotal.ToString, 0, TriState.True)
        calculatePctDiskon()
        calculateTotalOrder()
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
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim soNoSystem As String = "SO/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxSoNo.Text = soNoSystem


        Me.DataGridViewSO.ColumnCount = 7
        Me.DataGridViewSO.Columns(0).Name = "Kode Item"
        Me.DataGridViewSO.Columns(1).Name = "Nama Item"
        Me.DataGridViewSO.Columns(2).Name = "Qty"
        Me.DataGridViewSO.Columns(3).Name = "Satuan"
        Me.DataGridViewSO.Columns(4).Name = "Harga Satuan"
        Me.DataGridViewSO.Columns(5).Name = "Diskon"
        Me.DataGridViewSO.Columns(6).Name = "Total Harga"


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

    Public Sub addItemToListSO(kodeItem As String, namaItem As String, satuan As String, price As String, diskon As String)
        Dim idx As Integer = DataGridViewSO.RowCount
        idx = idx - 1
        DataGridViewSO.Rows(idx).Cells(2).Selected = True
        DataGridViewSO.CurrentCell = Me.DataGridViewSO(2, idx)
        DataGridViewSO.BeginEdit(True)
        'DataGridViewPO.EndEdit()

        DataGridViewSO.Rows(idx).Cells(0).Value = kodeItem
        DataGridViewSO.Rows(idx).Cells(1).Value = namaItem
        DataGridViewSO.Rows(idx).Cells(2).Value = CLng(1)
        DataGridViewSO.Rows(idx).Cells(3).Value = satuan
        DataGridViewSO.Rows(idx).Cells(4).Value = CLng(price)
        DataGridViewSO.Rows(idx).Cells(5).Value = CLng(diskon)

        DataGridViewSO.Rows(idx).Cells(0).ReadOnly = True
        DataGridViewSO.Rows(idx).Cells(1).ReadOnly = True
        DataGridViewSO.Rows(idx).Cells(6).ReadOnly = True
        hitungTotalHarga(idx)
        formatKolomNumeric()
    End Sub
    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim qty As Long
        Dim hargaSatuan As Long
        Dim hargaDiskon As Long
        qty = DataGridViewSO.Rows(rowIdx).Cells(2).Value
        hargaSatuan = DataGridViewSO.Rows(rowIdx).Cells(4).Value
        hargaDiskon = DataGridViewSO.Rows(rowIdx).Cells(5).Value
        Dim totalHarga As Long
        totalHarga = (qty * hargaSatuan) - (qty * hargaDiskon)
        DataGridViewSO.Rows(rowIdx).Cells(6).Value = totalHarga
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewSO.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSO.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSO.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSO.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSO.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSO.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSO.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSO.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
            CmbCust.DataSource = ds.Tables(0)
            CmbCust.ValueMember = "id"
            CmbCust.DisplayMember = "name_customer"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
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

    Private Sub CmbCust_Click(sender As Object, e As EventArgs) Handles CmbCust.Click
        populateCust()
    End Sub

    Private Sub CmbCust_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbCust.SelectionChangeCommitted
        findCustomerById(CmbCust.SelectedValue)
        TextBoxShipTo.Focus()
    End Sub

    Private Sub CheckCustTaxable_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckCustTaxable.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub CheckInclusiveTax_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckInclusiveTax.CheckStateChanged
        inisialisasi()
    End Sub

    Private Sub DataGridViewSO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSO.CellDoubleClick
        If e.ColumnIndex = 0 Then
            AdvancedSearchItems.menuCalling = "SalesOrderFrm"
            AdvancedSearchItems.Show()
        End If
    End Sub

    Private Sub DataGridViewSO_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSO.CellEndEdit
        If e.ColumnIndex = 0 Then
            AdvancedSearchItems.Show()
        ElseIf e.ColumnIndex = 2 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        ElseIf e.ColumnIndex = 4 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        ElseIf e.ColumnIndex = 5 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        End If
    End Sub

    Private Sub DataGridViewSO_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewSO.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.rowIndex = e.RowIndex
            Me.ContextMenuStrip1.Show(Me.DataGridViewSO, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteRows_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDeleteRows.Click
        Try
            If Not Me.DataGridViewSO.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridViewSO.Rows.RemoveAt(Me.rowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItemAddRows_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAddRows.Click
        DataGridViewSO.ClearSelection()
        Dim idx As Integer = DataGridViewSO.RowCount
        idx = idx - 1
        If idx >= 0 Then
            DataGridViewSO.Rows(idx).Cells(0).Selected = True
            DataGridViewSO.CurrentCell = Me.DataGridViewSO(0, idx)
            DataGridViewSO.NotifyCurrentCellDirty(True)
        Else
            DataGridViewSO.NotifyCurrentCellDirty(True)
        End If
    End Sub

    Private Sub DataGridViewSO_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewSO.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
    End Sub

    Private Sub DataGridViewSO_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewSO.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Try
                Dim iColumn As Integer = DataGridViewSO.CurrentCell.ColumnIndex
                Dim iRows As Integer = DataGridViewSO.CurrentCell.RowIndex
                DataGridViewSO.ClearSelection()
                DataGridViewSO.Rows(iRows).Cells(iColumn + 1).Selected = True
                ' Set the current cell to the cell in column 1, Row 0. 
                DataGridViewSO.CurrentCell = Me.DataGridViewSO(iColumn + 1, iRows)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DataGridViewSO_Leave(sender As Object, e As EventArgs) Handles DataGridViewSO.Leave
        hitungSubTotalHarga()
        calculatePctDiskon()
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

    Private Sub TextBoxValueDiskon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxValueDiskon.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
            If TextBoxValueDiskon.Text = "" Then
                TextBoxValueDiskon.Text = 0
                TextBoxPctDiskon.Text = 0
            End If
            TextBoxValueDiskon.Text = FormatNumber(TextBoxValueDiskon.Text.ToString, 0, TriState.True)
            TextBoxFreight.Focus()
            If CheckInclusiveTax.Checked Then
                hitungPPnInclusiveTax()
            Else
                hitungPPn()
            End If
            calculateTotalOrder()
        End If
    End Sub

    Private Sub TextBoxFreight_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFreight.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxFreight.Text = "" Then
                TextBoxFreight.Text = 0
            End If
            TextBoxFreight.Text = FormatNumber(TextBoxFreight.Text.ToString, 0, TriState.True)
            ButtonSaveNew.Focus()
            calculateTotalOrder()
        End If
    End Sub

    Private Sub TextBoxValueDiskon_Leave(sender As Object, e As EventArgs) Handles TextBoxValueDiskon.Leave
        TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
        If TextBoxValueDiskon.Text = "" Then
            TextBoxValueDiskon.Text = 0
            TextBoxPctDiskon.Text = 0
        End If
        TextBoxValueDiskon.Text = FormatNumber(TextBoxValueDiskon.Text.ToString, 0, TriState.True)
        TextBoxFreight.Focus()
        If CheckInclusiveTax.Checked Then
            hitungPPnInclusiveTax()
        Else
            hitungPPn()
        End If
        calculateTotalOrder()
    End Sub

    Private Sub TextBoxPoNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPoNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateTimePickerSoDate.Focus()
        End If
    End Sub

    Private Sub DateTimePickerSoDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerSoDate.KeyDown
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
            CmbCust.Focus()
        End If
    End Sub

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        'If countPOByPONo(TextBoxPoNo.Text) = 0 Then
        Dim temp As Integer = insertSO()
        If temp <> 0 Then
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        End If

        'Else
        'MessageBox.Show("No PO duplikat, ganti dengan No PO yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub clearAllFIeld()
        TextBoxKodeCust.Text = ""
        TextBoxNamaCust.Text = ""
        textBoxBillTo.Text = ""
        TextBoxShipTo.Text = ""
        TextBoxPoNo.Text = ""
        CheckCustTaxable.Checked = False
        CheckInclusiveTax.Checked = False
        DataGridViewSO.Rows.Clear()
        TextBoxNotes.Text = ""
        TextBoxPctDiskon.Text = "0"
        TextBoxValueDiskon.Text = "0"
        TextBoxFreight.Text = "0"
        TextBoxPoNo.Focus()
        TextBoxSubTotal.Text = "0"
        TextBoxPPn.Text = "0"
        TextBoxTotalOrder.Text = "0"
        CmbCust.SelectedIndex = -1
    End Sub
    Private Sub removeSeparator(txtBox As TextBox)
        Dim temp As String
        temp = txtBox.Text
        temp = temp.Replace(",", "")
        txtBox.Text = temp
    End Sub
    Private Sub removeSeparatorBeforeInsert()
        removeSeparator(TextBoxFreight)
        removeSeparator(TextBoxPPn)
        removeSeparator(TextBoxPctDiskon)
        removeSeparator(TextBoxSubTotal)
        removeSeparator(TextBoxTotalOrder)
        removeSeparator(TextBoxValueDiskon)
    End Sub

    Private Function insertSO() As Integer
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
            If TextBoxPoNo.Text.Length > 0 Then
                sqlCommand.Parameters.AddWithValue("@po_no", TextBoxPoNo.Text)
            Else
                MessageBox.Show("PO No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxPoNo.Focus()
                Return 0
            End If
            If CmbCust.SelectedIndex = -1 Then
                MessageBox.Show("Customer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCust.Focus()
                Return 0
            End If

            If DataGridViewSO.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert SO Header
            sql = "INSERT INTO sales_order_header(kode_customer,nama_customer,bill_to,ship_to,cust_taxable,inclusive_tax,po_no,so_no,so_date,ship_date,notes,sub_total,diskon,diskon_pct,tax_value,cost_ship,total_order,status_so,created_by) VALUES (@kode_customer,@nama_customer,@bill_to,@ship_to,@cust_taxable,@inclusive_tax,@po_no,@so_no,@so_date,@ship_date,@notes,@sub_total,@diskon,@diskon_pct,@tax_value,@cost_ship,@total_order,@status_so,@created_by)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_customer", TextBoxKodeCust.Text)
            sqlCommand.Parameters.AddWithValue("@nama_customer", TextBoxNamaCust.Text)
            sqlCommand.Parameters.AddWithValue("@bill_to", textBoxBillTo.Text)
            sqlCommand.Parameters.AddWithValue("@ship_to", TextBoxShipTo.Text)
            If CheckCustTaxable.Checked = True Then
                sqlCommand.Parameters.AddWithValue("@cust_taxable", 1)
            Else
                sqlCommand.Parameters.AddWithValue("@cust_taxable", 0)
            End If
            If CheckInclusiveTax.Checked = True Then
                sqlCommand.Parameters.AddWithValue("@inclusive_tax", 1)
            Else
                sqlCommand.Parameters.AddWithValue("@inclusive_tax", 0)
            End If

            sqlCommand.Parameters.AddWithValue("@so_no", TextBoxSoNo.Text)
            sqlCommand.Parameters.AddWithValue("@so_date", DateTimePickerSoDate.Value)
            sqlCommand.Parameters.AddWithValue("@ship_date", DateTimePickerShipDate.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            sqlCommand.Parameters.AddWithValue("@sub_total", TextBoxSubTotal.Text)
            sqlCommand.Parameters.AddWithValue("@diskon", TextBoxValueDiskon.Text)
            sqlCommand.Parameters.AddWithValue("@diskon_pct", TextBoxValueDiskon.Text)
            sqlCommand.Parameters.AddWithValue("@tax_value", TextBoxPPn.Text)
            sqlCommand.Parameters.AddWithValue("@cost_ship", TextBoxFreight.Text)
            sqlCommand.Parameters.AddWithValue("@total_order", TextBoxTotalOrder.Text)
            sqlCommand.Parameters.AddWithValue("@status_so", 1)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert SO Detail
            sql = "INSERT INTO sales_order_detail(so_header_id,kode_item,nama_item,qty,satuan,price_per_unit,diskon,price_total) VALUES (@so_header_id,@kode_item,@nama_item,@qty,@satuan,@price_per_unit,@diskonDetail,@price_total)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.Add("@so_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@price_per_unit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@diskonDetail", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@price_total", MySqlDbType.Int64)
            For Each oItem As DataGridViewRow In DataGridViewSO.Rows
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@so_header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@satuan").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@price_per_unit").Value = oItem.Cells(4).Value
                sqlCommand.Parameters("@diskonDetail").Value = oItem.Cells(5).Value
                sqlCommand.Parameters("@price_total").Value = oItem.Cells(6).Value
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

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click
        'If countPOByPONo(TextBoxPoNo.Text) = 0 Then
        Dim temp As Integer = insertSO()
        If temp <> 0 Then
            Me.Close()
        End If
        'Else
        'MessageBox.Show("No PO duplikat, ganti dengan No PO yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
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

    Private Sub TextBoxFreight_Leave(sender As Object, e As EventArgs) Handles TextBoxFreight.Leave
        If TextBoxFreight.Text = "" Then
            TextBoxFreight.Text = 0
        End If
        TextBoxFreight.Text = FormatNumber(TextBoxFreight.Text.ToString, 0, TriState.True)
        ButtonSaveNew.Focus()
        calculateTotalOrder()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        Dim temp As Integer = insertSO()
        If temp <> 0 Then
            printSoByNoSO(TextBoxSoNo.Text)
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        End If
        
    End Sub
    Private Sub printSoByNoSO(noSO As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Dim sqlSelectGeneral As String = "select ph.po_no,ph.so_no ,ph.so_date,ph.ship_date, ph.bill_to,ph.ship_to, ph.nama_customer ,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit"
        Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
        Dim sqlSelectPnn As String
        Try
            sql = sqlSelectGeneral + sqlSelectCompanyName + sqlSelectPnn + " from  sales_order_header ph inner join sales_order_detail pd on ph.id = pd.so_header_id where ph.so_no = @soNo"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@soNo", noSO)
            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukSO.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
End Class