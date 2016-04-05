/*
 Problem 8. Trapezoid area
 Write an expression that calculates trapezoid's area by given sides a and b and height h.
 a	b	h	  area
 5	7	12	  72
 2	1	33	  49.5
 */

(function () {
    'use strict';

    function calculateTrapezoidArea(a, b, h) {
        return ((a + b) / 2) * h;
    }

    console.log(calculateTrapezoidArea(5, 7, 12));
    console.log(calculateTrapezoidArea(2, 1, 33));
}());