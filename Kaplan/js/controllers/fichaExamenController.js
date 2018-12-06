app.controller("fichaExamenController", ['$scope', 'ModalService', 'Notification', 'LoginService', '$location', 'examenService',
function ($scope, ModalService, Notification, LoginService, $location, examenService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {

         /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Examenes...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.loadingData = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        examenService.getExamenes().then(function (result) {
            $scope.Examenes = result.data;
            $scope.loadingData = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Examenes' };
            Notification.error(msg);
        });


        $scope.NuevoExamen = function () {
            ModalService.showModal({
                templateUrl: "views/fichaExamenNuevo.html",
                inputs: { id:-1 },
                controller: "fichaExamenNuevoController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        examenService.getExamenes().then(function (result) {
                            $scope.Examenes = result.data;
                        }, function (reason) {
                            msg = { title: 'Error Listar Examenes' };
                            Notification.error(msg);
                        });
                    };
                });
            });
        };
        /*  Fin Tipos   */
    };
}]);