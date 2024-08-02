Namespace Spotify.Api.Models

    Public Class Categories
        Public Property href As String
        Public Property limit As Integer
        Public Property [next] As String
        Public Property offset As Integer
        Public Property previous As String
        Public Property total As Integer
        Public Property items As List(Of Item)
    End Class
End Namespace