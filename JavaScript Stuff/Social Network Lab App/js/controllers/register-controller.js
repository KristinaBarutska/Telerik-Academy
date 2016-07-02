(function() {
    'use strict';
    
    define(['jquery', 'mustache'], ($, Mustache) => {
        let registerController = (function() {
            let registerController = {};

            Object.defineProperty(registerController, 'loadRegister', {
                value(selector) {
                    $.get('./views/register.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });
            
            return registerController;
        }());
        
        return registerController;
    });
}());