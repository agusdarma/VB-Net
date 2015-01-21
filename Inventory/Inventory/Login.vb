Public Class Login

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCheckDb.Click
        Dim mydb As New mySqlDB


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Hide()
        MainMenu.Show()

    End Sub
End Class
