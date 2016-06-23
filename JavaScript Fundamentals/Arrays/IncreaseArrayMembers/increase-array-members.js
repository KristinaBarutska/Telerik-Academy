function solve(input) {
    'use strict';

    let n = Number(input[0]);
    let numbers = new Array(n);

    for (let i = 0; i < n; i += 1) {
        numbers[i] = i * 5;
    }

    console.log(numbers.join('\n'));
}
