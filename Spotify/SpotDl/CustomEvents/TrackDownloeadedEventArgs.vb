Imports Spotify.SpotDl.Models
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Imports Spotify.Spotify.SpotDl.Models

Namespace Spotify.SpotDl.CustomEvents
    Public Delegate Sub TrackDownloadedEventHandler(sender As Object, e As TrackDownloeadedEventArgs)
    Public Class TrackDownloeadedEventArgs
        Inherits EventArgs
        Public Property Track As Track
        Sub New(track As Track)
            Me.Track = track
        End Sub
    End Class
End Namespace

