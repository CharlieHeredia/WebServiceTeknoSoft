Public Class Traslado
    Dim base As String = ""
    Dim impuesto As String = ""
    Dim tipofactor As String = ""
    Dim tasacuota As String = ""
    Dim importe As String = ""

    'Datos traslado'

    Public Property _base() As String
        Get
            Return base
        End Get
        Set(value As String)
            base = value
        End Set
    End Property

    Public Property _impuesto() As String
        Get
            Return impuesto
        End Get
        Set(value As String)
            impuesto = value
        End Set
    End Property

    Public Property _tipofactor() As String
        Get
            Return tipofactor
        End Get
        Set(value As String)
            tipofactor = value
        End Set
    End Property

    Public Property _tasacuota() As String
        Get
            Return tasacuota
        End Get
        Set(value As String)
            tasacuota = value
        End Set
    End Property

    Public Property _importe() As String
        Get
            Return importe
        End Get
        Set(value As String)
            importe = value
        End Set
    End Property
End Class
