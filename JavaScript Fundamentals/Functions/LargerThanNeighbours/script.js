/*
 Problem 6. Larger than neighbours
 Write a function that checks if the element at given position in given array of integers is bigger than
 its two neighbours (when such exist).
 */

(function () {
    'use strict';

    function checkIfLargerThanNeighbours(arrayOfNumbers, index) {
        if (arrayOfNumbers[index] > arrayOfNumbers[index - 1] && arrayOfNumbers[index] > arrayOfNumbers[index + 1]) {
            return true;
        }

        return false;
    }

    console.log(checkIfLargerThanNeighbours([1,2,1], 1));
    console.log(checkIfLargerThanNeighbours([1,1,1], 1));
}());