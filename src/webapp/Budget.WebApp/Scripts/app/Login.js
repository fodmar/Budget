define(['app/btnloader', 'jqueryValidateUnobtrusive'], function (btnloader) {
    return {
        init: function () {
            //$("button").on("click", btnloader.loader(function () {
            //    var promise = $.Deferred();

            //    setTimeout(function () {
            //        promise.resolve();
            //    }, 2000);

            //    return promise;
            //}));

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