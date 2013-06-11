define(['durandal/system', 'durandal/plugins/router', 'services/logger'],
    function (system, router, logger) {
        var shell = {
            activate: activate,
            router: router
        };

        return shell;

        //#region Internal Methods
        function activate() {
            return boot();
        }

        function boot() {
            router.mapNav('dashboard', null, 'Dashboard').settings = { admin: false };
            router.mapNav('my/info', null, 'Information').settings = { admin: false };
            router.mapNav('my/account', null, 'Account').settings = { admin: false };
            router.mapNav('my/password', null, 'Password').settings = { admin: false };
            router.mapNav('my/photo', null, 'Photo').settings = { admin: false };
            log('uManage Loaded!', null, true);
            return router.activate('dashboard');
        }

        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(shell), showToast);
        }
        //#endregion
    });