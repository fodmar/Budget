define([], function () {
    function fill(template, data) {
        return template.replace(/{{ (.*?) }}/gi, function (fullmatch, group) {
            return data[group];
        });
    };

    return {
        fill: fill
    };
});