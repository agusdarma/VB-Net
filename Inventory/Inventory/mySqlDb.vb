Imports MySql.Data.MySqlClient

Class mySqlDB
    'MySQL
    Public connString As String = "Server=127.0.0.1;Database=sms;Uid=root;Pwd=;"
    Public conn As MySqlConnection
    Public SUCCESS As String = "SUCCESS"
    Public SERROR As String = "ERROR"

    Public Function executeSQL(ByVal sSql As String, ByRef sResult As String) As Data.DataTable
        Dim sReturn As String = ""
        'Dim sr As SqlDataReader = Nothing
        Dim dt As DataTable = New DataTable
        Dim da As New MySqlDataAdapter
        conn = New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()
            Dim sComm As New MySqlCommand
            sComm.CommandText = sSql
            sComm.Connection = conn
            da.SelectCommand = sComm
            da.Fill(dt)
            conn.Close()
            sResult = SUCCESS
        Catch ex As Exception
            sResult = SERROR & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        conn = Nothing
        Return dt
    End Function
    Public Function executeDMLSQL(ByVal sSql As String, ByRef sResult As String) As Integer
        Dim sReturn As String = ""
        Dim irows As Integer = 0
        conn = New MySqlConnection
        Try
            conn.ConnectionString = connString
            conn.Open()
            Dim sComm As New MySqlCommand
            sComm.CommandText = sSql
            sComm.Connection = conn
            irows = sComm.ExecuteNonQuery()
            conn.Close()
            sResult = SUCCESS
        Catch ex As Exception
            sResult = SERROR & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        conn = Nothing
        Return irows
    End Function
End Class
