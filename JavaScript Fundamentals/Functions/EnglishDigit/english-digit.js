function solve(input) {
    'use strict';

    let digitWords = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    let digit = Number(input[0]) % 10;

    console.log(digitWords[digit]);
}