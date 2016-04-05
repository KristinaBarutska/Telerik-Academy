/*
    Problem 1. Reverse string
    Write a JavaScript function that reverses a string and returns it.
*/

(function () {
    var text = 'JavaScript',
        reversed = '',
        len = text.length;

    for (let i = len - 1; i >= 0; i -= 1) {
        reversed += text[i];
    }

    console.log(reversed);
})();