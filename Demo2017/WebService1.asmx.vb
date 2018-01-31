Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService
    Dim conexion As New Conexion
    Private Cliente As TCPControl
    '//////////////////////////// FUNCIONES PARA BASE DE DATOS ////////////////////////////////////////////////////////////////////'
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////'
    <WebMethod()> _
    Public Function ProbarConexion() 'FUNCIÓN PARA REALIZAR UNA PRUEBA DE CONEXIÓN.'
        Try
            conexion.Conectar() 'SE ABRE LA CONEXIÓN A LA BASE DE DATOS.'
            ProbarConexion = True 'SE REGRESA UN True INDICANDO QUE LA CONEXIÓN SE REALIZO CORRECTAMENTE.'
        Catch ex As Exception
            MsgBox(ex.Message) 'MENSAJE DE ERROR EN CASO DE QUE LA CONEXIÓN FALLE.'
            ProbarConexion = False 'SE REGRESA UN False INDICANDO QUE LA CONEXIÓN FALLO.'
        Finally
            conexion.CerrarConexion() 'CIERRE DE LA CONEXIÓN.'
        End Try
        Return ProbarConexion ' SE REGRESA EL RESULTADO DE LA PRUEBA DE CONEXIÓN.'
    End Function
    <WebMethod()> _
    Public Function GenerarArchivoDatosConexion(ByVal host As String, ByVal BD As String, ByVal user As String, ByVal pass As String) As Boolean
        Try
            GenerarArchivoDatosConexion = GenerarArchivoDatosConexionWebService(host, BD, user, pass)
            'DEVUELVE True INDICANDO QUE LOS DATOS SE GUARDARON CORRECTAMENTE.'
            'DEVUELVE False INDICANDO QUE EL ARCHIVO DE CONFIGURACIÓN YA EXISTE.'
        Catch ex As Exception
            GenerarArchivoDatosConexion = False 'DEVUELVE False INDICADNO QUE LOS DATOS NO SE GUARDARON CORRECTAMENTE
        End Try
    End Function
    <WebMethod()> _
    Public Function EliminarArchivoDatosConexion() As Boolean
        Try
            EliminarArchivoDatosConexion = EliminarArchivoDatosConexionWebService()
        Catch ex As Exception
            EliminarArchivoDatosConexion = False
        End Try
    End Function
    ' <WebMethod()> _
    ' Public Function TipoConexion(ByVal Tipo As String) As Boolean 'FUNCIÓN PARA SELECCIONAR EL TIPO DE CONEXIÓN.'
    '    Select Case Tipo
    '       Case "1" ' 1 PARA CONEXIÓN DE TIPO SQL.' 
    '          motorDB = Tipo 'SQL'
    '     Case "2" ' 2 PARA CONEXIÓN DE TIPO DBF.'
    '        motorDB = Tipo 'DBF'
    'End Select
    'Return True
    'End Function

    ' <WebMethod()> _
    'Public Function ConsultarDocumentos(ByVal condicion As String, ByVal tabla As String) As Documento 'FUNCIÓN PARA CONSULTAR LA INFORMACIÓN DE UN DOCUMENTO.'
    '   Try
    'Dim clase As New Configuracion 'CREACION DE UNA VARIABLE DE LA CLASE Configuración'
    'Dim documentoConsulta As New Documento 'CREACION DE VARIBLE DE LA CLASE Documento.'
    'Dim campos() As String = clase.LecturaConfiguracionDocumento() 'SE LEEN LOS NOMBRES DE LOS CAMPOS ALMACENADOS EN EL ARCHIVO DE CONFIGURACIÓN.'
    '       conexion.Conectar() 'SE ABRE LA CONEXIÓN CON LA BASE DE DATOS.'
    '      Select Case motorDB
    '         Case "1" ' 1 PARA CONEXIONES DE TIPO SQL.'
    '            conexion.ConsultarDocumentoSQL(campos, condicion, tabla, documentoConsulta)
    '       Case "2" ' 2 PARA CONEXIONES DE TIPO DBF.'
    '          conexion.ConsultarDocumento(campos, condicion, tabla, documentoConsulta)
    ' End Select
    'conexion.CerrarConexion() 'CIERRE DE LA CONEXION.'
    'Return documentoConsulta 'DEVULVE LA CONSULTA REALIZADA A LA BASE DATOS.'
    'Catch ex As Exception
    '    MsgBox("Problema encontrado: " & ex.Message) 'MENSAJE DE ERROR DE TIPO VENTANA DE WINDOWS
    '    conexion.CerrarConexion() 'EN CASO DE FALLAR SE CIERRA LA CONEXIÓN ABIERTA PREVIAMENTE.'
    'End Try

    'End Function
    <WebMethod()> _
    Public Function GenerarArchivoDatosPrueba(ByVal Folio As String) As Boolean
        Try
            GenerarArchivo(Folio)
            Return True
        Catch ex As Exception
            MsgBox("Error encontrado: " & ex.Message)
            Return False
        End Try
    End Function
    <WebMethod()> _
    Public Function ConsultaDocumentosInterna(ByVal condicion As String, ByVal tabla As String) As Documento
        Dim documentoConsulta As New Documento 'CREACION DE VARIBLE DE LA CLASE Documento.'
        documentoConsulta = ConsultarDocumentoSQL(condicion, tabla)
        Return documentoConsulta
    End Function
    <WebMethod()> _
    Public Function ConfigurarDocumento(ByVal idDocumento As String, ByVal aFolio As String, ByVal aNumMoneda As String, ByVal aTipoCambio As String, ByVal aImporte As String, ByVal aDescuentoDoc1 As String, ByVal aDescuentoDoc2 As String, ByVal aSistemasOrigen As String, ByVal aCodConcepto As String, ByVal aSerie As String, ByVal aFecha As String, ByVal aCodigoCteProv As String, ByVal aCodigoAgente As String, ByVal aReferencia As String, ByVal aAfecta As String, ByVal aGasto1 As String, ByVal aGasto2 As String, ByVal aGasto3 As String, ByVal NombreTabla As String, ByVal aRazonSocial As String) As Boolean
        Try
            VerificacionExistenciaDirectorioPrincipal()
            Dim Path = File.Create("C:\TeknoCom\ConfiguracionDocumento.txt") 'SE CREA EL ARCHIVO TXT DONDE SE ALMACENA LA CONFIGURACIÓN DEL DOCUMENTO.'
            Path.Close()
            Dim createText() As String = {idDocumento.Trim() & "|" & aFolio.Trim() & "|" & aNumMoneda.Trim() & "|" & aTipoCambio.Trim() & "|" & aImporte.Trim() & "|" & aDescuentoDoc1.Trim() & "|" & aDescuentoDoc2.Trim() & "|" & aSistemasOrigen.Trim() & "|" & aCodConcepto.Trim() & "|" & aSerie.Trim() & "|" & aFecha.Trim() & "|" & aCodigoCteProv.Trim() & "|" & aCodigoAgente.Trim() & "|" & aReferencia.Trim() & "|" & aAfecta.Trim() & "|" & aGasto1.Trim() & "|" & aGasto2.Trim() & "|" & aGasto3.Trim() & "|" & aRazonSocial.Trim()}
            'SE GENERA EL TEXTO QUE SERÁ GUARDADO EN EL ARCHIVO DE CONFIGURACIÓN.'
            File.WriteAllLines("C:\TeknoCom\ConfiguracionDocumento.txt", createText) 'SE GUARDA EL TEXTO EN EL ARCHIVO.'
            Dim Tabla() As String = {""}
            Tabla(0) = NombreTabla 'NOMBRE DE LA TABLA DE DOCUMENTO EN LA BASE DE DATOS.  AUN NO  TIENE USO ESTA LINEA EN EL ARCHIVO. 11/01/2018'
            File.AppendAllLines("C:\TeknoCom\ConfiguracionDocumento.txt", Tabla) 'SE AGREGA EL NOMBRE DE LA TABLA AL ARCHIVO.'
            Return True
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR POR MEDIO DE VENTANA DE WINDOWS.'
            Return False
        End Try
    End Function
    <WebMethod()> _
    Public Function ConfigurarProducto(ByVal cantidad As String, ByVal unidad As String, ByVal num_identificacion As String, ByVal valorUnitario As String, ByVal importe As String, ByVal claveProductoSer As String, ByVal claveunidad As String, ByVal descripcion As String, ByVal numeroPedimentoAduana As String, ByVal totalImpuesto As String, ByVal baseTrasladoImpuesto As String, ByVal impuestoTrasladoImpuesto As String, ByVal tipofactorTrasladoImpuesto As String, ByVal tasacuotaTrasladoImpuesto As String, ByVal importeTrasladoImpuesto As String) As Boolean
        Try
            VerificacionExistenciaDirectorioPrincipal()
            Dim Path = File.Create("C:\TeknoCom\ConfiguracionMovimiento.txt") 'SE CREA EL ARCHIVO TXT DONDE SE ALMACENA LA CONFIGURACIÓN DEL MOVIMIENTO.'
            Path.Close()
            Dim createText() As String = {cantidad.Trim() & "|" & unidad.Trim() & "|" & num_identificacion.Trim() & "|" & valorUnitario.Trim() & "|" & importe.Trim() & "|" & claveProductoSer.Trim() & "|" & claveunidad.Trim() & "|" & descripcion.Trim() & "|" & numeroPedimentoAduana.Trim() & "|" & totalImpuesto.Trim() & "|" & baseTrasladoImpuesto.Trim() & "|" & importeTrasladoImpuesto.Trim() & "|" & tipofactorTrasladoImpuesto.Trim() & "|" & tasacuotaTrasladoImpuesto.Trim() & "|" & importeTrasladoImpuesto.Trim()}
            'SE GENERA EL TEXTO QUE SERÁ GUARDADO EN EL ARCHIVO DE CONFIGURACIÓN.'
            File.WriteAllLines("C:\TeknoCom\ConfiguracionMovimiento.txt", createText) 'SE GUARDA EL TEXTO EN EL ARCHIVO.'
            Return True
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR POR MEDIO DE VENTANA DE WINDOWS.'
            Return False
        End Try
    End Function
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////'.
    '//////////////////// FUNCIONES PARA SOCKET. //////////////////////////////////////////////////////////////////////////////'.
    <WebMethod()> _
    Public Function Terminar_Conexion_Socket() 'FUNCIÓN PARA TERMINAR LA CONEXIÓN CON EL SOCKET.'
        Try
            If IsNothing(Cliente) = False Then 'SI EL CLIENTE ESTA CONEXTADO ENTRA EN LA CONDICIÓN.'
                Cliente.Cliente.Close() 'SE CIERRA LA CONEXIÓN CON EL SOCKET SERVIDOR.'
            End If
            Return "Conexión cerrada" 'MENSAJE DE CONEXIÓN TERMINADA.'
        Catch ex As Exception
            MsgBox("Error: " & ex.Message) 'MENSAJE DE ERRORT TIPO VENTANA DE WINDOWS PARA EL USUARIO.'
            Return "Error al cerrar conexión" 'MENSAJE DE ERROR AL TERMINAR LA CONEXIÓN QUE DEVULVE POR MEDIO DE LA FUNCIÓN.'
        End Try
    End Function

    <WebMethod()> _
    Public Function Probar_Socket_Timbrado(Palabra As String) As Boolean
        Try
            Cliente = New TCPControl() 'CREA UNA NUEVA CONEXIÓN AL SOCKET.'
            SendTimbrado(Palabra) 'SE ENVIA LA INFORMACIÓN REQUERIDA PARA REALIZAR EL TIRMBRADO.'
            Terminar_Conexion_Socket() 'SE TERMINA LA CONEXIÓN CON EL SOCKET.'
            Return True
        Catch ex As Exception
            MsgBox("Problema encontrado: " & ex.Message) 'MENSAJE DE ERRROR AL USUAIRO POR MEDIO DE VENTANA DE WINDOWS.'
            Return False
        End Try
    End Function
    Private Sub SendTimbrado(Palabra As String) 'FUNCIÓN QUE RECOJE LA INFORMACIÓN PARA TIMBRADO, VERIFICA QUE EL CLIENTE ESTE CONECTADO,
        ' ENVIA LA INFORMACIÓN A UNA SUB FUNCIÓN  (Send).'
        Try
            If Cliente.Cliente.Connected = True Then 'VERIFICACIÓN DE CLIENTE CONECTADO CON EL SOCKET.'
                Cliente.Send(Palabra) 'SUBFUNCIÓN QUE ENVIAR LA INFORMACIÓN AL SOCKET SERVIDOR.'
            End If
        Catch ex As Exception
            MsgBox("Problema encontrado: " & ex.Message) 'MENSAJE DE ERROR AL USUARIO POR MEDIO DE VENTANA DE WINDOWS.'
        End Try

    End Sub
    '/////////////////////////FUNCIONES DE CONFIGURACIÓN DE SOCKET ///////////////////////////////////////////////////////////////'
    <WebMethod()> _
    Public Function Configuracion_IP_Puerto_Socket(IP As String, Puerto As Integer) 'FUNCIÓN PARA CONFIGURAR LA DIRECCIÓN IP Y PUERTO DEL SOCKET SERVIDOR.'
        DireccionIPServidor = IP 'DIRECCIÓN IP DEL SERVIDOR.'
        PuertoServidor = Puerto 'PUERTO DEL SERVIDOR.'
    End Function
    <WebMethod()> _
    Public Function Configuracion_Socket(DireccionEmpresa As String, aRutaXML As String, aCodConcepto As String, aUUID As String, aRutaDDA As String, aPass As String, aRutaFormato As String) As Boolean
        'FUNCIÓN QUE GUARDA DATOS EN LA BASE DE DATOS PARA LA CREACIÓN DEL ARCHIVO XML.
        'LOS DATOS SE GUARDAN EN SQL, LA BASE Y LA TABLA SON ESTATICAS HASTA EL MOMENTO 30/01/2018
        Try
            conexion.InsertarConfiguracionSocket(DireccionEmpresa, aRutaXML, aCodConcepto, aUUID, aRutaDDA, aPass, aRutaFormato)
            Return True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            Return False
        End Try
    End Function
    <WebMethod()> _
    Public Function PruebaProducto() As Producto
        Dim adu As New Aduana
        Dim imp As New Impuesto
        Dim tras As New Traslado
        Dim pro As New Producto
        imp._traslados = New List(Of Traslado)
        imp._traslados.Add(tras)
        pro._aduana = adu
        pro._impuesto = imp
        Return pro
    End Function
    <WebMethod()> _
    Public Function Tacos()
        CargarArchivoConfiguracionWebService()
    End Function
End Class