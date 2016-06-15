function solve(input) {
    'use strict';
    
    let number = Number(input[0]);
    let thirdBit = (number >> 3) & 1;

    console.log(thirdBit);
}
