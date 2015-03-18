"use strict";

/* Routing */

var routing = angular.module("umsRouting", ["ngRoute"]);

routing.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/", { templateUrl: "app/views/home/home.html", controller: "HomeCtrl", title: "Home", navEnabled: true, navContent: "<i class=\"fa fa-home fa-fw fa-lg\"></i>&nbsp; Home</a>" })
        .when("/home", { redirectTo: "/" })
        .when("/dashboard", { title: "Dashboard", navEnabled: true, navContent: "<i class=\"fa fa-dashboard fa-fw fa-lg\"></i>&nbsp; Dashboard</a>" })
        .when("/people", { title: "People", navEnabled: true, navContent: "<i class=\"fa fa-users fa-fw fa-lg\"></i>&nbsp; People</a>" })
        .when("/groups", { title: "Groups", navEnabled: true, navContent: "<i class=\"fa fa-key fa-fw fa-lg\"></i>&nbsp; Groups</a>" })
        .when("/settings", { title: "Settings", navEnabled: true, navContent: "<i class=\"fa fa-cog fa-fw fa-lg\"></i>&nbsp; Settings</a>" })
        .when("/me", { templateUrl: "app/views/me/info.html", controller: "MeCtrl", title: "My Info" })
        .when("/me/account", { templateUrl: "app/views/me/account.html", controller: "MeCtrl", title: "My Account" })
        .when("/me/password", { templateUrl: "app/views/me/password.html", controller: "MeCtrl", title: "My Password" })
        .when("/404", { templateUrl: "app/views/404.html", title: "Not Found!" })
        .otherwise({ redirectTo: "/404" });
}]);