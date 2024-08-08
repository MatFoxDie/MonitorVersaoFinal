﻿Imports System.IO
Imports System.Threading
Imports Microsoft.Web.WebView2.WinForms
Imports MonitorVersaoFinal.Services
Imports NAudio.Wave
Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models
Imports vlcPlayer.Controls
Imports vlcPlayer.Vlc.Card



Public Class AsSpotifyPlayer
    Implements IPlayer

    Private _frm As frmVLC
    Private _webview As WebView2
    Private _spotifyApi As SpotifyApi
    Private _account As IAccount
    Private _currentPlaylistId As String
    Private _currentTimerIn_sec As Integer = 0
    Private _currentTimerLength_sec As Integer = 0
    Private _timerIsRunning As Boolean = False
    Private valorDeSoma As Integer = 1
    Private _timer As System.Timers.Timer
    Private _gerarRandomTracks As GenerateRandomTracks
    Private _currentTrackList As List(Of Track)
    Private _index As Integer = 0
    Public Sub New(frm As frmVLC, webview As WebView2, spotifyApi As SpotifyApi)
        _frm = frm
        _webview = webview
        _spotifyApi = spotifyApi
        _account = GetUserTyepe()
        _gerarRandomTracks = New GenerateRandomTracks(False, _spotifyApi)
        _currentTrackList = New List(Of Track)
    End Sub

    Public Property IAccount As IAccount
        Get
            Return Nothing
        End Get
        Set(value As IAccount)
        End Set
    End Property

    Private Function GetUserTyepe() As IAccount
        Try
            Dim userLogado = _spotifyApi.GetCurrentUserProfile
            If userLogado.product = "premium" Then
                Return New PremiumAccount(_spotifyApi)
            Else
                Return New FreeAccount(_webview)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return New FreeAccount(_webview)
        End Try
    End Function

    Public Sub PlayPause() Implements IPlayer.PlayPause
        Try
            If _webview.InvokeRequired Then
                _webview.Invoke(New Action(AddressOf PlayPause))
            Else
                _webview.ExecuteScriptAsync(JavaScriptCommands.PlayPause)
                Thread.Sleep(1000)
                UpdateControls()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub PlaylistClick(playlistId As String) Implements IPlayer.PlaylistClick
        Try
            _frm.picAleatorio.Image = My.Resources.aleatorio
            _currentPlaylistId = playlistId
            OpenPlaylist(playlistId)
            _account.StartPlaylist(playlistId)
            Thread.Sleep(1000)
            Task.Run(Sub() UpdateControls())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub TrackClick(panelCliked As Panel, track As Track, pictureBox As PictureBox, panels As List(Of Panel)) Implements IPlayer.TrackClick
        Try
            Dim card As Card = panelCliked.Tag
            _index = _currentTrackList.FindIndex(Function(t) t.id = track.id)
            If _frm.flpCards.Navegacao = ENavegation.InSearch Or _frm.flpCards.Navegacao = ENavegation.InRandom Then
                _account.PlaySingleTrack(track)
            Else
                _account.PlayTrackInPlaylist(track.FromPlaylistId, _index)
            End If
            Thread.Sleep(1000)
            Task.Run(Sub() UpdateControls())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub pararProcessos() Implements IPlayer.pararProcessos
        Return
    End Sub

    Public Async Sub IniciarModoAleatorio() Implements IPlayer.IniciarModoAleatorio
        Try
            _frm.flpCards.Controls.Clear()
            Dim tracksRandomTask = _gerarRandomTracks.GetRandomTracks(40)
            OpenTrackList(Await tracksRandomTask)
            _account.PlaySingleTrack(_currentTrackList(0))
            Thread.Sleep(1000)
            Await Task.Run(Sub()
                               Thread.Sleep(100)
                               UpdateControls()
                           End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub Skip() Implements IPlayer.SkipToNext
        Try
            If _frm.flpCards.Navegacao = ENavegation.InRandom Then
                _index += 1
                If _index >= _currentTrackList.Count Then
                    _index = 0
                    IniciarModoAleatorio()
                End If
                _account.PlaySingleTrack(_currentTrackList(_index))
            Else
                _webview.CoreWebView2.ExecuteScriptAsync(JavaScriptCommands.SkipToNext)
            End If
            Thread.Sleep(1000)
            Await Task.Run(Sub()
                               Thread.Sleep(100)
                               UpdateControls()
                           End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub SkipToPrevious() Implements IPlayer.SkipToPrevious
        Try
            If _frm.flpCards.Navegacao = ENavegation.InRandom Then
                _index -= 1
                If _index < 0 Then
                    _index = _currentTrackList.Count - 1
                End If
                _account.PlaySingleTrack(_currentTrackList(_index))
            End If
            Await _webview.CoreWebView2.ExecuteScriptAsync(JavaScriptCommands.SkipToPrevious)
            Thread.Sleep(1000)
            Await Task.Run(Sub()
                               Thread.Sleep(100)
                               UpdateControls()
                           End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Async Sub UpdateControls()
        Try

            Dim playbacksate = _spotifyApi.GetPlaybackState()
            While playbacksate Is Nothing
                playbacksate = _spotifyApi.GetPlaybackState()
                Thread.Sleep(100)
            End While
            If Not _timerIsRunning Then
                StartTimer()
            End If
            If playbacksate.is_playing Then
                valorDeSoma = 1
            Else
                valorDeSoma = 0
            End If
            If playbacksate.item Is Nothing Then
                Thread.Sleep(100)
                playbacksate = _spotifyApi.GetPlaybackState()
            End If
            While playbacksate.currently_playing_type = "ad"
                Thread.Sleep(1000)
                playbacksate = _spotifyApi.GetPlaybackState()
            End While
            _currentTimerLength_sec = playbacksate.item.duration_ms / 1000
            _currentTimerIn_sec = playbacksate.progress_ms / 1000
            _frm.BeginInvoke(Sub() UpdateCamposForm(playbacksate))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub OpenTrackList(trackList As List(Of Track))
        Try
            _frm.flpCards.Navegacao = ENavegation.InRandom
            _currentTrackList = trackList
            For Each track In trackList
                Dim card = New Card(track)
                _frm._cardManager.addCard(card, _frm.flpCards)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Async Sub OpenPlaylist(playlistId As String)
        Try
            _frm.flpCards.Navegacao = ENavegation.InMusics
            Dim playlistInfo = Await _spotifyApi.GetPlaylistInfo(playlistId, True)
            Dim playListName As String = playlistInfo.name
            Dim trackList As List(Of Track) = playlistInfo.tracks.items.Select(Function(trackItem) trackItem.track).ToList()
            _frm.flpCards.Navegacao = ENavegation.InMusics
            _currentTrackList = trackList
            For Each track In trackList
                Dim card = New Card(track)
                _frm._cardManager.addCard(card, _frm.flpCards)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub PnlDescricaoClick() Implements IPlayer.PnlDescricaoClick
        Try
            If String.IsNullOrEmpty(_currentPlaylistId) Then
                Return
            End If
            OpenPlaylist(_currentPlaylistId)
            _frm.pnlDescricao.Enabled = True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub FinalizarProcessos() Implements IPlayer.FinalizarProcessos
        Try
            If _timer IsNot Nothing Then
                _timer.Stop()
                _timer.Dispose()
            End If
            _frm.picAleatorio.Image = My.Resources.aleatorio
            _frm.picPlay.Image = My.Resources.toque
            _frm.lblCurrentTrack.Text = ""
            _frm.lblCurretArtist.Text = ""
            _frm.picCurrentPlaying.Image = Nothing
            _frm.lblCurrentTime.Text = "00:00"
            _frm.lblEndTime.Text = "00:00"
            _frm.pnlBuffer.Width = 0
            _frm.pnlProgresIn.Width = 0
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub StartTimer()
        Try
            _timerIsRunning = True
            _timer = New System.Timers.Timer(1000)
            _timer.Interval = 1000
            AddHandler _timer.Elapsed, AddressOf timertick
            _timer.Start()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Dim qtdeDeVezes As Integer = 0

    Private Async Sub timertick(sender As Object, e As Timers.ElapsedEventArgs)
        Try
            If _timer Is Nothing Then
                Return
            End If
            _currentTimerIn_sec += valorDeSoma
            Dim time = ContertSecToTime(_currentTimerIn_sec)
            _frm.lblCurrentTrack.BeginInvoke(Sub() _frm.lblCurrentTime.Text = time)
            If _currentTimerIn_sec >= _currentTimerLength_sec + 2 Then
                _currentTimerIn_sec = 0
                If _frm.flpCards.Navegacao = ENavegation.InRandom Then
                    _index += 1
                    If _index >= _currentTrackList.Count Then
                        _index = 0
                        _frm.BeginInvoke(Sub()
                                             IniciarModoAleatorio()
                                         End Sub)
                    End If

                    _account.PlaySingleTrack(_currentTrackList(_index))
                End If


                'Qtdedevezes = quantidade de musicas tocadas antes de tocar o anuncio
                If qtdeDeVezes = 1 Then
                    'Carrega as configurações do painel de configurações
                    Dim xmlPainelConfig As XmlReaderService = New XmlReaderService()
                    xmlPainelConfig.LoadRssSources("rssFeeds.xml")

                    If xmlPainelConfig.RssConfiguracoes.Anuncio = 1 Then

                        Dim aleatorio As New Random()
                        Dim numeroAleatorio As Integer = aleatorio.Next(1, 10)

                        'Verifica se existe o audio de propaganda aonde é "anuncio" & numeroAleatorio & ".wav"
                        If Not File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Audios", "anuncio" & numeroAleatorio & ".wav")) Then
                            numeroAleatorio = 1
                        End If

                        Dim audio As String = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Audios", "anuncio" & numeroAleatorio & ".wav")

                        'Pausa a música
                        If playerInstance IsNot Nothing Then
                            playerInstance.PlayPause()
                        End If

                        'Toca o audio de propaganda
                        Dim player As New System.Media.SoundPlayer(audio)
                        player.Play()

                        'Verifica o tamanho do audio para saber quanto tempo ele vai ficar tocando
                        Dim durationInSeconds As Double = GetAudioDurationInSeconds(audio)

                        'Aguarda o tempo de duração do anúncio
                        Thread.Sleep(durationInSeconds * 1000)

                        'Retoma a música
                        If playerInstance IsNot Nothing Then
                            playerInstance.PlayPause()
                        End If
                    End If

                    qtdeDeVezes = 0
                Else
                    qtdeDeVezes += 1
                End If



                Await Task.Run(Sub()
                                   Thread.Sleep(1000)
                                   UpdateControls()
                               End Sub)
            End If
            _frm.BeginInvoke(Sub()
                                 _frm.pnlBuffer.Width = _frm.pnlProgressOut.Width
                                 _frm.pnlProgresIn.Width = Math.Floor((_currentTimerIn_sec / _currentTimerLength_sec) * _frm.pnlBuffer.Width)
                             End Sub)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Function GetAudioDurationInSeconds(filePath As String) As Double
        Using reader As New AudioFileReader(filePath)
            Return reader.TotalTime.TotalSeconds
        End Using
    End Function


    Private Function ContertSecToTime(sec As Integer) As String
        Try
            Dim minutes = Math.Floor(sec \ 60)
            Dim seconds = sec Mod 60
            Return minutes.ToString("00") & ":" & seconds.ToString("00")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return "00:00"
        End Try
    End Function


    Private Sub UpdateCamposForm(playbacksate As DeviceStatus)
        Try
            _frm.pnlDescricao.BeginInvoke(Sub() _frm.pnlDescricao.Enabled = True)
            _frm.picCurrentPlaying.Image = _frm.getImageFromUrl(playbacksate.item.album.images(0).url)
            _frm.lblCurrentTrack.Text = playbacksate.item.name
            _frm.lblCurretArtist.Text = playbacksate.item.artists(0).name
            _frm.lblCurrentTrack.Visible = True
            _frm.lblCurretArtist.Visible = True
            _frm.trkVolume.Value = playbacksate.device.volume_percent / 10
            _frm.lblEndTime.Text = ContertSecToTime(_currentTimerLength_sec)
            If playbacksate.is_playing Then
                _frm.picPlay.Image = My.Resources.pausa
            Else
                _frm.picPlay.Image = My.Resources.toque
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetVolume(value As Integer) Implements IPlayer.SetVolume
        Try
            _account.SetVolume(value)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SetPosition(value As Double) Implements IPlayer.SetPosition

    End Sub
End Class
