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
            'Verifica se tem pasta Config criada se nao cria
            If Not Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config")) Then
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config"))
            End If

            'Salva no path atual da bin com uma pasta chamada Config e um arquivo chamado config.xml
            Dim configPath As String = Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config", "config.xml")

            Return configPath
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function
End Class
