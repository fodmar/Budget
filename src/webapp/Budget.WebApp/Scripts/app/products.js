define(["app/list"], function (list) {

    function init() {
        var config = {
            template: "#product-list",
            container: "#product-list-container",
            load: {
                url: "/Product/GetProducts"
            },
            delete: {
                url: "/Product/Delete",
                target: ".delete",
                entry: ".entry"
            }
        };

        list.createList(config);
    };

    return {
        init: init
    };
});