/*
 Problem 2. Numbers not divisible
 Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time
 */

(function () {
    'use strict';

    function printNumbersNotDivisibleInRange(n) {
        for (let i = 1; i <= n; i += 1) {
            if (i % (3 * 7) !== 0) {
                console.log(i);
            }
        }
    }

    printNumbersNotDivisibleInRange(30);
}());