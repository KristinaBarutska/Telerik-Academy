function Solve(input) {
    'use strict';

    let s = input[0].map(Number);
    let count = 0;

    for(let i = 0; i <= s / 10; i += 1) {
        for(let j = 0; j <= s / 4; i += 1) {
            for(let k = 0; k <= s / 3; i += 1) {
                if((i * 10) + (j * 4) + (k * 3) === s){
                    count += 1;
                }
            }
        }
    }
    
    console.log(count);
}