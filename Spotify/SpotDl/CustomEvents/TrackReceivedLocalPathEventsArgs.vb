Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Public Delegate Sub TrackReceivedLocalPathEventHandler(sender As Object, e As TrackReceivedLocalPathEventsArgs)
Public Class TrackReceivedLocalPathEventsArgs
    Inherits EventArgs
    Property track As Track
    Sub New(track As Track)
        Me.track = track
    End Sub
End Class
