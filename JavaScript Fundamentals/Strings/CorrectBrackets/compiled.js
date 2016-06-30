function solve(input) {
    'use strict';

    var openingBracketsCount = 0;

    for (var i = 0; i < input[0].length; i += 1) {
        if (input[0][i] === '(') {
            openingBracketsCount += 1;
        } else if (input[0][i] === ')') {
            openingBracketsCount -= 1;
        }
    }

    console.log(openingBracketsCount === 0 ? 'Correct' : 'Incorrect');
}
