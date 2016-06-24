'use strict';

function solve(input) {
    'use strict';

    input = input[0].split(' ').map(Number);
    var maxNumber = Math.max.apply(null, input);

    console.log(maxNumber);
}

solve(['7 19 19']);
