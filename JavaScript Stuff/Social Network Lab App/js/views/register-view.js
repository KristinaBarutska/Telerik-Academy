(function() {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let registerView = (function() {
            let registerView = {};

            Object.defineProperty(registerView, 'render', {
                value(selector) {
                    $.get('./views/register.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            return registerView;
        }());

        return registerView;
    });
}());
