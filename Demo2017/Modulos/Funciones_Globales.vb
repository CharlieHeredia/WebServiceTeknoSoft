﻿Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Module Funciones_Globales
    Dim conexion As New Conexion
    Public Function ConsultaProductoSQL()

    End Function

    Public Function ConsultarDocumentoSQL(ByVal condicion As String, ByVal tabla As String)
        Try
            Dim clase As New Configuracion 'CREACION DE UNA VARIABLE DE LA CLASE Configuración'
            Dim documentoConsulta As New Documento 'CREACION DE VARIBLE DE LA CLASE Documento.'
            Dim campos() As String = clase.LecturaConfiguracionDocumento() 'SE LEEN LOS NOMBRES DE LOS CAMPOS ALMACENADOS EN EL ARCHIVO DE CONFIGURACIÓN.'
            conexion.Conectar() 'SE ABRE LA CONEXIÓN CON LA BASE DE DATOS.'
            conexion.ConsultarDocumentoSQL(campos, condicion, tabla, documentoConsulta)
            conexion.CerrarConexion() 'CIERRE DE LA CONEXION.'
            Return documentoConsulta 'DEVULVE LA CONSULTA REALIZADA A LA BASE DATOS.'
        Catch ex As Exception
            MsgBox("Problema encontrado: " & ex.Message) 'MENSAJE DE ERROR DE TIPO VENTANA DE WINDOWS
            conexion.CerrarConexion() 'EN CASO DE FALLAR SE CIERRA LA CONEXIÓN ABIERTA PREVIAMENTE.'
        End Try
    End Function

    Public Function GenerarArchivo(ByVal Folio As String)
        Try
            conexion.Conectar() 'SE ABRE LA CONEXIÓN CON LA BASE DE DATOS.'
            conexion.GenerarArchivo(Folio)
            conexion.CerrarConexion() 'CIERRA LA CONEXIÓN.'
        Catch ex As Exception
            MsgBox("Error interno: " & ex.ToString())
        End Try
    End Function

    Public Function VerificacionExistenciaDirectorioPrincipal()
        'FUNCIÓN PARA CREAR EL DIRECTORIO PRINCIPAL DONDE TRABAJA EL WEBSERVICE.'
        If Directory.Exists("C:\TeknoCom") = False Then 'VERIFICACIÓN DE EXISTENCIA DE DIRECTORIO. EN CASO DE NO EXISTIR ENTRA A LA CONDICIÓN'
            Directory.CreateDirectory("C:\TeknoCom") 'SE CREAA EL DIRECTORIO.'
        End If
    End Function

    Public Function VerificacionExistenciaDirectorioConfiguracionWebService()
        'FUNCIÓN PARA CREAR EL DIRECTORIO DONDE SE ALMACENAN LOS ARCHIVOS DE CONFIGURACIÓN DEL WEB SERVICE.'
        If Directory.Exists("C:\TeknoCom\WebService") = False Then
            Directory.CreateDirectory("C:\TeknoCom\WebService")
        End If
    End Function

    Public Function GenerarArchivoDatosConexionWebService(ByVal host As String, ByVal BD As String, ByVal user As String, ByVal pass As String) As Boolean
        VerificacionExistenciaDirectorioConfiguracionWebService()
        If File.Exists("C:\TeknoCom\WebService\ConfiguracionConexion.txt") = False Then
            hostname = host 'NOMBRE DE HOST O INSTANCIA'
            BaseDatos = BD 'NOMBRE DE LA BASE DE DATOS'
            usuarioBD = user 'NOMBRE DE USUARIO DE LA BASE DE DATOS'
            contra = pass 'CONTRASEÑA DE LA BASE DE DATOS'
            Dim Path = File.Create("C:\TeknoCom\WebService\ConfiguracionConexion.txt")
            Path.Close()
            Dim texto() As String = {host, BD, user, pass}
            File.WriteAllLines("C:\TeknoCom\WebService\ConfiguracionConexion.txt", texto)
            'File.Encrypt("C:\TeknoCom\WebService\ConfiguracionConexion.txt")
            ArchivoConfiguracionWebService = True
            Return True
        Else
            Return False
        End If
    End Function
    Public Function EliminarArchivoDatosConexionWebService() As Boolean
        If File.Exists("C:\TeknoCom\WebService\ConfiguracionConexion.txt") = False Then
            Return False
        Else
            'File.Delete("C:\TeknoCom\WebService\ConfiguracionConexion.txt")
            My.Computer.FileSystem.DeleteFile("C:\TeknoCom\WebService\ConfiguracionConexion.txt", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently) 'BORRA PERMANENTEMENTE EL ARCHIVO DE CONFIGURACIÓN.'
            Return True
        End If
    End Function
End Module
