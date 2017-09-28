define(['app/btnloader', 'jqueryValidateUnobtrusive'], function (btnloader) {
    return {
        init: function () {
            $("#Login").focus();

            var form = $(".login-form").find("form");
            var submitButton = form.find("button");

            form.on("submit", function (event) {
                if (form.validate().checkForm()) {
                    btnloader.before.bind(submitButton)();
                }
            });
        }
    };
});