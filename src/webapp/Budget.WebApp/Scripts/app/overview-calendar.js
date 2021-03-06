﻿define(['app/text', 'lib/locale-all'], function (text) {
    function init(config) {
        $("#calendar").fullCalendar({
            locale: document.body.getAttribute("lang"),
            editable: false,
            droppable: false,
            firstDay: 1,
            customButtons: {
                addreceipt: {
                    text: text.NewExpense,
                    click: config.addReceipt
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

    function addEvent(calendarEvent) {
        $("#calendar").fullCalendar("renderEvent", calendarEvent, true);
    };

    return {
        init: init,
        addEvent: addEvent
    };
});