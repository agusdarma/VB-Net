Imports MySql.Data.MySqlClient

Public Class PurchaseInvoice
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
            Sql = "select id from purchase_invoice_header order by id desc limit 0,1"
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
        Dim formNoSystem As String = "PI/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxFormNo.Text = formNoSystem


        Me.DataGridViewPI.ColumnCount = 7
        Me.DataGridViewPI.Columns(0).Name = "Kode Item"
        Me.DataGridViewPI.Columns(1).Name = "Nama Item"
        Me.DataGridViewPI.Columns(2).Name = "Qty"
        Me.DataGridViewPI.Columns(3).Name = "Satuan"
        Me.DataGridViewPI.Columns(4).Name = "Harga Satuan"
        Me.DataGridViewPI.Columns(5).Name = "Diskon"
        Me.DataGridViewPI.Columns(6).Name = "Total Harga"
        Me.DataGridViewPI.Columns(7).Name = "Gudang"
        Me.DataGridViewPI.Columns(8).Name = "PO No"
        Me.DataGridViewPI.Columns(9).Name = "Receive Item No"



        lblPPN.Visible = False
        LblPPnRp.Visible = False
        TextBoxPPn.Visible = False
        lblTax.Visible = False
        CheckInclusiveTax.Enabled = False
        If CheckVendorTaxable.Checked = True Then
            lblPPN.Visible = True
            LblPPnRp.Visible = True
            TextBoxPPn.Visible = True
            CheckInclusiveTax.Enabled = True
            'hitungPPn()
            'calculateTotalOrder()
        Else
            lblPPN.Visible = False
            LblPPnRp.Visible = False
            TextBoxPPn.Visible = False
            lblTax.Visible = False
            CheckInclusiveTax.Enabled = False
            CheckInclusiveTax.Checked = False
            'clearHitungPPn()
            'calculateTotalOrder()
            Exit Sub
        End If
        If CheckInclusiveTax.Checked = True Then
            lblPPN.Visible = True
            LblPPnRp.Visible = True
            TextBoxPPn.Visible = True
            lblTax.Visible = True
            'hitungPPnInclusiveTax()
        End If
    End Sub
    Private Sub PurchaseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        TextBoxInvoiceNo.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub formatKolomNumeric()
        DataGridViewPI.Columns("Total Harga").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Diskon").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Harga Satuan").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Qty").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewPI.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Harga Satuan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewPI.Columns("Total Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
End Class