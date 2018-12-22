Imports Microsoft.Reporting.WebForms

Public Class reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                If Request("tipo") Is Nothing Then Response.End()
                If Request("paciente") Is Nothing Then Response.End()
                Select Case Request("tipo")
                    Case "FN"
                        Dim data As New dsReporte
                        Dim dt As DataTable = reportes.reporteNutricion(Request("paciente"))
                        dt.TableName = "PACIENTE"
                        Dim rds = New ReportDataSource("dsReporte", dt)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", dt.DefaultView))
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "nutricion.rdlc"
                        ReportViewer1.Visible = True
                        ReportViewer1.LocalReport.Refresh()
                    Case "FP"
                        Dim data As New dsReporte
                        Dim dt As DataTable = reportes.reportePsicologia(Request("paciente"))
                        dt.TableName = "PSICOLOGIA"
                        Dim rds = New ReportDataSource("dsReporte", dt)
                        ReportViewer2.LocalReport.DataSources.Clear()
                        ReportViewer2.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", dt.DefaultView))
                        ReportViewer2.LocalReport.ReportEmbeddedResource = "psicologia.rdlc"
                        ReportViewer2.Visible = True
                        ReportViewer2.LocalReport.Refresh()
                End Select
            Catch ex As Exception

            Finally

            End Try
        End If
    End Sub

End Class