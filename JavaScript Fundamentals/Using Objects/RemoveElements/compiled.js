'use strict';

function solve(input) {
    'use strict';

    Array.prototype.remove = function (element) {
        return [].filter.call(this, function (s) {
            return s !== element;
        });
    };

    var elementToRemove = input[0];
    input = input.remove(elementToRemove).join('\n');
    console.log(input);
}

solve(['_h/_', '^54F#', 'V', '^54F#', 'Z285', 'kv?tc`', '^54F#', '_h/_', 'Z285', '_h/_', 'kv?tc`', 'Z285', '^54F#', 'Z285', 'Z285', '_h/_', '^54F#', 'kv?tc`', 'kv?tc`', 'Z285']);
