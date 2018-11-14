Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class FichaKinesiologia
        Public Property Id As Integer
        Public Property Riesgo As String
        Public Property NumeroSesion As Integer
        Public Property IdEspecialista As Integer
        Public Property TipoEvaluacion As String
        Public Property ERGOESPIROMETRIA As ERGOESPIROMETRIA
        Public Property SHUTTLE As SHUTTLE
        Public Property EvolucionEgresoKine As EvolucionEgresoKine
        Public Property EvolucionIngresoKine As EvolucionIngresoKine
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property


    End Class
End Namespace