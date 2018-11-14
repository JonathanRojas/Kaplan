Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class ERGOESPIROMETRIA
        Public Property FechaIngreso As Date
        Public ReadOnly Property FechaIngresoString As String
            Get
                Return FechaIngreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property EFechaEgreso As Date
        Public ReadOnly Property EFechaEgresoString As String
            Get
                Return EFechaEgreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property VO2LIngreso As String
        Public Property VO2LEgreso As String
        Public Property VO2MIngreso As String
        Public Property VO2MEgreso As String
        Public Property FCIngreso As String
        Public Property FCEgreso As String
        Public Property PulsoIngreso As String
        Public Property PulsoEgreso As String
        Public Property VEIngreso As String
        Public Property VEEgreso As String
        Public Property METSIngreso As String
        Public Property METSEgreso As String
    End Class

End Namespace