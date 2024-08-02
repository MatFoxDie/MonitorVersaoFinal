Namespace Spotify.Controls

    Public Class RoudedPanel
        Inherits Panel
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
            Dim arcSize As Integer = 16 ' Tamanho do arco

            ' Desenha o fundo do painel
            g.FillRectangle(New SolidBrush(Me.BackColor), rect)

            ' Desenha as bordas arredondadas
            Dim path As New Drawing2D.GraphicsPath()
            path.StartFigure()
            path.AddArc(New Rectangle(0, 0, arcSize, arcSize), 180, 90)
            path.AddArc(New Rectangle(rect.Width - arcSize, 0, arcSize, arcSize), 270, 90)
            path.AddArc(New Rectangle(rect.Width - arcSize, rect.Height - arcSize, arcSize, arcSize), 0, 90)
            path.AddArc(New Rectangle(0, rect.Height - arcSize, arcSize, arcSize), 90, 90)
            path.CloseFigure()

            ' Aplica o desenho das bordas arredondadas
            Me.Region = New Region(path)

            ' Desenha o conteúdo do painel
            MyBase.OnPaint(e)
        End Sub

    End Class

End Namespace
