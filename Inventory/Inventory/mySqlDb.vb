Imports Microsoft.VisualBasic

Public Class Class1
    'MySQL
 13      Public connString As String = "Server=127.0.0.1;Database=sms;Uid=root;Pwd=;"
 14      Public conn As MySqlConnection
 15      Public SUCCESS As String = "SUCCESS"
 16      Public SERROR As String = "ERROR"
 17  
 18      Public Function executeSQL(ByVal sSql As String, ByRef sResult As String) As Data.DataTable
 19          Dim sReturn As String = ""
 20          'Dim sr As SqlDataReader = Nothing
 21          Dim dt As DataTable = New DataTable
 22          Dim da As New mySqlDataAdapter
 23          conn = New MySqlConnection
 24          Try
 25              conn.ConnectionString = connString
 26              conn.Open()
 27              Dim sComm As New MySqlCommand
 28              sComm.CommandText = sSql
 29              sComm.Connection = conn
 30              da.SelectCommand = sComm
 31              da.Fill(dt)
 32              conn.Close()
 33              sResult = SUCCESS
 34          Catch ex As Exception
 35              sResult = SERROR & ": " & ex.Message
 36              If (conn.State = Data.ConnectionState.Open) Then
 37                  conn.Close()
 38              End If
 39          End Try
 40          conn = Nothing
 41          Return dt
 42      End Function
 43      Public Function executeDMLSQL(ByVal sSql As String, ByRef sResult As String) As Integer
 44          Dim sReturn As String = ""
 45          Dim irows As Integer = 0
 46          conn = New MySqlConnection
 47          Try
 48              conn.ConnectionString = connString
 49              conn.Open()
 50              Dim sComm As New MySqlCommand
 51              sComm.CommandText = sSql
 52              sComm.Connection = conn
 53              irows = sComm.ExecuteNonQuery()
 54              conn.Close()
 55              sResult = SUCCESS
 56          Catch ex As Exception
 57              sResult = SERROR & ": " & ex.Message
 58              If (conn.State = Data.ConnectionState.Open) Then
 59                  conn.Close()
 60              End If
 61          End Try
 62          conn = Nothing
 63          Return irows
 64      End Function
 65      Public Sub populateDDList(ByRef ctlDD As DropDownList, ByVal sSql As String)
 66  
 67          Dim res As String = ""
 68          Dim red As DataTable 'SqlDataReader = Nothing
 69          Dim drow As DataRow
 70          red = executeSQL(sSql, res)
 71          ctlDD.Items.Clear()
 72          ctlDD.Items.Add(New ListItem("Select", "Select"))
 73          If res = "SUCCESS" Then
 74              For Each drow In red.Rows
 75                  ctlDD.Items.Add(New ListItem(drow.Item(0).ToString, drow.Item(1).ToString))
 76              Next
 77          Else
 78          End If
 79      End Sub
 80  
 81      Public Function executeSQL_dset(ByVal sSql As String, ByRef sResult As String) As Data.DataSet
 82          Dim sReturn As String = ""
 83          'Dim sr As SqlDataReader = Nothing
 84          'Dim dt As DataTable = New DataTable
 85          Dim dt As DataSet = New DataSet
 86          Dim da As New MySqlDataAdapter
 87          conn = New MySqlConnection
 88          Try
 89              conn.ConnectionString = connString
 90              conn.Open()
 91              Dim sComm As New MySqlCommand
 92              sComm.CommandText = sSql
 93              sComm.Connection = conn
 94              da.SelectCommand = sComm
 95              da.Fill(dt)
 96              conn.Close()
 97              sResult = SUCCESS
 98          Catch ex As Exception
 99              sResult = SERROR & ": " & ex.Message
100              If (conn.State = Data.ConnectionState.Open) Then
101                  conn.Close()
102              End If
103          End Try
104          conn = Nothing
105          Return dt
106      End Function
107  
108      Public Function fillmygridview(gdview As WebControls.GridView, selectsql As String) As GridView
109          Try
110              Dim res As String = ""
111              Dim dset As Data.DataSet
112              Dim sSql1 As String = selectsql
113              dset = executeSQL_dset(sSql1, res)
114              gdview.DataSource = dset
115              gdview.DataBind()
116          Catch ex As Exception
117          End Try
118          Return gdview
119      End Function
120  
121      Public Function getAllMonth(ByVal sdate As String) As String
122          Dim sSql As String = ""
123          'Dim dDate As Date = date.(sdate,"dd/MM/yyyy")
124          'dDate.Month = sdate.Substring(3, 2)
125  
126          Dim inumDays As Integer = Date.DaysInMonth(sdate.Substring(6, 4), sdate.Substring(3, 2)) 'dDate.AddMonths(1).AddDays(-1).Day
127          Dim dd As Integer
128          For dd = 1 To inumDays
129              sSql &= ", max(case when day(att_date)=" & dd & " then att_flag else '' end) as '" & dd & "' "
130          Next
131  
132          Return sSql
133      End Function
134  
135      Public Sub CreateConfirmBox(ByRef btn As WebControls.GridView, _
136                                         ByVal strMessage As String)
137          btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
138      End Sub
139      Public Sub CreateConfirmBoxButton(ByRef btn As WebControls.Button, _
140                                         ByVal strMessage As String)
141          btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
142      End Sub
143      Public Sub CreateConfirmBoxlink(ByRef btn As WebControls.LinkButton, _
144                                        ByVal strMessage As String)
145          btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
146  
147      End Sub
148  
149      Sub sendmail(ByVal body As String, ByVal email As String)
150          Try
151              'Dim uemail As String = a
152              Dim MailObj As New System.Net.Mail.SmtpClient
153              Dim basicAuthenticationInfo As New System.Net.NetworkCredential("ServiceOrder@canar.com.sd", "satellite")
154              'Put your own, or your ISPs, mail server name onthis next line
155              'mailClient.Host = "Mail.RemoteMailServer.com"
156              'MailObj.UseDefaultCredentials = False
157              MailObj.Credentials = basicAuthenticationInfo
158              MailObj.Port = 25
159              'MailObj.EnableSsl = True
160  
161              MailObj.Host = "canarmail.canar.com.sd"
162              MailObj.Send("ServiceOrder@canar.com.sd", email, "Service Order Notification Service", body)
163              'MsgBox("done")
164          Catch ex As Exception
165              'MsgBox(ex.ToString) 'Errorbar.Text = Errorbar.Text + " Email not Sent ..!"
166          End Try
167      End Sub
168  
End Class
