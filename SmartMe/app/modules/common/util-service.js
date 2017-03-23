(function () {
    'use strict';

    angular.module('smartme.common').service('UtilService', UtilService);

    UtilService.$inject = ['$q']

    function UtilService($q) {

        var service = {
            get: get,
            post: post
        };

        return service;

        function get() {

        }

        function set() {

        }

    }

})();