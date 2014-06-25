define(['plugins/http'], function (http) {

    var currentUser = ko.observable(),
        loadCurrentUser = function () {
            http.get('api/users/me').then(function (response) {
                currentUser(response);
            });
        }

    return {
        currentUser: function () {
            if (currentUser === undefined || currentUser === null) {
                loadCurrentUser();
            }
            return currentUser;
        }
    };
});

