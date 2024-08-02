Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.Json.Serialization
Namespace Spotify.Api.Models
    Public Class DeviceList
        <JsonPropertyName("devices")>
        Public Property Devices As List(Of Device)
    End Class
    Public Class Device
        <JsonPropertyName("id")>
        Public Property Id As String

        <JsonPropertyName("is_active")>
        Public Property IsActive As Boolean

        <JsonPropertyName("is_private_session")>
        Public Property IsPrivateSession As Boolean

        <JsonPropertyName("is_restricted")>
        Public Property IsRestricted As Boolean

        <JsonPropertyName("name")>
        Public Property Name As String

        <JsonPropertyName("type")>
        Public Property Type As String

        <JsonPropertyName("supports_volume")>
        Public Property SupportsVolume As Boolean

        Public Property volume_percent As Integer
    End Class

End Namespace
