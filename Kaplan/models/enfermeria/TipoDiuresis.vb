﻿Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDiuresis
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDiuresis)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDiuresis)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEDiuresis"
        End Sub
        Shared Function getTipos() As List(Of TipoDiuresis)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDiuresis
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace