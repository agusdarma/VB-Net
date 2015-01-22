Imports MySql.Data.MySqlClient

Public Class UserFrm
    'Represents an SQL statement or stored procedure to execute against a data source.
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    'declare conn as connection and it will now a new connection because 
    'it is equal to Getconnection Function
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 10
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim scrollVal As Integer
    Public connString As String = "Server=127.0.0.1;Database=ims;Uid=root;Pwd=root;"
    Public sqlBase As String = "Select * "
    Public Function jokenconn() As MySqlConnection
        Return New MySqlConnection(connString)
    End Function
    Private Sub UserFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String        
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = sqlBase & "from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
            con.Close()
            calculateTotalAllRow()
            Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
            Label_Showing_Pages.Text = "Showing pages x of " + calculateTotalPages().ToString
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
    Private Function calculateTotalPages() As Integer
        'Create Command object
        Dim totalPages As Integer
        calculateTotalAllRow()
        totalPages = totalRow Mod rowPage
        Return totalPages
    End Function
    Private Sub LinkLabel_NextPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_NextPage.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart + rowPage
            If rowStart < totalRow Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()
                sql = sqlBase & " from user order by id asc limit " & rowStart & "," & rowPage & ""
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

    Private Sub LinkLabel_LastPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_LastPage.LinkClicked
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
            sql = sqlBase & " from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
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
            sql = sqlBase & " from user order by id asc limit " & rowStart & "," & rowPage & ""
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
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
                sql = sqlBase & " from user order by id asc limit " & rowStart & "," & rowPage & ""
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

    Private Sub GridUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUser.CellContentClick

    End Sub
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridUser.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = GridUser.Rows(e.RowIndex)
            MessageBox.Show("tess")
        End If
    End Sub

    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim selectedRowCount As Integer = GridUser.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                sb.Append("Row: ")
                sb.Append(GridUser.SelectedRows(i).Index.ToString())
                sb.Append("User Code : ")
                sb.Append(GridUser.SelectedRows(i).Cells.ToString)
                sb.Append(Environment.NewLine)
            Next i

            sb.Append("Total: " + selectedRowCount.ToString())
            MessageBox.Show(sb.ToString(), "Selected Rows")

        End If


    End Sub
End Class