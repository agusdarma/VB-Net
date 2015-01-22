Imports MySql.Data.MySqlClient

Class mySqlDB
    'MySQL
    Public connString As String = "Server=127.0.0.1;Database=ims;Uid=root;Pwd=root;"
    Public conn As MySqlConnection
    Public Function checkDB() As String
        Dim sReturn As String = ""        
        conn = New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()
            conn.Close()
            sReturn = "Database connected."
        Catch ex As Exception
            sReturn = "Failed to connect to Database.." & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        conn = Nothing
        Return sReturn
    End Function
    Public Function connectDB() As MySqlConnection       
        conn = New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()            
        Catch ex As Exception

        End Try       
        Return conn
    End Function
End Class
