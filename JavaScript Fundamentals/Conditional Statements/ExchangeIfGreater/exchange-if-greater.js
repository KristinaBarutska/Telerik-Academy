function solve(input) {
    "use strict";
    
    let a = Number(input[0]);
    let b = Number(input[1]);

    return a > b ? `${b} ${a}` : `${a} ${b}`;
}