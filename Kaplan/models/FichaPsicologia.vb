Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class FichaPsicologia
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property Sintomatologia As Integer
        Public Property DerivacionAPS As Integer
        Public Property ApoyoSocial As Integer
        Public Property ProblemaPsicosocial As Integer
        Public Property RasgoPersonalidad As Integer
        Public Property TrastornoMental As Integer
        Public Property TraumaPostOp As Integer
        Public Property ConcienciaFactor As Integer
        Public Property DificultadResp As Integer
        Public Property IngresoTaller As Integer
        Public Property Tratamiento As Integer
        Public Property Observacion As String
        Public Property Sf36 As Sf36
        Public Property Had As Had

        Public Shared Function MapeoFichaPsicologia(prmDatos As DataTable) As FichaPsicologia
            Try
                Dim vPsicologia As New FichaPsicologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vPsicologia.Id = prmRow("id_ficha_psico")
                vPsicologia.IdReserva = prmRow("id_reserva")
                vPsicologia.IdEspecialista = prmRow("id_especialista")
                vPsicologia.Sintomatologia = prmRow("sinto_prev")
                vPsicologia.DerivacionAPS = prmRow("deriv_aps")
                vPsicologia.ApoyoSocial = prmRow("apoyo_soc")
                vPsicologia.ProblemaPsicosocial = prmRow("prob_psico")
                vPsicologia.RasgoPersonalidad = prmRow("rasgo_perso")
                vPsicologia.TrastornoMental = prmRow("trast_mental")
                vPsicologia.TraumaPostOp = prmRow("trauma_post")
                vPsicologia.ConcienciaFactor = prmRow("conci_factor")
                vPsicologia.DificultadResp = prmRow("dific_resp")
                vPsicologia.IngresoTaller = prmRow("ingre_taller")
                vPsicologia.Tratamiento = prmRow("tratamiento")
                vPsicologia.Observacion = prmRow("observacion").ToString


                Dim vSf36 As New Sf36
                'vERGOESPIROMETRIA.EFechaEgreso = prmRow("ergo_fecha_egr").ToString
                'vERGOESPIROMETRIA.EFechaIngreso = prmRow("ergo_fecha_ing").ToString
                'vKinesiologia.ERGOESPIROMETRIA = vERGOESPIROMETRIA

                Dim vHad As New Had
                'vSHUTTLE.EFechaEgreso = prmRow("shu_fecha_egr").ToString
                'vSHUTTLE.EFechaIngreso = prmRow("shu_fecha_ing").ToString
                'vKinesiologia.SHUTTLE = vSHUTTLE

                Return vPsicologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace
