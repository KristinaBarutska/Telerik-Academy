/*
 Problem 1. Exchange if greater
 Write an if statement that takes two double variables a and b and exchanges their values if the first one is greater than the second.
 As a result print the values a and b, separated by a space.
 a	b	result
 5	2	2 5
 3	4	3 4
 */

(function(){
    'use strict';

    function exchangeIfGreater(a, b){
        return a > b ? [b, a] : [a, b];
    }

    console.log(...exchangeIfGreater(5, 2));
    console.log(...exchangeIfGreater(3, 4));
}());