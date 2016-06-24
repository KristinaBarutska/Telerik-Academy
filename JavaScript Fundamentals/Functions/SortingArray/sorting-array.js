function solve(input) {
    'use strict';

    input = input.split('\n');
    let numbers = input[1]
        .split(' ')
        .map(Number);

    numbers.sort((a, b) => a - b);
    console.log(numbers.join(' '));
}