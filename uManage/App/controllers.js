"use strict";

var controllers = angular.module("umsControllers", []);

controllers.controller("ShellCtrl", ["$rootScope", "$route", "$scope",
    function ($rootScope, $route, $scope) {
        //$scope.routes = $route.routes;

        function activate() {
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