// KO Binding Handlers for different cool things!
define([], function () {

    return {
        init: init
    };

    function init() {
        // Simple Date String
        ko.bindingHandlers.dateString = {
            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var value = valueAccessor(),
                    allBindings = allBindingsAccessor();
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                var momentValue = moment(valueUnwrapped).format('ll');
                $(element).text(momentValue);
            }
        }

        ko.bindingHandlers.yearString = {
            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var value = valueAccessor(),
                    allBindings = allBindingsAccessor();
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                var momentValue = moment(valueUnwrapped).format('YYYY');
                $(element).text(momentValue);
            }
        }

        // Simple integer string
        ko.bindingHandlers.intString = {
            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var value = valueAccessor(),
                    allBindings = allBindingsAccessor();
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                $(element).text($.number(valueUnwrapped));
            }
        }
    }
});