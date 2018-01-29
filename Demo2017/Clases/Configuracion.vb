Imports System.IO
Public Class Configuracion
    Public Function RestaurarConfiguracion() As Boolean
        Try
            Return True
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString())
            Return False
        End Try
    End Function
    Public Function LecturaConfiguracionDocumento() As String() 'FUNCIÓN PARA LEER EL ARCHIVO DE CONFIGURACIÓN DE DOCUMENTO.'
        Dim vacio() As String = {""} 'VARIABLE QUE SE REGRESA EN CASO DE NO LOGRARSE LA LECTURA DEL ARCHIVO.'
        Try
            If File.Exists("C:\TeknoCom\ConfiguracionDocumento.txt") Then 'VALIDACIÓN DE LA EXISTENCIA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim campos() As String 'VARIABLE PARA ALMACENAR EL NOMBRE DE LOS CAMPOS.'
                Dim Path As String = "C:\TeknoCom\ConfiguracionDocumento.txt" 'VARIABLE PARA ALMACENAR LA RUTA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim apuntadorArchivo As New StreamReader(Path, System.Text.Encoding.Default, False) 'APUNTADOR AL ARCHIVO.'
                Dim lineaTexto As String = "" 'VARIABLE PARA ALMACENAR LA LINEA DE TEXTO QUE SE LEA DEL ARCHIVO.'
                Dim NumeroLinea As Integer = 1

                Do While Not apuntadorArchivo.EndOfStream 'CICLO MIENTRAR EL APUNTADOR NO LLEGUE AL FINAL DEL ARCHIVO.'
                    lineaTexto = apuntadorArchivo.ReadLine 'SE LEE LA PRIMERA LINEA DEL ARCHIVO.'
                    If NumeroLinea = 1 Then 'VALIDACIÓN PARA SABER SI ES LA PRIMERA LINEA DE TEXTO DEL ARCHIVO. DONDE SE ESTABLECEN LOS NOMBRES DE LOS CAMPOS.'
                        campos = Split(lineaTexto.Trim(), "|") 'SE SEPARAN LOS NOMBRES DE LOS CAMPOS EN UN ARREGLO.'
                        For i As Integer = 0 To campos.Length - 1 'CICLO QUE RECORRE TODOS LOS CAMPOS EN EL ARREGLO.'
                            campos(i) = campos(i).Trim() 'DEVUELVE LA CADENA SIM ESPACIOS INICIALES NI FINALES.'
                        Next
                    End If
                    NumeroLinea += 1 'AUMENTO DEL CONTADOR DE LINEAS.'
                Loop 'FIN DEL CICLO.'

                Return campos 'REGRESA EL NOMBRE DE LOS CAMPOS.'
            Else
                MsgBox("No existe el archivo de configuración. (C:\TeknoCom\ConfiguracionDocumento.txt)") 'MENSJAE DE QUE NO EXISTE EL ARCHIVO DE CONFIGURACIÓN.'
                Return vacio
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR.'
            Return vacio
        End Try
    End Function
    Public Function LecturaNombreTablaDocumento() As String 'FUNCIÓN PARA LEER EL NOMBRE DE LA TABLA DE DOCUMENTO. NO TIENE USO HASTA EL MOMENTO 11/01/2018'
        Try
            If File.Exists("C:\TeknoCom\ConfiguracionDocumento.txt") Then 'VALIDACIÓN DE LA EXISTENCIA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim Path As String = "C:\TeknoCom\ConfiguracionDocumento.txt" 'VARIABLE PARA ALMACENAR LA RUTA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim apuntadorArchivo As New StreamReader(Path, System.Text.Encoding.Default, False) 'APUNTADOR AL ARCHIVO.'
                Dim lineaTexto As String = "" 'VARIABLE PARA ALMACENAR LA LINEA DE TEXTO QUE SE LEA DEL ARCHIVO.'
                Dim NumeroLinea As Integer = 1
                Dim NombreTabla As String = ""
                Do While Not apuntadorArchivo.EndOfStream 'CICLO MIENTRAR EL APUNTADOR NO LLEGUE AL FINAL DEL ARCHIVO.'
                    lineaTexto = apuntadorArchivo.ReadLine 'SE LEE LA LINEA DEL ARCHIVO.'
                    If lineaTexto = 2 Then 'VALIDACIÓN PARA SABER SI ES LA SEGUNDA LINEA DONDE SE ALMACENA EL NOMBRE DE LA TABLA EN EL ARCHIVO.'
                        NombreTabla = lineaTexto.Trim() 'SE ELIMINAN LOS ESPACIOS DE INICIO Y FINALES DE LA CADENA.'
                    End If
                    NumeroLinea += 1 'SE AUMENTA EL CONTADOR DE LAS LINEAS.'
                Loop

                Return NombreTabla 'SE RETORNA EL NOMBRE DE LA TABLA.'
            Else
                MsgBox("No existe el archivo de configuración.") 'MENSAJE DE QUE NO EXISTE EL ARCHIVO DE CONFIGURACIÓN.'
                Return "" 'SE REGRESA UNA VARIABLE VACIA.'
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR EN FORMA DE VENTANA DE WINDOWS.'
            Return "" 'SE REGRESA UNA VARIABLE VACIA.'
        End Try
    End Function
    Public Function LecturaConfiguracionProducto() As String() 'FUNCIÓN PARA LEER EL ARCHIVO DE CONFIGURACIÓN DE DOCUMENTO.'
        Dim vacio() As String = {""} 'VARIABLE QUE SE REGRESA EN CASO DE NO LOGRARSE LA LECTURA DEL ARCHIVO.'
        Try
            If File.Exists("C:\TeknoCom\ConfiguracionMovimiento.txt") Then 'VALIDACIÓN DE LA EXISTENCIA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim campos() As String 'VARIABLE PARA ALMACENAR EL NOMBRE DE LOS CAMPOS.'
                Dim Path As String = "C:\TeknoCom\ConfiguracionMovimiento.txt" 'VARIABLE PARA ALMACENAR LA RUTA DEL ARCHIVO DE CONFIGURACIÓN.'
                Dim apuntadorArchivo As New StreamReader(Path, System.Text.Encoding.Default, False)  'APUNTADOR AL ARCHIVO.'
                Dim lineaTexto As String = "" 'VARIABLE PARA ALMACENAR LA LINEA DE TEXTO QUE SE LEA DEL ARCHIVO.'
                Dim NumeroLinea As Integer = 1

                Do While Not apuntadorArchivo.EndOfStream 'CICLO MIENTRAS EL APUNTADOR NO LLEGUE AL FINAL DEL ARCHIVO.'
                    lineaTexto = apuntadorArchivo.ReadLine 'SE LEE LA PRIMERA LINEA DEL ARCHIVO.'
                    If NumeroLinea = 1 Then 'VALIDACIÓN PARA SABER SI ES LA PRIMERA LINEA DE TEXTO DEL ARCHIVO. DONDE SE ESTABLECEN LOS NOMBRES DE LOS CAMPOS.'
                        campos = Split(lineaTexto.Trim(), "|") 'SE SEPARAN LOS NOMBRES DE LOS CAMPOS EN UN ARREGLO.'
                        For i As Integer = 0 To campos.Length - 1 'CICLO QUE RECORRE TODOS LOS CAMPOS EN EL ARREGLO.'
                            campos(i) = campos(i).Trim() 'DEVUELVE LA CADENA SIM ESPACIOS INICIALES NI FINALES.'
                        Next
                    End If
                Loop 'FIN DEL CICLO.'

                Return campos 'REGRESA EL NOMBRE DE LOS CAMPOS.'
            Else
                MsgBox("No existe el archivo de configuración.(C:\TeknoCom\ConfiguracionMovimiento.txt)") 'MENSJAE DE QUE NO EXISTEN EL ARCHIVO DE CONFIGURACIÓN.'
                Return vacio 'REGRESA UNA VARIABLE VACIA.'
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un problema: " & ex.ToString()) 'MENSAJE DE ERROR EN FORMA DE VENTANA DE WINDOWS.'
            Return vacio 'REGRESA UNA VARIABLE VACIA.'
        End Try
    End Function
    Public Function LecturaNombreTabla() As String

    End Function
End Class
