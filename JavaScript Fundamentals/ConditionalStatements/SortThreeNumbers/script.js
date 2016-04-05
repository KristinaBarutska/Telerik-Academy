/*
 Problem 4. Sort 3 numbers
 Sort 3 real values in descending order.
 Use nested if statements.
 Note: Don’t use arrays and the built-in sorting functionality.
 */

(function () {
    'use strict';

    function sortNumbers(a, b, c) {
        let result;

        if (a > b) {
            if (a > c) {
                result = a;
                if (b > c) {
                    result += " " + b + " " + c;
                }
                else {
                    result += " " + c + " " + b;
                }
            }
            else {
                result = c + " " + a + " " + b;
            }
        }
        else {
            if (b > c) {
                result = b;
                if (c > a) {
                    result += " " + c + " " + a;
                }
                else {
                    result += " " + a + " " + c;
                }
            }
            else {
                result = c + " " + b + " " + a;
            }
        }

        return result;
    }

    console.log(sortNumbers(5, 1, 2));
}());