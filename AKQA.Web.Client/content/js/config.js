angular
  .module('app')
  .config(function ($locationProvider,$stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
        url: '/',
        controller: 'ChequeController as ctrl',
        templateUrl: '/content/html/chequeForm.html'
      })
      .state('cheque', {
        url: '/',
        controller: 'ChequeController as ctrl',
        templateUrl: '/content/html/chequeForm.html'
       
      })
      .state('print', {
        url: '/',
        controller: 'PrintController as ctrl',
        templateUrl: '/content/html/chequeTemplate.html'

      });
    $urlRouterProvider.otherwise('/');
    $locationProvider.html5Mode(true);
  });
