Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class GenerateReportTools

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myData As New DataSet
        Dim myDataDetail As New DataSet
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter

        conn.ConnectionString = "server=127.0.0.1;" _
            & "uid=root;" _
            & "pwd=root;" _
            & "database=ims"
        Dim sql As String
        Try
            'Dim sqlSelectGeneral As String = "select ph.form_no ,ph.sales_invoice_no ,ph.sales_invoice_date ,ph.bill_to,ph.ship_to, ph.nama_customer ,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit,pd.price_total, ph.notes,ph.sub_total,ph.diskon,ph.tax_value,ph.total_order"
            'Dim sqlSelectCompanyName As String = ",'PT Emobile Indonesia' as companyName"
            'sql = sqlSelectGeneral + sqlSelectCompanyName + " from sales_invoice_header ph inner join sales_invoice_detail pd on ph.id = pd.sales_invoice_header_id"
            'sql = "select distinct h.id,h.nama_customer,h.so_date,d.nama_item,d.so_header_id,h.total_order from sales_order_header h inner join sales_order_detail d on h.id = d.so_header_id order by h.so_date asc"
            'sql = "select distinct h.id,h.nama_customer,h.so_date, h.total_order from sales_order_header h order by h.so_date asc"
            'sql = "select srh.id, srh.trx_date,srh.total_trx,srh.total_qty,srh.total_pembayaran,srh.total_kembalian,srh.total_laba_rugi from sales_retail_header srh order by trx_date asc"
            sql = "select srd.kode_item,srd.nama_item,srd.qty,srd.harga_satuan,srd.harga_modal,srd.harga_total,srd.header_id from sales_retail_detail srd"

            conn.Open()
            'Dim sql As String = "select ph.po_no,ph.po_date,ph.nama_supplier,pd.kode_item,pd.nama_item,pd.qty,pd.satuan,pd.price_per_unit,'PT Emobile Indonesia' as companyName,'Include PPN' as ppn from  purchase_order_header ph inner join purchase_order_detail pd on ph.id = pd.po_header_id"
            cmd.CommandText = sql
            cmd.Connection = conn

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            'myReport.Load("D:\Personal\IT_Solution\VB-Net\Inventory\Inventory\ReportSalesOrder.rpt")
            'myReport.SetDataSource(myData.Tables(0))
            'myReport.Subreports.Item("subreport1").SetDataSource(myData)
            'sql = "select * from sales_order_detail"
            'cmd.CommandText = sql
            'cmd.Connection = conn
            'myAdapter.SelectCommand = cmd
            'myAdapter.Fill(myDataDetail)
            'myReport.Subreports(0).SetDataSource(myDataDetail.Tables(0))
            'myReport.Subreports.Item("subreport1").SetDataSource(myDataDetail)
            'myReport.Subreports("ReportSalesOrder.rpt").SetDataSource(myDataDetail)

            myData.WriteXml("D:\Personal\IT_Solution\VB-Net\DataSet\SALES_RETAIL_DETAIL.xml", XmlWriteMode.WriteSchema) 'use kalo mau buat data source
            PreviewPrintPO.CrystalReportViewer1.ReportSource = myReport
            PreviewPrintPO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class