define(['app/text', 'lib/locale-all', 'jqueryUi', 'jqueryValidate'], function (text) {
    function addreceipt() {
        $("#add-receipt").dialog("open");
    };

    function nextReceiptEntryClick(event) {
        var button = $(event.target);
        var parent = button.prev();
        var child = parent.clone();

        var currentIndex = parseInt(parent.attr("data-index")) + 1;
        child.attr("data-index", currentIndex);

        var currentName = parent.data("name") + currentIndex;
        child.find("label").attr("for", currentName);

        var input = child.find("input");
        input.attr("id", currentName);
        input.attr("name", currentName);

        child.insertBefore(button);

        input.rules("add", {
            required: true,
            messages: {
                required: text.ThisFieldIsRequired
            }
        });
    };

    function init() {
        var form = $("#add-receipt").find("form");

        form.validate();
        form.find('input[type="number"]').rules("add", {
            required: true,
            messages: {
                required: text.ThisFieldIsRequired
            }
        });

        $("#add-receipt").dialog({
            autoOpen: false,
            buttons: [
            {
                text: text.OK,
                click: function () {
                    $(this).find("form").valid();
                }
            }]
        });

        $("#add-receipt").find("button").on("click", nextReceiptEntryClick);

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