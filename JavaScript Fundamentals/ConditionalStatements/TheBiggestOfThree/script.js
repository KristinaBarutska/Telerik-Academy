/*
 Problem 3. The biggest of Three
 Write a script that finds the biggest of three numbers.
 Use nested if statements.
 a	   b	 c	biggest
 5	   2	 2	5
 -2	   -2	 1	1
 -2	   4	 3	4
 */

(function () {
    'use strict';

    function getLargestNumber(a, b, c) {
        if (a > b) {
            if (a > c) {
                return a;
            }
            else {
                return c;
            }
        }
        else {
            if (b > c) {
                return b;
            }
            else {
                return c;
            }
        }
    }

    console.log(getLargestNumber(5, 2, 2));
    console.log(getLargestNumber(-2, -2, 1));
    console.log(getLargestNumber(-2, 4, 3));
}());