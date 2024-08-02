Imports Vlc.DotNet.Forms
Imports vlcPlayer.Controls


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVLC
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVLC))
        Me.TimerBarraProgresso = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnlLateral = New System.Windows.Forms.Panel()
        Me.picRefresh = New System.Windows.Forms.PictureBox()
        Me.pnlUsuarioLogado = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSair = New System.Windows.Forms.Button()
        Me.lblNomeUsuarioLogado = New System.Windows.Forms.Label()
        Me.btnEntrarComSpotify = New System.Windows.Forms.Button()
        Me.picConfig = New System.Windows.Forms.PictureBox()
        Me.flpCards = New vlcPlayer.Controls.flowPanelCard()
        Me.pnlBuscar = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.picVoltarPanel = New System.Windows.Forms.PictureBox()
        Me.lblNavegacao = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.pnlBuffer = New System.Windows.Forms.Panel()
        Me.pnlProgresIn = New System.Windows.Forms.Panel()
        Me.picAleatorio = New System.Windows.Forms.PictureBox()
        Me.pnlDescricao = New System.Windows.Forms.Panel()
        Me.lblCurretArtist = New System.Windows.Forms.Label()
        Me.picCurrentPlaying = New System.Windows.Forms.PictureBox()
        Me.lblCurrentTrack = New System.Windows.Forms.Label()
        Me.lblMouseHover = New System.Windows.Forms.Label()
        Me.picAvancar = New System.Windows.Forms.PictureBox()
        Me.picVoltar = New System.Windows.Forms.PictureBox()
        Me.picReplay = New System.Windows.Forms.PictureBox()
        Me.picPlay = New System.Windows.Forms.PictureBox()
        Me.pnlProgressOut = New System.Windows.Forms.Panel()
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.trkVolume = New System.Windows.Forms.TrackBar()
        Me.picVolume = New System.Windows.Forms.PictureBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlLateral.SuspendLayout()
        CType(Me.picRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUsuarioLogado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBuscar.SuspendLayout()
        CType(Me.picVoltarPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.pnlBuffer.SuspendLayout()
        CType(Me.picAleatorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDescricao.SuspendLayout()
        CType(Me.picCurrentPlaying, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAvancar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVoltar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picReplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PnlLateral
        '
        Me.PnlLateral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlLateral.Controls.Add(Me.picRefresh)
        Me.PnlLateral.Controls.Add(Me.pnlUsuarioLogado)
        Me.PnlLateral.Controls.Add(Me.btnEntrarComSpotify)
        Me.PnlLateral.Controls.Add(Me.picConfig)
        Me.PnlLateral.Controls.Add(Me.flpCards)
        Me.PnlLateral.Controls.Add(Me.pnlBuscar)
        Me.PnlLateral.Controls.Add(Me.picVoltarPanel)
        Me.PnlLateral.Controls.Add(Me.lblNavegacao)
        Me.PnlLateral.Location = New System.Drawing.Point(0, -1)
        Me.PnlLateral.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PnlLateral.Name = "PnlLateral"
        Me.PnlLateral.Size = New System.Drawing.Size(1135, 631)
        Me.PnlLateral.TabIndex = 16
        '
        'picRefresh
        '
        Me.picRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picRefresh.Image = Global.vlcPlayer.My.Resources.Resources.recarregar
        Me.picRefresh.Location = New System.Drawing.Point(258, 86)
        Me.picRefresh.Name = "picRefresh"
        Me.picRefresh.Size = New System.Drawing.Size(33, 30)
        Me.picRefresh.TabIndex = 28
        Me.picRefresh.TabStop = False
        '
        'pnlUsuarioLogado
        '
        Me.pnlUsuarioLogado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUsuarioLogado.Controls.Add(Me.PictureBox1)
        Me.pnlUsuarioLogado.Controls.Add(Me.BtnSair)
        Me.pnlUsuarioLogado.Controls.Add(Me.lblNomeUsuarioLogado)
        Me.pnlUsuarioLogado.Location = New System.Drawing.Point(475, 21)
        Me.pnlUsuarioLogado.Name = "pnlUsuarioLogado"
        Me.pnlUsuarioLogado.Size = New System.Drawing.Size(350, 32)
        Me.pnlUsuarioLogado.TabIndex = 27
        Me.pnlUsuarioLogado.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.vlcPlayer.My.Resources.Resources.spotify
        Me.PictureBox1.Location = New System.Drawing.Point(314, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 29)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'BtnSair
        '
        Me.BtnSair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSair.FlatAppearance.BorderSize = 0
        Me.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSair.Location = New System.Drawing.Point(252, 4)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(56, 24)
        Me.BtnSair.TabIndex = 2
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSair.UseVisualStyleBackColor = True
        '
        'lblNomeUsuarioLogado
        '
        Me.lblNomeUsuarioLogado.AutoSize = True
        Me.lblNomeUsuarioLogado.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeUsuarioLogado.Location = New System.Drawing.Point(3, 8)
        Me.lblNomeUsuarioLogado.Name = "lblNomeUsuarioLogado"
        Me.lblNomeUsuarioLogado.Size = New System.Drawing.Size(143, 16)
        Me.lblNomeUsuarioLogado.TabIndex = 1
        Me.lblNomeUsuarioLogado.Text = "Bem-Vindo: ioafoiaj"
        '
        'btnEntrarComSpotify
        '
        Me.btnEntrarComSpotify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEntrarComSpotify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEntrarComSpotify.FlatAppearance.BorderSize = 0
        Me.btnEntrarComSpotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrarComSpotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntrarComSpotify.Image = Global.vlcPlayer.My.Resources.Resources.spotify
        Me.btnEntrarComSpotify.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEntrarComSpotify.Location = New System.Drawing.Point(847, 18)
        Me.btnEntrarComSpotify.Name = "btnEntrarComSpotify"
        Me.btnEntrarComSpotify.Size = New System.Drawing.Size(191, 39)
        Me.btnEntrarComSpotify.TabIndex = 26
        Me.btnEntrarComSpotify.Text = "Entrar Com Spotify"
        Me.btnEntrarComSpotify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEntrarComSpotify.UseVisualStyleBackColor = True
        '
        'picConfig
        '
        Me.picConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picConfig.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picConfig.Image = Global.vlcPlayer.My.Resources.Resources.config
        Me.picConfig.Location = New System.Drawing.Point(1086, 18)
        Me.picConfig.Name = "picConfig"
        Me.picConfig.Size = New System.Drawing.Size(40, 42)
        Me.picConfig.TabIndex = 25
        Me.picConfig.TabStop = False
        '
        'flpCards
        '
        Me.flpCards.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpCards.Location = New System.Drawing.Point(0, 116)
        Me.flpCards.Name = "flpCards"
        Me.flpCards.Navegacao = vlcPlayer.Controls.ENavegation.InCategory
        Me.flpCards.Size = New System.Drawing.Size(1135, 512)
        Me.flpCards.TabIndex = 24
        '
        'pnlBuscar
        '
        Me.pnlBuscar.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlBuscar.Controls.Add(Me.btnBuscar)
        Me.pnlBuscar.Controls.Add(Me.txtBuscar)
        Me.pnlBuscar.Location = New System.Drawing.Point(61, 5)
        Me.pnlBuscar.Name = "pnlBuscar"
        Me.pnlBuscar.Size = New System.Drawing.Size(408, 45)
        Me.pnlBuscar.TabIndex = 23
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = Global.vlcPlayer.My.Resources.Resources.procurar
        Me.btnBuscar.Location = New System.Drawing.Point(363, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(42, 37)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(23, 13)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(342, 19)
        Me.txtBuscar.TabIndex = 21
        '
        'picVoltarPanel
        '
        Me.picVoltarPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picVoltarPanel.Image = Global.vlcPlayer.My.Resources.Resources.volte
        Me.picVoltarPanel.Location = New System.Drawing.Point(11, 14)
        Me.picVoltarPanel.Name = "picVoltarPanel"
        Me.picVoltarPanel.Size = New System.Drawing.Size(24, 24)
        Me.picVoltarPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picVoltarPanel.TabIndex = 20
        Me.picVoltarPanel.TabStop = False
        '
        'lblNavegacao
        '
        Me.lblNavegacao.AutoSize = True
        Me.lblNavegacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNavegacao.Location = New System.Drawing.Point(7, 88)
        Me.lblNavegacao.Name = "lblNavegacao"
        Me.lblNavegacao.Size = New System.Drawing.Size(236, 25)
        Me.lblNavegacao.TabIndex = 19
        Me.lblNavegacao.Text = "Escolha uma Categoria"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.Transparent
        Me.pnlBottom.Controls.Add(Me.pnlBuffer)
        Me.pnlBottom.Controls.Add(Me.picAleatorio)
        Me.pnlBottom.Controls.Add(Me.pnlDescricao)
        Me.pnlBottom.Controls.Add(Me.lblMouseHover)
        Me.pnlBottom.Controls.Add(Me.picAvancar)
        Me.pnlBottom.Controls.Add(Me.picVoltar)
        Me.pnlBottom.Controls.Add(Me.picReplay)
        Me.pnlBottom.Controls.Add(Me.picPlay)
        Me.pnlBottom.Controls.Add(Me.pnlProgressOut)
        Me.pnlBottom.Controls.Add(Me.lblEndTime)
        Me.pnlBottom.Controls.Add(Me.lblCurrentTime)
        Me.pnlBottom.Controls.Add(Me.trkVolume)
        Me.pnlBottom.Controls.Add(Me.picVolume)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 634)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1135, 132)
        Me.pnlBottom.TabIndex = 24
        '
        'pnlBuffer
        '
        Me.pnlBuffer.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlBuffer.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.pnlBuffer.Controls.Add(Me.pnlProgresIn)
        Me.pnlBuffer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlBuffer.Location = New System.Drawing.Point(426, 107)
        Me.pnlBuffer.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBuffer.Name = "pnlBuffer"
        Me.pnlBuffer.Size = New System.Drawing.Size(491, 14)
        Me.pnlBuffer.TabIndex = 34
        '
        'pnlProgresIn
        '
        Me.pnlProgresIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlProgresIn.BackColor = System.Drawing.Color.Blue
        Me.pnlProgresIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlProgresIn.Location = New System.Drawing.Point(-18, 0)
        Me.pnlProgresIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlProgresIn.Name = "pnlProgresIn"
        Me.pnlProgresIn.Size = New System.Drawing.Size(261, 15)
        Me.pnlProgresIn.TabIndex = 0
        '
        'picAleatorio
        '
        Me.picAleatorio.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picAleatorio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAleatorio.Image = Global.vlcPlayer.My.Resources.Resources.aleatorio
        Me.picAleatorio.Location = New System.Drawing.Point(426, 48)
        Me.picAleatorio.Name = "picAleatorio"
        Me.picAleatorio.Size = New System.Drawing.Size(34, 28)
        Me.picAleatorio.TabIndex = 34
        Me.picAleatorio.TabStop = False
        '
        'pnlDescricao
        '
        Me.pnlDescricao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlDescricao.Controls.Add(Me.lblCurretArtist)
        Me.pnlDescricao.Controls.Add(Me.picCurrentPlaying)
        Me.pnlDescricao.Controls.Add(Me.lblCurrentTrack)
        Me.pnlDescricao.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlDescricao.Location = New System.Drawing.Point(7, 1)
        Me.pnlDescricao.Name = "pnlDescricao"
        Me.pnlDescricao.Size = New System.Drawing.Size(350, 133)
        Me.pnlDescricao.TabIndex = 17
        '
        'lblCurretArtist
        '
        Me.lblCurretArtist.AutoSize = True
        Me.lblCurretArtist.Location = New System.Drawing.Point(195, 62)
        Me.lblCurretArtist.Name = "lblCurretArtist"
        Me.lblCurretArtist.Size = New System.Drawing.Size(44, 16)
        Me.lblCurretArtist.TabIndex = 3
        Me.lblCurretArtist.Text = "Artista"
        '
        'picCurrentPlaying
        '
        Me.picCurrentPlaying.Location = New System.Drawing.Point(2, 4)
        Me.picCurrentPlaying.Name = "picCurrentPlaying"
        Me.picCurrentPlaying.Size = New System.Drawing.Size(186, 122)
        Me.picCurrentPlaying.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCurrentPlaying.TabIndex = 2
        Me.picCurrentPlaying.TabStop = False
        '
        'lblCurrentTrack
        '
        Me.lblCurrentTrack.AutoSize = True
        Me.lblCurrentTrack.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTrack.Location = New System.Drawing.Point(195, 26)
        Me.lblCurrentTrack.Name = "lblCurrentTrack"
        Me.lblCurrentTrack.Size = New System.Drawing.Size(56, 16)
        Me.lblCurrentTrack.TabIndex = 1
        Me.lblCurrentTrack.Text = "Música"
        '
        'lblMouseHover
        '
        Me.lblMouseHover.AutoSize = True
        Me.lblMouseHover.Location = New System.Drawing.Point(1148, 598)
        Me.lblMouseHover.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMouseHover.Name = "lblMouseHover"
        Me.lblMouseHover.Size = New System.Drawing.Size(38, 16)
        Me.lblMouseHover.TabIndex = 33
        Me.lblMouseHover.Text = "06:31"
        '
        'picAvancar
        '
        Me.picAvancar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picAvancar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAvancar.Image = Global.vlcPlayer.My.Resources.Resources.proximo_botao
        Me.picAvancar.Location = New System.Drawing.Point(693, 49)
        Me.picAvancar.Margin = New System.Windows.Forms.Padding(4)
        Me.picAvancar.Name = "picAvancar"
        Me.picAvancar.Size = New System.Drawing.Size(24, 24)
        Me.picAvancar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picAvancar.TabIndex = 31
        Me.picAvancar.TabStop = False
        '
        'picVoltar
        '
        Me.picVoltar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picVoltar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picVoltar.Image = Global.vlcPlayer.My.Resources.Resources.anterior
        Me.picVoltar.Location = New System.Drawing.Point(571, 49)
        Me.picVoltar.Margin = New System.Windows.Forms.Padding(4)
        Me.picVoltar.Name = "picVoltar"
        Me.picVoltar.Size = New System.Drawing.Size(24, 24)
        Me.picVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picVoltar.TabIndex = 30
        Me.picVoltar.TabStop = False
        '
        'picReplay
        '
        Me.picReplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picReplay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picReplay.Image = CType(resources.GetObject("picReplay.Image"), System.Drawing.Image)
        Me.picReplay.Location = New System.Drawing.Point(501, 49)
        Me.picReplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picReplay.Name = "picReplay"
        Me.picReplay.Size = New System.Drawing.Size(24, 24)
        Me.picReplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picReplay.TabIndex = 29
        Me.picReplay.TabStop = False
        '
        'picPlay
        '
        Me.picPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picPlay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPlay.Image = Global.vlcPlayer.My.Resources.Resources.toque
        Me.picPlay.Location = New System.Drawing.Point(629, 45)
        Me.picPlay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picPlay.Name = "picPlay"
        Me.picPlay.Size = New System.Drawing.Size(32, 32)
        Me.picPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picPlay.TabIndex = 16
        Me.picPlay.TabStop = False
        '
        'pnlProgressOut
        '
        Me.pnlProgressOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlProgressOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProgressOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlProgressOut.Location = New System.Drawing.Point(426, 108)
        Me.pnlProgressOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlProgressOut.Name = "pnlProgressOut"
        Me.pnlProgressOut.Size = New System.Drawing.Size(519, 13)
        Me.pnlProgressOut.TabIndex = 11
        '
        'lblEndTime
        '
        Me.lblEndTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Location = New System.Drawing.Point(960, 107)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(38, 16)
        Me.lblEndTime.TabIndex = 10
        Me.lblEndTime.Text = "00:00"
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.Location = New System.Drawing.Point(381, 107)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(38, 16)
        Me.lblCurrentTime.TabIndex = 9
        Me.lblCurrentTime.Text = "00:00"
        '
        'trkVolume
        '
        Me.trkVolume.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.trkVolume.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trkVolume.Location = New System.Drawing.Point(818, 45)
        Me.trkVolume.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.trkVolume.Name = "trkVolume"
        Me.trkVolume.Size = New System.Drawing.Size(127, 56)
        Me.trkVolume.TabIndex = 20
        Me.trkVolume.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'picVolume
        '
        Me.picVolume.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.picVolume.BackColor = System.Drawing.Color.Transparent
        Me.picVolume.Image = Global.vlcPlayer.My.Resources.Resources.som
        Me.picVolume.Location = New System.Drawing.Point(765, 49)
        Me.picVolume.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picVolume.Name = "picVolume"
        Me.picVolume.Size = New System.Drawing.Size(24, 24)
        Me.picVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picVolume.TabIndex = 26
        Me.picVolume.TabStop = False
        '
        'frmVLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 766)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.PnlLateral)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(100, 100)
        Me.Name = "frmVLC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vlc Player"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlLateral.ResumeLayout(False)
        Me.PnlLateral.PerformLayout()
        CType(Me.picRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUsuarioLogado.ResumeLayout(False)
        Me.pnlUsuarioLogado.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBuscar.ResumeLayout(False)
        Me.pnlBuscar.PerformLayout()
        CType(Me.picVoltarPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.pnlBuffer.ResumeLayout(False)
        CType(Me.picAleatorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDescricao.ResumeLayout(False)
        Me.pnlDescricao.PerformLayout()
        CType(Me.picCurrentPlaying, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAvancar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVoltar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picReplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerBarraProgresso As Timer
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents lblCurrentTime As Label
    Friend WithEvents lblEndTime As Label
    Friend WithEvents pnlProgressOut As Panel
    Friend WithEvents pnlProgresIn As Panel
    Friend WithEvents PnlLateral As Panel
    Friend WithEvents trkVolume As TrackBar
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents picVolume As PictureBox
    Friend WithEvents picReplay As PictureBox
    Friend WithEvents picAvancar As PictureBox
    Friend WithEvents picVoltar As PictureBox
    Friend WithEvents lblMouseHover As Label
    Friend WithEvents pnlBuffer As Panel
    Friend WithEvents picPlay As PictureBox
    Friend WithEvents pnlDescricao As Panel
    Friend WithEvents lblCurrentTrack As Label
    Friend WithEvents lblNavegacao As Label
    Friend WithEvents picVoltarPanel As PictureBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents picCurrentPlaying As PictureBox
    Friend WithEvents lblCurretArtist As Label
    Friend WithEvents pnlBuscar As Panel
    Friend WithEvents picAleatorio As PictureBox
    Friend WithEvents flpCards As Controls.flowPanelCard
    Friend WithEvents picConfig As PictureBox
    Friend WithEvents btnEntrarComSpotify As Button
    Friend WithEvents pnlUsuarioLogado As Panel
    Friend WithEvents lblNomeUsuarioLogado As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnSair As Button
    Friend WithEvents picRefresh As PictureBox
End Class
