function solve(input) {
    'use strict';

    var number = Number(input[0]);
    console.log(number % 2 === 0 ? 'even ' + number : 'odd ' + number);
}