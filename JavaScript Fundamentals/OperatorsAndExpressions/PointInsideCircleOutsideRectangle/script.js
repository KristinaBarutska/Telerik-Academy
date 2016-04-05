/*
 Problem 9. Point in Circle and outside Rectangle
 Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).
 Examples:
 x	y	inside K & outside of R
 1	4	yes
 3	2	yes
 0	1	no
 */

(function () {
    'use strict';

    function checkPoint(x, y) {
        var distance = Math.sqrt(((x - 1) * (x - 1)) + ((y - 1) * (y - 1))),
            inCircle = distance <= 3,
            inRect = (x >= -1 && x <= -1 + 6) && (y <= 1 && y >= 1 - 2);

        return inCircle && !inRect;
    }

    console.log(checkPoint(1, 4) ? 'yes' : 'no');
    console.log(checkPoint(3, 2) ? 'yes' : 'no');
    console.log(checkPoint(0, 1) ? 'yes' : 'no');
}());