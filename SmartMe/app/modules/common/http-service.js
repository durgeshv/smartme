(function () {
    'use strict';

    angular.module('smartme.common').service('HttpService', HttpService);

    HttpService.$inject = ['$http', '$q', 'SessionService'];

    function HttpService($http, $q, session) {

        var service = {
            get: get,
            post: post
        };

        return service;

        function get(url) {
            var deferred = $q.defer();
            $http
                .get(url)
                .then(function (response) {
                    deferred.resolve(response.data);
                })
                .catch(function (response) {
                    session.setError(response.data.exceptionMessage);
                    deferred.reject(response.data);
                })
                .finally(function () {
                });

            return deferred.promise;
        }

        function post(url, requestData) {
            var deferred = $q.defer();
            $http
               .post(url, requestData)
               .then(function (response) {
                   deferred.resolve(response.data);
               })
               .catch(function (response) {
                   session.setError(response.data.exceptionMessage);
                   deferred.reject(response.data);
               })
               .finally(function () {
               });

            return deferred.promise;
        }
    }

})();