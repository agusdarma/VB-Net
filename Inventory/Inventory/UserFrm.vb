Imports MySql.Data.MySqlClient

Public Class UserFrm
    'Represents an SQL statement or stored procedure to execute against a data source.
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    'declare conn as connection and it will now a new connection because 
    'it is equal to Getconnection Function
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 2
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim scrollVal As Integer
    Public connString As String = "Server=127.0.0.1;Database=ims;Uid=root;Pwd=root;"

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUser.CellContentClick

    End Sub
    Public Function jokenconn() As MySqlConnection
        Return New MySqlConnection(connString)
    End Function
    Private Sub UserFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String        
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select user_code,user_name from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)            
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub calculateTotalAllRow()
        'Create Command object
        Dim nonqueryCommand As MySqlCommand = con.CreateCommand()
        Try
            ' Open Connection
            con.Open()            
            System.Diagnostics.Debug.WriteLine("Connection Opened")
            'Create Command objects
            Dim scalarCommand As New MySqlCommand("SELECT COUNT(*) FROM user", con)
            ' Execute Scalar Query
            Console.WriteLine("Before INSERT, Number of Employees = {0}",
                              scalarCommand.ExecuteScalar())
            totalRow = scalarCommand.ExecuteScalar()
        Catch ex As MySqlException
            ' Display error
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            ' Close Connection
            con.Close()
            Console.WriteLine("Connection Closed")
        End Try

    End Sub
    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart + rowPage
            If rowStart < totalRow Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()
                sql = "select user_code,user_name from user order by id asc limit " & rowStart & "," & rowPage & ""
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "user")
                GridUser.DataSource = ds.Tables(0)
            Else
                MessageBox.Show("data sudah habis")
                rowStart = rowStart - rowPage
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click        
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart - rowPage
            If rowStart >= 0 Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()
                sql = "select user_code,user_name from user order by id asc limit " & rowStart & "," & rowPage & ""
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "user")
                GridUser.DataSource = ds.Tables(0)
            Else
                MessageBox.Show("data sudah habis woi")
                rowStart = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Dim sql As String
        Try
            rowStart = 0
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select user_code,user_name from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnLastpage_Click(sender As Object, e As EventArgs) Handles btnLastpage.Click
        Dim sql As String
        Try
            calculateTotalAllRow()
            Dim temp As Integer
            temp = totalRow Mod 2
            If temp = 0 Then
                rowStart = totalRow - rowPage
            Else
                rowStart = totalRow - (rowPage - 1)
            End If
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select user_code,user_name from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class