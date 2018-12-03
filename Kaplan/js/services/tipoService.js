app.factory('tipoService', ['$http', '$q', function ($http, $q) {
    var tipoServ = [];

    /*  Tipos Antecedentes  */
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
    /*  Tipos Kinesiología  */
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
    tipoServ.getTipoDerivacionAPS = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoDerivacionAPS'
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
    tipoServ.getTipoApoyoSocial = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoApoyoSocial'
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
    tipoServ.getTipoProblemaPsicosocial = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoProblemaPsicosocial'
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
    tipoServ.getTipoRasgoPersonalidad = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoRasgoPersonalidad'
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
    tipoServ.getTipoTrastornoMental = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoTrastornoMental'
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
    tipoServ.getTipoTraumaPostOp = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoTraumaPostOp'
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
    tipoServ.getTipoConcienciaFactor = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoConcienciaFactor'
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
    tipoServ.getTipoDificultadResp = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoDificultadResp'
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
    tipoServ.getTipoIngresoTaller = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoIngresoTaller'
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
    tipoServ.getTipoTratamiento = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoTratamiento'
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
    /*  Tipos Nutrición     */
    tipoServ.getTipoAlergiaAlimentaria = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoAlergiaAlimentaria'
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
    tipoServ.getTipoAversionAlimentaria = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoAversionAlimentaria'
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
    tipoServ.getTipoAzucar = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoAzucar'
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
    tipoServ.getTipoCarne = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoCarne'
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
    tipoServ.getTipoCribaje = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoCribaje'
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
    tipoServ.getTipoFruta = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoFruta'
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
    tipoServ.getTipoIntolerenciaAlimentaria = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoIntolerenciaAlimentaria'
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
    tipoServ.getTipoLacteo = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoLacteo'
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
    tipoServ.getTipoLegumbre = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoLegumbre'
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
    tipoServ.getTipoLiquido = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoLiquido'
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
    tipoServ.getTipoPescado = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoPescado'
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
    tipoServ.getTipoPreferenciaAlimentaria = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoPreferenciaAlimentaria'
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
    tipoServ.getTipoSodio = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoSodio'
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
    tipoServ.getTipoVerdura = function () {
        var deferred = http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTipoVerdura'
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
    /*  Tipos Médico        */

    return tipoServ;
}]);