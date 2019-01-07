﻿app.controller("fichaMedicoController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.mostrarReporte = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.loadingTiposRespuesta = true;
        $scope.loadingTipoDiseccionAortica = true;
        $scope.loadingTipoAneurismaMedico = true;
        $scope.loadingTipoTumorMedico = true;
        $scope.loadingTipoEcocardiogramaMedico = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoComuna && !$scope.loadingPlanes && !$scope.loadingTiposRespuesta && !$scope.loadingTipoDiseccionAortica && !$scope.loadingTipoAneurismaMedico && !$scope.loadingTipoTumorMedico && !$scope.loadingTipoEcocardiogramaMedico);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        /*Validacion de perfil para editar la ficha*/
        if (parseInt(LoginService.getTipo()) == 2) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        /*Fin*/

        /*Creacion de input variables*/
        $scope.columnsHistoriaCardiopatia = [{ colId: 'col1', Historia: '', Id: -1 }];

        $scope.addNewColumnHistoriaCardiopatia = function () {
            var newItemNo = $scope.columnsHistoriaCardiopatia.length + 1;
            $scope.columnsHistoriaCardiopatia.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHistoriaCardiopatia = function (index) {
            $scope.columnsHistoriaCardiopatia.splice(index, 1);
        };
        //-----------------------------------------------------------//
        $scope.columnsHistoriaCronica = [{ colId: 'col1', Historia: '', Id: -1 }];

        $scope.addNewColumnHistoriaCronica = function () {
            var newItemNo = $scope.columnsHistoriaCronica.length + 1;
            $scope.columnsHistoriaCronica.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHistoriaCronica = function (index) {
            $scope.columnsHistoriaCronica.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsOtraCirugia = [{ colId: 'col1', Cirugia: '', Id: -1, Fecha: '' }];

        $scope.addNewColumnOtraCirugia = function () {
            var newItemNo = $scope.columnsOtraCirugia.length + 1;
            $scope.columnsOtraCirugia.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnOtraCirugia = function (index) {
            $scope.columnsOtraCirugia.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsBetabloqueador = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnBetabloqueador = function () {
            var newItemNo = $scope.columnsBetabloqueador.length + 1;
            $scope.columnsBetabloqueador.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnBetabloqueador = function (index) {
            $scope.columnsBetabloqueador.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsBloqueadorCorrientes = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnBloqueadorCorrientes = function () {
            var newItemNo = $scope.columnsBloqueadorCorrientes.length + 1;
            $scope.columnsBloqueadorCorrientes.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnBloqueadorCorrientes = function (index) {
            $scope.columnsBloqueadorCorrientes.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIECA = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnIECA = function () {
            var newItemNo = $scope.columnsIECA.length + 1;
            $scope.columnsIECA.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIECA = function (index) {
            $scope.columnsIECA.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsARA2 = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnARA2 = function () {
            var newItemNo = $scope.columnsARA2.length + 1;
            $scope.columnsARA2.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnARA2 = function (index) {
            $scope.columnsARA2.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsNitratos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnNitratos = function () {
            var newItemNo = $scope.columnsNitratos.length + 1;
            $scope.columnsNitratos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnNitratos = function (index) {
            $scope.columnsNitratos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAnticoagulanteOral = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAnticoagulanteOral = function () {
            var newItemNo = $scope.columnsAnticoagulanteOral.length + 1;
            $scope.columnsAnticoagulanteOral.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAnticoagulanteOral = function (index) {
            $scope.columnsAnticoagulanteOral.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsEstatina = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnEstatina = function () {
            var newItemNo = $scope.columnsEstatina.length + 1;
            $scope.columnsEstatina.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEstatina = function (index) {
            $scope.columnsEstatina.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAntiplaquetario = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAntiplaquetario = function () {
            var newItemNo = $scope.columnsAntiplaquetario.length + 1;
            $scope.columnsAntiplaquetario.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAntiplaquetario = function (index) {
            $scope.columnsAntiplaquetario.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsHipoglicemiante = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnHipoglicemiante = function () {
            var newItemNo = $scope.columnsHipoglicemiante.length + 1;
            $scope.columnsHipoglicemiante.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHipoglicemiante = function (index) {
            $scope.columnsHipoglicemiante.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsEsteroides = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnEsteroides = function () {
            var newItemNo = $scope.columnsEsteroides.length + 1;
            $scope.columnsEsteroides.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEsteroides = function (index) {
            $scope.columnsEsteroides.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDiuretico = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnDiuretico = function () {
            var newItemNo = $scope.columnsDiuretico.length + 1;
            $scope.columnsDiuretico.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDiuretico = function (index) {
            $scope.columnsDiuretico.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAlopurinol = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAlopurinol = function () {
            var newItemNo = $scope.columnsAlopurinol.length + 1;
            $scope.columnsAlopurinol.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAlopurinol = function (index) {
            $scope.columnsAlopurinol.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDigitalicos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnDigitalicos = function () {
            var newItemNo = $scope.columnsDigitalicos.length + 1;
            $scope.columnsDigitalicos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDigitalicos = function (index) {
            $scope.columnsDigitalicos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAntiarritmicos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAntiarritmicos = function () {
            var newItemNo = $scope.columnsAntiarritmicos.length + 1;
            $scope.columnsAntiarritmicos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAntiarritmicos = function (index) {
            $scope.columnsAntiarritmicos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsOtros = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnOtros = function () {
            var newItemNo = $scope.columnsOtros.length + 1;
            $scope.columnsOtros.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnOtros = function (index) {
            $scope.columnsOtros.splice(index, 1);
        };
        /*Fin*/

        /*Accion de para avanzar o retroceder en un tabpanel*/
        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };

        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };
        /*Fin*/

        /*Tipo Services*/
        tipoService.getTipoRegion().then(function (result) {
            $scope.TipoRegiones = result.data;
            $scope.loadingTipoRegion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Region' };
            Notification.error(msg);
        });

        tipoService.getTipoComuna().then(function (result) {
            $scope.TipoComunas = result.data;
            $scope.loadingTipoComuna = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Comuna' };
            Notification.error(msg);
        });

        tipoService.getTipoRespuestaMedico().then(function (result) {
            $scope.TiposHistoriaCardiopatia = result.data;
            $scope.TiposHistoriaCronica = result.data;
            $scope.TiposTabaquismoActivo = result.data;
            $scope.TiposAlcohol = result.data;
            $scope.TiposAbusoDrogas = result.data;
            $scope.TiposDislipidemias = result.data;
            $scope.TiposHipertensionArterial = result.data;
            $scope.TiposDiabetesMellitus = result.data;
            $scope.TiposInsulinoterapia = result.data;
            $scope.TiposAlergias = result.data;
            $scope.TiposEnfermedadRenalCronica = result.data;
            $scope.TiposProteinurea = result.data;
            $scope.TiposHemodialisis = result.data;
            $scope.TiposAnemia = result.data;
            $scope.TiposEnfermedadPulmonar = result.data;
            $scope.TiposEnfermedadHepatica = result.data;
            $scope.TiposEnfermedadArterialPeriferica = result.data;
            $scope.TiposCirugiaPeriferica = result.data;
            $scope.TiposEnfermedadCerebroVascular = result.data;
            $scope.TiposCirugiaCarotidea = result.data;
            $scope.TiposInmunosupresion = result.data;
            $scope.TiposHistoriaOncologica = result.data;
            $scope.TiposQuimioterapia = result.data;
            $scope.TiposRadioterapia = result.data;
            $scope.TiposApneaSueno = result.data;
            $scope.TiposCardiopatiaCongenita = result.data;
            $scope.TiposInfartoAgudoMiocardio = result.data;
            $scope.TiposInsuficienciaCardiaca = result.data;
            $scope.TiposSincopeCardiogenico = result.data;
            $scope.TiposShockCardiogenico = result.data;
            $scope.TiposParoCardiorRespiratorio = result.data;
            $scope.TiposSupraventricular = result.data;
            $scope.TiposVentricular = result.data;
            $scope.TiposEndocarditis = result.data;
            $scope.TiposDiseccionAortica = result.data;
            $scope.TiposAneurismaAortico = result.data;
            $scope.TiposTumorCardiaco = result.data;
            $scope.TiposPuenteCoronario = result.data;
            $scope.TiposADA = result.data;
            $scope.TiposACX = result.data;
            $scope.TiposACD = result.data;
            $scope.TiposCirugiaValvular = result.data;
            $scope.TiposAortica = result.data;
            $scope.TiposMitral = result.data;
            $scope.TiposTricuspide = result.data;
            $scope.TiposCierreComInteraricular = result.data;
            $scope.TiposCierreComInterVetricular = result.data;
            $scope.TiposCirugiaAorta = result.data;
            $scope.TiposCirugiaCardiopatiaCon = result.data;
            $scope.TiposReoperacion = result.data;
            $scope.TiposTrasplanteCardiaco = result.data;
            $scope.TiposImplantacionLVAD = result.data;
            $scope.TiposOtraCirugia = result.data;
            $scope.TiposTerapiaAblativa = result.data;
            $scope.TiposMarcapaso = result.data;
            $scope.TiposCDITRC = result.data;
            $scope.TiposAngioplastia = result.data;
            $scope.TiposBalon = result.data;
            $scope.TiposBetabloqueador = result.data;
            $scope.TiposBloqueadorCorrientes = result.data;
            $scope.TiposIECA = result.data;
            $scope.TiposARA2 = result.data;
            $scope.TiposNitratos = result.data;
            $scope.TiposAnticoagulanteOral = result.data;
            $scope.TiposEstatina = result.data;
            $scope.TiposAntiplaquetario = result.data;
            $scope.TiposHipoglicemiante = result.data;
            $scope.TiposEsteroides = result.data;
            $scope.TiposDiuretico = result.data;
            $scope.TiposAlopurinol = result.data;
            $scope.TiposDigitalicos = result.data;
            $scope.TiposAntiarritmicos = result.data;
            $scope.TiposOtros = result.data;
            $scope.TiposLesionAda = result.data;
            $scope.TiposLesionACD = result.data;
            $scope.TiposLesionACX = result.data;
            $scope.TiposTroncoCoronario = result.data;
            $scope.TiposPapMedia = result.data;
            $scope.TiposUwood = result.data;
            $scope.TiposTestReversibilidad = result.data;
            $scope.TiposDilatacionAuricular = result.data;
            $scope.TiposHipertensionPulmonar = result.data;
            $scope.TiposDisfuncionVentriculo = result.data;
            $scope.TiposEstenosisAortica = result.data;
            $scope.TiposEstenosisMitral = result.data;
            $scope.TiposInsuficienciaAortica = result.data;
            $scope.TiposInsuficienciaMitral = result.data;
            $scope.TiposAquinesia = result.data;
            $scope.TiposArrtimias = result.data;
            $scope.TiposBloqueosAV = result.data;
            $scope.TiposEjeCardiaco = result.data;
            $scope.loadingTiposRespuesta = false;

            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Respuesta' };
            Notification.error(msg);
        });

        tipoService.getTipoEcocardiogramaMedico().then(function (result) {
            $scope.TiposDilatacionAuricularTipo = result.data;
            $scope.TiposHipertensionPulmonarTipo = result.data;
            $scope.TiposDisfuncionVentriculoTipo = result.data;
            $scope.TiposEstenosisAorticaTipo = result.data;
            $scope.TiposEstenosisMitralTipo = result.data;
            $scope.TiposInsuficienciaAorticaTipo = result.data;
            $scope.TiposInsuficienciaMitralTipo = result.data;
            $scope.TiposAquinesiaTipo = result.data;

            $scope.loadingTipoEcocardiogramaMedico = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diseccion' };
            Notification.error(msg);
        });

        tipoService.getTipoDiseccionMedico().then(function (result) {
            $scope.TiposDiseccionAorticaTipo = result.data;
            $scope.loadingTipoDiseccionAortica = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diseccion' };
            Notification.error(msg);
        });

        tipoService.getTipoAneurismaMedico().then(function (result) {
            $scope.TiposAneurismaAorticoTipo = result.data;
            $scope.loadingTipoAneurismaMedico = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Aneurisma' };
            Notification.error(msg);
        });

        tipoService.getTipoTumorMedico().then(function (result) {
            $scope.TiposTumorCardiacoTipo = result.data;
            $scope.loadingTipoTumorMedico = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Tumor' };
            Notification.error(msg);
        });
        /*Fin*/

        /*Carga de Planes*/
        fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
            $scope.Planes = result.data;
            $scope.loadingPlanes = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Planes' };
            Notification.error(msg);
        });
        /*Fin*/

        /*Funciones*/
        $scope.CambioPlan = function (plan) {
            if (typeof plan !== 'undefined') {
                fichaService.getSesionesxPlan(plan, 2).then(function (result) {
                    $scope.Sesiones = result.data;
                }, function (reason) {
                    msg = { title: 'Error Listar Planes' };
                    Notification.error(msg);
                });
            };
        };

        $scope.CambiarSesion = function (sesion) {
            if (typeof sesion !== 'undefined') {
                waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
                fichaService.getFichaEnfermeriaxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.mostrarReporte = false;
                        $scope.Ficha = result.data;
                        $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                        $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                        for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                            $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                        }
                        $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                        $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                        $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                        $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                        $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                        $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);
                        fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                            $scope.Paciente = result.data;
                            $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                            $('#collapseDataPaciente').collapse('show');
                            waitingDialog.hide();
                        }, function (reason) {
                            msg = { title: 'Error Al cargar datos del paciente' };
                            Notification.error(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        });
                    } else {
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    };
                }, function (reason) {
                    if (reason.errorcode == 404) {
                        if (parseInt(LoginService.getTipo()) == 2) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.columnsEvolucion = [{ colId: 'col1', Fecha: '', Evolucion: '', Id: -1 }];
                                $scope.columnsMedicamentos = [{ colId: 'col1', Nombre: '', Observacion: '', Dosis: '', Horario: '', Id: -1 }];
                                $scope.columnsDiagnostico = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIntervenciones = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIndicadores = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1, Inicio: '', Final: '' }];
                                $scope.Ficha = { FichaEnfermeria: { Id: -1, IdReserva: sesion } };
                                $('#collapseDataPaciente').collapse('show');
                                waitingDialog.hide();
                            }, function (reason) {
                                msg = { title: 'Error Al cargar datos del paciente' };
                                Notification.error(msg);
                                $('#collapseDataPaciente').collapse('hide');
                                waitingDialog.hide();
                            });
                        } else {
                            msg = { title: 'Sesion Sin Ficha' };
                            Notification.warning(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        };
                    } else {
                        msg = { title: 'Error al Buscar Ficha' };
                        Notification.error(msg);
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    }
                });
            } else {
                $('#collapseDataPaciente').collapse('hide');
                waitingDialog.hide();
            };
        };

        $scope.SaveFicha = function () {
            if ($scope.ValidarForm()) {
                $scope.Ficha.Id = fichaService.getidFicha();
                $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria = $scope.columnsMedicamentos;
                $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria = $scope.columnsEvolucion;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico = $scope.columnsDiagnostico;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion = $scope.columnsIntervenciones;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores = $scope.columnsIndicadores;
                $scope.Ficha.FichaEnfermeria.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaEnfermeria($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       fichaService.getFichaEnfermeriaxReserva($scope.Ficha.FichaEnfermeria.IdReserva).then(function (result) {
                           $scope.Ficha = result.data;
                           $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                           $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                           for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                               $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                           }
                           $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                           $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                           $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                           $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                           $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                           $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);
                           fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                               $scope.Paciente = result.data;
                               $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                               msg = { title: 'Ficha guardada con éxito', message: "" };
                               Notification.success(msg);
                               waitingDialog.hide();
                               window.scrollTo(0, 0);
                           });
                       }, function (reason) {
                           msg = { title: 'Error al Intentar Recargar los datos de la Ficha guardada' };
                           Notification.error(msg);
                           $('#collapseDataPaciente').collapse('hide');
                           waitingDialog.hide();
                       });
                   }, function (reason) {
                       msg = { title: 'Error guardando Ficha' };
                       Notification.error(msg);
                       $scope.saving = false;
                       waitingDialog.hide();
                   });
            };
        }

        $scope.ValidarForm = function () {
            var error = 0;
            var msg = 'Los siguientes campos son requeridos :<br>';
            $(':input[required]', '#frmMedico').each(function () {
                $(this).css('border', '1px solid #32b8da');
                if ($(this).val() == '') {
                    msg += '<br><b>' + $(this).attr('placeholder') + '</b>';
                    $(this).css('border', '2px solid #F57E7D');
                    /*if (error == 0) {
                        $(this).focus();
                        var tab = $(this).closest('.tab-pane').attr('id');
                        $('#myTab a[href="#' + tab + '"]').tab('show');
                    }*/
                    error = 1;
                }
            });
            if (error == 1) {
                msg = { title: 'Ups, faltan campos por completar', message: msg, delay: 5000 };
                Notification.warning(msg);
                return false;
            } else {
                return true;
            }
        }
        /*Fin*/

        $scope.reporte = function (sesion) {
            url = "reports/reporte.aspx?tipo=FE&id=" + sesion
            window.open(url, '_blank');
        }
    };
}]);