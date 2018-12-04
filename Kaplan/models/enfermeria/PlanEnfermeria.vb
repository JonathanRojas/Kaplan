Namespace Clases
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
    End Class
End Namespace
