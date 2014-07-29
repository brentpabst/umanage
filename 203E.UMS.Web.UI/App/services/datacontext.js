define(['services/dataservice'], function (dataservice) {
    "use strict";

    var currentUser = function (results) {
        return dataservice.currentUser()
            .then(function (data) {
                results(data);
            });
    };

    return {
        currentUser: currentUser
    }
});