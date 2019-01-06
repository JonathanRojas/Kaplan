Namespace Clases
    Public Class HistoriaCronica
        Public Property Id As Integer
        Public Property colId As String
        Public Property Historia As String

        Public Shared Function MapeoHistoriaCronica(prmDatos As DataTable) As List(Of HistoriaCronica)
            Try
                MapeoHistoriaCronica = New List(Of HistoriaCronica)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New HistoriaCronica
                    vClass.Id = vRow("id_medicamento").ToString
                    vClass.colId = "colId" & vRow("id_medicamento").ToString
                    vClass.Historia = vRow("nombre").ToString
                    MapeoHistoriaCronica.Add(vClass)
                Next
                Return MapeoHistoriaCronica
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace