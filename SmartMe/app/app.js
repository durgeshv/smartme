(function () {
    'use strict';

    angular.module('smartme', [
        'ngRoute',
        'ngResource',
        'ngSanitize',
        'ngStorage',
        'ui.router',
        'smartme.expenses'
    ]);

    angular.module('smartme').config(config);
    angular.module('smartme').controller('IndexController', IndexController);
    IndexController.$inject = ['$scope', '$sessionStorage', '$q'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        $locationProvider.hashPrefix('');
        $urlRouterProvider.otherwise('/dashboard');

        $stateProvider
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: 'modules/dashboard/dashboard.html'
            })
            .state('expenses', {
                url: '/expenses',
                templateUrl: 'modules/expenses/expenses.html'
            });
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
            console.log('Called from initIndex');
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