Namespace Spotify.Api.Models

    Public Class Item
        Public Property collaborative As Boolean?
        Public Property description As String
        Public Property images As List(Of Image)
        Public Property owner As Owner
        Public Property [public] As Boolean?
        Public Property snapshot_id As String
        Public Property tracks As Tracks
        Public Property icons As List(Of Icon)
        Public Property added_by As AddedBy
        Public Property added_at As String
        Public Property track As Track
        Public Property album As Album
        Public Property artists As List(Of Artist)
        Public Property available_markets As List(Of String)
        Public Property disc_number As Integer
        Public Property duration_ms As Integer
        Public Property explicit As Boolean
        Public Property external_ids As ExternalIds
        Public Property external_urls As ExternalUrls
        Public Property href As String
        Public Property id As String
        Public Property is_playable As Boolean
        Public Property linked_from As Object
        Public Property restrictions As Restrictions
        Public Property name As String
        Public Property popularity As Integer
        Public Property preview_url As String
        Public Property track_number As Integer
        Public Property type As String
        Public Property uri As String
        Public Property is_local As Boolean
    End Class
End Namespace