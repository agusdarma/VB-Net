Public Class GeneralFilterFrm
    Public tagNew As String
    Public Sub setTag(tag As String)
        tagNew = tag
    End Sub

    Private Sub GeneralFilterFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbField.DataSource = SupplierFrm.getFieldFilter
        CmbField.ValueMember = "id"
        CmbField.DisplayMember = "name"
        Me.Text = SupplierFrm.getTitle
        MessageBox.Show (tagNew)
    End Sub
End Class