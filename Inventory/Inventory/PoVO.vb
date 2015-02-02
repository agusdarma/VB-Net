Public Class PoVO
    Public Sub New(ByVal noPo As String)
        PONo = noPo
    End Sub

    Private PONo As String
    Public Property NOPO() As String
        Get
            Return PONo
        End Get
        Set(ByVal value As String)
            PONo = value
        End Set
    End Property
End Class
