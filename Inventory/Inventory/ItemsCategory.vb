Imports MySql.Data.MySqlClient

Public Class ItemsCategory
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 10
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim currentPage As Integer
    Public kodeCategory As String
    Public paramSearch As String
    Public sqlBase As String = "SELECT id as ID, kode_category as KodeCategory, nama_kategori as NamaKategori "
    Public Function jokenconn() As MySqlConnection
        'Return New MySqlConnection(connString)
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
                sql = sqlBase & " from items_category order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from items_category where 1 = 1  " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items_category")
            GridCategory.DataSource = ds.Tables(0)
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
                Sql = "SELECT COUNT(*) FROM items_category"
            Else
                Sql = "SELECT COUNT(*) from items_category where 1 = 1 " + paramSearch
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

    Private Sub ItemsCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshGrid()
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
                    sql = sqlBase & " from items_category order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from items_category where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "items_category")
                GridCategory.DataSource = ds.Tables(0)
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
                sql = sqlBase & " from items_category order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from items_category where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items_category")
            GridCategory.DataSource = ds.Tables(0)
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
                sql = sqlBase & " from items_category order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from items_category where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "items_category")
            GridCategory.DataSource = ds.Tables(0)
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
                    sql = sqlBase & " from items_category order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from items_category where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "items_category")
                GridCategory.DataSource = ds.Tables(0)
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
        kodeCategory = ""
        'CustomerAddFrm.Show()
    End Sub
    Public Function getKodeCategory() As String
        Return kodeCategory
    End Function

    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim selectedRowCount As Integer = GridCategory.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            kodeCategory = GridCategory.SelectedRows(0).Cells(1).Value
            'CustomerAddFrm.Show()
        End If
    End Sub

    Private Sub Button_delete_Click(sender As Object, e As EventArgs) Handles Button_delete.Click
        Dim selectedRowCount As Integer = GridCategory.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim kodeCategory As String
            kodeCategory = GridCategory.SelectedRows(0).Cells(1).Value
            Dim result As Integer = MessageBox.Show("Are you sure want to delete this item " + vbNewLine + "Kode Category : " + kodeCategory, "Confirmation Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                refreshGrid()
            ElseIf result = DialogResult.Yes Then
                delete(kodeCategory)
                MessageBox.Show("Data has been deleted", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshGrid()
            End If
        End If
    End Sub
    Private Function delete(kodeCategory As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "delete from items_category WHERE kode_category = @kodeCategory"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kodeCategory", kodeCategory)
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
        fieldFilters.Add(New ComboVO("kode_category", "Kode Category"))
        fieldFilters.Add(New ComboVO("nama_kategori", "Nama Category"))
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
        GeneralFilterFrm.setTag("item_category")
        GeneralFilterFrm.Show()
    End Sub
End Class