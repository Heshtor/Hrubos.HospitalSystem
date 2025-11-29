$.validator.addMethod('filecontent', function (value, element, params) {
    var allowedTypes = params.types.toLowerCase().split(','); // [image, pdf]

    var uploadedType  = "";
    if (element && element.files && element.files.length > 0) {
        uploadedType  = element.files[0].type.toLowerCase(); // např.: image/png
    }

    // value obsahuje např.: obrazek.png
    if (!value) { // pokud nebyl vybrán žádný soubor
        return true;
    }

    if (allowedTypes.some(t => uploadedType.includes(t.trim().toLowerCase()))) {
        return true;
    }

    return false;
});


$.validator.unobtrusive.adapters.add('filecontent', ['types'], function (options) {
    options.rules['filecontent'] = {
        types: options.params['types'] // "image,pdf"
    };
    options.messages['filecontent'] = options.message;

    $(options.element).on('change', function () {
        $(this).valid();
    });
});
