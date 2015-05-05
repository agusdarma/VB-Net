Imports MySql.Data.MySqlClient

Public Class GroupAccess
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 10
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim currentPage As Integer
    Public kodeGroup As String
    Public paramSearch As String
    Public sqlBase As String = "select group_code as Code, group_name as Name, updated_on as UpdatedOn "
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
                sql = sqlBase & "  from groups order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from groups where 1 = 1  " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "groups")
            GridGroups.DataSource = ds.Tables(0)
            con.Close()
            calculateTotalAllRow()
            resetCurrentPage()
            Dim temp As String = paramSearch
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
                Sql = "SELECT COUNT(*) FROM groups"
            Else
                Sql = "SELECT COUNT(*) from groups where 1 = 1 " + paramSearch
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
    Private Sub GroupAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                    sql = sqlBase & " from groups order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from groups where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "groups")
                GridGroups.DataSource = ds.Tables(0)
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
                sql = sqlBase & " from groups order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from groups where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "groups")
            GridGroups.DataSource = ds.Tables(0)
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
                sql = sqlBase & " from groups order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from groups where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "groups")
            GridGroups.DataSource = ds.Tables(0)
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
                    sql = sqlBase & " from groups order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from groups where 1 = 1 " + paramSearch + " order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "groups")
                GridGroups.DataSource = ds.Tables(0)
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
    Public Function getKodeGroup() As String
        Return kodeGroup
    End Function

    Private Sub Button_delete_Click(sender As Object, e As EventArgs) Handles Button_delete.Click
        Dim selectedRowCount As Integer = GridGroups.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim kodeGroup As String
            kodeGroup = GridGroups.SelectedRows(0).Cells(0).Value.ToString
            Dim result As Integer = MessageBox.Show("Are you sure want to delete this item " + vbNewLine + "Kode Groups : " + kodeGroup, "Confirmation Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                refreshGrid()
            ElseIf result = DialogResult.Yes Then
                If delete(kodeGroup) = 1 Then
                    MessageBox.Show("Data has been deleted", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    refreshGrid()
                End If
                
            End If
        End If
    End Sub

    Private Function delete(kodeGroups As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim transaction As MySqlTransaction
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            sql = "select id from groups where group_code = @group_code"
            sqlCommand.CommandText = sql
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.AddWithValue("@group_code", kodeGroups)
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            Dim count As Long
            sqlCommand.Parameters.AddWithValue("@ID", ID)
            sql = "select count(id) from user where group_id = @ID"
            sqlCommand.CommandText = sql
            count = sqlCommand.ExecuteScalar()
            If count > 0 Then
                MessageBox.Show("groups cannot be deleted, already used in user", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return rowEffected = 0
            End If

            sql = "delete from groups WHERE group_code = @group_code"            
            sqlCommand.CommandText = sql
            rowEffected = sqlCommand.ExecuteNonQuery()
            ' Delete Group Module
            'sqlCommand.Parameters.AddWithValue("@ID", ID)
            sql = "delete from group_module where group_id = @ID"
            sqlCommand.CommandText = sql
            sqlCommand.ExecuteScalar()
            transaction.Commit()
            con.Close()
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

    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim selectedRowCount As Integer = GridGroups.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            kodeGroup = GridGroups.SelectedRows(0).Cells(0).Value.ToString
            GroupAccessAdd.Show()
        End If
    End Sub
    Public Function getTitle() As String
        Return Me.Text
    End Function

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        kodeGroup = ""
        GroupAccessAdd.Show()
    End Sub
End Class