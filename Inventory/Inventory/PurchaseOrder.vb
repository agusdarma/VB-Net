Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

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
        TextBoxPoNo.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim poNoSystem As String = "PO/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxPoNo.Text = poNoSystem


        Me.DataGridViewPO.ColumnCount = 7
        Me.DataGridViewPO.Columns(0).Name = "Kode Item"
        Me.DataGridViewPO.Columns(1).Name = "Nama Item"
        Me.DataGridViewPO.Columns(2).Name = "Qty"
        Me.DataGridViewPO.Columns(3).Name = "Satuan"
        Me.DataGridViewPO.Columns(4).Name = "Harga Satuan"
        Me.DataGridViewPO.Columns(5).Name = "Diskon"
        Me.DataGridViewPO.Columns(6).Name = "Total Harga"


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

    Public Sub addItemToListPO(kodeItem As String, namaItem As String, satuan As String, price As String, diskon As String)
        Dim idx As Integer = DataGridViewPO.RowCount
        idx = idx - 1
        DataGridViewPO.Rows(idx).Cells(2).Selected = True
        DataGridViewPO.CurrentCell = Me.DataGridViewPO(2, idx)
        DataGridViewPO.BeginEdit(True)
        'DataGridViewPO.EndEdit()

        DataGridViewPO.Rows(idx).Cells(0).Value = kodeItem
        DataGridViewPO.Rows(idx).Cells(1).Value = namaItem
        DataGridViewPO.Rows(idx).Cells(2).Value = CLng(1)
        DataGridViewPO.Rows(idx).Cells(3).Value = satuan
        DataGridViewPO.Rows(idx).Cells(4).Value = CLng(price)
        DataGridViewPO.Rows(idx).Cells(5).Value = CLng(diskon)

        DataGridViewPO.Rows(idx).Cells(0).ReadOnly = True
        DataGridViewPO.Rows(idx).Cells(1).ReadOnly = True
        DataGridViewPO.Rows(idx).Cells(6).ReadOnly = True
        hitungTotalHarga(idx)
        formatKolomNumeric()
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewPO.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPO.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPO.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPO.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPO.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPO.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPO.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPO.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
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
            sql = "select address1,address2,kode_supplier,name_supplier from supplier where id ='" & id & "'"
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

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
    End Sub

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierById(CmbVendor.SelectedValue)
        TextBoxShipTo.Focus()
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
    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim qty As Long
        Dim hargaSatuan As Long
        Dim hargaDiskon As Long
        qty = DataGridViewPO.Rows(rowIdx).Cells(2).Value
        hargaSatuan = DataGridViewPO.Rows(rowIdx).Cells(4).Value
        hargaDiskon = DataGridViewPO.Rows(rowIdx).Cells(5).Value
        Dim totalHarga As Long
        totalHarga = (qty * hargaSatuan) - (qty * hargaDiskon)
        DataGridViewPO.Rows(rowIdx).Cells(6).Value = totalHarga
    End Sub

    Private Sub DataGridViewPO_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPO.CellEndEdit
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
        DataGridViewPO.ClearSelection()
        Dim idx As Integer = DataGridViewPO.RowCount
        idx = idx - 1
        If idx >= 0 Then
            DataGridViewPO.Rows(idx).Cells(0).Selected = True
            DataGridViewPO.CurrentCell = Me.DataGridViewPO(0, idx)
            DataGridViewPO.NotifyCurrentCellDirty(True)
        Else
            DataGridViewPO.NotifyCurrentCellDirty(True)
        End If
    End Sub

    Private Sub DataGridViewPO_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPO.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
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

    Private Sub hitungSubTotalHarga()
        Dim totalharga As Long = 0
        'totalharga = DataGridViewPO.Rows(rowIdx).Cells(6).Value
        Dim str As String = ""
        For Each oItem As DataGridViewRow In DataGridViewPO.Rows
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
    Private Sub DataGridViewPO_Leave(sender As Object, e As EventArgs) Handles DataGridViewPO.Leave
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
            DateTimePickerPoDate.Focus()
        End If
    End Sub

    Private Sub DateTimePickerPoDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePickerPoDate.KeyDown
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

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        If countPOByPONo(TextBoxPoNo.Text) = 0 Then
            insertPOHeader()
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString
        Else
            MessageBox.Show("No PO duplikat, ganti dengan No PO yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub
    Private Sub clearAllFIeld()
        TextBoxKodeSupplier.Text = ""
        TextBoxNamaSupplier.Text = ""
        alamatVendor.Text = ""
        TextBoxShipTo.Text = ""
        TextBoxPoNo.Text = ""
        CheckVendorTaxable.Checked = False
        CheckInclusiveTax.Checked = False
        DataGridViewPO.Rows.Clear()
        TextBoxNotes.Text = ""
        TextBoxPctDiskon.Text = "0"
        TextBoxValueDiskon.Text = "0"
        TextBoxFreight.Text = "0"
        TextBoxPoNo.Focus()
        TextBoxSubTotal.Text = "0"
        TextBoxPPn.Text = "0"
        TextBoxTotalOrder.Text = "0"
        CmbVendor.SelectedIndex = -1
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

    Private Function insertPOHeader() As Integer
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
            If CmbVendor.SelectedIndex = -1 Then
                MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbVendor.Focus()
                Return 0
            End If

            If DataGridViewPO.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert PO Header
            sql = "INSERT INTO purchase_order_header(kode_supplier,nama_supplier,alamat_supplier,ship_to,supplier_taxable,inclusive_tax,po_no,po_date,expected_date,fob,terms,ship_via,notes,available_dp,used_dp,sub_total,diskon,tax_value,cost_ship,total_order,status_po,created_by,diskon_pct) VALUES (@kode_supplier,@nama_supplier,@alamat_supplier,@ship_to,@supplier_taxable,@inclusive_tax,@po_no,@po_date,@expected_date,@fob,@terms,@ship_via,@notes,@available_dp,@used_dp,@sub_total,@diskon,@tax_value,@cost_ship,@total_order,@status_po,@created_by,@diskon_pct)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_supplier", TextBoxKodeSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@nama_supplier", TextBoxNamaSupplier.Text)
            sqlCommand.Parameters.AddWithValue("@alamat_supplier", alamatVendor.Text)
            sqlCommand.Parameters.AddWithValue("@ship_to", TextBoxShipTo.Text)
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


            sqlCommand.Parameters.AddWithValue("@po_date", DateTimePickerPoDate.Value)
            sqlCommand.Parameters.AddWithValue("@expected_date", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@fob", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@terms", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@ship_via", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@notes", TextBoxNotes.Text)
            sqlCommand.Parameters.AddWithValue("@available_dp", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@used_dp", DBNull.Value)
            sqlCommand.Parameters.AddWithValue("@sub_total", TextBoxSubTotal.Text)
            sqlCommand.Parameters.AddWithValue("@diskon", TextBoxValueDiskon.Text)
            sqlCommand.Parameters.AddWithValue("@tax_value", TextBoxPPn.Text)
            sqlCommand.Parameters.AddWithValue("@cost_ship", TextBoxFreight.Text)
            sqlCommand.Parameters.AddWithValue("@total_order", TextBoxTotalOrder.Text)
            sqlCommand.Parameters.AddWithValue("@status_po", 1)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@diskon_pct", TextBoxPctDiskon.Text)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert PO Detail
            sql = "INSERT INTO purchase_order_detail(po_header_id,kode_item,nama_item,qty,satuan,price_per_unit,diskon,price_total) VALUES (@po_header_id,@kode_item,@nama_item,@qty,@satuan,@price_per_unit,@diskonDetail,@price_total)"
            'sql = "INSERT INTO purchase_order_detail(po_header_id) VALUES (@po_header_id)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.Add("@po_header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@satuan", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@price_per_unit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@diskonDetail", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@price_total", MySqlDbType.Int64)
            For Each oItem As DataGridViewRow In DataGridViewPO.Rows
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sqlCommand.Parameters("@po_header_id").Value = ID
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
        If countPOByPONo(TextBoxPoNo.Text) = 0 Then
            insertPOHeader()
            Me.Close()
        Else
            MessageBox.Show("No PO duplikat, ganti dengan No PO yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub

    Private Sub printPoByNoPO(noPO As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Dim sqlSelectGeneral As String = "select ph.po_no,ph.po_date,ph.nama_supplier,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit"
        Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
        Dim sqlSelectPnn As String
        Try
            If CheckVendorTaxable.Checked = False Then
                sqlSelectPnn = ",'' as ppn "
            Else
                sqlSelectPnn = ",'Include PPN' as ppn "
            End If
            sql = sqlSelectGeneral + sqlSelectCompanyName + sqlSelectPnn + " from  purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id where ph.po_no = @poNo"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@poNo", noPO)
            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukPO.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        If countPOByPONo(TextBoxPoNo.Text) = 0 Then
            insertPOHeader()
            printPoByNoPO(TextBoxPoNo.Text)
            clearAllFIeld()
            inisialisasi()
            Me.idPrimary.Text = getPrimaryId().ToString

        Else
            MessageBox.Show("No PO duplikat, ganti dengan No PO yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Function countPOByPONo(noPO As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from  purchase_order_header where po_no ='" & noPO & "'"
            Dim scalarCommand As New MySqlCommand(Sql, con)
            db = scalarCommand.ExecuteScalar()
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try
        Return db
    End Function

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
    Private Sub findPOBySeqNext(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id where ph.id > '" & idPrimary & "' order by ph.id asc limit 0,1"
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
                    TextBoxShipTo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(5)
                    If taxable = 1 Then
                        CheckVendorTaxable.Checked = True
                    Else
                        CheckVendorTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(6)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    TextBoxPoNo.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    DateTimePickerPoDate.Text = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(16)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(16)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(17)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(17)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(18)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(18)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(19)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(19)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(20)) Then
                    TextBoxFreight.Text = publictable.Rows(0).Item(20)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(21)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(21)
                End If
                'Detail
                sql = "select * from purchase_order_detail pd where pd.po_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewPO.Rows.Clear()
                DataGridViewPO.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("price_total").ToString()}
                    DataGridViewPO.Rows.Add(row)
                Next
                DataGridViewPO.Refresh()
                disableButton()
            Else
                MessageBox.Show("This is Last data", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    Private Sub findPOBySeqPrev(idPrimary As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            Dim detail As New DataTable
            sql = "select * from purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id where ph.id < '" & idPrimary & "' order by ph.id desc limit 0,1"
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
                    TextBoxShipTo.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    Dim taxable As Integer
                    taxable = publictable.Rows(0).Item(5)
                    If taxable = 1 Then
                        CheckVendorTaxable.Checked = True
                    Else
                        CheckVendorTaxable.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    Dim inclusiveTax As Integer
                    inclusiveTax = publictable.Rows(0).Item(6)
                    If inclusiveTax = 1 Then
                        CheckInclusiveTax.Checked = True
                    Else
                        CheckInclusiveTax.Checked = False
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    TextBoxPoNo.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    DateTimePickerPoDate.Text = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    TextBoxNotes.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(16)) Then
                    TextBoxSubTotal.Text = publictable.Rows(0).Item(16)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(17)) Then
                    TextBoxValueDiskon.Text = publictable.Rows(0).Item(17)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(18)) Then
                    TextBoxPctDiskon.Text = publictable.Rows(0).Item(18)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(19)) Then
                    TextBoxPPn.Text = publictable.Rows(0).Item(19)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(20)) Then
                    TextBoxFreight.Text = publictable.Rows(0).Item(20)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(21)) Then
                    TextBoxTotalOrder.Text = publictable.Rows(0).Item(21)
                End If
                'Detail
                sql = "select * from purchase_order_detail pd where pd.po_header_id = '" & publictable.Rows(0).Item(0) & "' order by pd.id asc"
                con = jokenconn()
                con.Open()
                sqlCommand.Connection = con
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(detail)
                con.Close()
                'Reading DataTable Rows Column Value using Column Index Number
                Dim row As String()
                DataGridViewPO.Rows.Clear()
                DataGridViewPO.Refresh()
                For Each oRecord As Object In detail.Rows
                    row = New String() {oRecord("kode_item").ToString(), oRecord("nama_item").ToString(), oRecord("qty").ToString(), oRecord("satuan").ToString(), oRecord("price_per_unit").ToString(), oRecord("diskon").ToString(), oRecord("price_total").ToString()}
                    DataGridViewPO.Rows.Add(row)
                Next
                DataGridViewPO.Refresh()
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
    Private Sub disableButton()
        ButtonSaveClose.Enabled = False
        ButtonSaveNew.Enabled = False
        SavePrint.Enabled = False
        Cancel.Enabled = False
        CheckVendorTaxable.Enabled = False
        CheckInclusiveTax.Enabled = False
    End Sub
    Private Sub enableButton()
        ButtonSaveClose.Enabled = True
        ButtonSaveNew.Enabled = True
        SavePrint.Enabled = True
        Cancel.Enabled = True
        CheckVendorTaxable.Enabled = True
        CheckInclusiveTax.Enabled = True
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from purchase_order_header order by id desc limit 0,1"
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
    Private Sub PrevPO_Click(sender As Object, e As EventArgs) Handles PrevPO.Click        
        findPOBySeqPrev(idPrimary.Text)
    End Sub

    Private Sub NextPo_Click(sender As Object, e As EventArgs) Handles NextPo.Click
        findPOBySeqNext(idPrimary.Text)
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class