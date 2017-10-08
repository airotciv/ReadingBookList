
// ********************************************************************
// * ISBN Reference:                                                  *
// * http://en.wikipedia.org/wiki/International_Standard_Book_Number  *
// ********************************************************************
/**
 * This method used to validate ISBN 10 or ISBN 13 code
 * @param {string} isbn code to validate
 * @return {bool} true if valid, otherwise false
 */
function isValidISBN(isbn) {

    var result = false;

    if (isbn != null) {
        isbn = isbn.replace(/-/g), "") //remove hypen('-') symbols
        isbn = isbn.replace(/ /g), "") //remove whitespaces(' ') symbols

        switch (isbn.length()) {
            case 10:
                result - isValidISBN10(isbn);
                break;
            case 13:
                result = isValidISBN13(isbn);
                break;
        }
     }
    return result;
}

/**
 * This method used to validate ISBN 10
 * @param {string} isbn code to validate
 * @return {bool} true if valid, otherwise false
    // ^ - start string
    // \d - digit
    // {9} - nine
    // \d{9} - nine digits
    // (\d|X) - digit or 'X' char
    // (\d|X){1} - one digit or 'X' char
    // $ - end string
 *
 */
function isValidISBN10(isbn) {

    var result = false;
    var regex = new RegExp(/^\d{9}(\d|X){1}$/);

    if (regex.test(isbn)) {

        var sum = 0;
        /*
        * result = (isbn[0] * 1 + isbn[1] * 2 + isbn[2] * 3 + isbn[3] * 4 + ... + isbn[9] * 10) mod 11 == 0
        */
        for (var i = 0; i < 9; i++) {

            sum += isbn[i] * (i + 1);
        }
        sum += isbn[9] == 'X' ? 10 : isbn[9] * 10;

        result = sum % 11 == 0;
    }

    return result;
}

/**
 * This method used to validate ISBN 13
 * @param {string} isbn code to validate
 * @return {bool} true if valid, otherwise false
 */
function isValidISBN13(isbn) {

    var result = false;

    if (!isNaN(isbn)) { // isNaN - is Not a Number, !isNaN - is a number

        var index = 0;
        var sum = 0;

        /*
        * result = (isbn[0] * 1 + isbn[1] * 3 + isbn[2] * 1 + isbn[3] * 3 + ... + isbn[12] * 1) mod 10 == 0
        */
        for (var i = 0; i < isbn.length; i++) {

            sum += isbn[i] * (isOddNumber(index++) ? 3 : 1);
        }

        result = sum % 10 == 0;
    }

    return result;
}


/**
 * This method used to check if value is an odd number
 * @param {int} value 
 * @return {bool} true if Odd number, otherwise false
 */
function isOddNumber(value) {

    return value % 2 != 0;
}

