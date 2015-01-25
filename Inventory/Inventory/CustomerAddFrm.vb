Imports MySql.Data.MySqlClient

Public Class CustomerAddFrm
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
        If CustomerCode.Text.Length = 0 Then
            MessageBox.Show("Please fill customer code", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf CustomerName.Text.Length = 0 Then
            MessageBox.Show("Please fill customer name", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf cp.Text.Length = 0 Then
            MessageBox.Show("Please fill contact person", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If CustomerFrm.getKodeCustomer.Length > 0 Then
                update()
                Me.Close()
                CustomerFrm.refreshGrid()
            Else
                If countCustomerByCode(CustomerCode.Text) = 0 Then
                    Dim row As Integer
                    row = insert()
                    ClearTextBoxes(Me)
                Else 
                    MessageBox.Show("Kode Customer duplikat, ganti dengan Kode Customer yang lain", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        CustomerFrm.refreshGrid()
    End Sub
    Private Function update() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try
            sql = "UPDATE customer SET name_customer = @namaCustomer ,contact_person = @cp,address1 = @address1,address2 = @address2,city = @city,phone = @phone,hp = @hp,fax = @fax,email = @email,website = @website,diskon = @diskon,credit_term = @credit_term,npwp = @npwp,territory_key = @territoryKey,credit_limit = @creditLimit,class_key = @classKey ,updated_by = @updatedBy ,updated_on = @updatedOn WHERE kode_customer = @kode_customer"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kode_customer", CustomerCode.Text)
            sqlCommand.Parameters.AddWithValue("@namaCustomer", CustomerName.Text)
            sqlCommand.Parameters.AddWithValue("@cp", cp.Text)
            sqlCommand.Parameters.AddWithValue("@address1", address1.Text)
            sqlCommand.Parameters.AddWithValue("@address2", address2.Text)
            sqlCommand.Parameters.AddWithValue("@city", city.Text)
            sqlCommand.Parameters.AddWithValue("@phone", phone.Text)
            sqlCommand.Parameters.AddWithValue("@hp", hp.Text)
            sqlCommand.Parameters.AddWithValue("@fax", fax.Text)
            sqlCommand.Parameters.AddWithValue("@email", email.Text)
            sqlCommand.Parameters.AddWithValue("@website", website.Text)
            sqlCommand.Parameters.AddWithValue("@diskon", disc.Text)
            sqlCommand.Parameters.AddWithValue("@credit_term", credit.Text)
            sqlCommand.Parameters.AddWithValue("@npwp", npwp.Text)
            sqlCommand.Parameters.AddWithValue("@classKey", classKey.Text)
            sqlCommand.Parameters.AddWithValue("@creditLimit", creditLimit.Text)
            sqlCommand.Parameters.AddWithValue("@territoryKey", TerritoryKey.Text)
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
            sql = "INSERT INTO customer(kode_customer,name_customer,contact_person,address1,address2,city,phone,hp,fax,email,website,diskon,credit_term,npwp,territory_key,credit_limit,class_key,updated_on,updated_by,created_by,created_on ) VALUES (@kodeCustomer, @namaCust,@cp,@addr1,@addr2,@city,@phone,@hp,@fax,@email,@website,@diskon,@credit,@npwp,@territory,@creditLimit,@classKey, @updatedOn, @updatedBy, @createdBy,@createdOn)"
            con = jokenconn()
            con.Open()
            Dim session As Session = Login.getSession()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kodeCustomer", CustomerCode.Text)
            sqlCommand.Parameters.AddWithValue("@namaCust", CustomerName.Text)
            sqlCommand.Parameters.AddWithValue("@cp", cp.Text)
            sqlCommand.Parameters.AddWithValue("@addr1", address1.Text)
            sqlCommand.Parameters.AddWithValue("@addr2", address2.Text)
            sqlCommand.Parameters.AddWithValue("@city", city.Text)
            sqlCommand.Parameters.AddWithValue("@phone", phone.Text)
            sqlCommand.Parameters.AddWithValue("@hp", hp.Text)
            sqlCommand.Parameters.AddWithValue("@fax", fax.Text)
            sqlCommand.Parameters.AddWithValue("@email", email.Text)
            sqlCommand.Parameters.AddWithValue("@website", website.Text)
            If disc.Text.Length = 0 Then
                sqlCommand.Parameters.AddWithValue("@diskon", 0)
            Else
                sqlCommand.Parameters.AddWithValue("@diskon", disc.Text)
            End If
            If credit.Text.Length = 0 Then
                sqlCommand.Parameters.AddWithValue("@credit", 0)
            Else
                sqlCommand.Parameters.AddWithValue("@credit", credit.Text)
            End If
            sqlCommand.Parameters.AddWithValue("@npwp", npwp.Text)
            If creditLimit.Text.Length = 0 Then
                sqlCommand.Parameters.AddWithValue("@creditLimit", 0)
            Else
                sqlCommand.Parameters.AddWithValue("@creditLimit", creditLimit.Text)
            End If
            sqlCommand.Parameters.AddWithValue("@classKey", classKey.Text)
            sqlCommand.Parameters.AddWithValue("@territory", TerritoryKey.Text)
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


    Private Sub disc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles disc.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub credit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles credit.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub creditLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles creditLimit.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CustomerCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CustomerCode.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CustomerName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CustomerName.KeyPress
        Dim tb As TextBox
        tb = CType(sender, TextBox)

        If Char.IsControl(e.KeyChar) Then
            If e.KeyChar.Equals(Chr(Keys.Return)) Then
                Me.SelectNextControl(tb, True, True, False, True)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CustomerAddFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CustomerFrm.getKodeCustomer.Length > 0 Then
            findCustomerByCode(CustomerFrm.getKodeCustomer)
            CustomerCode.ReadOnly = True
        End If
    End Sub
    Private Sub findCustomerByCode(kodeCustomer As String)
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Try
            Dim publictable As New DataTable
            sql = "select * from customer where kode_customer ='" & kodeCustomer & "'"
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
                    Me.CustomerCode.Text = publictable.Rows(0).Item(1)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(2)) Then
                    Me.CustomerName.Text = publictable.Rows(0).Item(2)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(3)) Then
                    Me.cp.Text = publictable.Rows(0).Item(3)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(4)) Then
                    Me.address1.Text = publictable.Rows(0).Item(4)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(5)) Then
                    Me.address2.Text = publictable.Rows(0).Item(5)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(6)) Then
                    Me.city.Text = publictable.Rows(0).Item(6)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(7)) Then
                    Me.phone.Text = publictable.Rows(0).Item(7)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(8)) Then
                    Me.hp.Text = publictable.Rows(0).Item(8)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(9)) Then
                    Me.fax.Text = publictable.Rows(0).Item(9)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(10)) Then
                    Me.email.Text = publictable.Rows(0).Item(10)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(11)) Then
                    Me.website.Text = publictable.Rows(0).Item(11)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(12)) Then
                    Me.disc.Text = publictable.Rows(0).Item(12)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(13)) Then
                    Me.credit.Text = publictable.Rows(0).Item(13)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(14)) Then
                    Me.npwp.Text = publictable.Rows(0).Item(14)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(15)) Then
                    Me.TerritoryKey.Text = publictable.Rows(0).Item(15)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(16)) Then
                    Me.creditLimit.Text = publictable.Rows(0).Item(16)
                End If
                If Not IsDBNull(publictable.Rows(0).Item(17)) Then
                    Me.classKey.Text = publictable.Rows(0).Item(17)
                End If
            Else
                MessageBox.Show("Data Customer Not Found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function countCustomerByCode(kodeCustomer As String) As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim db As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "SELECT COUNT(*) from customer where kode_customer ='" & kodeCustomer & "'"
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
End Class