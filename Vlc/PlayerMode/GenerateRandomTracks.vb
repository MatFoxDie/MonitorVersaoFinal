Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models
Imports vlcPlayer.Config

Public Class GenerateRandomTracks
    Private _spotifyApi As SpotifyApi
    Private _xmlManager As XmlManager
    Private _trazerMaximo As Boolean
    Sub New(trazerMaximo As Boolean, spotifyApi As SpotifyApi)
        _spotifyApi = spotifyApi
        _xmlManager = New XmlManager()
        _trazerMaximo = trazerMaximo
    End Sub
    Public Async Function GetRandomTracks(maxTracks As Integer) As Task(Of List(Of Track))
        Try
            Dim categoriasSelecionadas As List(Of XmlCategoria) = New List(Of XmlCategoria)
            categoriasSelecionadas = _xmlManager.GetCategorias()
            Dim playlistsID As List(Of String) = New List(Of String)
            If categoriasSelecionadas Is Nothing OrElse categoriasSelecionadas.Count = 0 Then
                Dim listaCategorias = _spotifyApi.GetCategories(0, 50)
                Dim categorias = listaCategorias.categories.items
                categorias = EmbaralharCategorias(categorias).Take(5).ToList()
                Dim playlistTask = New List(Of Task(Of PlaylistResponse))
                For Each categoria In categorias
                    playlistTask.Add(_spotifyApi.getPlaylistByCategory(categoria.id))
                Next
                Await Task.WhenAll(playlistTask)
                For Each task In playlistTask
                    Dim playlists = task.Result
                    playlistsID.Add(playlists.playlists.items(0).id)
                Next
            Else
                categoriasSelecionadas = EmbaralharCategorias(categoriasSelecionadas).Take(5).ToList()
                Dim playlistTask = New List(Of Task(Of PlaylistResponse))
                For Each categoria In categoriasSelecionadas
                    playlistTask.Add(_spotifyApi.getPlaylistByCategory(categoria.Id))
                Next
                Await Task.WhenAll(playlistTask)
                For Each task In playlistTask
                    Dim playlists = task.Result
                    playlistsID.Add(playlists.playlists.items(0).id)
                Next
            End If
            Dim tracks = GetTrackInRandom(playlistsID, maxTracks)
            For Each track In tracks
                track.FromPlaylistId = "Random"
            Next
            Return tracks
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function GetTrackInRandom(playlistsID As List(Of String), maxTracks As Integer) As List(Of Track)
        Try
            Dim tracks As List(Of Track) = New List(Of Track)
            Dim TaskTracks = New List(Of Task(Of PlaylistInfo))
            For Each playlistId In playlistsID
                TaskTracks.Add(_spotifyApi.GetPlaylistInfo(playlistId, _trazerMaximo))
            Next
            Task.WaitAll(TaskTracks.ToArray())
            For Each task In TaskTracks
                Dim playlistInfo = task.Result
                tracks.AddRange(playlistInfo.tracks.items.Select(Function(trackItem) trackItem.track).ToList())
            Next

            tracks = EmbaralharTracks(tracks)
            Return tracks.Take(maxTracks).ToList()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function EmbaralharTracks(tracks As List(Of Track)) As List(Of Track)
        Try
            Dim random As Random = New Random()
            Dim tracksEmbaralhadas As List(Of Track) = New List(Of Track)
            While tracks.Count > 0
                Dim index = random.Next(0, tracks.Count)
                tracksEmbaralhadas.Add(tracks(index))
                tracks.RemoveAt(index)
            End While
            Return tracksEmbaralhadas
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function EmbaralharCategorias(categorias As List(Of Item)) As List(Of Item)
        Try
            Dim random As Random = New Random()
            Dim categoriasEmbaralhadas As List(Of Item) = New List(Of Item)
            While categorias.Count > 0
                Dim index = random.Next(0, categorias.Count)
                categoriasEmbaralhadas.Add(categorias(index))
                categorias.RemoveAt(index)
            End While
            Return categoriasEmbaralhadas
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function EmbaralharCategorias(categorias As List(Of XmlCategoria)) As List(Of XmlCategoria)
        Try
            Dim random As Random = New Random()
            Dim categoriasEmbaralhadas As List(Of XmlCategoria) = New List(Of XmlCategoria)
            While categorias.Count > 0
                Dim index = random.Next(0, categorias.Count)
                categoriasEmbaralhadas.Add(categorias(index))
                categorias.RemoveAt(index)
            End While
            Return categoriasEmbaralhadas
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
