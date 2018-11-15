Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Paciente
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Persona As Persona

        Public Shared Function getPaciente(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Paciente
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("BuscarPersona", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Rut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            Rut.Direction = ParameterDirection.Input
            Rut.Value = inRut

            Dim Pasaporte As OleDbParameter = cmd.Parameters.Add("@inPasaporte", OleDbType.VarChar, 100)
            Pasaporte.Direction = ParameterDirection.Input
            Pasaporte.Value = strPasaporte

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)
            If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                If Not vDataSet.Tables(0).Rows(0)("ID_PAC").Equals(DBNull.Value) Then
                    getPaciente = Mapeo(vDataSet)
                End If
            End If

            If vDataSet.Tables(0).Rows.Count = 0 OrElse vDataSet.Tables(0).Rows(0)("ID_PAC").Equals(DBNull.Value) Then NoData = True

            Return getPaciente
        End Function

        Private Shared Function Mapeo(prmDatos As DataSet) As Paciente
            Try
                Dim vPaciente As New Paciente
                Dim prmRow As DataRow = prmDatos.Tables(0).Rows(0)

                vPaciente.Persona = New Persona
                vPaciente.Id = prmRow("id_PAC").ToString
                vPaciente.Estado = prmRow("estado_paciente").ToString
                vPaciente.Persona.Id = prmRow("id").ToString
                vPaciente.Persona.Rut = prmRow("rut").ToString
                vPaciente.Persona.Dv = prmRow("dv").ToString
                vPaciente.Persona.Nombre = prmRow("nombres").ToString
                vPaciente.Persona.Paterno = prmRow("paterno").ToString
                vPaciente.Persona.Materno = prmRow("materno").ToString
                vPaciente.Persona.FechaNac = prmRow("fecha_nac").ToString
                vPaciente.Persona.Comuna = Tipos.TipoComuna.getTipo(prmRow("comuna"))
                vPaciente.Persona.Region = Tipos.TipoRegion.getTipo(prmRow("region"))
                vPaciente.Persona.Direccion = prmRow("direccion").ToString
                vPaciente.Persona.Telefono = prmRow("telefono").ToString
                vPaciente.Persona.Movil = prmRow("movil").ToString
                vPaciente.Persona.SituacionLaboral = prmRow("situacion_laboral").ToString

                Return vPaciente
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace