define(['viewmodels/shell', 'services/logger'], function (shell, logger) {
    var vm = {
        activate: activate,
        title: 'Information View'
    };

    return vm;

    //#region Internal Methods
    function activate() {
        logger.log('Information View Activated', null, 'info', true);
        return true;
    }
    //#endregion
});