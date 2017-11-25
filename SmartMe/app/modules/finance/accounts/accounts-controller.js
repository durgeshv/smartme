(function () {
    'use strict';

    angular.module('smartme.accounts').controller('AccountController', AccountController);

    AccountController.$inject = ['$scope', 'SessionService', 'AccountService'];

    function AccountController($scope, session, accountService) {
        var vm = this;

        vm.initAccount = initAccount;
        vm.openAddRecordModal = openAddRecordModal;
        vm.closeAddRecordModal = closeAddRecordModal;
        vm.deleteRecord = deleteRecord;
        vm.saveRecord = saveRecord;

        function initAccount() {
            loadRecords();
        }

        function openAddRecordModal() {
            $("#addRecordModal").modal('show');
            vm.addRecord = {};
        }

        function closeAddRecordModal() {
            $("#addRecordModal").modal('hide');
            delete vm.addRecord;
            //loadRecords();
        }

        function deleteRecord() {

        }

        function saveRecord() {

        }

        /************************************************************************************/
        /*private functions                                                                 */
        /************************************************************************************/
        function loadRecords() {
            //waitingDialog.show();
            accountService.getRecords().then(function (data) {
                vm.accountsTableOptions = data;
                waitingDialog.hide();
            })
            .finally(function () {
                //waitingDialog.hide();
            });
        }

    }

})();