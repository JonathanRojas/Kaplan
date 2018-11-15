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

    <WebMethod(EnableSession:=True)>
    Public Function getPaciente(intRut As Integer, strPasaporte As String) As String
        Dim NoData As Boolean
        Dim vPaciente As Paciente = Paciente.getPaciente(intRut, strPasaporte, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vPaciente) Then
            vResult.result = True
            vResult.data = vPaciente
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vPaciente
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function getPlanesxRut(intRut As Integer) As String
        Dim vPlan As List(Of Plan) = Plan.getPlanesxRut(intRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vPlan) Then
            vResult.result = True
            vResult.data = vPlan
        Else
            vResult.result = False
            vResult.data = vPlan
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

#Region "Tipos"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoObjetivoKine() As String
        Dim vTipos As List(Of TipoObjetivoKine) = TipoObjetivoKine.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoDiagnosticoKine() As String
        Dim vTipos As List(Of TipoDiagnosticoKine) = TipoDiagnosticoKine.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoRegion() As String
        Dim vTipos As List(Of TipoRegion) = TipoRegion.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoComuna() As String
        Dim vTipos As List(Of TipoComuna) = TipoComuna.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

#End Region

End Class