function solve(input) {
    "use strict";

    let isPositive = true;
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);

    if (a >= 0) {
        if (b > 0 && c < 0) {
            isPositive = false;
        }
        else if (b < 0 && c > 0) {
            isPositive = false;
        }
    }
    else {
        if (b > 0 && c > 0) {
            isPositive = false;
        }
        else if (b < 0 && c < 0) {
            isPositive = false;
        }
    }

    if (a === 0 || b === 0 || c === 0) {
        return 0;
    }
    else if (isPositive) {
        return '+';
    }
    else {
        return '-';
    }
}