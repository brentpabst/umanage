define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        year: moment().utc().year(),
        router: router,
        activate: function () {
            router.map([
                { route: '', title: 'Dashboard', moduleId: 'viewmodels/dash', nav: true }
            ]).buildNavigationModel()
              .activate();
        }
    };
});

