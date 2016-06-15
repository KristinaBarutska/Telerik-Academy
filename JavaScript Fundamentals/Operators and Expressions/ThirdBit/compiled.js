function solve(input) {
    'use strict';

    var number = Number(input[0]);
    var thirdBit = number >> 3 & 1;

    console.log(thirdBit);
}
