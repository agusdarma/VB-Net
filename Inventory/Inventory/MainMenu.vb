Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Text

Public Class MainMenu
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim publictable As New DataTable
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        closeAllForms()
        Login.Show()
    End Sub
    Private Sub closeAllForms()
        UserFrm.Close()
        UserAddFrm.Close()
        UserEditFrm.Close()
        SupplierFrm.Close()
        SupplierAddFrm.Close()
        GeneralFilterFrm.Close()
    End Sub
    Private Function canAccessMenu(menuName As String) As Boolean
        Dim canAccess As Boolean = False
        Dim session As Session = Login.getSession()
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "select * from user where user_code ='" & session.Code & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                Dim groupId As Integer
                groupId = publictable.Rows(0).Item(4)
                sql = "select module_name as moduleName from group_module gm inner join user_modules um on gm.module_id = um.id where gm.group_id ='" & groupId & "' and gm.access_level = 1"
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(publictable)
                If publictable.Rows.Count > 0 Then
                    For Each row As DataRow In publictable.Rows
                        If menuName.Equals(row("moduleName")) Then
                            canAccess = True
                            Return canAccess
                        Else
                            canAccess = False
                        End If
                    Next
                Else
                    'MessageBox.Show("User Cannot Access This Menu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    canAccess = False
                End If
            Else
                'MessageBox.Show("User Cannot Access This Menu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                canAccess = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        If canAccess = False Then
            MessageBox.Show("User Cannot Access This Menu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return canAccess
    End Function

    Private Function canEnabledMenu(menuName As String) As Boolean
        Dim canAccess As Boolean = False
        Dim session As Session = Login.getSession()
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "select * from user where user_code ='" & session.Code & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                Dim groupId As Integer
                groupId = publictable.Rows(0).Item(4)
                sql = "select module_name as moduleName from group_module gm inner join user_modules um on gm.module_id = um.id where gm.group_id ='" & groupId & "' and gm.access_level = 1"
                sqlCommand.CommandText = sql
                da.SelectCommand = sqlCommand
                da.Fill(publictable)
                If publictable.Rows.Count > 0 Then
                    For Each row As DataRow In publictable.Rows
                        If menuName.Equals(row("moduleName")) Then
                            canAccess = True
                            Return canAccess
                        Else
                            canAccess = False
                        End If
                    Next
                Else
                    'MessageBox.Show("User Cannot Access This Menu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    canAccess = False
                End If
            Else
                'MessageBox.Show("User Cannot Access This Menu.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                canAccess = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        If canAccess = False Then
            If menuName.Equals("User Management") Then
                UserManagementToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Master Vendor/Supplier") Then
                MasterVendorToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Master Customer") Then
                MasterCustomerToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Master Item Class") Then
                MasterItemClassToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Master Gudang") Then
                MasterGudangToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Master Item") Then
                MasterItemToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Purchase Order") Then
                PurchaseOrderToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Receive Items") Then
                ReceiveItemsToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Purchase Invoice") Then
                PurchaseInvoiceToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Purchase Payment") Then
                PurchasePaymentToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Sales Order") Then
                SalesOrderToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Delivery Order") Then
                DeliveryOrderToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Sales Invoice") Then
                SalesInvoiceToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Sales Receipt") Then
                SalesReceiptToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Laporan Item Per Gudang") Then
                LaporanItemPerGudangToolStripMenuItem.Enabled = False
            ElseIf menuName.Equals("Group Management") Then
                GroupManagementToolStripMenuItem.Enabled = False
            End If
        End If
        Return canAccess
    End Function

    Private Sub UserManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserManagementToolStripMenuItem.Click
        If canAccessMenu("User Management") Then
            UserFrm.Show()
        End If
    End Sub

    Private Sub MasterVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterVendorToolStripMenuItem.Click

        If canAccessMenu("Master Vendor/Supplier") Then
            SupplierFrm.Show()
        End If
    End Sub

    Private Sub MasterCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterCustomerToolStripMenuItem.Click

        If canAccessMenu("Master Customer") Then
            CustomerFrm.Show()
        End If
    End Sub

    Private Sub MasterItemClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterItemClassToolStripMenuItem.Click

        If canAccessMenu("Master Item Class") Then
            ItemsCategory.Show()
        End If
    End Sub

    Private Sub MasterGudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterGudangToolStripMenuItem.Click

        If canAccessMenu("Master Gudang") Then
            Warehouse.Show()
        End If
    End Sub

    Private Sub MasterItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterItemToolStripMenuItem.Click

        If canAccessMenu("Master Item") Then
            Barang.Show()
        End If
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem.Click

        If canAccessMenu("Purchase Order") Then
            PurchaseOrder.Show()
        End If
    End Sub

    Private Sub GenerateReportToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolsToolStripMenuItem.Click
        GenerateReportTools.Show()
    End Sub

    Private Sub ReceiveItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiveItemsToolStripMenuItem.Click

        If canAccessMenu("Receive Items") Then
            ReceiveItems.Show()
        End If
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseInvoiceToolStripMenuItem.Click

        If canAccessMenu("Purchase Invoice") Then
            PurchaseInvoice.Show()
        End If
    End Sub

    Private Sub PurchasePaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchasePaymentToolStripMenuItem.Click

        If canAccessMenu("Purchase Payment") Then
            PurchasePayment.Show()
        End If
    End Sub

    Private Sub SalesOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesOrderToolStripMenuItem.Click

        If canAccessMenu("Sales Order") Then
            SalesOrderFrm.Show()
        End If
    End Sub

    Private Sub DeliveryOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveryOrderToolStripMenuItem.Click

        If canAccessMenu("Delivery Order") Then
            DeliveryOrderFrm.Show()
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesInvoiceToolStripMenuItem.Click

        If canAccessMenu("Sales Invoice") Then
            SalesInvoice.Show()
        End If
    End Sub

    Private Sub SalesReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReceiptToolStripMenuItem.Click

        If canAccessMenu("Sales Receipt") Then
            SalesPayment.Show()
        End If
    End Sub

    Private Sub LaporanItemPerGudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanItemPerGudangToolStripMenuItem.Click

        If canAccessMenu("Laporan Stok Item") Then
            ReportItemsGudang.Show()
        End If
    End Sub

    Private Sub GroupManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupManagementToolStripMenuItem.Click
        If canAccessMenu("Group Management") Then
            GroupAccess.Show()
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAllMenu()
    End Sub
    Private Sub loadAllMenu()
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim listMenu As New List(Of UserMenuVO)
            Dim publictable As New DataTable
            sql = "select id as id, module_name as menu from user_modules"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            For Each row As DataRow In publictable.Rows
                Dim tempMenu As UserMenuVO = New UserMenuVO()
                tempMenu.getIDMenu = row.Item("id")
                tempMenu.getNamaMenu = row.Item("menu")
                listMenu.Add(tempMenu)
            Next row
            For Each cur In listMenu
                Dim temp As String
                temp = cur.getNamaMenu()
                canEnabledMenu(temp)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LaporanSalesOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanSalesOrderToolStripMenuItem.Click
        If canAccessMenu("Laporan Sales Order") Then
            RptSalesOrder.Show()
        End If
    End Sub

    Private Sub RetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetailToolStripMenuItem.Click
        If canAccessMenu("Sales Retail") Then
            SalesRetail.Show()
        End If
    End Sub
End Class
