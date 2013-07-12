define(['viewmodels/shell', 'services/logger'], function (shell, logger) {
    var vm = {
        activate: activate,
        title: 'Account View'
    };

    return vm;

    //#region Internal Methods
    function activate() {
        logger.log('Account View Activated', null, 'account', true);
        return true;
    }
    //#endregion
});