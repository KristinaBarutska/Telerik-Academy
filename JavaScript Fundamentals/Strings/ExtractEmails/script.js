/*
    Problem 9. Extract e-mails
    Write a function for extracting all email addresses from given text.
    All sub-strings that match the format @… should be recognized as emails.
    Return the emails as array of strings.
*/

(function () {
    var text = 'abv@abv.bg dsakdd udsa ij mdia gringo@gmail.com';
    var textSplitted = text.split(/[^.,@_\w]/);
    var emails = [];
    var len = textSplitted.length;

    for (let i = 0; i < len; i += 1) {
        if(textSplitted[i].search(/@/) !== -1){
            emails.push(textSplitted[i]);
        }
    }

    console.log(emails.join('\n'));
})();