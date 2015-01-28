Imports MySql.Data.MySqlClient

Public Class PurchaseOrder
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Private Sub PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateVendor()
    End Sub
    Private Sub findVendorByCode(kodeVendor As String)
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier where kode_supplier ='" & kodeVendor & "'"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub populateVendor()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            ComboBox1.DataSource = ds.Tables(0)
            ComboBox1.ValueMember = "id"
            ComboBox1.DisplayMember = "name_supplier"
            'MultiColumnComboBoxVendor.DisplayDataSource.DataSource = ds
           
            'MultiColumnComboBoxVendor.DisplayDataSource.DataMember = "id"
            'MultiColumnComboBoxVendor.DisplayDataSource.DataSource = "group_name"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class