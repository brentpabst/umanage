define(['viewmodels/shell', 'services/logger'], function (shell, logger) {
    var vm = {
        activate: activate,
        title: 'Password View'
    };

    return vm;

    //#region Internal Methods
    function activate() {
        logger.log('Password View Activated', null, 'password', true);
        return true;
    }
    //#endregion
});