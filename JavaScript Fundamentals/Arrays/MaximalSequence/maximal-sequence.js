function solve(input) {
    'use strict';

    input = input[0].split('\n').map(Number);

    let bestCouter = 1;
    let currentCounter = 1;

    for (let i = 1; i < input.length; i += 1) {
        if (input[i] === input[i - 1]) {
            currentCounter += 1;
        } else {
            bestCouter = currentCounter > bestCouter ? currentCounter : bestCouter;
            currentCounter = 1;
        }
    }

    console.log(bestCouter);
}
