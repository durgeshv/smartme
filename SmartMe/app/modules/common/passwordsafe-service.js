(function () {
    'use strict';

    angular.module('smartme.common').service('PasswordSafeService', PasswordSafeService);

    PasswordSafeService.$inject = ['$q', 'HttpService', 'SessionService']

    function PasswordSafeService($q, httpq, session) {

        var service = {
            getRecords: getRecords,
            saveRecord: saveRecord
        }

        return service;

        function getRecords() {
            var url = '../api/passwords';

            var deferred = $q.defer();
            httpq.get(url).then(function (response) {
                deferred.resolve(response);
            });

            return deferred.promise;
        }

        function saveRecord(passwordSafeId, serviceName, username, password, serviceType,
            securityQuestion1, securityAnswer1,
            securityQuestion2, securityAnswer2,
            securityQuestion3, securityAnswer3) {

            var url = '../api/passwords/save';

            var passwordSafeRequest = {};
            var passwordSafe = {};
            passwordSafe.passwordSafeId = passwordSafeId;
            passwordSafe.serviceName = serviceName;
            passwordSafe.username = username;
            passwordSafe.password = password;
            passwordSafe.serviceType = serviceType;
            passwordSafe.securityQuestion1 = securityQuestion1;
            passwordSafe.securityAnswer1 = securityAnswer1;
            passwordSafe.securityQuestion2 = securityQuestion2;
            passwordSafe.securityAnswer2 = securityAnswer2;
            passwordSafe.securityQuestion3 = securityQuestion3;
            passwordSafe.securityAnswer3 = securityAnswer3;

            passwordSafeRequest.passwordSafe = passwordSafe;

            var deferred = $q.defer();
            httpq.post(url, JSON.stringify(passwordSafeRequest))
                .then(function (data) {
                    deferred.resolve(data);
                });

            return deferred.promise;
        }

    }

})();