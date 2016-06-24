'use strict';

function solve(input) {
    'use strict';

    var point = function () {
        var point = Object.create({});

        Object.defineProperty(point, 'init', {
            value: function value(x, y) {
                this.x = x;
                this.y = y;
                return this;
            }
        });

        Object.defineProperty(point, 'x', {
            get: function get() {
                return this._x;
            },
            set: function set(value) {
                this._x = value;
            }
        });

        Object.defineProperty(point, 'y', {
            get: function get() {
                return this._y;
            },
            set: function set(value) {
                this._y = value;
            }
        });

        return point;
    }();

    var line = function () {
        var line = Object.create({});

        Object.defineProperty(line, 'init', {
            value: function value(firstPoint, secondPoint) {
                this.firstPoint = firstPoint;
                this.secondPoint = secondPoint;
                return this;
            }
        });

        Object.defineProperty(line, 'firstPoint', {
            get: function get() {
                return this._firstPoint;
            },
            set: function set(value) {
                this._firstPoint = value;
            }
        });

        Object.defineProperty(line, 'secondPoint', {
            get: function get() {
                return this._secondPoint;
            },
            set: function set(value) {
                this._secondPoint = value;
            }
        });

        Object.defineProperty(line, 'calculateLength', {
            value: function value() {
                var xSqrt = this.secondPoint.x - this.firstPoint.x;
                var ySqrt = this.secondPoint.y - this.firstPoint.y;
                var lineLength = Math.sqrt(xSqrt * xSqrt + ySqrt * ySqrt);

                return lineLength;
            }
        });

        return line;
    }();

    function checkIfLinesFormTriangle(firstLine, secondLine, thirdLine) {
        var firstLineLength = firstLine.calculateLength();
        var secondLineLength = secondLine.calculateLength();
        var thirdLineLength = thirdLine.calculateLength();

        return firstLineLength + secondLineLength > thirdLineLength && firstLineLength + thirdLineLength > secondLineLength && secondLineLength + thirdLineLength > firstLineLength;
    }

    input = input.map(Number);
    var firstLinePointX = Object.create(point).init(input[0], input[1]);
    var firstLinePointY = Object.create(point).init(input[2], input[3]);

    var secondLinePointX = Object.create(point).init(input[4], input[5]);
    var secondLinePointY = Object.create(point).init(input[6], input[7]);

    var thirdLinePointX = Object.create(point).init(input[8], input[9]);
    var thirdLinePointY = Object.create(point).init(input[10], input[11]);

    var firstLine = Object.create(line).init(firstLinePointX, firstLinePointY);
    var secondLine = Object.create(line).init(secondLinePointX, secondLinePointY);
    var thirdLine = Object.create(line).init(thirdLinePointX, thirdLinePointY);

    var canFormTriangle = checkIfLinesFormTriangle(firstLine, secondLine, thirdLine) ? 'Triangle can be built' : "Triangle can not be built";

    console.log('' + firstLine.calculateLength().toFixed(2));
    console.log('' + secondLine.calculateLength().toFixed(2));
    console.log('' + thirdLine.calculateLength().toFixed(2));
    console.log(canFormTriangle);
}

solve(['7', '7', '2', '2', '5', '6', '2', '2', '95', '-14.5', '0', '-0.123']);
