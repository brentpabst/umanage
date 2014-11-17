'use strict';

angular.module('umsApp', [
    'ngRoute',
    'ngSanitize'
]).config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({ redirectTo: '/home' });
    }
]).config([
    '$logProvider', function ($logProvider) {
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
}]);