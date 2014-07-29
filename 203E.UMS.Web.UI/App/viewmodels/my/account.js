define(['plugins/router', 'viewmodels/shell'], function (router, shell) {
    var expandAll = function () {
        $('.info-panel .collapse').collapse('show');
    },
    hideAll = function () {
        $('.info-panel .collapse').collapse('hide');
    }

    return {
        currentUser: shell.currentUser,
        expandAll: expandAll,
        hideAll: hideAll,
        activate: function () {
            router.on('router:navigation:composition-complete', function () {
                $('.info-panel .collapse').on('show.bs.collapse', function (e) {
                    var header = $(e.target).siblings('.info-panel-header')[0];
                    var icon = $(header).children('span')[0];
                    $(icon).removeClass('fa-caret-down').addClass('fa-caret-up');
                });
            });
            router.on('router:navigation:composition-complete', function () {
                $('.info-panel .collapse').on('hide.bs.collapse', function (e) {
                    var header = $(e.target).siblings('.info-panel-header')[0];
                    var icon = $(header).children('span')[0];
                    $(icon).removeClass('fa-caret-up').addClass('fa-caret-down');
                });
            });
        }
    }
});