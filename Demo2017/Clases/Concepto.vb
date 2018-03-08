Public Class Concepto
    'UN MOVIMIENTO EQUIVALE A UN PRODUCTO.'
    Dim ClaveSAT As String = "" 'CLAVE DE SAT/CLAVE UNIDAD'
    Dim ClaveINT As String = "" 'CLAVE DE COMERCIO EXTERIOR.'
    Dim NombreUnidad As String = "" 'NOMBRE DE UNIDAD.'
    Dim Unidades As String = "" 'CANTIDAD DE PRODUCTO'
    Dim CodigoProducto As String = "" 'CODIGO DE PRODUCTO.'
    Dim NombreProducto As String = "" 'NOMBRE DE PRODUCTO.'
    Dim Precio As String = "" 'PRECIO DEL PRODUCTO.'
    Dim Neto As String = "" 'IMPORTE NETO PARA EL MOVIMIENTO.'
    Dim Descripcion As String = "" 'DESCRIPCIÓN DEL PRODUCTO.'
    Dim IdProducto As String = "" 'ID DEL PRODUCTO EN LA BASE DE DATOS.'
    Public Property _ClaveSAT() As String
        Get
            Return ClaveSAT
        End Get
        Set(value As String)
            ClaveSAT = value
        End Set
    End Property
    Public Property _ClaveINT() As String
        Get
            Return ClaveINT
        End Get
        Set(value As String)
            ClaveINT = value
        End Set
    End Property
    Public Property _NombreUnidad() As String
        Get
            Return NombreUnidad
        End Get
        Set(value As String)
            NombreUnidad = value
        End Set
    End Property
    Public Property _Unidades() As String
        Get
            Return Unidades
        End Get
        Set(value As String)
            Unidades = value
        End Set
    End Property
    Public Property _CodigoProducto() As String
        Get
            Return CodigoProducto
        End Get
        Set(value As String)
            CodigoProducto = value
        End Set
    End Property
    Public Property _NombreProducto() As String
        Get
            Return NombreProducto
        End Get
        Set(value As String)
            NombreProducto = value
        End Set
    End Property
    Public Property _Precio() As String
        Get
            Return Precio
        End Get
        Set(value As String)
            Precio = value
        End Set
    End Property
    Public Property _Neto() As String
        Get
            Return Neto
        End Get
        Set(value As String)
            Neto = value
        End Set
    End Property
    Public Property _Descripcion() As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property
    Public Property _IdProducto()
        Get
            Return IdProducto
        End Get
        Set(value)
            IdProducto = value
        End Set
    End Property
End Class
