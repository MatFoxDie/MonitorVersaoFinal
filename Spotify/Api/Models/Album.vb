Namespace Spotify.Api.Models
    Public Class Album
        Public Property tracks As Tracks
        Public Property copyrights As List(Of Copyright)
        Public Property external_ids As ExternalIds
        Public Property genres As List(Of String)
        Public Property label As String
        Public Property popularity As Integer
        Public Property album_type As String
        Public Property total_tracks As Integer
        Public Property available_markets As List(Of String)
        Public Property external_urls As ExternalUrls
        Public Property href As String
        Public Property id As String
        Public Property images As List(Of Image)
        Public Property name As String
        Public Property release_date As String
        Public Property release_date_precision As String
        Public Property restrictions As Restrictions
        Public Property type As String
        Public Property uri As String
        Public Property artists As List(Of Artist)

    End Class

End Namespace