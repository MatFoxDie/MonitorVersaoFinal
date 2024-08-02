<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWebSpotify
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
        Me.WebView1 = New EO.WebBrowser.WebView()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.WebView22 = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebView22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Location = New System.Drawing.Point(0, 66)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(863, 758)
        Me.WebView21.TabIndex = 1
        Me.WebView21.ZoomFactor = 1.0R
        '
        'WebView22
        '
        Me.WebView22.AllowExternalDrop = True
        Me.WebView22.CreationProperties = Nothing
        Me.WebView22.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView22.Location = New System.Drawing.Point(362, 254)
        Me.WebView22.Name = "WebView22"
        Me.WebView22.Size = New System.Drawing.Size(8, 8)
        Me.WebView22.TabIndex = 2
        Me.WebView22.ZoomFactor = 1.0R
        '
        'frmWebSpotify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 826)
        Me.Controls.Add(Me.WebView22)
        Me.Controls.Add(Me.WebView21)
        Me.Name = "frmWebSpotify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login com Spotify"
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebView22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebView1 As EO.WebBrowser.WebView
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents WebView22 As Microsoft.Web.WebView2.WinForms.WebView2
End Class
