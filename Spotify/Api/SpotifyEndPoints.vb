Imports Spotify.Spotify.Models

Namespace Spotify.Api
    Public Module SpotifyEndPoints

        Public Function Pause() As String
            Return "https://api.spotify.com/v1/me/player/pause"
        End Function

        Public Function GetAlbum(albumId As String) As String
            Return "https://api.spotify.com/v1/albums/" + albumId
        End Function
        Public Function GetAudioFeaturesForSeveralTracks() As String
            Return "https://api.spotify.com/v1/audio-features"
        End Function

        Public Function GetBrowseFeaturedPlaylists(limit As String, offset As String) As String
            Return $"https://api.spotify.com/v1/browse/featured-playlists?locale=pt_BR&limit=" & limit & "&offset=" & offset
        End Function

        Public Function GetPlaylistByCategory(categoryId As String) As String
            Return $"https://api.spotify.com/v1/browse/categories/" & categoryId & "/playlists"
        End Function

        Public Function GetBrowseCategories(limit As String, offset As String) As String
            Return "https://api.spotify.com/v1/browse/categories?locale=pt_BR&limit=" & limit & "&offset=" & offset
        End Function

        Public Function GetAvaibleDevices() As String
            Return "https://api.spotify.com/v1/me/player/devices"
        End Function

        Public Function GetTracks(playlistId As String) As String
            Return "https://api.spotify.com/v1/playlists/" & playlistId & "/tracks"
        End Function

        Public Function GetPlaylistInfo(playlistId As String) As String
            Return "https://api.spotify.com/v1/playlists/" & playlistId
        End Function

        Public Function getSearch(searchVal As String, maxResults As Integer)
            Return "https://api.spotify.com/v1/search?q=" & searchVal & "&type=playlist%2Ctrack&limit=" & maxResults
        End Function

        Public Function GetTrack(trackId As String) As String
            Return "https://api.spotify.com/v1/tracks/" & trackId
        End Function

        Public Function Play(deviceId As String) As String
            Return "https://api.spotify.com/v1/me/player/play?device_id=" & deviceId
        End Function

        Public Function SetVolume(volume As Integer) As String
            Return "https://api.spotify.com/v1/me/player/volume?volume_percent=" & volume
        End Function

        Friend Function SkipToNext() As String
            Return "https://api.spotify.com/v1/me/player/next"
        End Function

        Friend Function SkipToPrevious() As String
            Return "https://api.spotify.com/v1/me/player/previous"
        End Function

        Friend Function GetPlaybackState() As String
            Return "https://api.spotify.com/v1/me/player"
        End Function

        Friend Function GetCurrentUserProfile() As String
            Return "https://api.spotify.com/v1/me"
        End Function

        Friend Function SeekToPosition(positionMs As Integer) As String
            Return "https://api.spotify.com/v1/me/player/seek?position_ms=" & positionMs
        End Function

        Friend Function UsersPlaylists() As String
            Return "https://api.spotify.com/v1/me/playlists"
        End Function

        Friend Function CreatePlaylist(userId As String) As String
            Return "https://api.spotify.com/v1/users/" & userId & "/playlists"
        End Function

        Friend Function RemoveTrack(id As String, trackId As String) As String
            Return "https://api.spotify.com/v1/playlists/" & id & "/tracks"
        End Function
    End Module
End Namespace

