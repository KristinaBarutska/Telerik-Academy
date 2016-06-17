function solve(input) {
    "use strict";

    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);
    let d = b * b - 4 * a * c;

    if (d < 0) {
        return 'no real roots';
    } else if (d === 0) {
        return `x1=x2=${(-b / (2 * a)).toFixed(2)}`;
    } else {
        return `x1=${((-b - Math.sqrt(d)) / (2 * a)).toFixed(2)}; x2=${((-b + Math.sqrt(d)) / ( 2 * a)).toFixed(2)}`;
    }
}
