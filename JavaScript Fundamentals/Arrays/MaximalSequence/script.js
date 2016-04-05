/*
 Problem 3. Maximal sequence
 Write a script that finds the maximal sequence of equal elements in an array.
 Example:
 input	                           result
 2, 1, 1, 2, 3, 3, 2, 2, 2, 1      2, 2, 2
 */

(function () {
    'use strict';

    var numbers = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
        numbersLength = numbers.length,
        currentCounter = 1,
        bestCounter = 1,
        bestValue;

    for (let i = 1; i < numbersLength; i += 1) {
        if (numbers[i] === numbers[i - 1]) {
            currentCounter += 1;
        } else {
            currentCounter = 0;
        }

        if (bestCounter < currentCounter) {
            bestCounter = currentCounter;
            bestValue = numbers[i];
        }
    }

    let bestSequence = [];

    for (let i = 0; i <= bestCounter; i += 1) {
        bestSequence.push(bestValue);
    }

    console.log(`Longest sequence: ${bestSequence.join(', ')}`);
}());