Imports MySql.Data.MySqlClient

Public Class UserEditFrm
    Dim userCodeEdit As String
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim publictable As New DataTable
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub UserEditFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userCodeEdit = UserFrm.getUserCode()
        'MessageBox.Show(userCodeEdit, "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                userCodeDb = publictable.Rows(0).Item(1)
                usernameDb = publictable.Rows(0).Item(2)
                Me.UserCode.Text = userCodeDb
                Me.UserName.Text = usernameDb
            Else
                MessageBox.Show("Data User Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
End Class