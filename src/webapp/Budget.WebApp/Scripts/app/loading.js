define(['jquery'], function () {

    function loading(callback) {
        return function () {
            var target = $(this);
            target.addClass("loading");

            $.when(callback.apply(this, arguments)).always(function () {
                target.removeClass("loading");
            });
        };
    };

    return {
        loading: loading
    };
});