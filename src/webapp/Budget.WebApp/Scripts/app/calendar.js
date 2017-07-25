$(function () {
    $("#calendar").fullCalendar({
        locale: 'pl',
        editable: false,
        droppable: false,
        firstDay: 1,
        header: {
            left: 'agendaDay,agendaWeek,month',
            center: 'title',
            right: 'today prev, next'
        },
        loading: function (isLoading, view) {

        },
        allDayDefault: false,
        events: {
            url: "/Overview/GetReceipts"
        },
        eventAfterAllRender: function (view) {
            
        }
    });
});