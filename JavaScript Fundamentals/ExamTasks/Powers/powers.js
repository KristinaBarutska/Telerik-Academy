function Solve(input) {
    'use strict';

    let nk = input[0].split(' ').map(Number);
    let numbers = input[1].split(' ').map(Number);
    let K = nk[1];
    let N = nk[0];
    let transformCount = 0;

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

    let transformedNumbers = [];

    while (transformCount < K) {
        for (let i = 0; i < N; i += 1) {
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

    let sum = numbers.reduce((a, b) => a + b);

    console.log(sum);
}