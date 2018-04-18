


  function dataService($http,$q) {

    return {
      getChequeFormat: function (data) {
        var deferred = $q.defer();
        $http.post('api/cheque/print', data).then(function (response) {
          deferred.resolve(response);
        }, function (response) {
          deferred.reject(response);
        });
        return deferred.promise; 
      }
    };
}

angular
  .module('app')
  .factory('dataService', ['$http', '$q', dataService]);
