Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net.Mail

Namespace Clases
    Public Class Especialista
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Especialidad As Tipos.TipoEspecialidad
        Public Property Persona As Persona
        Public Shared Function getEspecialistas(ByRef msj As String) As List(Of Especialista)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("ListadoEspecialistas", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getEspecialistas = New List(Of Especialista)
                For Each vRow As DataRow In vDataTable.Rows
                    getEspecialistas.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getEspecialistas

            Catch exc As Exception
                msj = exc.ToString
            End Try

        End Function
        Public Shared Function getEspecialista(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Especialista
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
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            For Each vRow As DataRow In vDataTable.Rows
                getEspecialista = Mapeo(vDataTable(0))
                NoData = False
            Next

            If vDataTable.Rows.Count = 0 Then NoData = True

            Return getEspecialista
        End Function
        Public Shared Function getEspecialistaId(inId As Integer) As Especialista
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("BuscarEspecialistaId", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Rut As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            Rut.Direction = ParameterDirection.Input
            Rut.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            For Each vRow As DataRow In vDataTable.Rows
                getEspecialistaId = Mapeo(vDataTable(0))
            Next

            Return getEspecialistaId
        End Function
        Public Shared Function getEspecialistasEsp(ByRef inEspecialidad As Integer) As List(Of Especialista)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("ListadoEspecialistasEsp", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Especialidad As OleDbParameter = cmd.Parameters.Add("@inEspecialidad", OleDbType.Integer, Nothing)
                Especialidad.Direction = ParameterDirection.Input
                Especialidad.Value = inEspecialidad

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getEspecialistasEsp = New List(Of Especialista)
                For Each vRow As DataRow In vDataTable.Rows
                    getEspecialistasEsp.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getEspecialistasEsp

            Catch exc As Exception
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Especialista
            Try
                Dim vEspecialista As New Especialista
                vEspecialista.Persona = New Persona
                vEspecialista.Id = IIf(prmRow("ID_ESPECIALISTA").Equals(DBNull.Value), -1, prmRow("ID_ESPECIALISTA"))
                vEspecialista.Estado = IIf(prmRow("ESTADO_ESPECIALISTA").Equals(DBNull.Value), -1, prmRow("ESTADO_ESPECIALISTA"))
                If Not prmRow("especialidad").Equals(DBNull.Value) Then vEspecialista.Especialidad = Tipos.TipoEspecialidad.getTipo(prmRow("especialidad")) Else vEspecialista.Especialidad = New Tipos.TipoEspecialidad
                vEspecialista.Persona.Id = prmRow("ID").ToString
                vEspecialista.Persona.Rut = prmRow("rut").ToString
                vEspecialista.Persona.Dv = prmRow("dv").ToString
                vEspecialista.Persona.Nombre = prmRow("nombres").ToString
                vEspecialista.Persona.Paterno = prmRow("paterno").ToString
                vEspecialista.Persona.Materno = prmRow("materno").ToString
                vEspecialista.Persona.FechaNac = prmRow("fecha_nac").ToString
                vEspecialista.Persona.Telefono = prmRow("telefono").ToString
                vEspecialista.Persona.Movil = prmRow("movil").ToString
                vEspecialista.Persona.Sexo = Tipos.TipoSexo.getTipo(prmRow("sexo"))
                vEspecialista.Persona.Email = prmRow("email").ToString
                Return vEspecialista

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function registrarEspecialista() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarEspecialista", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inIdEs As OleDbParameter = cmd.Parameters.Add("@inIdEspecialista", OleDbType.Decimal, Nothing)
            inIdEs.Direction = ParameterDirection.Input
            inIdEs.Value = Me.Id

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inIdPersona", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Persona.Id

            Dim inRut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            inRut.Direction = ParameterDirection.Input
            inRut.Value = Me.Persona.Rut

            Dim inDv As OleDbParameter = cmd.Parameters.Add("@inDv", OleDbType.Char, 1)
            inDv.Direction = ParameterDirection.Input
            inDv.Value = Me.Persona.Dv

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 250)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = Me.Persona.Nombre

            Dim inPaterno As OleDbParameter = cmd.Parameters.Add("@inPaterno", OleDbType.VarChar, 200)
            inPaterno.Direction = ParameterDirection.Input
            inPaterno.Value = Me.Persona.Paterno

            Dim inMaterno As OleDbParameter = cmd.Parameters.Add("@inMaterno", OleDbType.VarChar, 200)
            inMaterno.Direction = ParameterDirection.Input
            inMaterno.Value = Me.Persona.Materno

            Dim inFechNac As OleDbParameter = cmd.Parameters.Add("@inFechNac", OleDbType.Date, Nothing)
            inFechNac.Direction = ParameterDirection.Input
            inFechNac.Value = Me.Persona.FechaNac

            Dim inSexo As OleDbParameter = cmd.Parameters.Add("@inSexo", OleDbType.Decimal, Nothing)
            inSexo.Direction = ParameterDirection.Input
            inSexo.Value = Me.Persona.Sexo.ID

            Dim inTelefono As OleDbParameter = cmd.Parameters.Add("@inTelefono", OleDbType.Decimal, Nothing)
            inTelefono.Direction = ParameterDirection.Input
            inTelefono.Value = Me.Persona.Telefono

            Dim inMovil As OleDbParameter = cmd.Parameters.Add("@inMovil", OleDbType.Decimal, Nothing)
            inMovil.Direction = ParameterDirection.Input
            inMovil.Value = Me.Persona.Movil

            Dim inEmail As OleDbParameter = cmd.Parameters.Add("@inEmail", OleDbType.VarChar, 100)
            inEmail.Direction = ParameterDirection.Input
            inEmail.Value = Me.Persona.Email

            Dim inEspecialidad As OleDbParameter = cmd.Parameters.Add("@inEspecialidad", OleDbType.Decimal, Nothing)
            inEspecialidad.Direction = ParameterDirection.Input
            inEspecialidad.Value = Me.Especialidad.ID

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outLogin As OleDbParameter = cmd.Parameters.Add("@outLogin", OleDbType.VarChar, 50)
            outLogin.Direction = ParameterDirection.Output

            Dim outPass As OleDbParameter = cmd.Parameters.Add("@outPass", OleDbType.VarChar, 50)
            outPass.Direction = ParameterDirection.Output


            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            If CInt(cmd.Parameters("@outError").Value).Equals(1) And Me.Id.Equals(-1) Then
                enviarCorreo(Me.Persona.Email, cmd.Parameters("@outLogin").Value, cmd.Parameters("@outPass").Value)
            End If

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function enviarCorreo(ByVal email As String, ByVal login As String, ByVal pass As String)
            Try
                Dim correo As New MailMessage
                Dim smtp As New SmtpClient()

                correo.From = New MailAddress("no_reply@sistemaskaplan.info", "Sistema Kaplan", System.Text.Encoding.UTF8)
                correo.To.Add(email)
                correo.SubjectEncoding = System.Text.Encoding.UTF8
                correo.Subject = "Nuevo usuario"
                correo.Body = "Su usuario de conexión es " & login & " y su contraseña es " & pass
                correo.BodyEncoding = System.Text.Encoding.UTF8
                correo.IsBodyHtml = True
                correo.Priority = MailPriority.High

                smtp.Credentials = New System.Net.NetworkCredential("no_reply@sistemaskaplan.info", "Kaplan*2018*")
                smtp.Port = 25
                smtp.Host = "mail.sistemaskaplan.info"
                smtp.EnableSsl = False

                smtp.Send(correo)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
    End Class
End Namespace