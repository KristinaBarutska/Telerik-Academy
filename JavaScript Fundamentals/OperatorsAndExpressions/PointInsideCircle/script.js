/*
 Problem 6. Point in Circle
 Write an expression that checks if given point P(x, y) is within a circle K({0,0}, 5). //{0,0} is the centre and 5 is the radius
 Examples:
 x	      y	            inside
 0	      1	            true
 -5	      0	            true
 -4	      5	            false
 1.5	  -3	        true
 -4	      -3.5	        false
 100	  -30	        false
 0	      0	            true
 0.2	  -0.8	        true
 0.9	  -4.93	        false
 2        2.655	        true
 */

(function () {
    'use strict';

    function checkIfIsInside(x, y) {
        return (x * x) + (y * y) <= 25;
    }

    console.log(checkIfIsInside(0, 1));
    console.log(checkIfIsInside(-5, 0));
    console.log(checkIfIsInside(-4, 5));
    console.log(checkIfIsInside(1.5, -3));
    console.log(checkIfIsInside(100, -30));
    console.log(checkIfIsInside(0, 0));
}());