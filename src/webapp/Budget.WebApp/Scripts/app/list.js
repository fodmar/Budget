define(['app/template', 'jquery'], function (template) {
    function loadObjects(load) {
        return $.ajax({
            url: load.url,
            method: "GET",
            data: load.params
        });
    };

    function fillTemplate(config, objects) {
        var elementTemplate = document.getElementById(config.templateId).innerHTML;
        var container = $(document.getElementById(config.containerId));

        objects.forEach(function (item) {
            var element = template.fill(elementTemplate, item);
            container.append(element);
        });
    };

    function createList(config) {

        loadObjects(config.load).done(function (objects) {
            fillTemplate(config, objects);
        });
    };

    return {
        createList: createList
    };
});