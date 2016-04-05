/*
 Problem 7. The biggest of five numbers
 Write a script that finds the greatest of given 5 variables.
 Use nested if statements.
 Examples:
 a	b	c	d	e	biggest
 5	2	2	4	1	5
 -2	-22	1	0	0	1
 */

(function () {
    'use strict';

    function findMaxNumber(a, b, c, d, e) {
        var max = a;

        if (max < b) {
            max = b;
        }

        if (max < c) {
            max = c;
        }

        if (max < d) {
            max = d;
        }

        if (max < e) {
            max = e;
        }

        return max;
    }

    console.log(findMaxNumber(5, 2, 2, 4, 1, 5));
    console.log(findMaxNumber(-2, -22, 1, 0, 0, 1));
}());