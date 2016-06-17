function solve(input) {
    "use strict";

    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);
    let result = '';

    if (a > b) {
        if (a > c) {
            result += a;

            if (b > c) {
                result += ` ${b} ${c}`;
            }
            else {
                result += ` ${c} ${b}`;
            }
        }
        else {
            result = `${c} ${a} ${b}`;
        }
    }
    else {
        if (b > c) {
            result += b;

            if (c > a) {
                result += ` ${c} ${a}`;
            }
            else {
                result += ` ${a} ${c}`;
            }
        }
        else {
            result = `${c} ${b} ${a}`;
        }
    }

    return result;
}
