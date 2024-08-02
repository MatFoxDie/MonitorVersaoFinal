Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models

Public Class DirectoryManager
    ReadOnly Property MaximumFolderSize As Long
    Public Event TrackReceivedLocalPath As TrackReceivedLocalPathEventHandler
    Sub New(rootFolder As String)
        DeleteDirectory(rootFolder)
    End Sub

    Public Function CreateDirectory(path As String) As String
        Directory.CreateDirectory(path)
    End Function

    Public Function VerifyDirectoryExists(path As String) As Boolean
        Return Directory.Exists(path)
    End Function

    Public Function VerifyDirectorySize(path As String) As Long
        Throw New NotImplementedException()
    End Function

    Public Function filePath(folderPath As String, fileName As String) As MemoryStream
        Try
            Dim files As String() = Directory.GetFiles(folderPath)
            fileName = fileName _
                        .Replace("_", "") _
                        .Replace("?", "") _
                        .Replace("/", "") _
                        .Replace("<", "") _
                        .Replace(">", "") _
                        .Replace("|", "") _
                        .Replace("*", "")

            Dim fileNameNormaized = RemoveDiacritics(fileName).ToLower()

            For Each file As String In files
                file = verificarSeDiretorioVemComEspacos(file)
                Dim fileNormalized = RemoveDiacritics(file).ToLower()
                Dim posicaoHifen = fileNormalized.IndexOf("-")
                If posicaoHifen <> -1 Then
                    fileNormalized = fileNormalized.Substring(posicaoHifen + 1).Trim()
                Else
                End If
                If fileNormalized.Contains(fileNameNormaized) Then
                    Dim fileInmemeory = AsMemoryStream(file)
                    DeleteFile(file)
                    Return fileInmemeory
                End If
            Next
            Return Nothing
        Catch ex As Exception
            Console.WriteLine("Erro ao buscar arquivo: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Function RemoveDiacritics(text As String) As String
        Try
            Dim normalizedString As String = text.Normalize(NormalizationForm.FormD)
            Dim stringBuilder As New Text.StringBuilder()

            For Each c As Char In normalizedString
                Dim unicodeCategory As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
                If unicodeCategory <> UnicodeCategory.NonSpacingMark Then
                    stringBuilder.Append(c)
                End If
            Next

            Return stringBuilder.ToString()
        Catch ex As Exception
            Console.WriteLine("Erro ao remover acentos: " & ex.Message)
            Return text
        End Try

    End Function

    Private Function removeSpecialChars(txt As String) As String
        Try
            Dim regex As New Regex("[^a-zA-Z0-9\s]")
            Return regex.Replace(txt, "")
        Catch ex As Exception
            Console.WriteLine("Erro ao remover caracteres especiais: " & ex.Message)
        End Try
    End Function

    Private Function verificarSeDiretorioVemComEspacos(path As String) As String
        Try
            Dim ultimaParteIndice As Integer = path.LastIndexOf("\")

            Dim parteAntesDaBarra As String = path.Substring(0, ultimaParteIndice)
            Dim parteDepoisDaBarra As String = path.Substring(ultimaParteIndice)

            Dim parteAtesDaBarraSemEspacosNoFinal As String = parteAntesDaBarra.TrimEnd()

            Return parteAtesDaBarraSemEspacosNoFinal + parteDepoisDaBarra
        Catch ex As Exception
            Console.WriteLine("Erro ao verificar se diretório vem com espaços: " & ex.Message)
        End Try
    End Function

    Public Sub filePathAsync(folderPath As String, traklist As List(Of Track))
        Try
            While traklist.Any(Function(track) track.LocalPath Is Nothing)
                Dim currentTrack = traklist.FirstOrDefault(Function(track) track.LocalPath Is Nothing)
                currentTrack.LocalPath = filePath(folderPath, currentTrack.name)
                If currentTrack.LocalPath IsNot Nothing Then
                    RaiseEvent TrackReceivedLocalPath(Me, New TrackReceivedLocalPathEventsArgs(currentTrack))
                End If
            End While
        Catch ex As Exception
            Console.WriteLine("Erro ao buscar arquivo: " & ex.Message)
        End Try
    End Sub

    Private Function AsMemoryStream(file As String) As MemoryStream
        Try
            Dim memoryStream As New MemoryStream()
            Dim fileStream As New FileStream(file, FileMode.Open)
            fileStream.CopyTo(memoryStream)
            fileStream.Close()
            Return memoryStream
        Catch ex As Exception
            Console.WriteLine("Erro ao converter arquivo para MemoryStream: " & ex.Message)
        End Try
    End Function

    Public Sub DeleteDirectory(path As String)
        Try
            If VerifyDirectoryExists(path) Then
                Directory.Delete(path, True)
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao deletar diretório: " & ex.Message)
        End Try

    End Sub

    Private Sub DeleteFile(path As String)
        Try
            File.Delete(path)
        Catch ex As Exception
            Console.WriteLine("Erro ao deletar arquivo: " & ex.Message)
        End Try

    End Sub
End Class
