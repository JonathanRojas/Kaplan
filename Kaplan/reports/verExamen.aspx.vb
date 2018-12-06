Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class verExamen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("inId") Is Nothing Then Response.End()
        If Request("inTipo") Is Nothing Then Response.End()

        Select Case Request("inTipo")
            Case "Examen"
                Dim vDocumento As Documento = Documento.obtenerDocumento(1, Request("inId"))
                Response.ContentType = vDocumento.Formato
                Response.BinaryWrite(vDocumento.Documento)
        End Select
        Response.End()
    End Sub

End Class