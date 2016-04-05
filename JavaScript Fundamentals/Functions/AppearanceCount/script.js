/*
 Problem 5. Appearance count
 Write a function that counts how many times given number appears in given array.
 Write a test function to check if the function is working correctly.
 */

(function () {
    'use strict';

    function getNumberOccurrences(arrayOfNumbers, number) {
        var counter = 0,
            arrayLength = arrayOfNumbers.length;

        for (let i = 0; i < arrayLength; i += 1) {
            if (arrayOfNumbers[i] === number) {
                counter++;
            }
        }

        return counter;
    }

    console.log(getNumberOccurrences([1, 3, 3, 2, 5, 3, 1, 9, 3, 9, 3, 1, 3], 3));
}());