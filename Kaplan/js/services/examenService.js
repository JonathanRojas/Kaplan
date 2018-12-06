app.factory('examenService', ['$http', '$q', function ($http, $q) {
    var ExamenServ = [];

    ExamenServ.registrarExamen = function (examen, archivo) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("documento", archivo)
        myFormData.append("Examen", angular.toJson(examen));
        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarExamen',
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
    return ExamenServ;
}]);