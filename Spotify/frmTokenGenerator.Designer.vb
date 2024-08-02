<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTokenGenerator
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
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
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 543)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Token"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Client Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cliente Secrect"
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(54, 571)
        Me.txtToken.Name = "txtToken"
        Me.txtToken.Size = New System.Drawing.Size(511, 22)
        Me.txtToken.TabIndex = 3
        '
        'txtClientId
        '
        Me.txtClientId.Location = New System.Drawing.Point(54, 53)
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.Size = New System.Drawing.Size(511, 22)
        Me.txtClientId.TabIndex = 4
        '
        'txtClientSecret
        '
        Me.txtClientSecret.Location = New System.Drawing.Point(54, 135)
        Me.txtClientSecret.Name = "txtClientSecret"
        Me.txtClientSecret.Size = New System.Drawing.Size(511, 22)
        Me.txtClientSecret.TabIndex = 5
        '
        'btnGerarUri
        '
        Me.btnGerarUri.Location = New System.Drawing.Point(466, 261)
        Me.btnGerarUri.Name = "btnGerarUri"
        Me.btnGerarUri.Size = New System.Drawing.Size(99, 23)
        Me.btnGerarUri.TabIndex = 6
        Me.btnGerarUri.Text = "Gerar Url"
        Me.btnGerarUri.UseVisualStyleBackColor = True
        '
        'txtUri
        '
        Me.txtUri.Location = New System.Drawing.Point(54, 369)
        Me.txtUri.Name = "txtUri"
        Me.txtUri.Size = New System.Drawing.Size(511, 22)
        Me.txtUri.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Url"
        '
        'btnGerarToken
        '
        Me.btnGerarToken.Location = New System.Drawing.Point(466, 504)
        Me.btnGerarToken.Name = "btnGerarToken"
        Me.btnGerarToken.Size = New System.Drawing.Size(99, 23)
        Me.btnGerarToken.TabIndex = 9
        Me.btnGerarToken.Text = "Gerar Token"
        Me.btnGerarToken.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(466, 643)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(99, 23)
        Me.btnSalvar.TabIndex = 10
        Me.btnSalvar.Text = "Fechar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'txtUriResposta
        '
        Me.txtUriResposta.Location = New System.Drawing.Point(54, 447)
        Me.txtUriResposta.Name = "txtUriResposta"
        Me.txtUriResposta.Size = New System.Drawing.Size(511, 22)
        Me.txtUriResposta.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Url Resposta"
        '
        'txtRedirectUri
        '
        Me.txtRedirectUri.Location = New System.Drawing.Point(54, 208)
        Me.txtRedirectUri.Name = "txtRedirectUri"
        Me.txtRedirectUri.Size = New System.Drawing.Size(511, 22)
        Me.txtRedirectUri.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Redirect Uri"
        '
        'frmTokenGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 712)
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
        Me.Name = "frmTokenGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTokenGenerator"
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
End Class
