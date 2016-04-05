/*
 Problem 2. Lexicographically comparison
 Write a script that compares two char arrays lexicographically (letter by letter).
 */

(function () {
    'use strict';

    function compareArrays(firstArray, secondArray) {
        if (firstArray.length !== secondArray.length) {
            return false;
        } else {
            let length = firstArray.length;

            for (let i = 0; i < length; i += 1) {
                if (firstArray[i] !== secondArray[i]) {
                    return false;
                }
            }

            return true;
        }
    }

    console.log(compareArrays(['a', 'b', 'c'], ['a', 'b', 'c']));
    console.log(compareArrays(['a', 'b', 'c'], ['a', 'b', 'c', 'd']));
    console.log(compareArrays(['a', 'b', 'c'], ['a', 'b', 'd']));
}());