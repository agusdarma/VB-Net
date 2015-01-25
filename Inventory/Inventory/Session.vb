Public Class Session
    Public Sub New(ByVal code As String)
        userCode = code
    End Sub
    Private userCode As String
    Public Property Code() As String
        Get
            Return userCode
        End Get
        Set(ByVal value As String)
            userCode = value
        End Set
    End Property
End Class
