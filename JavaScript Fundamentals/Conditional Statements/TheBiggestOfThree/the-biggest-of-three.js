function solve(input) {
    "use strict";
    
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);

    if (a > b) {
        if (a > c) {
            return a;
        }
        else {
            return c;
        }
    }
    else {
        if (b > c) {
            return b;
        }
        else {
            return c;
        }
    }
}