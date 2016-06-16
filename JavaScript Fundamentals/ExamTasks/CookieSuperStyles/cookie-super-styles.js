function solve(input) {
    'use strict';

    let result = '';

    function minifyCode() {
        let inputLength = input.length;
        let inBody = false;
        let isTrimming = false;
        let hasSemicolon = false;
        let hasWhiteSpace = false;

        for (let j = 0; j < inputLength; j += 1) {
            let currentLine = input[j].trim();
            let lineLength = currentLine.length;

            for (let i = 0; i < lineLength; i += 1) {
                let currentChar = currentLine[i];

                if (isTrimming && currentChar === ' ') {
                    continue;
                } else {
                    isTrimming = false;
                }

                if (hasWhiteSpace && currentChar !== '{') {
                    result += ' ';
                    result += currentChar;
                    hasWhiteSpace = false;
                    continue;
                }

                if (currentChar === ' ' && inBody) {
                    continue;
                }

                if (currentChar === '{') {
                    inBody = true;
                    hasWhiteSpace = false;
                    result += '{';
                    continue;
                }

                if (hasSemicolon) {
                    if (currentChar === '}') {
                        inBody = false;
                        hasSemicolon = false;
                        result += '}';
                        continue;
                    } else {
                        result += ';';
                        result += currentChar;
                        hasSemicolon = false;
                        continue;
                    }
                }

                if (!inBody) {
                    if (currentChar === ' ') {
                        hasWhiteSpace = true;
                        isTrimming = true;
                    } else {
                        result += currentChar;
                    }
                }

                if (inBody) {
                    if (currentChar === ' ') {
                        continue;
                    } else if (currentChar === ';') {
                        hasSemicolon = true;
                        continue;
                    } else {
                        result += currentChar;
                    }
                }
            }
        }
    }

    minifyCode();
    console.log(result);
}

/* let args = [
'#the-big-b{',
'  color: yellow;',
'  size: big;',
'}',
'.muppet{',
'  powers: all;',
'  skin: fluffy;',
'}',
'     .water-spirit         {',
'  powers: water;',
'             alignment    : not-good;',
'				}',
'all{',
'  meant-for: nerdy-children;',
'}',
'.muppet      {',
'	powers: everything;',
'}',
'all            .muppet {',
'	alignment             :             good                             ;',
'}',
'   .muppet+             .water-spirit{',
'   power: everything-a-muppet-can-do-and-water;',
'}'
]; */

let args = [
    '.muppet      {',
    '	powers: everything;',
    '}'
];

solve(args);