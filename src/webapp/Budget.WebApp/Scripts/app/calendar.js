define(['app/text', 'lib/locale-all', 'jqueryUi', 'jqueryValidateUnobtrusive'], function (text) {
    function addreceipt() {
        $("#add-receipt").dialog("open");
    };

    function init() {
        var dialogButtons = 

        $("#add-receipt").dialog({
            autoOpen: false,
            buttons: [
            {
                text: text.OK,
                click: function () {
                    $(this).find("form").valid();
                }
            },
            {
                text: text.Cancel,
                click: function () {
                    $(this).dialog("close");
                }
            }]
        });

        $("#calendar").fullCalendar({
            locale: navigator.language, //todo only supported languages
            editable: false,
            droppable: false,
            firstDay: 1,
            customButtons: {
                addreceipt: {
                    text: text.NewExpense,
                    click: addreceipt
                }
            },
            views: {
                month: {
                    columnFormat: 'dddd'
                },
                week: {
                    columnFormat: 'dddd'
                },
                day: {
                    columnFormat: 'dddd'
                }
            },
            header: {
                left: 'basicDay basicWeek month',
                center: 'title',
                right: 'addreceipt today prev next'
            },
            loading: function (isLoading, view) {
                $(".fc-center").toggleClass('loading', isLoading);
            },
            allDayDefault: false,
            events: {
                url: "/Overview/GetReceipts"
            },
            eventAfterAllRender: function (view) {

            }
        });
    };

    return {
        init: init
    };
});