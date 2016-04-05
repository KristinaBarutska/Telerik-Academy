/*
    Problem 3. Sub-string in text
    Write a JavaScript function that finds how many times a substring is contained 
    in a given text (perform case insensitive search).
    Example:
    The target sub-string is in
    The text is as follows: We are living in an yellow submarine. We don't have anything 
    else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
*/

(function (undefined) {
    var text = 'We are living in an yellow submarine. We don\'t have anything else. inside the submarine ' +
        'is very tight. So we are drinking all the day. We will move out of it in 5 days';
    var substring = 'in',
        substringCounter = 0,
        len = text.length;

    for (let i = 0; i < len; i += 1) {
        if(text.substring(i, i + 2) === substring){
            substringCounter++;
            i += 2;
        }
    }

    console.log(`'in' appears ${substringCounter} times in the text.`);
})();