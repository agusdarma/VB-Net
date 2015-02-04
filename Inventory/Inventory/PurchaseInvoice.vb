Imports MySql.Data.MySqlClient

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
            DataGridViewPI.Columns(8).Visible = False
        ElseIf type = "Select RI" Then


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
        DataGridViewPI.Refresh()
    End Sub
    Private Sub findItemsByPONo(poNo As String)

        Dim sql As String
        Dim sqlCommand As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            con.Open()
            sql = "select pd.kode_item,pd.nama_item,pd.qty,pd.satuan,i.default_price,i.default_diskon,'0', g.nama_gudang,ph.po_no from purchase_order_header ph left join purchase_order_detail pd on ph.id = pd.po_header_id left join items i on i.kode_item = pd.kode_item left join gudang g on g.id = i.gudang_id where ph.po_no ='" & poNo & "'"
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
End Class