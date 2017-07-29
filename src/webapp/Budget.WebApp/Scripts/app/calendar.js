$(function () {
    (function () {
        $("#add-receipt").dialog({
           
        });
    })();


    function addreceipt() {
        $("#add-receipt").dialog();
    };

    $("#calendar").fullCalendar({
        locale: 'pl',
        editable: false,
        droppable: false,
        firstDay: 1,
        customButtons: {
            addreceipt: {
                text: 'todo resources.js',
                click: addreceipt
            }
        },
        views:{
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
});