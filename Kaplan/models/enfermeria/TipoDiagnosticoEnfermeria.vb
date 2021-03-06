﻿Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDiagnosticoEnfermeria
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDiagnosticoEnfermeria)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDiagnosticoEnfermeria)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEDiagnostico"
        End Sub
        Shared Function getTipos() As List(Of TipoDiagnosticoEnfermeria)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDiagnosticoEnfermeria
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace