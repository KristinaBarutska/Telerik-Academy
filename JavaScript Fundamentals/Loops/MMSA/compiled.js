function solve(input) {
    'use strict';

    input = input.map(Number);
    var min = Math.min.apply(null, input);
    var max = Math.max.apply(null, input);
    var sum = input.reduce(function (p, c) {
        return p + c;
    }, 0);
    var avg = sum / input.length;

    console.log('min=' + min.toFixed(2) + '\nmax=' + max.toFixed(2) + '\nsum=' + sum.toFixed(2) + '\navg=' + avg.toFixed(2));
}