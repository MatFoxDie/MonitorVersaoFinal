Namespace Spotify.Api.Models

    Public Class Artist
        Public Property external_urls As ExternalUrls
        Public Property followers As Followers
        Public Property genres As List(Of String)
        Public Property href As String
        Public Property id As String
        Public Property images As List(Of Image)
        Public Property name As String
        Public Property popularity As Integer
        Public Property type As String
        Public Property uri As String
    End Class
End Namespace