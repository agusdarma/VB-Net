Public Class UserMenuVO
    Private menu As String = String.Empty
    Private id As Integer = 0
    Private accessLevel As Boolean = False
    Public Property getNamaMenu() As String
        Get
            Return menu
        End Get
        Set(value As String)
            menu = value
        End Set
    End Property
    Public Property getIDMenu() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property getAccessLevel() As Boolean
        Get
            Return accessLevel
        End Get
        Set(value As Boolean)
            accessLevel = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.menu
    End Function
End Class
