function solve(input) {
    'use strict';

    var result = '';

    function minifyCode() {
        var inputLength = input.length;
        var inBody = false;
        var isTrimming = false;
        var hasSemicolon = false;
        var hasWhiteSpace = false;

        for (var j = 0; j < inputLength; j += 1) {
            var currentLine = input[j].trim();
            var lineLength = currentLine.length;

            for (var i = 0; i < lineLength; i += 1) {
                var currentChar = currentLine[i];

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

var args = ['.muppet      {', '	powers: everything;', '}'];

solve(args);
