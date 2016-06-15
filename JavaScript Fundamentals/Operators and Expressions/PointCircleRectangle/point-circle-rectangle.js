function solve(input) {
    'use strict';
    
    let x = Number(input[0]);
    let y = Number(input[1]);
    let distance = Math.sqrt(((x - 1) * (x - 1)) + ((y - 1) * (y - 1)));
    let inCircle = distance <= 1.5;
    let inRectangle = (x >= -1 && x <= -1 + 6) && (y <= 1 && y >= 1 - 2);

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