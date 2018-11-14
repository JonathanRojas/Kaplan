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

        $scope.columnsO = [{ colId: 'col1', Objetivo: { ID: '' } }];

        $scope.addNewColumnO = function () {
            var newItemNo = $scope.columnsO.length + 1;
            $scope.columnsO.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnO = function (index) {
            $scope.columnsO.splice(index, 1);
        };

        $scope.columnsD = [{ colId: 'col1', Diagnostico: { ID: '' } }];

        $scope.addNewColumnD = function () {
            var newItemNo = $scope.columnsD.length + 1;
            $scope.columnsD.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnD = function (index) {
            $scope.columnsD.splice(index, 1);
        };

        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };

        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };


    };
}]);