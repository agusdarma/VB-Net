Imports System.Windows.Forms

Public Class MainMenu

    

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Login.Show()

    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserManagementToolStripMenuItem.Click
        UserFrm.Show()

    End Sub

    Private Sub MasterVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterVendorToolStripMenuItem.Click
        SupplierFrm.Show()
    End Sub
End Class
