function solve(input) {
    'use strict';

    let number = Number(input[0]);

    if (number < 2 || number != Math.round(number)) {
        return false;
    }

    let isPrime = true;

    for (let i = 2; i <= Math.sqrt(number); i += 1) {
        if (number % i === 0) {
            isPrime = false;
        }
    }

    console.log(isPrime);
}
