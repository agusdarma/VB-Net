Imports MySql.Data.MySqlClient

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

End Class