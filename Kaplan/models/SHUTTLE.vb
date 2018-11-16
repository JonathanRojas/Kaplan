Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class SHUTTLE
        Public Property EFechaIngreso As Date
        Public ReadOnly Property EFechaIngresoString As String
            Get
                Return EFechaIngreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property EFechaEgreso As Date
        Public ReadOnly Property EFechaEgresoString As String
            Get
                Return EFechaEgreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property METROSIngreso As String
        Public Property METROSEgreso As String
        Public Property NIVELIngreso As String
        Public Property NIVELEgreso As String
        Public Property VO2MIngreso As String
        Public Property VO2MEgreso As String
        Public Property METSIngreso As String
        Public Property METSEgreso As String
        Public Property FCIngreso As String
        Public Property FCEgreso As String
        Public Property FCMTIngreso As String
        Public Property FCMTEgreso As String
        Public Property METSMAXIngreso As String
        Public Property METSMAXEgreso As String
    End Class

End Namespace
