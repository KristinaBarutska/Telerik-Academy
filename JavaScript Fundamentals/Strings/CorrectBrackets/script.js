/*
    Problem 2. Correct brackets
    Write a JavaScript function to check if in a given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/

(function () {
    function checkBrackets(expression) {
        var openingBracketsCounter = 0,
            len = expression.length;

        for (let i = 0; i < len; i++) {
            if (expression[i] === '(') {
                openingBracketsCounter++;
            }

            if (expression[i] === ')') {
                openingBracketsCounter--;
            }
        }

        return openingBracketsCounter === 0;
    }

    console.log(`Correct brackets in ((a+b)/5-d) ? ${checkBrackets('((a+b)/5-d)')}`);
    console.log(`Correct brackets in )(a+b)) ? ${checkBrackets(')(a+b))')}`);
})();