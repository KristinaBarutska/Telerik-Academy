function solve(input) {
    'use strict';

    var digitWords = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    var digit = Number(input[0]) % 10;

    console.log(digitWords[digit]);
}
