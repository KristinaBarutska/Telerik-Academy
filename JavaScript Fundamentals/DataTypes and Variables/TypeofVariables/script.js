/*
 Problem 3. Typeof variables
 Try typeof on all variables you created.
 */

(function(){
    'use strict';

    let variables = ['str', 11, {}, [], null, true, undefined];
    variables.forEach(e => console.log(typeof e));
}());