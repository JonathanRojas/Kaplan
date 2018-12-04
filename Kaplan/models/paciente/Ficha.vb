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
            Dim cmd As OleDbCommand = New OleDbCommand("RegistrarFichaKinesiologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = 1

            Dim inIdKine As OleDbParameter = cmd.Parameters.Add("@id_ficha_kine", OleDbType.Decimal, Nothing)
            inIdKine.Direction = ParameterDirection.Input
            inIdKine.Value = Me.FichaEnfermeria.Id

            'Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            'inid_reserva.Direction = ParameterDirection.Input
            'inid_reserva.Value = Me.FichaEnfermeria.IdReserva

            'Dim inRiesgo As OleDbParameter = cmd.Parameters.Add("@riesgo", OleDbType.VarChar, 500)
            'inRiesgo.Direction = ParameterDirection.Input
            'inRiesgo.Value = Me.FichaEnfermeria.Riesgo

            'Dim inTipoEvaluacion As OleDbParameter = cmd.Parameters.Add("@TipoEvaluacion", OleDbType.VarChar, 500)
            'inTipoEvaluacion.Direction = ParameterDirection.Input
            'inTipoEvaluacion.Value = Me.FichaKinesiologia.TipoEvaluacion

            'Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            'inIdEspecialista.Direction = ParameterDirection.Input
            'inIdEspecialista.Value = Me.FichaKinesiologia.IdEspecialista

            'Dim inErgo_fecha_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_ing", OleDbType.Date, Nothing)
            'inErgo_fecha_ing.Direction = ParameterDirection.Input
            'inErgo_fecha_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso

            'Dim inErgo_fecha_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_egr", OleDbType.Date, Nothing)
            'inErgo_fecha_egr.Direction = ParameterDirection.Input
            'inErgo_fecha_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso

            'Dim inergo_vol_ing As OleDbParameter = cmd.Parameters.Add("@ergo_vol_ing", OleDbType.Decimal, Nothing)
            'inergo_vol_ing.Direction = ParameterDirection.Input
            'inergo_vol_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LIngreso

            'Dim inergo_vol_egr As OleDbParameter = cmd.Parameters.Add("@ergo_vol_egr", OleDbType.Decimal, Nothing)
            'inergo_vol_egr.Direction = ParameterDirection.Input
            'inergo_vol_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LEgreso

            'Dim inergo_voml_ing As OleDbParameter = cmd.Parameters.Add("@ergo_voml_ing", OleDbType.Decimal, Nothing)
            'inergo_voml_ing.Direction = ParameterDirection.Input
            'inergo_voml_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MIngreso

            'Dim inergo_voml_egr As OleDbParameter = cmd.Parameters.Add("@ergo_voml_egr", OleDbType.Decimal, Nothing)
            'inergo_voml_egr.Direction = ParameterDirection.Input
            'inergo_voml_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MEgreso

            'Dim inergo_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_ing", OleDbType.Decimal, Nothing)
            'inergo_fcmax_ing.Direction = ParameterDirection.Input
            'inergo_fcmax_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCIngreso

            'Dim inergo_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_egr", OleDbType.Decimal, Nothing)
            'inergo_fcmax_egr.Direction = ParameterDirection.Input
            'inergo_fcmax_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCEgreso

            'Dim inergo_pulso_ing As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_ing", OleDbType.Decimal, Nothing)
            'inergo_pulso_ing.Direction = ParameterDirection.Input
            'inergo_pulso_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoIngreso

            'Dim inergo_pulso_egr As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_egr", OleDbType.Decimal, Nothing)
            'inergo_pulso_egr.Direction = ParameterDirection.Input
            'inergo_pulso_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoEgreso

            'Dim inergo_ve_ing As OleDbParameter = cmd.Parameters.Add("@ergo_ve_ing", OleDbType.Decimal, Nothing)
            'inergo_ve_ing.Direction = ParameterDirection.Input
            'inergo_ve_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEIngreso

            'Dim inergo_ve_egr As OleDbParameter = cmd.Parameters.Add("@ergo_ve_egr", OleDbType.Decimal, Nothing)
            'inergo_ve_egr.Direction = ParameterDirection.Input
            'inergo_ve_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEEgreso

            'Dim inergo_mets_ing As OleDbParameter = cmd.Parameters.Add("@ergo_mets_ing", OleDbType.Decimal, Nothing)
            'inergo_mets_ing.Direction = ParameterDirection.Input
            'inergo_mets_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSIngreso

            'Dim inergo_mets_egr As OleDbParameter = cmd.Parameters.Add("@ergo_mets_egr", OleDbType.Decimal, Nothing)
            'inergo_mets_egr.Direction = ParameterDirection.Input
            'inergo_mets_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSEgreso

            'Dim inshu_fecha_ing As OleDbParameter = cmd.Parameters.Add("@shu_fecha_ing", OleDbType.Date, Nothing)
            'inshu_fecha_ing.Direction = ParameterDirection.Input
            'inshu_fecha_ing.Value = Me.FichaKinesiologia.SHUTTLE.EFechaIngreso

            'Dim inshu_fecha_egr As OleDbParameter = cmd.Parameters.Add("@shu_fecha_egr", OleDbType.Date, Nothing)
            'inshu_fecha_egr.Direction = ParameterDirection.Input
            'inshu_fecha_egr.Value = Me.FichaKinesiologia.SHUTTLE.EFechaEgreso

            'Dim inshu_mts_ing As OleDbParameter = cmd.Parameters.Add("@shu_mts_ing", OleDbType.Decimal, Nothing)
            'inshu_mts_ing.Direction = ParameterDirection.Input
            'inshu_mts_ing.Value = Me.FichaKinesiologia.SHUTTLE.METROSIngreso

            'Dim inshu_mts_egr As OleDbParameter = cmd.Parameters.Add("@shu_mts_egr", OleDbType.Decimal, Nothing)
            'inshu_mts_egr.Direction = ParameterDirection.Input
            'inshu_mts_egr.Value = Me.FichaKinesiologia.SHUTTLE.METROSEgreso

            'Dim inshu_niv_ing As OleDbParameter = cmd.Parameters.Add("@shu_niv_ing", OleDbType.Decimal, Nothing)
            'inshu_niv_ing.Direction = ParameterDirection.Input
            'inshu_niv_ing.Value = Me.FichaKinesiologia.SHUTTLE.NIVELIngreso

            'Dim inshu_niv_egr As OleDbParameter = cmd.Parameters.Add("@shu_niv_egr", OleDbType.Decimal, Nothing)
            'inshu_niv_egr.Direction = ParameterDirection.Input
            'inshu_niv_egr.Value = Me.FichaKinesiologia.SHUTTLE.NIVELEgreso

            'Dim inshu_vol_ing As OleDbParameter = cmd.Parameters.Add("@shu_vol_ing", OleDbType.Decimal, Nothing)
            'inshu_vol_ing.Direction = ParameterDirection.Input
            'inshu_vol_ing.Value = Me.FichaKinesiologia.SHUTTLE.VO2MIngreso

            'Dim inshu_vol_egr As OleDbParameter = cmd.Parameters.Add("@shu_vol_egr", OleDbType.Decimal, Nothing)
            'inshu_vol_egr.Direction = ParameterDirection.Input
            'inshu_vol_egr.Value = Me.FichaKinesiologia.SHUTTLE.VO2MEgreso

            'Dim inshu_mets_ing As OleDbParameter = cmd.Parameters.Add("@shu_mets_ing", OleDbType.Decimal, Nothing)
            'inshu_mets_ing.Direction = ParameterDirection.Input
            'inshu_mets_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSIngreso

            'Dim inshu_mets_egr As OleDbParameter = cmd.Parameters.Add("@shu_mets_egr", OleDbType.Decimal, Nothing)
            'inshu_mets_egr.Direction = ParameterDirection.Input
            'inshu_mets_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSEgreso

            'Dim inshu_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_ing", OleDbType.Decimal, Nothing)
            'inshu_fcmax_ing.Direction = ParameterDirection.Input
            'inshu_fcmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCIngreso

            'Dim inshu_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_egr", OleDbType.Decimal, Nothing)
            'inshu_fcmax_egr.Direction = ParameterDirection.Input
            'inshu_fcmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCEgreso

            'Dim inshu_fcmt_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_ing", OleDbType.Decimal, Nothing)
            'inshu_fcmt_ing.Direction = ParameterDirection.Input
            'inshu_fcmt_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCMTIngreso

            'Dim inshu_fcmt_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_egr", OleDbType.Decimal, Nothing)
            'inshu_fcmt_egr.Direction = ParameterDirection.Input
            'inshu_fcmt_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCMTEgreso

            'Dim inshu_metsmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_ing", OleDbType.Decimal, Nothing)
            'inshu_metsmax_ing.Direction = ParameterDirection.Input
            'inshu_metsmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXIngreso

            'Dim inshu_metsmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_egr", OleDbType.Decimal, Nothing)
            'inshu_metsmax_egr.Direction = ParameterDirection.Input
            'inshu_metsmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXEgreso

            'Dim inid_evolucion_1 As OleDbParameter = cmd.Parameters.Add("@Diagnostico", OleDbType.Decimal, Nothing)
            'inid_evolucion_1.Direction = ParameterDirection.Input
            'inid_evolucion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Id

            'Dim inevolucion_fecha_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_1", OleDbType.Date, Nothing)
            'inevolucion_fecha_1.Direction = ParameterDirection.Input
            'inevolucion_fecha_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Fecha

            'Dim inevolucion_eva_mus_esq_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_1", OleDbType.VarChar, 500)
            'inevolucion_eva_mus_esq_1.Direction = ParameterDirection.Input
            'inevolucion_eva_mus_esq_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.EME

            'Dim inevolcuion_observacion_1 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_1", OleDbType.VarChar, 500)
            'inevolcuion_observacion_1.Direction = ParameterDirection.Input
            'inevolcuion_observacion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Observacion

            'Dim inid_evolucion_2 As OleDbParameter = cmd.Parameters.Add("@id_evolucion_2", OleDbType.Decimal, Nothing)
            'inid_evolucion_2.Direction = ParameterDirection.Input
            'inid_evolucion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Id

            'Dim inevolucion_fecha_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_2", OleDbType.Date, Nothing)
            'inevolucion_fecha_2.Direction = ParameterDirection.Input
            'inevolucion_fecha_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Fecha

            'Dim inevolucion_eva_mus_esq_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_2", OleDbType.VarChar, 500)
            'inevolucion_eva_mus_esq_2.Direction = ParameterDirection.Input
            'inevolucion_eva_mus_esq_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.EME

            'Dim inevolcuion_observacion_2 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_2", OleDbType.VarChar, 500)
            'inevolcuion_observacion_2.Direction = ParameterDirection.Input
            'inevolcuion_observacion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Observacion

            'Dim inidPlan_kine As OleDbParameter = cmd.Parameters.Add("@v_idPlan_kine", OleDbType.Decimal, Nothing)
            'inidPlan_kine.Direction = ParameterDirection.Input
            'inidPlan_kine.Value = Me.FichaKinesiologia.PlanKinesico.Id

            'Dim ineje_aerobico As OleDbParameter = cmd.Parameters.Add("@eje_aerobico", OleDbType.VarChar, 500)
            'ineje_aerobico.Direction = ParameterDirection.Input
            'ineje_aerobico.Value = Me.FichaKinesiologia.PlanKinesico.AEROBICO

            'Dim ineje_sobrecarga As OleDbParameter = cmd.Parameters.Add("@eje_sobrecarga", OleDbType.VarChar, 500)
            'ineje_sobrecarga.Direction = ParameterDirection.Input
            'ineje_sobrecarga.Value = Me.FichaKinesiologia.PlanKinesico.SOBRECARGA

            'Dim inentre_funcional As OleDbParameter = cmd.Parameters.Add("@entre_funcional", OleDbType.VarChar, 500)
            'inentre_funcional.Direction = ParameterDirection.Input
            'inentre_funcional.Value = Me.FichaKinesiologia.PlanKinesico.FUNCIONAL

            'Dim inedu_habitos_cardio As OleDbParameter = cmd.Parameters.Add("@edu_habitos_cardio", OleDbType.VarChar, 500)
            'inedu_habitos_cardio.Direction = ParameterDirection.Input
            'inedu_habitos_cardio.Value = Me.FichaKinesiologia.PlanKinesico.EDUCACION

            'Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, -1)
            'indiagnostico.Direction = ParameterDirection.Input
            'indiagnostico.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONDiagnostico(Me.FichaKinesiologia.PlanKinesico.Diagnostico)

            'Dim inobjetivo As OleDbParameter = cmd.Parameters.Add("@objetivo", OleDbType.VarChar, -1)
            'inobjetivo.Direction = ParameterDirection.Input
            'inobjetivo.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONObjetivo(Me.FichaKinesiologia.PlanKinesico.Objetivo)

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

    End Class
End Namespace


