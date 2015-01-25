Imports System.Text

Public Class GeneralFilterFrm
    Public tagNew As String
    Public Sub setTag(tag As String)
        tagNew = tag
    End Sub

    Private Sub GeneralFilterFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tagNew = "Vendor" Then
            CmbField.DataSource = SupplierFrm.getFieldFilter
            CmbField.ValueMember = "id"
            CmbField.DisplayMember = "name"
            CmbCondition.DataSource = SupplierFrm.getConditionFilter
            CmbCondition.ValueMember = "id"
            CmbCondition.DisplayMember = "name"
            Me.Text = SupplierFrm.getTitle
            Dim temp As String = SupplierFrm.paramSearch
            If Len(temp) > 0 Then
                If Not temp = "" Then
                    ListBox1.Items.Add(SupplierFrm.paramSearch)
                End If
            End If
        ElseIf tagNew = "Customer" Then
            CmbField.DataSource = CustomerFrm.getFieldFilter
            CmbField.ValueMember = "id"
            CmbField.DisplayMember = "name"
            CmbCondition.DataSource = CustomerFrm.getConditionFilter
            CmbCondition.ValueMember = "id"
            CmbCondition.DisplayMember = "name"
            Me.Text = CustomerFrm.getTitle
            Dim temp As String = CustomerFrm.paramSearch
            If Len(temp) > 0 Then
                If Not temp = "" Then
                    ListBox1.Items.Add(CustomerFrm.paramSearch)
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ClearFIlter.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub AddFIlter_Click(sender As Object, e As EventArgs) Handles AddFIlter.Click
        Dim field As String = CmbField.SelectedValue
        Dim condition As String = CmbCondition.SelectedValue
        Dim value As String = InputValue.Text
        If condition = "like" Then
            ListBox1.Items.Add("and " + field + " " + condition + " '%" + value + "%' ")
        Else
            ListBox1.Items.Add("and " + field + " " + condition + " '" + value + "' ")
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click           
        Dim builder As New StringBuilder
        For i As Integer = 0 To ListBox1.Items.Count - 1
            builder.Append(ListBox1.Items(i))
        Next
        If tagNew = "Vendor" Then
            SupplierFrm.paramSearch = builder.ToString
            SupplierFrm.refreshGrid()
        ElseIf tagNew = "Customer" Then
            CustomerFrm.paramSearch = builder.ToString
            CustomerFrm.refreshGrid()
        End If        
        Me.Close()
    End Sub

    Private Sub InputValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles InputValue.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub
End Class