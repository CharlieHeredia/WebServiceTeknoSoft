Imports System.IO
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

            conexion.CerrarConexion() 'CIERRA LA CONEXIÓN.'
        Catch ex As Exception
            MsgBox("Error interno: " & ex.Message)
        End Try
    End Function

    Public Function VerificacionExistenciaDirectorioPrincipal()
        'FUNCIÓN PARA CREAR EL DIRECTORIO PRINCIPAL DONDE TRABAJA EL WEBSERVICE.'
        If Directory.Exists("C:\TeknoCom") = False Then 'VERIFICACIÓN DE EXISTENCIA DE DIRECTORIO. EN CASO DE NO EXISTIR ENTRA A LA CONDICIÓN'
            Directory.CreateDirectory("C:\TeknoCom") 'SE CREAA EL DIRECTORIO.'
        End If
    End Function
End Module
