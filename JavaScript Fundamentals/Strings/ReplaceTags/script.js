/*
    Problem 8. Replace tags
    Write a JavaScript function that replaces in a HTML document given as string all the tags 
    <a href="…">…</a> with corresponding tags [URL=…]…/URL].
*/

(function () {
    var html = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.' +
        'Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'
    var openingHrefTag = '<a href';
    var closingHrefTag = '</a>';
    var openingUrlTag = '[URL';
    var closingUrlTag = '[/URL]';
    var inHrefTag = false;
    var len = html.length;
    var sb = new StringBuilder();

    for (let i = 0; i < len; i += 1) {
        if (html.substr(i, openingHrefTag.length) === openingHrefTag) {
            sb.append(openingUrlTag);
            i += openingHrefTag.length;
            inHrefTag = true;
        }

        if (html.substr(i, closingHrefTag.length) === closingHrefTag) {
            sb.append(closingUrlTag);
            i += closingHrefTag.length;
        }

        if (inHrefTag) {
            if(html.substr(i,1) == '>'){
                sb.append(']');
                inHrefTag = false;
                continue;
            }
        }

        sb.append(html[i]);
    }

    let replacedTags = sb.toString();

    console.log(replacedTags);
})();