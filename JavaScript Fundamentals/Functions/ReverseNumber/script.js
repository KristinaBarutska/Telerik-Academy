/*
 Problem 2. Reverse number
 Write a function that reverses the digits of given decimal number.
 Example:
 input	output
 256	652
 123.45	54.321
 */

(function () {
    'use strict';

    function reverseNumber(number) {
        var numberAsString = number + '',
            numberAsStringLength = numberAsString.length,
            reversedNumberAsString = '';

        for (let i = numberAsStringLength - 1; i >= 0; i -= 1) {
            reversedNumberAsString += numberAsString[i];
        }

        return Number(reversedNumberAsString);
    }

    console.log(reverseNumber(256));
    console.log(reverseNumber(123.45));
}());