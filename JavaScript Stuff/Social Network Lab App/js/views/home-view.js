(function() {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let homeView = (function() {
            let homeView = {};

            Object.defineProperty(homeView, 'render', {
                value(selector) {
                    $.get('./views/guest-home.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            return homeView;
        }());

        return homeView;
    });
}());
