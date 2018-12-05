﻿Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Kaplan.Clases

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class doPost
    Inherits System.Web.Services.WebService
#Region "Generales"
    <WebMethod(EnableSession:=True)>
    Public Function getIngresar() As String
        Dim js As New JavaScriptSerializer

        Dim vUsuario As Usuario = js.Deserialize(Context.Request.Form("Usuario"), GetType(Usuario))
        Dim vResult As New httpResult

        Dim vResultado = vUsuario.Login()

        If vResultado = 1 Then
            vResult.result = False
            vResult.message = "Usuario incorrecto o inactivo"
        ElseIf vResultado = 2 Then
            vResult.result = False
            vResult.message = "Contraseña incorrecta"
        ElseIf vResultado = 0 Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error en llamado al procedimiento"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region

#Region "Kinesiología"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaKinesiologia() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaKinesiologia() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Psicología"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaPsicologia() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaPsicologia() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Enfermería"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaEnfermeria() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaEnfermeria() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Nutrición"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaNutricion() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaNutricion() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Médico"

#End Region

End Class