app.controller("fichaController", ['$scope', '$http', 'ModalService', 'fichaService', 'tipoService', 'Notification',
function ($scope, $http, ModalService, FichaService, TipoService, Notification) {
    $scope.saving = false;

    $scope.loading = true;
    $scope.loadingFicha = true;
    $scope.loadingTipoSexo = true;
    $scope.TipoEstadoCiviles = true;
    
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingFicha);
    };

    //Listado de Pacientes
    FichaService.getFichas().then(function (result) {
        $scope.Fichas = result.data;
        $scope.loadingFicha = false;
        $scope.StopLoading();
        msg = { title: 'Listado con éxito', message: "" };
        Notification.success(msg);
    }, function (reason) {
        msg = { title: 'Error' };
        Notification.error(msg);
        $element.modal('hide');
        close(true, 500);
    });

    $scope.verFicha = function (id) {
        FichaService.getFicha(id).then(function (result) {
            $scope.Ficha = result.data;
            $scope.Ficha.FechaNac = moment($scope.Ficha.FechaNac);
        })
    }

    $scope.registrarFicha = function () {
        $scope.saving = true;
        FichaService.registrarFicha($scope.Ficha).then(function (result) {
            msg = { title: 'Registro guardado con éxito', message: "" };
            Notification.success(msg);
            FichaService.getFichas().then(function (result) { $scope.Fichas = result.data; });

            $scope.Ficha.Id = "";
            $scope.Ficha.Rut = "";
            $scope.Ficha.Dv = "";
            $scope.Ficha.Nombre = "";
            $scope.Ficha.Paterno = "";
            $scope.Ficha.Materno = "";
            $scope.Ficha.FechaNac = "";
            $scope.Ficha.EstadoCivil = null;
            $scope.Ficha.Domicilio = "";
            $scope.Ficha.Telefono = "";
            $scope.Ficha.Sexo = null;
            $scope.Ficha.SituacionLaboral = "";

        }, function (reason) {
            msg = { title: 'Error guardando registro' };
            Notification.error(msg);
            $scope.saving = false;
        });
    };

    TipoService.getTipoEstadoCivil().then(function (result) {
        $scope.TipoEstadoCiviles = result.data;
        $scope.loadingTipoEstadoCiviles = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Lista Tipo Sexo' };
        Notification.error(msg);
        close(true);
    });

    TipoService.getTipoSexo().then(function (result) {
        $scope.TipoSexos = result.data;
        $scope.loadingTipoSexo = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Lista Tipo Sexo' };
        Notification.error(msg);
        close(true);
    });
}]);

