define(['app/text', 'lib/locale-all', 'jqueryUi', 'jqueryValidate'], function (text) {
    function addreceipt() {
        $("#add-receipt").dialog("open");
    };

    function postForm(form) {
        $.ajax({
            url: "/Overview/SaveReceipt",
            method: "POST",
            data: form.serialize()
        });
    }

    function addRequiredRule(element) {
        element.rules("add", {
            required: true,
            messages: {
                required: text.ThisFieldIsRequired
            }
        });
    }

    function nextReceiptEntryClick(event) {
        var button = $(event.target);
        var parent = button.prev();
        var child = parent.clone();

        var currentIndex = parseInt(parent.attr("data-index")) + 1;
        child.attr("data-index", currentIndex);

        var currentName = parent.data("name") + "[" + currentIndex + "].Amount";
        child.find("label").attr("for", currentName);

        var input = child.find("input");
        input.attr("name", currentName);

        child.insertBefore(button);

        addRequiredRule(input);
    };

    function init() {
        var form = $("#add-receipt").find("form");
        form.validate();

        form.find('input[type="datetime"]').each(function (index, value) {
            $(value).attr("type", "datetime-local");
        });

        form.find("input").each(function (index, value) {
            addRequiredRule($(value));
        });

        $("#add-receipt").dialog({
            autoOpen: false,
            buttons: [
            {
                text: text.OK,
                click: function () {
                    var form = $(this).find("form");

                    if (form.valid()) {
                        postForm(form);
                        $(this).dialog("close");
                    }
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