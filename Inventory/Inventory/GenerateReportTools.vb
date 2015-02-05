Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class GenerateReportTools

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myData As New DataSet
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter

        conn.ConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=root;" _
            & "database=ims"
        Dim sql As String
        Try
            Dim sqlSelectGeneral As String = "select ph.nama_supplier,CONCAT_WS(' ',s.address1,s.address2) as alamat_supplier,ph.form_no,ph.invoice_no,ph.invoice_date,ph.ship_date,ph.sub_total,ph.diskon,ph.tax_value,ph.total_order,pd.kode_item,pd.nama_item,pd.qty,pd.price_per_unit,pd.diskon,pd.price_total"
            Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
            sql = sqlSelectGeneral + sqlSelectCompanyName + " from purchase_invoice_header ph inner join purchase_invoice_detail pd on ph.id = pd.purchase_header_id inner join supplier s on s.kode_supplier = ph.kode_supplier"
            conn.Open()
            'Dim sql As String = "select ph.po_no,ph.po_date,ph.nama_supplier,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit,'PT Emobile Indonesia' as companyName,'Include PPN' as ppn from  purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id"
            cmd.CommandText = sql
            cmd.Connection = conn

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            'myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukPO.rpt")
            'myReport.SetDataSource(myData)
            myData.WriteXml("D:\Personal\IT_Solution\VB-Net\DataSet\PI_REPORT.xml", XmlWriteMode.WriteSchema) 'use kalo mau buat data source
            'PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            'PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class