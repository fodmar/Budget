define(["app/callwrapper", "app/text", "jquery"], function (callwrapper, text) {

    function before(event) {
        var button = $(this);

        button.attr("original-text", button.text());
        button.text(text.PleaseWait);
        button.prepend('<div class="loader"></div>');
    };

    function after(event) {
        var button = $(this);
        button.find("div.loader").remove();
        button.text(button.attr("original-text"));
    };

    function loader(callback) {
        var functions = {
            before: before,
            after: after
        };

        return callwrapper.wrap(callback, functions);
    };

    return {
        loader: loader,
        before: before,
        after: after
    };
});