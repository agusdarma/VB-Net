﻿Imports MySql.Data.MySqlClient

Public Class SearchInvoiceForm
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

    Private Sub findDOKodeCustomer(kodeCustomer As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select do_no, delivery_date, nama_customer from delivery_order_header where kode_customer = '" & kodeCustomer & "' and (status_delivery_order = 1) order by delivery_date asc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                DataGridViewListPO.Rows.Clear()
                DataGridViewListPO.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("do_no").ToString(), oRecord("delivery_date").ToString(), oRecord("nama_customer").ToString()}
                    DataGridViewListPO.Rows.Add(row)
                Next
                DataGridViewListPO.Refresh()
            Else
                MessageBox.Show("List DO Not Found", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub findSOKodeCustomer(kodeCustomer As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select so_no, so_date, nama_customer from sales_order_header where kode_customer = '" & kodeCustomer & "' and (status_so = 1) order by so_date asc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                DataGridViewListPO.Rows.Clear()
                DataGridViewListPO.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("so_no").ToString(), oRecord("so_date").ToString(), oRecord("nama_customer").ToString()}
                    DataGridViewListPO.Rows.Add(row)
                Next
                DataGridViewListPO.Refresh()
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
    Private Sub findPOKodeSupplier(kodeSupplier As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select po_no, po_date, nama_supplier from purchase_order_header where kode_supplier = '" & kodeSupplier & "' and (status_po = 1) order by po_date asc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                DataGridViewListPO.Rows.Clear()
                DataGridViewListPO.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("po_no").ToString(), oRecord("po_date").ToString(), oRecord("nama_supplier").ToString()}
                    DataGridViewListPO.Rows.Add(row)
                Next
                DataGridViewListPO.Refresh()
            Else
                MessageBox.Show("List PO Not Found", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub findRIByKodeSupplier(kodeSupplier As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select form_no, receive_date, nama_supplier from receive_item_header where kode_supplier = '" & kodeSupplier & "' and status_receive_item = 1 order by receive_date asc"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                DataGridViewListPO.Rows.Clear()
                DataGridViewListPO.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("form_no").ToString(), oRecord("receive_date").ToString(), oRecord("nama_supplier").ToString()}
                    DataGridViewListPO.Rows.Add(row)
                Next
                DataGridViewListPO.Refresh()
            Else
                MessageBox.Show("List RI Not Found", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub SearchInvoiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim type As String = PurchaseInvoice.type
        If type = Nothing Then
            type = SalesInvoice.type
        End If
        If type = "Select PO" Then
            DataGridViewListPO.ColumnCount = 3
            DataGridViewListPO.Columns(0).Name = "PO No"
            DataGridViewListPO.Columns(1).Name = "PO Date"
            DataGridViewListPO.Columns(2).Name = "Nama Supplier"
            Me.Text = "Select Purchase Order"

            DataGridViewListPO.Rows.Clear()
            findPOKodeSupplier(PurchaseInvoice.kodeSupplier)

            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridViewListPO.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
        ElseIf type = "Select RI" Then
            DataGridViewListPO.ColumnCount = 3
            DataGridViewListPO.Columns(0).Name = "RI No"
            DataGridViewListPO.Columns(1).Name = "Receive Date"
            DataGridViewListPO.Columns(2).Name = "Nama Supplier"
            Me.Text = "Select Receive Item"

            'Dim row As String() = New String() {"1", "Product 1", "1000"}
            'DataGridViewListPO.Rows.Add(row)
            DataGridViewListPO.Rows.Clear()
            findRIByKodeSupplier(PurchaseInvoice.kodeSupplier)

            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridViewListPO.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
        ElseIf type = "Select SO" Then
            DataGridViewListPO.ColumnCount = 3
            DataGridViewListPO.Columns(0).Name = "SO No"
            DataGridViewListPO.Columns(1).Name = "SO Date"
            DataGridViewListPO.Columns(2).Name = "Nama Customer"
            Me.Text = "Select Sales Order"

            DataGridViewListPO.Rows.Clear()
            findSOKodeCustomer(SalesInvoice.kodeCustomer)

            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridViewListPO.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
        ElseIf type = "Select DO" Then
            DataGridViewListPO.ColumnCount = 3
            DataGridViewListPO.Columns(0).Name = "DO No"
            DataGridViewListPO.Columns(1).Name = "DO Date"
            DataGridViewListPO.Columns(2).Name = "Nama Customer"
            Me.Text = "Select Delivery Order"

            DataGridViewListPO.Rows.Clear()
            findDOKodeCustomer(SalesInvoice.kodeCustomer)

            Dim chk As New DataGridViewCheckBoxColumn()
            DataGridViewListPO.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        listSelectPo = New List(Of PoVO)
        For Each oItem As DataGridViewRow In DataGridViewListPO.Rows
            If oItem.Cells(3).Value = True Then
                listSelectPo.Add(New PoVO(oItem.Cells(0).Value))
            End If
        Next
        Dim type As String = PurchaseInvoice.type
        If type = Nothing Then
            type = SalesInvoice.type
        End If
        If type = "Select PO" Then
            PurchaseInvoice.addSelectToList()
        ElseIf type = "Select RI" Then
            PurchaseInvoice.addSelectToList()
        ElseIf type = "Select SO" Then
            SalesInvoice.addSelectToList()
        ElseIf type = "Select DO" Then
            SalesInvoice.addSelectToList()
        End If

        Me.Close()
    End Sub

    Private Sub CheckBoxCheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCheckAll.CheckedChanged
        If CheckBoxCheckAll.Text = "Select All" Then
            For Each row As DataGridViewRow In DataGridViewListPO.Rows
                CType(row.Cells(3), DataGridViewCheckBoxCell).Value = True
            Next
            CheckBoxCheckAll.Text = "Uncheck All"
        Else
            For Each row As DataGridViewRow In DataGridViewListPO.Rows
                CType(row.Cells(3), DataGridViewCheckBoxCell).Value = False
            Next
            CheckBoxCheckAll.Text = "Select All"
        End If
    End Sub
End Class