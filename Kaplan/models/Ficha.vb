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

        Public Shared Function getFichaKinesiologia(inId As Integer, ByRef NoData As Boolean) As Ficha
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
        End Function

        Private Shared Function MapeoFichaKine(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vKinesiologia As New FichaKinesiologia
                Dim vEvolucionE As New EvolucionEgresoKine
                Dim vEvolucionI As New EvolucionIngresoKine
                Dim vPlanKinesico As New PlanKinesico

                vficha.FichaKinesiologia = vKinesiologia.MapeoFichaKine(prmDatos.Tables(0))
                vficha.FichaKinesiologia.EvolucionEgresoKine = vEvolucionE.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.EvolucionIngresoKine = vEvolucionI.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.PlanKinesico = vPlanKinesico.MapeoPlan(prmDatos.Tables(4))
                'vficha.FichaKinesiologia.PlanKinesico = vKinesiologia.EvolucionIngresoKine.Mapeo(prmDatos.Tables(2))
                'vficha.FichaKinesiologia.PlanKinesico = vKinesiologia.EvolucionIngresoKine.Mapeo(prmDatos.Tables(3))


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

            Dim inergo_vol_ing As OleDbParameter = cmd.Parameters.Add("@ergo_vol_ing", OleDbType.VarChar, 50)
            inergo_vol_ing.Direction = ParameterDirection.Input
            inergo_vol_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LIngreso

            Dim inergo_vol_egr As OleDbParameter = cmd.Parameters.Add("@ergo_vol_egr", OleDbType.VarChar, 50)
            inergo_vol_egr.Direction = ParameterDirection.Input
            inergo_vol_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LEgreso

            Dim inergo_voml_ing As OleDbParameter = cmd.Parameters.Add("@ergo_voml_ing", OleDbType.VarChar, 50)
            inergo_voml_ing.Direction = ParameterDirection.Input
            inergo_voml_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MIngreso

            Dim inergo_voml_egr As OleDbParameter = cmd.Parameters.Add("@ergo_voml_egr", OleDbType.VarChar, 50)
            inergo_voml_egr.Direction = ParameterDirection.Input
            inergo_voml_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MEgreso

            Dim inergo_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_ing", OleDbType.VarChar, 50)
            inergo_fcmax_ing.Direction = ParameterDirection.Input
            inergo_fcmax_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCIngreso

            Dim inergo_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_egr", OleDbType.VarChar, 50)
            inergo_fcmax_egr.Direction = ParameterDirection.Input
            inergo_fcmax_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCEgreso

            Dim inergo_pulso_ing As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_ing", OleDbType.VarChar, 50)
            inergo_pulso_ing.Direction = ParameterDirection.Input
            inergo_pulso_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoIngreso

            Dim inergo_pulso_egr As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_egr", OleDbType.VarChar, 50)
            inergo_pulso_egr.Direction = ParameterDirection.Input
            inergo_pulso_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoEgreso

            Dim inergo_ve_ing As OleDbParameter = cmd.Parameters.Add("@ergo_ve_ing", OleDbType.VarChar, 50)
            inergo_ve_ing.Direction = ParameterDirection.Input
            inergo_ve_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEIngreso

            Dim inergo_ve_egr As OleDbParameter = cmd.Parameters.Add("@ergo_ve_egr", OleDbType.VarChar, 50)
            inergo_ve_egr.Direction = ParameterDirection.Input
            inergo_ve_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEEgreso

            Dim inergo_mets_ing As OleDbParameter = cmd.Parameters.Add("@ergo_mets_ing", OleDbType.VarChar, 50)
            inergo_mets_ing.Direction = ParameterDirection.Input
            inergo_mets_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSIngreso

            Dim inergo_mets_egr As OleDbParameter = cmd.Parameters.Add("@ergo_mets_egr", OleDbType.VarChar, 50)
            inergo_mets_egr.Direction = ParameterDirection.Input
            inergo_mets_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSEgreso

            Dim inshu_fecha_ing As OleDbParameter = cmd.Parameters.Add("@shu_fecha_ing", OleDbType.Date, Nothing)
            inshu_fecha_ing.Direction = ParameterDirection.Input
            inshu_fecha_ing.Value = Me.FichaKinesiologia.SHUTTLE.EFechaIngreso

            Dim inshu_fecha_egr As OleDbParameter = cmd.Parameters.Add("@shu_fecha_egr", OleDbType.Date, Nothing)
            inshu_fecha_egr.Direction = ParameterDirection.Input
            inshu_fecha_egr.Value = Me.FichaKinesiologia.SHUTTLE.EFechaEgreso

            Dim inshu_mts_ing As OleDbParameter = cmd.Parameters.Add("@shu_mts_ing", OleDbType.VarChar, 50)
            inshu_mts_ing.Direction = ParameterDirection.Input
            inshu_mts_ing.Value = Me.FichaKinesiologia.SHUTTLE.METROSIngreso

            Dim inshu_mts_egr As OleDbParameter = cmd.Parameters.Add("@shu_mts_egr", OleDbType.VarChar, 50)
            inshu_mts_egr.Direction = ParameterDirection.Input
            inshu_mts_egr.Value = Me.FichaKinesiologia.SHUTTLE.METROSEgreso

            Dim inshu_niv_ing As OleDbParameter = cmd.Parameters.Add("@shu_niv_ing", OleDbType.VarChar, 50)
            inshu_niv_ing.Direction = ParameterDirection.Input
            inshu_niv_ing.Value = Me.FichaKinesiologia.SHUTTLE.NIVELIngreso

            Dim inshu_niv_egr As OleDbParameter = cmd.Parameters.Add("@shu_niv_egr", OleDbType.VarChar, 50)
            inshu_niv_egr.Direction = ParameterDirection.Input
            inshu_niv_egr.Value = Me.FichaKinesiologia.SHUTTLE.NIVELEgreso

            Dim inshu_vol_ing As OleDbParameter = cmd.Parameters.Add("@shu_vol_ing", OleDbType.VarChar, 50)
            inshu_vol_ing.Direction = ParameterDirection.Input
            inshu_vol_ing.Value = Me.FichaKinesiologia.SHUTTLE.VO2MIngreso

            Dim inshu_vol_egr As OleDbParameter = cmd.Parameters.Add("@shu_vol_egr", OleDbType.VarChar, 50)
            inshu_vol_egr.Direction = ParameterDirection.Input
            inshu_vol_egr.Value = Me.FichaKinesiologia.SHUTTLE.VO2MEgreso

            Dim inshu_mets_ing As OleDbParameter = cmd.Parameters.Add("@shu_mets_ing", OleDbType.VarChar, 50)
            inshu_mets_ing.Direction = ParameterDirection.Input
            inshu_mets_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSIngreso

            Dim inshu_mets_egr As OleDbParameter = cmd.Parameters.Add("@shu_mets_egr", OleDbType.VarChar, 50)
            inshu_mets_egr.Direction = ParameterDirection.Input
            inshu_mets_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSEgreso

            Dim inshu_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_ing", OleDbType.VarChar, 50)
            inshu_fcmax_ing.Direction = ParameterDirection.Input
            inshu_fcmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCIngreso

            Dim inshu_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_egr", OleDbType.VarChar, 50)
            inshu_fcmax_egr.Direction = ParameterDirection.Input
            inshu_fcmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCEgreso

            Dim inshu_fcmt_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_ing", OleDbType.VarChar, 50)
            inshu_fcmt_ing.Direction = ParameterDirection.Input
            inshu_fcmt_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCMTIngreso

            Dim inshu_fcmt_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_egr", OleDbType.VarChar, 50)
            inshu_fcmt_egr.Direction = ParameterDirection.Input
            inshu_fcmt_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCMTEgreso

            Dim inshu_metsmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_ing", OleDbType.VarChar, 50)
            inshu_metsmax_ing.Direction = ParameterDirection.Input
            inshu_metsmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXIngreso

            Dim inshu_metsmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_egr", OleDbType.VarChar, 50)
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

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, 5000)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONDiagnostico(Me.FichaKinesiologia.PlanKinesico.Diagnostico)

            Dim inobjetivo As OleDbParameter = cmd.Parameters.Add("@objetivo", OleDbType.VarChar, 5000)
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

    End Class
End Namespace
