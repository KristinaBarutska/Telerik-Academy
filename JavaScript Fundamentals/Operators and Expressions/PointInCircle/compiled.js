function solve(input) {
    "use strict";

    var x = Number(input[0]);
    var y = Number(input[1]);
    var isInside = x * x + y * y <= 4;
    var distance = Math.sqrt(x * x + y * y);

    console.log(isInside ? "yes " + distance.toFixed(2) : "no " + distance.toFixed(2));
}
