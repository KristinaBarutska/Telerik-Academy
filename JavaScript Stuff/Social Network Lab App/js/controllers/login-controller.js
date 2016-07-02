(function() {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let loginController = (function() {
            let loginController = {};

            Object.defineProperty(loginController, 'loadLogin', {
                value(selector) {
                    $.get('./views/login.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            return loginController;
        }());

        return loginController;
    });
}());