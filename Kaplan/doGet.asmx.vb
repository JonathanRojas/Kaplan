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
    Public Function getFichas() As String
        Dim vFichas As List(Of Ficha) = Ficha.getFichas()
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vFichas) Then
            vResult.result = True
            vResult.data = vFichas
        Else
            vResult.result = False
            vResult.message = "Error recuperando lista fichas"
        End If
        js.MaxJsonLength = Int32.MaxValue
        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getFicha(inId As Integer) As String
        Dim vFicha As Ficha = Ficha.getFicha(inId)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vFicha) Then
            vResult.result = True
            vResult.data = vFicha
        Else
            vResult.result = False
            vResult.data = vFicha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function getTipoSexo() As String
        Dim vTipos As List(Of TipoSexo) = TipoSexo.getTipos
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
    Public Function getTipoEstadoCivil() As String
        Dim vTipos As List(Of TipoEstadoCivil) = TipoEstadoCivil.getTipos
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

End Class