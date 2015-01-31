Imports System.Windows.Forms

Public Class MainMenu
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

    Private Sub UserManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserManagementToolStripMenuItem.Click
        UserFrm.Show()

    End Sub

    Private Sub MasterVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterVendorToolStripMenuItem.Click
        SupplierFrm.Show()
    End Sub

    Private Sub MasterCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterCustomerToolStripMenuItem.Click
        CustomerFrm.Show()
    End Sub

    Private Sub MasterItemClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterItemClassToolStripMenuItem.Click
        ItemsCategory.Show()
    End Sub

    Private Sub MasterGudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterGudangToolStripMenuItem.Click
        Warehouse.Show()
    End Sub

    Private Sub MasterItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterItemToolStripMenuItem.Click
        Barang.Show()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem.Click
        PurchaseOrder.Show()
    End Sub

    Private Sub GenerateReportToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolsToolStripMenuItem.Click
        GenerateReportTools.Show()
    End Sub
End Class
