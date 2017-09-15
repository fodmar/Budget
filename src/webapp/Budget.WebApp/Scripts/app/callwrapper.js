define(['jquery'], function () {

    function wrap(callback, functions) {
        return function () {
            var orignialArgs = arguments;

            if (typeof functions.before === "function") {
                functions.before.apply(this, orignialArgs);
            }

            $.when(callback.apply(this, arguments)).always(function () {
                if (typeof functions.after === "function") {
                    functions.after.apply(this, orignialArgs);
                }
            });
        };
    };

    return {
        wrap: wrap
    };
});