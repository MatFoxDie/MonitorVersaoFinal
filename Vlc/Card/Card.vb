Imports System.IO
Imports System.Net
Imports Spotify.Spotify.Api.Models

Namespace Vlc.Card
    Public Class Card
        Property Id As String
        Property Name As String
        Property Type As ECardType
        Property Description As String
        Property Image As Drawing.Image
        Property Status As ECardStatus
        Property Size As Size
        Property Tag As Object
        Sub New()
        End Sub
        Sub New(track As Track)
            Me.Id = track.id
            Me.Name = track.name
            Me.Type = ECardType.Track
            Me.Description = track.artists(0).name
            Me.Image = getImageFromUrl(track.album.images(0).url)
            Me.Status = ECardStatus.Completed
            Me.Size = New Size(200, 220)
            Me.Tag = track
        End Sub

        Sub New(item As Item)
            Me.Id = item.id
            Me.Name = item.name
            Me.Type = getTipo(item.type)
            Me.Description = ""
            Dim UrlImage = getUrlImage(item)
            Me.Image = getImageFromUrl(UrlImage)
            Me.Status = ECardStatus.Completed
            Me.Size = New Size(200, 200)
            Me.Tag = item
        End Sub

        Private Function getTipo(tipo As String) As ECardType
            Select Case tipo
                Case "playlist"
                    Return ECardType.Playlist
                Case "album"
                    Return ECardType.Album
                Case "track"
                    Return ECardType.Track
                Case "categoria"
                    Return ECardType.Category
                Case "feateredPlaylists"
                    Return ECardType.FeateredPlaylists
                Case Else
                    Return ECardType.Playlist
            End Select
        End Function

        Private Function getUrlImage(Item As Item) As String
            Select Case Item.type
                Case "playlist", "album"
                    Return Item.images(0).url
                Case "categoria", "feateredPlaylists"
                    Return Item.icons(0).url
                Case Else
                    Return Item.icons(0).url
            End Select
        End Function

        Public Sub InDownloadStatus()
            Me.Status = ECardStatus.InDownloadProgress
            Me.Image = My.Resources.loading
        End Sub

        Private Function getImageFromUrl(url As String)
            Dim request As WebRequest = WebRequest.Create(url)
            Dim response As WebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim bitmap As New Bitmap(responseStream)
            responseStream.Close()
            Return bitmap

        End Function

        Public Function GetCardEmDestaque() As Card
            Dim card As New Card
            card.Id = "1"
            card.Name = "Em destaque"
            card.Type = ECardType.FeateredPlaylists
            card.Image = My.Resources.em_destaque
            card.Size = New Size(200, 200)
            Return card
        End Function

    End Class
End Namespace
