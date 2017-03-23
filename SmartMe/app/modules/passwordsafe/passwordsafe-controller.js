(function () {
    'use strict';

    angular.module('smartme.passwordsafe').controller('PasswordSafeController', PasswordSafeController);

    PasswordSafeController.$inject = ['$scope', 'PasswordSafeService'];

    function PasswordSafeController($scope, passwordSafeService) {
        var vm = this;

        vm.initializePasswordSafe = initializePasswordSafe;
        vm.openAddRecordModal = openAddRecordModal;
        vm.deleteRecord = deleteRecord;
        vm.save = save;

        function initializePasswordSafe() {
            console.log('In passwordSafe init');
            loadRecords();
        }

        function openAddRecordModal() {
            $("#addRecordModal").modal('show');
        }

        function deleteRecord() {

        }

        function save() {
            console.log(JSON.stringify(vm.addRecord));
            passwordSafeService.saveRecord(0, vm.addRecord.serviceName, 
                vm.addRecord.username, vm.addRecord.password, vm.addRecord.serviceType, 
                vm.addRecord.secretQuestion1, vm.addRecord.secretAnswer1, 
                vm.addRecord.secretQuestion2, vm.addRecord.secretAnswer2,
                vm.addRecord.secretQuestion3, vm.addRecord.secretAnswer3)
                .then(function (data) {
                    console.log(JSON.stringify(data));
            });
        }

        /************************************************************************************/
        /*private functions                                                                 */
        /************************************************************************************/
        function loadRecords() {
            passwordSafeService.getRecords().then(function (data) {
                console.log(JSON.stringify(data));
                vm.onlineAccountsTableOptions = data;
            });
        }

    }

})();