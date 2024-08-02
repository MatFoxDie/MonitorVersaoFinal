Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Namespace Spotify.Api
    Public Class SpotifyApi
        Private Property _currentDevice As Device
        Public Property ClientId As String
        Public Property ClientSecret
        Public Property Token As Token
        Public Property Url As String
        Public Property grant_type As String
        Public Property Code As String
        Public Property redirect_uri As String
        Public Property Userlogago As Boolean = False

        Private _autenticadorSpotify As AutenticadorSpotify
        Sub New()
            ReadXml()
            Url = "https://accounts.spotify.com/api/token"
            grant_type = "client_credentials"
            _autenticadorSpotify = New AutenticadorSpotify(Me)
        End Sub

        Private Sub ReadXml()
            Dim xmlManager As New XmlManager()
            Dim config As Config = xmlManager.GetConfig()
            ClientId = config.ClientId
            ClientSecret = config.ClientSecret
            redirect_uri = config.RedirectUri
            Dim tokenAsJason = config.Token
            Token = Token.GetFromJson(tokenAsJason)
        End Sub
        Function GetAlbumById(AlbumId As String) As Album
            Try
                Return New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetAlbum(AlbumId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of Album)()
            Catch ex As Exception
                Console.WriteLine("Erro ao obter os álbuns: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetAlbumById(AlbumId) ' Tenta novamente após renovar o token
                End If
            End Try
        End Function

        Public Sub PauseTrack()
            Try
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes("{}")
                Dim response = New RequestBuilder().
            EndPoint(SpotifyEndPoints.Pause()).
            Method("PUT").
            WithToken(Token).
            WithData("{}").
            Execute(Of String)
            Catch ex As Exception
                Console.WriteLine("Erro ao fazer a solicitação PUT: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    PauseTrack() ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        Public Sub ResumeTrack()
            Try
                Dim response = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.Play(_currentDevice.Id)).
                    Method("PUT").
                    WithToken(Token).
                    WithData("{}").
                    Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao retomar a reprodução: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    ResumeTrack() ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        'end point apenas para continhas premium
        Function PlayTrack(trackUri As String) As String
            _currentDevice = GetAvailableDevices()
            Dim contextUri As String = trackUri
            Dim position As Integer = 0 ' Define a posição da playlist a tocar
            Dim positionMs As Integer = 0 ' Define a posição da música a tocar

            ' Define o corpo da requisição JSON
            Dim postData As String = "{""uris"":[""" & contextUri & """],""offset"":{""position"":" & position & "},""position_ms"":" & positionMs & "}"

            Try
                Dim response = New RequestBuilder().
                                EndPoint(SpotifyEndPoints.Play(_currentDevice.Id)).
                                Method("PUT").
                                WithToken(Token).
                                WithData(postData).
                                Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao iniciar a reprodução:")
                Console.WriteLine(ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    PlayTrack(trackUri) ' Tenta novamente após renovar o token
                ElseIf ex.Message.Contains("404") Then
                    Console.WriteLine("Erro ao fazer a solicitação PUT: " & ex.Message)
                    GetAvailableDevices() ' Obtém dispositivos disponíveis novamente
                End If
            End Try
        End Function

        Function PlayTrack(playlistId As String, position As Integer) As String
            _currentDevice = GetAvailableDevices()
            'Dim defaultContextUri = "spotify:album:5ht7ItJgpBH7W6vJ5BqpPr"
            Dim contextUri As String = "spotify:playlist:" & playlistId
            Dim positionMs As Integer = 0 ' Define a posição da música a tocar
            ' Define o corpo da requisição JSON
            Dim postData As String = "{""context_uri"":""" & contextUri & """,""offset"":{""position"":" & position & "},""position_ms"":" & positionMs & "}"

            Try
                Dim response = New RequestBuilder().
                                EndPoint(SpotifyEndPoints.Play(_currentDevice.Id)).
                                Method("PUT").
                                WithToken(Token).
                                WithData(postData).
                                Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao iniciar a reprodução:")
                Console.WriteLine(ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    PlayTrack(playlistId, position) ' Tenta novamente após renovar o token
                ElseIf ex.Message.Contains("404") Then
                    Console.WriteLine("Erro ao fazer a solicitação PUT: " & ex.Message)
                    GetAvailableDevices() ' Obtém dispositivos disponíveis novamente
                End If
            End Try
        End Function

        Public Function getFeaturedPlaylist(offset As Integer, limit As Integer) As PlaylistResponse
            ' Limita o valor de limit para no máximo 50 e o valor de offset para no mínimo 0
            limit = Math.Max(1, Math.Min(limit, 50))
            offset = Math.Max(0, offset)
            Try
                Dim featuredPlaylist As PlaylistResponse = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetBrowseFeaturedPlaylists(limit, offset)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of PlaylistResponse)()

                Return featuredPlaylist
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as playlists em destaque: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return getFeaturedPlaylist(offset, limit) ' Tenta novamente após renovar o token
                End If
            End Try
        End Function

        Public Async Function getPlaylistByCategory(categoryId As String) As Task(Of PlaylistResponse)
            Try
                Dim featuredPlaylist As PlaylistResponse = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetPlaylistByCategory(categoryId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of PlaylistResponse)()

                Return featuredPlaylist
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as playlists em destaque: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    getPlaylistByCategory(categoryId) ' Tenta novamente após renovar o token
                End If
            End Try
        End Function

        Public Function GetCategories(offset As Integer, limit As Integer) As CategoriesResponse
            limit = Math.Max(1, Math.Min(limit, 50))
            offset = Math.Max(0, offset)

            Try
                Dim categories As CategoriesResponse = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetBrowseCategories(limit, offset)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of CategoriesResponse)()

                For Each item In categories.categories.items
                    item.type = "categoria"
                Next

                Return categories
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as categorias: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetCategories(offset, limit) ' Tenta novamente após renovar o token
                End If
            End Try
        End Function

        Public Function GetAvailableDevices() As Device
            Dim deviceList As DeviceList = New DeviceList()
            Try
                deviceList = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetAvaibleDevices()).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of DeviceList)()
                If deviceList.Devices.Count > 0 Then
                    ' Verifica se há um dispositivo do tipo "computer" com o nome "Web Player (Chrome)"
                    Dim device = deviceList.Devices.Find(Function(d) d.Type = "Computer" AndAlso d.Name = "Web Player (Microsoft Edge)")
                    If device IsNot Nothing Then
                        Return device
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao obter os dispositivos disponíveis: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetAvailableDevices() ' Tenta novamente após renovar o token
                End If
            End Try
            Return New Device()
        End Function

        Public Function getTracks(playlistId As String) As TrackResponse
            Dim tracks As TrackResponse = New TrackResponse()
            Try
                tracks = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetTracks(playlistId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of TrackResponse)()
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as faixas da playlist: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return getTracks(playlistId) ' Tenta novamente após renovar o token
                End If
            End Try
            Return tracks
        End Function

        Public Async Function GetPlaylistInfo(playlistId As String, bringAll As Boolean) As Task(Of PlaylistInfo)
            Try
                Dim playlistInfo As PlaylistInfo = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetPlaylistInfo(playlistId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of PlaylistInfo)()
                If bringAll Then
                    playlistInfo.tracks.items = playlistInfo.tracks.items.
                   Where(Function(item) item.track IsNot Nothing).ToList()
                Else
                    playlistInfo.tracks.items = playlistInfo.tracks.items.
                    Where(Function(item) item.track IsNot Nothing).Take(15).
                    ToList()

                End If


                setPlaylistIdOnTrack(playlistInfo, playlistId)

                Return playlistInfo
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as informações da playlist: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    GetPlaylistInfo(playlistId, bringAll) ' Tenta novamente após renovar o token
                End If
            End Try
        End Function


        Public Function Search(searchVal As String) As SearchResult
            searchVal.Replace(" ", "+")
            Try
                Dim searchResult As SearchResult = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.getSearch(searchVal, 4)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of SearchResult)()
                For Each item In searchResult.Tracks.items
                    item.images = buscarImagem(item.id)
                Next
                Return searchResult
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as informações da playlist: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return Search(searchVal) ' Tenta novamente após renovar o token
                End If
            End Try


        End Function
        Private Function buscarImagem(trackId) As List(Of Image)
            Dim images As List(Of Image) = New List(Of Image)()
            Try
                Dim track As Track = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetTrack(trackId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of Track)()
                ' Verifica se o objeto de faixa retornado não é nulo e se possui imagens do álbum
                If track IsNot Nothing AndAlso track.album IsNot Nothing AndAlso track.album.images IsNot Nothing Then
                    images = track.album.images
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as imagens da faixa: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return buscarImagem(trackId) ' Tenta novamente após renovar o token
                End If
            End Try

            Return images
        End Function

        Public Function getTrack(trackId As String) As Track
            Dim track As Track = New Track()
            Try
                track = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetTrack(trackId)).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of Track)()
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as informações da playlist: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return getTrack(trackId) ' Tenta novamente após renovar o token
                End If
            End Try
            Return track
        End Function

        Public Sub SetPlaybackVolume(volume As Integer)
            Try
                Dim response = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.SetVolume(volume)).
                    Method("PUT").
                    WithData("{""volume_percent"":" & volume & "}").
                    WithToken(Token).
                    Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao definir o volume de reprodução: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    SetPlaybackVolume(volume) ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        Public Sub SkipToNext()
            Try
                Dim response = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.SkipToNext()).
                    Method("POST").
                    WithData("{}").
                    WithToken(Token).
                    Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao passar para a próxima faixa: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    SkipToNext() ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        Public Sub SkipToPrevious()
            Try
                Dim response = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.SkipToPrevious()).
                    Method("POST").
                    WithData("{}").
                    WithToken(Token).
                    Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao passar para a faixa anterior: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    SkipToPrevious() ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        Public Function GetPlaybackState() As DeviceStatus
            Dim playbackState As DeviceStatus
            Try
                playbackState = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetPlaybackState()).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of DeviceStatus)()
                Return playbackState
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o estado de reprodução: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetPlaybackState() ' Tenta novamente após renovar o token
                End If
            End Try
            Return playbackState
        End Function


        Public Function GetCurrentUserProfile() As SpotifyUser
            Try
                Dim userProfile As SpotifyUser = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.GetCurrentUserProfile()).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of SpotifyUser)()
                Return userProfile
            Catch ex As Exception
                Console.WriteLine("Erro ao obter o perfil do usuário: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetCurrentUserProfile() ' Tenta novamente após renovar o token
                End If
                If ex.Message.Contains("403") Then
                    Console.WriteLine("Erro ao obter o perfil do usuário: " & ex.Message)
                    Return Nothing
                End If
            End Try
        End Function

        Public Sub SeekToPosition(positionMs As Integer)
            Try
                Dim response = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.SeekToPosition(positionMs)).
                    Method("PUT").
                    WithData("{""position_ms"":" & positionMs & "}").
                    WithToken(Token).
                    Execute(Of Object)()
            Catch ex As Exception
                Console.WriteLine("Erro ao definir a posição de reprodução: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    SeekToPosition(positionMs) ' Tenta novamente após renovar o token
                End If
            End Try
        End Sub

        Public Function GetRandomPlaylistId() As Item
            Try
                Dim playlists As Playlists = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.UsersPlaylists()).
                    Method("GET").
                    WithToken(Token).
                    Execute(Of Playlists)()
                If playlists.items.Count > 0 Then
                    Return playlists.items.Where(Function(p) p.name.Contains("Random")).FirstOrDefault()
                End If
            Catch ex As Exception
                Console.WriteLine("Erro ao obter as playlists em destaque: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return GetRandomPlaylistId() ' Tenta novamente após renovar o token
                End If
            End Try

        End Function

        Public Function CreateRandomPlaylist() As Item
            Dim userId = GetCurrentUserProfile().id
            Dim playlistName = "Random"
            Dim playlistDescription = "Playlist"
            Dim playlistPublic = False
            Dim playlistCollaborative = True
            Try
                Dim playlist As Item = New RequestBuilder().
                    EndPoint(SpotifyEndPoints.CreatePlaylist(userId)).
                    Method("POST").
                    WithToken(Token).
                    WithData("{""name"":""" & playlistName & """,""description"":""" & playlistDescription & """,""public"":" & playlistPublic & ",""collaborative"":" & playlistCollaborative & "}").
                    Execute(Of Item)()
                Return playlist
            Catch ex As Exception
                Console.WriteLine("Erro ao criar a playlist: " & ex.Message)
                If ex.Message.Contains("401") Then
                    Token = _autenticadorSpotify.RefreshToken(Token)
                    Return CreateRandomPlaylist() ' Tenta novamente após renovar o token
                End If
            End Try

        End Function

        Private Sub setPlaylistIdOnTrack(plalistInfo As PlaylistInfo, playlistId As String)
            For Each item In plalistInfo.tracks.items
                item.track.FromPlaylistId = playlistId
            Next
        End Sub

        Public Sub PlaylistRemoveTracks(id As String)
            Dim tracksFromId = getTracks(id)
            If tracksFromId IsNot Nothing Then
                For Each item In tracksFromId.items
                    Dim trackId = item.track.id
                    Dim response = New RequestBuilder().
                        EndPoint(SpotifyEndPoints.RemoveTrack(id, trackId)).
                        Method("DELETE").
                        WithToken(Token).
                        WithData("{""tracks"":[{""uri"":""spotify:track:" & trackId & """}]}").
                        Execute(Of Object)()
                Next
            End If

        End Sub
    End Class
End Namespace