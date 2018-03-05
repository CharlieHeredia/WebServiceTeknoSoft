﻿Imports System.Data.SqlClient
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
        Dim DatosReceptor As New Receptor
        Dim adaptador As New SqlDataAdapter 'ADAPTADOR PARA RECIBIR LA CONSULTA A LA BASE DE DATOS.'
        Dim ds As New DataSet 'DATASET UTILIZADO PARA PASAR LA INFORMACIÓN DEL ADAPTADOR A ESTÉ.'
        VerificacionExistenciaDirectorioPrincipal()
        '<-------------------------------------- INFORMACIÓN DEL RECEPTOR.'
        Dim cmd As New SqlCommand("SELECT admClientes.CRFC,admClientes.CRAZONSOCIAL,CUSOCFDI from admDocumentos INNER JOIN admClientes on admClientes.CIDCLIENTEPROVEEDOR = admDocumentos.CIDCLIENTEPROVEEDOR WHERE CFOLIO = " & Folio & " AND CIDDOCUMENTODE = 4", ConexionesSQL)
        adaptador.SelectCommand = cmd 'EJECUCION DEL COMANDO SQL.'
        '<---------------------- TERMINA CONSULTA SQL --------------------------------->'
        adaptador.Fill(ds)
        Dim renglon As String = ""
        For Each row As DataRow In ds.Tables(0).Rows
            renglon = row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "¬"
            DatosReceptor._RFC = row(0).ToString.Trim() 'RFC.'
            DatosReceptor._razonsocial = row(1).ToString.Trim() 'RAZON SOCIAL.'
            DatosReceptor._usocfdi = row(2).ToString.Trim() 'USOCFDI.'
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
        MsgBox("Texto: " & IdEmpresa)
        ConexionSQLTemporal.Close()
        ' TERMINA USO DE CONEXION SQL TEMPORAL.'
        ds = New DataSet
        cmd = New SqlCommand("SELECT CNOMBREEMPRESA,CRFCEMPRESA,CREGIMFISC,CIMPUESTO1,CIMPUESTO2,CIMPUESTO3,CNOMBREIMPUESTO1,CNOMBREIMPUESTO2,CNOMBREIMPUESTO3 from admParametros where CIDEMPRESA = " & IdEmpresa, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        For Each row As DataRow In ds.Tables(0).Rows
            renglon = row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "|" + row(3).ToString() + "|" + row(4).ToString() + "|" + row(5).ToString() + "|" + row(6).ToString() + "|" + row(7).ToString() + "|" + row(8).ToString() + "¬"
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
        cmd = New SqlCommand("SELECT admProductos.CCLAVESAT,CCLAVEINT,CNOMBREUNIDAD,CUNIDADES,CCODIGOPRODUCTO,CNOMBREPRODUCTO,CPRECIO,CNETO FROM admMovimientos INNER JOIN admProductos on admProductos.CIDPRODUCTO = admMovimientos.CIDPRODUCTO INNER JOIN admUnidadesMedidaPeso on admUnidadesMedidaPeso.CIDUNIDAD = admMovimientos.CIDUNIDAD WHERE CIDDOCUMENTO =" & iddocu, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        Dim DatosConcepto(ds.Tables(0).Rows.Count) As Concepto
        Dim i As Integer = 0
        For Each row As DataRow In ds.Tables(0).Rows
            renglon = row(0).ToString() + "|" + row(1).ToString() + "|" + row(2).ToString() + "|" + row(3).ToString() + "|" + row(4).ToString() + "|" + row(5).ToString() + "|" + row(6).ToString() + "|" + row(7).ToString() + "¬"
            DatosConcepto(i)._ClaveSAT = row(0).ToString.Trim() 'CLAVE SAT.'
            DatosConcepto(i)._ClaveINT = row(1).ToString.Trim() 'CLAVE INT.'
            DatosConcepto(i)._NombreUnidad = row(2).ToString.Trim() 'NOMBRE DE UNIDAD.'
            DatosConcepto(i)._Unidades = row(3).ToString.Trim() 'UNIDADES.'
            DatosConcepto(i)._CodigoProducto = row(4).ToString.Trim() 'CODIGO DE PRODUCTO.'
            DatosConcepto(i)._NombreProducto = row(5).ToString.Trim() 'NOMBRE DE PRODUCTO.'
            DatosConcepto(i)._Precio = row(6).ToString.Trim() 'PRECIO.'
            DatosConcepto(i)._Neto = row(7).ToString.Trim() 'NETO.'
            i += 1 'AUMENTO DE CONTADOR.'
        Next
        MsgBox("Texto: " & renglon)
        '<------------------------------------------------------------- INFORMACIÓN DE COMPROBANTE'
        Dim DatosComprobante As New Comprobante
        ds = New DataSet
        cmd = New SqlCommand("SELECT CSERIEDOCUMENTO,CFOLIO,admDocumentos.CTIMESTAMP,CMETODOPAG,CLUGAREXPE,admMonedas.CCLAVESAT from admDocumentos INNER JOIN admMonedas on admMonedas.CIDMONEDA = admDocumentos.CIDMONEDA Where CIDDOCUMENTO=;" & iddocu, ConexionesSQL)
        adaptador.SelectCommand = cmd
        adaptador.Fill(ds)
        renglon = ""
        For Each row As DataRow In ds.Tables(0).Rows
            DatosComprobante._serie = row(0).ToString.Trim()
            DatosComprobante._folio = row(1).ToString.Trim()
            DatosComprobante._fecha = row(2).ToString.Trim()
            DatosComprobante._metodoDePago = row(3).ToString.Trim()
            DatosComprobante._lugarExpedicion = row(4).ToString.Trim()
            DatosComprobante._ClaveSATMoneda = row(5).ToString.Trim()
        Next
        '**Aclaración
        '*CLUGAREXPE contiene toda la dirección del cliente, dentro de esa misma tabla no se encuentra un identificador para hacer la referencia a la tabla de admDomicilios,
        'por lo tanto, se recomienda realizar un substring del dato.
        '*VERSION se deja en 3.3.
        '*SUBTOTAL se obtiene de la suma de todos los totales sin incluir el impuesto.
        '*TOTAL es la sumatoria del subtotal con el total de todos los impuestos.
        '*FORMA DE PAGO Y TIPO DE COMPROBANTE no se encuentran dentro de las tablas de SQL.

        '------------------- TERMINA CONSULTA DE DATOS PARA LLENAR EL ARCHIVO XML.'
    End Function
    Public Function PrubaGeneradorXML()
        Dim nombre As String = "C:\XML\" & carpeta & "\" & facturaxml._folio & ".xml"
        Dim w As StreamWriter = New StreamWriter(nombre, False, System.Text.Encoding.UTF8)
        Dim hora As Date = Format(Now, "HH:mm:ss")
        hora = hora.AddSeconds(segundos)
        Dim fecha As String = Format(Date.Today, "yyyy-MM-dd") & "T" & hora.ToString("HH:mm:ss")
        Dim idfactura As String = ""
        fecha = fecha.Trim
        '  MsgBox(fecha)
        Dim todotexto As String = ""
        ' Dim monedaExtranjera As Boolean = False
        Dim TextoMoneda As String = ""
        Dim textoDescuento As String = ""
        Dim textoRelacion As String = ""
        If monedaExtranjera Then
            TextoMoneda = """ TipoCambio=""" & facturaxml._TipoCambio & """ Moneda=""" & facturaxml._Moneda
        Else
            TextoMoneda = """ Moneda=""" & facturaxml._Moneda
        End If

        If tieneDescuento Then  ' esta parte aun no se añade al xml 28/06/2017 11:41 am
            textoDescuento = """ descuento=""" & facturaxml._Descuento
            If facturaxml._motivoDescuento <> "" Then
                textoDescuento += """ motivoDescuento=""" & facturaxml._motivoDescuento
            End If
            'textoDescuento2 = """"
        End If
        If relacion Then
            textoRelacion = """ FolioFiscalOrig=""" & facturaxml._FechaFolioFiscalOrig & """ SerieFolioFiscalOrig=""" & facturaxml._SerieFolioFiscalOrig _
                & """ FechaFolioFiscalOrig=""" & facturaxml._FechaFolioFiscalOrig & """ MontoFolioFiscalOrig=""" & facturaxml._MontoFolioFiscalOrig
        Else
            textoRelacion = ""
        End If
        todotexto = "<?xml version=""1.0"" encoding=""UTF-8""?><cfdi:Comprobante xmlns:cfdi=""http://www.sat.gob.mx/cfd/3"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""" _
              & " xsi:schemaLocation=""http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd""" & vbCrLf & "version=""3.2""" _
              & " serie=""" & facturaxml._serie & """ folio=""" & facturaxml._folio & """ fecha=""" & fecha & """ formaDePago=""" & facturaxml._formaDePago & """" & vbCrLf & "" _
              & " subTotal=""" & facturaxml._subTotal & textoDescuento & TextoMoneda & """ total=""" & facturaxml._total & """ tipoDeComprobante=""" & facturaxml._tipoDeComprobante & """" & vbCrLf & "" _
              & " metodoDePago=""" & facturaxml._metodoDePago & """ LugarExpedicion=""" & facturaxml._EmisorDomFiscalCalle & " " _
              & facturaxml._emisorDomFiscalnoExt & " " & facturaxml._emisorDomFiscalnoInt & ", " & facturaxml._emisorDomFiscalColonia & ", " _
              & facturaxml._emisorDomfiscalCP & ", " & facturaxml._emisorDomFiscalLocalidad & ", " & facturaxml._emisorDomFiscalMunicipio & ", " & facturaxml._emisorDomFiscalEstado & ", " & facturaxml._emisorDomFiscalPais & """" & vbCrLf & "NumCtaPago=""" & facturaxml._NumCtaPago & textoRelacion & """>" _
          & "<cfdi:Emisor rfc=""" & facturaxml._EmisorRFC & """ nombre=""" & facturaxml._EmisorNombre & """>" _
  & "<cfdi:DomicilioFiscal calle=""" & facturaxml._EmisorDomFiscalCalle & """ noExterior=""" & facturaxml._emisorDomFiscalnoExt & """ noInterior=""" & facturaxml._emisorDomFiscalnoInt & """ colonia=""" _
              & facturaxml._emisorDomFiscalColonia & """ localidad=""" & facturaxml._emisorDomFiscalLocalidad & """ municipio=""" & facturaxml._emisorDomFiscalMunicipio & """ estado=""" & facturaxml._emisorDomFiscalEstado _
              & """ pais=""" & facturaxml._emisorDomFiscalPais & """ codigoPostal=""" & facturaxml._emisorDomfiscalCP & """/>" & vbCrLf & "<cfdi:RegimenFiscal Regimen=""" & facturaxml._RegimenFiscal & """/></cfdi:Emisor>" _
& "<cfdi:Receptor rfc=""" & facturaxml._receptorRFC & """ nombre=""" & facturaxml._receptorNombre & """>" _
& "<cfdi:Domicilio calle=""" & facturaxml._receptorDomCalle & """ noInterior=""" & facturaxml._receptorDomNoInt & """ colonia=""" _
               & facturaxml._receptorDomColonia & """ localidad=""" & facturaxml._receptorDomLocalidad & """ municipio=""" _
               & facturaxml._receptorDomMunicipio & """ estado=""" & facturaxml._receptorDomEstado & """ pais=""" & facturaxml._receptorDomPais _
               & """ codigoPostal=""" & facturaxml._receptorDomCP & """/></cfdi:Receptor>" & vbCrLf & "" _
& "<cfdi:Conceptos>" & vbCrLf & ""


        For Each producto As Productos_Factura In listaProductos
            Dim cadena As String = "<cfdi:Concepto cantidad=""" & producto._cantidad & """ unidad=""" & producto._unidad & """ noIdentificacion=""" & producto._noIdentificacion _
                        & """ descripcion=""" & producto._descripcion & """ valorUnitario=""" & producto._valorUnitario & """ importe=""" & producto._importe & """>"

            If producto._numero <> "" Then
                Dim fechas() As String
                Dim fecha2 As String
                fechas = producto._fecha.Split("/")
                fecha2 = fechas(2) & "-" & fechas(1) & "-" & fechas(0)
                cadena += "<cfdi:InformacionAduanera numero=""" & producto._numero & """ fecha=""" & fecha2 & """ aduana=""" & producto._aduana & """/>"
            End If
            cadena += "</cfdi:Concepto>" & vbCrLf & ""
            todotexto += cadena
        Next
        todotexto += "</cfdi:Conceptos>" _
& "<cfdi:Impuestos totalImpuestosTrasladados=""" & facturaxml._TotalImpuestosTraslados & """>" & vbCrLf & "" _
        & "<cfdi:Traslados><cfdi:Traslado impuesto=""IVA"" tasa=""16.00"" importe=""" & facturaxml._importeTotalIva & """/></cfdi:Traslados></cfdi:Impuestos></cfdi:Comprobante>"

        'If todotexto.Contains("&") Then


        'End If
        w.WriteLine(todotexto)
        w.Close()

        comprobarIdcomprocante("idfactura", "facturas.dbf", idfactura)
        Conexiones.conectar(empresaGlobal)
        Dim comprobarfolio As String = ""
        Conexiones.consultaValor(" folio", " facturas", " where folio='" & facturaxml._folio & "'", comprobarfolio)
        If comprobarfolio = "" Then
            '  MsgBox(facturaxml._cobserva01)
            validafactura(facturaxml, listaProductos) ' la funcion validafactura es para cambiar caracteres que se deben cambiar para insertar en la base de datos
            ' MsgBox(facturaxml._cobserva01)
            Dim band As Boolean = False
            insertar_factura(facturaxml, idfactura, nombre, fecha, band)
            If band Then
                insertar_productos(listaProductos, idfactura)
            End If

        End If
        'MsgBox("se creo " & nombre)
        GC.Collect()
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
