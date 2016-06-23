function solve(input) {
    'use strict';

    input = input[0].split('\n').slice(1).map(Number).sort(function(a, b) {
        return a - b;
    });

    console.log(input.join('\n'));
}
