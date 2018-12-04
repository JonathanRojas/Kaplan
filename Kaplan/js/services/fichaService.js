app.factory('fichaService', ['$http', '$q', 'WindowsService', function ($http, $q, WindowsService) {
    var FichaServ = [];

    /*  Generales   */
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

    FichaServ.getSesionesxPlan = function (plan, especialidad) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getSesionesxPlan?intPlan=' + plan + '&intEspecialidad=' + especialidad
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

    /*  Kinesiología    */
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
    FichaServ.SaveFichaKinesiologia = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

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
    /*  Psicología    */
    FichaServ.getFichaPsicologiaxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaPsicologiasReserva?intReserva=' + id
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
    FichaServ.SaveFichaPsicologia = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaPsicologia',
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
    /*  Nutrición    */
    FichaServ.getFichaNutricionxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaNutricionReserva?intReserva=' + id
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
    FichaServ.SaveFichaNutricion = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaPsicologia',
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
    /*  Enfermeria    */
    FichaServ.getFichaEnfermeriaxReserva = function (id) {
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
    FichaServ.SaveFichaEnfermeria = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaEnfermeria',
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