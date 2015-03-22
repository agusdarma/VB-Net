Imports MySql.Data.MySqlClient

Public Class BarangAdd
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Public Sub ClearTextBoxes()
        KodeItem.Text = ""
        NamaItem.Text = ""
        qty.Text = "0"
        satuan.Text = ""
        Cost.Text = "0"
        TotalCost.Text = "0"
        salesPrice.Text = "0"
        diskon.Text = "0"
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        Dim itemType As String = ""
        If RadioButtonInventory.Checked Then
            itemType = RadioButtonInventory.Text
        ElseIf RadioButtonNonInventory.Checked Then
            itemType = RadioButtonNonInventory.Text
        ElseIf RadioButtonService.Checked Then
            itemType = RadioButtonService.Checked
        End If

        'pengecekan harus di input semua
        If KodeItem.Text.Length = 0 Then
            MessageBox.Show("Please fill kode item", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf NamaItem.Text.Length = 0 Then
            MessageBox.Show("Please fill nama item", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf qty.Text.Length = 0 Then
            MessageBox.Show("Please fill qty", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Cost.Text.Length = 0 Then
            MessageBox.Show("Please fill cost", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf TotalCost.Text.Length = 0 Then
            MessageBox.Show("Please fill total cost", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf salesPrice.Text.Length = 0 Then
            MessageBox.Show("Please fill sales price", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf diskon.Text.Length = 0 Then
            MessageBox.Show("Please fill diskon", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf itemType.Length = 0 Then
            MessageBox.Show("Please fill item type", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Me.ComboBoxGudang.Items.Count = 0 Then
            MessageBox.Show("Please fill gudang", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Me.ComboBoxSupplier.Items.Count = 0 Then
            MessageBox.Show("Please fill supplier", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Me.ComboBoxKategori.Items.Count = 0 Then
            MessageBox.Show("Please fill kategori", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Barang.getKodeItem.Length > 0 Then
                Update(itemType)
                Me.Close()
                Barang.refreshGrid()
            Else
                If countItemByCode(KodeItem.Text) = 0 Then
                    Dim row As Integer
                    row = insert(itemType)
                    ClearTextBoxes()
                Else
                    MessageBox.Show("Kode item duplikat, ganti dengan Kode item yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                
            End If
        End If
    End Sub
    Private Function countItemByCode(kodeItem As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from items where kode_item ='" & kodeItem & "'"
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
    Private Function Update(itemType As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim transaction As MySqlTransaction
        Dim now As DateTime = DateTime.Now
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            sql = "UPDATE items SET nama_item = @nama_item,quantity = @quantity,item_type = @item_type,item_status = @item_status,satuan = @satuan,gudang_id = @gudang_id,category_id = @category_id,supplier_id = @supplier_id,default_price = @default_price,default_diskon = @default_diskon,total_cost = @total_cost,cost = @cost ,updated_by = @updated_by ,updated_on = @updated_on WHERE kode_item = @kode_item"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_item", KodeItem.Text)
            sqlCommand.Parameters.AddWithValue("@nama_item", NamaItem.Text)
            sqlCommand.Parameters.AddWithValue("@quantity", qty.Text)
            sqlCommand.Parameters.AddWithValue("@item_type", itemType)
            sqlCommand.Parameters.AddWithValue("@item_status", ComboBoxStatus.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@satuan", satuan.Text)
            sqlCommand.Parameters.AddWithValue("@gudang_id", ComboBoxGudang.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@category_id", ComboBoxKategori.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@supplier_id", ComboBoxSupplier.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@default_price", salesPrice.Text)
            sqlCommand.Parameters.AddWithValue("@default_diskon", diskon.Text)
            sqlCommand.Parameters.AddWithValue("@total_cost", TotalCost.Text)
            sqlCommand.Parameters.AddWithValue("@cost", Cost.Text)
            sqlCommand.Parameters.AddWithValue("@updated_on", now)
            sqlCommand.Parameters.AddWithValue("@updated_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@created_on", now)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()

            ' update Items - Gudang
            'sql = "INSERT INTO items_gudang(gudang_id,item_id,qty) VALUES (@warehouse_id,@item_id,@qty)"
            sql = "UPDATE items_gudang SET qty = @qty WHERE gudang_id = @warehouse_id AND kode_item = @item_id"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@qty", qty.Text)
            sqlCommand.Parameters.AddWithValue("@warehouse_id", ComboBoxGudang.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@item_id", KodeItem.Text)
            sqlCommand.ExecuteNonQuery()
            transaction.Commit()

            con.Close()
            MessageBox.Show("Data has been updated", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
    Private Sub removeSeparatorBeforeInsert()
        removeSeparator(qty)
        removeSeparator(salesPrice)
        removeSeparator(diskon)
        removeSeparator(TotalCost)
        removeSeparator(Cost)
    End Sub
    Private Function insert(itemType As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            sql = "INSERT INTO items (kode_item,nama_item,quantity,item_type,item_status,satuan,gudang_id,category_id,supplier_id,default_price,default_diskon,total_cost,cost,created_by,created_on,updated_on,updated_by)VALUES (@kode_item,@nama_item,@quantity,@item_type,@item_status,@satuan,@gudang_id,@category_id,@supplier_id,@default_price,@default_diskon,@total_cost,@cost,@created_by,@created_on,@updated_on,@updated_by)"
            Dim session As Session = Login.getSession()
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.AddWithValue("@kode_item", KodeItem.Text)
            sqlCommand.Parameters.AddWithValue("@nama_item", NamaItem.Text)
            sqlCommand.Parameters.AddWithValue("@quantity", qty.Text)
            sqlCommand.Parameters.AddWithValue("@item_type", itemType)
            sqlCommand.Parameters.AddWithValue("@item_status", ComboBoxStatus.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@satuan", satuan.Text)
            sqlCommand.Parameters.AddWithValue("@gudang_id", ComboBoxGudang.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@category_id", ComboBoxKategori.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@supplier_id", ComboBoxSupplier.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@default_price", salesPrice.Text)
            sqlCommand.Parameters.AddWithValue("@default_diskon", diskon.Text)
            sqlCommand.Parameters.AddWithValue("@total_cost", TotalCost.Text)
            sqlCommand.Parameters.AddWithValue("@cost", Cost.Text)
            sqlCommand.Parameters.AddWithValue("@updated_on", now)
            sqlCommand.Parameters.AddWithValue("@updated_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@created_on", now)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()


            ' Insert Items - Gudang
            sql = "INSERT INTO items_gudang(gudang_id,kode_item,qty) VALUES (@warehouse_id,@kode_item1,@qty)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@warehouse_id", ComboBoxGudang.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@kode_item1", KodeItem.Text)
            sqlCommand.Parameters.AddWithValue("@qty", qty.Text)
            sqlCommand.ExecuteNonQuery()
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
    Private Sub BarangAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateDataStatus()
        populateKategori()
        populateGudang()
        populateSupplier()
        If Barang.getKodeItem.Length > 0 Then
            findItemByCode(Barang.kodeItem)
            KodeItem.ReadOnly = True
            RadioButtonInventory.Enabled = False
            RadioButtonNonInventory.Enabled = False
            RadioButtonService.Enabled = False
            KodeItem.BackColor = Color.LightGray
        End If
        TotalCost.BackColor = Color.LightGray
    End Sub
    Private Sub findItemByCode(kodeItem As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select * from items where kode_item ='" & kodeItem & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                'it gets the data from specific column and assign to the variable
                If Not IsDBNull(publictable.Rows(0).Item(1)) Then
                    Me.KodeItem.Text = publictable.Rows(0).Item(1)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    Me.NamaItem.Text = publictable.Rows(0).Item(2)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    Me.qty.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    Dim itemType As String
                    itemType = publictable.Rows(0).Item(4)
                    If (itemType = "Inventory Part") Then
                        RadioButtonInventory.Checked = True
                    ElseIf (itemType = "Non Inventory Part") Then
                        RadioButtonNonInventory.Checked = True
                    ElseIf (itemType = "Service") Then
                        RadioButtonService.Checked = True
                    End If
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    ComboBoxStatus.SelectedValue = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    Me.satuan.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    ComboBoxGudang.SelectedValue = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    ComboBoxKategori.SelectedValue = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    ComboBoxSupplier.SelectedValue = publictable.Rows(0).Item(9)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    Me.salesPrice.Text = FormatNumber(publictable.Rows(0).Item(10), 0, TriState.True)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    Me.diskon.Text = FormatNumber(publictable.Rows(0).Item(11), 0, TriState.True)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    Me.TotalCost.Text = FormatNumber(publictable.Rows(0).Item(12), 0, TriState.True)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    Me.Cost.Text = FormatNumber(publictable.Rows(0).Item(13), 0, TriState.True)
                End If
            Else
                MessageBox.Show("Data Item Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub populateDataStatus()
        ComboBoxStatus.DataSource = Me.getFieldStatus
        ComboBoxStatus.ValueMember = "id"
        ComboBoxStatus.DisplayMember = "name"
    End Sub
    Private Sub removeSeparator(txtBox As TextBox)
        Dim temp As String
        temp = txtBox.Text
        temp = temp.Replace(",", "")
        txtBox.Text = temp
    End Sub
    Private Sub populateKategori()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from items_category order by nama_kategori asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items_category")
            con.Close()
            ComboBoxKategori.DataSource = ds.Tables(0)
            ComboBoxKategori.ValueMember = "id"
            ComboBoxKategori.DisplayMember = "nama_kategori"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub populateSupplier()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier order by name_supplier asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            ComboBoxSupplier.DataSource = ds.Tables(0)
            ComboBoxSupplier.ValueMember = "id"
            ComboBoxSupplier.DisplayMember = "name_supplier"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub populateGudang()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from gudang order by nama_gudang asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "gudang")
            con.Close()
            ComboBoxGudang.DataSource = ds.Tables(0)
            ComboBoxGudang.ValueMember = "id"
            ComboBoxGudang.DisplayMember = "nama_gudang"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function getFieldStatus() As List(Of ComboVO)
        Dim fieldFilters = New List(Of ComboVO)
        fieldFilters.Add(New ComboVO("aktif", "Aktif"))
        fieldFilters.Add(New ComboVO("non_aktif", "Non Aktif"))
        Return fieldFilters
    End Function

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        Barang.refreshGrid()
    End Sub

    Private Sub KodeItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KodeItem.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub NamaItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NamaItem.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Cost_Click(sender As Object, e As EventArgs) Handles Cost.Click
        Cost.SelectAll()
    End Sub

    Private Sub Cost_Enter(sender As Object, e As EventArgs) Handles Cost.Enter
        Cost.SelectAll()
    End Sub

    Private Sub Cost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cost.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TotalCost_Click(sender As Object, e As EventArgs) Handles TotalCost.Click
        TotalCost.SelectAll()
    End Sub

    Private Sub TotalCost_Enter(sender As Object, e As EventArgs) Handles TotalCost.Enter
        TotalCost.SelectAll()
    End Sub

    Private Sub diskon_Click(sender As Object, e As EventArgs) Handles diskon.Click
        diskon.SelectAll()
    End Sub

    Private Sub diskon_Enter(sender As Object, e As EventArgs) Handles diskon.Enter
        diskon.SelectAll()
    End Sub

    Private Sub salesPrice_Click(sender As Object, e As EventArgs) Handles salesPrice.Click
        salesPrice.SelectAll()
    End Sub

    Private Sub salesPrice_Enter(sender As Object, e As EventArgs) Handles salesPrice.Enter
        salesPrice.SelectAll()
    End Sub

    Private Sub Cost_Leave(sender As Object, e As EventArgs) Handles Cost.Leave
        Dim totalCost As Long
        Dim qty As Long
        Dim cost As Long
        If Me.qty.Text.Length > 0 Then
            qty = Convert.ToDecimal(Me.qty.Text)
        End If
        If Me.Cost.Text.Length > 0 Then
            cost = Convert.ToDecimal(Me.Cost.Text)
            Me.Cost.Text = FormatNumber(Me.Cost.Text, 0, TriState.True)
        End If
        totalCost = qty * cost
        Me.TotalCost.Text = FormatNumber(totalCost.ToString, 0, TriState.True)

    End Sub

    Private Sub qty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles qty.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub satuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles satuan.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub qty_Leave(sender As Object, e As EventArgs) Handles qty.Leave
        Dim totalCost As Long
        Dim qty As Long
        Dim cost As Long
        If Me.qty.Text.Length > 0 Then
            qty = Convert.ToDecimal(Me.qty.Text)
        End If
        If Me.Cost.Text.Length > 0 Then
            cost = Convert.ToDecimal(Me.Cost.Text)
            Me.Cost.Text = FormatNumber(Me.Cost.Text, 0, TriState.True)
        End If
        totalCost = qty * cost
        Me.TotalCost.Text = FormatNumber(totalCost.ToString, 0, TriState.True)

    End Sub

    Private Sub salesPrice_Leave(sender As Object, e As EventArgs) Handles salesPrice.Leave
        If Me.salesPrice.Text.Length > 0 Then
            salesPrice.Text = FormatNumber(salesPrice.Text, 0, TriState.True)
        End If

    End Sub

    Private Sub diskon_Leave(sender As Object, e As EventArgs) Handles diskon.Leave
        If Me.diskon.Text.Length > 0 Then
            diskon.Text = FormatNumber(diskon.Text, 0, TriState.True)
        End If
    End Sub
End Class