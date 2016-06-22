function solve(input) {
    'use strict';

    var firstString = input[0];
    var secondString = input[1];

    function compareStrings(firstString, secondString) {
        if (firstString.length < secondString.length) {
            return '<';
        } else if (firstString.length > secondString.length) {
            return '>';
        } else {
            var equalitySign = '=';

            for (var i = 0; i < firstString.length; i += 1) {
                if (firstString[i] < secondString[i]) {
                    equalitySign = '<';
                    break;
                } else if (firstString[i] > secondString[i]) {
                    equalitySign[i] = '>';
                    break;
                }
            }

            return equalitySign;
        }
    }

    return compareStrings(firstString, secondString);
}