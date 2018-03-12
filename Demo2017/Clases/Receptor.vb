Public Class Receptor
    Dim razonsocial As String = "" ' RAZON SOCIAL.'
    Dim RFC As String = "" 'RFC.'
    Dim usocfdi As String = "" ' USOCFDI.'
    Dim Direccion As String = "" 'DIRECCIÓN COMPLETA (SEPARADA POR COMAS.')
    Dim Nombre As String = "" 'NOMBRE DEL RECEPTOR.'

    'Datos Receptor'
    Public Property _razonsocial() As String
        Get
            Return razonsocial
        End Get
        Set(value As String)
            razonsocial = value
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
    Public Property _Direccion() As String
        Get
            Return Direccion
        End Get
        Set(value As String)
            Direccion = value
        End Set
    End Property
    Public Property _Nombre() As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property
End Class
