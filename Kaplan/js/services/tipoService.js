app.factory('tipoService', ['$http', '$q', function ($http, $q) {
    var tipoServ = [];

    /*  Tipos Antecedentes    */

    tipoServ.getTipoComuna = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoComuna'
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

    tipoServ.getTipoRegion = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoRegion'
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

    /*  Tipos Kinesiología    */

    tipoServ.getTipoObjetivoKine = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoObjetivoKine'
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

    tipoServ.getTipoDiagnosticoKine = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoDiagnosticoKine'
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

    /*  Tipos Psicología    */

    tipoServ.getTipoSintomatologia = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoSintomatologia'
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

    /*  Tipos Enfermería    */

    /*  Tipos Nutrición    */

    /*  Tipos Médico    */

    return tipoServ;
}]);