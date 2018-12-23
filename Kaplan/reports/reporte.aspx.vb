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
                    Case "FK"
                        Dim data As New dsReporte
                        Dim ds As New DataSet
                        ds = reportes.reporteKinesiologia(Request("paciente"))
                        ds.Tables(0).TableName = "KINESIOLOGIA"
                        ds.Tables(1).TableName = "FKEVOLUCION"
                        ds.Tables(2).TableName = "FKDIAGNOSTICO"
                        ds.Tables(3).TableName = "FKOBJETIVO"
                        ds.Tables(4).TableName = "FKPLAN"
                        Dim rds = New ReportDataSource("dsReporte", ds.Tables(0))
                        Dim rds2 = New ReportDataSource("dsReporte", ds.Tables(1))
                        Dim rds3 = New ReportDataSource("dsReporte", ds.Tables(2))
                        Dim rds4 = New ReportDataSource("dsReporte", ds.Tables(3))
                        Dim rds5 = New ReportDataSource("dsReporte", ds.Tables(4))
                        ReportViewer3.LocalReport.DataSources.Clear()
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", ds.Tables(0).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKEvolucion", ds.Tables(1).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKDiagnostico", ds.Tables(2).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKObjetivo", ds.Tables(3).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKPlan", ds.Tables(4).DefaultView))
                        ReportViewer3.LocalReport.ReportEmbeddedResource = "kinesiologia.rdlc"
                        ReportViewer3.Visible = True
                        ReportViewer3.LocalReport.Refresh()
                End Select
            Catch ex As Exception

            Finally

            End Try
        End If
    End Sub

End Class