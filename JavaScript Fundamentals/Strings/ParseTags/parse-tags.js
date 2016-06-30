function solve(input) {
    'use strict';

    let text = input[0];
    let result = '';

    function parseTags() {
        let inUpcase = false;
        let inLowcase = false;
        let inOrgcase = false;

        text = text.replace(/<orgcase>/g, '');
        text = text.replace(/<\/orgcase>/g, '');
    }

    parseTags();
    console.log(text);
}

solve([ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]);
