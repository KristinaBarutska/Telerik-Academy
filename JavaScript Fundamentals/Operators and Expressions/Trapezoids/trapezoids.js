function solve(input) {
    'use strict';

    let a = Number(input[0]);
    let b = Number(input[1]);
    let h = Number(input[2]);
    let area = ((a + b) * h) / 2;

    console.log(area.toFixed(7));
}
