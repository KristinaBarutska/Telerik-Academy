/*
 Problem 3. Occurrences of word
 Write a function that finds all the occurrences of word in a text.
 The search can be case sensitive or case insensitive.
 Use function overloading.
 */

(function () {
    'use strict';

    function searchWord(text, word, caseSensitive) {
        var sensitive = caseSensitive || false,
            textReplaced = text.replace(/\W+/g, ' '),
            words = textReplaced.split(' '),
            occurrences = 0;

        if (sensitive) {
            for (let i = 0; i < words.length; i += 1) {
                if (words[i] === word) {
                    occurrences++;
                }
            }
        } else {
            let lower = word.toLowerCase();

            for (let i = 0; i < words.length; i += 1) {
                if (words[i].toLowerCase() === lower) {
                    occurrences++;
                }
            }
        }

        return occurrences;
    }

    console.log(searchWord('javascript dasd k udas nud javascript', 'javascript'));


}());