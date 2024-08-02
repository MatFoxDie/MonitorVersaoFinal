Imports Newtonsoft.Json

Namespace Spotify.Api
    Public Class Token
        Property Access_token As String
        Property Token_type As String
        Property Expires_in As Integer
        Property Refresh_token As String

        Sub New()
        End Sub

        Public Shared Function GetFromJson(responseApiToken As String) As Token
            Try
                Dim token As Token
                token = JsonConvert.DeserializeObject(Of Token)(responseApiToken)
                Return token
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
            End Try
        End Function

    End Class

End Namespace