$.validator.addMethod('firstlettercap', function (value, element, params) {
    if (!value || value == '')
        return true;


    const firstChar = value[0];
    if (firstChar.toUpperCase() === firstChar && firstChar.toLowerCase() !== firstChar) {
        return true;
    }

    return false;
});


$.validator.unobtrusive.adapters.add('firstlettercap', '', function (options) {
    var element = $(options.form).find('#Description')[0];

    options.rules['firstlettercap'] = [element, ''];
    options.messages['firstlettercap'] = options.message;
});
