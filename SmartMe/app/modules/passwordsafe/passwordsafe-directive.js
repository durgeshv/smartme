(function () {
    'use strict';

    angular.module('smartme.passwordsafe').directive('onlineAccountsTable', onlineAccountsTable);

    function onlineAccountsTable($sanitize) {
        return {
            restrict: 'E, A, C',
            link: function (scope, element, attrs, controller) {
                element.dataTable({
                    "sDom": "<'row'<'col-sm-2'<'onlineAccountsTableToolbar'>><'col-sm-2'l><'col-sm-3'f><'col-sm-5'p>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'p>>",
                    // "ordering": true,
                    // "paging": true,
                    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                    "pageLength": 100
                });

                $("#onlineAccountsTableActions").appendTo("div.onlineAccountsTableToolbar").show();
                var dataTable = element.DataTable();

                scope.$watch('options', handleModelUpdates);

                function handleModelUpdates(newData) {
                    var data = newData || null;
                    /*
                    if (data) {
                        dataTable.clear();
                        $.each(data, function (key, value) {
                            $.each(value, function (key, value) {
                                dataTable.row.add(['<input type="checkbox" id="' + value.mockContextId + '" />',
                                    '<a href="#/customer-simulation-details?mockContextId=' + value.mockContextId + '">' + value.mockContextId + '</a>',
                                     value.name]);
                            });
                        });
                    }
                    dataTable.draw(false);
                    */
                }
            },
            scope: {
                options: "=options"
            }
        };
    }

})();