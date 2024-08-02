
Imports System.Diagnostics.Eventing.Reader
Imports System.Threading
Imports System.Timers
Imports Spotify
Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Imports Spotify.Spotify.SpotDl.CustomEvents
Imports Vlc.DotNet.Core.Interops.Signatures
Imports Vlc.DotNet.Forms
Imports vlcPlayer.Controls
Imports vlcPlayer.Vlc.Card

Public Class AsLocalPlayer
    Implements IPlayer

    Private _frm As frmVLC
    Private _timer As System.Timers.Timer
    Private _vlcManager As VlcManager
    Private _gerarRandomTracks As GenerateRandomTracks
    Sub New(frm As frmVLC, spotifyApi As SpotifyApi)
        _frm = frm
        _vlcManager = New VlcManager(frm)
        _gerarRandomTracks = New GenerateRandomTracks(False, spotifyApi)
        InitTimer()
    End Sub

    Public Property VlcManager As VlcManager
        Get
            Return Nothing
        End Get
        Set(value As VlcManager)
        End Set
    End Property

    Private Sub InitTimer()
        Try
            _timer = New System.Timers.Timer()
            _timer.Interval = 1000
            _timer.Start()
            AddHandler _timer.Elapsed, AddressOf TimerElapsed
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub TimerElapsed(sender As Object, e As ElapsedEventArgs)
        Try
            _frm.BeginInvoke(Sub()
                                 updateTimeLabels(_vlcManager.GetCurrentTime, _vlcManager.GetTotalTime, _vlcManager.GetCurrentPosition)
                             End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub PlayPause() Implements IPlayer.PlayPause
        Try
            _vlcManager.PlayPause()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub PlaylistClick(playlistId As String) Implements IPlayer.PlaylistClick
        Try
            _frm.flpCards.Navegacao = ENavegation.InMusics
            Dim playlistInfo = Await _frm._spotifyApi.GetPlaylistInfo(playlistId, False)
            Dim playListName As String = playlistInfo.name
            Dim trackList As List(Of Track) = playlistInfo.tracks.items.Select(Function(trackItem) trackItem.track).ToList()
            _vlcManager.StartPlaylistDownload(trackList, playListName, playlistId)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub



    Public Sub TrackClick(panelCliked As Panel, track As Track, pictureBox As PictureBox, panels As List(Of Panel)) Implements IPlayer.TrackClick
        Try
            Dim card As Card = panelCliked.Tag
            If card.Status = ECardStatus.InDownloadProgress Then
                MessageBox.Show("A música ainda está sendo baixada")
                Return
            End If
            If _frm.flpCards.Navegacao = ENavegation.InSearch Then
                _frm.desabilitarOutrosCardNoPanel(panelCliked, panels)
                _frm.flpCards.Navegacao = ENavegation.InMusics
                _frm.pnlDescricao.Enabled = False
                pictureBox.Image = My.Resources.loading
                _vlcManager.playSingleTrack(track)
                Return
            End If

            _vlcManager.vlcPlayIndex(track)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub pararProcessos() Implements IPlayer.pararProcessos
        Try
            _vlcManager.PararProcessosDeDownload()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub IniciarModoAleatorio() Implements IPlayer.IniciarModoAleatorio
        Try
            pararProcessos()
            _frm.pnlDescricao.Enabled = False
            If _frm.flpCards.Navegacao <> ENavegation.InMusics Then
                _frm.flpCards.Navegacao = ENavegation.InMusics
            Else
                _frm.flpCards.Controls.Clear()
            End If
            Dim tracks = Await _gerarRandomTracks.GetRandomTracks(15)
            _vlcManager.StartPlaylistDownload(tracks, "Random", "Random")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SkipToNext() Implements IPlayer.SkipToNext
        Try
            _vlcManager.changeVideoTo(1)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SkipToPrevious() Implements IPlayer.SkipToPrevious
        Try
            _vlcManager.changeVideoTo(-1)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub PnlDescricaoClick() Implements IPlayer.PnlDescricaoClick
        Dim currentTrack As Track = _frm.pnlDescricao.Tag
        If currentTrack Is Nothing Then
            Return
        End If
        Try
            If _frm._modoAleatorio Then
                Dim randomTracks = Await _gerarRandomTracks.GetRandomTracks(15)
                _vlcManager.AbrirPLaylistNaDescricao(randomTracks, "Random")
            Else
                Dim playlistInfo = Await _frm._spotifyApi.GetPlaylistInfo(currentTrack.FromPlaylistId, False)
                Dim trackList As List(Of Track) = playlistInfo.tracks.items.Select(Function(trackItem) trackItem.track).ToList()
                _vlcManager.AbrirPLaylistNaDescricao(trackList, playlistInfo.name)
            End If
        Catch
            Return
        End Try
    End Sub

    Public Sub FinalizarProcessos() Implements IPlayer.FinalizarProcessos
        Try
            _timer.Stop()
            _timer.Dispose()
            _vlcManager.StopPlay()
            _frm.picAleatorio.Image = My.Resources.aleatorio
            _frm.lblCurrentTrack.Text = ""
            _frm.lblCurretArtist.Text = ""
            _frm.picCurrentPlaying.Image = Nothing
            _frm.lblCurrentTime.Text = "00:00"
            _frm.lblEndTime.Text = "00:00"
            _frm.pnlBuffer.Width = 0
            _frm.pnlProgresIn.Width = 0
            _frm.picPlay.Image = My.Resources.toque
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub updateTimeLabels(videoTime As Long, totalLengh As Long, currentPosition As Single)
        Try
            _frm.lblCurrentTime.Text = VlcTimeTostring(videoTime)
            _frm.lblEndTime.Text = VlcTimeTostring(totalLengh)
            _frm.pnlProgresIn.Width = _frm.pnlProgressOut.Width * currentPosition
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetVolume(value As Integer) Implements IPlayer.SetVolume
        Try
            _vlcManager.setVolume(value)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetPosition(value As Double) Implements IPlayer.SetPosition
        Try
            _vlcManager.SetPosition(value)
            _frm.BeginInvoke(Sub()
                                 updateTimeLabels(_vlcManager.GetCurrentTime, _vlcManager.GetTotalTime, _vlcManager.GetCurrentPosition)
                             End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function VlcTimeTostring(vlcTime As Long) As String
        Try
            Dim minutos As Double = vlcTime / 60000
            Dim minutosInt As Integer = Math.Floor(minutos)
            Dim segundos As Integer = (vlcTime Mod 60000) / 1000
            Return minutosInt.ToString("00") & ":" & segundos.ToString("00")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return "00:00"
        End Try
    End Function
End Class
