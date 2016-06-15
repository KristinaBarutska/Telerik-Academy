function solve(input) {
    'use strict';

    var a = Number(input[0]);
    var b = Number(input[1]);
    var h = Number(input[2]);
    var area = (a + b) * h / 2;

    console.log(area.toFixed(7));
}