Imports System.IO

Namespace Spotify.Api.Models

    Public Class Track
        Public Property album As Album
        Public Property external_ids As ExternalIds
        Public Property popularity As Integer
        Public Property artists As List(Of Artist)
        Public Property available_markets As List(Of String)
        Public Property disc_number As Integer?
        Public Property duration_ms As Integer?
        Public Property explicit As Boolean?
        Public Property external_urls As ExternalUrls
        Public Property href As String
        Public Property id As String
        Public Property is_playable As Boolean
        Public Property linked_from As LinkedFrom
        Public Property restrictions As Restrictions
        Public Property name As String
        Public Property preview_url As String
        Public Property track_number As Integer
        Public Property type As String
        Public Property uri As String
        Public Property is_local As Boolean
        Public Property LocalPath As MemoryStream

        Public Property FromPlaylistId As String
        Public ReadOnly Property SpotifyUrl As String
            Get
                Return "https://open.spotify.com/track/" & id
            End Get
        End Property
        Overloads Function ToString() As String
            Return name
        End Function
    End Class
End Namespace
