'use strict';

var controllers = angular.module('umsControllers', []);

controllers.controller('ShellCtrl', ['$rootScope',
    function ($rootScope) {
        var vm = this;

        activate();
        function activate() {
            // Load the user's bootstrap info here
            console.log("Shell Loaded");
        }
    }
]);

controllers.controller('HomeCtrl', [
    '$scope',
    function ($scope) {
        // Do something on the home page..
    }
]);

controllers.controller('MeCtrl', [
    '$scope',
    function ($scope) {
        // Do something on the user's pages..
    }
]);