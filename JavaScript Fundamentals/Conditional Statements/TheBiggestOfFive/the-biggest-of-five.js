function solve(input) {
    "use strict";
    
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);
    let d = Number(input[3]);
    let e = Number(input[4]);
    let max = a;

    if (max < b) {
        max = b;
    }

    if (max < c) {
        max = c;
    }

    if (max < d) {
        max = d;
    }

    if (max < e) {
        max = e;
    }

    return max;
}
