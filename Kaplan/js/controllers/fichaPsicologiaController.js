app.controller("fichaPsicologiaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.TiposSintomatologia = true;

        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTiposSintomatologia);
            if (!$scope.loading) { waitingDialog.hide(); }
        };

        if (parseInt(LoginService.getTipo()) == 5) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        
        fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
            $scope.Planes = result.data;
            $scope.loadingPlanes = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Planes' };
            Notification.error(msg);
        });

        $scope.CambioPlan = function (plan) {
            if (typeof plan !== 'undefined') {
                fichaService.getSesionesxPlan(plan, 4).then(function (result) {
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
                        if (parseInt(LoginService.getTipo()) == 5) {
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

        /*  Tipos   */
        tipoService.getTipoSintomatologia().then(function (result) {
            $scope.TiposSintomatologia = result.data;
            $scope.loadingTiposSintomatologia = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sintomatología Kine' };
            Notification.error(msg);
        });
        /*  Fin Tipos   */
    };
}]);