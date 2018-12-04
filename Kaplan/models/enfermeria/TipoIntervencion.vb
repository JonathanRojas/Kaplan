﻿Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoIntervencion
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoIntervencion)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoIntervencion)
        Shared Sub New()
            CachedTipo.DataPackage = "ListarTipoFEIntervencion"
        End Sub
        Shared Function getTipos() As List(Of TipoIntervencion)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoIntervencion
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace