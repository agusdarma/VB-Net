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
        Else
            lblPPN.Visible = False
            LblPPnRp.Visible = False
            TextBoxPPn.Visible = False
            lblTax.Visible = False
            CheckInclusiveTax.Enabled = False
            CheckInclusiveTax.Checked = False
            clearHitungPPn()
            Exit Sub
        End If
        If CheckInclusiveTax.Checked = True Then
            lblPPN.Visible = True
            LblPPnRp.Visible = True
            TextBoxPPn.Visible = True
            lblTax.Visible = True
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
        End If
    End Sub
    Private Sub calculatePctDiskon()
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
        totalOrder = (subTotal - valueDiskon) + (ppnValue + freight)
        TextBoxTotalOrder.Text = FormatNumber(totalOrder.ToString, 0, TriState.True)
    End Sub

    Private Sub TextBoxValueDiskon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxValueDiskon.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
            TextBoxValueDiskon.Text = FormatNumber(TextBoxValueDiskon.Text.ToString, 0, TriState.True)
            TextBoxFreight.Focus()
        End If
    End Sub

    Private Sub TextBoxFreight_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFreight.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBoxFreight.Text = FormatNumber(TextBoxFreight.Text.ToString, 0, TriState.True)
            ButtonSaveNew.Focus()
            calculateTotalOrder()
        End If
    End Sub

    Private Sub TextBoxValueDiskon_Leave(sender As Object, e As EventArgs) Handles TextBoxValueDiskon.Leave
        TextBoxValueDiskon.TextAlign = HorizontalAlignment.Right
    End Sub
End Class