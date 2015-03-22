Imports MySql.Data.MySqlClient

Public Class Barang
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 50
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim currentPage As Integer
    Public kodeItem As String
    Public paramSearch As String
    'Public sqlBase As String = "SELECT id as ID, kode_item as KodeItem, nama_item as NamaItem,quantity as Quantity, default_price as SellingPrice, item_type as Type "
    Public sqlBase As String = "SELECT i.id AS ID, i.kode_item     AS KodeItem, i.nama_item AS NamaItem,i.quantity AS Quantity,i.default_price AS SellingPrice,i.item_type AS Type,g.nama_gudang AS NamaGudang "

    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Public Sub refreshGrid()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            If paramSearch = "" Then
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id order by i.id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1  " + paramSearch + " order by i.id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items")
            GridBarang.DataSource = ds.Tables(0)
            con.Close()
            calculateTotalAllRow()
            resetCurrentPage()
            Dim temp As String = paramSearch
            Filter.Text = "Filter Off"
            If Len(temp) > 0 Then
                Filter.Text = "Filter On"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub calculateTotalAllRow()
        Dim nonqueryCommand As MySqlCommand = con.CreateCommand()
        Try
            con.Open()
            Dim Sql As String
            If paramSearch = "" Then
                Sql = "SELECT COUNT(*) FROM items i inner join gudang g on i.gudang_id = g.id"
            Else
                Sql = "SELECT COUNT(*) FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1 " + paramSearch
            End If
            Dim scalarCommand As New MySqlCommand(Sql, con)
            totalRow = scalarCommand.ExecuteScalar()
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try

    End Sub
    Private Sub updateNextCurrentPage()
        currentPage = currentPage + 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub updatePrevCurrentPage()
        currentPage = currentPage - 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub resetCurrentPage()
        currentPage = 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub resetCurrentPageForLast()
        currentPage = calculateTotalPages()
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Function calculateTotalPages() As Integer
        'Create Command object
        Dim tempTotalPages As Double
        Dim totalPages As Double
        tempTotalPages = totalRow / rowPage
        totalPages = Math.Ceiling(tempTotalPages)
        If totalPages = 0 Then
            totalPages = 1
        End If
        Return totalPages
    End Function

    Private Sub Barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshGrid()
        Me.GridBarang.Columns("Quantity").DefaultCellStyle.Format = "n0"
        Me.GridBarang.Columns("SellingPrice").DefaultCellStyle.Format = "n0"
        Me.GridBarang.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.GridBarang.Columns("SellingPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub LinkLabel_NextPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_NextPage.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart + rowPage
            If rowStart < totalRow Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()

                If paramSearch = "" Then
                    sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id order by i.id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1 " + paramSearch + " order by i.id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "items")
                GridBarang.DataSource = ds.Tables(0)
                con.Close()
                updateNextCurrentPage()
            Else
                MessageBox.Show("This is last data", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rowStart = rowStart - rowPage
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_LastPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_LastPage.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            Dim totalPage As Integer = calculateTotalPages()
            rowStart = (totalPage - 1) * rowPage
            ds = New DataSet()
            con = jokenconn()
            con.Open()

            If paramSearch = "" Then
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id order by i.id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1 " + paramSearch + " order by i.id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items")
            GridBarang.DataSource = ds.Tables(0)
            con.Close()
            resetCurrentPageForLast()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_FirstPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_FirstPage.LinkClicked
        Dim sql As String
        Try
            rowStart = 0
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            If paramSearch = "" Then
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id order by i.id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1 " + paramSearch + " order by i.id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items")
            GridBarang.DataSource = ds.Tables(0)
            con.Close()
            resetCurrentPage()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_Previous_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_Previous.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart - rowPage
            If rowStart >= 0 Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()

                If paramSearch = "" Then
                    sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id order by i.id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " FROM items i inner join gudang g on i.gudang_id = g.id where 1 = 1 " + paramSearch + " order by i.id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "items")
                GridBarang.DataSource = ds.Tables(0)
                con.Close()
                updatePrevCurrentPage()

            Else
                MessageBox.Show("This is last data.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rowStart = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        kodeItem = ""
        BarangAdd.Show()
    End Sub
    Public Function getKodeItem() As String
        Return kodeItem
    End Function

    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim selectedRowCount As Integer = GridBarang.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            kodeItem = GridBarang.SelectedRows(0).Cells(1).Value
            BarangAdd.Show()
        End If
    End Sub

    Private Sub Button_delete_Click(sender As Object, e As EventArgs) Handles Button_delete.Click
        Dim selectedRowCount As Integer = GridBarang.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim kodeItem As String
            kodeItem = GridBarang.SelectedRows(0).Cells(1).Value
            Dim result As Integer = MessageBox.Show("Are you sure want to delete this item " + vbNewLine + "Kode Item : " + kodeItem, "Confirmation Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                refreshGrid()
            ElseIf result = DialogResult.Yes Then
                delete(kodeItem)
                MessageBox.Show("Data has been deleted", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshGrid()
            End If
        End If
    End Sub

    Private Function delete(kodeItem As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "delete from items WHERE kode_item = @kodeItem"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kodeItem", kodeItem)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
    Public Function getFieldFilter() As List(Of ComboVO)
        Dim fieldFilters = New List(Of ComboVO)
        fieldFilters.Add(New ComboVO("kode_item", "Kode Item"))
        fieldFilters.Add(New ComboVO("nama_item", "Nama Item"))
        Return fieldFilters
    End Function
    Public Function getConditionFilter() As List(Of ComboVO)
        Dim fieldFilters = New List(Of ComboVO)
        fieldFilters.Add(New ComboVO("=", "Equals"))
        fieldFilters.Add(New ComboVO("like", "Like"))
        Return fieldFilters
    End Function
    Public Function getTitle() As String
        Return Me.Text
    End Function
    Private Sub Filter_Click(sender As Object, e As EventArgs) Handles Filter.Click
        GeneralFilterFrm.setTag("items")
        GeneralFilterFrm.Show()
    End Sub
    Private Sub onAutoComplete(namaItem As String)
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select nama_item from items where nama_item like '" + namaItem + "%' "
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "list")
            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("nama_item").ToString())
            Next
            TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
            TextBox1.AutoCompleteCustomSource = col
            TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'onAutoComplete()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
           If TextBox1.Text.Length > 0 Then
                paramSearch = " and i.nama_item like '" + TextBox1.Text.ToString + "%'"
                refreshGrid()
            End If
        End If
    End Sub

    

    

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 2 Then
            onAutoComplete(TextBox1.Text.ToString)
        End If
    End Sub
End Class