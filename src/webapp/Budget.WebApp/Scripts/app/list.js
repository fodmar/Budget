define(['app/template', 'jquery'], function (template) {
    var objects;

    function loadObjects(load) {
        return $.ajax({
            url: load.url,
            method: "GET",
            data: load.params
        });
    };

    function deleteObject(object, url) {
        return $.ajax({
            url: url,
            method: "DELETE",
            data: object
        });
    };


    function fillTemplate(container, elementTemplate, objects) {
        var index = 0;

        objects.forEach(function (item) {
            var element = $(template.fill(elementTemplate, item));
            element.attr("index", index++);
            container.append(element);
        });
    };

    function initDelete(container, deleteConfig) {
        container.on("click", deleteConfig.target, function (event) {
            var entry = $(event.target).closest(deleteConfig.entry);
            var entryIndex = entry.attr("index");

            var toDelete = objects[entryIndex];

            deleteObject(toDelete, deleteConfig.url).done(function () {
                entry.remove();
                objects[entryIndex] = null;
            });
        });
    };

    function createList(config) {
        loadObjects(config.load).done(function (result) {
            objects = result;

            var elementTemplate = $(config.template).html();
            var container = $(config.container);

            fillTemplate(container, elementTemplate, result);

            if (config.delete) {
                initDelete(container, config.delete);
            }
        });
    };

    return {
        createList: createList
    };
});