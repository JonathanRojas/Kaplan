app.controller("fichaEnfermeriaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        //$scope.loadingData = true;
        $scope.loadingTipoRegion = true;
        //$scope.loadingTipoDiagnosticoKine = true;
        //$scope.loadingTipoObjetivoKine = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoComuna && !$scope.loadingPlanes);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        /*Validacion de perfil para editar la ficha*/
        if (parseInt(LoginService.getTipo()) == 3) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        /*Fin*/

        /*Creacion de input variables*/
        $scope.columnsEvolucion = [{ colId: 'col1', Fecha: '', Evolucion: '', Id: -1 }];

        $scope.addNewColumnEvolucion = function () {
            var newItemNo = $scope.columnsEvolucion.length + 1;
            $scope.columnsEvolucion.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEvolucion = function (index) {
            $scope.columnsEvolucion.splice(index, 1);
        };
        //-----------------------------------------------------------//
        $scope.columnsMedicamentos = [{ colId: 'col1', Nombre: '', Observacion: '', Dosis: '', Horario: '', Id: -1 }];

        $scope.addNewColumnMedicamentos = function () {
            var newItemNo = $scope.columnsMedicamentos.length + 1;
            $scope.columnsMedicamentos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnMedicamentos = function (index) {
            $scope.columnsMedicamentos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDiagnostico = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnDiagnostico = function () {
            var newItemNo = $scope.columnsDiagnostico.length + 1;
            $scope.columnsDiagnostico.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDiagnostico = function (index) {
            $scope.columnsDiagnostico.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIntervenciones = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnIntervenciones = function () {
            var newItemNo = $scope.columnsIntervenciones.length + 1;
            $scope.columnsIntervenciones.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIntervenciones = function (index) {
            $scope.columnsIntervenciones.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIndicadores = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1, Inicio: '', Final: '' }];

        $scope.addNewColumnIndicadores = function () {
            var newItemNo = $scope.columnsIndicadores.length + 1;
            $scope.columnsIndicadores.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIndicadores = function (index) {
            $scope.columnsIndicadores.splice(index, 1);
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
                fichaService.getSesionesxPlan(plan, 3).then(function (result) {
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
                fichaService.getFichaKinesiologiasxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.Ficha = result.data;
                        $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso);
                        $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso);
                        $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso);
                        $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso);
                        $scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha);
                        $scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha);
                        $scope.columnsO = $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo;
                        $scope.columnsD = $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico;
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
                        if (parseInt(LoginService.getTipo()) == 3) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.Ficha = { FichaKinesiologia: { Id: -1, IdReserva: sesion } };
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
                $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico = $scope.columnsD;
                $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo = $scope.columnsO;
                $scope.Ficha.FichaKinesiologia.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaKinesiologia($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       msg = { title: 'Ficha creada con éxito', message: "" };
                       Notification.success(msg);
                       waitingDialog.hide();
                       window.scrollTo(0, 0);
                       //$scope.CambiarSesion($scope.Sesion.Id);
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
            $(':input[required]', '#frmEnfermeria').each(function () {
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

    };
}]);