Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.Policy
Imports System.Text
Imports System.Text.Json
Imports System.Text.RegularExpressions
Imports System.Web
Namespace Spotify.Api
    Public Class AutenticadorSpotify

        Private _spotifyApi As SpotifyApi
        Private _authHeader As String
        Sub New(spotifyApi As SpotifyApi)
            _spotifyApi = spotifyApi
            _authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(_spotifyApi.ClientId & ":" & _spotifyApi.ClientSecret))
        End Sub

        Public Function GetLoginUrl() As Uri
            Dim reposonseUri As Uri
            Dim scope As String = GetUserPermission()
            Dim code As String
            Dim url As String = "https://accounts.spotify.com/authorize"
            Dim response_type As String = "code"
            Dim state As String = "34fFs29kd09"
            Dim request As HttpWebRequest = WebRequest.Create(url & "?client_id=" & _spotifyApi.ClientId &
        "&response_type=" & response_type & "&redirect_uri=" & _spotifyApi.redirect_uri & "&scope=" & scope) '& "&state=" & state)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"
            Try
                Dim response As WebResponse = request.GetResponse()
                Dim dataStreamResponse As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStreamResponse)
                Dim responseFromServer As String = reader.ReadToEnd()
                reposonseUri = response.ResponseUri
                code = HttpUtility.ParseQueryString(reposonseUri.Query).Get("code")
                reader.Close()
                dataStreamResponse.Close()
                response.Close()
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
            End Try
            Console.ReadLine()
            Return reposonseUri
        End Function

        Public Function GetAcessTokenByUrlCode(Urlcode As String) As Token
            Try
                Dim code As String = ExtrairCodeDaUrl(Urlcode)
                Dim bodyParameters As New Dictionary(Of String, String)() From {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", _spotifyApi.redirect_uri}
            }
                Dim httpClient As New HttpClient()
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " & _authHeader)
                Dim content As New FormUrlEncodedContent(bodyParameters)
                ' Envia a solicitação POST para o Spotify
                Dim response As HttpResponseMessage = httpClient.PostAsync("https://accounts.spotify.com/api/token", content).Result
                Dim token As Token
                ' Processa a resposta
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = response.Content.ReadAsStringAsync().Result
                    token = Token.GetFromJson(responseContent)
                Else
                    Console.WriteLine("A solicitação falhou com o código de status: " & response.StatusCode)
                    token = Nothing
                End If
                Return token
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
                Return Nothing
            End Try
        End Function

        Public Function AsAuthorizationCode() As String
            Dim scope As String = GetUserPermission()
            Dim code As String
            Dim url As String = "https://accounts.spotify.com/authorize"
            Dim response_type As String = "code"
            Dim state As String = "34fFs29kd09"
            Dim request As HttpWebRequest = WebRequest.Create(url & "?client_id=" & _spotifyApi.ClientId &
        "&response_type=" & response_type & "&redirect_uri=" & _spotifyApi.redirect_uri & "&scope=" & scope &
        "&state=" & state)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"
            Try
                Dim response As WebResponse = request.GetResponse()
                Dim dataStreamResponse As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStreamResponse)
                Dim responseFromServer As String = reader.ReadToEnd()
                Dim reposonseUri As Uri = response.ResponseUri
                code = HttpUtility.ParseQueryString(reposonseUri.Query).Get("code")
                reader.Close()
                dataStreamResponse.Close()
                response.Close()
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
            End Try
            Console.ReadLine()
            Return code
        End Function

        Public Function getAcessTokenByCode(code As String) As String
            Try
                ' Configuração dos parâmetros no corpo da requisição
                Dim bodyParameters As New Dictionary(Of String, String)() From {
            {"grant_type", "authorization_code"},
            {"code", code},
            {"redirect_uri", _spotifyApi.redirect_uri}
        }
                Dim httpClient As New HttpClient()
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " & _authHeader)
                Dim content As New FormUrlEncodedContent(bodyParameters)
                ' Envia a solicitação POST para o Spotify
                Dim response As HttpResponseMessage = httpClient.PostAsync("https://accounts.spotify.com/api/token", content).Result

                ' Processa a resposta
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = response.Content.ReadAsStringAsync().Result
                    Console.WriteLine("Resposta do Spotify:")
                    Console.WriteLine(responseContent)
                Else
                    Console.WriteLine("A solicitação falhou com o código de status: " & response.StatusCode)
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
            End Try
        End Function

        Public Function RefreshToken(ExpiredToken As Token) As Token
            Try
                Dim TempRefreshToken As String = ExpiredToken.Refresh_token
                Dim token As Token
                Dim url As String = "https://accounts.spotify.com/api/token"
                Dim bodyParameters As New Dictionary(Of String, String)() From {
                {"grant_type", "refresh_token"},
                {"refresh_token", ExpiredToken.Refresh_token}
            }
                Dim httpClient As New HttpClient()
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " & _authHeader)
                Dim content As New FormUrlEncodedContent(bodyParameters)
                Dim response As HttpResponseMessage = httpClient.PostAsync(url, content).Result
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = response.Content.ReadAsStringAsync().Result
                    token = Token.GetFromJson(responseContent)
                Else
                    Console.WriteLine("A solicitação falhou com o código de status: " & response.StatusCode)
                    token = Nothing
                End If
                token.Refresh_token = TempRefreshToken
                Return token
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o token de acesso: " & ex.Message)
                Return Nothing
            End Try
        End Function
        Private Function GetUserPermission() As String
            Return "user-read-playback-state " &
               "user-modify-playback-state " &
               "user-read-currently-playing " &
               "app-remote-control " &
               "streaming " &
               "playlist-read-private " &
               "playlist-read-collaborative " &
               "playlist-modify-private " &
               "playlist-modify-public " &
               "user-follow-modify " &
               "user-follow-read " &
               "user-read-playback-position " &
               "user-top-read " &
               "user-read-recently-played " &
               "user-library-modify " &
               "user-library-read " &
               "user-read-email " &
               "user-read-private "
        End Function


        Private Function ExtrairCodeDaUrl(url As String) As String
            Try
                Dim pattern As String = "code=([^&]+)"
                Dim match As Match = Regex.Match(url, pattern)

                If match.Success Then
                    Dim codeValue As String = match.Groups(1).Value
                    Return codeValue
                Else
                    Console.WriteLine("O parâmetro 'code' não foi encontrado na URL.")
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao extrair o código da URL: " & ex.Message)
                Return Nothing
            End Try
        End Function
    End Class
End Namespace