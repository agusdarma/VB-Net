Imports MySql.Data.MySqlClient

Public Class SearchSOForm
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public listSelectPo = New List(Of PoVO)
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub SearchSOForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewListSO.ColumnCount = 3
        DataGridViewListSO.Columns(0).Name = "SO No"
        DataGridViewListSO.Columns(1).Name = "SO Date"
        DataGridViewListSO.Columns(2).Name = "Nama Customer"

        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'DataGridViewListPO.Rows.Add(row)
        DataGridViewListSO.Rows.Clear()
        findSOKodeCustomer(DeliveryOrderFrm.kodeCustomer)

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridViewListSO.Columns.Add(chk)
        chk.HeaderText = "Check Data"
        chk.Name = "chk"
        'DataGridViewListPO.Rows(2).Cells(3).Value = True
    End Sub

    Private Sub findSOKodeCustomer(kodeCustomer As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select so_no, so_date, nama_customer from sales_order_header where kode_customer = '" & kodeCustomer & "' and status_so = 1 order by so_date asc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                DataGridViewListSO.Rows.Clear()
                DataGridViewListSO.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("so_no").ToString(), oRecord("so_date").ToString(), oRecord("nama_customer").ToString()}
                    DataGridViewListSO.Rows.Add(row)
                Next
                DataGridViewListSO.Refresh()
            Else
                MessageBox.Show("List SO Not Found", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        listSelectPo = New List(Of PoVO)
        For Each oItem As DataGridViewRow In DataGridViewListSO.Rows
            If oItem.Cells(3).Value = True Then
                listSelectPo.Add(New PoVO(oItem.Cells(0).Value))
            End If
        Next
        DeliveryOrderFrm.addSelectSOToList()
        Me.Close()
    End Sub

    Private Sub CheckBoxCheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCheckAll.CheckedChanged
        If CheckBoxCheckAll.Text = "Select All" Then
            For Each row As DataGridViewRow In DataGridViewListSO.Rows
                CType(row.Cells(3), DataGridViewCheckBoxCell).Value = True
            Next
            CheckBoxCheckAll.Text = "Uncheck All"
        Else
            For Each row As DataGridViewRow In DataGridViewListSO.Rows
                CType(row.Cells(3), DataGridViewCheckBoxCell).Value = False
            Next
            CheckBoxCheckAll.Text = "Select All"
        End If
    End Sub
End Class