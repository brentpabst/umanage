"use strict";

/* App Module */

var ums = angular.module("ums", [
    "ngRoute",
    "ngSanitize",
    "ngResource",
    "angular-loading-bar",

    "umsRouting",
    "umsControllers",
    "umsServices",
    "umsFilters"
]);

ums.run([
    "$rootScope", "$route", "currentUser", function ($rootScope, $route, currentUser) {
        // Get view change events
        $rootScope.$on("$routeChangeSuccess", function (event, current, previous) {
            if ($route && $route.current && $route.current.title) {
                $rootScope.title = $route.current.title;
            }
        });

        // Load the user's basic information
        $rootScope.currentUser = currentUser.query();
    }
]);

ums.config(["$logProvider", function ($logProvider) {
    if ($logProvider.debugEnabled) {
        console.log("Debugging Enabled");
        $logProvider.debugEnabled(true);
    }
}]);