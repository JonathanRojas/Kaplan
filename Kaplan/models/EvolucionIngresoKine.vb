Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class EvolucionIngresoKine
        Public Property Id As Integer
        Public Property Observacion As String
        Public Property EME As String
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
    End Class
End Namespace