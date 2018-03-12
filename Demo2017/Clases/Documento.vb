Public Class Documento
    Dim idDocumento As String = "" 'Id del Documento'
    Dim aRazonSocial As String = "" 'Razon Social'
    Dim aFolio As String = "" 'Folio del documento.'
    Dim aNumMoneda As String = "" 'Moneda del documento.  1 = Pesos MN, 2 = Moneda extranjera.'
    Dim aTipoÇambio As String = "" 'Tipo de cambio del documento.'
    Dim aImporte As String = "" 'Importe del documento. Sólo se usa en documentos de cargo/abono.'
    Dim aDescuentoDoc1 As String = "" 'No tiene uso, valor por omisión = 0 (cero).'
    Dim aDescuentoDoc2 As String = "" 'No tiene uso, valor por omisión = 0 (cero).'
    Dim aSistemasOrigen As String = "" 'Valor mayor a 5 que indica una aplicación diferente a los PAQ's'
    Dim aCodConcepto As String = "" 'Código del concepto del documento. '
    Dim aSerie As String = "" 'Serie del documento.'
    Dim aFecha As String = "" 'Fecha del documento. Formato mm/dd/aaaa Las “/” diagonales son parte del formato.'
    Dim aCodigoCteProv As String = "" 'Código del Cliente/Proveedor.'
    Dim aCodigoAgente As String = "" 'Código del Agente.'
    Dim aReferencia As String = "" 'Referencia del Documento.'
    Dim aAfecta As String = "" 'No tiene uso, valor por omisión = 0 (cero).'
    Dim aGasto1 As String = "" 'Valor por omisión = 0 (cero).'
    Dim aGasto2 As String = "" 'Valor por omisión = 0 (cero).'
    Dim aGasto3 As String = "" 'Valor por omisión = 0 (cero).'
    Dim aImpuesto1 As String = "" 'IMPUESTO 1 (IVA).'
    Dim aImpuestoTotalTraslado As String = "" 'TOTAL DE IMPUESTOS (EN ESTA CASO UNICAMENTE LA SUMATORIO DEL IVA)
    Dim aClaveSATMoneda As String = "" 'CLAVE DEL SAT PARA MONEDA.'
    Dim aReceptorColonia As String = ""
    Dim aReceptorMunicipio As String = ""
    Dim aReceptorLocalidad As String = ""
    Dim aReceptorEstado As String = ""
    Dim aReceptorNumInterior As String = ""
    Dim aReceptorCodigoPostal As String = ""
    Dim aReceptorCalle As String = ""
    Dim aReceptorPais As String = ""
    Dim aNeto As String = "" 'Importe del total del neto para el documento. '
    Dim aTotal As String = "" 'Importe del total de los totales de los movimientos para el documento.'
    'Documento'
    Public Property _aIdDocumento() As String
        Get
            Return idDocumento
        End Get
        Set(value As String)
            idDocumento = value
        End Set
    End Property
    Public Property _aFolio() As String
        Get
            Return aFolio
        End Get
        Set(value As String)
            aFolio = value
        End Set
    End Property
    Public Property _aNumMoneda() As String
        Get
            Return aNumMoneda
        End Get
        Set(value As String)
            aNumMoneda = value
        End Set
    End Property
    Public Property _aTipoÇambio() As String
        Get
            Return aTipoÇambio
        End Get
        Set(value As String)
            aTipoÇambio = value
        End Set
    End Property
    Public Property _aImporte() As String
        Get
            Return aImporte
        End Get
        Set(value As String)
            aImporte = value
        End Set
    End Property
    Public Property _aDescuentoDoc1() As String
        Get
            Return aDescuentoDoc1
        End Get
        Set(value As String)
            aDescuentoDoc1 = value
        End Set
    End Property
    Public Property _aDescuentoDoc2() As String
        Get
            Return aDescuentoDoc2
        End Get
        Set(value As String)
            aDescuentoDoc2 = value
        End Set
    End Property
    Public Property _aSistemasOrigen() As String
        Get
            Return aSistemasOrigen
        End Get
        Set(value As String)
            aSistemasOrigen = value
        End Set
    End Property
    Public Property _aCodConcepto() As String
        Get
            Return aCodConcepto
        End Get
        Set(value As String)
            aCodConcepto = value
        End Set
    End Property
    Public Property _aSerie() As String
        Get
            Return aSerie
        End Get
        Set(value As String)
            aSerie = value
        End Set
    End Property
    Public Property _aFecha() As String
        Get
            Return aFecha
        End Get
        Set(value As String)
            aFecha = value
        End Set
    End Property
    Public Property _aCodigoCteProv() As String
        Get
            Return aCodigoCteProv
        End Get
        Set(value As String)
            aCodigoCteProv = value
        End Set
    End Property
    Public Property _aCodigoAgente() As String
        Get
            Return aCodigoAgente
        End Get
        Set(value As String)
            aCodigoAgente = value
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
    Public Property _aAfecta() As String
        Get
            Return aAfecta
        End Get
        Set(value As String)
            aAfecta = value
        End Set
    End Property
    Public Property _aGasto1() As String
        Get
            Return aGasto1
        End Get
        Set(value As String)
            aGasto1 = value
        End Set
    End Property
    Public Property _aGasto2() As String
        Get
            Return aGasto2
        End Get
        Set(value As String)
            aGasto2 = value
        End Set
    End Property
    Public Property _aGasto3() As String
        Get
            Return aGasto3
        End Get
        Set(value As String)
            aGasto3 = value
        End Set
    End Property
    Public Property _aRazonSocial() As String
        Get
            Return aRazonSocial
        End Get
        Set(value As String)
            aRazonSocial = value
        End Set
    End Property
    Public Property _aImpuesto1() As String
        Get
            Return aImpuesto1
        End Get
        Set(value As String)
            aImpuesto1 = value
        End Set
    End Property
    Public Property _aImpuestoTotalTraslado() As String
        Get
            Return aImpuestoTotalTraslado
        End Get
        Set(value As String)
            aImpuestoTotalTraslado = value
        End Set
    End Property
    Public Property _aClaveSATMoneda() As String
        Get
            Return aClaveSATMoneda
        End Get
        Set(value As String)
            aClaveSATMoneda = value
        End Set
    End Property
    Public Property _aReceptorColonia() As String
        Get
            Return aReceptorColonia
        End Get
        Set(value As String)
            aReceptorColonia = value
        End Set
    End Property
    Public Property _aReceptorMunicipio() As String
        Get
            Return aReceptorMunicipio
        End Get
        Set(value As String)
            aReceptorMunicipio = value
        End Set
    End Property
    Public Property _aReceptorLocalidad() As String
        Get
            Return aReceptorLocalidad
        End Get
        Set(value As String)
            aReceptorLocalidad = value
        End Set
    End Property
    Public Property _aReceptorEstado() As String
        Get
            Return aReceptorEstado
        End Get
        Set(value As String)
            aReceptorEstado = value
        End Set
    End Property
    Public Property _aReceptorNumInterior() As String
        Get
            Return aReceptorNumInterior
        End Get
        Set(value As String)
            aReceptorNumInterior = value
        End Set
    End Property
    Public Property _aReceptorCodigoPostal() As String
        Get
            Return aReceptorCodigoPostal
        End Get
        Set(value As String)
            aReceptorCodigoPostal = value
        End Set
    End Property
    Public Property _aReceptorCalle() As String
        Get
            Return aReceptorCalle
        End Get
        Set(value As String)
            aReceptorCalle = value
        End Set
    End Property
    Public Property _aReceptorPais() As String
        Get
            Return aReceptorPais
        End Get
        Set(value As String)
            aReceptorPais = value
        End Set
    End Property
    Public Property _aNeto() As String
        Get
            Return aNeto
        End Get
        Set(value As String)
            aNeto = value
        End Set
    End Property
    Public Property _aTotal() As String
        Get
            Return aTotal
        End Get
        Set(value As String)
            aTotal = value
        End Set
    End Property
End Class
