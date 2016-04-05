/*
    Problem 2. Remove elements
    Write a function that removes all elements with a given value.
    Attach it to the array type.
    Read about prototype and how to attach methods.
*/

(function () {
    'use strict';

    Array.prototype.removeSpecifiedElements = function (value) {
        var length = this.length;

        for (let i = 0; i < length; i += 1) {
            if (this[i] === value) {
                this.splice(i, 1);
                i--;
            }
        }
    }

    let numbers = [1, 1, 2, 3, 1, 4, 1, 5, 1];

    numbers.removeSpecifiedElements(1);

    console.log(...numbers);
})();