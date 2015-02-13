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
            Dim sqlSelectGeneral As String = "select ph.form_no ,ph.sales_invoice_no ,ph.sales_invoice_date ,ph.bill_to,ph.ship_to, ph.nama_customer ,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit,pd.price_total, ph.notes,ph.sub_total,ph.diskon,ph.tax_value,ph.total_order"
            Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
            sql = sqlSelectGeneral + sqlSelectCompanyName + " from sales_invoice_header ph inner join sales_invoice_detail pd on ph.id = pd.sales_invoice_header_id"
            conn.Open()
            'Dim sql As String = "select ph.po_no,ph.po_date,ph.nama_supplier,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit,'PT Emobile Indonesia' as companyName,'Include PPN' as ppn from  purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id"
            cmd.CommandText = sql
            cmd.Connection = conn

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            'myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\StrukPO.rpt")
            'myReport.SetDataSource(myData)
            myData.WriteXml("D:\Personal\IT_Solution\VB-Net\DataSet\SI_REPORT.xml", XmlWriteMode.WriteSchema) 'use kalo mau buat data source
            'PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            'PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class