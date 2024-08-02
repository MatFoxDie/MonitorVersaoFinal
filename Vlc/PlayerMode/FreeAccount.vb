Imports System.Threading
Imports Microsoft.Web.WebView2.WinForms
Imports Spotify
Imports Spotify.Spotify.Api.Models

Public Class FreeAccount
    Implements IAccount
    Private _webview As WebView2

    Public Sub New(webview As WebView2)
        _webview = webview
    End Sub
    Public Async Sub PlaySingleTrack(track As Track) Implements IAccount.PlaySingleTrack
        Try
            Dim spotfiyUrl = "https://open.spotify.com/track/" & track.id
            _webview.CoreWebView2.Navigate(spotfiyUrl)
            Thread.Sleep(2000)
            Dim texto = Await _webview.CoreWebView2.ExecuteScriptAsync(JavaScriptCommands.PlayGreenButton)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub PlayTrackInPlaylist(playlistId As String, position As Integer) Implements IAccount.PlayTrackInPlaylist
        MessageBox.Show("Somente para conta Premium")
    End Sub

    Public Async Sub StartPlaylist(playlistId As String) Implements IAccount.StartPlaylist
        Try
            Dim spotfiyUrl = "https://open.spotify.com/playlist/" & playlistId
            _webview.CoreWebView2.Navigate(spotfiyUrl)
            Thread.Sleep(2000)
            Dim texto = Await _webview.CoreWebView2.ExecuteScriptAsync(JavaScriptCommands.PlayGreenButton)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetVolume(value As Integer) Implements IAccount.SetVolume

    End Sub

    Public Sub SetPosition(value As Double) Implements IAccount.SetPosition
    End Sub
End Class
