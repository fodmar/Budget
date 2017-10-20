if (!getBaseUrl) {
    function getBaseUrl() {
        return "/Scripts";
    };
}

requirejs.config({
    config: {
        "i18n": {
            locale: document.body.getAttribute("lang")
        }
    },
    baseUrl: getBaseUrl(),
    urlArgs: '',
    paths: {
        app: 'app',
        lib: 'lib',
        nls: 'nls',
        jquery: 'lib/jquery-3.1.1',
        jqueryUi: 'lib/jquery-ui-1.12.1',
        jqueryValidate: 'lib/jquery.validate',
        jqueryValidateUnobtrusive: 'lib/jquery.validate.unobtrusive',
        i18n: 'lib/i18n',
        moment: 'lib/moment',
        jasmine: 'jasmine-2.8.0',
        spec: 'spec'
    },
    shim: {
        jqueryValidateUnobtrusive: {
            deps: ['jqueryValidate']
        },
        'lib/locale-all': {
            deps: ['lib/fullcalendar']
        },
        'jasmine/jasmine-html': {
            deps: ['jasmine/jasmine']
        },
        'jasmine/boot': {
            deps: ['jasmine/jasmine', 'jasmine/jasmine-html']
        }
    }
});