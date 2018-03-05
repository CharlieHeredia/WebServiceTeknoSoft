Public Class Concepto
    Dim ClaveSAT As String = "" 'CLAVE DE SAT.'
    Dim ClaveINT As String = "" 'CLAVE INTERNA.'
    Dim NombreUnidad As String = "" 'NOMBRE DE UNIDAD.'
    Dim Unidades As String = "" 'UNIDADES.'
    Dim CodigoProducto As String = "" 'CODIGO DE PRODUCTO.'
    Dim NombreProducto As String = "" 'NOMBRE DE PRODUCTO.'
    Dim Precio As String = "" 'PRECIO.'
    Dim Neto As String = "" 'NETO.'
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
End Class
