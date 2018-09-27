/**
 * Custom validator for letter only, not allow numbers or special characters
*/
$.validator.addMethod("lettersOnly", function (value, element) {
    return this.optional(element) || /^[a-zA-Z ]+$/i.test(value);
}, "Por favor letras unicamente.");

/**
* Custom validator for dates (0-9 and slashes).  Does not check month, day or year.
*/
$.validator.addMethod("formatDate", function (value, element) {
    return this.optional(element) || /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/i.test(value);
}, "Por favor una fecha como (dd/MM/yyyy) o (dd-MM-yyyy).");