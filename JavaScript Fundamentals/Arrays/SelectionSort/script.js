/*
 Problem 5. Selection sort
 Sorting an array means to arrange its elements in increasing order.
 Write a script to sort an array.
 Use the selection sort algorithm: Find the smallest element, move it at the first position,
 find the smallest from the rest, move it at the second position, etc.
 */

(function () {
    'use strict';

    Array.prototype.sortUsingSelectionSort = function () {
        let i,
            j;

        for (j = 0; j < this.length - 1; j += 1) {
            let min = j;

            for (i = j + 1; i < this.length; i += 1) {
                if (this[i] < this[min]) {
                    min = i;
                }
            }

            if (min != i) {
                let temp = this[j];
                this[j] = this[min];
                this[min] = temp;
            }
        }
    }

    var numbers = [64, 25, 12, 22, 11];
    numbers.sortUsingSelectionSort();

    console.log(...numbers);
}());