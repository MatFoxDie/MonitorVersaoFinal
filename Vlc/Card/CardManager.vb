Imports System.Drawing.Drawing2D
Imports Spotify.Spotify.Api.Models
Imports vlcPlayer.Controls
Imports vlcPlayer.Vlc.Card

Public Class CardManager

    Private _flpCards As flowPanelCard
    Private _frm As frmVLC

    Sub New(flpCards As flowPanelCard, frm As frmVLC)
        _flpCards = flpCards
        _frm = frm
        AddHandler _flpCards.NavegationChanged, AddressOf NavegationChanged
    End Sub

    Private Sub NavegationChanged(sender As Object, e As NavegationChangedEventArgs)
        Try
            Dim tempBuscar = _frm.txtBuscar.Text
            _frm.resetBuscar()
            _flpCards.Controls.Clear()
            Select Case e.Navegacao
                Case ENavegation.InCategory
                    _frm.picRefresh.Visible = False
                    _frm.lblNavegacao.Text = "Escolha uma Categoria"
                    _frm.CarregarCategoryCards()
                Case ENavegation.InSearch
                    _frm.picRefresh.Visible = False
                    _frm.lblNavegacao.Text = $"Resultados para: {tempBuscar}"
                Case ENavegation.InPlaylist
                    _frm.picRefresh.Visible = False
                    _frm.lblNavegacao.Text = "Escolha uma Playlist"
                Case ENavegation.InMusics
                    _frm.pnlDescricao.Enabled = False
                    _frm.lblNavegacao.Text = "Escolha uma Música"
                Case ENavegation.InRandom
                    _frm.lblNavegacao.Text = "Músicas Aleatórias"
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Sub addCard(card As Card, flpPanel As Control)
        Try
            Dim novoCard As New Panel
            novoCard.Size = card.Size
            ArredondarPanel(novoCard, 20)

            Dim pb As New PictureBox()
            pb.Size = New Size(150, 150)
            pb.Location = New Point((novoCard.Width - pb.Width) \ 2, 10)
            pb.Image = card.Image
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            novoCard.Controls.Add(pb)

            Dim lblTitulo As New Label()
            lblTitulo.Text = card.Name
            lblTitulo.Font = New Font("Arial", 10, FontStyle.Bold)
            lblTitulo.AutoSize = True
            Dim larguraLabel = lblTitulo.Width
            lblTitulo.Location = New Point(novoCard.Width / 2, pb.Bottom + 10)
            novoCard.Controls.Add(lblTitulo)

            If card.Description <> "" Then
                Dim lblDescricao As New Label()
                lblDescricao.Text = card.Description
                lblDescricao.AutoSize = True
                lblDescricao.Location = New Point((novoCard.Width - lblDescricao.Width) \ 2, lblTitulo.Bottom + 10)
                lblDescricao.Visible = True
                novoCard.Controls.Add(lblDescricao)
                novoCard.Refresh()
            End If

            novoCard.Tag = card
            novoCard.Cursor = Cursors.Hand

            AddHandler pb.Click, AddressOf PictureBox_Click
            AddHandler pb.MouseEnter, AddressOf PictureBox_MouseEnter
            AddHandler lblTitulo.Click, AddressOf Title_click
            AddHandler lblTitulo.MouseEnter, AddressOf Title_MouseEnter
            AddHandler novoCard.Click, AddressOf card_Click
            AddHandler novoCard.MouseEnter, AddressOf card_MouseEnter
            AddHandler novoCard.MouseLeave, AddressOf card_MouseLeave

            flpPanel.Controls.Add(novoCard)

            'precisa reposicionar o label depois de carregar para poder centralizar com o real tamanho dele com o autosize
            For Each panel As Panel In flpPanel.Controls
                For Each control As Control In panel.Controls
                    If TypeOf control Is Label Then
                        Dim label As Label = control
                        label = ajustarLinha(label, panel)
                        label.Location = New Point((panel.Width - label.Width) \ 2, label.Location.Y)
                    End If
                Next
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub card_MouseLeave(sender As Object, e As EventArgs)
        Try
            sender.backcolor = Color.Transparent
            sender.Refresh()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub card_MouseEnter(sender As Object, e As EventArgs)
        Try
            Dim flowpanellist As List(Of FlowLayoutPanel) = New List(Of FlowLayoutPanel)
            flowpanellist.Add(_flpCards)
            For Each control As Control In _flpCards.Controls
                If TypeOf control Is FlowLayoutPanel Then
                    flowpanellist.Add(control)
                End If
            Next
            For Each panel In flowpanellist
                For Each control As Control In panel.Controls
                    If TypeOf control Is Panel And control IsNot sender Then
                        control.BackColor = Color.Transparent
                        control.Refresh()
                    End If
                Next
            Next

            sender.backcolor = Color.LightBlue
            sender.Refresh()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub card_Click(sender As Object, e As EventArgs)
        Try
            If sender.tag Is Nothing Then Return
            Dim panelCliked As Panel = sender
            Dim panels As List(Of Panel) = GetFlowLayoutPanelControls()
            Dim pictureBox As PictureBox = _frm.GetPictureBoxFromSender(sender)
            Dim card As Card = sender.tag
            Select Case card.Type
                Case ECardType.Category
                    _frm.HandleCategoryClick(card.Tag, pictureBox, panels)
                Case ECardType.Playlist
                    _frm.HandlePlaylistClick(panelCliked, card.Tag, pictureBox, panels)
                Case ECardType.Track
                    _frm.HandleTrackClick(panelCliked, card.Tag, pictureBox, panels)
                Case ECardType.FeateredPlaylists
                    _frm.HandleFeateredPlaylistsClick()
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub Title_MouseEnter(sender As Object, e As EventArgs)
        Try
            Dim labelHover As Label = sender
            Dim panelParent As Panel = labelHover.Parent
            card_MouseEnter(panelParent, e)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Sub Title_click(sender As Object, e As EventArgs)
        Try
            Dim labelClicked As Label = sender
            Dim panelParent As Panel = labelClicked.Parent
            Console.WriteLine(sender.width)
            card_Click(panelParent, e)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox_MouseEnter(sender As Object, e As EventArgs)
        Try
            Dim pictureBoxHover As PictureBox = sender
            Dim panelParent As Panel = pictureBoxHover.Parent
            card_MouseEnter(panelParent, e)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub PictureBox_Click(sender As Object, e As EventArgs)
        Try
            Dim pictureBoxClicked As PictureBox = sender
            Dim panelParent As Panel = pictureBoxClicked.Parent
            card_Click(panelParent, e)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub ArredondarPanel(panel As Panel, cornerRadius As Integer)
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

    Private Function ajustarLinha(label As Label, panel As Panel) As Label
        Try
            If label.ClientSize.Width > panel.ClientSize.Width Then
                Dim texto As String = label.Text
                For i As Integer = texto.Length - 1 To 0 Step -1
                    If texto(i) = " " Then
                        Dim textoParcial As String = texto.Substring(0, i)
                        label.Text = textoParcial
                        If label.Width <= panel.Width Then
                            Exit For
                        End If
                    End If
                Next
            End If
            Return label
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

    Private Function GetFlowLayoutPanelControls() As List(Of Panel)
        Try
            Dim panels As New List(Of Panel)
            For Each control As Control In _flpCards.Controls
                If TypeOf control Is FlowLayoutPanel Then
                    panels.Add(control)
                End If
            Next
            panels.Add(_flpCards)
            Return panels
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Function

End Class
