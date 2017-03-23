(function () {
    'use strict';

    angular.module('smartme.common').factory('SessionService', SessionService);

    function SessionService() {

        var appSession;
        var error = '';

        return {
            getAppSession: function () {
                return appSession;
            },
            setAppSession: function (value) {
                appSession = value;
            },

            getLoggedOnUser: function () {
                return appSession.loggedOnUser;
            },

            getError: function () {
                return error;
            },
            setError: function (value) {
                error = value;
            },

        };
    }

})();