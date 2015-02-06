Imports MySql.Data.MySqlClient

Public Class PurchasePayment
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeSupplier As String
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub populateVendor()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from supplier order by name_supplier asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            CmbVendor.DataSource = ds.Tables(0)
            CmbVendor.ValueMember = "kode_supplier"
            CmbVendor.DisplayMember = "name_supplier"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from purchase_payment order by id desc limit 0,1"
            Dim scalarCommand As New MySqlCommand(Sql, con)
            idPrimary = scalarCommand.ExecuteScalar()
            idPrimary = idPrimary + 1
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try
        Return idPrimary
    End Function
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim formNoSystem As String = "VP/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxFormNo.Text = formNoSystem


        Me.DataGridViewVP.ColumnCount = 6
        Me.DataGridViewVP.Columns(0).Name = "Invoice No"
        Me.DataGridViewVP.Columns(1).Name = "Form Invoice No"
        Me.DataGridViewVP.Columns(2).Name = "Invoice Date"
        Me.DataGridViewVP.Columns(3).Name = "Total Order"
        Me.DataGridViewVP.Columns(4).Name = "Owing"
        Me.DataGridViewVP.Columns(5).Name = "Payment Amount"
    End Sub
    Private Sub PurchasePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        CmbVendor.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
    End Sub
    Private Function findSupplierByKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select address1,address2,kode_supplier,name_supplier from supplier where kode_supplier ='" & kode & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                alamatVendor.Text = publictable.Rows(0).Item(0) + " " + publictable.Rows(0).Item(1)
                TextBoxKodeSupplier.Text = publictable.Rows(0).Item(2)
                TextBoxNamaSupplier.Text = publictable.Rows(0).Item(3)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Function findInvoiceBySupplierKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select invoice_no,form_no, invoice_date , total_order, total_order as owing, '0' as payment_amount from purchase_invoice_header where kode_supplier = '" & kode & "' and status_invoice = 1"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                If DataGridViewVP.Columns.Count = 7 Then
                    DataGridViewVP.Columns.RemoveAt(6)
                End If
                DataGridViewVP.Rows.Clear()
                DataGridViewVP.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("invoice_no").ToString(), oRecord("form_no").ToString(), oRecord("invoice_date").ToString(), oRecord("total_order").ToString(), oRecord("owing").ToString(), oRecord("payment_amount").ToString()}
                    DataGridViewVP.Rows.Add(row)
                Next
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridViewVP.Columns.Add(chk)
                chk.HeaderText = "Pay"
                chk.Name = "pay"
                DataGridViewVP.Refresh()
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierByKode(CmbVendor.SelectedValue)
        findInvoiceBySupplierKode(CmbVendor.SelectedValue)
    End Sub

    Private Sub DataGridViewVP_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewVP.CellBeginEdit
        
    End Sub

    Private Sub DataGridViewVP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVP.CellClick
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each oItem As DataGridViewRow In DataGridViewVP.Rows
            If oItem.Cells(6).Value = True Then
                MessageBox.Show("Checked1", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("UnChecked1", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub

    Private Sub DataGridViewVP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVP.CellContentClick
        If e.ColumnIndex = 6 Then
            If e.RowIndex >= 0 Then
                TextBoxNotes.Focus()
                If DataGridViewVP.Rows(e.RowIndex).Cells(6).Value = True Then
                    DataGridViewVP.Rows(e.RowIndex).Cells(5).Value = DataGridViewVP.Rows(e.RowIndex).Cells(3).Value
                    'MessageBox.Show("Checked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DataGridViewVP.Rows(e.RowIndex).Cells(5).Value = "0"
                    'MessageBox.Show("UnChecked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridViewVP_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVP.CellEndEdit
        If e.ColumnIndex = 5 Then
            Dim iColumn As Integer = DataGridViewVP.CurrentCell.ColumnIndex
            Dim iRows As Integer = DataGridViewVP.CurrentCell.RowIndex
            DataGridViewVP.Rows(iRows).Cells(6).Value = True
        End If
    End Sub

End Class