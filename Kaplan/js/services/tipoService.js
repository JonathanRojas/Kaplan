app.factory('tipoService', ['$http', '$q', function ($http, $q) {
    var tipoServ = [];

    tipoServ.getTipoSexo = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoSexo'
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

    tipoServ.getTipoEstadoCivil = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoEstadoCivil'
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
    return tipoServ;
}]);