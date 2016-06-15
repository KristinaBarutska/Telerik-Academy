function solve(input) {
    'use strict';

    var number = Number(input[0]);

    if (number < 2 || number != Math.round(number)) {
        return false;
    }

    var isPrime = true;

    for (var i = 2; i <= Math.sqrt(number); i += 1) {
        if (number % i === 0) {
            isPrime = false;
        }
    }

    console.log(isPrime);
}
