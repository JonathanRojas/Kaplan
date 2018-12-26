app.controller("defaultController", ['$scope', '$http', 'ModalService',
    function ($scope, $http, ModalService) { }]);

app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'login.html',
            inputs: { id: -1 },
            controller: 'loginController',
            controllerAs: 'login'
        })
        .when('/menu', {
            templateUrl: 'views/menuConsulta.html',
            inputs: { id: -1 },
            controller: 'menuConsultaController',
            controllerAs: 'menu'
        })
        .otherwise({
            redirectTo: '/'
        });
});