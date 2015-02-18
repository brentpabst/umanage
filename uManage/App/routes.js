'use strict';

/* Routing */

var routing = angular.module('umsRouting', ['ngRoute']);

routing.config(['$routeProvider', function($routeProvider) {
    $routeProvider
        .when('/', { templateUrl: 'app/views/home/home.html', controller: 'HomeCtrl' })
        .when('/404', { templateUrl: 'app/views/404.html' })
        .when('/my', { templateUrl: 'app/views/my/info.html', controller: 'MeCtrl' })
        .when('/my/account', { templateUrl: 'app/views/my/account.html', controller: 'MeCtrl' })
        .when('/my/password', { templateUrl: 'app/views/my/password.html', controller: 'MeCtrl' })
        .otherwise({ redirectTo: '/404' });
}]);