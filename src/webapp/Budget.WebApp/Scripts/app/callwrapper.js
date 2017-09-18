define(['jquery'], function () {

    function wrap(callback, functions) {
        return function () {
            var promise = $.Deferred();
            var orignialArgs = arguments;

            if (typeof functions.before === "function") {
                functions.before.apply(this, orignialArgs);
            }

            $.when(callback.apply(this, orignialArgs)).always(function (result) {
                if (typeof functions.after === "function") {
                    var original = [].slice.call(orignialArgs);
                    var current = [].slice.call(arguments);

                    functions.after.apply(this, original.concat(current));
                }

                promise.resolve(result);
            });

            return promise;
        };
    };

    return {
        wrap: wrap
    };
});