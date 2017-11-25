(function () {
    'use strict';

    angular.module('smartme.accounts').directive('accountsTable', accountsTable);

    function accountsTable($sanitize) {
        return {
            restrict: 'E, A, C',
            link: function (scope, element, attrs, controller) {
                element.dataTable({
                    "sDom": "<'row'<'col-sm-2'<'accountsTableToolbar'>><'col-sm-2'l><'col-sm-3'f><'col-sm-5'p>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'p>>",
                    "order": [[0, 'asc'], [1, 'asc'], [2, 'asc'], [3, ''], [4, ''], [5, '']],
                    // "paging": true,
                    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                    "pageLength": 100
                });

                $("#accountsTableActions").appendTo("div.accountsTableToolbar").show();
                var dataTable = element.DataTable();

                scope.$watch('options', handleModelUpdates);

                function handleModelUpdates(newData) {
                    var data = newData || null;
                    if (data) {
                        dataTable.clear();
                        $.each(data, function (key, value) {
                            dataTable.row.add([
                                value.accountName ? value.accountName : "",
                                value.accountNumber ? value.accountNumber : "",
                                value.accountTypeName ? value.accountTypeName : "",
                                value.routingNumberPaperElectronic ? value.routingNumberPaperElectronic + " (P&E)<br />" : "<br />"
                                    + value.routingNumberWires ? value.routingNumberWires + " Wires " : "",
                                value.cvv ? value.cvv : "",
                                value.pin ? value.pin : "",
                                value.email ? value.email : "",
                                value.address ? value.address : "",
                                value.phone1 ? value.phone1 : "" + " <br /> " + value.phone2 ? value.phone2 : ""
                            ]);
                        });
                    }
                    dataTable.draw(false);
                }

                element.on('click', 'td', function () {
                    console.log('Cell Index : ' + $(this).index());
                    var control = dataTable.cell(this, 0).data();
                    console.log('Clicked the row : ' + JSON.stringify(control));
                });

            },
            scope: {
                options: "="
            }
        };
    }

})();