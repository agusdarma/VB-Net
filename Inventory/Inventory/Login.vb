Imports MySql.Data.MySqlClient

Public Class Login
    'Represents an SQL statement or stored procedure to execute against a data source.
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    'declare conn as connection and it will now a new connection because 
    'it is equal to Getconnection Function
    Dim con As MySqlConnection

    Public Function jokenconn() As MySqlConnection        
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCheckDb.Click
        Dim mydb As New mySqlDB
        Dim hasil As String = mydb.checkDB()
        MessageBox.Show(hasil)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim sql As String
        Dim publictable As New DataTable
        ' Check if username or password is empty
        If txtUserCode.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("User Code dan Password harus isi!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' Both fields was supply
            ' Check if user exist in database
            ' Connect to DB           
            Try
                con = jokenconn()
                sql = "select * from user where user_code ='" & txtUserCode.Text & "'"
                'bind the connection and query
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da.SelectCommand = cmd
                da.Fill(publictable)
                'check if theres a result by getting the count number of rows
                If publictable.Rows.Count > 0 Then
                    'it gets the data from specific column and assign to the variable
                    Dim userCode, password As String
                    userCode = publictable.Rows(0).Item(1)
                    password = publictable.Rows(0).Item(3)
                    'MessageBox.Show("user code : " + userCode + " password : " + password)
                    If password = txtPassword.Text Then
                        Me.Hide()
                        MainMenu.Show()
                    Else
                        MessageBox.Show("User Code atau Password Salah", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("User Code atau Password Salah", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            Catch ex As MySqlException
                MessageBox.Show("error : " + ex.ToString)

            Finally
                con.Close()
            End Try

        End If

    End Sub

    Private Sub txtUserCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserCode.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnLogin.KeyPress
        Dim tb As Button
        tb = CType(sender, Button)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCheckDb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnCheckDb.KeyPress
        Dim tb As Button
        tb = CType(sender, Button)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnExit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnExit.KeyPress
        Dim tb As Button
        tb = CType(sender, Button)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub
End Class
