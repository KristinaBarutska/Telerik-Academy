/*
 Problem 2. Multiplication Sign
 Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
 Use a sequence of if operators.

 a	  b	    c	   result
 5	  2	    2      +
 -2	 -2	    1      +
 -2	  4	    3      -
 0	 -2.5   4	   0
 -1	 -0.5   -5.1   -
 */

(function () {
    'use strict';

    function getMultiplicationSign(a, b, c) {
        var isPositive = true;
        if (a >= 0) {
            if (b > 0 && c < 0) {
                isPositive = false;
            }
            else if (b < 0 && c > 0) {
                isPositive = false;
            }
        }
        else {
            if (b > 0 && c > 0) {
                isPositive = false;
            }
            else if (b < 0 && c < 0) {
                isPositive = false;
            }
        }

        if (a === 0 || b === 0 || c === 0) {
            return 0;
        }
        else if (isPositive) {
            return '+';
        }
        else {
            return '-';
        }
    }

    console.log(getMultiplicationSign(5, 2, 2));
    console.log(getMultiplicationSign(-2, -2, 1));
    console.log(getMultiplicationSign(-2, 4, 3));
    console.log(getMultiplicationSign(0, -2.5, 4));
    console.log(getMultiplicationSign(-1, -0.5, -5.1));
}());