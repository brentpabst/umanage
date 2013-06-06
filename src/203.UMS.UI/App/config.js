define(function () {
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

    var appTitle = 'uManage';

    var startModule = 'dashboard';

    var routes = [
        {
            url: 'dashboard',
            moduleId: 'viewmodels/dashboard',
            name: 'Dashboard',
            visible: true
        }
    ];

    return {
        appTitle: appTitle,
        debugEnabled: ko.observable(true),
        startModule: startModule,
        routes: routes
    };
});