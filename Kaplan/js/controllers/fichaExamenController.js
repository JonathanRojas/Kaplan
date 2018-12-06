app.controller("fichaExamenController", ['$scope', 'ModalService', 'Notification', 'LoginService', '$location',
function ($scope, ModalService, Notification, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {        
        $scope.NuevoExamen = function () {
            ModalService.showModal({
                templateUrl: "views/fichaExamenNuevo.html",
                inputs: { id:-1 },
                controller: "fichaExamenNuevoController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                    };
                });
            });
        };
        $scope.ValidarForm = function () {
            var error = 0;
            var msg = 'Los siguientes campos son requeridos :<br>';
            $(':input[required]', '#frmPsicologia').each(function () {
                $(this).css('border', '1px solid #32b8da');
                if ($(this).val() == '') {
                    msg += '<br><b>' + $(this).attr('placeholder') + '</b>';
                    $(this).css('border', '2px solid #F57E7D');
                    /*if (error == 0) {
                        $(this).focus();
                        var tab = $(this).closest('.tab-pane').attr('id');
                        $('#myTab a[href="#' + tab + '"]').tab('show');
                    }*/
                    error = 1;
                }
            });
            if (error == 1) {
                msg = { title: 'Ups, faltan campos por completar', message: msg, delay: 5000 };
                Notification.warning(msg);
                return false;
            } else {
                return true;
            }
        }
        /*  Fin Tipos   */
    };
}]);