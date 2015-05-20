Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class RptHistorySalesByItem
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 2 Then
            onAutoComplete(TextBox1.Text.ToString)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length > 0 Then
            Dim kodeItem As String
            kodeItem = findKodeItemByNamaItem(TextBox1.Text)
            If kodeItem.Length > 0 Then
                print(kodeItem)
            Else
                MessageBox.Show("Item tidak ditemukan, cek master item!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Nama Item harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            TextBox1.SelectAll()
        End If
    End Sub
    Private Function findKodeItemByNamaItem(namaItem As String) As String

        Dim kodeItem As String
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        kodeItem = ""
        Try
            con = jokenconn()
            sql = "select kode_item from items where nama_item = '" + namaItem + "' "
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                kodeItem = publictable.Rows(0).Item(0)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return kodeItem
    End Function
    Private Sub print(kodeItem As String)
        Dim myData As New DataSet
        Dim myDataDetail As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Try
            sql = "select h.nama_customer,h.delivery_date,d.nama_item,d.qty, g.nama_gudang from delivery_order_header h inner join delivery_order_detail d on h.id = d.delivery_header_id inner join gudang g on g.kode_gudang = d.kode_gudang where d.kode_item = @kodeItem order by h.delivery_date desc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kodeItem", kodeItem)

            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\ReportHistorySalesByItem.rpt")
            myReport.SetDataSource(myData)
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
End Class