Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.IO
Public Class Conexion
    Public RutaEmpresa As String 'VARIABLE PARA ALMACENAR LA RUTA DE LA EMRPESA.'
    Public Conexiones As New OleDb.OleDbConnection() 'VARIABLE PARA REALIZAR LAS CONEXIONES TIPO DBF.'
    Public ConexionesSQL As New SqlConnection() 'VARIABLE PARA REALIZAR CONEXIONES TIPO SQL.'
    Public empresa As String 'VARIABLE PARA ALMACENAR EL NOMBRE DE LA EMPRESA.'

    Public Function Conectar() 'FUNCIÓN PARA ABRIR CONEXIÓN A LA BASE DE DATOS SQL Y DBF'
        CargarArchivoConfiguracionWebService() 'CARGAR LOS DATOS DEL ARCHIVO DE CONFIGURACIÓN.' 
        ' RutaEmpresa = rutaempresaq
        Select Case motorDB
            Case "1" 'CONEXIÓN DE TIPO SQL'
                ConexionesSQL = New SqlConnection() 'SE GENERA UNA NUEVA INSTANCIA.'
                ConexionesSQL.ConnectionString = "Data Source=" & hostname & ";Initial Catalog=" & BaseDatos & ";User Id=" & usuarioBD & ";Password=" & contra 'INFORMACIÓN DE LA CONEXIÓN.'
                ConexionesSQL.Open() 'SE ABRE LA CONEXIÓN SQL.'
            Case "2" 'CONEXIÓN DE TIPO BDF'
                Conexiones = New OleDb.OleDbConnection 'SE GENERA UNA NUEVA INSTANCIA.'
                Conexiones.ConnectionString = "Provider=VFPOLEDB.1;Data Source=" & RutaEmpresa.Trim & ";mode=share deny Read;BackGroudFetch=Yes" 'INFORMACIÓN DE LA CONEXIÓN.'
                Conexiones.Open() 'SE ABRE LA CONEXIÓN DBF.'
        End Select
        'MsgBox("Provider=sqloledb;Data Source=" & hostname & ";Initial Catalog=" & BasedDatos & ";User Id=" & usuarioBD & ";Password=" & contraseña)

    End Function
    Public Function CerrarConexion() 'FUNCIÓN PARA CERRRAR LA CONEXIÓN SQL Y DBF.'
        Select Case motorDB
            Case "1" 'CONEXIÓN TIPO SQL'
                ConexionesSQL.Close()
            Case "2" 'CONEXIÓN TIPO DBF'
                Conexiones.Close()
        End Select
    End Function
    Public Function ConsultarMovimiento(ByVal campos As String, ByVal tabla As String, ByVal condicion As String)

    End Function
    Public Function ConsultarDocumentoSQL(ByVal campos As String(), ByVal condicion As String, ByVal tabla As String, ByRef datos As Documento) As Boolean
        ConsultarDocumentoSQL = False
        Try
            Dim adaptador As New SqlDataAdapter 'ADAPTADOR PARA RECIBIR LA CONSULTA A LA BASE DE DATOS.'
            Dim ds As New DataSet 'DATASET UTILIZADO PARA PASAR LA INFORMACIÓN DEL ADAPTADOR A ESTÉ.'
            Dim camp As String = campos(0)
            Dim campo As String = campos(1)
            Dim campo2 As String = campos(2)
            Dim campo3 As String = campos(3)
            Dim campo4 As String = campos(4)
            Dim campo5 As String = campos(5)
            Dim campo6 As String = campos(6)
            Dim campo7 As String = campos(7)
            Dim campo8 As String = campos(8)
            Dim campo9 As String = campos(9)
            Dim campo10 As String = campos(10)
            Dim campo11 As String = campos(11)
            Dim campo12 As String = campos(12)
            Dim campo13 As String = campos(13)
            Dim campo14 As String = campos(14)
            Dim campo15 As String = campos(15)
            Dim campo16 As String = campos(16)
            Dim campo17 As String = campos(17)
            Dim campo18 As String = campos(18)
            '<------------- CONSULA A LA BASE DE DATOS SQL -------------------------------------------------->'
            Dim cmd As New SqlCommand(" select " & camp & "," & campo & "," & campo2 & "," & campo3 & "," & campo4 & "," & campo5 & "," & campo6 & "," & campo7 & "," & campo8 & "," & campo9 & "," & campo10 & "," & campo11 & "," & campo12 & "," & campo13 & "," & campo14 & "," & campo15 & "," & campo16 & "," & campo17 & "," & campo18 & " from " & tabla & " " & condicion, ConexionesSQL)
            adaptador.SelectCommand = cmd 'EJECUCION DEL COMANDO SQL.'
            '<---------------------- TERMINA CONSULTA SQL --------------------------------->'
            adaptador.Fill(ds)
            '<------- TRASPASO DE CONSULTA A OBJETO TIPO DOCUMENTO(datos) --------------->'
            For Each row As DataRow In ds.Tables(0).Rows
                datos._aIdDocumento = row(0) 'aIdDococumento'
                datos._aFolio = row(1) 'aFolio'
                datos._aNumMoneda = row(2) 'aNumMoneda'
                datos._aTipoÇambio = row(3) 'aTipoÇambio'
                datos._aImporte = row(4) 'aImporte'
                datos._aDescuentoDoc1 = row(5) 'aDescuentoDoc1'
                datos._aDescuentoDoc2 = row(6) 'aDescuentoDoc2'
                datos._aSistemasOrigen = row(7) 'aSistemasOrigen'
                datos._aCodConcepto = row(8) 'aCodConcepto'
                datos._aSerie = row(9) 'aSerie'
                datos._aAfecta = row(10) 'aFecha'
                datos._aCodigoCteProv = row(11) 'aCodigoCteProv'
                datos._aCodigoAgente = row(12) 'aCodigoAgente'
                datos._aReferencia = row(13) 'aReferencia'
                datos._aAfecta = row(14) 'aAfecta'
                datos._aGasto1 = row(15) 'aGasto1'
                datos._aGasto2 = row(16) 'aGasto2'
                datos._aGasto3 = row(17) 'aGasto3'
                datos._aRazonSocial = row(18) 'aRazonSocial'
            Next
            '<--------------- TERMINA TRASPASO DE DATOS ---------------------->'
            ConsultarDocumentoSQL = True
        Catch ex As Exception
            ConexionesSQL.Close() 'CIERRE DE LA CONEXIÓN.'
        End Try
    End Function
    Public Function GenerarArchivoXML(ByVal Folio As String, ByVal iddocu As String)
        Dim nombre As String = "C:\TeknoCom\" & Folio & ".xml"
        Dim w As StreamWriter = New StreamWriter(nombre, False, System.Text.Encoding.UTF8)
        Dim hora As Date = Format(Now, "HH:mm:ss")
        'hora = hora.AddSeconds(segundos)
        Dim fecha As String = Format(Date.Today, "yyyy-MM-dd") & "T" & hora.ToString("HH:mm:ss")
        Dim DatosReceptor As New Receptor 'SE UTILIZA PARA ALMACENAR DATOS DEL RECEPTOR.'
        Dim adaptador As New SqlDataAdapter 'ADAPTADOR PARA RECIBIR LA CONSULTA A LA BASE DE DATOS.'
        Dim ds As New DataSet 'DATASET UTILIZADO PARA PASAR LA INFORMACIÓN DEL ADAPTADOR A ESTÉ.'
        Dim Factura As New Documento 'SE UTILIZA PARA GUARDAR INFORMACIÓN GENEREAL DE LA FACTURA
        Factura._aIdDocumento = iddocu
        Factura._aFolio = Folio
        VerificacionExistenciaDirectorioPrincipal()
        fecha = fecha.Trim
        ' Dim monedaExtranjera As Boolean = False
        Dim TextoMoneda As String = ""
        Dim textoDescuento As String = ""
        Dim textoRelacion As String = ""
        
        '<-------------------------------------- INFORMACIÓN DEL RECEPTOR.'
        Dim cmd As New SqlCommand("SELECT admClientes.CRFC,admClientes.CRAZONSOCIAL,CUSOCFDI,admDocumentos.CIMPUESTO1,admDocumentos.CIDMONEDA from admDocumentos INNER JOIN admClientes on admClientes.CIDCLIENTEPROVEEDOR = admDocumentos.CIDCLIENTEPROVEEDOR INNER JOIN admMonedas on admMonedas.CIDMONEDA = admDocumentos.CIDMONEDA WHERE CFOLIO = " & Folio & " AND CIDDOCUMENTODE = 4", ConexionesSQL)
        adaptador.SelectCommand = cmd 'EJECUCION DEL COMANDO SQL.'
        '<---------------------- TERMINA CONSULTA SQL --------------------------------->'
        adaptador.Fill(ds)
        Dim renglon As String = ""
        For Each row As DataRow In ds.Tables(0).Rows
            renglon += row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "¬"
            DatosReceptor._RFC = row(0).ToString.Trim() 'RFC.'
            DatosReceptor._razonsocial = row(1).ToString.Trim() 'RAZON SOCIAL.'
            DatosReceptor._usocfdi = row(2).ToString.Trim() 'USOCFDI.'
            Factura._aImpuesto1 = row(3).ToString.Trim() 'IVA TOTAL DE LA FACTURA.'
            Factura._aMoneda = row(4).ToString.Trim() 'ID DE MONEDA DE LA FACTURA.'
        Next

        MsgBox("Texto recogido: " & renglon)
        '<---------------------------------------- INFORMACIÓN DEL EMISOR.'
        ' LA CONSULTA REALIZA UNA CONEXIÓN SQL DISTUNTA A LAS OTRAS CONSULTAS DEBIDO A QUE UTILIZA OTRA BASE DE DATOS.'
        Dim DatosEmisor As New Emisor
        Dim ConexionSQLTemporal As New SqlConnection()
        ds = New DataSet
        ConexionSQLTemporal.ConnectionString = "Data Source=" & hostname & ";Initial Catalog=CompacWAdmin ;User Id=" & usuarioBD & ";Password=" & contra 'INFORMACIÓN DE LA CONEXIÓN.'
        ConexionSQLTemporal.Open()
        Dim Direccion As String = "C:\Compac\Empresas\" & BaseDatos.Trim()
        'MsgBox("Direccion: " & Direccion)
        cmd = New SqlCommand("SELECT CIDEMPRESA from Empresas where CRUTADATOS ='" & Direccion.Trim() & "'", ConexionSQLTemporal)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        Dim IdEmpresa As String = ""
        For Each row As DataRow In ds.Tables(0).Rows
            IdEmpresa = row(0).ToString()
        Next
        MsgBox("ID EMPRESA: " & IdEmpresa)
        ConexionSQLTemporal.Close()
        ' TERMINA USO DE CONEXION SQL TEMPORAL.'
        ds = New DataSet
        cmd = New SqlCommand("SELECT CNOMBREEMPRESA,CRFCEMPRESA,CREGIMFISC,CIMPUESTO1,CIMPUESTO2,CIMPUESTO3,CNOMBREIMPUESTO1,CNOMBREIMPUESTO2,CNOMBREIMPUESTO3 from admParametros where CIDEMPRESA = " & IdEmpresa, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        For Each row As DataRow In ds.Tables(0).Rows
            renglon += row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "|" + row(3).ToString() + "|" + row(4).ToString() + "|" + row(5).ToString() + "|" + row(6).ToString() + "|" + row(7).ToString() + "|" + row(8).ToString() + "¬"
            DatosEmisor._NombreEmpresa = row(0).ToString.Trim() ' NOMBRE DE EMPRESA.'
            DatosEmisor._rfc = row(1).ToString.Trim() ' RFC DE EMPRESA.'
            DatosEmisor._regimenFiscal = row(2).ToString.Trim() ' REGIMEN FISCAL.'
            DatosEmisor._Impuesto1 = row(3).ToString.Trim() ' IMPUESTO 1.'
            DatosEmisor._Impuesto2 = row(4).ToString.Trim() ' IMPUESTO 2.'
            DatosEmisor._Impuesto3 = row(5).ToString.Trim() ' IMPUESTO 3.'
            DatosEmisor._NombreImpuesto1 = row(6).ToString.Trim() 'NOMBRE DE IMPUESTO 1.'
            DatosEmisor._NombreImpuesto2 = row(7).ToString.Trim() 'NOMBRE DE IMPUESTO 2.'
            DatosEmisor._NombreImpuesto3 = row(8).ToString.Trim() 'NOMBRE DE IMPUESTO 3.'
        Next
        MsgBox("Texto: " & renglon)
        '<--------------------------------------------------------- INFORMACIÓN DE CONCEPTO'
        ds = New DataSet
        cmd = New SqlCommand("SELECT admProductos.CCLAVESAT,CCLAVEINT,CNOMBREUNIDAD,CUNIDADES,CCODIGOPRODUCTO,CNOMBREPRODUCTO,CPRECIO,CNETO,admMovimientos.CIDPRODUCTO,admProductos.CDESCRIPCIONPRODUCTO,admMovimientos.CIMPUESTO1,admMovimientos.CPORCENTAJEIMPUESTO1 FROM admMovimientos INNER JOIN admProductos on admProductos.CIDPRODUCTO = admMovimientos.CIDPRODUCTO INNER JOIN admUnidadesMedidaPeso on admUnidadesMedidaPeso.CIDUNIDAD = admMovimientos.CIDUNIDAD WHERE CIDDOCUMENTO =" & iddocu, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        MsgBox("Count: " & ds.Tables(0).Rows.Count.ToString.Trim())
        Dim DatosConcepto(ds.Tables(0).Rows.Count - 1) As Concepto
        Dim i As Integer = 0
        For Each row As DataRow In ds.Tables(0).Rows
            renglon += row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "|" + row(3).ToString() + "|" + row(4).ToString() + "|" + row(5).ToString() + "|" + row(6).ToString() + "|" + row(7).ToString() + "¬"
            DatosConcepto(i) = New Concepto
            DatosConcepto(i)._ClaveSAT = row(0).ToString.Trim() 'CLAVE SAT./CLAVE UNIDAD'
            DatosConcepto(i)._ClaveINT = row(1).ToString.Trim() 'CLAVE DE COMERCIO EXTERNO.'
            DatosConcepto(i)._NombreUnidad = row(2).ToString.Trim() 'NOMBRE DE LA UNIDAD.'
            DatosConcepto(i)._Unidades = row(3).ToString.Trim() 'CANTIDAD DE PRODUCTO.'
            DatosConcepto(i)._CodigoProducto = row(4).ToString.Trim() 'CODIGO DE PRODUCTO.'
            DatosConcepto(i)._NombreProducto = row(5).ToString.Trim() 'NOMBRE DE PRODUCTO.'
            DatosConcepto(i)._Precio = row(6).ToString.Trim() 'PRECIO.'
            DatosConcepto(i)._Neto = row(7).ToString.Trim() 'NETO.'
            DatosConcepto(i)._IdProducto = row(8).ToString.Trim() 'ID DEL PRODUCTO.'
            If IsDBNull(row(9)) Then 'VALIDACIÓN DE VALOR NULO.'
                DatosConcepto(i)._Descripcion = ""
            Else
                DatosConcepto(i)._Descripcion = row(9).ToString.Trim() 'DESCRIPCIÓN DEL PRODUCTO.'
            End If
            DatosConcepto(i)._Impuesto = row(10).ToString.Trim() 'IMPUESTO (IVA) DEL MOVIMIENTO.'
            DatosConcepto(i)._PorcentajeImpuesto = row(11).ToString.Trim() 'PORCENTAJE DEL IMPUESTO.'
            i += 1 'AUMENTO DE CONTADOR.'
        Next
        MsgBox("Texto: " & renglon)
        '<------------------------------------------------------------- INFORMACIÓN DE COMPROBANTE'
        Dim DatosComprobante As New Comprobante
        ds = New DataSet
        cmd = New SqlCommand("SELECT CSERIEDOCUMENTO,CFOLIO,admDocumentos.CTIMESTAMP,CMETODOPAG,CLUGAREXPE,admMonedas.CCLAVESAT,admDocumentos.CNATURALEZA from admDocumentos INNER JOIN admMonedas on admMonedas.CIDMONEDA = admDocumentos.CIDMONEDA Where CIDDOCUMENTO=" & iddocu, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        For Each row As DataRow In ds.Tables(0).Rows
            DatosComprobante._serie = row(0).ToString.Trim() 'SERIE'
            DatosComprobante._folio = row(1).ToString.Trim() 'FOLIO'
            DatosComprobante._fecha = row(2).ToString.Trim() 'FECHA'
            DatosComprobante._metodoDePago = row(3).ToString.Trim() 'MÉTODO DE PAGO'
            DatosComprobante._lugarExpedicion = row(4).ToString.Trim() 'LUGAR DE EXPEDICIÓN.'
            DatosComprobante._ClaveSATMoneda = row(5).ToString.Trim() 'CLAVE SAT MONEDA'
            DatosComprobante._tipoDeComprobante = row(6).ToString.Trim() 'NATURALEZA'
        Next
        '**Aclaración
        '*CLUGAREXPE contiene toda la dirección del cliente, dentro de esa misma tabla no se encuentra un identificador para hacer la referencia a la tabla de admDomicilios,
        'por lo tanto, se recomienda realizar un substring del dato.
        '*VERSION se deja en 3.3.
        '*SUBTOTAL se obtiene de la suma de todos los totales sin incluir el impuesto.
        '*TOTAL es la sumatoria del subtotal con el total de todos los impuestos.
        '*FORMA DE PAGO Y TIPO DE COMPROBANTE no se encuentran dentro de las tablas de SQL.

        '------------------- TERMINA CONSULTA DE DATOS PARA LLENAR EL ARCHIVO XML.'
        Dim todotexto As String = ""
        If DatosComprobante._tipoDeComprobante = "0" Then 'INGRESO/CARGO'
            DatosComprobante._tipoDeComprobante = "I"
        ElseIf DatosComprobante._tipoDeComprobante = "1" Then 'EGRESO/ABONO'
            DatosComprobante._tipoDeComprobante = "E"
        End If
        ' 222222 FALTA OBTENER EL VALOR DE LA CONSULTA 2222222 <---------------------------------------------//////
        If DatosComprobante._formaDePago.ToUpper = "PAGO EN UNA SOLA EXHIBICIÓN" Then
            DatosComprobante._formaDePago = "PUE"
        ElseIf DatosComprobante._formaDePago.Trim.ToUpper = "PAGO EN PARCIALIDADES O DIFERIDO" Then
            DatosComprobante._formaDePago = "PPD"
        End If
        If DatosEmisor._regimenFiscal = "REGIMEN GENERAL DE LEY PERSONAS MORALES" Then ' esta parte puede ponerse configurable
            DatosEmisor._regimenFiscal = "601"
        End If
        'facturaxml._receptorUsoCfdi = "P01"
        If DatosComprobante._metodoDePago.ToUpper = "NO APLICA" Then 'Por definir, cuando es por definir, siempre requerira comprobante de pagos
            DatosComprobante._metodoDePago = "99"
        End If
        If DatosComprobante._metodoDePago = "99" Then
            DatosComprobante._formaDePago = "PPD"
            ' Else   ----------' comentado para que tome la forma de pago PPD cuando el cliente asi lo requiera
            '    facturaxml._formaDePago = "PUE"
        End If
        If DatosComprobante._formaDePago = "" Then
            DatosComprobante._formaDePago = "PPD"
        End If
        'facturaxml._errores += errores
        '--------conexion a tabla nueva donde se encontrara la forma de pago del cliente para que no lleve 99 por definir
        ' Dim dtdatoscliente As New DataTable
        ' conexiones.conectar(ArchivoAccess, 2)
        'conexiones.consultarTabla("FormaPago,metododPago,usocfdi", "tablaaccessnueva", " where cliente = " & facturaxml._nocliente , dtdatoscliente)
        'dim rowf as datarow = dtdatoscliente.rows(0)
        'facturaxml._metodoDePago= rowf("FormaPago")
        'facturaxml._metodoDePago= rowf("metododPago")
        'facturaxml._metodoDePago= rowf("usocfdi")
        ''aqui una prueba para no estar repitiendo mucho codigo---- ya quedo la prueba
        Dim numreg As String = ""
        If DatosReceptor._RFC = "XEXX010101000" Then 'FACTURACIÓN EXTRANJERO'

        Else
            'facturaxml._ComercioExterior = False
        End If
        'If facturaxml._ComercioExterior Then
        '    todotexto = "<?xml version=""1.0"" encoding=""UTF-8""?>" & vbCrLf & "<cfdi:Comprobante xmlns:cfdi=""http://www.sat.gob.mx/cfd/3"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:cce11=""http://www.sat.gob.mx/ComercioExterior11""" _
        '                  & " xsi:schemaLocation=""http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/ComercioExterior11 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior11/ComercioExterior11.xsd"" " & vbCrLf & "Version=""3.3""" _
        '                  & " Serie=""" & facturaxml._serie & """ Folio=""" & facturaxml._folio & """ Fecha=""" & fecha & """" & vbCrLf & " FormaPago=""" & facturaxml._metodoDePago & """" & vbCrLf _
        '                  & " SubTotal=""" & facturaxml._subTotal.Replace(",", "") & TextoMoneda & textoDescuento & """ Total=""" & facturaxml._total33.Replace(",", "") & """ TipoDeComprobante=""" & facturaxml._tipoDeComprobante & """" _
        '                  & " MetodoPago=""" & facturaxml._formaDePago & """ LugarExpedicion=""" & facturaxml._emisorDomfiscalCP & TextoLimiteTotal _
        '                  & textoRelacion & vbCrLf & "<cfdi:Emisor Rfc=""" & facturaxml._EmisorRFC & """ Nombre=""" & facturaxml._EmisorNombre & """ RegimenFiscal=""" & facturaxml._RegimenFiscal & """></cfdi:Emisor>" _
        '                  & vbCrLf & "<cfdi:Receptor Rfc=""" & facturaxml._receptorRFC & """ Nombre=""" & facturaxml._receptorNombre & """ UsoCFDI=""" & facturaxml._receptorUsoCfdi & """ ResidenciaFiscal=""" & facturaxml._ResidenciaFiscal & """ NumRegIdTrib=""" & facturaxml._NumRegIDTrib & """></cfdi:Receptor>" _
        '                  & vbCrLf & "<cfdi:Conceptos>" & vbCrLf
        'Else

        '    todotexto = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf & "<cfdi:comprobante xmlns:cfdi=""http://www.sat.gob.mx/cfd/3"" xmlns:xsi=""http://www.w3.org/2001/xmlschema-instance""" _
        '                   & " xsi:schemalocation=""http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd"" " & vbCrLf & "version=""3.3""" _
        '                   & " serie=""" & facturaxml._serie & """ folio=""" & facturaxml._folio & """ fecha=""" & fecha & """" & vbCrLf & " formapago=""" & facturaxml._metododepago & """" & vbCrLf _
        '                   & " subtotal=""" & facturaxml._subtotal.replace(",", "") & textomoneda & textodescuento & """ total=""" & facturaxml._total33.replace(",", "") & """ tipodecomprobante=""" & facturaxml._tipodecomprobante & """" _
        '                   & " metodopago=""" & facturaxml._formadepago & """ lugarexpedicion=""" & facturaxml._emisordomfiscalcp & textolimitetotal _
        '                   & textorelacion & vbCrLf & "<cfdi:emisor rfc=""" & facturaxml._emisorrfc & """ nombre=""" & facturaxml._emisornombre & """ regimenfiscal=""" & facturaxml._regimenfiscal & """/>" _
        '                   & vbCrLf & "<cfdi:receptor rfc=""" & facturaxml._receptorrfc & """ nombre=""" & facturaxml._receptornombre & """ usocfdi=""" & facturaxml._receptorusocfdi & """/>" _
        '                   & vbCrLf & "<cfdi:conceptos>" & vbCrLf
        'End If

        If Factura._amoneda <> "1" Then
            TextoMoneda = """ TipoCambio=""" & facturaxml._TipoCambio & """ Moneda=""" & facturaxml._Moneda
        Else
            TextoMoneda = """ Moneda=""" & facturaxml._Moneda
        End If

        'If tieneDescuento Then  ' esta parte aun no se añade al xml 28/06/2017 11:41 am
        '    textoDescuento = """ descuento=""" & facturaxml._Descuento
        '    If facturaxml._motivoDescuento <> "" Then
        '        textoDescuento += """ motivoDescuento=""" & facturaxml._motivoDescuento
        '    End If
        '    'textoDescuento2 = """"
        'End If
        Dim cantidadTotalIva As Double = 0
        Dim TotalImpuestoTrasAsis As Double = 0.0
        For Each producto As Concepto In DatosConcepto
            'If producto._unidad.ToUpper = "PIEZAS" Or producto._unidad.ToUpper = "PIEZA" Then
            'producto._claveunidad = "H87"
            ' End If
            '------------------------ Se pone clave de producto para hacer pruebas
            Dim cadena As String = "<cfdi:Concepto ClaveProdServ= """ & producto._CodigoProducto & """ NoIdentificacion=""" & producto._ClaveSAT & """ Cantidad=""" & producto._Unidades & """ ClaveUnidad=""" _
                        & producto._ClaveSAT & """ Unidad=""" & producto._NombreUnidad & """ Descripcion=""" & producto._Descripcion & """ ValorUnitario=""" & producto._Precio.Replace(",", "") & """ Importe=""" & producto._Neto.Replace(",", "")
            'VALIDACIÓN SIGUIENTE AÚN NO ESTA EN FUNCIONAMIENTO.'
            'If tieneDescuento Then   
            'cadena += """ Descuento=""" & producto._descuento
            'End If
            cadena += """>"
            'aqui se puede hace una condicion si maneja impuestos o no y si es mas de un impuesto, ahora solo se toma en cuenta el IVA
            ' Dim CantidadIva As String = (Convert.ToDecimal(Math.Round((CDbl(producto._importe)) * 0.16, 2))).ToString("N")
            'cantidadTotalIva += CDbl(CantidadIva)
            'MsgBox(facturaxml._porcentajeIVA & " " & producto._iva)

            'IMPORTE          =     CANTIDAD       * PRECIO UNITARIO.
            producto._Importe = producto._Unidades * producto._Precio
            If CDbl(producto._PorcentajeImpuesto) <> 0.0 And CDbl(producto._Impuesto) <> 0.0 Then
                cadena += vbCrLf & "<cfdi:Impuestos>" & vbCrLf & "<cfdi:Traslados>" & vbCrLf & "<cfdi:Traslado Base=""" & producto._Importe.Replace(",", "") & """ Impuesto=""002"" TipoFactor=""Tasa"" TasaOCuota=""0.160000"" Importe=""" & producto._Impuesto.Replace(",", "") & """/>" _
                            & vbCrLf & "</cfdi:Traslados>" & vbCrLf & "</cfdi:Impuestos>"
            ElseIf CDbl(producto._PorcentajeImpuesto) = 0 Or CDbl(producto._Impuesto) = 0 Then
                cadena += vbCrLf & "<cfdi:Impuestos>" & vbCrLf & "<cfdi:Traslados>" & vbCrLf & "<cfdi:Traslado Base=""" & producto._Importe.Replace(",", "") & """ Impuesto=""002"" TipoFactor=""Exento""/>" _
                         & vbCrLf & "</cfdi:Traslados>" & vbCrLf & "</cfdi:Impuestos>"
            End If
            'numero de pedimento
            'If producto._numero <> "" And facturaxml._receptorRFC.ToUpper <> "XEXX010101000" Then
            '    Dim numeroPedimento As String = ""
            '    ' MsgBox(numeroPedimento)

            '    ' numero de pedimento cierra

            '    cadena += vbCrLf & "<cfdi:InformacionAduanera NumeroPedimento=""" & producto._numero & """/>"
            'End If
            cadena += vbCrLf & "</cfdi:Concepto>"
            todotexto += cadena & vbCrLf
            TotalImpuestoTrasAsis += CDbl(producto._Impuesto)
        Next
        Factura._aImpuestoTotalTraslado = TotalImpuestoTrasAsis.ToString.Trim()
        'MsgBox(cantidadTotalIva)
        'aqui totalimpuestos = al importe de iva
        todotexto += "</cfdi:Conceptos>"
        If Factura._aImpuesto1 <> "0" Then
            todotexto += vbCrLf & "<cfdi:Impuestos TotalImpuestosTrasladados=""" & Factura._aImpuestoTotalTraslado.Replace(",", "") & """>" _
                    & vbCrLf & "<cfdi:Traslados>" & vbCrLf & "<cfdi:Traslado Impuesto=""002"" TipoFactor=""Tasa"" TasaOCuota=""0.160000"" Importe=""" & Factura._aImpuestoTotalTraslado.Replace(",", "") & """/></cfdi:Traslados></cfdi:Impuestos>"
        ElseIf Factura._aImpuesto1 = "0" Then
            '  todotexto += vbCrLf & "<cfdi:Impuestos TotalImpuestosTrasladados=""" & "0.00" & """>" _
            ' & vbCrLf & "<cfdi:Traslados>" & vbCrLf & "<cfdi:Traslado Impuesto=""002"" TipoFactor=""Tasa"" TasaOCuota=""0.000000"" Importe=""" & "0.00" & """/></cfdi:Traslados></cfdi:Impuestos>"

        End If
        'If facturaxml._ComercioExterior Then
        '    todotexto += vbCrLf & "<cfdi:Complemento>" & vbCrLf & "<cce11:ComercioExterior Version=""1.1"" TipoOperacion=""2"" ClaveDePedimento=""A1"" CertificadoOrigen=""0"" Incoterm=""" _
        '            & facturaxml._intercom & """ Subdivision=""0"" TipoCambioUSD=""" & facturaxml._tipoCambioUSD & """ TotalUSD=""" & facturaxml._totalUSD & """>" _
        '           & vbCrLf & "<cce11:Emisor >" & vbCrLf _
        '            & "<cce11:Domicilio Calle=""" & facturaxml._EmisorDomFiscalCalle & """ NumeroExterior=""" & facturaxml._emisorDomFiscalnoExt & """ Colonia=""" _
        '            & "1746" & """ Estado=""MOR"" Pais=""MEX"" CodigoPostal=""62760""/>" & vbCrLf _
        '            & "</cce11:Emisor>" & vbCrLf _
        '            & "<cce11:Receptor>" & vbCrLf _
        '            & "<cce11:Domicilio Calle=""" & facturaxml._receptorDomCalle & """ NumeroExterior=""" & facturaxml._receptorDomNoInt _
        '            & """ Colonia=""" & facturaxml._receptorDomColonia & """ Estado="""" Pais="""" CodigoPostal=""" & facturaxml._receptorDomCP & """/>" _
        '            & vbCrLf & "</cce11:Receptor>" & vbCrLf _
        '            & "<cce11:Mercancias>"
        '    For Each producto As Productos_Factura In listaProductos
        '        If producto._descripcion = "SERVICIOS DE ASESORIA FINANCIERA" Then
        '            todotexto += vbCrLf & "<cce11:Mercancia NoIdentificacion=""" & producto._noIdentificacion & "" _
        '                & """ CantidadAduana=""1.00"" UnidadAduana=""99"" ValorUnitarioAduana=""" _
        '                & "0.00" & """ ValorDolares=""0.00"">" & vbCrLf & "</cce11:Mercancia>"
        '        Else

        '            todotexto += vbCrLf & "<cce11:Mercancia NoIdentificacion=""" & producto._noIdentificacion & """ FraccionArancelaria=""" & producto._FraccionArancelaria _
        '                & """ CantidadAduana=""" & producto._CantidadAudana & """ UnidadAduana=""" & producto._UnidadAduana & """ ValorUnitarioAduana=""" _
        '                & producto._ValorUnitarioAduana & """ ValorDolares=""" & producto._ValorDolares & """>" & vbCrLf & "</cce11:Mercancia>"
        '        End If

        '    Next
        '    todotexto += vbCrLf & "</cce11:Mercancias>" & vbCrLf & "</cce11:ComercioExterior>" & vbCrLf & "</cfdi:Complemento>"
        'End If
        todotexto += "</cfdi:Comprobante>"
        w.WriteLine(todotexto)
        w.Close()
    End Function
    Public Function PrubaGeneradorXML()
        
    
        
        
        
        
        
        

        
        
        


    End Function
    Public Function ConsultarDocumento(ByVal campos As String(), ByVal condicion As String, ByVal tabla As String, ByRef datos As Documento) As Boolean
        ConsultarDocumento = False
        Try
            Dim adaptador As OleDb.OleDbDataAdapter 'ADAPTADOR PARA RECIBIR LA CONSULTA REALIZADA A LA BASE DE DATOS DBF.'
            Dim table As New DataTable 'TABLA UTILIZADA PARA PASAR LA INFORMACIÓN DEL ADAPTADOR A ESTA TABLA.'
            Dim campo As String = campos(0)
            Dim campo2 As String = campos(1)
            Dim campo3 As String = campos(2)
            Dim campo4 As String = campos(3)
            Dim campo5 As String = campos(4)
            Dim campo6 As String = campos(5)
            Dim campo7 As String = campos(6)
            Dim campo8 As String = campos(7)
            Dim campo9 As String = campos(8)
            Dim campo10 As String = campos(9)
            Dim campo11 As String = campos(10)
            Dim campo12 As String = campos(11)
            Dim campo13 As String = campos(12)
            Dim campo14 As String = campos(13)
            Dim campo15 As String = campos(14)
            Dim campo16 As String = campos(15)
            Dim campo17 As String = campos(16)
            'CONSULTA A LA BASE DE DATOS DBF.'
            adaptador = New OleDbDataAdapter(" select " & campo & "," & campo2 & "," & campo3 & "," & campo4 & "," & campo5 & "," & campo6 & "," & campo7 & "," & campo8 & "," & campo9 & "," & campo10 & "," & campo11 & "," & campo12 & "," & campo13 & "," & campo14 & "," & campo15 & "," & campo16 & "," & campo17 & " from " & tabla & " " & condicion, Conexiones)
            adaptador.Fill(table) 'TRASPASO DE DATOS DEL ADAPTADOR A LA TABLA.'
            '/// FALTA PASAR LOS DATOS DE LA TABLA AL OBJETO DOCUMENTO. ///////////    11/01/2017'
            ConsultarDocumento = True
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR DE FORMA VENTANA DE WINDOWS.'
            Conexiones.Close() 'CIERRE DE CONEXIÓN.'
        End Try

    End Function

    Public Function InsertarConfiguracionSocket(DireccionEmpresa As String, aRutaXML As String, aCodConcepto As String, aUUID As String, aRutaDDA As String, aPass As String, aRutaFormato As String)
        'FUNCIÓN QUE GUARDA DATOS EN LA BASE DE DATOS PARA LA CREACIÓN DEL ARCHIVO XML.
        'LA FUNCIÓN CREA LA BASE DE DATOS Y LA TABLA EN CASO DE NO EXISTIR.
        'LOS DATOS SE GUARDAN EN SQL, LA BASE Y LA TABLA SON ESTATICAS HASTA EL MOMENTO 30/01/2018
        Try
            Dim NombreBaseDatos As String = "Tacos" 'NOMBRE DE LA BASE DE DATOS.'
            Dim NombreTabla As String = "taquitos" 'NOMBRE DE TABLA EN LA BASE DE DATOS.'
            Dim ConexionSQLTemporal As New SqlConnection() 'CONEXION SQL PARA REALIZAR LAS OPERACIONES NECESARIAS.'
            Dim cmdTemporal As SqlCommand 'VARIABLE PARA EJECUTAR COMANDOS SQL.'
            ConexionSQLTemporal.ConnectionString = "Data Source=" & hostname & ";User Id=" & usuarioBD & ";Password=" & contra 'INFORMACIÓN DE LA CONEXIÓN.'
            'ConexionSQLTemporal.Open() 'SE ABRE LA CONEXIÓN SQL.'
            '<----------- VERIFICACIÓN DE EXISTENCIA DE BASE DE DATOS ------------------------------------------------------->'
            Try 'SE UTILIZA PARA CREAR LA BASE DE DATOS, EN CASO DE EXISTIR LA BASE MANDARA UNA EXCEPCIÓN.'
                cmdTemporal = New SqlCommand("CREATE DATABASE " & NombreBaseDatos, ConexionSQLTemporal) 'COMANDO SQL.'
                ConexionSQLTemporal.Open() 'SE ABRE LA CONEXIÓN SQL.'
                cmdTemporal.ExecuteNonQuery()
            Catch ex As Exception
                'ENTRA EN ESTA EXCEPCIÓN EN CASO DE QUE LA BASE DE DATOS EXISTA.'
            Finally
                ConexionSQLTemporal.Close() 'CIERRE DE LA CONEXIÓN SQL.'
            End Try
            '<-------------- VERIFICACIÓN DE EXISTENCIA DE TABLA -------------------------------------------------->'
            Try
                ConexionSQLTemporal.ConnectionString = "Data Source=" & hostname & ";Initial Catalog= " & NombreBaseDatos & ";User Id=" & usuarioBD & ";Password=" & contra 'INFORMACIÓN DE LA CONEXIÓN.'
                cmdTemporal = New SqlCommand("CREATE TABLE " & NombreTabla & "(DireccionEmpresa VARCHAR(255), aRutaXML VARCHAR(255), aCodConcepto VARCHAR(50), aUUID VARCHAR(255), aRutaDDA VARCHAR(255), aPass VARCHAR(255), aRutaFormato VARCHAR(255))", ConexionSQLTemporal)
                ConexionSQLTemporal.Open()
                cmdTemporal.ExecuteNonQuery()
                cmdTemporal = New SqlCommand("INSERT INTO " & NombreTabla & " VALUES ('" & DireccionEmpresa & "','" & aRutaXML & "','" & aCodConcepto & "','" & aUUID & "','" & aRutaDDA & "','" & aPass & "','" & aRutaFormato & "')", ConexionSQLTemporal)
                cmdTemporal.ExecuteNonQuery()
            Catch ex As Exception
                'ENTRA AQUI CUANDO LA TABLA YA EXISTE.'
                'BORRAR LA CONFIGURACIÓN GUARDADA PREVIAMENTE.'
                cmdTemporal = New SqlCommand("DELETE FROM " & NombreTabla, ConexionSQLTemporal) 'BORRADO DE DATOS.'
                cmdTemporal.ExecuteNonQuery()
                cmdTemporal = New SqlCommand("INSERT INTO " & NombreTabla & " VALUES ('" & DireccionEmpresa & "','" & aRutaXML & "','" & aCodConcepto & "','" & aUUID & "','" & aRutaDDA & "','" & aPass & "','" & aRutaFormato & "')", ConexionSQLTemporal)
                cmdTemporal.ExecuteNonQuery()
            Finally
                ConexionSQLTemporal.Close() 'CIERRE DE LA CONEXIÓN SQL.'
            End Try

        Catch ex As Exception
            MsgBox("Problema: " & ex.Message)
        End Try
    End Function
End Class
