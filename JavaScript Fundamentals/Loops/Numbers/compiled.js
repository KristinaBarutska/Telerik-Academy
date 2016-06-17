function solve(input) {
    'use strict';

    var end = Number(input[0]);
    var result = '';

    for (var i = 1; i <= end; i += 1) {
        result += i + ' ';
    }

    console.log(result.trim());
}
