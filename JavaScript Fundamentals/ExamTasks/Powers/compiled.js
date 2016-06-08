function Solve(input) {
    'use strict';

    var nk = input[0].split(' ').map(Number);
    var numbers = input[1].split(' ').map(Number);
    var K = nk[1];
    var N = nk[0];
    var transformCount = 0;

    function performTransformation(number, firstNeighbor, secondNeighbor) {
        if (number === 0) {
            return Math.abs(firstNeighbor - secondNeighbor);
        } else if (number === 1) {
            return firstNeighbor + secondNeighbor;
        } else if (number % 2 === 0) {
            return Math.max(firstNeighbor, secondNeighbor);
        } else if (number % 2 !== 0) {
            return Math.min(firstNeighbor, secondNeighbor);
        }
    }

    var transformedNumbers = [];

    while (transformCount < K) {
        for (var i = 0; i < N; i += 1) {
            if (i === 0) {
                transformedNumbers.push(performTransformation(numbers[0], numbers[N - 1], numbers[1]));
            } else if (i === N - 1) {
                transformedNumbers.push(performTransformation(numbers[N - 1], numbers[N - 2], numbers[0]));
            } else {
                transformedNumbers.push(performTransformation(numbers[i], numbers[i - 1], numbers[i + 1]));
            }
        }

        numbers = transformedNumbers;
        transformedNumbers = [];
        transformCount += 1;
    }

    var sum = numbers.reduce(function (a, b) {
        return a + b;
    });

    console.log(sum);
}