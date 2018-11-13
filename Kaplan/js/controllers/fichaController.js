app.controller("fichaController", ['$scope', 'Notification', 'LoginService', '$location',
function ($scope, Notification, LoginService, $location) {

    if (LoginService.getisAuthenticated()) {
        $scope.tipo = LoginService.getTipo();
        $scope.Nombres = LoginService.getUserName();

        if ($scope.tipo == '1') {
            $scope.NombreEspecialidad = 'Secretaria'
        }
        else {
            $scope.NombreEspecialidad = 'Especialista'
        }

        var vm = this;
        vm.filePath = {
            name: "views/inicio.html",
            url: "views/inicio.html"
        };
    };

    $scope.CerrarSesion = function () {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    };

    $scope.nav = function (path) {
        if (LoginService.getisAuthenticated()) {
            vm.filePath = {
                name: path,
                url: path
            };
        }
    };

}]);

