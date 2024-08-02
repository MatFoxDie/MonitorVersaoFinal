Imports System.Text.RegularExpressions

Namespace Spotify.SpotDl.Models
    Public Class CmdResponse
        Private output As String
        Sub New()
        End Sub
        Sub New(output As String)
            Me.output = output
        End Sub

        Public Function formatOutput() As String
            output = Regex.Replace(output, "Skipping.*?\(file already exists\) \(duplicate\)", "")
            Console.WriteLine(output)
            Return output
        End Function


    End Class
End Namespace
