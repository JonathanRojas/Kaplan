app.controller("fichaController", ['$scope', 'Notification', 'LoginService', '$location', 'ServiceObservadorUser', 'fichaService',
function ($scope, Notification, LoginService, $location, ServiceObservadorUser, fichaService) {

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

        this.receive = function (message) {
            if (message.Estado == 1) {
                $scope.rutvalido = true;
                $scope.Titulo = message.Persona.Nombre + " " + message.Persona.Paterno + " " + message.Persona.Materno;
                $scope.RutPaciente = message.Persona.Rut + "-" + message.Persona.Dv;
            } else {
                $scope.Titulo = null;
                $scope.RutPaciente = null;
                $scope.rutvalido = false;
            };

        };
        ServiceObservadorUser.listenMessage(this);
        
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

