Imports MySql.Data.MySqlClient

Public Class SupplierFrm
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 10
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim currentPage As Integer
    Public kodeSupplier As String
    Dim paramSearch As String
    Public sqlBase As String = "SELECT id as ID, kode_supplier as KodeSupplier, name_supplier as NamaSupplier, contact_person as ContactPerson,phone as Phone, hp as Hp"
    Public Function jokenconn() As MySqlConnection
        'Return New MySqlConnection(connString)
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Private Sub SupplierFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub refreshGrid()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            If paramSearch = "" Then
                sql = sqlBase & "from supplier order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & "from supplier where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            GridSupplier.DataSource = ds.Tables(0)
            con.Close()
            calculateTotalAllRow()
            resetCurrentPage()
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
            'System.Diagnostics.Debug.WriteLine("Connection Opened")
            'Create Command objects
            Dim Sql As String
            If paramSearch = "" Then
                Sql = "SELECT COUNT(*) FROM supplier"
            Else
                Sql = "SELECT COUNT(*) FROM supplier where user_code like '%" + paramSearch + "%'"
            End If
            Dim scalarCommand As New MySqlCommand(Sql, con)
            ' Execute Scalar Query
            'Console.WriteLine("Before INSERT, Number of Employees = {0}",
            '                 scalarCommand.ExecuteScalar())
            totalRow = scalarCommand.ExecuteScalar()
            con.Close()
        Catch ex As MySqlException
            ' Display error
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            ' Close Connection
            con.Close()
            'Console.WriteLine("Connection Closed")
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
End Class