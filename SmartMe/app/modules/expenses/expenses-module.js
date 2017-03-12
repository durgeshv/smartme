(function () {
    'use strict';

    angular.module('smartme.expenses', ['ngRoute', 'ngResource']);

    angular.module('smartme.expenses').config(config);

    function config($routeProvider) {
        /*
        $routeProvider
            .when('/expenses', {
                templateUrl: 'modules/expenses/expenses.html',
                controller: 'ExpenseController'
            });
        */
    }

})();