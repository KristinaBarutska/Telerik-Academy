/*
 Problem 7. Binary search
 Write a script that finds the index of given element in a sorted array of integers by using
 the binary search algorithm.
 */

(function () {
    'use strict';

    function performBinarySearch(arrayOfNumbers, min, max, target) {
        arrayOfNumbers.sort((a, b) => a - b);

        var min = 0,
            max = arrayOfNumbers.length - 1,
            indexOfTarget = -1;

        while (min <= max) {
            let mid = min + (max - min) / 2;

            mid = Math.floor(mid);

            if (arrayOfNumbers[mid] > target) {
                max = mid - 1;
            } else if (arrayOfNumbers[mid] < target) {
                min = mid + 1;
            } else {
                indexOfTarget = mid;
                break;
            }
        }

        return indexOfTarget;
    }

    // 1, 1, 2, 3, 3, 4, 7, 7, 8 => result should be 5
    console.log(performBinarySearch([8, 3, 1, 4, 3, 7, 7, 2, 1], 0, 8, 4));
}());