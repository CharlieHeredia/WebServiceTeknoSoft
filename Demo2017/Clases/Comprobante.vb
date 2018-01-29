Public Class Comprobante
    Dim version As String = "3.3"
    Dim serie As String = ""
    Dim folio As String = ""
    Dim fecha As String = ""
    Dim tipoDeComprobante As String = ""
    Dim formaDePago As String = ""
    Dim metodoDePago As String = ""
    Dim subTotal As String = ""
    Dim moneda As String = ""
    Dim total As String = ""
    Dim LugarExpedicion As String = ""
    Dim NumCtaPago As String = ""

    Public Property _serie As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property

    Public Property _folio As String
        Get
            Return folio
        End Get
        Set(value As String)
            folio = value
        End Set
    End Property
    Public Property _fecha As String
        Get
            Return fecha
        End Get
        Set(value As String)
            fecha = value
        End Set
    End Property
    Public Property _tipoDeComprobante As String
        Get
            Return tipoDeComprobante
        End Get
        Set(value As String)
            tipoDeComprobante = value
        End Set
    End Property
    Public Property _formaDePago As String
        Get
            Return formaDePago
        End Get
        Set(value As String)
            formaDePago = value
        End Set
    End Property
    Public Property _metodoDePago As String
        Get
            Return metodoDePago
        End Get
        Set(value As String)
            metodoDePago = value
        End Set
    End Property
    Public Property _subTotal As String
        Get
            Return subTotal
        End Get
        Set(value As String)
            subTotal = value
        End Set
    End Property
    Public Property _moneda As String
        Get
            Return moneda
        End Get
        Set(value As String)
            moneda = value
        End Set
    End Property
    Public Property _total As String
        Get
            Return total
        End Get
        Set(value As String)
            total = value
        End Set
    End Property
    Public Property _lugarExpedicion As String
        Get
            Return LugarExpedicion
        End Get
        Set(value As String)
            LugarExpedicion = value
        End Set
    End Property
    Public Property _NumCtaPago As String
        Get
            Return NumCtaPago
        End Get
        Set(value As String)
            NumCtaPago = value
        End Set
    End Property
End Class
