Public Class Movimiento
    Dim aUnidades As String = "" 'Unidades del movimiento.'
    Dim aPrecio As String = "" 'Precio del movimiento (para doctos. de venta ).'
    Dim aCoste As String = "" 'Costo del movimiento (para doctos. de compra).'
    Dim aCodProdSer As String = "" 'Códogo del producto o servicio. '
    Dim aCodAlmacen As String = "" 'Código del Almacén'
    Dim aReferencia As String = "" 'Referencia del movimiento.'
    Dim aCodClasificacion As String = "" 'Código de la clasificación.'

    Dim NombreProducto As String
    Dim CosteProducto As String
    Dim CantidadPiezazProducto As String
    Dim CodigoProducto As String
    Dim UnidadesProducto As String
    Dim CodigoCliente As String

    Public Property _NombreProducto() As String
        Get
            Return NombreProducto
        End Get
        Set(value As String)
            NombreProducto = value
        End Set
    End Property
    Public Property _aUnidades() As String
        Get
            Return aUnidades
        End Get
        Set(value As String)
            aUnidades = value
        End Set
    End Property
    Public Property _aPrecio() As String
        Get
            Return aPrecio
        End Get
        Set(value As String)
            aPrecio = value
        End Set
    End Property
    Public Property _aCoste() As String
        Get
            Return aCoste
        End Get
        Set(value As String)
            aCoste = value
        End Set
    End Property
    Public Property _aCodProdSer() As String
        Get
            Return aCodProdSer
        End Get
        Set(value As String)
            aCodProdSer = value
        End Set
    End Property
    Public Property _aCodAlmacen() As String
        Get
            Return aCodAlmacen
        End Get
        Set(value As String)
            aCodAlmacen = value
        End Set
    End Property
    Public Property _aReferencia() As String
        Get
            Return aReferencia
        End Get
        Set(value As String)
            aReferencia = value
        End Set
    End Property
    Public Property _aCodClasificacion() As String
        Get
            Return aCodClasificacion
        End Get
        Set(value As String)
            aCodClasificacion = value
        End Set
    End Property
End Class
