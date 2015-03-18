"use strict";

var controllers = angular.module("umsControllers", []);

controllers.controller("ShellCtrl", ["$rootScope", "$route", "$location", "$scope",
    function ($rootScope, $route, $location, $scope) {
        $scope.routes = [];

        $scope.isActive = function(viewLocation) {
            return viewLocation === $location.path();
        }

        function activate() {
            // Load Menu
            angular.forEach($route.routes, function (route) {
                if (route.title && route.navEnabled) {
                    $scope.routes.push(route);
                }
            });

            // Load the user's bootstrap info here
            console.log("Shell Loaded");
        }

        activate();
    }
]);

controllers.controller("HomeCtrl", [
    "$scope",
    function ($scope) {
        // Do something on the home page..
    }
]);

controllers.controller("MeCtrl", [
    "$scope",
    function ($scope) {
        // Do something on the user's pages..
    }
]);