function solve(input) {
    'use strict';
    
    let end = Number(input[0]);
    let result = '';

    for (let i = 1; i <= end; i += 1) {
        result += `${i} `;
    }

    console.log(result.trim());
}