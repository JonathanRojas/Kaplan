Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Kaplan.Clases
Imports Kaplan.Tipos

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class doGet
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    Public Function getLogin(strUser As String) As String
        Dim NoData As Boolean
        Dim vUsuario As Usuario = Usuario.getUsuario(strUser)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vUsuario) Then
            vResult.result = True
            vResult.data = vUsuario
        Else
            vResult.result = False
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

    '#Region "Tipos"
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoSexo() As String
    '        Dim vTipos As List(Of TipoSexo) = TipoSexo.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoEstadoCivil() As String
    '        Dim vTipos As List(Of TipoEstadoCivil) = TipoEstadoCivil.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoRegion() As String
    '        Dim vTipos As List(Of TipoRegion) = TipoRegion.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoComuna() As String
    '        Dim vTipos As List(Of TipoComuna) = TipoComuna.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoPais() As String
    '        Dim vTipos As List(Of TipoPais) = TipoPais.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoPrevision() As String
    '        Dim vTipos As List(Of TipoPrevision) = TipoPrevision.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoEspecialidad() As String
    '        Dim vTipos As List(Of TipoEspecialidad) = TipoEspecialidad.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoDias() As String
    '        Dim vTipos As List(Of TipoDia) = TipoDia.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoHoras() As String
    '        Dim vTipos As List(Of TipoHora) = TipoHora.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoAnulada() As String
    '        Dim vTipos As List(Of TipoAnulada) = TipoAnulada.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoNoRealizada() As String
    '        Dim vTipos As List(Of TipoNoRealizada) = TipoNoRealizada.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoMotivoPlan() As String
    '        Dim vTipos As List(Of TipoMotivoPlan) = TipoMotivoPlan.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoEstadoReserva() As String
    '        Dim vTipos As List(Of TipoEstadoReserva) = TipoEstadoReserva.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoEstadoPlan() As String
    '        Dim vTipos As List(Of TipoEstadoPlan) = TipoEstadoPlan.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '    <WebMethod(EnableSession:=True)>
    '    Public Function getTipoReserva() As String
    '        Dim vTipos As List(Of TipoReserva) = TipoReserva.getTipos
    '        Dim js As New JavaScriptSerializer
    '        Dim vResult As New httpResult
    '        If Not IsNothing(vTipos) Then
    '            vResult.result = True
    '            vResult.data = vTipos
    '        Else
    '            vResult.result = False
    '            vResult.data = vTipos
    '        End If

    '        Context.Response.Write(js.Serialize(vResult))

    '        Context.Response.End()
    '        Return ""
    '    End Function
    '#End Region

End Class