(function() {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let loginView = (function() {
            let loginView = {};

            Object.defineProperty(loginView, 'render', {
                value(selector) {
                    $.get('./views/login.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            return loginView;
        }());

        return loginView;
    });
}());
