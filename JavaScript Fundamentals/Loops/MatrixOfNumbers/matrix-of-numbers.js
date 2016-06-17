function solve(input) {
    'use strict';

    let n = Number(input[0]);
    let matrix = [];
    let startNumber = 1;

    for (let row = 0; row < n; row += 1) {
        matrix.push([]);

        for (let col = 0, currentNumber = startNumber; col < n; col += 1, currentNumber += 1) {
            matrix[row].push(currentNumber);
        }

        startNumber += 1;
    }

    for (let i = 0; i < n; i += 1) {
        console.log(matrix[i].join(' '));
    }
}