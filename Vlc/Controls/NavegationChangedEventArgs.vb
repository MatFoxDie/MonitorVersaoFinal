Namespace Controls


    Public Delegate Sub NavegationChangedEventHandler(sender As Object, e As NavegationChangedEventArgs)
    Public Class NavegationChangedEventArgs
        Inherits EventArgs
        Public Property Navegacao As ENavegation

        Public Sub New(navegacao As ENavegation)
            Me.Navegacao = navegacao
        End Sub

    End Class
End Namespace
