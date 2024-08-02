Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Public Delegate Sub BatchesInDownloadEventHandler(sender As Object, e As BatchesInDownloadEventArgs)
Public Class BatchesInDownloadEventArgs
    Inherits EventArgs
    Public Property Tracks As List(Of Track)
    Public Sub New(tracks As List(Of Track))
        Me.Tracks = tracks
    End Sub

End Class
