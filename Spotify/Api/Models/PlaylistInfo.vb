Imports System.Collections.Generic
Namespace Spotify.Api.Models
    Public Class PlaylistInfo
        Public Property collaborative As Boolean
        Public Property description As String
        Public Property external_urls As ExternalUrls
        Public Property followers As Followers
        Public Property href As String
        Public Property id As String
        Public Property images As List(Of Image)
        Public Property name As String
        Public Property owner As Owner
        Public Property _public As Boolean
        Public Property snapshot_id As String
        Public Property tracks As Tracks
        Public Property type As String
        Public Property uri As String
    End Class
End Namespace