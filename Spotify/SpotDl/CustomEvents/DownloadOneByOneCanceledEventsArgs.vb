Imports Spotify.Spotify.Api.Models
Public Delegate Sub DownloadOneByOneCanceledEventHandler(sender As Object, e As DownloadOneByOneCanceledEventsArgs)
Public Class DownloadOneByOneCanceledEventsArgs
    Inherits EventArgs
    Public Property LastTrackDownloeaded As Track
    Sub New(track As Track)
        Me.LastTrackDownloeaded = track
    End Sub


End Class
