requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', ko);
define('moment', moment);

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'services/logger', 'services/bindings'], function (system, app, viewLocator, logger, koBindings) {

    // Enable debug message to show in the console 
    system.debug(true);

    app.title = 'uManage';

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    // Initialize custom Knockout bindings
    koBindings.init();

    // Toastr settings
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.options.backgroundpositionClass = 'toast-bottom-right';

    // Timer allows for testing of splash page
    setTimeout(function () {
        app.start().then(function () {
            viewLocator.useConvention();
            app.setRoot('viewmodels/shell', 'entrance');
        });
    }, 0);
});