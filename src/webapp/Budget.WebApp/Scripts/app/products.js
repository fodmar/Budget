define(["app/list", "app/text"], function (list, text) {

    function init() {
        var containerSelector = "#product-list-container";
        $(containerSelector).on("mouseenter mouseleave", ".icon", function (event) {
            var div = $(event.target).closest(".entry");

            if (event.type === "mouseenter") {
                div.css("background-color", "silver");
            } else {
                div.css("background-color", "white");
            }
        });


        var config = {
            template: "#product-list",
            container: containerSelector,
            entry: ".entry",
            load: {
                url: "/Product/GetProducts"
            },
            remove: {
                url: "/Product/Delete",
                target: ".icon.delete",
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
                target: ".icon.update",
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