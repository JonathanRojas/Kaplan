Imports System.Data.OleDb

Namespace Clases
    Public Class ConsultaMaquinasKine
        Public Property id_paciente As Integer
        Public Property numero_ficha As Integer
        Public Property sexo As String
        Public Property situacion_laboral As String
        Public Property peso_actual As String
        Public Property talla As String

        Public Shared Function getListado() As List(Of ConsultaMaquinasKine)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("ExportarData", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListado = New List(Of ConsultaMaquinasKine)
                For Each vRow As DataRow In vDataTable.Rows
                    getListado.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListado
            Catch exc As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As ConsultaMaquinasKine
            Try
                Dim vClass As New ConsultaMaquinasKine
                vClass.id_paciente = prmRow("id_paciente").ToString
                vClass.numero_ficha = prmRow("numero_ficha").ToString
                vClass.sexo = prmRow("sexo").ToString
                vClass.situacion_laboral = prmRow("situacion_laboral").ToString
                vClass.peso_actual = prmRow("peso_actual").ToString
                vClass.talla = prmRow("talla").ToString

                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace

