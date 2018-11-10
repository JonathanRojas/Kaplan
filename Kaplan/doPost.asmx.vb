Imports System.Web.Services
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

    <WebMethod(EnableSession:=True)>
    Public Function registrarFicha() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("ficha"), GetType(Ficha))
        Dim vResult As New httpResult

        If vFicha.registrarFicha() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function

End Class