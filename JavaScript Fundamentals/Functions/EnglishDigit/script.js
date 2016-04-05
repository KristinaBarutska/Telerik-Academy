/*
 Problem 1. English digit
 Write a function that returns the last digit of given integer as an English word.
 Examples:
 input	output
 512	two
 1024	four
 12309	nine
 */

(function(){
    'use strict';

    function getLastDigitOfNumber(number){
        var words = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

        return words[Math.floor(number % 10)];
    }

    console.log(getLastDigitOfNumber(512));
    console.log(getLastDigitOfNumber(1024));
    console.log(getLastDigitOfNumber(12309));
}());