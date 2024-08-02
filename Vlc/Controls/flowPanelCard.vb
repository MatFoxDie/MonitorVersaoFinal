Namespace Controls
    Public Class flowPanelCard
        Inherits FlowLayoutPanel

        Public Event NavegationChanged As NavegationChangedEventHandler
        Private _navegacao As ENavegation
        Public Property Navegacao As ENavegation
            Get
                Return _navegacao
            End Get
            Set(value As ENavegation)
                _navegacao = value
                RaiseEvent NavegationChanged(Me, New NavegationChangedEventArgs(value))
            End Set
        End Property


    End Class
End Namespace
