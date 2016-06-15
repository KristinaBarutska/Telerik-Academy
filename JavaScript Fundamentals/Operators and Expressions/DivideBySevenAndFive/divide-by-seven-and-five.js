function solve(input) {
    'use strict';
    
    let number = Number(input[0]);
    console.log(number % (7 * 5) === 0 ? `true ${number}` : `false ${number}`);
}