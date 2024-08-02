Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models

Public Class PremiumAccount
    Implements IAccount
    Private _spotifyApi As SpotifyApi
    Public Sub New(spotifyApi As SpotifyApi)
        _spotifyApi = spotifyApi
    End Sub
    Public Sub PlaySingleTrack(track As Track) Implements IAccount.PlaySingleTrack
        Try
            _spotifyApi.PlayTrack(track.uri)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Public Sub PlayTrackInPlaylist(playlistId As String, position As Integer) Implements IAccount.PlayTrackInPlaylist
        Try
            _spotifyApi.PlayTrack(playlistId, position)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Public Sub StartPlaylist(playlistId As String) Implements IAccount.StartPlaylist
        Try
            _spotifyApi.PlayTrack(playlistId, 0)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetVolume(value As Integer) Implements IAccount.SetVolume
        Try
            _spotifyApi.SetPlaybackVolume(value * 10)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetPosition(value As Double) Implements IAccount.SetPosition
    End Sub
End Class
