define(['durandal/system',
    'services/logger',
    'durandal/plugins/router',
    'durandal/app',
    'config'],
function (system, logger, router, app, config) {

    var shell = {
        activate: activate,
        router: router
    };
    return shell;

    function activate() {
        app.title = config.appTitle;
        boot();
    }

    function boot() {
        logger.log('uManage Loaded!', null, system.getModuleId(shell), true);
        router.map(config.routes);
        return router.activate(config.startModule);
    }
});