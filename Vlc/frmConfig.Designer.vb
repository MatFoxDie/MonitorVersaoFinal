﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Me.lblModoAleatorio = New System.Windows.Forms.Label()
        Me.flpCategorias = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSelecioneCategorias = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblModoAleatorio
        '
        Me.lblModoAleatorio.AutoSize = True
        Me.lblModoAleatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModoAleatorio.Location = New System.Drawing.Point(12, 43)
        Me.lblModoAleatorio.Name = "lblModoAleatorio"
        Me.lblModoAleatorio.Size = New System.Drawing.Size(135, 20)
        Me.lblModoAleatorio.TabIndex = 0
        Me.lblModoAleatorio.Text = "Modo Aleatório"
        '
        'flpCategorias
        '
        Me.flpCategorias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpCategorias.AutoScroll = True
        Me.flpCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpCategorias.Location = New System.Drawing.Point(12, 111)
        Me.flpCategorias.Name = "flpCategorias"
        Me.flpCategorias.Size = New System.Drawing.Size(633, 249)
        Me.flpCategorias.TabIndex = 1
        '
        'lblSelecioneCategorias
        '
        Me.lblSelecioneCategorias.AutoSize = True
        Me.lblSelecioneCategorias.Location = New System.Drawing.Point(12, 88)
        Me.lblSelecioneCategorias.Name = "lblSelecioneCategorias"
        Me.lblSelecioneCategorias.Size = New System.Drawing.Size(156, 16)
        Me.lblSelecioneCategorias.TabIndex = 2
        Me.lblSelecioneCategorias.Text = "Selecione as categorias:"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmar.Location = New System.Drawing.Point(545, 507)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(100, 29)
        Me.btnConfirmar.TabIndex = 3
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(428, 507)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 549)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.lblSelecioneCategorias)
        Me.Controls.Add(Me.flpCategorias)
        Me.Controls.Add(Me.lblModoAleatorio)
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurações"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblModoAleatorio As Label
    Friend WithEvents flpCategorias As FlowLayoutPanel
    Friend WithEvents lblSelecioneCategorias As Label
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnCancelar As Button
End Class
