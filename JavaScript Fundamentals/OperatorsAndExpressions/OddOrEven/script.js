/*
 Problem 1. Odd or Even
 Write an expression that checks if given integer is odd or even.
 Examples:
 n	Odd?
 3	true
 2	false
 -2	false
 -1	true
 0	false
 */

(function(){
    'use strict';

    function checkIfOdd(number){
        return number % 2 !== 0;
    }

    console.log(checkIfOdd(3));
    console.log(checkIfOdd(2));
    console.log(checkIfOdd(-2));
    console.log(checkIfOdd(-1));
    console.log(checkIfOdd(0));
}());