app.factory('fichaService', ['$http', '$q', function ($http, $q) {
    var FichaServ = [];

    FichaServ.getFichas = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichas'
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;
    };

    FichaServ.getFicha = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFicha?inId=' + id
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    FichaServ.registrarFicha = function (ficha) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarFicha',
            data: myFormData,
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);;
        };

        return deferred.promise;
    };
    return FichaServ;
}]);