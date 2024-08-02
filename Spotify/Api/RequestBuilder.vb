Imports Newtonsoft.Json
Imports Spotify.Spotify.Api
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms.VisualStyles
Namespace Spotify.Api
    Friend Class RequestBuilder
        Private _endPoint As String
        Private _method As String
        Private _token As Token
        Private _contentLength As Long
        Private _byteArray As Byte()
        Public Sub New()
            ' Configurações padrão, você pode ajustar conforme necessário
            _method = "GET"
        End Sub

        Public Function EndPoint(endPointUrl As String) As RequestBuilder
            _endPoint = endPointUrl
            Return Me
        End Function

        Public Function Method(methodType As String) As RequestBuilder
            _method = methodType
            Return Me
        End Function

        Public Function WithToken(token As Token) As RequestBuilder
            _token = token
            Return Me
        End Function

        Public Function WithData(data As String) As RequestBuilder
            _byteArray = Encoding.UTF8.GetBytes(data)
            _contentLength = _byteArray.Length
            Return Me
        End Function

        Public Function Execute(Of T)() As T
            Dim request As HttpWebRequest = WebRequest.Create(_endPoint)
            If _token IsNot Nothing Then
                request.Headers.Add("Authorization", "Bearer " & _token.Access_token)
            End If
            request.ContentType = "application/json"
            request.Method = _method

            If _contentLength > 0 Then
                request.ContentLength = _byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(_byteArray, 0, _byteArray.Length)
                dataStream.Close()
            End If

            Dim responseString As String = String.Empty
            Try
                Using response As WebResponse = request.GetResponse()
                    Using dataStream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(dataStream)
                            responseString = reader.ReadToEnd()
                        End Using
                    End Using
                End Using
                Return JsonConvert.DeserializeObject(Of T)(responseString)
            Catch ex As Exception
                Console.WriteLine("Erro ao executar a solicitação: " & ex.Message)
                Throw ' Lança a exceção para que seja tratada pelo chamador
            End Try
        End Function
    End Class
End Namespace