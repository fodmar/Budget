define(["app/list", "app/text"], function (list, text) {

    function init() {
        var config = {
            template: "#product-list",
            container: "#product-list-container",
            entry: ".entry",
            load: {
                url: "/Product/GetProducts"
            },
            remove: {
                url: "/Product/Delete",
                target: ".delete",
            },
            add: {
                url: "/Product/Add",
                target: "#add",
                title: text.AddNewProduct,
                properties: [{
                    name: "Name",
                    display: text.Name
                }]
            },
            update: {
                url: "/Product/Update",
                target: ".update",
                title: text.ModifyProduct,
                properties: [{
                    name: "Id",
                    hidden: true
                }, {
                    name: "Name",
                    display: text.Name
                }]
            }
        };

        list.createList(config);
    };

    return {
        init: init
    };
});