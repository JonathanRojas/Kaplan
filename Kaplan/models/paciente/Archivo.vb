Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class Archivo
        Public Property Id As Integer
        Public Property FechaRegistro As Date
        Public Property FechaReserva As Date
        Public Property Plan As String
        Public Property Especialista As String
        Public Property Formato As String
        Public ReadOnly Property FechaRegistroString As String
            Get
                Return FechaRegistro.ToString("dd MMM yyyy")
            End Get
        End Property
        Public ReadOnly Property FechaReservaString As String
            Get
                Return FechaReserva.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Shared Function getArchivos(inRut As Integer) As List(Of Archivo)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("ListadoArchivos", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getArchivos = New List(Of Archivo)
                For Each vRow As DataRow In vDataTable.Rows
                    getArchivos.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getArchivos
            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Archivo
            Try
                Dim vArchivo As New Archivo
                vArchivo.Id = prmRow("ID")
                vArchivo.FechaRegistro = prmRow("FechaRegistro")
                vArchivo.FechaReserva = prmRow("FechaReserva")
                vArchivo.Plan = prmRow("nombrePlan").ToString
                vArchivo.Especialista = prmRow("Especialista").ToString
                vArchivo.Formato = prmRow("Formato").ToString
                Return vArchivo

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function registrarArchivo(ruta As String, contenido As Byte()) As Boolean
            Try
                Dim olecon As OleDbConnection
                Dim olecomm As OleDbCommand
                Dim oleadpt As OleDbDataAdapter
                Dim ds As DataSet
                Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=""Excel 8.0;HDR=NO;"""
                olecon = New OleDbConnection
                olecon.ConnectionString = connstring
                olecomm = New OleDbCommand
                'olecomm.CommandText = "Select * from [Ergo$A8:L8] "
                olecomm.CommandText = "Select * from [Ergo$A60:AT] "
                olecomm.Connection = olecon
                oleadpt = New OleDbDataAdapter(olecomm)
                ds = New DataSet

                olecon.Open()
                oleadpt.Fill(ds, "Fijo")
                Dim jsonDemo As String = GetJson(ds.Tables("fijo"))

                cargarArchivo(jsonDemo.ToString.Replace("[", "{" + """column""" + ":[").Replace("]", "]}"), contenido)

                registrarArchivo = True
            Catch exc As Exception
                registrarArchivo = False
            End Try
        End Function
        Public Function cargarArchivo(datos As String, contenido As Byte()) As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("registrarArchivo", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@datos", OleDbType.VarChar, -1)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = datos

            Dim inArchivo As OleDbParameter = cmd.Parameters.Add("@archivo", OleDbType.VarBinary, -1)
            inArchivo.Direction = ParameterDirection.Input
            inArchivo.Value = contenido

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outError").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function GetJson(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "F1" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F2" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F3" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F4" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F5" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F6" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F7" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F8" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F9" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F10" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F11" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F12" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F13" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F14" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F15" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F16" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F17" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F18" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F19" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F20" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F21" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F22" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F23" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F24" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F25" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F26" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F27" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F28" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F29" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F30" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F31" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F32" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F33" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F34" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F35" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F36" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F37" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F38" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F39" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F40" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F41" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F42" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F43" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F44" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F45" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F46" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        'Public Function EliminarExamen(Id As Integer) As Boolean
        '    Try
        '        Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
        '        Dim cmd As OleDbCommand = New OleDbCommand("EliminarExamen", conn)
        '        cmd.CommandType = CommandType.StoredProcedure

        '        Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
        '        inId.Direction = ParameterDirection.Input
        '        inId.Value = Id

        '        Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
        '        outError.Direction = ParameterDirection.Output

        '        conn.Open()
        '        cmd.ExecuteReader()
        '        conn.Close()

        '        Return CInt(cmd.Parameters("@outError").Value)
        '    Catch exc As Exception
        '        Return Nothing
        '    End Try
        'End Function
    End Class
End Namespace


