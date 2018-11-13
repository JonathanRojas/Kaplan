app.controller("fichaKinesologiaController", ['$scope', 'Notification', 'LoginService', '$location',
function ($scope, Notification, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        $scope.loading = true;
        $scope.loadingData = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
        };

        $scope.loadingData = false;
        $scope.StopLoading();

    };
}]);