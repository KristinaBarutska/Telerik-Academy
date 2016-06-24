function solve(input) {
    'use strict';

    let point = (function () {
        let point = Object.create({});

        Object.defineProperty(point, 'init', {
            value: function (x, y) {
                this.x = x;
                this.y = y;
                return this;
            }
        });

        Object.defineProperty(point, 'x', {
            get: function () {
                return this._x;
            },
            set: function (value) {
                this._x = value;
            }
        });

        Object.defineProperty(point, 'y', {
            get: function () {
                return this._y;
            },
            set: function (value) {
                this._y = value;
            }
        });

        return point;
    } ());

    let line = (function () {
        let line = Object.create({});

        Object.defineProperty(line, 'init', {
            value: function (firstPoint, secondPoint) {
                this.firstPoint = firstPoint;
                this.secondPoint = secondPoint;
                return this;
            }
        });

        Object.defineProperty(line, 'firstPoint', {
            get: function () {
                return this._firstPoint;
            },
            set: function (value) {
                this._firstPoint = value;
            }
        });

        Object.defineProperty(line, 'secondPoint', {
            get: function () {
                return this._secondPoint;
            },
            set: function (value) {
                this._secondPoint = value;
            }
        });

        Object.defineProperty(line, 'calculateLength', {
            value: function () {
                let xSqrt = this.secondPoint.x - this.firstPoint.x;
                let ySqrt = this.secondPoint.y - this.firstPoint.y;
                let lineLength = Math.sqrt((xSqrt * xSqrt) + (ySqrt * ySqrt));

                return lineLength;
            }
        });

        return line;
    } ());

    function checkIfLinesFormTriangle(firstLine, secondLine, thirdLine) {
        let firstLineLength = firstLine.calculateLength();
        let secondLineLength = secondLine.calculateLength();
        let thirdLineLength = thirdLine.calculateLength();

        return (firstLineLength + secondLineLength > thirdLineLength) &&
            (firstLineLength + thirdLineLength > secondLineLength) &&
            (secondLineLength + thirdLineLength > firstLineLength);
    }

    input = input.map(Number);
    let firstLinePointX = Object.create(point).init(input[0], input[1]);
    let firstLinePointY = Object.create(point).init(input[2], input[3]);

    let secondLinePointX = Object.create(point).init(input[4], input[5]);
    let secondLinePointY = Object.create(point).init(input[6], input[7]);

    let thirdLinePointX = Object.create(point).init(input[8], input[9]);
    let thirdLinePointY = Object.create(point).init(input[10], input[11]);

    let firstLine = Object.create(line).init(firstLinePointX, firstLinePointY);
    let secondLine = Object.create(line).init(secondLinePointX, secondLinePointY);
    let thirdLine = Object.create(line).init(thirdLinePointX, thirdLinePointY);

    let canFormTriangle =
        checkIfLinesFormTriangle(firstLine, secondLine, thirdLine) ?
            'Triangle can be built' :
            "Triangle can not be built";

    console.log(`${firstLine.calculateLength().toFixed(2)}`);
    console.log(`${secondLine.calculateLength().toFixed(2)}`);
    console.log(`${thirdLine.calculateLength().toFixed(2)}`);
    console.log(canFormTriangle);
}

solve([
  '7', '7', '2', '2',
  '5', '6', '2', '2',
  '95', '-14.5', '0', '-0.123'
]);