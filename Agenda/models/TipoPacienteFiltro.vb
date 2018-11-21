Imports Agenda.Clases
Namespace Tipos

    Public Class TipoPacienteFiltro
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoPacienteFiltro)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoPacienteFiltro)
        Shared Sub New()
            CachedTipo.DataPackage = "[ListarPacientesFiltro]"
        End Sub
        Shared Function getTipos() As List(Of TipoPacienteFiltro)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoPacienteFiltro
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
