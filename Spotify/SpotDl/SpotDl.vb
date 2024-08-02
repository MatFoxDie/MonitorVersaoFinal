Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.SpotDl.CustomEvents

Public Class SpotDl
    Public _directoryManager As DirectoryManager
    Private _cmdManager As CmdManager
    Private RootFolder As String
    Public Event TrackDownloaded As TrackDownloadedEventHandler
    Public Event PlaylistDownloaded As PlaylistDownloadedEventHandler
    Public Event TrackOneByOne As TrackOneByOneEventHandler
    Public Event DownloadCanceled As DownloadOneByOneCanceledEventHandler
    Public Event BatchesInDownload As BatchesInDownloadEventHandler

    Sub New()
        Me.RootFolder = SetdirectoryTempMusic()
        _directoryManager = New DirectoryManager(RootFolder)
        _cmdManager = New CmdManager()
    End Sub

    Public Async Function DownloadPlaylist(playListurl As String, playlistName As String, firstTrack As Track, trackList As List(Of Track)) As Task(Of String)
        Try
            Await Task.Run(Sub() DownloadFirstTrack(firstTrack, playlistName))
            Await Task.Run(Sub() DownloadFullPlaylist(playListurl, playlistName, trackList))
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
    End Function

    Private Sub DownloadFirstTrack(firstTrack As Track, playlistName As String)
        Try
            playlistName = removeSpecialChars(playlistName)
            Dim playlistFolder As String = RootFolder + playlistName
            If Not _directoryManager.VerifyDirectoryExists(playlistFolder) Then
                _directoryManager.CreateDirectory(playlistFolder)
            End If
            _cmdManager.OpenCmdInDirectory(playlistFolder)
            _cmdManager.ExecuteDownloadCommand(firstTrack.SpotifyUrl)
            firstTrack.LocalPath = _directoryManager.filePath(playlistFolder, firstTrack.name)
            RaiseEvent TrackDownloaded(Me, New TrackDownloeadedEventArgs(firstTrack))
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
    End Sub

    Private Async Sub DownloadFullPlaylist(playListUrl As String, playlistName As String, trackList As List(Of Track))
        Try
            playlistName = removeSpecialChars(playlistName)
            Dim playlistFolder As String = RootFolder + playlistName
            _cmdManager.OpenCmdInDirectory(playlistFolder)
            Task.Run(Sub() _directoryManager.filePathAsync(playlistFolder, trackList))
            _cmdManager.ExecuteDownloadCommand(playListUrl)

            Dim traklistComLocalPath = trackList.Where(Function(track) track.LocalPath IsNot "").ToList()
            Dim tracklistNotfounded = trackList.Where(Function(track) track.LocalPath Is "").ToList()
            RaiseEvent PlaylistDownloaded(Me, New PlaylistDownloadedEvenArgs(traklistComLocalPath))
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
    End Sub

    Public Async Function DownloadOneByOne(tracks As List(Of Track), playlistName As String, cancellationToken As CancellationTokenSource) As Task
        playlistName = removeSpecialChars(playlistName)
        Dim currentTrack As Track = New Track()
        Try
            For Each track As Track In tracks
                currentTrack = track
                Dim playlistFolder As String = RootFolder
                If Not _directoryManager.VerifyDirectoryExists(playlistFolder) Then
                    _directoryManager.CreateDirectory(playlistFolder)
                End If
                _cmdManager.OpenCmdInDirectory(playlistFolder)
                Await Task.Run(Sub() _cmdManager.ExecuteDownloadCommand(track.SpotifyUrl))
                track.LocalPath = _directoryManager.filePath(playlistFolder, track.name)
                RaiseEvent TrackOneByOne(Me, New TrackOneByOneEventArgs(track))
                cancellationToken.Token.ThrowIfCancellationRequested()
            Next
        Catch ex As OperationCanceledException
            Console.WriteLine("Download cancelado")
            RaiseEvent DownloadCanceled(Me, New DownloadOneByOneCanceledEventsArgs(currentTrack))

        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
    End Function

    Public Async Sub DownloadInBatches(tracks As List(Of Track), playlistName As String, cancellationToken As CancellationTokenSource)
        Try
            Dim downloadTasks As New List(Of Task)()
            Dim batchSize As Integer = 5
            Dim trackBatches = tracks.Select(Function(track, index) New With {track, index}).GroupBy(Function(x) x.index \ batchSize).Select(Function(g) g.Select(Function(x) x.track).ToList()).ToList()
            For Each batch As List(Of Track) In trackBatches

                For Each track As Track In batch
                    downloadTasks.Add(DownLoadSingleTrack(track, playlistName, cancellationToken))
                Next
                Await Task.WhenAll(downloadTasks)
                If cancellationToken.IsCancellationRequested Then
                    Exit For
                End If
            Next
            RaiseEvent PlaylistDownloaded(Me, New PlaylistDownloadedEvenArgs(tracks))
            Console.WriteLine("All batches downloaded")
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try

    End Sub

    Public Async Function DownLoadSingleTrack(track As Track, playlistName As String, cancellationToken As CancellationTokenSource) As Task
        Try
            If cancellationToken.IsCancellationRequested Then
                Return
            End If
            Dim tracklist As List(Of Track) = New List(Of Track)
            tracklist.Add(track)
            RaiseEvent BatchesInDownload(Me, New BatchesInDownloadEventArgs(tracklist))
            Await DownloadOneByOne(tracklist, playlistName, cancellationToken)
        Catch ex As Exception
            Console.WriteLine("Erro ao executar o comando: " & ex.Message)
        End Try
    End Function

    Private Function removeSpecialChars(txt As String) As String
        Try
            Dim regex As New Regex("[^a-zA-Z0-9\s]")
            Return regex.Replace(txt, "")
        Catch ex As Exception
            Console.WriteLine("Erro ao remover caracteres especiais: " & ex.Message)
        End Try
    End Function

    Private Function SetdirectoryTempMusic() As String
        Try
            Dim NomeProjetoVlc = "Vlc"
            Dim diretorioSolucao As String = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)))
            Dim vlcPath As String = diretorioSolucao & $"\{NomeProjetoVlc}\Temps\Musics"
            Return vlcPath
        Catch ex As Exception
            Console.WriteLine("Erro ao setar o diretório de download: " & ex.Message)
        End Try
    End Function
End Class
