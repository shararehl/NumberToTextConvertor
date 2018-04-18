function ChequeController($rootScope, $scope, $state, $stateParams, dataService, AlertService) {
  var ctrl = this;
  this.cheque = {
    fullname: '',
    amount: ''
  };
  this.message = '';
  this.chequeFormat = '';

  this.getChequeFormat = function (data) {
    dataService.getChequeFormat(data).then(success, failure);
    function success(response) {
      $rootScope.chequeFormat = response;
      $state.go('print');
    }
    function failure(response) {
      $rootScope.chequeFormat = null;
      AlertService.clear();
      AlertService.error(response.data);
    }
  };

    this.onSubmit = function () {
      if (this.cheque && this.cheque.fullname != '' && this.cheque.amount != '') {
        this.getChequeFormat({ fullname: this.cheque.fullname, amount: this.cheque.amount.toString() });

      }
    };
 }

  angular
    .module('app')
    .controller('ChequeController', ['$rootScope', '$scope', '$state', '$stateParams', 'dataService','AlertService', ChequeController]);
