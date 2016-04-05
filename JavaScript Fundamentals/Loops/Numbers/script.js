/*
 Problem 1. Numbers
 Write a script that prints all the numbers from 1 to N.
 */

(function () {
    'use strict';

    function printNumbersInRange(n) {
        var result = '';

        for (let i = 1; i <= n; i += 1) {
            result += `${i} `;
        }

        return result;
    }

    console.log(printNumbersInRange(10));
}());