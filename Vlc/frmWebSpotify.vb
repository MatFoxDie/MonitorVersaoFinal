Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports EO.WebBrowser
Imports Microsoft.Web.WebView2.Core
Imports Spotify.Spotify.Api

Public Class frmWebSpotify
    Private _autenticador As AutenticadorSpotify
    Private _spotifyApi As SpotifyApi
    Private _tokengerado As Boolean = False
    Private _spotifyHomeUrl As String = "https://www.spotify.com/br/"
    Private _frm As frmVLC
    Private _loged As Boolean = False
    Sub New(spotifyApi As SpotifyApi, frm As frmVLC)
        InitializeComponent()
        _spotifyApi = spotifyApi
        _autenticador = New AutenticadorSpotify(_spotifyApi)
        configControls()
        _frm = frm
    End Sub

    Private Sub configControls()
        Try
            Me.MaximizeBox = False
            WebView21.Dock = DockStyle.Fill
            WebView21.Source = _autenticador.GetLoginUrl()

            AddHandler WebView21.NavigationCompleted, AddressOf WebView21_NavigationCompleted
            AddHandler WebView21.NavigationStarting, AddressOf WebView21_NavigationStarting
            AddHandler WebView21.SourceChanged, AddressOf WebView21_SourceChanged
        Catch ex As Exception
            Console.WriteLine("Erro ao configurar controles: " & ex.Message)
        End Try
    End Sub

    Private Sub WebView21_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs)
        Try
            If _loged Then
                Return
            End If
            If WebView21.Source.ToString.Contains("https://accounts.spotify.com/authorize") Then
                Return
            End If
            If WebView21.Source.ToString.Contains("code=") And Not _tokengerado Then
                _tokengerado = True
                Dim novotoken As Token = _autenticador.GetAcessTokenByUrlCode(WebView21.Source.ToString)
                _spotifyApi.Token = novotoken
                WebView21.CoreWebView2.Navigate(_spotifyHomeUrl)
            End If
            If WebView21.Source.ToString.Contains("https://open.spotify.com/") Then
                Me.Hide()
                _loged = True
                WebView21.CoreWebView2.ExecuteScriptAsync("")
                Dim currentUri As Uri = WebView21.Source
                usuarioLogado(currentUri)
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao mudar a fonte: " & ex.Message)
        End Try
    End Sub

    Private Sub WebView21_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs)

    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)
        Try
            If _loged Then
                Return
            End If

            Dim currentUri As Uri = WebView21.Source
            If currentUri.AbsoluteUri.Contains(_spotifyApi.redirect_uri) And Not _tokengerado Then
                Me.Hide()
            End If
            If currentUri.AbsoluteUri.Contains(_spotifyHomeUrl) Then
                Me.Hide()
            End If
        Catch ex As Exception
            Console.WriteLine("Erro ao completar a navegação: " & ex.Message)
        End Try
    End Sub

    Private Sub usuarioLogado(currentUri As Uri)
        Try
            _frm.btnEntrarComSpotify.Visible = False
            Dim usuario = _spotifyApi.GetCurrentUserProfile()
            _frm.lblNomeUsuarioLogado.Text = "Bem-Vindo: " & usuario.display_name
            _frm.lblNomeUsuarioLogado.Text += "/" & usuario.product
            _frm.pnlUsuarioLogado.Visible = True
            Dim x = _frm.Width - (2 * _frm.picConfig.Width) - _frm.pnlUsuarioLogado.Width - 30
            Dim y = _frm.pnlUsuarioLogado.Location.Y
            _frm.pnlUsuarioLogado.Location = New Point(x, y)
            _spotifyApi.Userlogago = True
            _frm._player.pararProcessos()
            _frm._player.FinalizarProcessos()
            _frm._player = New AsSpotifyPlayer(_frm, WebView21, _spotifyApi)
            MessageBox.Show("Logado com sucesso!")
        Catch ex As Exception
            Console.WriteLine("Erro ao logar com o Spotify: " & ex.Message)
        End Try

    End Sub

    Public Async Sub Sair()
        Await WebView21.ExecuteScriptAsync(JavaScriptCommands.Sair())
        Thread.Sleep(1000)
        Me.Close()
    End Sub


    Private Sub LimparCache()


    End Sub

    Public Sub Refresh()
        WebView21.CoreWebView2.Navigate(_spotifyHomeUrl)
    End Sub


End Class