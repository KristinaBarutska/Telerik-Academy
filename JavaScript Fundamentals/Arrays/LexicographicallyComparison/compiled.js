'use strict';

function solve(input) {
    'use strict';

    function compareStrings(firstString, secondString) {
        var result = firstString.localeCompare(secondString);

        if (result < 0) {
            return '<';
        } else if (result > 0) {
            return '>';
        } else {
            return '=';
        }
    }

    var inputSplitted = input[0].split('\n').filter(function (s) {
        return s !== '';
    });
    var firstString = inputSplitted[0].trim();
    var secondString = inputSplitted[1].trim();
    var result = compareStrings(firstString, secondString);

    console.log(result);
}
