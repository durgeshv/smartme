(function () {
    'use strict';

    angular.module('smartme.passwordsafe').directive('onlineAccountsTable', onlineAccountsTable);

    function onlineAccountsTable($sanitize) {
        return {
            restrict: 'E, A, C',
            link: function (scope, element, attrs, controller) {
                element.dataTable({
                    "sDom": "<'row'<'col-sm-2'<'onlineAccountsTableToolbar'>><'col-sm-2'l><'col-sm-3'f><'col-sm-5'p>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'p>>",
                    "order": [[0, 'asc'], [1, 'asc'], [2, 'asc'], [3, ''], [4, ''], [5, '']],
                    // "paging": true,
                    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                    "pageLength": 100
                });

                $("#onlineAccountsTableActions").appendTo("div.onlineAccountsTableToolbar").show();
                var dataTable = element.DataTable();

                scope.$watch('options', handleModelUpdates);

                function handleModelUpdates(newData) {
                    var data = newData || null;
                    if (data) {
                        dataTable.clear();
                        $.each(data, function (key, value) {
                            dataTable.row.add([
                                value.serviceName ? value.serviceName : "",
                                value.username ? value.username : "",
                                value.serviceType ? value.serviceType : "",
                                '<span style="cursor:pointer"><i class="fa fa-eye" aria-hidden="true"></i></span>',
                                '<span style="cursor:pointer"><i class="fa fa-pencil" aria-hidden="true"></i></span>',
                                '<span style="cursor:pointer"><i class="fa fa-trash" aria-hidden="true"></i></span>'
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