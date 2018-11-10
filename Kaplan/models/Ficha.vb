Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Ficha
        Public Property Id As Integer
        Public Property Rut As String
        Public Property Dv As String
        Public Property Nombre As String
        Public Property Paterno As String
        Public Property Materno As String
        Public Property FechaNac As Date
        Public ReadOnly Property FechaNacString As String
            Get
                Return FechaNac.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property EstadoCivil As Tipos.TipoEstadoCivil
        Public Property Domicilio As String
        Public Property Telefono As String
        Public Property Sexo As Tipos.TipoSexo
        Public Property SituacionLaboral As String
        Public Shared Function getFichas() As List(Of Ficha)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("ListadoPacientes", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getFichas = New List(Of Ficha)
                For Each vRow As DataRow In vDataTable.Rows
                    getFichas.Add(Mapeo(vRow))
                Next
                conn.Close()

                Return getFichas

            Catch exc As Exception
                Dim msj As String = exc.ToString
            End Try
        End Function
        Public Shared Function getFicha(inId As Integer) As Ficha
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("ObtenerFicha", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            getFicha = Mapeo(vDataTable(0))
            Return getFicha
        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Ficha
            Dim vFicha As New Ficha
            vFicha.Id = prmRow("id").ToString
            vFicha.Rut = prmRow("rut").ToString
            vFicha.Dv = prmRow("dv").ToString
            vFicha.Nombre = prmRow("nombre").ToString
            vFicha.Paterno = prmRow("paterno").ToString
            vFicha.Materno = prmRow("materno").ToString
            vFicha.FechaNac = prmRow("fecha").ToString
            vFicha.EstadoCivil = Tipos.TipoEstadoCivil.getTipo(prmRow("estado_civil"))
            vFicha.Domicilio = prmRow("domicilio").ToString
            vFicha.Telefono = prmRow("telefono").ToString
            vFicha.Sexo = Tipos.TipoSexo.getTipo(prmRow("sexo"))
            vFicha.SituacionLaboral = prmRow("situacion_laboral").ToString
            Return vFicha
        End Function
        Public Function registrarFicha() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFicha", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inRut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            inRut.Direction = ParameterDirection.Input
            inRut.Value = Me.Rut

            Dim inDv As OleDbParameter = cmd.Parameters.Add("@inDv", OleDbType.Decimal, Nothing)
            inDv.Direction = ParameterDirection.Input
            inDv.Value = Me.Dv

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 50)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = Me.Nombre

            Dim inPaterno As OleDbParameter = cmd.Parameters.Add("@inPaterno", OleDbType.VarChar, 50)
            inPaterno.Direction = ParameterDirection.Input
            inPaterno.Value = Me.Paterno

            Dim inMaterno As OleDbParameter = cmd.Parameters.Add("@inMaterno", OleDbType.VarChar, 50)
            inMaterno.Direction = ParameterDirection.Input
            inMaterno.Value = Me.Materno

            Dim inFechNac As OleDbParameter = cmd.Parameters.Add("@inFechNac", OleDbType.Date, Nothing)
            inFechNac.Direction = ParameterDirection.Input
            inFechNac.Value = Me.FechaNac

            Dim inEstadoCivil As OleDbParameter = cmd.Parameters.Add("@inEstadoCivil", OleDbType.Decimal, Nothing)
            inEstadoCivil.Direction = ParameterDirection.Input
            inEstadoCivil.Value = Me.EstadoCivil.ID

            Dim inDomicilio As OleDbParameter = cmd.Parameters.Add("@inDomicilio", OleDbType.VarChar, 100)
            inDomicilio.Direction = ParameterDirection.Input
            inDomicilio.Value = Me.Domicilio

            Dim inTelefono As OleDbParameter = cmd.Parameters.Add("@inTelefono", OleDbType.VarChar, 12)
            inTelefono.Direction = ParameterDirection.Input
            inTelefono.Value = Me.Telefono

            Dim inSexo As OleDbParameter = cmd.Parameters.Add("@inSexo", OleDbType.Decimal, Nothing)
            inSexo.Direction = ParameterDirection.Input
            inSexo.Value = Me.Sexo.ID

            Dim inSituacionLaboral As OleDbParameter = cmd.Parameters.Add("@inSituacionLaboral", OleDbType.VarChar, 500)
            inSituacionLaboral.Direction = ParameterDirection.Input
            inSituacionLaboral.Value = Me.SituacionLaboral

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
    End Class
End Namespace
