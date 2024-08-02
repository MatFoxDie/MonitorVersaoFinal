Imports Spotify.Spotify.Api

Public Class frmTokenGenerator
    Private config As Config
    Private _xmlManager As XmlManager
    Private _config As Config
    Private _autenticadorSpotify As AutenticadorSpotify
    Sub New()
        InitializeComponent()
        _xmlManager = New XmlManager()
        config = _xmlManager.GetConfig()
        configControls()
    End Sub

    Private Sub configControls()
        Try
            txtClientId.Text = config.ClientId
            txtClientSecret.Text = config.ClientSecret
            txtRedirectUri.Text = config.RedirectUri
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub btnGerarUri_Click(sender As Object, e As EventArgs) Handles btnGerarUri.Click
        Try
            _config = New Config()
            _config.ClientId = txtClientId.Text
            _config.ClientSecret = txtClientSecret.Text
            _config.RedirectUri = txtRedirectUri.Text
            _config.Token = "None"
            _xmlManager.SaveConfig(_config)

            Dim spotifyApi As SpotifyApi = New SpotifyApi()
            spotifyApi.ClientId = txtClientId.Text
            spotifyApi.ClientSecret = txtClientSecret.Text
            spotifyApi.redirect_uri = txtRedirectUri.Text
            _autenticadorSpotify = New AutenticadorSpotify(spotifyApi)
            Dim uri As Uri = _autenticadorSpotify.GetLoginUrl()
            txtUri.Text = uri.ToString()

            MessageBox.Show("Uri gerada com sucesso!")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub btnGerarToken_Click(sender As Object, e As EventArgs) Handles btnGerarToken.Click
        Try
            Dim uriResponse As String = txtUriResposta.Text
            Dim token As Token = _autenticadorSpotify.GetAcessTokenByUrlCode(uriResponse)
            Dim tokenString As String = "{""access_token"":"" " & token.Access_token & " "",""token_type"":""Bearer"",""expires_in"":3600,""refresh_token"":""" & token.Refresh_token & """,""scope"":""playlist-read-private playlist-read-collaborative user-follow-read playlist-modify-private user-read-email user-read-private app-remote-control streaming user-modify-playback-state user-follow-modify user-library-read user-library-modify playlist-modify-public user-read-playback-state user-read-currently-playing user-read-recently-played user-read-playback-position user-top-read""}"

            config.ClientId = txtClientId.Text
            config.ClientSecret = txtClientSecret.Text
            config.RedirectUri = txtRedirectUri.Text

            config.Token = tokenString

            _xmlManager.SaveConfig(config)

            txtToken.Text = tokenString
            MessageBox.Show("Token gerado com sucesso!")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Me.Close()
    End Sub
End Class