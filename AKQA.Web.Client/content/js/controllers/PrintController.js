function PrintController($rootScope, $scope, $state,$stateParams) {
  var ctrl = this;
  this.cheque = {
    fullname: '',
    amount: ''
  };

  this.cheque = $rootScope.chequeFormat.data;
}

angular
  .module('app')
  .controller('PrintController', ['$rootScope', '$scope', '$state', '$stateParams', PrintController]);
