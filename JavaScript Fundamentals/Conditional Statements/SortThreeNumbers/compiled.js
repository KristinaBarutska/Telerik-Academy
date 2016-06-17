function solve(input) {
    "use strict";

    var a = Number(input[0]);
    var b = Number(input[1]);
    var c = Number(input[2]);
    var result = '';

    if (a > b) {
        if (a > c) {
            result += a;

            if (b > c) {
                result += " " + b + " " + c;
            } else {
                result += " " + c + " " + b;
            }
        } else {
            result = c + " " + a + " " + b;
        }
    } else {
        if (b > c) {
            result += b;

            if (c > a) {
                result += " " + c + " " + a;
            } else {
                result += " " + a + " " + c;
            }
        } else {
            result = c + " " + b + " " + a;
        }
    }

    return result;
}
