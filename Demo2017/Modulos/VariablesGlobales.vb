Module VariablesGlobales
    Public motorDB As String 'PARA SABER EL TIPO DE CONEXIÓN QUE SE UTILIZARÁ.'
    Public hostname As String 'NOMBRE DE HOST O INSTANCIA.'
    Public BaseDatos As String 'NOMBRE  DE LA BASE DE DATOS.'
    Public usuarioBD As String 'NOMBRE DEL USUARIO DE LA BASE DE DATOS.'
    Public contra As String 'CONTRASEÑA DE LA BASE DE DATOS.'
    Public DireccionIPServidor As String = "127.0.0.1" 'DIRECCIÓN DEL SOCKET SERVIDOR, POR DEFECTO SE COLOCA 127.0.0.1, ESTA DEBE CAMBIARSE.'
    Public PuertoServidor As Integer = 64555 'PUERTO DEL SOCKET SERVIDOR.'
End Module
