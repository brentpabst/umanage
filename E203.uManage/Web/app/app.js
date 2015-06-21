"use strict";

var ums = angular.module('ums', [
    'ngMaterial',
    "ngAnimate",
    "ngAria",
    "ngRoute",
    "ngSanitize",
    "ngResource",
]);

//ums.run([

//]);

ums.config(["$mdThemingProvider", function($mdThemingProvider) {
        $mdThemingProvider.theme("default")
            .primaryPalette("grey")
            .accentPalette("blue");
    }
])