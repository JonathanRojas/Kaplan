app.controller("modalArchivoController", ['$scope', 'ModalService', 'Notification', 'archivoService', 'id', "$element", 'close', 'fichaService', 'LoginService',
function ($scope, ModalService, Notification, archivoService, id, $element, close, fichaService, LoginService) {

    $scope.Carga = {
        Id: -1,
    };

    $scope.registrarArchivo = function () {
        $scope.saving = true;
        waitingDialog.show('Cargando Archivo...', { dialogSize: 'sm' });
        $scope.Carga.Paciente = fichaService.getRutPaciente();
        $scope.Carga.Especialista = LoginService.getIdEspecialista();
        archivoService.registrarArchivo($scope.Carga, $scope.ergoFile).then(function (result) {
            msg = { title: 'Archivo Cargado Exitosamente' };
            Notification.success(msg);
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
