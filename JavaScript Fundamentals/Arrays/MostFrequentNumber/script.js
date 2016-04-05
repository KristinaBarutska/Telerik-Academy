/*
 Problem 6. Most frequent number
 Write a script that finds the most frequent number in an array.
 Example:
 input	                                      result
 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3        4(5 times)
 */

(function () {
    'use strict';

    function findMostFrequentNumber(arrayOfNumbers) {
        var currentCounter = 1,
            bestCounter = 1,
            mostFrequentNumber = arrayOfNumbers[0],
            arrayLength = arrayOfNumbers.length;

        arrayOfNumbers.sort((a, b)=> a - b);

        for (let i = 1; i < arrayLength; i += 1) {
            if (arrayOfNumbers[i] == arrayOfNumbers[i - 1]) {
                currentCounter++;
            } else {
                currentCounter = 1;
            }

            if (bestCounter < currentCounter) {
                bestCounter = currentCounter;
                mostFrequentNumber = arrayOfNumbers[i];
            }
        }

        return `${mostFrequentNumber}(${bestCounter} times)`;
    }

    console.log(findMostFrequentNumber([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));
}());