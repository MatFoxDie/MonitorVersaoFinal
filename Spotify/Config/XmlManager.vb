Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization

Public Class XmlManager
    Private _path As String
    Sub New()
        _path = GetPath()
    End Sub

    Friend Sub SaveConfig(config As Config)
        Try
            Dim serializer As New XmlSerializer(GetType(Config))
            Dim writer As New StreamWriter(_path)
            serializer.Serialize(writer, config)
            writer.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Function GetConfig() As Config
        Try
            Dim config As New Config
            Dim serializer As New XmlSerializer(GetType(Config))
            Dim reader As New StreamReader(_path)
            config = serializer.Deserialize(reader)
            reader.Close()
            Return config
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Function GetPath() As String
        Try
            Dim NomeProjetoVlc = "Spotify"
            Dim diretorioSolucao As String = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)))
            Dim configPath As String = diretorioSolucao & $"\{NomeProjetoVlc}\Config\Config.xml"
            Return configPath
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function
End Class
