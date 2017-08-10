requirejs.config({
    baseUrl: '/Scripts',
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
        moment: 'lib/moment'
    },
    shim: {
        jqueryValidateUnobtrusive: {
            deps: ['jqueryValidate']
        },
        'lib/locale-all': {
            deps: ['lib/fullcalendar']
        }
    }
});