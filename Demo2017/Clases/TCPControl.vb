Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Public Class TCPControl
    Public Cliente As New TcpClient(DireccionIPServidor, PuertoServidor)
    Public DataStream As New StreamWriter(Cliente.GetStream)

    'Public Sub New()
    'CLIENTE'
    '    Try
    '       Cliente = New TcpClient(DireccionIPServidor, PuertoServidor)
    '      DataStream = New StreamWriter(Cliente.GetStream)
    ' Catch ex As Exception
    'MsgBox("Eror creando cliente: " & ex.Message)
    '   End Try

    'End Sub

    Public Sub Send(Data As String) 'FUNCIÓN PARA ENVIAR LOS DATOS AL SOCKET.'
        DataStream.Write(Data & vbCrLf) 'TRASPASO DE INFORMACIÓN.'
        DataStream.Flush()
    End Sub
End Class
