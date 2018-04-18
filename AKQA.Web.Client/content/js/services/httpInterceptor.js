function HttpInterceptor(CHEQUE_API, $q) {
  return {
    request: function (config) {
      if (config.url === CHEQUE_API) {
        config.headers['x-csrf-token'] = 'toddmotto';
      }
      console.log(config);
      return config;
    },
    requestError: function (config) {
      console.log(config);
      return $q.reject(config);
    },
    response: function (response) {
      console.log(response);
      return response;
    },
    responseError: function (response) {
      console.log(response);
      return $q.reject(response);
    }
  };
}

angular
  .module('app')
  .factory('HttpInterceptor', HttpInterceptor);
