Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Public Delegate Sub TrackOneByOneEventHandler(sender As Object, e As TrackOneByOneEventArgs)
Public Class TrackOneByOneEventArgs
    Inherits EventArgs
    Public Property Track As Track
    Sub New(track As Track)
        Me.Track = track
    End Sub

End Class
