"use strict";

/* Global Filters */

var filters = angular.module("umsFilters", []);

filters.filter("fromNow", ["$window",
    function ($window) {
        return function (date) {
            return $window.moment(date).fromNow();
        }
    }
]);