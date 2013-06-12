define(['viewmodels/shell', 'services/logger'], function (shell, logger) {
    var vm = {
        activate: activate,
        title: 'Photo View'
    };

    return vm;

    //#region Internal Methods
    function activate() {
        logger.log('Photo View Activated', null, 'photo', true);
        return true;
    }
    //#endregion
});