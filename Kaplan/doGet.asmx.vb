Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Kaplan.Clases
Imports Kaplan.Tipos

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class doGet
    Inherits System.Web.Services.WebService
#Region "Generales"
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
    <WebMethod(EnableSession:=True)>
    Public Function getSesionesxPlan(intPlan As Integer, intEspecialidad As Integer) As String
        Dim vSesiones As List(Of Sesion) = Sesion.getSesionxPlan(intPlan, intEspecialidad)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vSesiones) Then
            vResult.result = True
            vResult.data = vSesiones
        Else
            vResult.result = False
            vResult.data = vSesiones
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region

#Region "Kinesiología"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaKinesiologiasxReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaKinesiologia(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region

#Region "Psicología"

#End Region
#Region "Enfermería"

#End Region
#Region "Nutrición"

#End Region
#Region "Médico"

#End Region
#Region "Tipos"
#Region "Tipos Antecedentes"
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
#Region "Tipos Kinesiología"
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
#End Region
#Region "Tipos Psicología"
    '<WebMethod(EnableSession:=True)>
    'Public Function getTipoSintomalogia() As String
    '    Dim vTipos As List(Of TipoSintomalogia) = TipoSintomalogia.getTipos
    '    Dim js As New JavaScriptSerializer
    '    Dim vResult As New httpResult
    '    If Not IsNothing(vTipos) Then
    '        vResult.result = True
    '        vResult.data = vTipos
    '    Else
    '        vResult.result = False
    '        vResult.data = vTipos
    '    End If

    '    Context.Response.Write(js.Serialize(vResult))

    '    Context.Response.End()
    '    Return ""
    'End Function
#End Region
#Region "Tipos Enfermería"
#End Region
#Region "Tipos Nutrición"
#End Region
#Region "Tipos Médico"
#End Region
#End Region

End Class