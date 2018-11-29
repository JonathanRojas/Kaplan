app.controller("fichaPsicologiaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        //$scope.loadingData = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTipoDiagnosticoKine = true;
        $scope.loadingTipoObjetivoKine = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoDiagnosticoKine && !$scope.loadingTipoObjetivoKine && !$scope.loadingTipoComuna && !$scope.loadingPlanes);
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
                fichaService.getSesionesxPlan(plan).then(function (result) {
                    $scope.Sesiones = result.data;
                }, function (reason) {
                    msg = { title: 'Error Listar Planes' };
                    Notification.error(msg);
                });
            };
        };

        /*  Tipos   */
        tipoService.getTipoObjetivoKine().then(function (result) {
            $scope.TiposObjetivo = result.data;
            $scope.loadingTipoObjetivoKine = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Objetivo Kine' };
            Notification.error(msg);
        });
        /*  Fin Tipos   */
    };
}]);