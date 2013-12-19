define(['durandal/system', 'plugins/router'], function (system, router) {
    return {
        date: moment().utc(),
        router: router,
        activate: function () {
            router.map([
            { route: '', title: 'Dashboard', moduleId: 'viewmodels/dashboard', nav: true },
            { route: 'dashboard', title: 'Dashboard', moduleId: 'viewmodels/dashboard', nav: true },
            { route: 'my/info', title: 'Information', moduleId: 'viewmodels/my/info', nav: true },
            { route: 'my/account', title: 'Account', moduleId: 'viewmodels/my/account', nav: true },
            { route: 'my/password', title: 'Password', moduleId: 'viewmodels/my/password', nav: true },
            { route: 'my/photo', title: 'Photo', moduleId: 'viewmodels/my/photo', nav: true }
            ]).buildNavigationModel()
                .mapUnknownRoutes('viewmodels/404', '404')
                .activate();
        }
    };
});