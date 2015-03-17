"use strict";

/* App Module */

var ums = angular.module("ums", [
    "ngRoute",
    "ngSanitize",
    "ngResource",

    "umsRouting",
    "umsControllers"
]);

ums.run([
    "$rootScope", "$route", function ($rootScope, $route) {
        $rootScope.$on("$routeChangeSuccess", function (event, current, previous) {
            if ($route && $route.current && $route.current.title) {
                $rootScope.title = $route.current.title;
            }
        });
    }
]);

ums.config(["$logProvider", function ($logProvider) {
    if ($logProvider.debugEnabled) {
        console.log("Debugging Enabled");
        $logProvider.debugEnabled(true);
    }
}]);