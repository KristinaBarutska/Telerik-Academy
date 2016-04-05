(function () {
    var html = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>' +
    'and more...</div>in body</body></html>';
    var sb = new StringBuilder();
    var len = html.length;
    var whiteSpace = ' ';
    var openingTag = '<';
    var closingTag = '>';
    var inTag = false;
    var inText = false;

    for (let i = 0; i < len; i += 1) {
        if (html.substr(i, openingTag.length) === openingTag) {
            inTag = true;
            inText = false;
        }

        if (html.substr(i, closingTag.length) === closingTag) {
            inText = true;
            continue;
        }

        if (inText) {
            sb.append(html[i]);

            if (html.substr(i, openingTag.length) === openingTag) {
                sb.append(whiteSpace);
            }
        }
    }

    let text = sb.toString();

    console.log(text);
})();