Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportItemsGudang
    Dim con As MySqlConnection
    Dim da As New MySqlDataAdapter
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        print(CmbItems.SelectedValue)
    End Sub
    Private Sub print(kodeItem As String)
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Try
            sql = "select i.nama_item,g.nama_gudang,ig.qty from items_gudang ig inner join items i on ig.kode_item = i.kode_item inner join gudang g on g.id = ig.gudang_id where 1 = 1 "
            
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            If CmbItems.SelectedValue <> "-1" Then
                sql = sql + " and i.kode_item = @kodeItem"
                sqlCommand.Parameters.AddWithValue("@kodeItem", kodeItem)
            End If
            sql = sql + " group by i.nama_item,g.nama_gudang"
            sqlCommand.CommandText = sql

            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\ReportItemsPerGudang.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ReportItemsGudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateItems()
    End Sub
    Private Sub populateItems()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from items order by nama_item asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            Dim dr As DataRow
            dr = ds.Tables(0).NewRow
            dr("kode_item") = "-1"
            dr("nama_item") = "Please Select"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            CmbItems.DataSource = ds.Tables(0)
            CmbItems.ValueMember = "kode_item"
            CmbItems.DisplayMember = "nama_item"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class