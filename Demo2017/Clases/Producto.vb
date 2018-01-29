Public Class Producto
    Dim cantidad As String = ""
    Dim unidad As String = ""
    Dim num_identificacion As String = ""
    Dim valorUnitario As String = ""
    Dim importe As String = ""
    Dim claveProductoSer As String = ""
    Dim claveunidad As String = ""
    Dim aduana As Aduana
    Dim impuesto As Impuesto
    Dim descripcion As String = ""

    'Datos Producto'

    Public Property _cantidad() As String
        Get
            Return cantidad
        End Get
        Set(value As String)
            cantidad = value
        End Set
    End Property

    Public Property _unidad() As String
        Get
            Return unidad
        End Get
        Set(value As String)
            unidad = value
        End Set
    End Property

    Public Property _num_identificacion() As String
        Get
            Return num_identificacion
        End Get
        Set(value As String)
            num_identificacion = value
        End Set
    End Property

    Public Property _valorUnitario() As String
        Get
            Return valorUnitario
        End Get
        Set(value As String)
            valorUnitario = value
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

    Public Property _claveProductoSer() As String
        Get
            Return claveProductoSer
        End Get
        Set(value As String)
            claveProductoSer = value
        End Set
    End Property

    Public Property _claveunidad() As String
        Get
            Return claveunidad
        End Get
        Set(value As String)
            claveunidad = value
        End Set
    End Property

    Public Property _aduana() As Aduana
        Get
            Return aduana
        End Get
        Set(value As Aduana)
            aduana = value
        End Set
    End Property

    Public Property _impuesto() As Impuesto
        Get
            Return impuesto
        End Get
        Set(value As Impuesto)
            impuesto = value
        End Set
    End Property

    Public Property _descripcion As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property
End Class
