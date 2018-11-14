Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class PlanKinesico
        Public Property AEROBICO As String
        Public Property SOBRECARGA As String
        Public Property FUNCIONAL As String
        Public Property EDUCACION As String
        Public Property Diagnostico As List(Of Tipos.TipoDiagnosticoKine)
        Public Property Objetivo As List(Of Tipos.TipoObjetivoKine)

    End Class
End Namespace
