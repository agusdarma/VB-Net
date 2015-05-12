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
        If checkItemAlreadyExist(barcode) = 0 Then
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
        End If
    End Sub
    Private Function checkItemAlreadyExist(barcode As String) As Integer
        Dim result As Integer
        result = 0
        Dim idx As Integer
        For Each oItem As DataGridViewRow In DataGridViewRetail.Rows          
            Dim br As String
            Dim qty As Long
            br = oItem.Cells(0).Value
            If barcode.ToUpper = br.ToUpper Then
                qty = CLng(oItem.Cells(3).Value)
                qty = qty + 1
                oItem.Cells(3).Value = qty
                result = 1
                idx = oItem.Index
                Exit For
            End If
        Next
        If DataGridViewRetail.RowCount > 0 Then
            hitungTotalHarga(idx)
        End If
        hitungSubTotalHarga()
        formatKolomNumeric()
        txtBarcode.Focus()
        txtBarcode.SelectAll()
        Return result
    End Function
    Private Function getTotalQty() As Integer
        Dim qty As Long
        For Each oItem As DataGridViewRow In DataGridViewRetail.Rows
            Dim qtyTemp As Long
            qtyTemp = CLng(oItem.Cells(3).Value)
            qty = qty + qtyTemp
        Next
        Return qty
    End Function

    Private Function getTotalLabaRugi() As Long
        Dim totalLabaRugi As Long
        totalLabaRugi = 0
        For Each oItem As DataGridViewRow In DataGridViewRetail.Rows
            Dim cmd As New MySqlCommand
            Dim publictable As New DataTable
            Dim cost As Long
            Dim sql As String
            Try
                con = jokenconn()
                sql = "select cost from items where kode_item ='" & oItem.Cells(1).Value & "'"
                With cmd
                    .Connection = con
                    .CommandText = Sql
                End With
                da.SelectCommand = cmd
                da.Fill(publictable)
                If publictable.Rows.Count > 0 Then
                    cost = CLng(publictable.Rows(0).Item(0))
                Else
                    Throw New System.Exception("Item " + oItem.Cells(1).Value + " tidak ditemukan, transaksi gagal.")
                End If
            Catch ex As MySqlException
                MessageBox.Show("error : " + ex.ToString)
            Finally
                con.Close()
            End Try
            ' kalkulasi harga total laba dan rugi
            totalLabaRugi = totalLabaRugi + ((CLng(oItem.Cells(5).Value) - cost) * CLng(oItem.Cells(3).Value))
        Next
        Return totalLabaRugi
    End Function
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
    Private Sub hitungKembalian()
        Dim totalharga As Long = 0
        Dim pembayaran As Long = 0
        Dim kembalian As Long = 0
        totalharga = CLng(txtTotal.Text)
        pembayaran = CLng(txtPembayaran.Text)
        kembalian = pembayaran - totalharga
        If kembalian < 0 Then
            MessageBox.Show("Pembayaran Kurang Silahkan Coba Kembali", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPembayaran.Focus()
            txtPembayaran.SelectAll()
        Else
            txtKembalian.Text = FormatNumber(kembalian.ToString, 0, TriState.True)
            txtPembayaran.Text = FormatNumber(txtPembayaran.Text, 0, TriState.True)
        End If
        
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
        txtBarcode.Focus()
        txtBarcode.SelectAll()
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
                hitungKembalian()
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

    Private Sub SavePrint_Click(sender As Object, e As EventArgs) Handles SavePrint.Click
        If insert() > 0 Then
            clearAllFIeld()
        End If
    End Sub
    Private Sub clearAllFIeld()
        txtTotal.Text = "0"
        txtBarcode.Text = ""
        txtKembalian.Text = "0"
        txtPembayaran.Text = "0"
        DataGridViewRetail.Rows.Clear()
    End Sub
    Private Sub removeSeparator(txtBox As TextBox)
        Dim temp As String
        temp = txtBox.Text
        temp = temp.Replace(",", "")
        txtBox.Text = temp
    End Sub
    Private Sub removeSeparatorBeforeInsert()
        removeSeparator(txtTotal)
        removeSeparator(txtPembayaran)
        removeSeparator(txtKembalian)
    End Sub

    Private Function insert() As Integer
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
            If DataGridViewRetail.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert Sales Retail Header
            sql = "INSERT INTO sales_retail_header(trx_date ,total_trx ,total_qty ,total_pembayaran,total_kembalian,total_laba_rugi,created_on ,created_by ,updated_on ,updated_by) VALUES (@trx_date,@total_trx,@total_qty,@total_pembayaran,@total_kembalian,@total_laba_rugi,@created_on,@created_by,@updated_on,@updated_by)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            Dim trxDate As DateTime
            trxDate = DateTime.Now
            Dim qty As Long
            qty = getTotalQty()
            sqlCommand.Parameters.AddWithValue("@trx_date", trxDate)
            sqlCommand.Parameters.AddWithValue("@total_trx", txtTotal.Text)
            sqlCommand.Parameters.AddWithValue("@total_qty", qty)
            sqlCommand.Parameters.AddWithValue("@total_pembayaran", txtPembayaran.Text)
            sqlCommand.Parameters.AddWithValue("@total_kembalian", txtKembalian.Text)
            sqlCommand.Parameters.AddWithValue("@total_laba_rugi", getTotalLabaRugi())
            sqlCommand.Parameters.AddWithValue("@created_on", trxDate)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@updated_on", trxDate)
            sqlCommand.Parameters.AddWithValue("@updated_by", session.Code)
            sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            ' Insert Sales Retail Detail            
            sqlCommand.Parameters.Add("@header_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@kode_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_item", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@qty", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@harga_satuan", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@harga_modal", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@harga_total", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@gudang_id", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@stockAvailable", MySqlDbType.Int64)

            For Each oItem As DataGridViewRow In DataGridViewRetail.Rows
                'If oItem.Cells(0).Value = "" Then
                'Continue For
                'End If
                Dim cmd As New MySqlCommand
                Dim publictable As New DataTable
                Dim cost As Long
                Try
                    con = jokenconn()
                    sql = "select cost from items where kode_item ='" & oItem.Cells(1).Value & "'"
                    With cmd
                        .Connection = con
                        .CommandText = sql
                    End With
                    da.SelectCommand = cmd
                    da.Fill(publictable)
                    If publictable.Rows.Count > 0 Then
                        cost = CLng(publictable.Rows(0).Item(0))
                    Else
                        Throw New System.Exception("Item " + oItem.Cells(1).Value + " tidak ditemukan, transaksi gagal.")
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("error : " + ex.ToString)
                Finally
                    con.Close()
                End Try

                sql = "INSERT INTO sales_retail_detail(kode_item,nama_item,qty,harga_satuan,harga_modal,harga_total,header_id,created_on,created_by,updated_on,updated_by)VALUES (@kode_item,@nama_item,@qty,@harga_satuan,@harga_modal,@harga_total,@header_id,@created_on,@created_by,@updated_on,@updated_by)"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@header_id").Value = ID
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@nama_item").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@qty").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@harga_satuan").Value = oItem.Cells(5).Value
                sqlCommand.Parameters("@harga_modal").Value = cost
                sqlCommand.Parameters("@harga_total").Value = oItem.Cells(7).Value

                sqlCommand.Parameters("@created_on").Value = trxDate
                sqlCommand.Parameters("@created_by").Value = session.Code
                sqlCommand.Parameters("@updated_on").Value = trxDate
                sqlCommand.Parameters("@updated_by").Value = session.Code
                rowEffected = sqlCommand.ExecuteNonQuery()

                sql = "select qty, gudang_id from items_gudang where kode_item = @kode_item"
                Dim stockAvailable As Long
                stockAvailable = 0
                Dim idGudang As Long
                publictable.Clear()
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@kode_item").Value = oItem.Cells(1).Value
                da.SelectCommand = sqlCommand
                da.Fill(publictable)
                If publictable.Rows.Count > 0 Then
                    stockAvailable = publictable.Rows(0).Item(1)
                    idGudang = publictable.Rows(0).Item(2)
                    If (stockAvailable - CLng(oItem.Cells(3).Value)) >= 0 Then
                        sql = "UPDATE items_gudang SET qty = @stockAvailable - @qty WHERE gudang_id = @gudang_id AND kode_item = @kode_item"
                        sqlCommand.CommandText = sql
                        sqlCommand.Parameters("@gudang_id").Value = idGudang
                        sqlCommand.Parameters("@kode_item").Value = oItem.Cells(1).Value
                        sqlCommand.Parameters("@stockAvailable").Value = stockAvailable
                        sqlCommand.Parameters("@qty").Value = oItem.Cells(3).Value
                        rowEffected = sqlCommand.ExecuteNonQuery()

                        ' update stok items, di sum dari semua gudang
                        sql = "UPDATE items SET quantity = (select sum(qty) as jumlahTotItem from items_gudang where kode_item = @kode_item) ,updated_on = @updated_on ,updated_by = @updated_by WHERE kode_item = @kode_item"
                        sqlCommand.CommandText = sql
                        sqlCommand.Parameters("@kode_item").Value = oItem.Cells(1).Value
                        sqlCommand.Parameters("@updated_on").Value = now
                        sqlCommand.Parameters("@updated_by").Value = session.Code
                        rowEffected = sqlCommand.ExecuteNonQuery()
                    Else
                        MessageBox.Show("Stok Kosong untuk Item ini!" & vbNewLine & " Kode Item : " + oItem.Cells(1).Value & vbNewLine & " Sisa Stok di gudang : " + CStr(stockAvailable), "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return rowEffected = 0
                    End If
                Else
                    MessageBox.Show("Stok Kosong untuk Item ini!" & vbNewLine & " Kode Item : " + oItem.Cells(1).Value & vbNewLine & " Sisa Stok di gudang : " + CStr(stockAvailable), "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return rowEffected = 0
                End If
            Next

            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            rowEffected = 0
            MessageBox.Show(ex.Message)
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
End Class