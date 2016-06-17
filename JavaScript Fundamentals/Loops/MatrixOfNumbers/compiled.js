'use strict';

function solve(input) {
    'use strict';

    var n = Number(input[0]);
    var matrix = [];
    var startNumber = 1;

    for (var row = 0; row < n; row += 1) {
        matrix.push([]);

        for (var col = 0, currentNumber = startNumber; col < n; col += 1, currentNumber += 1) {
            matrix[row].push(currentNumber);
        }

        startNumber += 1;
    }

    for (var i = 0; i < n; i += 1) {
        console.log(matrix[i].join(' '));
    }
}