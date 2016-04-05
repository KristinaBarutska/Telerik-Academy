/*
 Problem 5. Digit as word

 Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
 Print “not a digit” in case of invalid input.
 Use a switch statement.
 Examples:

 digit	result
 2	two
 1	one
 */

(function(){
    'use strict';

    function getDigitAsWord(digit){
        switch (digit){
            case 0: return "Zero";
            case 1: return "One";
            case 2: return "Two";
            case 3: return "Three";
            case 4: return "Four";
            case 5: return "Five";
            case 6: return "Six";
            case 7: return "Seven";
            case 8: return "Eight";
            case 9: return "Nine";
            default : return "Not a digit!";
        }
    }

    console.log(getDigitAsWord(2))
    console.log(getDigitAsWord(1))
}());