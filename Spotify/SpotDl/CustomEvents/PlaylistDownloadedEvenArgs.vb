Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Imports Spotify.Spotify.SpotDl.Models
Namespace Spotify.SpotDl.CustomEvents

    Public Delegate Sub PlaylistDownloadedEventHandler(sender As Object, e As PlaylistDownloadedEvenArgs)
    Public Class PlaylistDownloadedEvenArgs
        Inherits EventArgs
        Public Property TrackList As List(Of Track)
        Sub New(trackList As List(Of Track))
            Me.TrackList = trackList
        End Sub
    End Class

End Namespace
