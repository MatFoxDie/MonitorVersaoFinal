Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models

Public Interface IPlayer
    Sub PlayPause()
    Sub PlaylistClick(playlistId As String)
    Sub TrackClick(panelCliked As Panel, track As Track, pictureBox As PictureBox, panels As List(Of Panel))
    Sub pararProcessos()
    Sub IniciarModoAleatorio()
    Sub SkipToNext()
    Sub SkipToPrevious()
    Sub PnlDescricaoClick()
    Sub FinalizarProcessos()
    Sub SetVolume(value As Integer)
    Sub SetPosition(value As Double)
End Interface
