Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Sql
Public Class Conexion
    Public RutaEmpresa As String 'VARIABLE PARA ALMACENAR LA RUTA DE LA EMRPESA.'
    Public Conexiones As New OleDb.OleDbConnection() 'VARIABLE PARA REALIZAR LAS CONEXIONES TIPO DBF.'
    Public ConexionesSQL As New SqlConnection() 'VARIABLE PARA REALIZAR CONEXIONES TIPO SQL.'
    Public empresa As String 'VARIABLE PARA ALMACENAR EL NOMBRE DE LA EMPRESA.'

    Public Function Conectar() 'FUNCIÓN PARA ABRIR CONEXIÓN A LA BASE DE DATOS SQL Y DBF'
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
