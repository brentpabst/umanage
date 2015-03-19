"use strict";

/* Services */

var services = angular.module("umsServices", ["ngResource"]);

services.factory("currentUser", [
    "$resource",
    function ($resource) {
        return $resource("/api/users/me", {}, {
            query: { method: "GET", params: {}, isArray: false }
        });
    }]);