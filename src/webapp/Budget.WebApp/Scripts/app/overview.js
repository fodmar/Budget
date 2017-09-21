define(['app/overview-calendar', 'app/text', 'app/template', 'app/btnloader', 'jqueryUi', 'jqueryValidate'], function (calendar, text, template, btnloader) {
    var currentEntryIndex = 1;

    function addReceipt() {
        var container = $("#add-receipt");
        var nextEntryBtn = $("#next-receipt-entry");

        container.find(".js-entry").remove();
        currentEntryIndex = 1;

        var click = jQuery.Event("click");
        click.target = nextEntryBtn;
        nextEntryBtn.trigger(click);

        container.dialog("open");
    };

    function postForm(form) {
        return $.ajax({
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

        var newEntry = $(template.fillElementById("entry-template", { index: currentEntryIndex }));
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
        calendar.init({
            addReceipt: addReceipt
        });

        var containter = $("#add-receipt");
        var form = containter.find("form");
        form.validate();

        form.find("input").each(function (index, value) {
            addRequiredRule($(value));
        });

        form.on("click", ".delete-icon", deleteReceiptEntryClick);
        $("#next-receipt-entry").on("click", nextReceiptEntryClick)

        containter.dialog({
            autoOpen: false,
            title: text.NewExpense,
            position: { my: "top", at: "top", of: $("#calendar") },
            buttons: [
            {
                text: text.OK,
                click: function (event) {
                    var dialogWindow = $(this);
                    var form = dialogWindow.find("form");

                    if (form.valid()) {
                        var button = $(event.target);

                        btnloader.loader(function () {
                            return postForm(form);
                        }, {
                            after: function (receipt) {
                                calendar.addEvent(receipt);
                                btnloader.after.apply(button);
                                dialogWindow.dialog("close");
                            }
                        }).apply(button);
                    }
                }
            }]
        });
    };

    return {
        init: init
    };
});