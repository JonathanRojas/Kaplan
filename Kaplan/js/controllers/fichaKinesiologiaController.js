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

        //$scope.loadingData = false;
        //$scope.StopLoading();

        $scope.columnsO = [{ colId: 'col1', Objetivo: { ID: '' } }];

        $scope.addNewColumnO = function () {
            var newItemNo = $scope.columnsO.length + 1;
            $scope.columnsO.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnO = function (index) {
            $scope.columnsO.splice(index, 1);
        };

        $scope.columnsD = [{ colId: 'col1', Diagnostico: { ID: '' } }];

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

    };
}]);