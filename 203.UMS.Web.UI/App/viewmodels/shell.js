define(['plugins/router', 'durandal/app', 'data/users'], function (router, app, users) {
    var user = ko.observable();

    return {
        year: moment().utc().year(),
        router: router,
        user: users.currentUser,
        activate: function () {
            router.map([
                { route: '', title: 'Dashboard', moduleId: 'viewmodels/dash', nav: true },
                { route: 'my/info', title: 'My Information', moduleId: 'viewmodels/my/info', nav: true },
                { route: 'my/account', title: 'My Account', moduleId: 'viewmodels/my/account', nav: true },
                { route: 'my/password', title: 'My Password', moduleId: 'viewmodels/my/password', nav: true },
                { route: 'my/photo', title: 'My Photo', moduleId: 'viewmodels/my/photo', nav: true }
            ]).buildNavigationModel()
              .activate();
        }
    };
});