Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

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
                'Dim olecon As OleDbConnection
                'Dim olecomm As OleDbCommand
                'Dim oleadpt As OleDbDataAdapter
                'Dim ds As DataSet
                'Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=""Excel 8.0;HDR=NO;"""
                'olecon = New OleDbConnection
                'olecon.ConnectionString = connstring
                'olecomm = New OleDbCommand
                'olecomm.CommandText = "Select * from [Ergo$A60:Z]"
                'olecomm.Connection = olecon
                'oleadpt = New OleDbDataAdapter(olecomm)
                'ds = New DataSet

                'olecon.Open()
                'oleadpt.Fill(ds, "Fijo")
                'registrarArchivo = True
                'Dim oApp As New Excel.Application
                'Dim oWBa As Excel.Workbook = oApp.Workbooks.Open("c:\Test.XLS")
                'Dim oWS As Excel.Worksheet = DirectCast(oWBa.Worksheets(1),
                'Excel.Worksheet)
                'oApp.Visible = False

                'Dim oRng As Excel.Range
                'oRng = oWS.Range("D6")
                'MsgBox(oRng.Value)
            Catch exc As Exception
                registrarArchivo = False
            End Try
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


