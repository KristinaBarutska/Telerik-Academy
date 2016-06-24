function solve(input) {
    'use strict';

    input = input[0].split('\n');
    var numbers = input[1].split(' ').map(Number);

    numbers.sort(function (a, b) {
        return a - b;
    });
    console.log(numbers.join(' '));
}
