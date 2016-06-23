function primeNums(input) {
    'use strict';

    let number = Number(input[0]);
    let isPrime = true;

    for (let i = number; i >= 0; i -= 1) {
        for (let j = 2; j < i; j += 1) {
            if (i % j === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            console.log(i);
            break;
        }
    }
}
