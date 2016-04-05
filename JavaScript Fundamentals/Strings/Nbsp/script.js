/*
    Problem 5. nbsp
    Write a function that replaces non breaking white-spaces in a text with &nbsp;
*/

(function () {
    var nbsp = '&nbsp',
        whiteSpace = ' ',
        text = 'Write a function that replaces non breaking white-spaces in a text with &nbsp',
        len = text.length,
        sb = new StringBuilder();

    for (var i = 0; i < len; i += 1) {
        if(text.substr(i, 1) === whiteSpace){
            sb.append(nbsp);
        } else {
            sb.append(text[i]);
        }
    }

    let replacedText = sb.toString();

    console.log(text);
    console.log(replacedText);
})();