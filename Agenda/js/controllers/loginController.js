app.controller("loginController", ['$scope', 'Notification', '$location', 'LoginService',
function ($scope, Notification, $location, LoginService) {
    $scope.Usuario = {
        User: null,
        Pass: null,
        PassEncrypted: null
    }

    $scope.formSubmit = function () {
        var myString = "blablabla Card game bla";
        var myPassword = "myPassword";

        // PROCESS        
        $scope.Usuario.PassEncrypted = md5($scope.Usuario.Pass);
        $("#btnGuardar").button('loading');
        LoginService.getIngresar($scope.Usuario)
            .then(function (result) {
                LoginService.getLoginServer($scope.Usuario.User).then(function (result) {
                    $scope.Usuario = result.data;
                    LoginService.getLoginLocal($scope.Usuario)
                    $location.path('calendario');
                }, function (reason) {
                    msg = { title: 'Error recuperando datos de usuarios' };
                    Notification.error(msg);
                    $("#btnGuardar").button('reset');
                });

            }, function (reason) {
                Notification.error(reason.message);
                $("#btnGuardar").button('reset');
            });
    };
}]);

