define(['app/text', 'app/template', 'lib/locale-all', 'jqueryUi', 'jqueryValidate'], function (text, template) {
    var currentEntryIndex = 1;

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
        var entryTemplate = $("#entry-template").html();

        var newEntry = $(template.fill(entryTemplate, { index: currentEntryIndex }));
        currentEntryIndex++;

        newEntry.insertBefore(button);

        newEntry.find(".js-required").each(function (index, value) {
            addRequiredRule($(value));
        });
    };

    function deleteReceiptEntryClick(event) {
        $(event.target).closest(".js-entry").remove();
    }

    function init() {
        var containter = $("#add-receipt");
        var form = containter.find("form");
        form.validate();

        form.find('input[type="datetime"]').each(function (index, value) {
            $(value).attr("type", "datetime-local");
        });

        form.find("input").each(function (index, value) {
            addRequiredRule($(value));
        });

        form.on("click", ".delete-icon", deleteReceiptEntryClick);

        var addButton = form.find("button");
        addButton.on("click", nextReceiptEntryClick);

        var click = jQuery.Event("click");
        click.target = addButton;
        addButton.trigger(click);

        containter.dialog({
            autoOpen: false,
            title: text.NewExpense,
            position: { my: "top", at: "top", of: $("#calendar") },
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