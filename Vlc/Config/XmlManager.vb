Imports System.IO

Namespace Config
    Public Class XmlManager
        Private _xmlPath As String
        Sub New()
            _xmlPath = GetPath()
        End Sub

        Public Function GetCategorias() As List(Of XmlCategoria)
            Try
                Dim categorias As New List(Of XmlCategoria)
                Dim ds As New DataSet
                ds.ReadXml(_xmlPath)
                For Each row As DataRow In ds.Tables(0).Rows
                    Dim categoria As New XmlCategoria
                    categoria.Id = row("Id")
                    categoria.Name = row("Name")
                    categorias.Add(categoria)
                Next
                Return categorias
            Catch ex As Exception

            End Try
        End Function

        Public Sub ChangeCategorias(categorias As List(Of XmlCategoria))
            Try
                Dim ds As New DataSet
                ds.ReadXml(_xmlPath)

                ' Limpa as linhas existentes no DataSet
                ds.Tables(0).Rows.Clear()

                ' Adiciona as novas categorias ao DataSet
                For Each categoria As XmlCategoria In categorias
                    Dim row As DataRow = ds.Tables(0).NewRow
                    row("Id") = categoria.Id
                    row("Name") = categoria.Name
                    ds.Tables(0).Rows.Add(row)
                Next

                ' Escreve o DataSet de volta no arquivo XML
                ds.WriteXml(_xmlPath)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Function GetPath() As String
            Dim NomeProjetoVlc = "Vlc"
            Dim diretorioSolucao As String = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)))
            Dim configPath As String = diretorioSolucao & $"\{NomeProjetoVlc}\Config\Config.xml"
            Return configPath
        End Function
    End Class

End Namespace