/*
 Problem 7. First larger than neighbours
 Write a function that returns the index of the first element in array that is larger than
 its neighbours or -1, if there’s no such element.
 Use the function from the previous exercise.
 */

(function () {
    'use strict';

    function getFirstLargerThanNeighbours(arrayOfNumbers) {
        var arrayLength = arrayOfNumbers.length;

        for (let i = 0; i < arrayLength; i += 1) {
            if (arrayOfNumbers[i] > arrayOfNumbers[i - 1] && arrayOfNumbers[i] > arrayOfNumbers[i + 1]) {
                return i;
            }
        }

        return -1;
    }

    console.log(getFirstLargerThanNeighbours([1, 2, 1]));
    console.log(getFirstLargerThanNeighbours([1, 1, 1]));
}());