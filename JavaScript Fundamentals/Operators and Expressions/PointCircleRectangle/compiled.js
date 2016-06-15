function solve(input) {
    'use strict';

    var x = Number(input[0]);
    var y = Number(input[1]);
    var distance = Math.sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
    var inCircle = distance <= 1.5;
    var inRectangle = x >= -1 && x <= -1 + 6 && y <= 1 && y >= 1 - 2;

    if (inCircle && inRectangle) {
        console.log('inside circle inside rectangle');
    } else if (!inCircle && !inRectangle) {
        console.log('outside circle outside rectangle');
    } else if (inCircle && !inRectangle) {
        console.log('inside circle outside rectangle');
    } else if (!inCircle && inRectangle){
        console.log('outside circle inside rectangle');
    }
}