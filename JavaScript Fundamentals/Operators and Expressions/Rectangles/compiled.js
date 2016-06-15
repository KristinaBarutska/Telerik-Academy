function solve(input) {
    'use strict';

    var width = Number(input[0]);
    var height = Number(input[1]);
    var perimeter = 2 * width + 2 * height;
    var area = width * height;

    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}
