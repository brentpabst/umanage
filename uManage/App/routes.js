"use strict";

/* Routing */

var routing = angular.module("umsRouting", ["ngRoute"]);

routing.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/", { templateUrl: "app/views/home/home.html", controller: "HomeCtrl", title: "Dashboard" })
        .when("/home", { redirectTo: "/" })
        .when("/404", { templateUrl: "app/views/404.html", title: "Not Found!" })
        .when("/me", { templateUrl: "app/views/me/info.html", controller: "MeCtrl", title: "My Info" })
        .when("/me/account", { templateUrl: "app/views/me/account.html", controller: "MeCtrl", title: "My Account" })
        .when("/me/password", { templateUrl: "app/views/me/password.html", controller: "MeCtrl", title: "My Password" })
        .otherwise({ redirectTo: "/404" });
}]);