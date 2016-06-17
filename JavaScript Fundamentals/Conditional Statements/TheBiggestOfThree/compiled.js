function solve(input) {
    "use strict";

    var a = Number(input[0]);
    var b = Number(input[1]);
    var c = Number(input[2]);

    if (a > b) {
        if (a > c) {
            return a;
        } else {
            return c;
        }
    } else {
        if (b > c) {
            return b;
        } else {
            return c;
        }
    }
}
