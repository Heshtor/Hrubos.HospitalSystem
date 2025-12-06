$.validator.addMethod('birthnumber', function (value, element, params) {
    if (!value || value == '') { // pokud je pole prázdné
        return true;
    }

    var message = null;
    var isValid = true;

    // Kontrola formátu rodného čísla
    // Formát: 6 číslic + lomítko + 3 nebo 4 číslice
    var format = /^\d{6}\/\d{3,4}$/;
    if (!format.test(value)) {
        isValid = false;
        message = params.msgformat;
    } else {
        var rc = value.replace('/', '').trim(); // odebrání lomítka

        // Kontrola dělitelnosti 11 (pouze pro 10místná čísla)
        if (rc.length === 10) {
            var number = parseInt(rc, 10);

            if (number % 11 !== 0) {
                isValid = false;
                message = params.msgmodulo;
            }
        }
    }

    if (!isValid) {
        var validator = $.data(element.form, "validator");

        if (validator && validator.settings.messages[element.name]) {
            validator.settings.messages[element.name].birthnumber = message;
        }

        return false;
    }

    return true;
});

$.validator.unobtrusive.adapters.add('birthnumber', ['msgformat', 'msgmodulo'], function (options) {
    options.rules['birthnumber'] = {
        msgformat: options.params.msgformat,
        msgmodulo: options.params.msgmodulo,
    };

    options.messages['birthnumber'] = options.message;
});
