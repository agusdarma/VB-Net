Imports MySql.Data.MySqlClient

Public Class UserFrm
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim rowPage As Integer = 10
    Dim rowStart As Integer
    Dim totalRow As Integer
    Dim currentPage As Integer
    Public userCode As String
    Dim paramSearch As String
    Public sqlBase As String = "Select u.id as ID, u.user_code as Usercode, u.user_name as Username,g.group_name as Groupname,u.last_login_on as LastLoginDate,u.updated_by as UpdatedBy, u.updated_on as UpdatedOn "
    Public Function jokenconn() As MySqlConnection
        'Return New MySqlConnection(connString)
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub UserFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshGrid()
    End Sub
    Private Sub calculateTotalAllRow()
        'Create Command object
        Dim nonqueryCommand As MySqlCommand = con.CreateCommand()
        Try
            ' Open Connection
            con.Open()            
            System.Diagnostics.Debug.WriteLine("Connection Opened")
            'Create Command objects
            Dim Sql As String
            If paramSearch = "" Then
                Sql = "SELECT COUNT(*) FROM user"
            Else
                Sql = "SELECT COUNT(*) FROM user where user_code like '%" + paramSearch + "%'"
            End If
            Dim scalarCommand As New MySqlCommand(Sql, con)
            ' Execute Scalar Query
            Console.WriteLine("Before INSERT, Number of Employees = {0}",
                              scalarCommand.ExecuteScalar())
            totalRow = scalarCommand.ExecuteScalar()
            con.Close()
        Catch ex As MySqlException
            ' Display error
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            ' Close Connection
            con.Close()
            Console.WriteLine("Connection Closed")
        End Try

    End Sub
    Private Sub updateNextCurrentPage()
        currentPage = currentPage + 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub updatePrevCurrentPage()
        currentPage = currentPage - 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub resetCurrentPage()
        currentPage = 1
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Sub resetCurrentPageForLast()
        currentPage = calculateTotalPages()
        labelCurrentPage.Text = currentPage.ToString
        Label_Showing_Pages.Text = "Showing pages " + currentPage.ToString + " of " + calculateTotalPages().ToString
        Label_TotalRecord.Text = "Total Records : " + totalRow.ToString
    End Sub
    Private Function calculateTotalPages() As Integer
        'Create Command object
        Dim tempTotalPages As Double
        Dim totalPages As Double
        tempTotalPages = totalRow / rowPage
        totalPages = Math.Ceiling(tempTotalPages)
        Return totalPages
    End Function
    Private Sub LinkLabel_NextPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_NextPage.LinkClicked
        Dim sql As String
        Try            
            calculateTotalAllRow()
            rowStart = rowStart + rowPage
            If rowStart < totalRow Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()

                If paramSearch = "" Then
                    sql = sqlBase & " from user u inner join groups g on u.group_id = g.id order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from user u inner join groups g on u.group_id = g.id where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "user")
                GridUser.DataSource = ds.Tables(0)
                con.Close()
                updateNextCurrentPage()
            Else
                MessageBox.Show("This is last data", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rowStart = rowStart - rowPage
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_LastPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_LastPage.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            Dim totalPage As Integer = calculateTotalPages()
            rowStart = (totalPage - 1) * rowPage
            ds = New DataSet()
            con = jokenconn()
            con.Open()

            If paramSearch = "" Then
                sql = sqlBase & " from user u inner join groups g on u.group_id = g.id order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from user u inner join groups g on u.group_id = g.id where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
            con.Close()
            resetCurrentPageForLast()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_FirstPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_FirstPage.LinkClicked
        Dim sql As String
        Try
            rowStart = 0
            ds = New DataSet()
            con = jokenconn()
            con.Open()


            If paramSearch = "" Then
                sql = sqlBase & " from user u inner join groups g on u.group_id = g.id order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & " from user u inner join groups g on u.group_id = g.id where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
            con.Close()
            resetCurrentPage()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LinkLabel_Previous_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_Previous.LinkClicked
        Dim sql As String
        Try
            calculateTotalAllRow()
            rowStart = rowStart - rowPage
            If rowStart >= 0 Then
                ds = New DataSet()
                con = jokenconn()
                con.Open()

                If paramSearch = "" Then
                    sql = sqlBase & " from user u inner join groups g on u.group_id = g.id order by id asc limit " & rowStart & "," & rowPage & ""
                Else
                    sql = sqlBase & " from user u inner join groups g on u.group_id = g.id where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
                End If
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "user")
                GridUser.DataSource = ds.Tables(0)
                con.Close()
                updatePrevCurrentPage()

            Else
                MessageBox.Show("This is last data.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rowStart = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try

    End Sub
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridUser.CellMouseDoubleClick
        'If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
        '    Dim selectedRow = GridUser.Rows(e.RowIndex)
        '    MessageBox.Show("tess")
        'End If
    End Sub

    

    Private Sub Button_Edit_Click_1(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim selectedRowCount As Integer = GridUser.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            userCode = GridUser.SelectedRows(0).Cells(1).Value
            UserEditFrm.Show()
        End If
    End Sub
    Public Function getUserCode() As String
        Return userCode
    End Function
    Public Sub refreshGrid()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            If paramSearch = "" Then
                sql = sqlBase & "from user u inner join groups g on u.group_id = g.id order by id asc limit " & rowStart & "," & rowPage & ""
            Else
                sql = sqlBase & "from user u inner join groups g on u.group_id = g.id where u.user_code like '%" + paramSearch + "%' order by id asc limit " & rowStart & "," & rowPage & ""
            End If
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "user")
            GridUser.DataSource = ds.Tables(0)
            con.Close()
            calculateTotalAllRow()
            resetCurrentPage()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        UserAddFrm.Show()
    End Sub

    Private Sub Button_delete_Click(sender As Object, e As EventArgs) Handles Button_delete.Click
        Dim selectedRowCount As Integer = GridUser.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            userCode = GridUser.SelectedRows(0).Cells(1).Value
            Dim result As Integer = MessageBox.Show("Are you sure want to delete this item " + vbNewLine + "User Code : " + userCode, "Confirmation Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                refreshGrid()
            ElseIf result = DialogResult.Yes Then
                delete(userCode)
                MessageBox.Show("Data has been deleted", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                refreshGrid()
            End If
        End If
    End Sub
    Private Function delete(userCode As String) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            sql = "Delete from user WHERE user_code = @userCode"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@userCode", userCode)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function

    Private Sub Button_Search_Click(sender As Object, e As EventArgs) Handles Button_Search.Click
        paramSearch = TextBox_SearchBy.Text
        resetCurrentPage()
        LinkLabel_FirstPage_LinkClicked(Nothing, Nothing)
        refreshGrid()
    End Sub

    Private Sub TextBox_SearchBy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_SearchBy.KeyPress
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