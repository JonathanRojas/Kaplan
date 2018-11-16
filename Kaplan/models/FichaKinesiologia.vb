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
        Public Property PlanKinesico As PlanKinesico
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Shared Function MapeoFichaKine(prmDatos As DataTable) As FichaKinesiologia
            Try
                Dim vKinesiologia As New FichaKinesiologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vKinesiologia.Id = prmRow("id_ficha_kine").ToString
                vKinesiologia.Riesgo = prmRow("riesgo").ToString
                vKinesiologia.TipoEvaluacion = prmRow("tipo_evaluacion").ToString

                Dim vERGOESPIROMETRIA As New ERGOESPIROMETRIA
                vERGOESPIROMETRIA.EFechaEgreso = prmRow("ergo_fecha_egr").ToString
                vERGOESPIROMETRIA.EFechaIngreso = prmRow("ergo_fecha_ing").ToString
                vERGOESPIROMETRIA.VO2LEgreso = prmRow("ergo_vol_egr").ToString
                vERGOESPIROMETRIA.VO2LIngreso = prmRow("ergo_vol_ing").ToString
                vERGOESPIROMETRIA.VO2MEgreso = prmRow("ergo_voml_egr").ToString
                vERGOESPIROMETRIA.VO2MIngreso = prmRow("ergo_voml_ing").ToString
                vERGOESPIROMETRIA.FCEgreso = prmRow("ergo_fcmax_egr").ToString
                vERGOESPIROMETRIA.FCIngreso = prmRow("ergo_fcmax_ing").ToString
                vERGOESPIROMETRIA.PulsoEgreso = prmRow("ergo_pulso_egr").ToString
                vERGOESPIROMETRIA.PulsoIngreso = prmRow("ergo_pulso_ing").ToString
                vERGOESPIROMETRIA.VEEgreso = prmRow("ergo_ve_egr").ToString
                vERGOESPIROMETRIA.VEIngreso = prmRow("ergo_ve_ing").ToString
                vERGOESPIROMETRIA.METSEgreso = prmRow("ergo_mets_egr").ToString
                vERGOESPIROMETRIA.METSIngreso = prmRow("ergo_mets_ing").ToString
                vKinesiologia.ERGOESPIROMETRIA = vERGOESPIROMETRIA

                Dim vSHUTTLE As New SHUTTLE
                vSHUTTLE.EFechaEgreso = prmRow("shu_fecha_egr").ToString
                vSHUTTLE.EFechaIngreso = prmRow("shu_fecha_ing").ToString
                vSHUTTLE.METROSEgreso = prmRow("shu_mts_egr").ToString
                vSHUTTLE.METROSIngreso = prmRow("shu_mts_ing").ToString
                vSHUTTLE.NIVELEgreso = prmRow("shu_niv_egr").ToString
                vSHUTTLE.NIVELIngreso = prmRow("shu_niv_ing").ToString
                vSHUTTLE.VO2MEgreso = prmRow("shu_vol_egr").ToString
                vSHUTTLE.VO2MIngreso = prmRow("shu_vol_ing").ToString
                vSHUTTLE.METSEgreso = prmRow("shu_mets_egr").ToString
                vSHUTTLE.METSIngreso = prmRow("shu_mets_ing").ToString
                vSHUTTLE.FCEgreso = prmRow("shu_fcmax_egr").ToString
                vSHUTTLE.FCIngreso = prmRow("shu_fcmax_ing").ToString
                vSHUTTLE.FCMTEgreso = prmRow("shu_fcmt_egr").ToString
                vSHUTTLE.FCMTIngreso = prmRow("shu_fcmt_ing").ToString
                vSHUTTLE.METSMAXEgreso = prmRow("shu_metsmax_egr").ToString
                vSHUTTLE.METSMAXIngreso = prmRow("shu_metsmax_ing").ToString
                vKinesiologia.SHUTTLE = vSHUTTLE

                Return vKinesiologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace