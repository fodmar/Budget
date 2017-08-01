requirejs.config({
    baseUrl: '/Scripts',
    paths: {
        app: 'app',
        lib: 'lib',
        jquery: 'lib/jquery-3.1.1',
        jqueryValidate: 'lib/jquery.validate',
        jqueryValidateUnobtrusive: 'lib/jquery.validate.unobtrusive'
    },
    shim: {
        jqueryValidate: {
            deps: ['jquery']
        },
        jqueryValidateUnobtrusive: {
            deps: ['jqueryValidate']
        }
    }
});