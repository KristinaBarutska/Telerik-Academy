/*
 Problem 4. Maximal increasing sequence
 Write a script that finds the maximal increasing sequence in an array.
 Example:
 input	                result
 3, 2, 3, 4, 2, 2, 4	2, 3, 4
 */

(function () {
    'use strict';

    var numbers = [3, 2, 3, 4, 2, 2, 4],
        numbersLength = numbers.length,
        currentSequence = [],
        bestSequence = [];

    for (let i = 0; i < numbersLength; i += 1) {
        let currentStartNumber = numbers[i];

        currentSequence.push(currentStartNumber);

        for (let j = i + 1; j < numbersLength; j += 1) {
            if (numbers[j] > numbers[j - 1]) {
                currentSequence.push(numbers[j]);
            } else {
                currentSequence = [];
                break;
            }

            if (currentSequence.length > bestSequence.length) {
                bestSequence = currentSequence;
            }
        }
    }

    console.log(`Longest increasing sequence: ${bestSequence.join(', ')}`);
}());