Imports MySql.Data.MySqlClient

Public Class ItemCategoryAdd
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
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

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        'pengecekan harus di input semua
        If KodeKategori.Text.Length = 0 Then
            MessageBox.Show("Please fill kode kategori", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf NamaKategori.Text.Length = 0 Then
            MessageBox.Show("Please fill nama kategori", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If ItemsCategory.getKodeCategory.Length > 0 Then
                Update()
                Me.Close()
                ItemsCategory.refreshGrid()
            Else
                If countItemsCategoryByCode(KodeKategori.Text) = 0 Then
                    Dim row As Integer
                    row = insert()
                    ClearTextBoxes(Me)
                Else
                    MessageBox.Show("Kode kategori duplikat, ganti dengan Kode kategori yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
    Private Function update() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "UPDATE items_category SET nama_kategori = @namaKategori ,updated_by = @updatedBy ,updated_on = @updatedOn WHERE kode_category = @kode_category"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_category", KodeKategori.Text)
            sqlCommand.Parameters.AddWithValue("@namaKategori", NamaKategori.Text)
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Data has been updated", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function
    Private Function insert() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "INSERT INTO items_category(kode_category,nama_kategori,updated_on,updated_by,created_by,created_on ) VALUES (@kode_category, @namaKategori, @updatedOn, @updatedBy, @createdBy,@createdOn)"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_category", KodeKategori.Text)
            sqlCommand.Parameters.AddWithValue("@namaKategori", NamaKategori.Text)            
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", session.Code)
            sqlCommand.Parameters.AddWithValue("@createdOn", now)
            sqlCommand.Parameters.AddWithValue("@createdBy", session.Code)
            rowEffected = sqlCommand.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function

    Private Sub KodeKategori_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KodeKategori.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub NamaKategori_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NamaKategori.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ItemCategoryAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ItemsCategory.getKodeCategory.Length > 0 Then
            findItemsCategoryCode(ItemsCategory.getKodeCategory)
            KodeKategori.ReadOnly = True
        End If
    End Sub
    Private Sub findItemsCategoryCode(kodeCategory As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select * from items_category where kode_category ='" & kodeCategory & "'"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            da.SelectCommand = sqlCommand
            da.Fill(publictable)
            con.Close()
            If publictable.Rows.Count > 0 Then
                'it gets the data from specific column and assign to the variable
                If Not IsDBNull(publictable.Rows(0).Item(1)) Then
                    Me.KodeKategori.Text = publictable.Rows(0).Item(1)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    Me.NamaKategori.Text = publictable.Rows(0).Item(2)
                End If                
            Else
                MessageBox.Show("Data Items Category Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function countItemsCategoryByCode(kodeCategory As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from items_category where kode_category ='" & kodeCategory & "'"
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

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        ItemsCategory.refreshGrid()
    End Sub
End Class