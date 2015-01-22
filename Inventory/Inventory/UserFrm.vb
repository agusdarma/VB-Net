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
            sql = "select user_code,user_name from user order by updated_on desc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, rowStart, rowPage, "user")
            GridUser.DataSource = ds.Tables(0)            
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub calculateTotalAllRow()
        Dim sql As String
        Try
            Dim tempDs = New DataSet()
            con = jokenconn()
            sql = "select user_code,user_name from user order by updated_on desc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(tempDs, "user")
            totalRow = tempDs.Tables(0).Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        calculateTotalAllRow()
        rowStart = rowStart + rowPage
        If rowStart > totalRow Then
            rowStart = totalRow - 1
            MessageBox.Show("Data yang ditampilkan sudah yang terakhir.")
        End If
        ds.Clear()
        da.Fill(ds, rowStart, rowPage, "user")

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        calculateTotalAllRow()
        rowStart = rowStart - rowPage
        If rowStart < 0 Then
            rowStart = 0
            MessageBox.Show("Data yang ditampilkan sudah yang pertama.")
        End If
        ds.Clear()
        da.Fill(ds, rowStart, rowPage, "user")
    End Sub
End Class