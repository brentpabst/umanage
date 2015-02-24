'use strict';

/* Routing */

var routing = angular.module('umsRouting', ['ngRoute']);

routing.config(['$routeProvider', function($routeProvider) {
    $routeProvider
        .when('/', { templateUrl: 'app/views/home/home.html', controller: 'HomeCtrl', title: 'Dashboard' })
        .when('/404', { templateUrl: 'app/views/404.html', title: 'Not Found!' })
        .when('/my', { templateUrl: 'app/views/my/info.html', controller: 'MeCtrl', title: 'My Info'})
        .when('/my/account', { templateUrl: 'app/views/my/account.html', controller: 'MeCtrl', title: 'My Account' })
        .when('/my/password', { templateUrl: 'app/views/my/password.html', controller: 'MeCtrl', title: 'My Password' })
        .otherwise({ redirectTo: '/404' });
}]);