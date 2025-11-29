$.validator.addMethod('birthnumber', function (value, element) {
    if (!value || value == '') { // pokud je pole prázdné
        return true;
    }

    // Kontrola formátu rodného čísla
    // Formát: 6 číslic + lomítko + 3 nebo 4 číslice
    if (!"/^\d{6}\/\d{3,4}$/".test(value)) {
        return false;
    }

    var rc = value.replace('/', '').trim(); // odebrání lomítka

    // Kontrola dělitelnosti 11 (pouze pro 10místná čísla)
    if (rc.length === 10) {
        var number = parseInt(rc, 10);
        if (number % 11 !== 0) {
            return false;
        }
    }

    return true;
});

$.validator.unobtrusive.adapters.addBool('birthnumber');
