﻿Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoRespuestaMedico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoRespuestaMedico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoRespuestaMedico)
        Shared Sub New()
            CachedTipo.DataPackage = "ListarTipoRespuesta"
        End Sub
        Shared Function getTipos() As List(Of TipoRespuestaMedico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoRespuestaMedico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
