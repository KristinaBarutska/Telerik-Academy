(function () {
    String.prototype.format = function (options) {
        var pattern = /#{[a-z]+}/g;
        var matches = this.match(pattern);
        var text = this;

        for (let i = 0; i < matches.length; i += 1) {
            let nameOfProperty = matches[i].substring(2, matches[i].length - 1);
            text = text.replace(matches[i], options[nameOfProperty]);
        }

        return text;
    }

    var options = {
        name: 'John',
        age: 13
    };
    var text = 'My name is #{name} and I am #{age}-years-old';

    var formattedText = text.format(options)

    console.log(formattedText);
})();