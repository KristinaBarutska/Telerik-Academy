function solve(input) {
    'use strict';

    input = input.map(Number);
    let min = Math.min.apply(null, input);
    let max = Math.max.apply(null, input);
    let sum = input.reduce((p, c) => p + c, 0);
    let avg = sum / input.length;

    console.log(`min=${min.toFixed(2)}\nmax=${max.toFixed(2)}\nsum=${sum.toFixed(2)}\navg=${avg.toFixed(2)}`);
}