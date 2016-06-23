function solve(input) {
    'use strict';

    input = input[0].split('\n');
    var bestCounter = 1;

    for (var i = 1; i < input.length; i += 1) {
        var currentCounter = 1;

        for (var j = i + 1; j < input.length; j += 1) {
            if (input[j] > input[j - 1]) {
                currentCounter += 1;
            } else {
                bestCounter = bestCounter < currentCounter ? currentCounter : bestCounter;
                break;
            }
        }
    }

    console.log(bestCounter);
}
