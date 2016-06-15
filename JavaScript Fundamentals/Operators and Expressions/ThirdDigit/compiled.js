function solve(input) {
    'use strict';

    var number = Number(input[0]);
    var thirdDigit = Math.floor(number / 100) % 10;

    console.log(thirdDigit === 7 ? 'true' : 'false ' + thirdDigit);
}
