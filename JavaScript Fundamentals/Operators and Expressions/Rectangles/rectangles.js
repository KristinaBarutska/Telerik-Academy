function solve(input) {
    'use strict';

    let width = Number(input[0]);
    let height = Number(input[1]);
    let perimeter = 2 * width + 2 * height;
    let area = width * height;

    console.log(`${area.toFixed(2)} ${perimeter.toFixed(2)}`);
}