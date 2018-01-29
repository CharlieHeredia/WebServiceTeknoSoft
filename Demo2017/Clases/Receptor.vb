Public Class Receptor
    Dim nombre As String = ""
    Dim RFC As String = ""
    Dim usocfdi As String = ""

    'Datos Receptor'
    Public Property _nombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
    Public Property _RFC() As String
        Get
            Return RFC
        End Get
        Set(value As String)
            RFC = value
        End Set
    End Property
    Public Property _usocfdi() As String
        Get
            Return usocfdi
        End Get
        Set(value As String)
            usocfdi = value
        End Set
    End Property
End Class
