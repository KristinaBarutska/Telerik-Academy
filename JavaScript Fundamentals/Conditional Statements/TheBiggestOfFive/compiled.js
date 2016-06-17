function solve(input) {
    "use strict";

    var a = Number(input[0]);
    var b = Number(input[1]);
    var c = Number(input[2]);
    var d = Number(input[3]);
    var e = Number(input[4]);
    var max = a;

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
