var StringBuilder = (function () {
    function StringBuilder() {
        this.container = [];
        this.index = 0;
    }

    StringBuilder.prototype.append = function (stringToAppend) {
        this.container[this.index] = stringToAppend;
        this.index++;
    }

    StringBuilder.prototype.toString = function () {
        return this.container.join('');
    }

    return StringBuilder;
})();