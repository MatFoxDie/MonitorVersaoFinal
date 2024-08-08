Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports Spotify
Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models
Imports Vlc.DotNet.Forms
Imports vlcPlayer.Config
Imports vlcPlayer.Controls
Imports vlcPlayer.Vlc.Card


Public Class frmVLC
    Private totalHeightComponentsytem As Integer
    Private originalPanelWidth As Integer
    Public replay As Boolean = False
    Public _spotifyApi As SpotifyApi
    Public _modoAleatorio As Boolean = False
    Public _cardManager As CardManager
    Private _browser As frmWebSpotify
    Public fechadoForcado As Boolean
    Sub New()
        InitializeComponent()
        ConfigControls()
        _spotifyApi = New SpotifyApi()
        _cardManager = New CardManager(flpCards, Me)

        If Not IsSpotifyConfigFilled() Then
            OpenConfigForm()
        Else


            'CarregarCategoryCards()
            playerInstance = New AsLocalPlayer(Me, _spotifyApi)

            AddHandler pnlDescricao.Click, AddressOf pnlDescricao_Click
            AddHandler picCurrentPlaying.Click, AddressOf picCurrentPlaying_Click

        End If
    End Sub

    Private Function IsSpotifyConfigFilled() As Boolean
        Try
            Dim NomeProjetoVlc = "Spotify"
            'Verifica se tem pasta Config criada se nao cria
            If Not Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config")) Then
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config"))
            End If

            'Salva no path atual da bin com uma pasta chamada Config e um arquivo chamado config.xml
            Dim configPathSpotify As String = Path.Combine(Directory.GetCurrentDirectory(), NomeProjetoVlc, "Config", "config.xml")


            If Not File.Exists(configPathSpotify) Then
                Return False
            End If

            Dim doc As XDocument = XDocument.Load(configPathSpotify)
            Dim clientId As String = doc.Root.Element("ClientId").Value
            Dim clientSecret As String = doc.Root.Element("ClientSecret").Value
            Dim redirectUri As String = doc.Root.Element("RedirectUri").Value
            Dim token As String = doc.Root.Element("Token").Value

            If String.IsNullOrWhiteSpace(clientId) OrElse
           String.IsNullOrWhiteSpace(clientSecret) OrElse
           String.IsNullOrWhiteSpace(redirectUri) OrElse
           String.IsNullOrWhiteSpace(token) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Private Sub OpenConfigForm()
        Try
            MessageBox.Show("As configurações do Spotify não estão preenchidas. Por favor, preencha as configurações.")
            Dim formConfig As New frmTokenGenerator()
            formConfig.ShowDialog()

            ' Após fechar o formulário de configuração, verifique novamente
            If Not IsSpotifyConfigFilled() Then
                fechadoForcado = formConfig.FechadoForcado
                If fechadoForcado Then
                    Me.Dispose()
                    Return
                End If
                OpenConfigForm() ' Continue mostrando o formulário até que esteja preenchido
            Else
                _spotifyApi = New SpotifyApi()
                _cardManager = New CardManager(flpCards, Me)
                CarregarCategoryCards()
                playerInstance = New AsLocalPlayer(Me, _spotifyApi)

                AddHandler pnlDescricao.Click, AddressOf pnlDescricao_Click
                AddHandler picCurrentPlaying.Click, AddressOf picCurrentPlaying_Click
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Property IPlayer As IPlayer
        Get
            Return Nothing
        End Get
        Set(value As IPlayer)
        End Set
    End Property

    Private Sub pnlProgressOut_Click(sender As Object, e As EventArgs) Handles pnlProgressOut.Click
        ProgressBarOnClick()
    End Sub

    Private Sub pnlProgresIn_Click(sender As Object, e As EventArgs) Handles pnlProgresIn.Click
        ProgressBarOnClick()
    End Sub
    Private Sub frmVLC_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        executeKeyActions(e)
    End Sub

    Private Sub picReplay_Click(sender As Object, e As EventArgs) Handles picReplay.Click
        Try
            If replay = False Then
                replay = True
                picReplay.Image = My.Resources.recarregar_azul
            Else
                replay = False
                picReplay.Image = My.Resources.recarregar
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub picAvancar_Click_1(sender As Object, e As EventArgs) Handles picAvancar.Click
        Try
            playerInstance.SkipToNext()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub picVoltar_Click(sender As Object, e As EventArgs) Handles picVoltar.Click
        Try
            playerInstance.SkipToPrevious()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub picPlay_Click(sender As Object, e As EventArgs) Handles picPlay.Click
        Try
            playerInstance.PlayPause()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub aumentarVolume(aumentar As Boolean)
        Try
            If aumentar And trkVolume.Value < 10 Then
                trkVolume.Value += 1
            ElseIf Not aumentar And trkVolume.Value > 0 Then
                trkVolume.Value -= 1
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub trkVolume_ValueChanged(sender As Object, e As EventArgs) Handles trkVolume.ValueChanged
        Try
            playerInstance.SetVolume(trkVolume.Value)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub pnlProgressOut_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlProgressOut.MouseMove
        Try
            MouseHoverTempo()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub pnlProgressOut_MouseLeave(sender As Object, e As EventArgs) Handles pnlProgressOut.MouseLeave
        Try
            lblMouseHover.Visible = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub pnlProgresIn_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlProgresIn.MouseMove
        Try
            MouseHoverTempo()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub pnlProgresIn_MouseLeave(sender As Object, e As EventArgs) Handles pnlProgresIn.MouseLeave
        Try
            lblMouseHover.Visible = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub pnlBuffer_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlBuffer.MouseMove
        Try
            MouseHoverTempo()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub pnlBuffer_MouseLeave(sender As Object, e As EventArgs) Handles pnlBuffer.MouseLeave
        Try
            lblMouseHover.Visible = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub pnlBuffer_MouseClick(sender As Object, e As MouseEventArgs) Handles pnlBuffer.MouseClick
        Try
            ProgressBarOnClick()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub ConfigControls()
        Try
            ArredondarPanel(pnlBuscar, 20)
            resetBuscar()
            Me.ActiveControl = Nothing
            ConfigPnlBottomControls()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function InitVlcControl() As VlcControl
        Try
            Dim vlcControl = New VlcControl()
            vlcControl.BeginInit()
            vlcControl.VlcLibDirectory = setVLCdirectory()
            vlcControl.EndInit()
            Me.Controls.Add(vlcControl)
            vlcControl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            Dim vlcManager As New VlcManager(Me)

            Return vlcControl
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function


    Private Sub ProgressBarOnClick()
        Try
            Dim clickPositionXPercentRounded As Double = getMousePositionInPercent()
            pnlProgresIn.Width = pnlProgressOut.Width * clickPositionXPercentRounded
            playerInstance.SetPosition(clickPositionXPercentRounded)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Function setVLCdirectory() As DirectoryInfo
        Try
            Dim NomeProjetoVlc = "Vlc"
            Dim diretorioSolucao As String = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)))
            Dim vlcPath As String = diretorioSolucao & $"\{NomeProjetoVlc}\vlc-portable32bit\app"
            Return New DirectoryInfo(vlcPath)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Sub executeKeyActions(e As KeyEventArgs)
        Try
            Dim keyActions As New Dictionary(Of Keys, Action) From {
            {Keys.Space, Sub() picPlay_Click(Nothing, Nothing)},
            {Keys.Up, Sub() aumentarVolume(True)},
            {Keys.Down, Sub() aumentarVolume(False)},
            {Keys.Enter, Sub() btnBuscar_Click(Nothing, Nothing)}
        }
            If keyActions.ContainsKey(e.KeyCode) And e.KeyCode = Keys.Enter Then
                keyActions(e.KeyCode).Invoke()
            End If

            If keyActions.ContainsKey(e.KeyCode) And Not txtBuscar.Focused Then
                keyActions(e.KeyCode).Invoke()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub MouseHoverTempo()
        Try
            Dim borderwidth As Integer = SystemInformation.BorderSize.Width / 2
            Dim clickPosition As Point = pnlProgressOut.PointToClient(MousePosition)
            Dim clickPositionX As Integer = clickPosition.X
            Dim clickPositionXPercentRounded As Double = getMousePositionInPercent()
            Dim time As Integer = ConverterTimeStringToSec(lblEndTime.Text) * clickPositionXPercentRounded
            lblMouseHover.Text = ConverterTimerSecToTime(time)
            lblMouseHover.Visible = True
            Dim labelsize As Integer = lblMouseHover.Size.Height + 3
            Dim larguraDaborda As Integer = SystemInformation.CaptionHeight / 2
            lblMouseHover.Location = New Point(pnlProgressOut.Location.X + clickPosition.X - larguraDaborda, pnlProgressOut.Location.Y - labelsize)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Function getMousePositionInPercent() As Double
        Try
            Dim clickPosition As Point = pnlProgressOut.PointToClient(MousePosition)
            Dim clickPositionX As Integer = clickPosition.X
            Dim pnlProgressOutWidth As Integer = pnlProgressOut.Width
            Dim clickPositionXPercent As Double = clickPositionX / pnlProgressOutWidth
            Dim clickPositionXPercentRounded As Double = Math.Round(clickPositionXPercent, 2)
            Return clickPositionXPercentRounded
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function


    Public Sub pnlBufferWidth(bufferPercent As Integer)
        Try
            pnlBuffer.Width = pnlProgressOut.Width * (bufferPercent / 100)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub ConfigPnlBottomControls()
        Try
            picRefresh.Visible = False
            pnlBuffer.Width = 0
            originalPanelWidth = PnlLateral.Size.Width
            pnlProgresIn.Width = 0
            pnlBuffer.BringToFront()
            pnlProgresIn.BringToFront()
            Dim borderheight As Integer = SystemInformation.CaptionHeight / 2
            Dim tituloheight As Integer = SystemInformation.CaptionHeight
            totalHeightComponentsytem = borderheight + tituloheight
            lblMouseHover.Visible = False
            lblCurrentTrack.Visible = False
            lblCurretArtist.Visible = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CarregarCards(items As List(Of Item))
        Try
            flpCards.Controls.Clear()
            flpCards.AutoScroll = True
            For Each item In items
                Dim card As New Card(item)
                _cardManager.addCard(card, flpCards)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub CarregarCategoryCards()
        Try
            flpCards.Controls.Clear()
            flpCards.AutoScroll = True
            Dim cardestaque As Card = New Card().GetCardEmDestaque()
            _cardManager.addCard(cardestaque, flpCards)
            Dim categories = _spotifyApi.GetCategories(0, 50)
            For Each category In categories.categories.items
                Dim card As New Card(category)
                _cardManager.addCard(card, flpCards)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Function ReturnCurrentTrack() As String
        Try
            If lblCurrentTrack.Text.Equals("Música") Or lblCurrentTrack.Equals("") Then
                Return "Nenhuma música tocando"
            End If

            Return "Música Atual:" & lblCurrentTrack.Text
        Catch ex As Exception
            Return "Nenhuma música tocando"
        End Try
    End Function

    Public Sub HandleFeateredPlaylistsClick()
        Try
            flpCards.Navegacao = ENavegation.InPlaylist
            Dim playlists = _spotifyApi.getFeaturedPlaylist(0, 50)
            CarregarCards(playlists.playlists.items)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub HandleTrackClick(panelCliked As Panel, track As Track, pictureBox As PictureBox, panels As List(Of Panel))
        Try
            playerInstance.TrackClick(panelCliked, track, pictureBox, panels)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Async Sub HandlePlaylistClick(panelCliked As Panel, item As Item, pictureBox As PictureBox, panels As List(Of Panel))
        Try
            playerInstance.PlaylistClick(item.id)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Public Async Sub HandleCategoryClick(item As Item, pictureBox As PictureBox, panels As List(Of Panel))
        Try
            flpCards.Navegacao = ENavegation.InPlaylist
            Dim playlists = Await _spotifyApi.getPlaylistByCategory(item.id)
            CarregarCards(playlists.playlists.items)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Function GetPictureBoxFromSender(sender As Object) As PictureBox
        Try
            Dim pictureBox As PictureBox = Nothing
            For Each control In sender.Controls
                If TypeOf control Is PictureBox Then
                    pictureBox = control
                End If
            Next
            Return pictureBox
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function
    Public Sub desabilitarOutrosCardNoPanel(currentPanel As Panel, panels As List(Of Panel))
        Try
            Dim pictureBox As PictureBox = GetPictureBoxFromSender(currentPanel)
            Dim title As Label = New Label()
            For Each control In currentPanel.Controls
                If TypeOf control Is Label Then
                    title = control
                End If
            Next
            For Each panel In panels
                For Each control As Control In panel.Controls
                    If TypeOf control Is FlowLayoutPanel Then
                        Continue For
                    End If
                    If control IsNot currentPanel Then
                        control.Enabled = False
                    End If
                Next
            Next
            RemoveHandler currentPanel.Click, AddressOf _cardManager.card_Click
            RemoveHandler pictureBox.Click, AddressOf _cardManager.PictureBox_Click
            RemoveHandler title.Click, AddressOf _cardManager.Title_click
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Function getImageFromUrl(url As String)
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            Dim response As WebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim bitmap As New Bitmap(responseStream)
            responseStream.Close()
            Return bitmap
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Sub picVoltarPanel_Click(sender As Object, e As EventArgs) Handles picVoltarPanel.Click
        Try
            pararProcessosDeDownload()
            flpCards.Navegacao = ENavegation.InCategory
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub pararProcessosDeDownload()
        Try
            playerInstance.pararProcessos()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim tempBuscar = txtBuscar.Text
            If tempBuscar = "Buscar" Or tempBuscar = "" Then
                Return
            End If

            flpCards.Navegacao = ENavegation.InSearch

            pararProcessosDeDownload()
            Dim lblMúsicas As Label = New Label()
            lblMúsicas.Text = "Músicas: "
            lblMúsicas.AutoSize = True
            lblMúsicas.Font = New Font("Arial", 12, FontStyle.Bold)

            Dim searchResult = _spotifyApi.Search(tempBuscar)
            flpCards.Controls.Clear()
            Dim flpTracks As New FlowLayoutPanel
            Dim borderwidth As Integer = SystemInformation.BorderSize.Width * 10
            flpTracks.AutoScroll = True
            flpTracks.Width = flpCards.Width - borderwidth
            flpTracks.Height = 230
            flpTracks.Dock = DockStyle.None

            Dim lblPlaylists As Label = New Label()
            lblPlaylists.Text = "Playlists: "
            lblPlaylists.AutoSize = True
            lblPlaylists.Font = New Font("Arial", 12, FontStyle.Bold)

            Dim flpPlaylists As New FlowLayoutPanel
            flpPlaylists.AutoScroll = True
            flpPlaylists.Dock = DockStyle.None
            flpPlaylists.Width = flpCards.Width - borderwidth
            flpPlaylists.Height = 230

            flpCards.Controls.Add(lblMúsicas)
            flpCards.Controls.Add(flpTracks)
            flpCards.Controls.Add(lblPlaylists)
            flpCards.Controls.Add(flpPlaylists)

            For Each item In searchResult.Tracks.items
                Dim track = _spotifyApi.getTrack(item.id)
                Dim card As New Card(track)
                _cardManager.addCard(card, flpTracks)
            Next

            For Each item In searchResult.Playlists.items
                Dim card As New Card(item)
                _cardManager.addCard(card, flpPlaylists)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub resetBuscar()
        Try
            txtBuscar.Text = "Buscar"
            txtBuscar.ForeColor = Color.Gray
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub flpCards_SizeChanged(sender As Object, e As EventArgs)
        Try
            Dim borderwidth As Integer = SystemInformation.BorderSize.Width * 10
            For Each control As Control In flpCards.Controls
                If TypeOf control Is FlowLayoutPanel Then
                    control.Width = flpCards.Width - borderwidth
                End If
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Try
            If txtBuscar.Text = "" Then
                Return
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub ArredondarPanel(panel As Panel, cornerRadius As Integer)
        Try
            Dim path As New GraphicsPath()
            Dim rect = panel.ClientRectangle
            path.AddArc(rect.Left, rect.Top, cornerRadius * 2, cornerRadius * 2, 180, 90) ' Canto superior esquerdo
            path.AddArc(rect.Right - 2 * cornerRadius, rect.Top, cornerRadius * 2, cornerRadius * 2, 270, 90) ' Canto superior direito
            path.AddArc(rect.Right - 2 * cornerRadius, rect.Bottom - 2 * cornerRadius, cornerRadius * 2, cornerRadius * 2, 0, 90) ' Canto inferior direito
            path.AddArc(rect.Left, rect.Bottom - 2 * cornerRadius, cornerRadius * 2, cornerRadius * 2, 90, 90) ' Canto inferior esquerdo
            path.CloseFigure()
            panel.Region = New Region(path)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) Handles txtBuscar.Click
        Try
            If txtBuscar.Text = "Buscar" Then
                txtBuscar.Text = ""
                txtBuscar.ForeColor = Color.Black
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function GetCardDestaque() As Item
        Try
            Dim item As New Item
            item.name = "Destaques"
            item.type = "feateredPlaylists"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Sub picAleatorio_Click(sender As Object, e As EventArgs) Handles picAleatorio.Click
        Try
            AtivarModoAleatorio(True)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub AtivarModoAleatorio(modoAleatorio As Boolean)
        Try
            If modoAleatorio Then
                picRefresh.Visible = True
                _modoAleatorio = True
                picAleatorio.Image = My.Resources.aleatorio_azul
                playerInstance.IniciarModoAleatorio()
            Else
                _modoAleatorio = False
                picAleatorio.Image = My.Resources.aleatorio
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


    Private Sub picConfig_Click(sender As Object, e As EventArgs) Handles picConfig.Click
        Try
            Dim formConfig As New frmConfig
            formConfig.ShowDialog()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnEntrarComSpotify_Click(sender As Object, e As EventArgs) Handles btnEntrarComSpotify.Click
        Try
            TimerBarraProgresso.Stop()
            picVoltarPanel_Click(Nothing, Nothing)
            Dim frmWebSpoty As New frmWebSpotify(_spotifyApi, Me)
            _browser = frmWebSpoty
            frmWebSpoty.Show()

            If frmWebSpoty IsNot Nothing Then
                frmWebSpoty.Show()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles BtnSair.Click
        Try
            picVoltarPanel_Click(Nothing, Nothing)
            playerInstance.pararProcessos()
            playerInstance.FinalizarProcessos()
            playerInstance = New AsLocalPlayer(Me, _spotifyApi)
            _browser.Sair()
            btnEntrarComSpotify.Visible = True
            pnlUsuarioLogado.Visible = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub picCurrentPlaying_Click(sender As Object, e As EventArgs)
        Try
            Dim pictureBox As PictureBox = sender
            Dim panelParent As Panel = pictureBox.Parent
            pnlDescricao_Click(panelParent, e)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Async Sub pnlDescricao_Click(sender As Object, e As EventArgs)
        Try
            If _flpCards.Navegacao = ENavegation.InMusics Then
                Return
            End If
            playerInstance.PnlDescricaoClick()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


    Private Function ConverterTimeStringToSec(time As String) As Integer
        Try
            Dim timeArray = time.Split(":")
            Dim minutos = timeArray(0)
            Dim segundos = timeArray(1)
            Return (minutos * 60) + segundos
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Function ConverterTimerSecToTime(sec As Integer) As String
        Try
            Dim minutos = Math.Floor(sec / 60)
            Dim segundos = sec Mod 60
            Return minutos.ToString("00") & ":" & segundos.ToString("00")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Sub picRefresh_Click(sender As Object, e As EventArgs) Handles picRefresh.Click
        Try
            playerInstance.IniciarModoAleatorio()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub Sair_Click(sender As Object, e As EventArgs) Handles Sair.Click
        Me.Visible = False
    End Sub

    Private Sub flpCards_Paint(sender As Object, e As PaintEventArgs) Handles flpCards.Paint

    End Sub
End Class
