Imports System.IO
Imports System.Threading
Imports Spotify
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.SpotDl.CustomEvents
Imports Vlc.DotNet.Core
Imports Vlc.DotNet.Core.Interops.Signatures
Imports Vlc.DotNet.Forms
Imports vlcPlayer.Controls
Imports vlcPlayer.Vlc.Card

Public Class VlcManager

    Private _cancellationTokenSource As Dictionary(Of String, CancellationTokenSource)
    Private _spotifyDl As SpotDl
    Private _vlc As VlcControl
    Private _frm As frmVLC
    Private _currentTrackList As List(Of Track)
    Private IndexAtual As Integer
    Sub New(frmVLC As frmVLC)
        _spotifyDl = New SpotDl()
        _vlc = InitVlc()
        _frm = frmVLC
        _cancellationTokenSource = New Dictionary(Of String, CancellationTokenSource)
        _currentTrackList = New List(Of Track)

        AddHandler _vlc.MediaChanged, AddressOf _vlc_MediaChanged
        AddHandler _vlc.Buffering, AddressOf VlcControl_Buffering
        AddHandler _vlc.EncounteredError, AddressOf VlcControl_EncounteredError
        AddHandler _vlc.EndReached, AddressOf VlcControl_EndReached
        AddHandler _vlc.Playing, AddressOf VlcControl_Playing
        AddHandler _vlc.Paused, AddressOf VlcControl_Paused

        AddHandler _spotifyDl.TrackOneByOne, AddressOf TrackDownloaded
        AddHandler _spotifyDl.BatchesInDownload, AddressOf BatchesInDownload
        AddHandler _spotifyDl.PlaylistDownloaded, AddressOf PlaylistDownloaded
    End Sub

    Private Sub VlcControl_Paused(sender As Object, e As VlcMediaPlayerPausedEventArgs)
        _frm.picPlay.BeginInvoke(Sub() _frm.picPlay.Image = My.Resources.toque)
    End Sub

    Private Sub VlcControl_Playing(sender As Object, e As VlcMediaPlayerPlayingEventArgs)
        Try
            _frm.picPlay.BeginInvoke(Sub() _frm.picPlay.Image = My.Resources.pausa)
        Catch ex As Exception
            MessageBox.Show("Erro ao reproduzir o vídeo")
        End Try
    End Sub

    Private Sub VlcControl_EndReached(sender As Object, e As VlcMediaPlayerEndReachedEventArgs)
        Try
            If _frm.replay Then
                _vlc.BeginInvoke(Sub() changeVideoTo(0))
                _frm.replay = False
                Return
            End If
            _vlc.BeginInvoke(Sub() changeVideoTo(1))
        Catch ex As Exception
            Console.WriteLine("Erro ao reproduzir o vídeo")
        End Try

    End Sub

    Private Sub VlcControl_EncounteredError(sender As Object, e As VlcMediaPlayerEncounteredErrorEventArgs)
        MessageBox.Show("Erro ao reproduzir o vídeo")
    End Sub

    Private Sub VlcControl_Buffering(sender As Object, e As VlcMediaPlayerBufferingEventArgs)
        Try
            If e.NewCache < 25 Then
                _frm.pnlBottom.BeginInvoke(Sub() enableControlsInPnlButton(False))
            Else
                _vlc.BeginInvoke(Sub() _vlc.Play())
                _frm.pnlBottom.BeginInvoke(Sub() enableControlsInPnlButton(True))
            End If
            _frm.BeginInvoke(Sub() _frm.pnlBufferWidth(e.NewCache))
        Catch ex As Exception
            Console.WriteLine("Erro ao reproduzir o vídeo")
        End Try
    End Sub

    Private Sub _vlc_MediaChanged(sender As Object, e As VlcMediaPlayerMediaChangedEventArgs)
        Try
            Dim currentTrack = _currentTrackList(IndexAtual)
            Dim imageUrl As String = currentTrack.album.images(0).url
            Dim image = _frm.getImageFromUrl(imageUrl)
            _frm.BeginInvoke(Sub()
                                 _frm.pnlDescricao.Enabled = True
                                 _frm.pnlDescricao.Tag = currentTrack
                                 _frm.picCurrentPlaying.Image = image
                                 _frm.lblCurrentTrack.Text = currentTrack.name
                                 _frm.lblCurrentTrack.Visible = True
                                 _frm.lblCurretArtist.Text = currentTrack.artists(0).name
                                 _frm.lblCurretArtist.Visible = True
                             End Sub)
        Catch ex As Exception
            Console.WriteLine("Erro ao reproduzir o vídeo")
        End Try
    End Sub


    Private Sub enableControlsInPnlButton(enable As Boolean)
        Try
            For Each control As Control In _frm.pnlBottom.Controls
                If control.Name <> "picCarregando" Then
                    control.Enabled = enable
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("Erro ao reproduzir o vídeo")
        End Try
    End Sub
    Private Shared Function setVLCdirectory() As DirectoryInfo
        Try
            Dim NomeProjetoVlc = "Vlc"
            Dim diretorioSolucao As String = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)))
            Dim vlcPath As String = diretorioSolucao & $"\{NomeProjetoVlc}\vlc-portable32bit\app"
            Return New DirectoryInfo(vlcPath)
        Catch ex As Exception
            Console.WriteLine("Erro ao setar o diretório do VLC")
        End Try
    End Function

    Private Function InitVlc() As VlcControl
        Try
            Dim vlcControl = New VlcControl()
            vlcControl.BeginInit()
            vlcControl.VlcLibDirectory = setVLCdirectory()
            vlcControl.EndInit()
            vlcControl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            Return vlcControl
        Catch ex As Exception
            Console.WriteLine("Erro ao iniciar o VLC")
            Return Nothing
        End Try
    End Function


    Private Sub BatchesInDownload(sender As Object, e As BatchesInDownloadEventArgs)
        Try
            If IsDownloadCanceled(e.Tracks(0)) Or Not _frm.flpCards.Navegacao = ENavegation.InMusics Then
                Return
            End If
            For Each track In e.Tracks
                If cardJacriado(track) Then
                    Continue For
                End If
                Dim card = New Card(track)
                card.InDownloadStatus()
                _frm._cardManager.addCard(card, _frm.flpCards)
            Next
        Catch ex As Exception
            Console.WriteLine("Erro ao baixar as músicas")
        End Try
    End Sub

    Private Sub TrackDownloaded(sender As Object, e As TrackOneByOneEventArgs)
        Try
            If IsDownloadCanceled(e.Track) Or TrackJaAdicionada(e.Track) Then
                Return
            End If

            If _currentTrackList.Count = 0 Then
                InicializarListaAtual(e.Track)
                initPlay()
            Else
                _currentTrackList.Add(e.Track)
            End If
            changeCardStatus(e.Track)
        Catch ex As Exception
            Console.WriteLine("Erro ao baixar a música")
        End Try
    End Sub

    Private Sub PlaylistDownloaded(sender As Object, e As PlaylistDownloadedEvenArgs)
        Console.WriteLine("Playlist baixada com sucesso!")
    End Sub


    Private ReadOnly Property IsDownloadCanceled(track As Track) As Boolean
        Get
            If track.FromPlaylistId IsNot Nothing AndAlso _cancellationTokenSource.ContainsKey(track.FromPlaylistId) AndAlso _cancellationTokenSource(track.FromPlaylistId).IsCancellationRequested Then
                Return True
            End If
            Return False
        End Get
    End Property


    Public Sub PlayPause()
        Try
            If _currentTrackList.Count = 0 Then
                MessageBox.Show("PlayList vazia")
                Return
            End If
            If _vlc.State = MediaStates.Playing Then
                _vlc.Pause()
            ElseIf _vlc.State = MediaStates.Paused Then
                _vlc.Play()
            Else
                initPlay()
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao reproduzir")
        End Try
    End Sub
    Private Sub initPlay()
        Dim trackAtual = _currentTrackList(IndexAtual)
        _vlc.SetMedia(trackAtual.LocalPath)
        _frm.TimerBarraProgresso.Start()
        _vlc.Play()
        _frm.trkVolume.Value = _vlc.Audio.Volume / 10
    End Sub

    Private Function GetOrCreateCancellationToken(playListId As String) As CancellationTokenSource
        Try
            Dim canlellationTokenSource As CancellationTokenSource
            If _cancellationTokenSource.ContainsKey(playListId) Then
                _cancellationTokenSource(playListId).Cancel()
                _cancellationTokenSource(playListId) = New CancellationTokenSource()
                canlellationTokenSource = _cancellationTokenSource(playListId)
            Else
                canlellationTokenSource = New CancellationTokenSource()
                _cancellationTokenSource.Add(playListId, canlellationTokenSource)
            End If
            Return canlellationTokenSource
        Catch ex As Exception
            Console.WriteLine("Erro ao criar o token de cancelamento")
            Return Nothing
        End Try
    End Function

    Friend Sub StartPlaylistDownload(trackList As List(Of Track), playListName As String, playlistId As String)
        Try
            _currentTrackList = New List(Of Track)
            Dim canlellationTokenSource = GetOrCreateCancellationToken(playlistId)
            _spotifyDl.DownloadInBatches(trackList, playListName, canlellationTokenSource)
        Catch ex As Exception
            Console.WriteLine("Erro ao baixar a playlist")
        End Try
    End Sub

    Friend Sub playSingleTrack(track As Track)
        Try
            _currentTrackList = New List(Of Track)
            Dim canlellationTokenSource = New CancellationTokenSource()
            _spotifyDl.DownLoadSingleTrack(track, "Single", canlellationTokenSource)
        Catch ex As Exception
            Console.WriteLine("Erro ao baixar a música")
        End Try

    End Sub

    Friend Sub vlcPlayIndex(track As Track)
        Dim Index = _currentTrackList.FindIndex(Function(t) t.id = track.id)
        Try
            IndexAtual = Index
            _vlc.SetMedia(_currentTrackList(IndexAtual).LocalPath)
            _vlc.Play()
        Catch ex As Exception
            MessageBox.Show("Não foi possivel encontrar o aquivo!")
        End Try
    End Sub

    Public Sub PararProcessosDeDownload()
        Try
            If _currentTrackList.Count <> 0 Then
                Dim track = _currentTrackList(0)
                Dim playlistId = track.FromPlaylistId
                If Not playlistId Is Nothing Then
                    _cancellationTokenSource(playlistId).Cancel()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao cancelar o download")
        End Try
    End Sub

    Private Function TrackJaAdicionada(track As Track) As Boolean
        Try
            Return _currentTrackList.Any(Function(t) t.id = track.id)
        Catch ex As Exception
            Console.WriteLine("Erro ao verificar se a música já foi adicionada")
            Return False
        End Try
    End Function

    Private Sub InicializarListaAtual(track As Track)
        Try
            _currentTrackList.Add(track)
            IndexAtual = 0
        Catch ex As Exception
            Console.WriteLine("Erro ao inicializar a lista atual")
        End Try
    End Sub

    Private Sub changeCardStatus(track As Track)
        Try
            Dim currentCards As List(Of Panel) = New List(Of Panel)
            For Each control As Control In _frm.flpCards.Controls
                If TypeOf control Is Panel Then
                    currentCards.Add(control)
                End If
            Next
            Dim trackCard As Panel = currentCards.FirstOrDefault(Function(c) c.Tag.id = track.id)
            If trackCard IsNot Nothing Then
                trackCard.Tag.Status = ECardStatus.Completed
                Dim pictureBox As PictureBox = _frm.GetPictureBoxFromSender(trackCard)
                pictureBox.Image = _frm.getImageFromUrl(track.album.images(0).url)
                Dim index = _currentTrackList.FindIndex(Function(t) t.id = track.id)
                _frm.flpCards.Controls.SetChildIndex(trackCard, index)
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao mudar o status do card")
        End Try
    End Sub

    Public Sub changeVideoTo(moveTo As Integer)
        Try
            Dim novoIndice = IndexAtual + moveTo
            If novoIndice < 0 Then
                novoIndice = _currentTrackList.Count - 1
            ElseIf novoIndice >= _currentTrackList.Count Then
                novoIndice = 0
            End If
            IndexAtual = novoIndice
            Dim videoAtual = _currentTrackList(IndexAtual)
            _vlc.SetMedia(videoAtual.LocalPath)
            _vlc.Play()
        Catch ex As Exception
            Console.WriteLine("Erro ao mudar o vídeo")
        End Try

    End Sub
    Private Function cardJacriado(track As Track) As Boolean
        Try
            Dim cards = _frm.flpCards.Controls.OfType(Of Panel).ToList()
            Return cards.Any(Function(c) c.Tag.id = track.id)
        Catch ex As Exception
            Console.WriteLine("Erro ao verificar se o card já foi criado")
            Return False
        End Try
    End Function

    Public Sub AbrirPLaylistNaDescricao(completeTrackList As List(Of Track), folderName As String)
        Try
            Dim tempCurrentList = _currentTrackList
            _frm.flpCards.Navegacao = ENavegation.InMusics
            _frm.pnlDescricao.Enabled = True
            _currentTrackList = tempCurrentList
            Dim currentTrack As Track = _frm.pnlDescricao.Tag
            If currentTrack.FromPlaylistId Is Nothing Then
                Return
            End If
            For Each track As Track In _currentTrackList
                Dim card As New Card(track)
                _frm._cardManager.addCard(card, _frm.flpCards)
                completeTrackList.RemoveAll(Function(trackItem) trackItem.id = track.id)
            Next
            _cancellationTokenSource.Remove(currentTrack.FromPlaylistId)
            Dim cancelationToken = New CancellationTokenSource()
            _cancellationTokenSource.Add(currentTrack.FromPlaylistId, cancelationToken)
            _spotifyDl.DownloadInBatches(completeTrackList, folderName, cancelationToken)
        Catch ex As Exception
            Console.WriteLine("Erro ao abrir a playlist na descrição")
        End Try
    End Sub

    Public Function GetCurrentTime() As Long
        Try
            If _vlc.GetCurrentMedia() Is Nothing Then
                Return 0
            Else
                Return _vlc.Time
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao pegar o tempo atual")
            Return 0
        End Try
    End Function

    Public Function GetTotalTime() As Long
        Try
            If _vlc.GetCurrentMedia() Is Nothing Then
                Return 0
            Else
                Return _vlc.Length
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao pegar o tempo total")
            Return 0
        End Try
    End Function

    Public Function GetCurrentPosition() As Single
        Try
            If _vlc.GetCurrentMedia() Is Nothing Then
                Return 0
            Else
                Return _vlc.Position
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao pegar a posição atual")
            Return 0
        End Try
    End Function

    Public Sub StopPlay()
        Try
            _vlc.Stop()
        Catch ex As Exception
            Console.WriteLine("Erro ao parar a reprodução")
        End Try
    End Sub

    Public Sub setVolume(volume As Integer)
        Try
            _vlc.Audio.Volume = volume * 10
        Catch ex As Exception
            Console.WriteLine("Erro ao setar o volume")
        End Try
    End Sub

    Public Sub SetPosition(value As Double)
        Try
            _vlc.Position = value
        Catch ex As Exception
            Console.WriteLine("Erro ao setar a posição")
        End Try
    End Sub

    Public Property SpotDl As SpotDl
        Get
            Return Nothing
        End Get
        Set(value As SpotDl)
        End Set
    End Property
End Class
