Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Examen
        Public Property Id As Integer
        Public Property Paciente As Integer
        Public Property Nombre As String
        Public Property Especialista As Integer
        Public Property Fecha As Date
        Public Property Descripcion As String
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Function registrarExamen(archivo As Byte(), formato As String) As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("RegistrarExamen", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = 1

                Dim Paciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                Paciente.Direction = ParameterDirection.Input
                Paciente.Value = 1

                Dim Especialista As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                Especialista.Direction = ParameterDirection.Input
                Especialista.Value = 1

                Dim inFecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.Date, Nothing)
                inFecha.Direction = ParameterDirection.Input
                inFecha.Value = Fecha

                Dim Documento As OleDbParameter = cmd.Parameters.Add("@inArchivo", OleDbType.VarBinary, -1)
                Documento.Direction = ParameterDirection.Input
                Documento.Value = archivo

                Dim Descripcion As OleDbParameter = cmd.Parameters.Add("@inDescripcion", OleDbType.VarChar, 500)
                Descripcion.Direction = ParameterDirection.Input
                Descripcion.Value = ""

                Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
                outError.Direction = ParameterDirection.Output

                conn.Open()
                cmd.ExecuteReader()
                conn.Close()

                Return CInt(cmd.Parameters("@outError").Value)
            Catch exc As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace


