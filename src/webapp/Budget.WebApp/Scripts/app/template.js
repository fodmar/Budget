define([], function () {
    function fill(template, data) {
        return template.replace(/{{ (.*?) }}/g, function (fullmatch, group) {
            return data[group] || "";
        });
    };

    function fillElementById(id, data) {
        var element = document.getElementById(id).innerHTML;

        return fill(element, data);
    }

    return {
        fill: fill,
        fillElementById: fillElementById
    };
});