Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Ficha
        Public Property Id As Integer
        Public Property Numero As Integer
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property Paciente As Paciente
        Public Property FichaKinesiologia As FichaKinesiologia
        Public Property FichaPsicologia As FichaPsicologia
        Public Property FichaNutricion As FichaNutricion
        Public Property FichaEnfermeria As FichaEnfermeria
#Region "Kinesiología"
        Public Shared Function getFichaKinesiologia(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("BuscarFichaKinesiologiaxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaKinesiologia = MapeoFichaKine(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaKinesiologia

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaKine(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vKinesiologia As New FichaKinesiologia
                Dim vEvolucionE As New EvolucionEgresoKine
                Dim vEvolucionI As New EvolucionIngresoKine
                Dim vPlanKinesico As New PlanKinesico
                Dim vDiagnostico As New PlanKinesicoDiagnostico
                Dim vObjetivo As New PlanKinesicoObjetivo

                vficha.FichaKinesiologia = vKinesiologia.MapeoFichaKine(prmDatos.Tables(0))
                vficha.FichaKinesiologia.EvolucionEgresoKine = vEvolucionE.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.EvolucionIngresoKine = vEvolucionI.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.PlanKinesico = vPlanKinesico.MapeoPlan(prmDatos.Tables(4))
                vficha.FichaKinesiologia.PlanKinesico.Diagnostico = vDiagnostico.MapeoDiagnostico(prmDatos.Tables(2))
                vficha.FichaKinesiologia.PlanKinesico.Objetivo = vObjetivo.MapeoObjetivo(prmDatos.Tables(3))

                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarFichaKinesiologia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFichaKinesiologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = 1

            Dim inIdKine As OleDbParameter = cmd.Parameters.Add("@id_ficha_kine", OleDbType.Decimal, Nothing)
            inIdKine.Direction = ParameterDirection.Input
            inIdKine.Value = Me.FichaKinesiologia.Id

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaKinesiologia.IdReserva

            Dim inRiesgo As OleDbParameter = cmd.Parameters.Add("@riesgo", OleDbType.VarChar, 500)
            inRiesgo.Direction = ParameterDirection.Input
            inRiesgo.Value = Me.FichaKinesiologia.Riesgo

            Dim inTipoEvaluacion As OleDbParameter = cmd.Parameters.Add("@TipoEvaluacion", OleDbType.VarChar, 500)
            inTipoEvaluacion.Direction = ParameterDirection.Input
            inTipoEvaluacion.Value = Me.FichaKinesiologia.TipoEvaluacion

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaKinesiologia.IdEspecialista

            Dim inErgo_fecha_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_ing", OleDbType.Date, Nothing)
            inErgo_fecha_ing.Direction = ParameterDirection.Input
            inErgo_fecha_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso

            Dim inErgo_fecha_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_egr", OleDbType.Date, Nothing)
            inErgo_fecha_egr.Direction = ParameterDirection.Input
            inErgo_fecha_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso

            Dim inergo_vol_ing As OleDbParameter = cmd.Parameters.Add("@ergo_vol_ing", OleDbType.Decimal, Nothing)
            inergo_vol_ing.Direction = ParameterDirection.Input
            inergo_vol_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LIngreso

            Dim inergo_vol_egr As OleDbParameter = cmd.Parameters.Add("@ergo_vol_egr", OleDbType.Decimal, Nothing)
            inergo_vol_egr.Direction = ParameterDirection.Input
            inergo_vol_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LEgreso

            Dim inergo_voml_ing As OleDbParameter = cmd.Parameters.Add("@ergo_voml_ing", OleDbType.Decimal, Nothing)
            inergo_voml_ing.Direction = ParameterDirection.Input
            inergo_voml_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MIngreso

            Dim inergo_voml_egr As OleDbParameter = cmd.Parameters.Add("@ergo_voml_egr", OleDbType.Decimal, Nothing)
            inergo_voml_egr.Direction = ParameterDirection.Input
            inergo_voml_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MEgreso

            Dim inergo_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_ing", OleDbType.Decimal, Nothing)
            inergo_fcmax_ing.Direction = ParameterDirection.Input
            inergo_fcmax_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCIngreso

            Dim inergo_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_egr", OleDbType.Decimal, Nothing)
            inergo_fcmax_egr.Direction = ParameterDirection.Input
            inergo_fcmax_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCEgreso

            Dim inergo_pulso_ing As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_ing", OleDbType.Decimal, Nothing)
            inergo_pulso_ing.Direction = ParameterDirection.Input
            inergo_pulso_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoIngreso

            Dim inergo_pulso_egr As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_egr", OleDbType.Decimal, Nothing)
            inergo_pulso_egr.Direction = ParameterDirection.Input
            inergo_pulso_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoEgreso

            Dim inergo_ve_ing As OleDbParameter = cmd.Parameters.Add("@ergo_ve_ing", OleDbType.Decimal, Nothing)
            inergo_ve_ing.Direction = ParameterDirection.Input
            inergo_ve_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEIngreso

            Dim inergo_ve_egr As OleDbParameter = cmd.Parameters.Add("@ergo_ve_egr", OleDbType.Decimal, Nothing)
            inergo_ve_egr.Direction = ParameterDirection.Input
            inergo_ve_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEEgreso

            Dim inergo_mets_ing As OleDbParameter = cmd.Parameters.Add("@ergo_mets_ing", OleDbType.Decimal, Nothing)
            inergo_mets_ing.Direction = ParameterDirection.Input
            inergo_mets_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSIngreso

            Dim inergo_mets_egr As OleDbParameter = cmd.Parameters.Add("@ergo_mets_egr", OleDbType.Decimal, Nothing)
            inergo_mets_egr.Direction = ParameterDirection.Input
            inergo_mets_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSEgreso

            Dim inshu_fecha_ing As OleDbParameter = cmd.Parameters.Add("@shu_fecha_ing", OleDbType.Date, Nothing)
            inshu_fecha_ing.Direction = ParameterDirection.Input
            inshu_fecha_ing.Value = Me.FichaKinesiologia.SHUTTLE.EFechaIngreso

            Dim inshu_fecha_egr As OleDbParameter = cmd.Parameters.Add("@shu_fecha_egr", OleDbType.Date, Nothing)
            inshu_fecha_egr.Direction = ParameterDirection.Input
            inshu_fecha_egr.Value = Me.FichaKinesiologia.SHUTTLE.EFechaEgreso

            Dim inshu_mts_ing As OleDbParameter = cmd.Parameters.Add("@shu_mts_ing", OleDbType.Decimal, Nothing)
            inshu_mts_ing.Direction = ParameterDirection.Input
            inshu_mts_ing.Value = Me.FichaKinesiologia.SHUTTLE.METROSIngreso

            Dim inshu_mts_egr As OleDbParameter = cmd.Parameters.Add("@shu_mts_egr", OleDbType.Decimal, Nothing)
            inshu_mts_egr.Direction = ParameterDirection.Input
            inshu_mts_egr.Value = Me.FichaKinesiologia.SHUTTLE.METROSEgreso

            Dim inshu_niv_ing As OleDbParameter = cmd.Parameters.Add("@shu_niv_ing", OleDbType.Decimal, Nothing)
            inshu_niv_ing.Direction = ParameterDirection.Input
            inshu_niv_ing.Value = Me.FichaKinesiologia.SHUTTLE.NIVELIngreso

            Dim inshu_niv_egr As OleDbParameter = cmd.Parameters.Add("@shu_niv_egr", OleDbType.Decimal, Nothing)
            inshu_niv_egr.Direction = ParameterDirection.Input
            inshu_niv_egr.Value = Me.FichaKinesiologia.SHUTTLE.NIVELEgreso

            Dim inshu_vol_ing As OleDbParameter = cmd.Parameters.Add("@shu_vol_ing", OleDbType.Decimal, Nothing)
            inshu_vol_ing.Direction = ParameterDirection.Input
            inshu_vol_ing.Value = Me.FichaKinesiologia.SHUTTLE.VO2MIngreso

            Dim inshu_vol_egr As OleDbParameter = cmd.Parameters.Add("@shu_vol_egr", OleDbType.Decimal, Nothing)
            inshu_vol_egr.Direction = ParameterDirection.Input
            inshu_vol_egr.Value = Me.FichaKinesiologia.SHUTTLE.VO2MEgreso

            Dim inshu_mets_ing As OleDbParameter = cmd.Parameters.Add("@shu_mets_ing", OleDbType.Decimal, Nothing)
            inshu_mets_ing.Direction = ParameterDirection.Input
            inshu_mets_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSIngreso

            Dim inshu_mets_egr As OleDbParameter = cmd.Parameters.Add("@shu_mets_egr", OleDbType.Decimal, Nothing)
            inshu_mets_egr.Direction = ParameterDirection.Input
            inshu_mets_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSEgreso

            Dim inshu_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_ing", OleDbType.Decimal, Nothing)
            inshu_fcmax_ing.Direction = ParameterDirection.Input
            inshu_fcmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCIngreso

            Dim inshu_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_egr", OleDbType.Decimal, Nothing)
            inshu_fcmax_egr.Direction = ParameterDirection.Input
            inshu_fcmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCEgreso

            Dim inshu_fcmt_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_ing", OleDbType.Decimal, Nothing)
            inshu_fcmt_ing.Direction = ParameterDirection.Input
            inshu_fcmt_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCMTIngreso

            Dim inshu_fcmt_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_egr", OleDbType.Decimal, Nothing)
            inshu_fcmt_egr.Direction = ParameterDirection.Input
            inshu_fcmt_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCMTEgreso

            Dim inshu_metsmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_ing", OleDbType.Decimal, Nothing)
            inshu_metsmax_ing.Direction = ParameterDirection.Input
            inshu_metsmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXIngreso

            Dim inshu_metsmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_egr", OleDbType.Decimal, Nothing)
            inshu_metsmax_egr.Direction = ParameterDirection.Input
            inshu_metsmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXEgreso

            Dim inid_evolucion_1 As OleDbParameter = cmd.Parameters.Add("@Diagnostico", OleDbType.Decimal, Nothing)
            inid_evolucion_1.Direction = ParameterDirection.Input
            inid_evolucion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Id

            Dim inevolucion_fecha_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_1", OleDbType.Date, Nothing)
            inevolucion_fecha_1.Direction = ParameterDirection.Input
            inevolucion_fecha_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Fecha

            Dim inevolucion_eva_mus_esq_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_1", OleDbType.VarChar, 500)
            inevolucion_eva_mus_esq_1.Direction = ParameterDirection.Input
            inevolucion_eva_mus_esq_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.EME

            Dim inevolcuion_observacion_1 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_1", OleDbType.VarChar, 500)
            inevolcuion_observacion_1.Direction = ParameterDirection.Input
            inevolcuion_observacion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Observacion

            Dim inid_evolucion_2 As OleDbParameter = cmd.Parameters.Add("@id_evolucion_2", OleDbType.Decimal, Nothing)
            inid_evolucion_2.Direction = ParameterDirection.Input
            inid_evolucion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Id

            Dim inevolucion_fecha_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_2", OleDbType.Date, Nothing)
            inevolucion_fecha_2.Direction = ParameterDirection.Input
            inevolucion_fecha_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Fecha

            Dim inevolucion_eva_mus_esq_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_2", OleDbType.VarChar, 500)
            inevolucion_eva_mus_esq_2.Direction = ParameterDirection.Input
            inevolucion_eva_mus_esq_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.EME

            Dim inevolcuion_observacion_2 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_2", OleDbType.VarChar, 500)
            inevolcuion_observacion_2.Direction = ParameterDirection.Input
            inevolcuion_observacion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Observacion

            Dim inidPlan_kine As OleDbParameter = cmd.Parameters.Add("@v_idPlan_kine", OleDbType.Decimal, Nothing)
            inidPlan_kine.Direction = ParameterDirection.Input
            inidPlan_kine.Value = Me.FichaKinesiologia.PlanKinesico.Id

            Dim ineje_aerobico As OleDbParameter = cmd.Parameters.Add("@eje_aerobico", OleDbType.VarChar, 500)
            ineje_aerobico.Direction = ParameterDirection.Input
            ineje_aerobico.Value = Me.FichaKinesiologia.PlanKinesico.AEROBICO

            Dim ineje_sobrecarga As OleDbParameter = cmd.Parameters.Add("@eje_sobrecarga", OleDbType.VarChar, 500)
            ineje_sobrecarga.Direction = ParameterDirection.Input
            ineje_sobrecarga.Value = Me.FichaKinesiologia.PlanKinesico.SOBRECARGA

            Dim inentre_funcional As OleDbParameter = cmd.Parameters.Add("@entre_funcional", OleDbType.VarChar, 500)
            inentre_funcional.Direction = ParameterDirection.Input
            inentre_funcional.Value = Me.FichaKinesiologia.PlanKinesico.FUNCIONAL

            Dim inedu_habitos_cardio As OleDbParameter = cmd.Parameters.Add("@edu_habitos_cardio", OleDbType.VarChar, 500)
            inedu_habitos_cardio.Direction = ParameterDirection.Input
            inedu_habitos_cardio.Value = Me.FichaKinesiologia.PlanKinesico.EDUCACION

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, -1)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONDiagnostico(Me.FichaKinesiologia.PlanKinesico.Diagnostico)

            Dim inobjetivo As OleDbParameter = cmd.Parameters.Add("@objetivo", OleDbType.VarChar, -1)
            inobjetivo.Direction = ParameterDirection.Input
            inobjetivo.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONObjetivo(Me.FichaKinesiologia.PlanKinesico.Objetivo)

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdKine", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outIdKine").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Psicología"
        Public Shared Function getFichaPsicologia(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("[BuscarFichaPsicologiaxReserva]", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaPsicologia = MapeoFichaPsicologia(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaPsicologia

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaPsicologia(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vPsicologia As New FichaPsicologia
                vficha.FichaPsicologia = vPsicologia.MapeoFichaPsicologia(prmDatos.Tables(0))
                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarFichaPsicologia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFichaPsicologia", conn)
            cmd.CommandType = CommandType.StoredProcedure
#Region "Ficha Psicología"
            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = 1

            Dim inIdPsico As OleDbParameter = cmd.Parameters.Add("@id_ficha_psico", OleDbType.Decimal, Nothing)
            inIdPsico.Direction = ParameterDirection.Input
            inIdPsico.Value = Me.FichaPsicologia.Id

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaPsicologia.IdEspecialista

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaPsicologia.IdReserva

            Dim inSintomatologia As OleDbParameter = cmd.Parameters.Add("@sinto_prev", OleDbType.Decimal, Nothing)
            inSintomatologia.Direction = ParameterDirection.Input
            inSintomatologia.Value = Me.FichaPsicologia.Sintomatologia.ID

            Dim inDerivacionAPS As OleDbParameter = cmd.Parameters.Add("@deriv_aps", OleDbType.Decimal, Nothing)
            inDerivacionAPS.Direction = ParameterDirection.Input
            inDerivacionAPS.Value = Me.FichaPsicologia.DerivacionAPS.ID

            Dim inApoyoSocial As OleDbParameter = cmd.Parameters.Add("@apoyo_soc", OleDbType.Decimal, Nothing)
            inApoyoSocial.Direction = ParameterDirection.Input
            inApoyoSocial.Value = Me.FichaPsicologia.ApoyoSocial.ID

            Dim inProblemaPsicosocial As OleDbParameter = cmd.Parameters.Add("@prob_psico", OleDbType.Decimal, Nothing)
            inProblemaPsicosocial.Direction = ParameterDirection.Input
            inProblemaPsicosocial.Value = Me.FichaPsicologia.ProblemaPsicosocial.ID

            Dim inRasgoPersonalidad As OleDbParameter = cmd.Parameters.Add("@rasgo_perso", OleDbType.Decimal, Nothing)
            inRasgoPersonalidad.Direction = ParameterDirection.Input
            inRasgoPersonalidad.Value = Me.FichaPsicologia.RasgoPersonalidad.ID

            Dim inTrastornoMental As OleDbParameter = cmd.Parameters.Add("@trast_mental", OleDbType.Decimal, Nothing)
            inTrastornoMental.Direction = ParameterDirection.Input
            inTrastornoMental.Value = Me.FichaPsicologia.TrastornoMental.ID

            Dim inTraumaPostOp As OleDbParameter = cmd.Parameters.Add("@trauma_post", OleDbType.Decimal, Nothing)
            inTraumaPostOp.Direction = ParameterDirection.Input
            inTraumaPostOp.Value = Me.FichaPsicologia.TraumaPostOp.ID

            Dim inConcienciaFactor As OleDbParameter = cmd.Parameters.Add("@conci_factor", OleDbType.Decimal, Nothing)
            inConcienciaFactor.Direction = ParameterDirection.Input
            inConcienciaFactor.Value = Me.FichaPsicologia.ConcienciaFactor.ID

            Dim inDificultadResp As OleDbParameter = cmd.Parameters.Add("@dific_resp", OleDbType.Decimal, Nothing)
            inDificultadResp.Direction = ParameterDirection.Input
            inDificultadResp.Value = Me.FichaPsicologia.DificultadResp.ID

            Dim inIngresoTaller As OleDbParameter = cmd.Parameters.Add("@ingre_taller", OleDbType.Decimal, Nothing)
            inIngresoTaller.Direction = ParameterDirection.Input
            inIngresoTaller.Value = Me.FichaPsicologia.IngresoTaller.ID

            Dim inTratamiento As OleDbParameter = cmd.Parameters.Add("@tratamiento", OleDbType.Decimal, Nothing)
            inTratamiento.Direction = ParameterDirection.Input
            inTratamiento.Value = Me.FichaPsicologia.Tratamiento.ID

            Dim inObservacion As OleDbParameter = cmd.Parameters.Add("@observacion", OleDbType.VarChar, 500)
            inObservacion.Direction = ParameterDirection.Input
            inObservacion.Value = Me.FichaPsicologia.Observacion
#End Region
#Region "SF36"
            Dim inSFFechaAIng As OleDbParameter = cmd.Parameters.Add("@sf_fechaa_ing", OleDbType.Date, Nothing)
            inSFFechaAIng.Direction = ParameterDirection.Input
            inSFFechaAIng.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inSFFechaAEgr As OleDbParameter = cmd.Parameters.Add("@sf_fechaa_egr", OleDbType.Date, Nothing)
            inSFFechaAEgr.Direction = ParameterDirection.Input
            inSFFechaAEgr.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inFuncionFisicaIng As OleDbParameter = cmd.Parameters.Add("@sf_funcion_ing", OleDbType.Decimal, Nothing)
            inFuncionFisicaIng.Direction = ParameterDirection.Input
            inFuncionFisicaIng.Value = Me.FichaPsicologia.Sf36.FuncionFisicaIng

            Dim inFuncionFisicaEgr As OleDbParameter = cmd.Parameters.Add("@sf_funcion_egr", OleDbType.Decimal, Nothing)
            inFuncionFisicaEgr.Direction = ParameterDirection.Input
            inFuncionFisicaEgr.Value = Me.FichaPsicologia.Sf36.FuncionFisicaEgr

            Dim inRolFisicoIng As OleDbParameter = cmd.Parameters.Add("@sf_rol_ing", OleDbType.Decimal, Nothing)
            inRolFisicoIng.Direction = ParameterDirection.Input
            inRolFisicoIng.Value = Me.FichaPsicologia.Sf36.RolFisicoIng

            Dim inRolFisicoEgr As OleDbParameter = cmd.Parameters.Add("@sf_rol_egr", OleDbType.Decimal, Nothing)
            inRolFisicoEgr.Direction = ParameterDirection.Input
            inRolFisicoEgr.Value = Me.FichaPsicologia.Sf36.RolFisicoEgr

            Dim inDolorIng As OleDbParameter = cmd.Parameters.Add("@sf_dolor_ing", OleDbType.Decimal, Nothing)
            inDolorIng.Direction = ParameterDirection.Input
            inDolorIng.Value = Me.FichaPsicologia.Sf36.DolorIng

            Dim inDolorEgr As OleDbParameter = cmd.Parameters.Add("@sf_dolor_egr", OleDbType.Decimal, Nothing)
            inDolorEgr.Direction = ParameterDirection.Input
            inDolorEgr.Value = Me.FichaPsicologia.Sf36.DolorEgr

            Dim inSaludIng As OleDbParameter = cmd.Parameters.Add("@sf_salud_ing", OleDbType.Decimal, Nothing)
            inSaludIng.Direction = ParameterDirection.Input
            inSaludIng.Value = Me.FichaPsicologia.Sf36.SaludIng

            Dim inSaludEgr As OleDbParameter = cmd.Parameters.Add("@sf_salud_egr", OleDbType.Decimal, Nothing)
            inSaludEgr.Direction = ParameterDirection.Input
            inSaludEgr.Value = Me.FichaPsicologia.Sf36.SaludEgr

            Dim inSFFechaBIng As OleDbParameter = cmd.Parameters.Add("@sf_fechab_ing", OleDbType.Date, Nothing)
            inSFFechaBIng.Direction = ParameterDirection.Input
            inSFFechaBIng.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inSFFechaBEgr As OleDbParameter = cmd.Parameters.Add("@sf_fechab_egr", OleDbType.Date, Nothing)
            inSFFechaBEgr.Direction = ParameterDirection.Input
            inSFFechaBEgr.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inVitalidadIng As OleDbParameter = cmd.Parameters.Add("@sf_vital_ing", OleDbType.Decimal, Nothing)
            inVitalidadIng.Direction = ParameterDirection.Input
            inVitalidadIng.Value = Me.FichaPsicologia.Sf36.VitalidadIng

            Dim inVitalidadEgr As OleDbParameter = cmd.Parameters.Add("@sf_vital_egr", OleDbType.Decimal, Nothing)
            inVitalidadEgr.Direction = ParameterDirection.Input
            inVitalidadEgr.Value = Me.FichaPsicologia.Sf36.VitalidadEgr

            Dim inFuncionSocialIng As OleDbParameter = cmd.Parameters.Add("@sf_funcionsoc_ing", OleDbType.Decimal, Nothing)
            inFuncionSocialIng.Direction = ParameterDirection.Input
            inFuncionSocialIng.Value = Me.FichaPsicologia.Sf36.FuncionSocialIng

            Dim inFuncionSocialEgr As OleDbParameter = cmd.Parameters.Add("@sf_funcionsoc_egr", OleDbType.Decimal, Nothing)
            inFuncionSocialEgr.Direction = ParameterDirection.Input
            inFuncionSocialEgr.Value = Me.FichaPsicologia.Sf36.FuncionSocialEgr

            Dim inRolEmocionalIng As OleDbParameter = cmd.Parameters.Add("@sf_rolemo_ing", OleDbType.Decimal, Nothing)
            inRolEmocionalIng.Direction = ParameterDirection.Input
            inRolEmocionalIng.Value = Me.FichaPsicologia.Sf36.RolEmocionalIng

            Dim inRolEmocionalEgr As OleDbParameter = cmd.Parameters.Add("@sf_rolemo_egr", OleDbType.Decimal, Nothing)
            inRolEmocionalEgr.Direction = ParameterDirection.Input
            inRolEmocionalEgr.Value = Me.FichaPsicologia.Sf36.RolEmocionalEgr

            Dim inSaludMentalIng As OleDbParameter = cmd.Parameters.Add("@sf_saludmen_ing", OleDbType.Decimal, Nothing)
            inSaludMentalIng.Direction = ParameterDirection.Input
            inSaludMentalIng.Value = Me.FichaPsicologia.Sf36.SaludMentalIng

            Dim inSaludMentalEgr As OleDbParameter = cmd.Parameters.Add("@sf_saludmen_egr", OleDbType.Decimal, Nothing)
            inSaludMentalEgr.Direction = ParameterDirection.Input
            inSaludMentalEgr.Value = Me.FichaPsicologia.Sf36.SaludMentalEgr

            Dim inSFObservacion As OleDbParameter = cmd.Parameters.Add("@sf_observacion", OleDbType.VarChar, 500)
            inSFObservacion.Direction = ParameterDirection.Input
            inSFObservacion.Value = Me.FichaPsicologia.Sf36.Observacion
#End Region
#Region "HAD"
            Dim inHadFechaAIng As OleDbParameter = cmd.Parameters.Add("@had_fechaa_ing", OleDbType.Date, Nothing)
            inHadFechaAIng.Direction = ParameterDirection.Input
            inHadFechaAIng.Value = Me.FichaPsicologia.Had.FechaAIng

            Dim inHadFechaAEgr As OleDbParameter = cmd.Parameters.Add("@had_fechaa_egr", OleDbType.Date, Nothing)
            inHadFechaAEgr.Direction = ParameterDirection.Input
            inHadFechaAEgr.Value = Me.FichaPsicologia.Had.FechaAEgr

            Dim inAnsiedadIng As OleDbParameter = cmd.Parameters.Add("@had_ansie_ing", OleDbType.Decimal, Nothing)
            inAnsiedadIng.Direction = ParameterDirection.Input
            inAnsiedadIng.Value = Me.FichaPsicologia.Had.AnsiedadIng

            Dim inAnsiedadEgr As OleDbParameter = cmd.Parameters.Add("@had_ansie_egr", OleDbType.Decimal, Nothing)
            inAnsiedadEgr.Direction = ParameterDirection.Input
            inAnsiedadEgr.Value = Me.FichaPsicologia.Had.AnsiedadEgr


            Dim inDepresionIng As OleDbParameter = cmd.Parameters.Add("@had_depre_ing", OleDbType.Decimal, Nothing)
            inDepresionIng.Direction = ParameterDirection.Input
            inDepresionIng.Value = Me.FichaPsicologia.Had.DepresionIng

            Dim inDepresionEgr As OleDbParameter = cmd.Parameters.Add("@had_depre_egr", OleDbType.Decimal, Nothing)
            inDepresionEgr.Direction = ParameterDirection.Input
            inDepresionEgr.Value = Me.FichaPsicologia.Had.DepresionEgr

            Dim inHadFechaBIng As OleDbParameter = cmd.Parameters.Add("@had_fechab_ing", OleDbType.Date, Nothing)
            inHadFechaBIng.Direction = ParameterDirection.Input
            inHadFechaBIng.Value = Me.FichaPsicologia.Had.FechaBIng

            Dim inHadFechaBEgr As OleDbParameter = cmd.Parameters.Add("@had_fechab_egr", OleDbType.Date, Nothing)
            inHadFechaBEgr.Direction = ParameterDirection.Input
            inHadFechaBEgr.Value = Me.FichaPsicologia.Had.FechaBEgr

            Dim inSubEscalaAnsiedadIng As OleDbParameter = cmd.Parameters.Add("@had_suba_ing", OleDbType.Decimal, Nothing)
            inSubEscalaAnsiedadIng.Direction = ParameterDirection.Input
            inSubEscalaAnsiedadIng.Value = Me.FichaPsicologia.Had.SubEscalaAnsiedadIng

            Dim inSubEscalaAnsiedadEgr As OleDbParameter = cmd.Parameters.Add("@had_suba_egr", OleDbType.Decimal, Nothing)
            inSubEscalaAnsiedadEgr.Direction = ParameterDirection.Input
            inSubEscalaAnsiedadEgr.Value = Me.FichaPsicologia.Had.SubEscalaAnsiedadEgr

            Dim inSubEscalaDepresionIng As OleDbParameter = cmd.Parameters.Add("@had_subd_ing", OleDbType.Decimal, Nothing)
            inSubEscalaDepresionIng.Direction = ParameterDirection.Input
            inSubEscalaDepresionIng.Value = Me.FichaPsicologia.Had.SubEscalaDepresionIng

            Dim inSubEscalaDepresionEgr As OleDbParameter = cmd.Parameters.Add("@had_subd_egr", OleDbType.Decimal, Nothing)
            inSubEscalaDepresionEgr.Direction = ParameterDirection.Input
            inSubEscalaDepresionEgr.Value = Me.FichaPsicologia.Had.SubEscalaDepresionEgr

            Dim inHadObservacion As OleDbParameter = cmd.Parameters.Add("@had_observacion", OleDbType.VarChar, 500)
            inHadObservacion.Direction = ParameterDirection.Input
            inHadObservacion.Value = Me.FichaPsicologia.Had.Observacion
#End Region
            Dim inAntecedentes As OleDbParameter = cmd.Parameters.Add("@antecedentes", OleDbType.VarChar, 500)
            inAntecedentes.Direction = ParameterDirection.Input
            inAntecedentes.Value = Me.FichaPsicologia.Antecedentes

            Dim inDiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, 500)
            inDiagnostico.Direction = ParameterDirection.Input
            inDiagnostico.Value = Me.FichaPsicologia.Diagnostico

            Dim inObjetivos As OleDbParameter = cmd.Parameters.Add("@objetivos", OleDbType.VarChar, 500)
            inObjetivos.Direction = ParameterDirection.Input
            inObjetivos.Value = Me.FichaPsicologia.Objetivo

            Dim inIntervencion As OleDbParameter = cmd.Parameters.Add("@intervencion", OleDbType.VarChar, 500)
            inIntervencion.Direction = ParameterDirection.Input
            inIntervencion.Value = Me.FichaPsicologia.Intervencion

            Dim inEvaluacion As OleDbParameter = cmd.Parameters.Add("@evaluacion", OleDbType.VarChar, 500)
            inEvaluacion.Direction = ParameterDirection.Input
            inEvaluacion.Value = Me.FichaPsicologia.Evaluacion

            Dim inEvolucion As OleDbParameter = cmd.Parameters.Add("@evolucion", OleDbType.VarChar, 500)
            inEvolucion.Direction = ParameterDirection.Input
            inEvolucion.Value = Me.FichaPsicologia.Evolucion

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdPsico", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idpsico = CInt(cmd.Parameters("@outIdPsico").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Enfermeria"
        Public Function registrarFichaEnfermeria() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFichaEnfermeria", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = 1

            Dim inIdEnfer As OleDbParameter = cmd.Parameters.Add("@id_ficha_Enfermeria", OleDbType.Decimal, Nothing)
            inIdEnfer.Direction = ParameterDirection.Input
            inIdEnfer.Value = -1 'Me.FichaEnfermeria.Id

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaEnfermeria.IdReserva

            Dim inProcedencia As OleDbParameter = cmd.Parameters.Add("@Procedencia", OleDbType.VarChar, 500)
            inProcedencia.Direction = ParameterDirection.Input
            inProcedencia.Value = Me.FichaEnfermeria.Procedencia

            Dim inTipoEvaluacion As OleDbParameter = cmd.Parameters.Add("@TipoEvaluacion", OleDbType.VarChar, 500)
            inTipoEvaluacion.Direction = ParameterDirection.Input
            inTipoEvaluacion.Value = Me.FichaEnfermeria.TipoEvaluacion

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaEnfermeria.IdEspecialista

            Dim inDiagnostico As OleDbParameter = cmd.Parameters.Add("@Diagnostico", OleDbType.VarChar, 500)
            inDiagnostico.Direction = ParameterDirection.Input
            inDiagnostico.Value = Me.FichaEnfermeria.Diagnostico

            Dim inFechaDiagnostico As OleDbParameter = cmd.Parameters.Add("@FechaDiagnostico", OleDbType.Date, Nothing)
            inFechaDiagnostico.Direction = ParameterDirection.Input
            inFechaDiagnostico.Value = Me.FichaEnfermeria.FechaDiagnostico

            Dim inCxProced As OleDbParameter = cmd.Parameters.Add("@CxProced", OleDbType.VarChar, 500)
            inCxProced.Direction = ParameterDirection.Input
            inCxProced.Value = Me.FichaEnfermeria.CxProced

            Dim inFechaCxProced As OleDbParameter = cmd.Parameters.Add("@FechaCxProced", OleDbType.Date, Nothing)
            inFechaCxProced.Direction = ParameterDirection.Input
            inFechaCxProced.Value = Me.FichaEnfermeria.FechaCxProced

            Dim inControles As OleDbParameter = cmd.Parameters.Add("@Controles", OleDbType.VarChar, 500)
            inControles.Direction = ParameterDirection.Input
            inControles.Value = Me.FichaEnfermeria.Controles

            Dim inFechaAlta As OleDbParameter = cmd.Parameters.Add("@FechaAlta", OleDbType.Date, Nothing)
            inFechaAlta.Direction = ParameterDirection.Input
            inFechaAlta.Value = Me.FichaEnfermeria.FechaAlta

            Dim inHeridaCX As OleDbParameter = cmd.Parameters.Add("@HeridaCX", OleDbType.VarChar, 500)
            inHeridaCX.Direction = ParameterDirection.Input
            inHeridaCX.Value = Me.FichaEnfermeria.HeridaCX

            Dim inHTA As OleDbParameter = cmd.Parameters.Add("@HTA", OleDbType.Decimal, Nothing)
            inHTA.Direction = ParameterDirection.Input
            inHTA.Value = Me.FichaEnfermeria.HTA.ID

            Dim inDM As OleDbParameter = cmd.Parameters.Add("@DM", OleDbType.Decimal, Nothing)
            inDM.Direction = ParameterDirection.Input
            inDM.Value = Me.FichaEnfermeria.DM.ID

            Dim inDLP As OleDbParameter = cmd.Parameters.Add("@DLP", OleDbType.Decimal, Nothing)
            inDLP.Direction = ParameterDirection.Input
            inDLP.Value = Me.FichaEnfermeria.DLP.ID

            Dim inSED As OleDbParameter = cmd.Parameters.Add("@SED", OleDbType.Decimal, Nothing)
            inSED.Direction = ParameterDirection.Input
            inSED.Value = Me.FichaEnfermeria.SED.ID

            Dim inSPOB As OleDbParameter = cmd.Parameters.Add("@SPOB", OleDbType.Decimal, Nothing)
            inSPOB.Direction = ParameterDirection.Input
            inSPOB.Value = Me.FichaEnfermeria.SPOB.ID

            Dim inTB As OleDbParameter = cmd.Parameters.Add("@TB", OleDbType.Decimal, Nothing)
            inTB.Direction = ParameterDirection.Input
            inTB.Value = Me.FichaEnfermeria.TB.ID

            Dim inOH As OleDbParameter = cmd.Parameters.Add("@OH", OleDbType.Decimal, Nothing)
            inOH.Direction = ParameterDirection.Input
            inOH.Value = Me.FichaEnfermeria.OH.ID

            Dim inAF As OleDbParameter = cmd.Parameters.Add("@AF", OleDbType.Decimal, Nothing)
            inAF.Direction = ParameterDirection.Input
            inAF.Value = Me.FichaEnfermeria.AF.ID

            Dim inEstres As OleDbParameter = cmd.Parameters.Add("@Estres", OleDbType.Decimal, Nothing)
            inEstres.Direction = ParameterDirection.Input
            inEstres.Value = Me.FichaEnfermeria.Estres.ID

            Dim inIntervencion As OleDbParameter = cmd.Parameters.Add("@Intervencion", OleDbType.VarChar, 500)
            inIntervencion.Direction = ParameterDirection.Input
            inIntervencion.Value = Me.FichaEnfermeria.Intervencion

            Dim inMedicamento As OleDbParameter = cmd.Parameters.Add("@Medicamento", OleDbType.VarChar, -1)
            inMedicamento.Direction = ParameterDirection.Input
            inMedicamento.Value = Me.FichaEnfermeria.ToJSONMedicamentos(Me.FichaEnfermeria.MedicamentosEnfermeria)

            Dim inid_anamnesis As OleDbParameter = cmd.Parameters.Add("@id_anamnesis", OleDbType.Decimal, Nothing)
            inid_anamnesis.Direction = ParameterDirection.Input
            inid_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Id

            Dim inAntecedentesRelevantes_anamnesis As OleDbParameter = cmd.Parameters.Add("@AntecedentesRelevantes_anamnesis", OleDbType.VarChar, 500)
            inAntecedentesRelevantes_anamnesis.Direction = ParameterDirection.Input
            inAntecedentesRelevantes_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.AntecedentesRelevantes

            Dim inPatronRespiratorio_anamnesis As OleDbParameter = cmd.Parameters.Add("@PatronRespiratorio_anamnesis", OleDbType.Decimal, Nothing)
            inPatronRespiratorio_anamnesis.Direction = ParameterDirection.Input
            inPatronRespiratorio_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.PatronRespiratorio.ID

            Dim inRegimenHiposodico_anamnesis As OleDbParameter = cmd.Parameters.Add("@RegimenHiposodico_anamnesis", OleDbType.Decimal, Nothing)
            inRegimenHiposodico_anamnesis.Direction = ParameterDirection.Input
            inRegimenHiposodico_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.RegimenHiposodico.ID

            Dim inFrutayVerdura_anamnesis As OleDbParameter = cmd.Parameters.Add("@FrutayVerdura_anamnesis", OleDbType.Decimal, Nothing)
            inFrutayVerdura_anamnesis.Direction = ParameterDirection.Input
            inFrutayVerdura_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.FrutayVerdura.ID

            Dim inAgua_anamnesis As OleDbParameter = cmd.Parameters.Add("@Agua_anamnesis", OleDbType.Decimal, Nothing)
            inAgua_anamnesis.Direction = ParameterDirection.Input
            inAgua_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Agua.ID

            Dim inBebidaNec_anamnesis As OleDbParameter = cmd.Parameters.Add("@BebidaNec_anamnesis", OleDbType.Decimal, Nothing)
            inBebidaNec_anamnesis.Direction = ParameterDirection.Input
            inBebidaNec_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.BebidaNec.ID

            Dim inGrasas_anamnesis As OleDbParameter = cmd.Parameters.Add("@Grasas_anamnesis", OleDbType.Decimal, Nothing)
            inGrasas_anamnesis.Direction = ParameterDirection.Input
            inGrasas_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Grasas.ID

            Dim inDiuresis_anamnesis As OleDbParameter = cmd.Parameters.Add("@Diuresis_anamnesis", OleDbType.Decimal, Nothing)
            inDiuresis_anamnesis.Direction = ParameterDirection.Input
            inDiuresis_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Diuresis.ID

            Dim inDeposicion_anamnesis As OleDbParameter = cmd.Parameters.Add("@Deposicion_anamnesis", OleDbType.Decimal, Nothing)
            inDeposicion_anamnesis.Direction = ParameterDirection.Input
            inDeposicion_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Deposicion.ID

            Dim inTBa_anamnesis As OleDbParameter = cmd.Parameters.Add("@TBa_anamnesis", OleDbType.Decimal, Nothing)
            inTBa_anamnesis.Direction = ParameterDirection.Input
            inTBa_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.TBa.ID

            Dim inTBb_anamnesis As OleDbParameter = cmd.Parameters.Add("@TBb_anamnesis", OleDbType.Decimal, Nothing)
            inTBb_anamnesis.Direction = ParameterDirection.Input
            inTBb_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.TBb.ID

            Dim inEA_anamnesis As OleDbParameter = cmd.Parameters.Add("@EA_anamnesis", OleDbType.Decimal, Nothing)
            inEA_anamnesis.Direction = ParameterDirection.Input
            inEA_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.EA.ID

            Dim inSuenoNocturnoa_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnoa_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnoa_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnoa_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnoa.ID

            Dim inSuenoNocturnob_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnob_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnob_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnob_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnob.ID

            Dim inSuenoNocturnoc_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnoc_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnoc_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnoc_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnoc.ID

            Dim inMotivacion_anamnesis As OleDbParameter = cmd.Parameters.Add("@Motivacion_anamnesis", OleDbType.Decimal, Nothing)
            inMotivacion_anamnesis.Direction = ParameterDirection.Input
            inMotivacion_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Motivacion.ID

            Dim inAVD_anamnesis As OleDbParameter = cmd.Parameters.Add("@AVD_anamnesis", OleDbType.Decimal, Nothing)
            inAVD_anamnesis.Direction = ParameterDirection.Input
            inAVD_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.AVD.ID

            Dim inActividadesRecreativas_anamnesis As OleDbParameter = cmd.Parameters.Add("@ActividadesRecreativas_anamnesis", OleDbType.Decimal, Nothing)
            inActividadesRecreativas_anamnesis.Direction = ParameterDirection.Input
            inActividadesRecreativas_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.ActividadesRecreativas.ID

            Dim inid_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@id_ExamenFisico", OleDbType.Decimal, Nothing)
            inid_ExamenFisico.Direction = ParameterDirection.Input
            inid_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Id

            Dim inCabeza_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Cabeza_ExamenFisico", OleDbType.Decimal, Nothing)
            inCabeza_ExamenFisico.Direction = ParameterDirection.Input
            inCabeza_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Cabeza.ID

            Dim inCuello_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Cuello_ExamenFisico", OleDbType.Decimal, Nothing)
            inCuello_ExamenFisico.Direction = ParameterDirection.Input
            inCuello_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Cuello.ID

            Dim inToraxa_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxa_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxa_ExamenFisico.Direction = ParameterDirection.Input
            inToraxa_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxa.ID

            Dim inToraxb_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxb_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxb_ExamenFisico.Direction = ParameterDirection.Input
            inToraxb_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxb.ID

            Dim inToraxc_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxc_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxc_ExamenFisico.Direction = ParameterDirection.Input
            inToraxc_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxc.ID

            Dim inToraxd_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxd_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxd_ExamenFisico.Direction = ParameterDirection.Input
            inToraxd_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxd.ID

            Dim inAbdomena_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Abdomena_ExamenFisico", OleDbType.Decimal, Nothing)
            inAbdomena_ExamenFisico.Direction = ParameterDirection.Input
            inAbdomena_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Abdomena.ID

            Dim inAbdomenb_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Abdomenb_ExamenFisico", OleDbType.Decimal, Nothing)
            inAbdomenb_ExamenFisico.Direction = ParameterDirection.Input
            inAbdomenb_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Abdomenb.ID

            Dim inEESS_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@EESS_ExamenFisico", OleDbType.Decimal, Nothing)
            inEESS_ExamenFisico.Direction = ParameterDirection.Input
            inEESS_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.EESS.ID

            Dim inllencap_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@llencap_ExamenFisico", OleDbType.Decimal, Nothing)
            inllencap_ExamenFisico.Direction = ParameterDirection.Input
            inllencap_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.llencap.ID

            Dim inEEII_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@EEII_ExamenFisico", OleDbType.Decimal, Nothing)
            inEEII_ExamenFisico.Direction = ParameterDirection.Input
            inEEII_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.EEII.ID

            Dim inPA_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@PA_ExamenFisico", OleDbType.Decimal, Nothing)
            inPA_ExamenFisico.Direction = ParameterDirection.Input
            inPA_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.PA

            Dim inFC_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@FC_ExamenFisico", OleDbType.Decimal, Nothing)
            inFC_ExamenFisico.Direction = ParameterDirection.Input
            inFC_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.FC

            Dim inSAT_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@SAT_ExamenFisico", OleDbType.Decimal, Nothing)
            inSAT_ExamenFisico.Direction = ParameterDirection.Input
            inSAT_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.SAT

            Dim inGlicemia_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Glicemia_ExamenFisico", OleDbType.Decimal, Nothing)
            inGlicemia_ExamenFisico.Direction = ParameterDirection.Input
            inGlicemia_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Glicemia

            Dim inEvolucion As OleDbParameter = cmd.Parameters.Add("@Evolucion", OleDbType.VarChar, -1)
            inEvolucion.Direction = ParameterDirection.Input
            inEvolucion.Value = Me.FichaEnfermeria.ToJSONEvolucion(Me.FichaEnfermeria.EvolucionEnfermeria)

            Dim inid_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@id_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inid_PlanEnfermeria.Direction = ParameterDirection.Input
            inid_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Id

            Dim inAdeherenciaFarma_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AdeherenciaFarma_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAdeherenciaFarma_PlanEnfermeria.Direction = ParameterDirection.Input
            inAdeherenciaFarma_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AdeherenciaFarma.ID

            Dim inRespiracion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Respiracion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inRespiracion_PlanEnfermeria.Direction = ParameterDirection.Input
            inRespiracion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Respiracion.ID

            Dim inAlimentacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Alimentacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAlimentacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAlimentacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Alimentacion.ID

            Dim inEliminacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Eliminacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inEliminacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inEliminacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Eliminacion.ID

            Dim inDescanso_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Descanso_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inDescanso_PlanEnfermeria.Direction = ParameterDirection.Input
            inDescanso_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Descanso.ID

            Dim inHigienePiel_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@HigienePiel_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inHigienePiel_PlanEnfermeria.Direction = ParameterDirection.Input
            inHigienePiel_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.HigienePiel.ID

            Dim inActividades_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Actividades_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inActividades_PlanEnfermeria.Direction = ParameterDirection.Input
            inActividades_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Actividades.ID

            Dim inVestirse_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Vestirse_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inVestirse_PlanEnfermeria.Direction = ParameterDirection.Input
            inVestirse_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Vestirse.ID

            Dim inComunicarse_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Comunicarse_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inComunicarse_PlanEnfermeria.Direction = ParameterDirection.Input
            inComunicarse_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Comunicarse.ID

            Dim inAutoRealizacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AutoRealizacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAutoRealizacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAutoRealizacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AutoRealizacion.ID

            Dim inRespiracionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@RespiracionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inRespiracionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inRespiracionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.RespiracionObservacion

            Dim inAlimentacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AlimentacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inAlimentacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAlimentacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AlimentacionObservacion

            Dim inEliminacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@EliminacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inEliminacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inEliminacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.EliminacionObservacion

            Dim inDescansoObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@DescansoObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inDescansoObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inDescansoObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.DescansoObservacion

            Dim inHigienePielObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@HigienePielObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inHigienePielObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inHigienePielObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.HigienePielObservacion

            Dim inActividadesObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@ActividadesObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inActividadesObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inActividadesObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ActividadesObservacion

            Dim inVestirseObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@VestirseObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inVestirseObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inVestirseObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.VestirseObservacion

            Dim inComunicarseObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@ComunicarseObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inComunicarseObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inComunicarseObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ComunicarseObservacion

            Dim inAutoRealizacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AutoRealizacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inAutoRealizacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAutoRealizacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AutoRealizacionObservacion

            Dim inObjetivo_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Objetivo_PlanEnfermeria", OleDbType.VarChar, 500)
            inObjetivo_PlanEnfermeria.Direction = ParameterDirection.Input
            inObjetivo_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Objetivo

            Dim inDiagnostico_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Diagnostico_PlanEnfermeria", OleDbType.VarChar, -1)
            inDiagnostico_PlanEnfermeria.Direction = ParameterDirection.Input
            inDiagnostico_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONDiagnosticos(Me.FichaEnfermeria.PlanEnfermeria.Diagnostico)

            Dim inIntervencion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Intervencion_PlanEnfermeria", OleDbType.VarChar, -1)
            inIntervencion_PlanEnfermeria.Direction = ParameterDirection.Input
            inIntervencion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONIntervencion(Me.FichaEnfermeria.PlanEnfermeria.Intervencion)

            Dim inIndicadores_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Indicadores_PlanEnfermeria", OleDbType.VarChar, -1)
            inIndicadores_PlanEnfermeria.Direction = ParameterDirection.Input
            inIndicadores_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONIndicador(Me.FichaEnfermeria.PlanEnfermeria.Indicadores)

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdEnf As OleDbParameter = cmd.Parameters.Add("@outIdEnf", OleDbType.Integer)
            outIdEnf.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idEnfer = CInt(cmd.Parameters("@outIdEnf").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Nutrición"
        Public Shared Function getFichaNutricion(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("[BuscarFichaNutricionxReserva]", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaNutricion = MapeoFichaNutricion(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaNutricion

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaNutricion(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vNutricion As New FichaNutricion
                vficha.FichaNutricion = vNutricion.MapeoFichaNutricion(prmDatos.Tables(0))
                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarFichaNutricion() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFichaNutricion", conn)
            cmd.CommandType = CommandType.StoredProcedure
#Region "Ficha Nutrición"
            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = 1

            Dim inIdPsico As OleDbParameter = cmd.Parameters.Add("@id_ficha_nutri", OleDbType.Decimal, Nothing)
            inIdPsico.Direction = ParameterDirection.Input
            inIdPsico.Value = Me.FichaNutricion.Id

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaNutricion.IdEspecialista

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaNutricion.IdReserva
#End Region
#Region "Mediciones Antropometricas"
            Dim PesoActual As OleDbParameter = cmd.Parameters.Add("@ma_peso_actual", OleDbType.Decimal, Nothing)
            PesoActual.Direction = ParameterDirection.Input
            PesoActual.Value = Me.FichaNutricion.MedicionesAntropometricas.PesoActual

            Dim Talla As OleDbParameter = cmd.Parameters.Add("@ma_talla", OleDbType.Decimal, Nothing)
            Talla.Direction = ParameterDirection.Input
            Talla.Value = Me.FichaNutricion.MedicionesAntropometricas.Talla

            Dim MasaGrasaCorporal As OleDbParameter = cmd.Parameters.Add("@ma_masa_grasa_corp", OleDbType.Decimal, Nothing)
            MasaGrasaCorporal.Direction = ParameterDirection.Input
            MasaGrasaCorporal.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim MasaMagra As OleDbParameter = cmd.Parameters.Add("@ma_masa_magra", OleDbType.Decimal, Nothing)
            MasaMagra.Direction = ParameterDirection.Input
            MasaMagra.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaMagra

            Dim IndiceCinturaCadera As OleDbParameter = cmd.Parameters.Add("@ma_indice_cint", OleDbType.Decimal, Nothing)
            IndiceCinturaCadera.Direction = ParameterDirection.Input
            IndiceCinturaCadera.Value = Me.FichaNutricion.MedicionesAntropometricas.IndiceCinturaCadera

            Dim MNA As OleDbParameter = cmd.Parameters.Add("@ma_mna", OleDbType.Decimal, Nothing)
            MNA.Direction = ParameterDirection.Input
            MNA.Value = Me.FichaNutricion.MedicionesAntropometricas.MNA

            Dim PesoHabitual As OleDbParameter = cmd.Parameters.Add("@ma_peso_hab", OleDbType.Decimal, Nothing)
            PesoHabitual.Direction = ParameterDirection.Input
            PesoHabitual.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim MasaGrasaPorc As OleDbParameter = cmd.Parameters.Add("@ma_grasa_porc", OleDbType.Decimal, Nothing)
            MasaGrasaPorc.Direction = ParameterDirection.Input
            MasaGrasaPorc.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim GrasaVisceralPorc As OleDbParameter = cmd.Parameters.Add("@ma_grasa_visceral_porc", OleDbType.Decimal, Nothing)
            GrasaVisceralPorc.Direction = ParameterDirection.Input
            GrasaVisceralPorc.Value = Me.FichaNutricion.MedicionesAntropometricas.GrasaVisceralPorc

            Dim PCintura As OleDbParameter = cmd.Parameters.Add("@ma_cintura", OleDbType.Decimal, Nothing)
            PCintura.Direction = ParameterDirection.Input
            PCintura.Value = Me.FichaNutricion.MedicionesAntropometricas.PCintura

            Dim Cribaje As OleDbParameter = cmd.Parameters.Add("@ma_cribaje", OleDbType.Decimal, Nothing)
            Cribaje.Direction = ParameterDirection.Input
            Cribaje.Value = Me.FichaNutricion.MedicionesAntropometricas.Cribaje.ID
#End Region
#Region "Anamnesis Alimentaria"
            Dim Apetito As OleDbParameter = cmd.Parameters.Add("@aa_apetito", OleDbType.Decimal, Nothing)
            Apetito.Direction = ParameterDirection.Input
            Apetito.Value = Me.FichaNutricion.Apetito.ID

            Dim AlergiaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_alergia_alim", OleDbType.Decimal, Nothing)
            AlergiaAlimentaria.Direction = ParameterDirection.Input
            AlergiaAlimentaria.Value = Me.FichaNutricion.AlergiaAlimentaria.ID

            Dim PreferenciaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_prefer_alim", OleDbType.Decimal, Nothing)
            PreferenciaAlimentaria.Direction = ParameterDirection.Input
            PreferenciaAlimentaria.Value = Me.FichaNutricion.PreferenciaAlimentaria.ID

            Dim IntoleranciaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_intoler_alim", OleDbType.Decimal, Nothing)
            IntoleranciaAlimentaria.Direction = ParameterDirection.Input
            IntoleranciaAlimentaria.Value = Me.FichaNutricion.IntoleranciaAlimentaria.ID

            Dim AversionAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_aversi_alim", OleDbType.Decimal, Nothing)
            AversionAlimentaria.Direction = ParameterDirection.Input
            AversionAlimentaria.Value = Me.FichaNutricion.AversionAlimentaria.ID

            Dim ConsumoSuplemento As OleDbParameter = cmd.Parameters.Add("@aa_aversi_alim", OleDbType.Decimal, Nothing)
            ConsumoSuplemento.Direction = ParameterDirection.Input
            ConsumoSuplemento.Value = Me.FichaNutricion.ConsumoSuplemento.ID
#End Region
#Region "Ingesta Alimentaria"
            Dim DesayunoHora As OleDbParameter = cmd.Parameters.Add("@ia_desayuno_hora", OleDbType.VarChar, 500)
            DesayunoHora.Direction = ParameterDirection.Input
            DesayunoHora.Value = Me.FichaNutricion.IngestaAlimentaria.DesayunoHora

            Dim DesayunoObs As OleDbParameter = cmd.Parameters.Add("@ia_desayuno_obs", OleDbType.VarChar, 500)
            DesayunoObs.Direction = ParameterDirection.Input
            DesayunoObs.Value = Me.FichaNutricion.IngestaAlimentaria.DesayunoObs

            Dim ColacionHora As OleDbParameter = cmd.Parameters.Add("@ia_colacion_hora", OleDbType.VarChar, 500)
            ColacionHora.Direction = ParameterDirection.Input
            ColacionHora.Value = Me.FichaNutricion.IngestaAlimentaria.ColacionHora

            Dim ColacionObs As OleDbParameter = cmd.Parameters.Add("@ia_colacion_obs", OleDbType.VarChar, 500)
            ColacionObs.Direction = ParameterDirection.Input
            ColacionObs.Value = Me.FichaNutricion.IngestaAlimentaria.ColacionObs

            Dim AlmuerzoHora As OleDbParameter = cmd.Parameters.Add("@ia_almuerzo_hora", OleDbType.VarChar, 500)
            AlmuerzoHora.Direction = ParameterDirection.Input
            AlmuerzoHora.Value = Me.FichaNutricion.IngestaAlimentaria.AlmuerzoHora

            Dim AlmuerzoObs As OleDbParameter = cmd.Parameters.Add("@ia_almuerzo_obs", OleDbType.VarChar, 500)
            AlmuerzoObs.Direction = ParameterDirection.Input
            AlmuerzoObs.Value = Me.FichaNutricion.IngestaAlimentaria.AlmuerzoObs

            Dim PicoteoHora As OleDbParameter = cmd.Parameters.Add("@ia_picoteo_hora", OleDbType.VarChar, 500)
            PicoteoHora.Direction = ParameterDirection.Input
            PicoteoHora.Value = Me.FichaNutricion.IngestaAlimentaria.PicoteoHora

            Dim PicoteoObs As OleDbParameter = cmd.Parameters.Add("@ia_picoteo_obs", OleDbType.VarChar, 500)
            PicoteoObs.Direction = ParameterDirection.Input
            PicoteoObs.Value = Me.FichaNutricion.IngestaAlimentaria.PicoteoObs

            Dim OnceHora As OleDbParameter = cmd.Parameters.Add("@ia_once_hora", OleDbType.VarChar, 500)
            OnceHora.Direction = ParameterDirection.Input
            OnceHora.Value = Me.FichaNutricion.IngestaAlimentaria.OnceHora

            Dim OnceObs As OleDbParameter = cmd.Parameters.Add("@ia_once_obs", OleDbType.VarChar, 500)
            OnceObs.Direction = ParameterDirection.Input
            OnceObs.Value = Me.FichaNutricion.IngestaAlimentaria.OnceObs

            Dim CenaHora As OleDbParameter = cmd.Parameters.Add("@ia_cena_hora", OleDbType.VarChar, 500)
            CenaHora.Direction = ParameterDirection.Input
            CenaHora.Value = Me.FichaNutricion.IngestaAlimentaria.CenaHora

            Dim CenaObs As OleDbParameter = cmd.Parameters.Add("@ia_cena_obs", OleDbType.VarChar, 500)
            CenaObs.Direction = ParameterDirection.Input
            CenaObs.Value = Me.FichaNutricion.IngestaAlimentaria.CenaObs

            Dim SnackHora As OleDbParameter = cmd.Parameters.Add("@ia_snack_hora", OleDbType.VarChar, 500)
            SnackHora.Direction = ParameterDirection.Input
            SnackHora.Value = Me.FichaNutricion.IngestaAlimentaria.SnackHora

            Dim SnackObs As OleDbParameter = cmd.Parameters.Add("@ia_snack_obs", OleDbType.VarChar, 500)
            SnackObs.Direction = ParameterDirection.Input
            SnackObs.Value = Me.FichaNutricion.IngestaAlimentaria.SnackObs

            Dim DiagNutInt As OleDbParameter = cmd.Parameters.Add("@dni_obs", OleDbType.VarChar, 500)
            DiagNutInt.Direction = ParameterDirection.Input
            DiagNutInt.Value = Me.FichaNutricion.DiagNutInt

            Dim Observacion As OleDbParameter = cmd.Parameters.Add("@ia_obs", OleDbType.VarChar, 500)
            Observacion.Direction = ParameterDirection.Input
            Observacion.Value = Me.FichaNutricion.IngestaAlimentaria.Observacion
#End Region
#Region "Requerimientos Nutricionales"
            Dim GEB As OleDbParameter = cmd.Parameters.Add("@rn_geb", OleDbType.Decimal, Nothing)
            GEB.Direction = ParameterDirection.Input
            GEB.Value = Me.FichaNutricion.RequerimientosNutricionales.GEB

            Dim Energia As OleDbParameter = cmd.Parameters.Add("@rn_energia", OleDbType.Decimal, Nothing)
            Energia.Direction = ParameterDirection.Input
            Energia.Value = Me.FichaNutricion.RequerimientosNutricionales.Energia

            Dim FA As OleDbParameter = cmd.Parameters.Add("@rn_fa", OleDbType.Decimal, Nothing)
            FA.Direction = ParameterDirection.Input
            FA.Value = Me.FichaNutricion.RequerimientosNutricionales.FA

            Dim ProteinaPorc As OleDbParameter = cmd.Parameters.Add("@rn_proteina_porc", OleDbType.Decimal, Nothing)
            ProteinaPorc.Direction = ParameterDirection.Input
            ProteinaPorc.Value = Me.FichaNutricion.RequerimientosNutricionales.ProteinaPorc

            Dim LipidosPorc As OleDbParameter = cmd.Parameters.Add("@rn_lipidos_porc", OleDbType.Decimal, Nothing)
            LipidosPorc.Direction = ParameterDirection.Input
            LipidosPorc.Value = Me.FichaNutricion.RequerimientosNutricionales.LipidosPorc

            Dim AporteKCal As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_kcal", OleDbType.Decimal, Nothing)
            AporteKCal.Direction = ParameterDirection.Input
            AporteKCal.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteKCal

            Dim AporteCho As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_cho", OleDbType.Decimal, Nothing)
            AporteCho.Direction = ParameterDirection.Input
            AporteCho.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteCho

            Dim AporteLip As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_lip", OleDbType.Decimal, Nothing)
            AporteLip.Direction = ParameterDirection.Input
            AporteLip.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteLip

            Dim AporteProt As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_prot", OleDbType.Decimal, Nothing)
            AporteProt.Direction = ParameterDirection.Input
            AporteProt.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteProt
#End Region
#Region "Plan de Nutrición"
            Dim PrescripcionDietetica As OleDbParameter = cmd.Parameters.Add("@pd_obs", OleDbType.VarChar, 500)
            PrescripcionDietetica.Direction = ParameterDirection.Input
            PrescripcionDietetica.Value = Me.FichaNutricion.PrescripcionDietetica

            Dim IndicacionesGenerales As OleDbParameter = cmd.Parameters.Add("@ig_obs", OleDbType.VarChar, 500)
            IndicacionesGenerales.Direction = ParameterDirection.Input
            IndicacionesGenerales.Value = Me.FichaNutricion.IndicacionesGenerales

            Dim DiagNutInt2 As OleDbParameter = cmd.Parameters.Add("@pn_dni", OleDbType.VarChar, 500)
            DiagNutInt2.Direction = ParameterDirection.Input
            DiagNutInt2.Value = Me.FichaNutricion.DiagNutInt

            Dim ObjetivosAlimentarios As OleDbParameter = cmd.Parameters.Add("@pn_oan", OleDbType.VarChar, 500)
            ObjetivosAlimentarios.Direction = ParameterDirection.Input
            ObjetivosAlimentarios.Value = Me.FichaNutricion.ObjetivosAlimentarios

            Dim IntervencionNutricional As OleDbParameter = cmd.Parameters.Add("@pn_in", OleDbType.VarChar, 500)
            IntervencionNutricional.Direction = ParameterDirection.Input
            IntervencionNutricional.Value = Me.FichaNutricion.IntervencionNutricional
#End Region
#Region "Cuestionario"
            Dim Fruta As OleDbParameter = cmd.Parameters.Add("@frutas", OleDbType.Decimal, Nothing)
            Fruta.Direction = ParameterDirection.Input
            Fruta.Value = Me.FichaNutricion.Cuestionario.Fruta.ID

            Dim Verdura As OleDbParameter = cmd.Parameters.Add("@verduras", OleDbType.Decimal, Nothing)
            Verdura.Direction = ParameterDirection.Input
            Verdura.Value = Me.FichaNutricion.Cuestionario.Verdura.ID

            Dim Lacteo As OleDbParameter = cmd.Parameters.Add("@lacteos", OleDbType.Decimal, Nothing)
            Lacteo.Direction = ParameterDirection.Input
            Lacteo.Value = Me.FichaNutricion.Cuestionario.Lacteo.ID

            Dim Carne As OleDbParameter = cmd.Parameters.Add("@carnes", OleDbType.Decimal, Nothing)
            Carne.Direction = ParameterDirection.Input
            Carne.Value = Me.FichaNutricion.Cuestionario.Carne.ID

            Dim Azucar As OleDbParameter = cmd.Parameters.Add("@azucar", OleDbType.Decimal, Nothing)
            Azucar.Direction = ParameterDirection.Input
            Azucar.Value = Me.FichaNutricion.Cuestionario.Azucar.ID

            Dim Legumbre As OleDbParameter = cmd.Parameters.Add("@legumbres", OleDbType.Decimal, Nothing)
            Legumbre.Direction = ParameterDirection.Input
            Legumbre.Value = Me.FichaNutricion.Cuestionario.Legumbre.ID

            Dim Pescado As OleDbParameter = cmd.Parameters.Add("@pescado", OleDbType.Decimal, Nothing)
            Pescado.Direction = ParameterDirection.Input
            Pescado.Value = Me.FichaNutricion.Cuestionario.Pescado.ID

            Dim Sodio As OleDbParameter = cmd.Parameters.Add("@sodio", OleDbType.Decimal, Nothing)
            Sodio.Direction = ParameterDirection.Input
            Sodio.Value = Me.FichaNutricion.Cuestionario.Sodio.ID

            Dim Liquido As OleDbParameter = cmd.Parameters.Add("@liquidos", OleDbType.Decimal, Nothing)
            Liquido.Direction = ParameterDirection.Input
            Liquido.Value = Me.FichaNutricion.Cuestionario.Liquido.ID
#End Region
            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdNutri", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idpsico = CInt(cmd.Parameters("@outIdNutri").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
    End Class
End Namespace


