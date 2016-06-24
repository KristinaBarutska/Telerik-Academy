function solve(input) {
    'use strict';

    input = input[0].split('\n');
    let numbers = input[1]
        .split(' ')
        .map(Number);
    let resultIndex = -1;

    for (let i = 1; i < numbers.length - 1; i += 1) {
        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) {
            resultIndex = i;
            break;
        }
    }

    console.log(resultIndex);
}