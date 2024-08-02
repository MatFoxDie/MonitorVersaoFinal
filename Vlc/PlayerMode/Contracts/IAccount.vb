Imports Spotify.Spotify.Api.Models

Public Interface IAccount
    Sub PlaySingleTrack(track As Track)
    Sub PlayTrackInPlaylist(playlistId As String, position As Integer)
    Sub StartPlaylist(playlistId As String)
    Sub SetVolume(value As Integer)
    Sub SetPosition(value As Double)
End Interface
