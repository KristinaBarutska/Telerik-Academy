function solve(input) {
    'use strict';

    let number = Number(input[0]);
    console.log(number % 2 === 0 ? `even ${number}` : `odd ${number}`);
}