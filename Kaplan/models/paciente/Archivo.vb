Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class Archivo
        Public Property Id As Integer
        'Private Shared Function Mapeo(prmRow As DataRow) As Examen
        '    Try
        '        Dim vExamen As New Examen
        '        vExamen.Id = prmRow("ID")
        '        vExamen.Nombre = prmRow("Nombre")
        '        vExamen.Descripcion = prmRow("Descripcion")
        '        vExamen.Fecha = prmRow("Fecha")
        '        vExamen.EspecialistaNombre = prmRow("EspecialistaNombre")
        '        vExamen.Formato = prmRow("Formato")
        '        Return vExamen

        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        'Public Shared Function getExamenes(inRut As Integer) As List(Of Examen)
        '    Try
        '        Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
        '        Dim cmd As OleDbCommand = New OleDbCommand("ListadoExamenes", conn)
        '        cmd.CommandType = CommandType.StoredProcedure

        '        Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
        '        inPaciente.Direction = ParameterDirection.Input
        '        inPaciente.Value = inRut

        '        conn.Open()
        '        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        '        Dim vDataTable As New DataTable
        '        adapter.Fill(vDataTable)
        '        getExamenes = New List(Of Examen)
        '        For Each vRow As DataRow In vDataTable.Rows
        '            getExamenes.Add(Mapeo(vRow))
        '        Next
        '        conn.Close()
        '        Return getExamenes
        '    Catch exc As Exception
        '        Return Nothing
        '    End Try

        'End Function
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
                olecomm.CommandText = "Select * from [Ergo$A60:Z] "
                olecomm.Connection = olecon
                oleadpt = New OleDbDataAdapter(olecomm)
                ds = New DataSet

                olecon.Open()
                oleadpt.Fill(ds, "Fijo")
                Dim jsonDemo As String = GetJson(ds.Tables("fijo"))

                cargarArchivo(jsonDemo)

                registrarArchivo = True
            Catch exc As Exception
                registrarArchivo = False
            End Try
        End Function
        Public Function cargarArchivo(archivo As String) As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("CargarArchivo", conn)
            cmd.CommandType = CommandType.StoredProcedure

            'Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            'inId.Direction = ParameterDirection.Input
            'inId.Value = Me.Id

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@archivo", OleDbType.VarChar, -1)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = archivo

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outIdKine").Value)

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
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F3" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F4" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F5" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F6" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F7" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F8" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F9" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F10" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F11" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F12" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F13" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F14" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F15" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F16" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F17" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F18" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F19" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F20" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F21" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F22" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F23" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F24" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F25" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F26" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
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


