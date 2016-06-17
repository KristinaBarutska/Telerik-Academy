function solve(input) {
    "use strict";

    var a = Number(input[0]);
    var b = Number(input[1]);

    return a > b ? b + " " + a : a + " " + b;
}
