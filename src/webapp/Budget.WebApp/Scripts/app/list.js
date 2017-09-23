define(['app/template', 'app/btnloader', 'app/text', 'jquery', 'jqueryUi', 'jqueryValidate'], function (template, btnloader, text) {
    var objects;
    var objectsContainer;
    var objectTemplate;

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

    function addObject(object, url) {
        return $.ajax({
            url: url,
            method: "PUT",
            data: object
        });
    };

    function fillTemplate() {
        objects.forEach(function (item, index) {
            var element = $(template.fill(objectTemplate, item));
            element.attr("index", index);
            objectsContainer.append(element);
        });
    };

    function appendObject(object) {
        objects.push(object);
        var element = $(template.fill(objectTemplate, object));
        element.attr("index", objects.length);
        objectsContainer.append(element);
    }

    function initDelete(config) {
        var removeConfig = config.remove;

        objectsContainer.on("click", removeConfig.target, function (event) {
            var entry = $(event.target).closest(config.entry);
            var entryIndex = entry.attr("index");

            var toDelete = objects[entryIndex];

            deleteObject(toDelete, removeConfig.url).done(function () {
                entry.remove();
                objects[entryIndex] = null;
            });
        });
    };

    function initAdd(config) {
        var addConfig = config.add;

        var addDialog = $('<div id="list-add-dialog" hidden="hidden"></div>')
        var dialogForm = $('<form></form>');
        dialogForm.validate();

        var properties = addConfig.properties;

        properties.forEach(function (prop) {
            dialogForm.append($("<label for='{0}'>{1}</label>".format(prop.name, prop.display)));
            var input = $("<input name='{0}' type='text'></input>".format(prop.name));

            dialogForm.append(input);

            input.rules("add", {
                required: true,
                messages: {
                    required: text.ThisFieldIsRequired
                }
            });
        });

        addDialog.append(dialogForm);
        addDialog.dialog({
            autoOpen: false,
            title: addConfig.title,
            buttons: [{
                text: text.OK,
                click: function (event) {
                    var window = $(this);
                    var form = window.find("form");

                    if (form.valid()) {
                        var button = $(event.target);

                        btnloader.loader(function () {
                            return addObject(form.serialize(), config.add.url);
                        }, {
                            after: function (object) {
                                appendObject(object);

                                btnloader.after.apply(button);
                                window.dialog("close");
                            }
                        }).apply(button);
                    }
                }
            }]
        });

        objectsContainer.on("click", addConfig.target, function (event) {
            addDialog.dialog("open");
        });
    };

    function createList(config) {
        loadObjects(config.load).done(function (result) {
            objects = result;
            objectTemplate = $(config.template).html();
            objectsContainer = $(config.container);

            fillTemplate();

            if (config.remove) {
                initDelete(config);
            }

            if (config.add) {
                initAdd(config)
            }
        });
    };

    return {
        createList: createList
    };
});