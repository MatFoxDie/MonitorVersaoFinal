<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTokenGenerator
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
    Private toolTip1 As System.Windows.Forms.ToolTip

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.txtClientId = New System.Windows.Forms.TextBox()
        Me.txtClientSecret = New System.Windows.Forms.TextBox()
        Me.btnGerarUri = New System.Windows.Forms.Button()
        Me.txtUri = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGerarToken = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.txtUriResposta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRedirectUri = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFecharSpotify = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client Id"
        Me.toolTip1.SetToolTip(Me.Label1, "Insira o Client Id aqui")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Client Secret"
        Me.toolTip1.SetToolTip(Me.Label2, "Insira o Client Secret aqui")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 114)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Redirect Uri"
        Me.toolTip1.SetToolTip(Me.Label3, "Insira o Redirect Uri aqui")
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(15, 244)
        Me.txtToken.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtToken.Name = "txtToken"
        Me.txtToken.Size = New System.Drawing.Size(384, 20)
        Me.txtToken.TabIndex = 3
        Me.toolTip1.SetToolTip(Me.txtToken, "O Token gerado aparecerá aqui")
        '
        'txtClientId
        '
        Me.txtClientId.Location = New System.Drawing.Point(90, 16)
        Me.txtClientId.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.Size = New System.Drawing.Size(309, 20)
        Me.txtClientId.TabIndex = 4
        Me.toolTip1.SetToolTip(Me.txtClientId, "Insira o Client Id")
        '
        'txtClientSecret
        '
        Me.txtClientSecret.Location = New System.Drawing.Point(90, 49)
        Me.txtClientSecret.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtClientSecret.Name = "txtClientSecret"
        Me.txtClientSecret.Size = New System.Drawing.Size(309, 20)
        Me.txtClientSecret.TabIndex = 5
        Me.toolTip1.SetToolTip(Me.txtClientSecret, "Insira o Client Secret")
        '
        'btnGerarUri
        '
        Me.btnGerarUri.Location = New System.Drawing.Point(324, 114)
        Me.btnGerarUri.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGerarUri.Name = "btnGerarUri"
        Me.btnGerarUri.Size = New System.Drawing.Size(74, 19)
        Me.btnGerarUri.TabIndex = 6
        Me.btnGerarUri.Text = "Gerar Url"
        Me.toolTip1.SetToolTip(Me.btnGerarUri, "Clique para gerar a URL")
        Me.btnGerarUri.UseVisualStyleBackColor = True
        '
        'txtUri
        '
        Me.txtUri.Location = New System.Drawing.Point(90, 146)
        Me.txtUri.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtUri.Name = "txtUri"
        Me.txtUri.Size = New System.Drawing.Size(309, 20)
        Me.txtUri.TabIndex = 8
        Me.toolTip1.SetToolTip(Me.txtUri, "A URL gerada aparecerá aqui")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Url"
        Me.toolTip1.SetToolTip(Me.Label4, "Insira a URL gerada")
        '
        'btnGerarToken
        '
        Me.btnGerarToken.Location = New System.Drawing.Point(324, 211)
        Me.btnGerarToken.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGerarToken.Name = "btnGerarToken"
        Me.btnGerarToken.Size = New System.Drawing.Size(74, 19)
        Me.btnGerarToken.TabIndex = 9
        Me.btnGerarToken.Text = "Gerar Token"
        Me.toolTip1.SetToolTip(Me.btnGerarToken, "Clique para gerar o Token")
        Me.btnGerarToken.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(295, 276)
        Me.btnSalvar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(104, 25)
        Me.btnSalvar.TabIndex = 10
        Me.btnSalvar.Text = "Fechar"
        Me.toolTip1.SetToolTip(Me.btnSalvar, "Clique para fechar o formulário")
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'txtUriResposta
        '
        Me.txtUriResposta.Location = New System.Drawing.Point(90, 179)
        Me.txtUriResposta.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtUriResposta.Name = "txtUriResposta"
        Me.txtUriResposta.Size = New System.Drawing.Size(309, 20)
        Me.txtUriResposta.TabIndex = 12
        Me.toolTip1.SetToolTip(Me.txtUriResposta, "A resposta da URL será exibida aqui")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 179)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Url Resposta"
        Me.toolTip1.SetToolTip(Me.Label5, "Insira a URL de resposta")
        '
        'txtRedirectUri
        '
        Me.txtRedirectUri.Location = New System.Drawing.Point(90, 114)
        Me.txtRedirectUri.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtRedirectUri.Name = "txtRedirectUri"
        Me.txtRedirectUri.Size = New System.Drawing.Size(226, 20)
        Me.txtRedirectUri.TabIndex = 14
        Me.toolTip1.SetToolTip(Me.txtRedirectUri, "Insira o Redirect Uri")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 244)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Token"
        Me.toolTip1.SetToolTip(Me.Label6, "O Token gerado será exibido aqui")
        '
        'btnFecharSpotify
        '
        Me.btnFecharSpotify.BackColor = System.Drawing.Color.Red
        Me.btnFecharSpotify.Location = New System.Drawing.Point(18, 276)
        Me.btnFecharSpotify.Name = "btnFecharSpotify"
        Me.btnFecharSpotify.Size = New System.Drawing.Size(104, 25)
        Me.btnFecharSpotify.TabIndex = 15
        Me.btnFecharSpotify.Text = "Fechar Spotify"
        Me.btnFecharSpotify.UseVisualStyleBackColor = False
        '
        'frmTokenGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 313)
        Me.Controls.Add(Me.btnFecharSpotify)
        Me.Controls.Add(Me.txtRedirectUri)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUriResposta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnGerarToken)
        Me.Controls.Add(Me.txtUri)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnGerarUri)
        Me.Controls.Add(Me.txtClientSecret)
        Me.Controls.Add(Me.txtClientId)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmTokenGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Token Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtToken As TextBox
    Friend WithEvents txtClientId As TextBox
    Friend WithEvents txtClientSecret As TextBox
    Friend WithEvents btnGerarUri As Button
    Friend WithEvents txtUri As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGerarToken As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents txtUriResposta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRedirectUri As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents toolTip As ToolTip
    Friend WithEvents btnFecharSpotify As Button
End Class
