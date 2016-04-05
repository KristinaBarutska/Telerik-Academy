(function () {
    var text = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t' +
       '</mixcase> have <lowcase>anything</lowcase> else';
    var len = text.length;

    var inMixcase = false,
        inUpcase = false,
        inLowcase = false;

    var mixCaseOpeningTag = '<mixcase>',
        mixCaseClosingTag = '</mixcase>',
        lowCaseOpeningTag = '<lowcase>',
        lowCaseClosingTag = '</lowcase>',
        upCaseOpeningTag = '<upcase>',
        upCaseClosingTag = '</upcase>';

    var sb = new StringBuilder(),
        mixCaseLetterCounter = 0;

    for (let i = 0; i < len; i += 1) {
        if (text.substr(i, mixCaseOpeningTag.length) === mixCaseOpeningTag) {
            inMixcase = true;
            i += mixCaseOpeningTag.length;
        }

        if (text.substr(i, mixCaseClosingTag.length) === mixCaseClosingTag) {
            inMixcase = false;
            i += mixCaseClosingTag.length;
        }

        if (text.substr(i, lowCaseOpeningTag.length) === lowCaseOpeningTag) {
            inLowcase = true;
            i += lowCaseOpeningTag.length;
        }

        if (text.substr(i, lowCaseClosingTag.length) === lowCaseClosingTag) {
            inLowcase = false;
            i += lowCaseClosingTag.length;
        }

        if (text.substr(i, upCaseOpeningTag.length) === upCaseOpeningTag) {
            inUpcase = true;
            i += upCaseOpeningTag.length;
        }

        if (text.substr(i, upCaseClosingTag.length) === upCaseClosingTag) {
            inUpcase = false;
            i += upCaseClosingTag.length;
        }

        if (inMixcase) {
            if (Math.floor(mixCaseLetterCounter % 2) === 0) {
                sb.append(text[i].toUpperCase());
                mixCaseLetterCounter++;
            } else {
                sb.append(text[i].toLowerCase());
                mixCaseLetterCounter++;
            }
        } else if (inLowcase) {
            sb.append(text[i].toLowerCase());
        } else if (inUpcase) {
            sb.append(text[i].toUpperCase());
        } else {
            sb.append(text[i]);
        }
    }

    let resultText = sb.toString();

    console.log(resultText);
})();