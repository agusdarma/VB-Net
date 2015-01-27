Imports MySql.Data.MySqlClient

Public Class WarehouseAdd
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
    Private Sub WarehouseAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Warehouse.getKodeGudang.Length > 0 Then
            findGudangByCode(Warehouse.getKodeGudang)
            KodeGudang.ReadOnly = True
        End If
    End Sub
    Private Sub findGudangByCode(kodeGudang As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select * from gudang where kode_gudang ='" & kodeGudang & "'"
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
                    Me.KodeGudang.Text = publictable.Rows(0).Item(1)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    Me.NamaGudang.Text = publictable.Rows(0).Item(2)
                End If
            Else
                MessageBox.Show("Data Gudang Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function countGudangByCode(kodeGudang As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from gudang where kode_gudang ='" & kodeGudang & "'"
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
        'pengecekan harus di input semua
        If KodeGudang.Text.Length = 0 Then
            MessageBox.Show("Please fill kode gudang", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf NamaGudang.Text.Length = 0 Then
            MessageBox.Show("Please fill nama gudang", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Warehouse.getKodeGudang.Length > 0 Then
                Update()
                Me.Close()
                Warehouse.refreshGrid()
            Else
                If countGudangByCode(KodeGudang.Text) = 0 Then
                    Dim row As Integer
                    row = insert()
                    ClearTextBoxes(Me)
                Else
                    MessageBox.Show("Kode gudang duplikat, ganti dengan Kode gudang yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Function Update() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "UPDATE gudang SET nama_gudang = @namaGudang,address = @address,person_in_charge = @pic ,updated_by = @updatedBy ,updated_on = @updatedOn WHERE kode_gudang = @kode_gudang"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_gudang", KodeGudang.Text)
            sqlCommand.Parameters.AddWithValue("@namaGudang", NamaGudang.Text)
            sqlCommand.Parameters.AddWithValue("@address", address.Text)
            sqlCommand.Parameters.AddWithValue("@pic", pic.Text)
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
            sql = "INSERT INTO gudang(kode_gudang,nama_gudang,address,person_in_charge,updated_on,updated_by,created_by,created_on ) VALUES (@kode_gudang, @namaGudang,@address,@pic, @updatedOn, @updatedBy, @createdBy,@createdOn)"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_gudang", KodeGudang.Text)
            sqlCommand.Parameters.AddWithValue("@namaGudang", NamaGudang.Text)
            sqlCommand.Parameters.AddWithValue("@address", address.Text)
            sqlCommand.Parameters.AddWithValue("@pic", pic.Text)
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

    Private Sub KodeGudang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles KodeGudang.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub NamaGudang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NamaGudang.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        Warehouse.refreshGrid()
    End Sub

    Private Sub address_KeyPress(sender As Object, e As KeyPressEventArgs) Handles address.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub pic_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pic.KeyPress
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