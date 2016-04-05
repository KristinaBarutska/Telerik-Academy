/*
 Problem 3. Min/Max of sequence
 Write a script that finds the max and min number from a sequence of numbers.
 */

(function () {
    'use strict';

    function findMin(sequenceOfNumbers) {
        let min = sequenceOfNumbers[0];

        for (let i = 0; i < sequenceOfNumbers.length; i += 1) {
            min = Math.min(min, sequenceOfNumbers[i]);
        }

        return min;
    }

    function findMax(sequenceOfNumbers) {
        let max = sequenceOfNumbers[0];

        for (let i = 0; i < sequenceOfNumbers.length; i += 1) {
            max = Math.max(max, sequenceOfNumbers[i]);
        }

        return max;
    }

    function printMinMax(sequenceOfNumbers) {
        let min = findMin(sequenceOfNumbers);
        let max = findMax(sequenceOfNumbers);

        console.log(`Min: ${min}  Max: ${max}`);
    }

    printMinMax([1, 2, 3, 4, 5, 6, 7, 8, 9]);
}());