app.factory('consultaService', ['$http', '$q', function ($http, $q) {
    var Serv = [];

    Serv.getConsulta = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getConsulta'
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

    return Serv;
}]);