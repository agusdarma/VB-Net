Imports MySql.Data.MySqlClient

Public Class SupplierAddFrm

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
        If SupplierCode.Text.Length = 0 Then
            MessageBox.Show(String.Format("Please fill supplier code", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning))
        ElseIf SupplierName.Text.Length = 0 Then
            MessageBox.Show(String.Format("Please fill supplier name", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning))
        ElseIf cp.Text.Length = 0 Then
            MessageBox.Show(String.Format("Please fill contact person", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning))
        Else
            Dim row As Integer
            row = insert()
            ClearTextBoxes(Me)
        End If
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        SupplierFrm.refreshGrid()
    End Sub
    Private Function insert() As Integer
        Dim rowEffected As Integer
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim now As DateTime = DateTime.Now
        Try            
            sql = "INSERT INTO supplier(kode_supplier,name_supplier,contact_person,address1,address2,city,phone,hp,fax,email,website,diskon,credit_term,npwp,updated_on,updated_by,created_by,created_on ) VALUES (@kodeSupplier, @namaSupp,@cp,@addr1,@addr2,@city,@phone,@hp,@fax,@email,@website,@diskon,@credit,@npwp, @updatedOn, @updatedBy, @createdBy,@createdOn)"
            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@kodeSupplier", SupplierCode.Text)
            sqlCommand.Parameters.AddWithValue("@namaSupp", SupplierName.Text)
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
            sqlCommand.Parameters.AddWithValue("@updatedOn", now)
            sqlCommand.Parameters.AddWithValue("@updatedBy", SupplierCode.Text)
            sqlCommand.Parameters.AddWithValue("@createdOn", now)
            sqlCommand.Parameters.AddWithValue("@createdBy", SupplierCode.Text)
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
End Class