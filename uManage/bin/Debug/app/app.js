'use strict';

angular.module('umsApp', [
    'ngRoute'
]).config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({ redirectTo: '/home' });
    }
]);