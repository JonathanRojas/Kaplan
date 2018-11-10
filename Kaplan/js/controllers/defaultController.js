app.controller("defaultController", ['$scope', '$http', 'ModalService',
    function ($scope, $http, ModalService) { }]);

app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'views/ficha.html',
            inputs: { id: -1 },
            controller: 'fichaController'
        })         
        .otherwise({
            redirectTo: '/'
        });
});