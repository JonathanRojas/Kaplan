app.controller("inicioController", ['$scope', 'Notification', 'fichaService', 'ServiceObservadorUser', 'LoginService', '$location',
function ($scope, Notification, fichaService, ServiceObservadorUser, LoginService, $location) {

    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        if (fichaService.getisRutvalido()) {
            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                $scope.Paciente = result.data;
                $scope.rutvalido = true;
                fichaService.getPacienteLocal($scope.Paciente.Persona.Rut);
                ServiceObservadorUser.sendMessage($scope.Paciente);
            });
        };

        $scope.Paciente = {
            Estado: 0,
            Persona: {
                Rut: null,
                Dv: null
            }
        };

        $scope.getRut = function () {
            $("#btnBuscar").button('loading');
            if ((typeof $scope.Paciente.Persona.Rut !== 'undefined' && $scope.Paciente.Persona.Rut !== null) && ($scope.Paciente.Persona.Dv !== "" && typeof $scope.Paciente.Persona.Dv !== 'undefined')) {
                var nuevo_numero = $scope.Paciente.Persona.Rut.toString().split("").reverse().join("");
                for (i = 0, j = 2, suma = 0; i < nuevo_numero.length; i++, ((j == 7) ? j = 2 : j++)) {
                    suma += (parseInt(nuevo_numero.charAt(i)) * j);
                }
                n_dv = 11 - (suma % 11);
                var dv = (n_dv == 11) ? 0 : ((n_dv == 10) ? "K" : n_dv);
                if ($scope.Paciente.Persona.Dv.toString().toUpperCase() !== dv.toString()) {
                    msg = { title: 'Advertencia', message: 'Rut no Valido' };
                    Notification.warning(msg);
                    setTimeout(function () { LimpiarDV() }, 100);
                    $scope.rutvalido = false;
                    $("#btnBuscar").button('reset');
                } else {
                    fichaService.getPaciente($scope.Paciente.Persona.Rut, null).then(function (result) {
                        $scope.Paciente = result.data;
                        if ($scope.Paciente.Estado == 1) {
                            $scope.rutvalido = true;
                            fichaService.getPacienteLocal($scope.Paciente.Persona.Rut);
                            ServiceObservadorUser.sendMessage($scope.Paciente);
                            $("#btnBuscar").button('reset');
                        } else {
                            msg = { title: 'Advertencia', message: 'Persona no registrada como paciente de la Fundación Kaplan' };
                            Notification.warning(msg);
                            $("#btnBuscar").button('reset');
                        };
                    }, function (reason) {
                        if (reason.errorcode == 404) {
                            msg = { title: 'Advertencia', message: 'Persona no registrada como paciente de la Fundación Kaplan' };
                            Notification.warning(msg);
                            $scope.rutvalido = false;
                            $("#btnBuscar").button('reset');
                        } else {
                            msg = { title: 'Error al intentar consultar rut' };
                            Notification.error(msg);
                            $scope.rutvalido = false;
                            $("#btnBuscar").button('reset');
                        }
                    });
                };
            };
            $("#btnBuscar").button('reset');
            function LimpiarDV() {
                $scope.Paciente.Persona.Dv = "";
            }
        };

        $scope.Limpiar = function () {
            $scope.Paciente = {
                Estado: 0,
                Persona: {
                    Rut: null,
                    Dv: null
                }
            };
            $scope.rutvalido = false;
            ServiceObservadorUser.sendMessage($scope.Paciente);
        };
    };
}]);