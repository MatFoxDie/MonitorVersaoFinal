Namespace Spotify.Api.Models

    Public Class DeviceStateResponse
        Public Property device As Device
        Public Property repeat_state As String
        Public Property shuffle_state As Boolean
        Public Property context As Context
        Public Property timestamp As Integer
        Public Property progress_ms As Integer
        Public Property is_playing As Boolean
        Public Property item As Item
        Public Property currently_playing_type As String
        Public Property actions As Actions
    End Class
End Namespace