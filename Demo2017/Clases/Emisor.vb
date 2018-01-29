Public Class Emisor
    Dim nombre As String = ""
    Dim RFC As String = ""
    Dim regimenFiscal As String = ""

    'Datos Emisor'
    Public Property _nombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
    Public Property _rfc() As String
        Get
            Return RFC
        End Get
        Set(value As String)
            RFC = value
        End Set
    End Property
    Public Property _regimenFiscal() As String
        Get
            Return regimenFiscal
        End Get
        Set(value As String)
            regimenFiscal = value
        End Set
    End Property
End Class
