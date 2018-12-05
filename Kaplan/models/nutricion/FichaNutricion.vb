Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class FichaNutricion
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property Diagnostico As String
        Public Property CxProced As String
        Public Property DiagNutInt As String
        Public Property MedicionesAntropometricas As MedicionesAntropometricas
        Public Property IngestaAlimentaria As IngestaAlimentaria
        Public Property Sedentario As Tipos.TipoSED
        Public Property Estres As Tipos.TipoEstres
        Public Property Tabaco As Tipos.TipoTB
        Public Property HTA As Tipos.TipoHTA
        Public Property DM As Tipos.TipoDM
        Public Property DLP As Tipos.TipoDLP
        Public Property SBOB As Tipos.TipoSPOB
        Public Property OH As Tipos.TipoOH
        Public Property Apetito As Tipos.TipoApetito
        Public Property AlergiaAlimentaria As Tipos.TipoAlergiaAlimentaria
        Public Property PreferenciaAlimentaria As Tipos.TipoPreferenciaAlimentaria
        Public Property IntoleranciaAlimentaria As Tipos.TipoIntolerenciaAlimentaria
        Public Property AversionAlimentaria As Tipos.TipoAversionAlimentaria
        Public Property ConsumoSuplemento As Tipos.TipoSuplemento

        Public Shared Function MapeoFichaNutricion(prmDatos As DataTable) As FichaNutricion
            Try
                Dim vNutricion As New FichaNutricion

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vNutricion.Id = prmRow("id_ficha_nutri")
                vNutricion.IdReserva = prmRow("id_reserva")
                vNutricion.IdEspecialista = prmRow("id_especialista")
                vNutricion.Diagnostico = prmRow("diagnostico").ToString
                vNutricion.CxProced = prmRow("cx_proced").ToString
                vNutricion.DiagNutInt = prmRow("dni_obs").ToString
                vNutricion.Sedentario = Tipos.TipoSED.getTipo(prmRow("Sedentario"))
                vNutricion.Estres = Tipos.TipoEstres.getTipo(prmRow("Estres"))
                vNutricion.Tabaco = Tipos.TipoTB.getTipo(prmRow("Tabaco"))
                vNutricion.HTA = Tipos.TipoHTA.getTipo(prmRow("HTA"))
                vNutricion.DM = Tipos.TipoDM.getTipo(prmRow("DM"))
                vNutricion.DLP = Tipos.TipoDLP.getTipo(prmRow("DLP"))
                vNutricion.SBOB = Tipos.TipoSPOB.getTipo(prmRow("SBOB"))
                vNutricion.OH = Tipos.TipoOH.getTipo(prmRow("OH"))
                vNutricion.Apetito = Tipos.TipoApetito.getTipo(prmRow("Apetito"))
                vNutricion.AlergiaAlimentaria = Tipos.TipoAlergiaAlimentaria.getTipo(prmRow("AlergiaAlimentaria"))
                vNutricion.PreferenciaAlimentaria = Tipos.TipoPreferenciaAlimentaria.getTipo(prmRow("PreferenciaAlimentaria"))
                vNutricion.IntoleranciaAlimentaria = Tipos.TipoIntolerenciaAlimentaria.getTipo(prmRow("IntoleranciaAlimentaria"))
                vNutricion.AversionAlimentaria = Tipos.TipoAversionAlimentaria.getTipo(prmRow("AversionAlimentaria"))
                vNutricion.ConsumoSuplemento = Tipos.TipoSuplemento.getTipo(prmRow("ConsumoSuplemento"))

                Dim vMedicionesAntropometricas As New MedicionesAntropometricas
                vMedicionesAntropometricas.PesoActual = prmRow("Peso_Actual")
                vMedicionesAntropometricas.Talla = prmRow("Talla")
                vMedicionesAntropometricas.PesoActual = prmRow("Peso_Actual")
                vMedicionesAntropometricas.Talla = Math.Round(prmRow("Talla"), 2)
                vMedicionesAntropometricas.IMC = Math.Round(prmRow("Peso_Actual") / Math.Pow(prmRow("Talla"), 2), 1)
                If vMedicionesAntropometricas.IMC > 25 Then
                    vMedicionesAntropometricas.EstadoIMC = "Sobrepeso"
                ElseIf vMedicionesAntropometricas.IMC > 18.5 Then
                    vMedicionesAntropometricas.EstadoIMC = "Normal"
                ElseIf vMedicionesAntropometricas.IMC < 18.5 Then
                    vMedicionesAntropometricas.EstadoIMC = "Desnutrido"
                Else
                    vMedicionesAntropometricas.EstadoIMC = ""
                End If
                vMedicionesAntropometricas.PesoHabitual = prmRow("Peso_Habitual")
                vMedicionesAntropometricas.PesoMinimo = Math.Round(Math.Pow(prmRow("Talla"), 2) * 18.5, 2)
                vMedicionesAntropometricas.PesoMaximo = Math.Round(Math.Pow(prmRow("Talla"), 2) * 24.9, 2)
                vMedicionesAntropometricas.PesoIdeal = Math.Round(Math.Pow(prmRow("Talla"), 2) * 21.7, 2)
                vMedicionesAntropometricas.PesoMinimoMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 23.1, 2)
                vMedicionesAntropometricas.PesoMaximoMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 27.9, 2)
                vMedicionesAntropometricas.PesoIdealMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 25.5, 2)
                If vMedicionesAntropometricas.IMC > 31 Then
                    vMedicionesAntropometricas.EstadoIMC = "Obesidad"
                ElseIf vMedicionesAntropometricas.EstadoIMCAM > 27.9 Then
                    vMedicionesAntropometricas.EstadoIMC = "Sobrepeso"
                ElseIf vMedicionesAntropometricas.IMC > 23.1 Then
                    vMedicionesAntropometricas.EstadoIMCAM = "Normal"
                ElseIf vMedicionesAntropometricas.IMC < 23.1 Then
                    vMedicionesAntropometricas.EstadoIMCAM = "Bajopeso"
                Else
                    vMedicionesAntropometricas.EstadoIMCAM = ""
                End If
                vMedicionesAntropometricas.MasaGrasaCorporal = prmRow("masa_grasa_corp")
                vMedicionesAntropometricas.MasaMagra = prmRow("masa_magra")
                vMedicionesAntropometricas.IndiceCinturaCadera = prmRow("indice_cintura")
                vMedicionesAntropometricas.MNA = prmRow("mna")
                vMedicionesAntropometricas.MasaGrasaPorc = prmRow("masa_grasa_porc")
                vMedicionesAntropometricas.GrasaVisceralPorc = prmRow("grasa_visc_porc")
                vMedicionesAntropometricas.PCintura = prmRow("cintura")
                vMedicionesAntropometricas.Cribaje = Tipos.TipoCribaje.getTipo(prmRow("cribaje"))
                vNutricion.MedicionesAntropometricas = vMedicionesAntropometricas

                Dim vIngestaAlimentaria As New IngestaAlimentaria
                vIngestaAlimentaria.DesayunoHora = prmRow("ia_desayuno_hora").ToString()
                vIngestaAlimentaria.DesayunoObs = prmRow("ia_desayuno_obs").ToString()
                vIngestaAlimentaria.ColacionHora = prmRow("ia_colacion_hora").ToString()
                vIngestaAlimentaria.ColacionObs = prmRow("ia_colacion_obs").ToString()
                vIngestaAlimentaria.AlmuerzoHora = prmRow("ia_Almuerzo_hora").ToString()
                vIngestaAlimentaria.AlmuerzoObs = prmRow("ia_Almuerzo_obs").ToString()
                vIngestaAlimentaria.PicoteoHora = prmRow("ia_Picoteo_hora").ToString()
                vIngestaAlimentaria.PicoteoObs = prmRow("ia_Picoteo_obs").ToString()
                vIngestaAlimentaria.OnceHora = prmRow("ia_Once_hora").ToString()
                vIngestaAlimentaria.OnceObs = prmRow("ia_Once_obs").ToString()
                vIngestaAlimentaria.SnackHora = prmRow("ia_Snack_hora").ToString()
                vIngestaAlimentaria.SnackObs = prmRow("ia_Snack_obs").ToString()
                vIngestaAlimentaria.CenaHora = prmRow("ia_Cena_hora").ToString()
                vIngestaAlimentaria.CenaObs = prmRow("ia_Cena_obs").ToString()
                vIngestaAlimentaria.Observacion = prmRow("ia_obs").ToString()
                vNutricion.IngestaAlimentaria = vIngestaAlimentaria
                Return vNutricion
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace
