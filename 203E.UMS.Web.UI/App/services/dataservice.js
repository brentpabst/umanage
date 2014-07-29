define(['plugins/http'], function (http) {
    "use strict";

    var currentUser = function () {
        return http.get('/api/users/me');
    };

    return {
        currentUser: currentUser
    }
});