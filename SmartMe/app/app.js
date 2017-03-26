(function () {
    'use strict';

    angular.module('smartme', [
        'ngRoute',
        'ngResource',
        'ngSanitize',
        'ngStorage',
        'smartme.common',
        'smartme.dashboard',
        'smartme.expenses',
        'smartme.passwordsafe'
    ]);

    angular.module('smartme').config(config);
    angular.module('smartme').controller('IndexController', IndexController);
    IndexController.$inject = ['$scope', '$sessionStorage', '$q'];

    function config($routeProvider) {
        $routeProvider
            .when('/dashboard', {
                templateUrl: 'modules/dashboard/dashboard.html',
                controller: 'DashboardController'
            })
            .when('/expenses', {
                templateUrl: 'modules/expenses/expenses.html',
                controller: 'ExpenseController'
            })
            .when('/passwordsafe', {
                templateUrl: 'modules/passwordsafe/passwordsafe.html',
                controller: 'PasswordSafeController'
            })
            .otherwise('/dashboard');
    }

    function IndexController($scope, $sessionStorage, $q) {
        var vm = this;

        $scope.$watch(watch);
        vm.initIndex = initIndex;
        vm.message = 'Test Message';

        function watch() {

        }

        function initIndex() {
            var session;
            waitingDialog.show();
            vm.login = false;
            createSession().then(function (data) {
                if ($sessionStorage.appSession) {
                    session = $sessionStorage.appSession;
                    if (session.requiresLogin) {
                        vm.login = true;
                    }
                }
            })
            .finally(function () {
                waitingDialog.hide();
            });
        }

        function createSession() {
            var deferred = $q.defer();

            if (!$sessionStorage.appSession) {
                var appSession = {};
                appSession.requiresLogin = true;
                $sessionStorage.appSession = appSession;
            }
            deferred.resolve();

            return deferred.promise;
        }
    }

})();