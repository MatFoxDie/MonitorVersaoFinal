Imports Spotify.Spotify.Api
Imports Spotify.Spotify.Api.Models
Imports Spotify.Spotify.Models
Imports vlcPlayer.Config

Public Class frmConfig

    Private _spotifyApi As SpotifyApi
    Private _xmlManager As XmlManager
    Sub New()
        InitializeComponent()
        _spotifyApi = New SpotifyApi()
        _xmlManager = New XmlManager()
        ConfigControls()
    End Sub

    Private Sub ConfigControls()
        Dim xlmCategorias As New XmlCategoria()
        Dim categorias As List(Of XmlCategoria) = GetApiCategories()
        Dim categoriasSeleccionadas As List(Of XmlCategoria) = _xmlManager.GetCategorias()
        AddCategoriesToFlowPanel(categorias, categoriasSeleccionadas)

    End Sub

    Private Function GetApiCategories() As List(Of XmlCategoria)
        Dim categories = _spotifyApi.GetCategories(0, 50)
        Return ConverToXmlCategories(categories)
    End Function

    Private Function ConverToXmlCategories(categorieResponse As CategoriesResponse) As List(Of XmlCategoria)
        Dim xmlCategories As New List(Of XmlCategoria)
        For Each categorie In categorieResponse.categories.items
            Dim xmlCategorie As New XmlCategoria
            xmlCategorie.Id = categorie.id
            xmlCategorie.Name = categorie.name
            xmlCategories.Add(xmlCategorie)
        Next
        Return xmlCategories
    End Function


    Private Sub AddCategoriesToFlowPanel(categorias As List(Of XmlCategoria), categoriasSelecionadas As List(Of XmlCategoria))
        Try
            For Each categoria As XmlCategoria In categorias
                Dim panel As Panel = New Panel
                panel.Size = New Size(100, 100)
                panel.Cursor = Cursors.Hand

                Dim label As Label = New Label
                label.Text = categoria.Name
                label.Location = New Point(25, 10)
                label.AutoSize = True
                label.Font = New Font("Arial", 8, FontStyle.Bold)
                panel.Controls.Add(label)
                panel.Cursor = Cursors.Hand

                Dim checkBox As CheckBox = New CheckBox
                checkBox.AutoSize = True
                checkBox.Location = New Point(5, 10)
                panel.Controls.Add(checkBox)
                panel.Cursor = Cursors.Hand
                If categoriasSelecionadas IsNot Nothing AndAlso categoriasSelecionadas.Exists(Function(x) x.Id = categoria.Id) Then
                    checkBox.Checked = True
                End If


                panel.Tag = categoria
                flpCategorias.Controls.Add(panel)

                AddHandler checkBox.MouseEnter, AddressOf checkBox_MouseEnter
                AddHandler label.MouseEnter, AddressOf label_MouseEnter
                AddHandler panel.MouseLeave, AddressOf Panel_MouseLeave
                AddHandler panel.MouseEnter, AddressOf Panel_MouseEnter
                AddHandler panel.Click, AddressOf Panel_Click
                AddHandler label.Click, AddressOf label_Click

                For Each control As Control In flpCategorias.Controls
                    If TypeOf control Is Panel Then
                        For Each control2 As Control In control.Controls
                            If TypeOf control2 Is Label Then
                                control.Size = New Size(control2.Width + 30, 30)
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


    Private Sub checkBox_MouseEnter(sender As Object, e As EventArgs)
        Dim panelParent As Panel = sender.Parent
        ChangePanelColor(panelParent, True)
    End Sub
    Private Sub label_MouseEnter(sender As Object, e As EventArgs)
        Dim panelParent As Panel = sender.Parent
        ChangePanelColor(panelParent, True)
    End Sub

    Private Sub Panel_MouseLeave(sender As Object, e As EventArgs)
        ChangePanelColor(sender, False)
    End Sub

    Private Sub Panel_MouseEnter(sender As Object, e As EventArgs)
        ChangePanelColor(sender, True)
    End Sub

    Private Sub label_Click(sender As Object, e As EventArgs)
        Dim label As Label = sender
        Dim panel As Panel = label.Parent
        check(panel)
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = sender
        check(panel)

    End Sub

    Private Sub check(panel As Panel)
        Dim checkBox As CheckBox
        For Each control As Control In panel.Controls
            If TypeOf control Is CheckBox Then
                checkBox = control
            End If
        Next
        If checkBox.Checked Then
            checkBox.Checked = False
        Else
            checkBox.Checked = True
        End If
    End Sub

    Private Sub ChangePanelColor(panel As Panel, change As Boolean)
        If change Then
            panel.BackColor = Color.LightGray
        Else
            panel.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim categorias As List(Of XmlCategoria) = GetSelectedCategories()
        _xmlManager.ChangeCategorias(categorias)
        Me.Close()
    End Sub

    Private Function GetSelectedCategories() As List(Of XmlCategoria)
        Dim categorias As New List(Of XmlCategoria)
        For Each control As Control In flpCategorias.Controls
            If TypeOf control Is Panel Then
                Dim panel As Panel = control
                Dim checkBox As CheckBox
                For Each control2 As Control In panel.Controls
                    If TypeOf control2 Is CheckBox Then
                        checkBox = control2
                    End If
                Next
                If checkBox.Checked Then
                    Dim panelCategoria As XmlCategoria = panel.Tag
                    categorias.Add(panelCategoria)
                End If
            End If
        Next
        Return categorias
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class