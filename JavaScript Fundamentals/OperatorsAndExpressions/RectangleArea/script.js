/*
 Problem 3. Rectangle area
 Write an expression that calculates rectangle’s area by given width and height.
 Examples:
 width	 height	 area
 3	      4	          12
 2.5	  3	      7.5
 5	      5       25
 */

(function(){
    'use strict';

    function calculateRectangleArea(width, height){
        return width * height;
    }

    console.log(calculateRectangleArea(3, 4));
    console.log(calculateRectangleArea(2.5, 3));
    console.log(calculateRectangleArea(5, 5));
}());