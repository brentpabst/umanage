'use strict';

/* Routing */

var routing = angular.module('umsRouting', ['ngRoute']);

routing.config(['$routeProvider', 'routes', routeConfigurator]);
routing.constant('routes', getRoutes());

function routeConfigurator($routeProvider, routes) {
    routes.forEach(function (r) {
        $routeProvider.when(r.url, r.config);
    });
    //todo: for some reason this is preventing routes from working properly
    $routeProvider.otherwise({ redirectTo: '/' });
}

function getRoutes() {
    return [
        { url: '/', config: { templateUrl: 'app/views/home/home.html', title: 'Home', settings: { content: '<i class="fa fa-home fa-fw fa-lg"></i>&nbsp; Home', nav: true } } },
        { url: 'my/info', config: { templateUrl: 'app/views/my/info.html', title: 'My Information', settings: { nav: false } } },
        { url: 'my/account', config: { templateUrl: 'app/views/my/account.html', title: 'My Account', settings: { nav: false } } },
        { url: 'my/password', config: { templateUrl: 'app/views/my/password.html', title: 'My Password', settings: { nav: false } } },
	    { url: '', config: { templateUrl: '', title: 'Administration', settings: { content: 'Administration', hideLink: true, nav: true } } },
        { url: 'admin/dash', config: { templateUrl: '', title: 'Dashboard', settings: { content: '<i class="fa fa-dashboard fa-fw fa-lg"></i>&nbsp; Dashboard', nav: true } } },
        { url: 'admin/users', config: { templateUrl: '', title: 'Users', settings: { content: '<i class="fa fa-users fa-fw fa-lg"></i>&nbsp; Users', nav: true } } },
        { url: 'admin/groups', config: { templateUrl: '', title: 'Groups', settings: { content: '<i class="fa fa-key fa-fw fa-lg"></i>&nbsp; Groups', nav: true } } },
        { url: 'admin/settings', config: { templateUrl: '', title: 'Settings', settings: { content: '<i class="fa fa-cog fa-fw fa-lg"></i>&nbsp; Settings', nav: true } } }
    ];
}