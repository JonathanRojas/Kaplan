
Namespace Clases
    Public Class FichaEnfermeria
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property TipoEvaluacion As String
        Public Property Procedencia As String
        Public Property IdEspecialista As Integer
        Public Property Diagnostico As String
        Public Property FechaDiagnostico As Date
        Public Property CxProced As String
        Public Property FechaCxProced As Date
        Public Property Controles As String
        Public Property FechaAlta As Date
        Public Property HeridaCX As String
        Public Property HTA As Tipos.TipoHTA
        Public Property DM As Tipos.TipoDM
        Public Property DLP As Tipos.TipoDLP
        Public Property SED As Tipos.TipoSED
        Public Property SPOB As Tipos.TipoSPOB
        Public Property TB As Tipos.TipoTB
        Public Property OH As Tipos.TipoOH
        Public Property AF As Tipos.TipoAF
        Public Property Estres As Tipos.TipoEstres
        Public Property Intervencion As String
        Public Property MedicamentosEnfermeria As List(Of MedicamentosEnfermeria)
        Public Property AnamnesisEnfermeria As AnamnesisEnfermeria
        Public Property ExamenFisicoEnfermeria As ExamenFisicoEnfermeria
        Public Property EvolucionEnfermeria As List(Of EvolucionEnfermeria)
        Public Property PlanEnfermeria As PlanEnfermeria
        Public Shared Function MapeoFichaKine(prmDatos As DataTable) As FichaKinesiologia
            Try
                Dim vKinesiologia As New FichaKinesiologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vKinesiologia.Id = prmRow("id_ficha_kine").ToString
                vKinesiologia.IdReserva = prmRow("id_reserva").ToString
                vKinesiologia.Riesgo = prmRow("riesgo").ToString
                vKinesiologia.TipoEvaluacion = prmRow("tipo_evaluacion").ToString

                Dim vERGOESPIROMETRIA As New Ergoespirometria
                vERGOESPIROMETRIA.EFechaEgreso = prmRow("ergo_fecha_egr").ToString
                vERGOESPIROMETRIA.EFechaIngreso = prmRow("ergo_fecha_ing").ToString
                vERGOESPIROMETRIA.VO2LEgreso = Double.Parse(prmRow("ergo_vol_egr"))
                vERGOESPIROMETRIA.VO2LIngreso = Double.Parse(prmRow("ergo_vol_ing"))
                vERGOESPIROMETRIA.VO2MEgreso = Double.Parse(prmRow("ergo_voml_egr"))
                vERGOESPIROMETRIA.VO2MIngreso = Double.Parse(prmRow("ergo_voml_ing"))
                vERGOESPIROMETRIA.FCEgreso = Double.Parse(prmRow("ergo_fcmax_egr"))
                vERGOESPIROMETRIA.FCIngreso = Double.Parse(prmRow("ergo_fcmax_ing"))
                vERGOESPIROMETRIA.PulsoEgreso = Double.Parse(prmRow("ergo_pulso_egr"))
                vERGOESPIROMETRIA.PulsoIngreso = Double.Parse(prmRow("ergo_pulso_ing"))
                vERGOESPIROMETRIA.VEEgreso = Double.Parse(prmRow("ergo_ve_egr"))
                vERGOESPIROMETRIA.VEIngreso = Double.Parse(prmRow("ergo_ve_ing"))
                vERGOESPIROMETRIA.METSEgreso = Double.Parse(prmRow("ergo_mets_egr"))
                vERGOESPIROMETRIA.METSIngreso = Double.Parse(prmRow("ergo_mets_ing"))
                vKinesiologia.ERGOESPIROMETRIA = vERGOESPIROMETRIA

                Dim vSHUTTLE As New Shuttle
                vSHUTTLE.EFechaEgreso = prmRow("shu_fecha_egr").ToString
                vSHUTTLE.EFechaIngreso = prmRow("shu_fecha_ing").ToString
                vSHUTTLE.METROSEgreso = Double.Parse(prmRow("shu_mts_egr"))
                vSHUTTLE.METROSIngreso = Double.Parse(prmRow("shu_mts_ing"))
                vSHUTTLE.NIVELEgreso = Double.Parse(prmRow("shu_niv_egr"))
                vSHUTTLE.NIVELIngreso = Double.Parse(prmRow("shu_niv_ing"))
                vSHUTTLE.VO2MEgreso = Double.Parse(prmRow("shu_vol_egr"))
                vSHUTTLE.VO2MIngreso = Double.Parse(prmRow("shu_vol_ing"))
                vSHUTTLE.METSEgreso = Double.Parse(prmRow("shu_mets_egr"))
                vSHUTTLE.METSIngreso = Double.Parse(prmRow("shu_mets_ing"))
                vSHUTTLE.FCEgreso = Double.Parse(prmRow("shu_fcmax_egr"))
                vSHUTTLE.FCIngreso = Double.Parse(prmRow("shu_fcmax_ing"))
                vSHUTTLE.FCMTEgreso = Double.Parse(prmRow("shu_fcmt_egr"))
                vSHUTTLE.FCMTIngreso = Double.Parse(prmRow("shu_fcmt_ing"))
                vSHUTTLE.METSMAXEgreso = Double.Parse(prmRow("shu_metsmax_egr"))
                vSHUTTLE.METSMAXIngreso = Double.Parse(prmRow("shu_metsmax_ing"))
                vKinesiologia.SHUTTLE = vSHUTTLE

                Return vKinesiologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace
