$(function () {
    $("abbr#passwordReminder").timeago();
})

jQuery.validator.addMethod('greaterthan', function (value, element, params) {
    var otherValue = $(params.element).val();

    if (parseFloat(value) == 0 && params.ignorezeros) return true;
    else return isNaN(value) && isNaN(otherValue) || (params.allowequality === 'True' ? parseFloat(value) >= parseFloat(otherValue) : parseFloat(value) > parseFloat(otherValue));
}, '');

jQuery.validator.unobtrusive.adapters.add('greaterthan', ['other', 'allowequality', 'ignorezeros'], function (options) {
    var prefix = options.element.name.substr(0, options.element.name.lastIndexOf('.') + 1),
    
    other = options.params.other,
    fullOtherName = appendModelPrefix(other, prefix),
    element = $(options.form).find(':input[name=' + fullOtherName + ']')[0];

    options.rules['greaterthan'] = { allowequality: options.params.allowequality, ignorezeros: options.params.ignorezeros, element: element };
    if (options.message) {
        options.messages['greaterthan'] = options.message;
    }
});

function appendModelPrefix(value, prefix) {
    if (value.indexOf('*.') === 0) {
        value = value.replace('*.', prefix);
    }
    return value;
}
