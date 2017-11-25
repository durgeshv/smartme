(function () {
    'use strict';

    angular.module('smartme.common').service('AccountService', AccountService);

    AccountService.$inject = ['$q', 'HttpService', 'SessionService']

    function AccountService($q, httpq, session) {

        var service = {
            getRecords: getRecords,
            saveRecord: saveRecord
        }
        return service;

        function getRecords() {
            var url = '../api/accounts';

            var deferred = $q.defer();
            httpq.get(url).then(function (response) {
                deferred.resolve(response);
            });

            return deferred.promise;
        }

        function saveRecord() {

        }

    }

})();