Imports System.Threading
Imports System.Web.UI
Imports OpenQA.Selenium.DevTools.V120.Emulation
Imports Spotify.Spotify.SpotDl.CustomEvents
Imports Spotify.Spotify.SpotDl.Models

Public Class CmdManager
    Private _process As Process
    Sub New()
        _process = New Process()
    End Sub

    Public Function OpenCmdInDirectory(path As String) As String
        _process.StartInfo.FileName = "cmd.exe"
        _process.StartInfo.WorkingDirectory = path
        _process.StartInfo.RedirectStandardInput = True
        _process.StartInfo.RedirectStandardOutput = True
        _process.StartInfo.UseShellExecute = False
        _process.StartInfo.CreateNoWindow = True

    End Function

    Public Sub ExecuteDownloadCommand(spotFyUrl As String)
        Dim output As String = ""
        Try

            _process.StartInfo.RedirectStandardOutput = True

            _process.Start()
            Dim Command = "spotdl " + spotFyUrl

            _process.StandardInput.WriteLine(Command)

            _process.StandardInput.Close()

            output = _process.StandardOutput.ReadToEnd()
            Console.WriteLine(output)
            Dim outputFormatted As String = New CmdResponse(output).formatOutput()
            _process.WaitForExit()
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
        If _process IsNot Nothing Then
            _process.Close()
        End If
        '_process.Close()
        Console.WriteLine("Processo encerrado")
    End Sub


    Public Sub killCmd()
        Try
            If _process IsNot Nothing AndAlso Not _process.HasExited Then
                _process.Kill()
                Console.WriteLine("Processo CMD encerrado.")
            Else
                Console.WriteLine("O processo CMD já foi encerrado ou não está em execução.")
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao encerrar o processo CMD: " & ex.Message)
        End Try
    End Sub

End Class
