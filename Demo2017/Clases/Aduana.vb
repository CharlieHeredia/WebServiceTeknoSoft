Public Class Aduana
    Dim numeroPedimento As String = ""

    'Datos Aduana'

    Public Property _numeroPedimento() As String
        Get
            Return numeroPedimento
        End Get
        Set(value As String)
            numeroPedimento = value
        End Set
    End Property

End Class
