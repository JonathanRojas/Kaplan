app.controller("fichaExamenNuevoController", ['$scope', 'ModalService','Notification', 'examenService', 'id', "$element", 'close', 'fichaService', 'LoginService',
function ($scope, ModalService, Notification, examenService, id, $element, close, fichaService, LoginService) {

    $scope.loading = true;
    $scope.StopLoading = function () {
        //$scope.loading = !(!$scope.loadingEspecialistas && !$scope.loadingEspecialidad && !$scope.loadingReserva);
    };

    $scope.Examen = {
        Id: -1,
    };

    $scope.registrarExamen = function () {
        $scope.saving = true;
        waitingDialog.show('Guardando Examen...', { dialogSize: 'sm' });
        $scope.Examen.Paciente = fichaService.getRutPaciente();
        $scope.Examen.Especialista = LoginService.getIdEspecialista();
        examenService.registrarExamen($scope.Examen, $scope.examenFile).then(function (result) {
            waitingDialog.hide();
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: reason.message };
            Notification.error(msg);
            $scope.saving = false;
            waitingDialog.hide();
        });
    };
    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);
