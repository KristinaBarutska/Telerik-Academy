/*
 Problem 4. Third digit
 Write an expression that checks for given integer if its third digit (right-to-left) is 7.
 Examples:
 n	Third digit 7?
 5	false
 701	true
 1732	true
 9703	true
 877	false
 777877	false
 9999799	true
 */

(function () {
    'use strict';

    function checkIfThirdDigitIsSeven(number) {
        return Math.floor((number / 100) % 10) == 7;
    }

    console.log(checkIfThirdDigitIsSeven(5));
    console.log(checkIfThirdDigitIsSeven(701));
    console.log(checkIfThirdDigitIsSeven(1732));
    console.log(checkIfThirdDigitIsSeven(9703));
    console.log(checkIfThirdDigitIsSeven(877));
    console.log(checkIfThirdDigitIsSeven(777877));
    console.log(checkIfThirdDigitIsSeven(9999799));
}());