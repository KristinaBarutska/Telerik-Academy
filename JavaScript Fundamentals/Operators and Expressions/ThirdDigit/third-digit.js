function solve(input) {
    'use strict';

    let number = Number(input[0]);
    let thirdDigit = Math.floor(number / 100) % 10;

    console.log(thirdDigit === 7 ? 'true' : `false ${thirdDigit}`); 
}