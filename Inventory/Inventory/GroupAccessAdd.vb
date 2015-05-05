Imports MySql.Data.MySqlClient

Public Class GroupAccessAdd
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Dim CheckedListBox1 = New CheckedListBox()
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Public Sub ClearTextBoxes(frm As Form)

        For Each Control In frm.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

    End Sub
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        GroupAccess.refreshGrid()
    End Sub

    Private Sub GroupAccessAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generateMenu()
        If GroupAccess.getKodeGroup.Length > 0 Then
            findGroupsByCode(GroupAccess.getKodeGroup)
            KodeGroups.ReadOnly = True
        End If
    End Sub
    Private Sub generateMenu()
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim listMenu As New List(Of UserMenuVO)
            Dim publictable As New DataTable
            sql = "select id as id, module_name as menu from user_modules"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            For Each row As DataRow In publictable.Rows
                Dim tempMenu As UserMenuVO = New UserMenuVO()
                tempMenu.getIDMenu = row.Item("id")
                tempMenu.getNamaMenu = row.Item("menu")
                listMenu.Add(tempMenu)
            Next row
            Dim chckAll = New CheckBox()
            chckAll.Name = "chckAll"
            Me.Controls.Add(chckAll)
            chckAll.Location = New Point(12, 110)
            chckAll.Text = "Check All"
            chckAll.Checked = False
            chckAll.Size = New Size(100, 20)
            AddHandler chckAll.Click, AddressOf checkAll_Click


            CheckedListBox1.Location = New System.Drawing.Point(12, 130)
            CheckedListBox1.Name = "CheckedListBox1"
            CheckedListBox1.Size = New System.Drawing.Size(335, 190)
            CheckedListBox1.BackColor = System.Drawing.Color.LightGray
            CheckedListBox1.ForeColor = System.Drawing.Color.Black
            CheckedListBox1.FormattingEnabled = True
            Me.Controls.Add(CheckedListBox1)
            For Each cur In listMenu
                CheckedListBox1.Items.Add(cur)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function getMenuIdSelected() As List(Of UserMenuVO)
        Dim menuIdSelected As New List(Of UserMenuVO)
        Dim allMenu As New List(Of UserMenuVO)
        For Each item In CheckedListBox1.CheckedItems
            Dim userMenuVO As UserMenuVO
            userMenuVO = CType(item, UserMenuVO)
            menuIdSelected.Add(userMenuVO)
        Next
        For Each item In CheckedListBox1.Items
            Dim userMenuVO As UserMenuVO
            userMenuVO = CType(item, UserMenuVO)
            allMenu.Add(userMenuVO)
        Next
        For Each tempMenu As UserMenuVO In allMenu
            For Each tempMenuSelected As UserMenuVO In menuIdSelected
                If tempMenu.getIDMenu = tempMenuSelected.getIDMenu Then
                    tempMenu.getAccessLevel = True
                End If
            Next
        Next
        Return allMenu
    End Function
    Private Sub checkAll_Click(sender As Object, e As EventArgs)
        Dim checkAll = CType(sender, CheckBox)
        If checkAll.Checked = False Then
            Dim sb As New System.Text.StringBuilder
            For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemCheckState(idx, 0)
            Next
        ElseIf checkAll.Checked = True Then
            Dim sb As New System.Text.StringBuilder
            For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemCheckState(idx, 1)
            Next
        End If
    End Sub
    Private Sub checkMenuEdit(listMenu As DataTable)
        For Each row As DataRow In listMenu.Rows
            'strDetail = row("Detail")
            Dim access As String
            Dim menuName As String
            access = row("access")
            menuName = row("moduleName")
            If access = "1" Then
                Dim idx As Integer = 0
                For Each item In CheckedListBox1.Items
                    Dim userMenuVO As UserMenuVO
                    userMenuVO = CType(item, UserMenuVO)
                    If menuName.Equals(userMenuVO.getNamaMenu) Then                        
                        For index As Integer = 0 To CheckedListBox1.Items.Count - 1
                            If index = idx Then
                                CheckedListBox1.SetItemCheckState(index, 1)
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                    idx = idx + 1
                Next
            End If
        Next row
    End Sub
    Private Sub findGroupsByCode(kodeGroups As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select gs.group_code as groupCode, gs.group_name as groupName, gm.module_id as menuId, gm.access_level as access, um.module_name as moduleName from groups gs inner join group_module gm on gs.id = gm.group_id inner join user_modules um on um.id = gm.module_id where gs.group_code ='" & kodeGroups & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                'it gets the data from specific column and assign to the variable
                If Not IsDBNull(publictable.Rows(0).Item("groupCode")) Then
                    Me.KodeGroups.Text = publictable.Rows(0).Item("groupCode").ToString
                End If
                If Not IsDBNull(publictable.Rows(0).Item("groupName")) Then
                    Me.NamaGroups.Text = publictable.Rows(0).Item("groupName").ToString
                End If
                checkMenuEdit(publictable)
            Else
                MessageBox.Show("Data Groups Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function countGroupsByCode(kodeGroups As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from groups where group_code ='" & kodeGroups & "'"
            Dim scalarCommand As New MySqlCommand(Sql, con)
            db = scalarCommand.ExecuteScalar()
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        Dim menuIdSelected As New List(Of UserMenuVO)
        menuIdSelected = getMenuIdSelected()
        'pengecekan harus di input semua
        If KodeGroups.Text.Length = 0 Then
            MessageBox.Show("Please fill kode groups", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf NamaGroups.Text.Length = 0 Then
            MessageBox.Show("Please fill nama groups", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf menuIdSelected.Count = 0 Then
            MessageBox.Show("Please select menu access", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If GroupAccess.getKodeGroup.Length > 0 Then
                Update(menuIdSelected)
                Me.Close()
                GroupAccess.refreshGrid()
            Else
                If countGroupsByCode(KodeGroups.Text) = 0 Then
                    Dim row As Integer
                    row = insert(menuIdSelected)
                    ClearTextBoxes(Me)
                Else
                    MessageBox.Show("Kode groups duplikat, ganti dengan Kode groups yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Function Update(userMenu As List(Of UserMenuVO)) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            sql = "UPDATE groups SET group_name = @group_name,updated_by = @updatedBy ,updated_on = @updatedOn WHERE group_code = @group_code"
            
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@group_name", NamaGroups.Text)
            sqlCommand.Parameters.AddWithValue("@group_code", KodeGroups.Text)
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()

            sql = "select id from groups where group_code = @group_code"
            sqlCommand.CommandText = sql
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()
            ' Delete Group Module First
            sqlCommand.Parameters.AddWithValue("@ID", ID)
            sql = "delete from group_module where group_id = @ID"
            sqlCommand.CommandText = sql
            sqlCommand.ExecuteScalar()

            ' Insert Group Module
            sql = "INSERT INTO group_module(group_id,module_id,access_level) VALUES (@group_id,@module_id,@access_level)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.Add("@group_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@module_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@access_level", MySqlDbType.Int32)
            For Each menu As UserMenuVO In userMenu
                sqlCommand.Parameters("@group_id").Value = ID
                sqlCommand.Parameters("@module_id").Value = menu.getIDMenu
                If menu.getAccessLevel = False Then
                    sqlCommand.Parameters("@access_level").Value = 0
                Else
                    sqlCommand.Parameters("@access_level").Value = 1
                End If
                sqlCommand.ExecuteNonQuery()
            Next

            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been updated", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function

    Private Function insert(userMenu As List(Of UserMenuVO)) As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        Dim queryGetIdentity As String = "Select @@Identity"
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            sql = "INSERT INTO groups(group_code,group_name,updated_on,updated_by,created_by,created_on ) VALUES (@group_code, @group_name, @updated_on, @updated_by, @created_by,@created_on)"
           
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@group_code", KodeGroups.Text)
            sqlCommand.Parameters.AddWithValue("@group_name", NamaGroups.Text)
            sqlCommand.Parameters.AddWithValue("@updated_on", now)
            sqlCommand.Parameters.AddWithValue("@updated_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@created_by", session.Code)
            sqlCommand.Parameters.AddWithValue("@created_on", now)
            rowEffected = sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()
            ' Insert Group Module
            sql = "INSERT INTO group_module(group_id,module_id,access_level) VALUES (@group_id,@module_id,@access_level)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.Add("@group_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@module_id", MySqlDbType.Int32)
            sqlCommand.Parameters.Add("@access_level", MySqlDbType.Int32)
            For Each menu As UserMenuVO In userMenu
                sqlCommand.Parameters("@group_id").Value = ID
                sqlCommand.Parameters("@module_id").Value = menu.getIDMenu
                If menu.getAccessLevel = False Then
                    sqlCommand.Parameters("@access_level").Value = 0
                Else
                    sqlCommand.Parameters("@access_level").Value = 1
                End If
                sqlCommand.ExecuteNonQuery()
            Next
            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
End Class