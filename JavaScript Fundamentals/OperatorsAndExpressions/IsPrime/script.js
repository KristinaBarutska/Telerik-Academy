/*
 Problem 7. Is prime
 Write an expression that checks if given positive integer number n (n ? 100) is prime.
 Examples:
 n	Prime?
 1	false
 2	true
 3	true
 4	false
 */

(function () {
    'use strict';

    function isPrime(number) {
        if (number < 2 || number != Math.round(number)) {
            return false
        }

        var isPrime = true;

        for (let i = 2; i <= Math.sqrt(number); i += 1) {
            if (number % i == 0) {
                isPrime = false
            }
        }

        return isPrime;
    }

    console.log(isPrime(1));
    console.log(isPrime(2));
    console.log(isPrime(3));
    console.log(isPrime(4));
}());