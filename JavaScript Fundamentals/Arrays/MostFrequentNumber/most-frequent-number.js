function solve(input) {
    'use strict';

    input = input[0]
        .split('\n')
        .map(Number)
        .sort((a, b) => a - b);

    let bestCounter = 1;
    let currentCounter = 1;
    let mostFrequentNumber = input[1];

    for (let i = 2; i < input.length; i += 1) {
        if (input[i] === input[i - 1]) {
            currentCounter += 1;
        } else {
            if (currentCounter > bestCounter) {
                bestCounter = currentCounter;
                mostFrequentNumber = input[i - 1];
            }

            currentCounter = 1;
        }
    }

    console.log(`${mostFrequentNumber} (${bestCounter} times)`);
}
