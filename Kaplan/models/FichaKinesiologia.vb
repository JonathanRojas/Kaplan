Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class FichaKinesiologia
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

    End Class
End Namespace