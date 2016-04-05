/*
 Problem 6. Quadratic equation
 Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
 Calculates and prints its real roots.
 Note: Quadratic equations may have 0, 1 or 2 real roots.
 Examples:
 a	b	c	roots
 2	5	-3	x1=-3; x2=0.5
 -1	3	0	x1=3; x2=0
 -0.5	4	-8	x1=x2=4
 5	2	8	no real roots
 */

(function () {
    'use strict';

    function solveEquation(a, b, c) {
        var d = b * b - 4 * a * c;

        if (d < 0) {
            return 'no real roots.';
        } else if (d === 0) {
            return `x1 = x2 = ${-b / (2 * a)}`;
        } else {
            return `x1 = ${(-b - Math.sqrt(d)) / (2 * a)}` + '\n' + `x2 = ${(-b + Math.sqrt(d)) / ( 2 * a)}`;
        }
    }

    console.log(solveEquation(2, 5, -3));
    console.log(solveEquation(-1, 3, -0));
    console.log(solveEquation(-0.5, 4, -8));
    console.log(solveEquation(5, 2, 8));
}());