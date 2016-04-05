(function () {
    function stringFormat() {
        var args = Array.prototype.slice.call(arguments);
        var text = args[0];
        var len = text.length;
        var sb = new StringBuilder();

        for (let i = 0; i < len; i += 1) {
            if (text[i] === '{' && text[i + 2] == '}') {
                let index = Number(text[i + 1]) + 1;

                sb.append(args[index]);
                i += 2;
                index++;
                continue;
            }

            sb.append(text[i]);
        }

        return sb.toString();
    }

    var frmt = '{0}, {1}, {0} text {2}';
    var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');

    console.log(str);
})();