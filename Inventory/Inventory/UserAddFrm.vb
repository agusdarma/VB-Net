Imports MySql.Data.MySqlClient

Public Class UserAddFrm
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Private Sub UserAddFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        UserFrm.refreshGrid()
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        'pengecekan harus di input semua
        Dim emptyTextBoxes = From txt In Me.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0 Select txt.Name
        If emptyTextBoxes.Any Then            
            MessageBox.Show(String.Format("Please fill following textboxes: {0}",
                                          String.Join(",", emptyTextBoxes)), "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim row As Integer
            row = insert()
            ClearTextBoxes(Me)
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Public Sub ClearTextBoxes(frm As Form)

        For Each Control In frm.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

    End Sub
    Private Function insert() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "INSERT INTO user (user_code, user_name, password,group_id,updated_on,updated_by,created_on,created_by) VALUES (@userCode, @userName,@password,@groupId, @updatedOn, @updatedBy, @createdOn, @createdBy)"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@userCode", UserCode.Text)
            sqlCommand.Parameters.AddWithValue("@userName", UserName.Text)
            sqlCommand.Parameters.AddWithValue("@password", Password.Text)
            sqlCommand.Parameters.AddWithValue("@groupId", ComboBox_Group.SelectedValue)
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", UserCode.Text)
            sqlCommand.Parameters.AddWithValue("@createdOn", now)
            sqlCommand.Parameters.AddWithValue("@createdBy", UserCode.Text)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function

    Private Sub UserCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserCode.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub UserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UserName.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Password.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboBox_Group_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox_Group.KeyPress
        Dim tb As ComboBox
        tb = CType(sender, ComboBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub
End Class