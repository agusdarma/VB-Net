Imports MySql.Data.MySqlClient

Public Class SalesRetail
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

    Private Sub SalesRetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridViewRetail.ColumnCount = 8
        Me.DataGridViewRetail.Columns(0).Name = "Barcode"
        Me.DataGridViewRetail.Columns(1).Name = "Kode Item"
        Me.DataGridViewRetail.Columns(2).Name = "Nama Item"
        Me.DataGridViewRetail.Columns(3).Name = "Qty"
        Me.DataGridViewRetail.Columns(4).Name = "Satuan"
        Me.DataGridViewRetail.Columns(5).Name = "Harga Satuan"
        Me.DataGridViewRetail.Columns(6).Name = "Diskon"
        Me.DataGridViewRetail.Columns(7).Name = "Total Harga"
        Me.Show()
        txtBarcode.Focus()
        txtBarcode.SelectAll()
    End Sub

    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        txtBarcode.SelectAll()
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)
        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Dim db As Integer
                Dim sql As String
                Dim cmd As New MySqlCommand
                Dim publictable As New DataTable
                Dim barcode As String
                barcode = txtBarcode.Text
                Try
                    con = jokenconn()
                    sql = "select i.kode_item,i.nama_item,i.quantity, i.satuan,i.default_price,i.default_diskon from items i where i.barcode ='" & barcode & "'"
                    With cmd
                        .Connection = con
                        .CommandText = sql
                    End With
                    da.SelectCommand = cmd
                    da.Fill(publictable)
                    If publictable.Rows.Count > 0 Then
                        addItemToList(barcode, publictable.Rows(0).Item(0), publictable.Rows(0).Item(1), publictable.Rows(0).Item(2), publictable.Rows(0).Item(3), publictable.Rows(0).Item(4), publictable.Rows(0).Item(5))
                    Else
                        MessageBox.Show("Items not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("error : " + ex.ToString)
                Finally
                    con.Close()
                End Try
            End If
        End If
    End Sub
    Public Sub addItemToList(barcode As String, kodeItem As String, namaItem As String, qty As String, satuan As String, price As String, diskon As String)
        Dim idx As Integer = DataGridViewRetail.RowCount
        Dim idx2 As Integer = DataGridViewRetail.RowCount
        idx = idx - 1
        If idx < 0 Then
            DataGridViewRetail.Rows.Add()
            DataGridViewRetail.NotifyCurrentCellDirty(True)
            DataGridViewRetail.Rows(0).Cells(0).Value = barcode
            DataGridViewRetail.Rows(0).Cells(1).Value = kodeItem
            DataGridViewRetail.Rows(0).Cells(2).Value = namaItem
            DataGridViewRetail.Rows(0).Cells(3).Value = CLng(1)
            DataGridViewRetail.Rows(0).Cells(4).Value = satuan
            DataGridViewRetail.Rows(0).Cells(5).Value = CLng(price)
            DataGridViewRetail.Rows(0).Cells(6).Value = CLng(diskon)

            DataGridViewRetail.Rows(0).Cells(0).ReadOnly = True
            DataGridViewRetail.Rows(0).Cells(1).ReadOnly = True
            DataGridViewRetail.Rows(0).Cells(2).ReadOnly = True
            DataGridViewRetail.Rows(0).Cells(4).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(7).ReadOnly = True            
            hitungTotalHarga(0)
            hitungSubTotalHarga()
            formatKolomNumeric()
            txtBarcode.Focus()
            txtBarcode.SelectAll()
        Else
            DataGridViewRetail.Rows.Add()
            DataGridViewRetail.Rows(idx2).Cells(0).Selected = True
            DataGridViewRetail.CurrentCell = Me.DataGridViewRetail(0, idx2)
            DataGridViewRetail.NotifyCurrentCellDirty(True)
            DataGridViewRetail.Rows(idx2).Cells(0).Value = barcode
            DataGridViewRetail.Rows(idx2).Cells(1).Value = kodeItem
            DataGridViewRetail.Rows(idx2).Cells(2).Value = namaItem
            DataGridViewRetail.Rows(idx2).Cells(3).Value = CLng(1)
            DataGridViewRetail.Rows(idx2).Cells(4).Value = satuan
            DataGridViewRetail.Rows(idx2).Cells(5).Value = CLng(price)
            DataGridViewRetail.Rows(idx2).Cells(6).Value = CLng(diskon)

            DataGridViewRetail.Rows(idx2).Cells(0).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(1).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(2).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(4).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(7).ReadOnly = True
            DataGridViewRetail.Rows(idx2).Cells(3).Selected = True
            DataGridViewRetail.CurrentCell = Me.DataGridViewRetail(3, idx2)
            DataGridViewRetail.BeginEdit(True)
            hitungTotalHarga(idx2)
            hitungSubTotalHarga()
            formatKolomNumeric()
            txtBarcode.Focus()
            txtBarcode.SelectAll()
        End If

    End Sub
    Private Sub hitungSubTotalHarga()
        Dim totalharga As Long = 0
        Dim str As String = ""
        For Each oItem As DataGridViewRow In DataGridViewRetail.Rows
            totalharga = totalharga + oItem.Cells(7).Value
        Next
        Dim subTotal As Long = totalharga
        txtTotal.Text = FormatNumber(subTotal.ToString, 0, TriState.True)
        'calculatePctDiskon()
        'calculateTotalOrder()
    End Sub
    Private Sub DataGridViewRetail_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewRetail.CellEndEdit
        If e.ColumnIndex = 3 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        ElseIf e.ColumnIndex = 5 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        ElseIf e.ColumnIndex = 6 Then
            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
            hitungSubTotalHarga()
        End If
    End Sub
    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim qty As Long
        Dim hargaSatuan As Long
        Dim hargaDiskon As Long
        qty = DataGridViewRetail.Rows(rowIdx).Cells(3).Value
        hargaSatuan = DataGridViewRetail.Rows(rowIdx).Cells(5).Value
        hargaDiskon = DataGridViewRetail.Rows(rowIdx).Cells(6).Value
        Dim totalHarga As Long
        totalHarga = (qty * hargaSatuan) - (qty * hargaDiskon)
        DataGridViewRetail.Rows(rowIdx).Cells(7).Value = totalHarga
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewRetail.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewRetail.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewRetail.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewRetail.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewRetail.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewRetail.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewRetail.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewRetail.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txtPembayaran_GotFocus(sender As Object, e As EventArgs) Handles txtPembayaran.GotFocus
        txtPembayaran.SelectAll()
    End Sub

    Private Sub txtPembayaran_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPembayaran.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPembayaran_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPembayaran.MouseDown
        txtPembayaran.SelectAll()
    End Sub

    Private Sub txtBarcode_MouseDown(sender As Object, e As MouseEventArgs) Handles txtBarcode.MouseDown
        txtBarcode.SelectAll()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub DataGridViewRetail_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewRetail.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
    End Sub
End Class