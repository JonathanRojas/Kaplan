app.controller("licenciaController", ['$scope', 'ModalService', 'licenciaService', 'Notification', "$element", 'rut','close',
function ($scope, ModalService, licenciaService, Notification, $element, rut, close) {
    $scope.saving = false;
    $scope.loading = true;
    $scope.Licencia = {
        Id: -1,
        Rut: rut.substring(0, rut.length-2),
        Inicio: null,
        Termino: null,
        Observacion: null
    };

    $scope.registrarLicencia = function () {
        $scope.saving = true;
        licenciaService.registrarLicencia($scope.Licencia).then(function (result) {
            msg = { title: 'Licencia registrada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando Licencia' };
            Notification.error(msg);
        });
    };
   

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);
