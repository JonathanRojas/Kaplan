﻿Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoObjetivoKine
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoObjetivoKine)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoObjetivoKine)
        Shared Sub New()
            CachedTipo.DataPackage = "ListarTipoObjetivoKine"
        End Sub
        Shared Function getTipos() As List(Of TipoObjetivoKine)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoObjetivoKine
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace