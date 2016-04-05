/*
 * Write functions for working with shapes in standard Planar coordinate system.
   Points are represented by coordinates P(X, Y)
   Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
   Calculate the distance between two points.
   Check if three segment lines can form a triangle.
 */

(function () {
    'use strict';

    function Point(x, y) {
        this.x = x;
        this.y = y;
    }

    function Line(firstPoint, secondPoint) {
        this.start = firstPoint;
        this.end = secondPoint;
        this.length = calculateDistanceBetweenPoints(firstPoint, secondPoint);
    }

    function calculateDistanceBetweenPoints(firstPoint, secondPoint) {
        var distance = Math.sqrt(Math.pow((secondPoint.x - firstPoint.x), 2) +
            Math.pow(((secondPoint.y - firstPoint.y), 2)));
        return distance;
    }

    function checkIfCanFormTriangle(firstLine, secondLine, thirdline) {
        var isTriangle = firstLine.length < secondLine.length + thirdline.length &&
              secondLine.getDistance() < thirdline.getDistance() + firstLine.getDistance() &&
              thirdline.getDistance() < firstLine.getDistance() + secondLine.getDistance();
        return isTriangle;
    }

    let firstPoint = new Point(1, 2);
    let secondPoint = new Point(3, 4);
    let thirdPoint = new Point(5, 6);
    let canFormTriangle = checkIfCanFormTriangle(firstPoint, secondPoint, thirdPoint);

    console.log(`Can form triangle ? : ${canFormTriangle}`);
}());