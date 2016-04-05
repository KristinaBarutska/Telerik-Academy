/*
 Problem 4. Number of elements
 Write a function to count the number of div elements on the web page
 */

(function(){
    'use strict';

    function getDivsCount() {
        var divs = document.getElementsByTagName('div');

        return divs.length;
    }

    console.log(getDivsCount());
}());