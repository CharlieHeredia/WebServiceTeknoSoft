Public Class Impuesto
    Dim total As String = ""
    Dim traslados As List(Of Traslado)

    'Datos Impuesto'

    Public Property _total() As String
        Get
            Return total
        End Get
        Set(value As String)
            total = value
        End Set
    End Property

    Public Property _traslados() As List(Of Traslado)
        Get
            Return traslados
        End Get
        Set(value As List(Of Traslado))
            traslados = value
        End Set
    End Property
End Class
