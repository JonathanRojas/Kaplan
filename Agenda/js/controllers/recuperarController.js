app.controller("recuperarController", ['$scope', 'Notification', '$location', 'LoginService',
function ($scope, Notification, $location, LoginService) {
    
    $scope.formSubmit = function () {
        $("#btnGuardar").button('loading');
        LoginService.getCorreo($scope.Email).then(function (result) {
                msg = { title: 'Email enviado' };
                Notification.success(msg);
                $("#btnGuardar").button('reset');
                $location.path('/');
            }, function (reason) {
                Notification.error('Error al enviar correo');
                $("#btnGuardar").button('reset');
            });
    };
}]);

