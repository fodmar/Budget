define(['app/template', 'app/btnloader', 'app/text', 'jquery', 'jqueryUi', 'jqueryValidate'], function (template, btnloader, text) {
    var objects;
    var objectsContainer;
    var objectTemplate;

    function callAjax(url, data, method) {
        return $.ajax({
            url: url,
            method: method || "GET",
            data: data
        });
    };

    function fillTemplate() {
        objects.forEach(function (item, index) {
            var element = $(template.fill(objectTemplate, item));
            element.attr("index", index);
            objectsContainer.append(element);
        });
    };

    function createForm(properties) {
        var form = $("<form></form>");
        form.validate();

        properties.forEach(function (prop) {
            var input;

            if (prop.hidden) {
                input = $("<input name='{0}' type='hidden'></input>".format(prop.name));
            } else {
                form.append($("<label for='{0}'>{1}</label>".format(prop.name, prop.display)));
                input = $("<input name='{0}' type='text'></input>".format(prop.name));
            }

            form.append(input);

            input.rules("add", {
                required: true,
                messages: {
                    required: text.ThisFieldIsRequired
                }
            });
        });

        return form;
    };

    function createDialog(title, actions) {
        return {
            autoOpen: false,
            title: title,
            buttons: [{
                text: text.OK,
                click: function (event) {
                    var window = $(this);
                    var form = window.find("form");

                    if (form.valid()) {
                        var button = $(event.target);

                        btnloader.loader(function () {
                            return actions.before(form);
                        }, {
                            after: function (object) {
                                actions.after(object, form);

                                btnloader.after.apply(button);
                                window.dialog("close");
                            }
                        }).apply(button);
                    }
                }
            }]
        }
    };

    function fillForm(form, object) {
        for (prop in object) {
            if (object.hasOwnProperty(prop)) {
                form.find("input[name={0}]".format(prop)).val(object[prop]);
            }
        }
    };

    function appendObject(object) {
        objects.push(object);
        var element = $(template.fill(objectTemplate, object));
        element.attr("index", objects.length);
        objectsContainer.append(element);
    };

    function replaceObject(object, index) {
        objects[index] = object;
        var element = $(template.fill(objectTemplate, object));
        element.attr("index", index);
        objectsContainer.find("[index={0}]".format(index)).replaceWith(element);
    };

    function initRemove(config) {
        var removeConfig = config.remove;

        objectsContainer.on("click", removeConfig.target, function (event) {
            var entry = $(event.target).closest(config.entry);
            var entryIndex = entry.attr("index");

            var toDelete = objects[entryIndex];

            callAjax(removeConfig.url, toDelete, "DELETE").done(function () {
                entry.remove();
                objects[entryIndex] = null;
            });
        });
    };

    function initAdd(config) {
        var addConfig = config.add;
        var addDialog = $('<div hidden="hidden"></div>')
        var dialogForm = createForm(addConfig.properties);

        addDialog.append(dialogForm);
        addDialog.dialog(createDialog(addConfig.title, {
            before: function (form) {
                return callAjax(config.add.url, form.serialize(), "PUT");
            },
            after: function (object) {
                appendObject(object);
            }
        }));

        $(addConfig.target).on("click", function (event) {
            addDialog.dialog("open");
        });
    };

    function initUpdate(config) {
        var updateConfig = config.update;

        var updateDialog = $('<div hidden="hidden"></div>')
        var dialogForm = createForm(updateConfig.properties);

        updateDialog.append(dialogForm);
        updateDialog.dialog(createDialog(updateConfig.title, {
            before: function (form) {
                return callAjax(updateConfig.url, form.serialize(), "POST");
            },
            after: function (object, form) {
                var index = form.attr("index");
                replaceObject(object, index);
            }
        }));

        objectsContainer.on("click", updateConfig.target, function (event) {
            var index = $(event.target).closest(config.entry).attr("index");
            var object = objects[index];

            fillForm(dialogForm, object);
            dialogForm.attr("index", index);

            updateDialog.dialog("open");
        });
    };

    function createList(config) {
        callAjax(config.load.url).done(function (result) {
            objects = result;
            objectTemplate = $(config.template).html();
            objectsContainer = $(config.container);

            fillTemplate();

            if (config.remove) initRemove(config);
            if (config.add) initAdd(config);
            if (config.update) initUpdate(config);
        });
    };

    return {
        createList: createList
    };
});