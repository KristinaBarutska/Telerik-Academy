function primeNums(input) {
    'use strict';

    var number = Number(input[0]);
    var isPrime = true;

    for (var i = number; i >= 0; i -= 1) {
        for (var j = 2; j < i; j += 1) {
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
