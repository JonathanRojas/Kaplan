Imports Newtonsoft.Json
Namespace Clases
    Public Class CollectionssDiagnosticos
        Public Property column As PlanEnfermeriaDiagnostico()
    End Class
    Public Class CollectionssIntervencion
        Public Property column As PlanEnfermeriaIntervencion()
    End Class
    Public Class CollectionssIndicador
        Public Property column As PlanEnfermeriaIndicador()
    End Class
    Public Class PlanEnfermeria
        Public Property Id As Integer
        Public Property AdeherenciaFarma As Tipos.TipoAdherenciaFarma
        Public Property Respiracion As Tipos.TipoValoracion
        Public Property Alimentacion As Tipos.TipoValoracion
        Public Property Eliminacion As Tipos.TipoValoracion
        Public Property Descanso As Tipos.TipoValoracion
        Public Property HigienePiel As Tipos.TipoValoracion
        Public Property Actividades As Tipos.TipoValoracion
        Public Property Vestirse As Tipos.TipoValoracion
        Public Property Comunicarse As Tipos.TipoValoracion
        Public Property AutoRealizacion As Tipos.TipoValoracion
        Public Property RespiracionObservacion As String
        Public Property AlimentacionObservacion As String
        Public Property EliminacionObservacion As String
        Public Property DescansoObservacion As String
        Public Property HigienePielObservacion As String
        Public Property ActividadesObservacion As String
        Public Property VestirseObservacion As String
        Public Property ComunicarseObservacion As String
        Public Property AutoRealizacionObservacion As String
        Public Property Objetivo As String
        Public Property Diagnostico As List(Of PlanEnfermeriaDiagnostico)
        Public Property Intervencion As List(Of PlanEnfermeriaIntervencion)
        Public Property Indicadores As List(Of PlanEnfermeriaIndicador)

        Public Function ToJSONDiagnosticos(rows As List(Of PlanEnfermeriaDiagnostico)) As String
            Dim data As New CollectionssDiagnosticos

            data = New CollectionssDiagnosticos With {.column = rows.ToArray}
            ToJSONDiagnosticos = JsonConvert.SerializeObject(data)
            Return ToJSONDiagnosticos
        End Function
        Public Function ToJSONIntervencion(rows As List(Of PlanEnfermeriaIntervencion)) As String
            Dim data As New CollectionssIntervencion

            data = New CollectionssIntervencion With {.column = rows.ToArray}
            ToJSONIntervencion = JsonConvert.SerializeObject(data)
            Return ToJSONIntervencion
        End Function
        Public Function ToJSONIndicador(rows As List(Of PlanEnfermeriaIndicador)) As String
            Dim data As New CollectionssIndicador

            data = New CollectionssIndicador With {.column = rows.ToArray}
            ToJSONIndicador = JsonConvert.SerializeObject(data)
            Return ToJSONIndicador
        End Function

    End Class
End Namespace
