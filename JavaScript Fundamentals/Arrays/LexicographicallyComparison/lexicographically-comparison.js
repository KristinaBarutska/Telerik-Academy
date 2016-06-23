function solve(input) {
    'use strict';

    function compareStrings(firstString, secondString) {
        let result = firstString.localeCompare(secondString);

        if (result < 0) {
            return '<';
        } else if (result > 0) {
            return '>';
        } else {
            return '=';
        }
    }

    let inputSplitted = input[0].split('\n').filter(s => s !== '');
    let firstString = inputSplitted[0].trim();
    let secondString = inputSplitted[1].trim();
    let result = compareStrings(firstString, secondString);

    console.log(result);
}
