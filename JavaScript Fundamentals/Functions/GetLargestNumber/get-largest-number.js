function solve(input) {
    'use strict';

    input = input[0]
        .split(' ')
        .map(Number);
    let maxNumber = Math.max.apply(null, input);

    console.log(maxNumber);
}

solve(['7 19 19']);