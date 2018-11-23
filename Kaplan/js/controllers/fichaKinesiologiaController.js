app.controller("fichaKinesiologiaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        $scope.loading = true;
        //$scope.loadingData = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTipoDiagnosticoKine = true;
        $scope.loadingTipoObjetivoKine = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoDiagnosticoKine && !$scope.loadingTipoObjetivoKine && !$scope.loadingTipoComuna && !$scope.loadingPlanes);
        };

        if (parseInt(LoginService.getTipo()) == 5) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };

        //$scope.loadingData = false;
        //$scope.StopLoading();

        $scope.columnsO = [{ colId: 'col1', Tipo: { ID: '' } , Id: -1}];

        $scope.addNewColumnO = function () {
            var newItemNo = $scope.columnsO.length + 1;
            $scope.columnsO.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnO = function (index) {
            $scope.columnsO.splice(index, 1);
        };

        $scope.columnsD = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnD = function () {
            var newItemNo = $scope.columnsD.length + 1;
            $scope.columnsD.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnD = function (index) {
            $scope.columnsD.splice(index, 1);
        };

        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };

        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };

        tipoService.getTipoObjetivoKine().then(function (result) {
            $scope.TiposObjetivo = result.data;
            $scope.loadingTipoObjetivoKine = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Objetivo Kine' };
            Notification.error(msg);
        });

        tipoService.getTipoDiagnosticoKine().then(function (result) {
            $scope.TiposDiagnostico = result.data;
            $scope.loadingTipoDiagnosticoKine = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diagnostico Kine' };
            Notification.error(msg);
        });

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
                fichaService.getSesionesxPlan(plan).then(function (result) {
                    $scope.Sesiones = result.data;
                }, function (reason) {
                    msg = { title: 'Error Listar Planes' };
                    Notification.error(msg);
                });
            };            
        };

        $scope.CambiarSesion = function (sesion) {
            if (typeof sesion !== 'undefined') {
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
                        }, function (reason) {
                            msg = { title: 'Error Al cargar datos del paciente' };
                            Notification.error(msg);
                            $('#collapseDataPaciente').collapse('hide');
                        });
                    } else {
                        $('#collapseDataPaciente').collapse('hide');
                    };
                }, function (reason) {
                    if (reason.errorcode == 404) {
                        if (parseInt(LoginService.getTipo()) == 5) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.Ficha = {FichaKinesiologia: { Id: -1, IdReserva: sesion }};
                                $('#collapseDataPaciente').collapse('show');
                            }, function (reason) {
                                msg = { title: 'Error Al cargar datos del paciente' };
                                Notification.error(msg);
                                $('#collapseDataPaciente').collapse('hide');
                            });
                        } else {
                            msg = { title: 'Sesion Sin Ficha' };
                            Notification.warning(msg);
                            $('#collapseDataPaciente').collapse('hide');
                        };
                    } else {
                        msg = { title: 'Error al Buscar Ficha' };
                        Notification.error(msg);
                        $('#collapseDataPaciente').collapse('hide');
                    }
                });
            } else {
                $('#collapseDataPaciente').collapse('hide');
            };            
        };

        $scope.SaveFicha = function () {
            $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
            $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico = $scope.columnsD;
            $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo = $scope.columnsO;
            $scope.Ficha.FichaKinesiologia.IdEspecialista = parseInt(LoginService.getIdEspecialista())
            console.log($scope.Ficha)
            fichaService.SaveFichaKinesiologia($scope.Ficha)
               .then(function (result) {
                   msg = { title: 'Ficha creada con éxito', message: "" };
                   Notification.success(msg);
               }, function (reason) {
                   msg = { title: 'Error guardando Ficha' };
                   Notification.error(msg);
                   $scope.saving = false;
               });
        }

    };
}]);