Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class FichaMedico
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property CentroDerivacion As String
        Public Property MedicoDerivador As String
        Public Property MotivoDerivacion As String
        Public Property FechaAlta As Date
        Public Property NumeroHospitalizaciones As Integer
        Public Property HistoriaCardiopatia As Tipos.TipoRespuestaMedico
        Public Property ListHistoriaCardiopatia As List(Of HistoriaCardiopatia)
        Public Property HistoriaCronica As Tipos.TipoRespuestaMedico
        Public Property ListHistoriaCronica As List(Of HistoriaCronica)
        Public Property IndiceMasaCoporal As Double
        Public Property PerimetroCintura As Double
        Public Property RelacionCinturaCadera As Double
        Public Property PorcentajeGrasa As Double
        Public Property Tabaquismo As Double
        Public Property IPA As String
        Public Property TabaquismoActivo As Tipos.TipoRespuestaMedico
        Public Property Alcohol As Tipos.TipoRespuestaMedico
        Public Property ActividadFisica As Double
        Public Property AbusoDrogas As Tipos.TipoRespuestaMedico
        Public Property AbusoDrogasDetalle As String
        Public Property Dislipidemias As Tipos.TipoRespuestaMedico
        Public Property DislipidemiasObs As String
        Public Property HipertensionArterial As Tipos.TipoRespuestaMedico
        Public Property HipertensionArterialObs As String
        Public Property DiabetesMellitus As Tipos.TipoRespuestaMedico
        Public Property Insulinoterapia As Tipos.TipoRespuestaMedico
        Public Property InsulinoterapiaDosis As String
        Public Property Alergias As Tipos.TipoRespuestaMedico
        Public Property AlergiasObs As String
        Public Property EnfermedadRenalCronica As Tipos.TipoRespuestaMedico
        Public Property Etapa As String
        Public Property Proteinurea As Tipos.TipoRespuestaMedico
        Public Property Hemodialisis As Tipos.TipoRespuestaMedico
        Public Property Anemia As Tipos.TipoRespuestaMedico
        Public Property Hemoglobina As String
        Public Property Ferritina As String
        Public Property Albumina As String
        Public Property Linfocitos As String
        Public Property EnfermedadPulmonar As Tipos.TipoRespuestaMedico
        Public Property SeveridadFuncionPulmonar As Tipos.TipoRespuestaMedico 'cambiar tipo
        Public Property EnfermedadHepatica As Tipos.TipoRespuestaMedico
        Public Property EnfermedadHepaticaObs As String
        Public Property EnfermedadArterialPeriferica As Tipos.TipoRespuestaMedico
        Public Property EnfermedadArterialPerifericaObs As String
        Public Property CirugiaPeriferica As Tipos.TipoRespuestaMedico
        Public Property CirugiaPerifericaObs As String
        Public Property EnfermedadCerebroVascular As Tipos.TipoRespuestaMedico
        Public Property EnfermedadCerebroVascularObs As String
        Public Property Secuelas As String
        Public Property CirugiaCarotidea As Tipos.TipoRespuestaMedico
        Public Property CirugiaCarotideaObs As String
        Public Property Inmunosupresion As Tipos.TipoRespuestaMedico
        Public Property InmunosupresionObs As String
        Public Property HistoriaOncologica As Tipos.TipoRespuestaMedico
        Public Property HistoriaOncologicaObs As String
        Public Property Localizacion As String
        Public Property Quimioterapia As Tipos.TipoRespuestaMedico
        Public Property QuimioterapiaObs As String
        Public Property Radioterapia As Tipos.TipoRespuestaMedico
        Public Property RadioterapiaObs As String
        Public Property ApneaSueno As Tipos.TipoRespuestaMedico
        Public Property ApneaSuenoObs As String
        Public Property EnfermedadCardiaca As String
        Public Property CardiopatiaCongenita As Tipos.TipoRespuestaMedico
        Public Property CardiopatiaCongenitaObs As String
        Public Property InfartoAgudoMiocardio As Tipos.TipoRespuestaMedico
        Public Property InfartoAgudoMiocardioObs As String
        Public Property InfartoAgudoMiocardioFecha As Date
        Public Property InsuficienciaCardiaca As Tipos.TipoRespuestaMedico
        Public Property InsuficienciaCardiacaFecha As Date
        Public Property InsuficienciaCardiacaNYHA As String
        Public Property SincopeCardiogenico As Tipos.TipoRespuestaMedico
        Public Property SincopeCardiogenicoObs As String
        Public Property ShockCardiogenico As Tipos.TipoRespuestaMedico
        Public Property ShockCardiogenicoObs As String
        Public Property ShockCardiogenicoFecha As Date
        Public Property ParoCardiorRespiratorio As Tipos.TipoRespuestaMedico
        Public Property ParoCardiorRespiratorioObs As String
        Public Property ParoCardiorRespiratorioFecha As Date
        Public Property Supraventricular As Tipos.TipoRespuestaMedico
        Public Property SupraventricularObs As String
        Public Property Ventricular As Tipos.TipoRespuestaMedico
        Public Property VentricularObs As String
        Public Property Endocarditis As Tipos.TipoRespuestaMedico
        Public Property EndocarditisObs As String
        Public Property DiseccionAortica As Tipos.TipoRespuestaMedico
        Public Property DiseccionAorticaTipo As Tipos.TipoRespuestaMedico ' cambiar tipo
        Public Property AneurismaAortico As Tipos.TipoRespuestaMedico
        Public Property AneurismaAorticoTipo As Tipos.TipoRespuestaMedico ' cambiar tipo
        Public Property TumorCardiaco As Tipos.TipoRespuestaMedico
        Public Property TumorCardiacoTipo As Tipos.TipoRespuestaMedico ' cambiar tipo
        Public Property Tiempo_ECMO As String
        Public Property PuenteCoronario As Tipos.TipoRespuestaMedico
        Public Property PuenteCoronarioObs As String
        Public Property ADA As Tipos.TipoRespuestaMedico
        Public Property ADAObs As String
        Public Property ACX As Tipos.TipoRespuestaMedico
        Public Property ACXObs As String
        Public Property ACD As Tipos.TipoRespuestaMedico
        Public Property ACDObs As String
        Public Property PuenteCoronarioFecha As Date
        Public Property CirugiaValvular As Tipos.TipoRespuestaMedico
        Public Property CirugiaValvularObs As String
        Public Property Aortica As Tipos.TipoRespuestaMedico
        Public Property AorticaObs As String
        Public Property Mitral As Tipos.TipoRespuestaMedico
        Public Property MitralObs As String
        Public Property Tricuspide As Tipos.TipoRespuestaMedico
        Public Property TricuspideObs As String
        Public Property CirugiaValvularFecha As Date
        Public Property CierreComInteraricular As Tipos.TipoRespuestaMedico
        Public Property CierreComInteraricularFecha As Date
        Public Property CierreComInterVetricular As Tipos.TipoRespuestaMedico
        Public Property CierreComInterVetricularFecha As Date
        Public Property CirugiaAorta As Tipos.TipoRespuestaMedico
        Public Property CirugiaAortaFecha As Date
        Public Property CirugiaCardiopatiaCon As Tipos.TipoRespuestaMedico
        Public Property CirugiaCardiopatiaConFecha As Date
        Public Property Reoperacion As Tipos.TipoRespuestaMedico
        Public Property ReoperacionFecha As Date
        Public Property TrasplanteCardiaco As Tipos.TipoRespuestaMedico
        Public Property TrasplanteCardiacoFecha As Date
        Public Property ImplantacionLVAD As Tipos.TipoRespuestaMedico
        Public Property ImplantacionLVADFecha As Date
        Public Property OtraCirugia As Tipos.TipoRespuestaMedico
        Public Property ListOtraCirugia As List(Of OtraCirugia)
        Public Property TerapiaAblativa As Tipos.TipoRespuestaMedico
        Public Property TerapiaAblativaObs As String
        Public Property TerapiaAblativaFecha As Date
        Public Property Marcapaso As Tipos.TipoRespuestaMedico
        Public Property MarcapasoObs As String
        Public Property MarcapasoFecha As Date
        Public Property CDITRC As Tipos.TipoRespuestaMedico
        Public Property CDITRCObs As String
        Public Property CDITRCFecha As Date
        Public Property Angioplastia As Tipos.TipoRespuestaMedico
        Public Property AngioplastiaObs As String
        Public Property AngioplastiaFecha As Date
        Public Property Balon As Tipos.TipoRespuestaMedico
        Public Property BalonObs As String
        Public Property BalonFecha As Date
        Public Property Farmacologia As Farmacologia
        Public Property ExamenMedico As ExamenMedico
        Public Property ExamenFisico As ExamenFisico
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
