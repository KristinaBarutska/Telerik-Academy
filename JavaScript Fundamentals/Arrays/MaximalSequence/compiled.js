function solve(input) {
    'use strict';

    input = input[0].split('\n').map(Number);

    var bestCouter = 1;
    var currentCounter = 1;

    for (var i = 0; i < input.length; i += 1) {
        if (input[i] === input[i - 1]) {
            currentCounter += 1;
        } else {
            bestCouter = currentCounter > bestCouter ? currentCounter : bestCouter;
            currentCounter = 1;
        }
    }

    console.log(bestCouter);
}
