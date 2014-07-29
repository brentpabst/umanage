define(['plugins/router', 'services/datacontext'], function (router, ctx) {
    var userInfoExpandContract = function() {
            // Changes the caret when the user clicks the user info panel
            router.on('router:navigation:composition-complete', function() {
                $('#user-extended').on('show.bs.collapse', function() {
                    $('.user-info-expand span').removeClass('fa-caret-down').addClass('fa-caret-up');
                });
            });
            router.on('router:navigation:composition-complete', function() {
                $('#user-extended').on('hide.bs.collapse', function() {
                    $('.user-info-expand span').removeClass('fa-caret-up').addClass('fa-caret-down');
                });
            });
        },
        currentUser = ko.observable(),
        loadCurrentUser = function() {
            ctx.currentUser(currentUser);
        };
    return {
        router: router,
        currentUser: currentUser,
        activate: function () {
            router.map([
                { route: '', title: 'Home', moduleId: 'viewmodels/home', nav: true, iconClass: 'fa fa-home fa-fw fa-lg', displayLink: true },
                { route: 'my/info', title: 'My Information', moduleId: 'viewmodels/my/info', nav: false, iconClass: '', displayLink: false },
                { route: 'my/account', title: 'My Account', moduleId: 'viewmodels/my/account', nav: false, iconClass: '', displayLink: false },
                { route: 'my/password', title: 'My Password', moduleId: 'viewmodels/my/password', nav: false, iconClass: '', displayLink: false },
                { route: '', title: 'Administration', moduleId: 'viewmodels/admin/dash', nav: true, iconClass: 'fa fa-dashboard fa-fw fa-lg', displayLink: false },
                { route: 'admin/dash', title: 'Dashboard', moduleId: 'viewmodels/admin/dash', nav: true, iconClass: 'fa fa-dashboard fa-fw fa-lg', displayLink: true },
                { route: 'admin/users', title: 'Users', moduleId: 'viewmodels/admin/users', nav: true, iconClass: 'fa fa-users fa-fw fa-lg', displayLink: true },
                { route: 'admin/groups', title: 'Groups', moduleId: 'viewmodels/admin/groups', nav: true, iconClass: 'fa fa-key fa-fw fa-lg', displayLink: true },
                { route: 'admin/settings', title: 'Settings', moduleId: 'viewmodels/admin/settings', nav: true, iconClass: 'fa fa-cog fa-fw fa-lg', displayLink: true }
            ]).buildNavigationModel()
              .mapUnknownRoutes('viewmodels/404', '404')
              .activate();

            userInfoExpandContract();
            loadCurrentUser();
        }
    };
});