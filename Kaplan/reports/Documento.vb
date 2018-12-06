Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Documento
        Public Property Documento As Byte()
        Public Property Formato As String
        Public Shared Function obtenerDocumento(inTipo As Integer, inId As Integer) As Documento
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("BuscarDocumento", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Tipo As OleDbParameter = cmd.Parameters.Add("@inTipo", OleDbType.Decimal, Nothing)
                Tipo.Direction = ParameterDirection.Input
                Tipo.Value = inTipo

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    obtenerDocumento = Mapeo(vDataSet)
                End If
                Return obtenerDocumento
            Catch exc As Exception
                Return Nothing
            End Try
        End Function
        Private Shared Function Mapeo(prmDatos As DataSet) As Documento
            Dim vDocumento As New Documento
            Dim vDatos As DataRow = prmDatos.Tables(0).Rows(0)

            vDocumento.Documento = vDatos("DOCUMENTO")
            vDocumento.Formato = vDatos("FORMATO")
            Return vDocumento
        End Function
    End Class
End Namespace

