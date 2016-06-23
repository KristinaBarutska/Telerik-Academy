'use strict';

function solve(input) {
    'use strict';

    input = input[0].split('\n').map(Number).sort(function (a, b) {
        return a - b;
    });

    var bestCounter = 1;
    var currentCounter = 1;
    var mostFrequentNumber = input[1];

    for (var i = 2; i < input.length; i += 1) {
        if (input[i] === input[i - 1]) {
            currentCounter += 1;
        } else {
            if (currentCounter > bestCounter) {
                bestCounter = currentCounter;
                mostFrequentNumber = input[i - 1];
            }

            currentCounter = 1;
        }
    }

    console.log(mostFrequentNumber + ' (' + bestCounter + ' times)');
}
