Imports MySql.Data.MySqlClient

Public Class UserEditFrm
    Dim userCodeEdit As String
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
    Private Sub populateComboGroups()
        'populate data group first
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select * from groups order by group_name asc"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "group")
            con.Close()
            ComboBox_Group.DataSource = ds.Tables(0)
            ComboBox_Group.ValueMember = "id"
            ComboBox_Group.DisplayMember = "group_name"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub UserEditFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userCodeEdit = UserFrm.getUserCode()
        'MessageBox.Show(userCodeEdit, "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        populateComboGroups()
        findUserByCode(userCodeEdit)

    End Sub
    Private Sub findUserByCode(userCode As String)        
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "select * from user where user_code ='" & userCode & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                'it gets the data from specific column and assign to the variable
                Dim userCodeDb, usernameDb As String
                Dim groupId As Integer
                userCodeDb = publictable.Rows(0).Item(1)
                usernameDb = publictable.Rows(0).Item(2)
                groupId = publictable.Rows(0).Item(4)
                Me.UserCode.Text = userCodeDb
                Me.UserName.Text = usernameDb
                ComboBox_Group.SelectedValue = groupId
            Else
                MessageBox.Show("Data User Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        update()
        MessageBox.Show("Data has been updated", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        UserFrm.refreshGrid()
    End Sub
    Private Function update() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "UPDATE user SET user_name = @userName ,group_id = @groupId ,updated_by = @updatedBy ,updated_on = @updatedOn WHERE user_code = @userCode"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@userCode", UserCode.Text)
            sqlCommand.Parameters.AddWithValue("@userName", UserName.Text)
            sqlCommand.Parameters.AddWithValue("@groupId", ComboBox_Group.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", UserCode.Text)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
End Class