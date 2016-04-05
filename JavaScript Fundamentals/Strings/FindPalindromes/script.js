/*
    Problem 10. Find palindromes
    Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */

(function () {
    function checkIfWordIsPalindrome(word) {
        var wordReversed = '';
        var len = word.length;

        for (let i = word.length - 1; i >= 0; i -= 1) {
            wordReversed += word[i];
        }

        return wordReversed === word;
    }

    let text = 'ABBA, dasd as. dasdaspjdhsaodh lamal, dsad exe';
    let patternToSplit = /[.,\/#!$%\^&\*;:{}=\-_`~()\d\s]/g;
    let words = text.split(patternToSplit);
    let palindromes = [];
    let len = words.length;

    for (let i = 0; i < len; i += 1) {
        let isPalindrome = checkIfWordIsPalindrome(words[i]);

        if (isPalindrome && words[i] != '') {
            palindromes.push(words[i]);
        }
    }

    console.log(palindromes.join('\n'));
})();