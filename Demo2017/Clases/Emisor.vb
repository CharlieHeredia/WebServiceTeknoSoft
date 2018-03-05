Public Class Emisor
    Dim IdEmpresa As String = "" 'ID DE EMPRESA.'
    Dim RutaDatos As String = "" 'RUTA DE DATOS.'
    Dim NombreEmpresa As String = "" 'NOBRE EMPRESA.'
    Dim RFC As String = "" ' RFC DE EMPRESA.'
    Dim RegimenFiscal As String = "" ' REGIMEN FISCAL.'
    Dim Impuesto1 As String = ""
    Dim Impuesto2 As String = ""
    Dim Impuesto3 As String = ""
    Dim NombreImpuesto1 As String = ""
    Dim NombreImpuesto2 As String = ""
    Dim NombreImpuesto3 As String = ""

    Public Property _IdEmpresa() As String
        Get
            Return IdEmpresa
        End Get
        Set(value As String)
            IdEmpresa = value
        End Set
    End Property
    Public Property _RutaDatos() As String
        Get
            Return RutaDatos
        End Get
        Set(value As String)
            RutaDatos = value
        End Set
    End Property
    Public Property _NombreEmpresa() As String
        Get
            Return NombreEmpresa
        End Get
        Set(value As String)
            NombreEmpresa = value
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
            Return RegimenFiscal
        End Get
        Set(value As String)
            RegimenFiscal = value
        End Set
    End Property
    Public Property _Impuesto1() As String
        Get
            Return Impuesto1
        End Get
        Set(value As String)
            Impuesto1 = value
        End Set
    End Property
    Public Property _Impuesto2() As String
        Get
            Return Impuesto2
        End Get
        Set(value As String)
            Impuesto2 = value
        End Set
    End Property
    Public Property _Impuesto3() As String
        Get
            Return Impuesto3
        End Get
        Set(value As String)
            Impuesto3 = value
        End Set
    End Property
    Public Property _NombreImpuesto1() As String
        Get
            Return NombreImpuesto1
        End Get
        Set(value As String)
            NombreImpuesto1 = value
        End Set
    End Property
    Public Property _NombreImpuesto2() As String
        Get
            Return NombreImpuesto2
        End Get
        Set(value As String)
            NombreImpuesto2 = value
        End Set
    End Property
    Public Property _NombreImpuesto3() As String
        Get
            Return NombreImpuesto3
        End Get
        Set(value As String)
            NombreImpuesto3 = value
        End Set
    End Property
End Class
