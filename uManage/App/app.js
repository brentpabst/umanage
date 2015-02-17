'use strict';

/* App Module */

var ums = angular.module('ums', [
    'ngRoute',
    'ngSanitize',

    'umsRouting'
]);

ums.run([
    '$rootScope', '$route', function($rootScope, $route) {
        $rootScope.$on('$routeChangeSuccess', function(event, current, previous) {
            if (current && current.$$route && current.$$route.title) {
                $rootScope.title = current.$$route.title;
            }
        });
    }
]);

ums.config(['$logProvider', function ($logProvider) {
    if ($logProvider.debugEnabled) {
        $logProvider.debugEnabled(true);
    }
}]);