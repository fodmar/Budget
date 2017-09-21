define(["app/list"], function (list) {

    function init() {
        var config = {
            templateId: "product-list",
            containerId: "product-list-container",
            load: {
                url: "/Product/GetProducts",
            }
        };

        list.createList(config);
    };

    return {
        init: init
    };
});