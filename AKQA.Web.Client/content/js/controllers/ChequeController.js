function ChequeController($rootScope, $scope, $state, $stateParams, dataService) {
  var ctrl = this;
  this.cheque = {
    fullname: '',
    amount: ''
  };
  this.chequeFormat = '';
  this.getChequeFormat = function (data) {
    dataService.getChequeFormat(data).then(function (response) {
      $rootScope.chequeFormat = response;
      $state.go('print');
    }, function (response) {
      $rootScope.chequeFormat = 'failure';
    });
  };

  this.onSubmit = function () {
    if (this.cheque && this.cheque.fullname != '' && this.cheque.amount != '') {
      this.getChequeFormat({ fullname: this.cheque.fullname, amount: this.cheque.amount.toString() });
      
    }
  };
}

angular
  .module('app')
  .controller('ChequeController', ['$rootScope', '$scope', '$state','$stateParams','dataService',ChequeController]);
