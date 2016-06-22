'use strict';

function solve(input) {
    'use strict';

    var n = Number(input[0]);
    var numbers = new Array(n);

    for (var i = 0; i < n; i += 1) {
        numbers[i] = i * 5;
    }

    console.log(numbers.join('\n'));
}
