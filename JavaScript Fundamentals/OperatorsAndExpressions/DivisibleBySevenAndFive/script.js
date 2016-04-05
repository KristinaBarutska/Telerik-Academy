/*
 Problem 2. Divisible by 7 and 5
 Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
 Examples:
 n	Divided by 7 and 5?
 3	false
 0	true
 5	false
 7	false
 35	true
 140	true
 */

(function () {
    'use strict';

    function checkDivisibility(number) {
        return number % (7 * 5) == 0;
    }

    console.log(checkDivisibility(3));
    console.log(checkDivisibility(0));
    console.log(checkDivisibility(5));
    console.log(checkDivisibility(7));
    console.log(checkDivisibility(35));
    console.log(checkDivisibility(140));
}());