app.factory('fichaService', ['$http', '$q', 'WindowsService', function ($http, $q, WindowsService) {
    var FichaServ = [];

    FichaServ.getPaciente = function (rut, pasaporte) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getPaciente?intRut=' + rut + '&strPasaporte=' + pasaporte
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

    FichaServ.getPacienteLocal = function (rut) {
        WindowsService.setVariable('isValid', true);
        WindowsService.setVariable('v_rutpaciente', rut);
        return true;
    };

    FichaServ.getisRutvalido = function () {
        return WindowsService.getVariable('isValid');
    };

    FichaServ.getRutPaciente = function () {
        return WindowsService.getVariable('v_rutpaciente');
    };

    FichaServ.getPlanesxRut = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getPlanesxRut?intRut=' + rut
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

    FichaServ.getSesionesxPlan = function (plan) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getSesionesxPlan?intPlan=' + plan
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

    FichaServ.getFichaKinesiologiasxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaKinesiologiasxReserva?intReserva=' + id
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

    FichaServ.SaveFichaKinesiologia = function (ficha, columnsD, columnsO) {
        var deferred = $q.defer();
        var myFormData = new FormData();
         //var diag = { 'FichaKinesiologia': { 'PlanKinesico': { 'Diagnostico': columnsD, 'Objetivo': columnsO } } };
        myFormData.append("Ficha", angular.toJson(ficha))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaKinesiologia',
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