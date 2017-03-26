(function () {
    'use strict';

    angular.module('smartme.passwordsafe').controller('PasswordSafeController', PasswordSafeController);

    PasswordSafeController.$inject = ['$scope', 'SessionService', 'PasswordSafeService'];

    function PasswordSafeController($scope, session, passwordSafeService) {
        var vm = this;

        vm.initializePasswordSafe = initializePasswordSafe;
        vm.openAddRecordModal = openAddRecordModal;
        vm.closeAddRecordModal = closeAddRecordModal;
        vm.deleteRecord = deleteRecord;
        vm.save = save;

        function initializePasswordSafe() {
            loadRecords();
        }

        function openAddRecordModal() {
            $("#addRecordModal").modal('show');
            vm.addRecord = {};
        }

        function closeAddRecordModal() {
            $("#addRecordModal").modal('hide');
            delete vm.addRecord;
            loadRecords();
        }

        function deleteRecord() {

        }

        function save() {
            delete vm.message;
            delete vm.errorMessage;
            passwordSafeService.saveRecord(0, vm.addRecord.serviceName, 
                vm.addRecord.username, vm.addRecord.password, vm.addRecord.serviceType, 
                vm.addRecord.secretQuestion1, vm.addRecord.secretAnswer1, 
                vm.addRecord.secretQuestion2, vm.addRecord.secretAnswer2,
                vm.addRecord.secretQuestion3, vm.addRecord.secretAnswer3)
                .then(function (data) {
                    if (data.success) {
                        vm.message = "Record Added Successfully";
                        delete vm.addRecord;
                        vm.addRecord = {};
                    }
                    else {
                        vm.errorMessage = data.message;
                    }
                });
        }

        /************************************************************************************/
        /*private functions                                                                 */
        /************************************************************************************/
        function loadRecords() {
            passwordSafeService.getRecords().then(function (data) {
                vm.onlineAccountsTableOptions = data;
            });
        }

    }

})();