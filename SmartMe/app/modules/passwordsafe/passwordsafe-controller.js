(function () {
    'use strict';

    angular.module('smartme.passwordsafe').controller('PasswordSafeController', PasswordSafeController);

    PasswordSafeController.$inject = ['$scope'];

    function PasswordSafeController($scope) {
        var vm = this;

        vm.initializePasswordSafe = initializePasswordSafe;
        vm.openAddRecordModal = openAddRecordModal;
        vm.deleteRecord = deleteRecord;

        function initializePasswordSafe() {

        }

        function openAddRecordModal() {
            $("#addRecordModal").modal('show');
        }

        function deleteRecord() {

        }
        

    }

})();