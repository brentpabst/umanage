define(['plugins/http'], function (http) {


    return {
        getCurrentUser: function () {
            var user = ko.observable();
            http.get('api/users/me').then(function (response) {
                user(response);
            });
            return user;
        }
    }
});

