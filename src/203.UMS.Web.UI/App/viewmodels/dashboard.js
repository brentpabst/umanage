define(['viewmodels/shell', 'services/logger'], function (shell, logger) {
    var vm = {
        activate: activate,
        title: 'Dashboard View'
    };

    return vm;

    //#region Internal Methods
    function activate() {
        logger.log('Dashboard View Activated', null, 'dashboard', true);
        return true;
    }
    //#endregion
});