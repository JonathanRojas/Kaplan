app.controller("fichaExamenNuevoController", ['$scope', 'ModalService','Notification', 'examenService', 'id', "$element", 'close',
function ($scope, ModalService, Notification, examenService, id, $element, close) {

    $scope.loading = true;
    $scope.StopLoading = function () {
        //$scope.loading = !(!$scope.loadingEspecialistas && !$scope.loadingEspecialidad && !$scope.loadingReserva);
    };

    $scope.Examen = {
        Id: -1,
    };

    $scope.registrarExamen = function () {
        $scope.saving = true;
        examenService.registrarExamen($scope.Examen, $scope.examenFile).then(function (result) {
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error registrando Examen' };
            Notification.error(msg);
            $scope.saving = false;
        });
    };
    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);
