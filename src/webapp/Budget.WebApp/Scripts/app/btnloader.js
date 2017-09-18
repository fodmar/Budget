define(["app/callwrapper", "app/text", "jquery"], function (callwrapper, text) {

    function before() {
        var button = $(this);

        button.attr("disabled", true);
        button.attr("original-text", button.text());
        button.text(text.PleaseWait);
        button.prepend('<div class="loader"></div>');
    };

    function after() {
        var button = $(this);
        button.find("div.loader").remove();
        button.text(button.attr("original-text"));
        button.attr("disabled", false);
    };

    function loader(callback, options) {
        var functions = {
            before: options.before || before,
            after: options.after || after,
        };

        return callwrapper.wrap(callback, functions);
    };

    return {
        loader: loader,
        before: before,
        after: after
    };
});