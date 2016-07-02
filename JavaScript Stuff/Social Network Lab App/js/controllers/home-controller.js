(function () {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let homeController = (function () {
            let homeController = {};

            Object.defineProperty(homeController, 'loadHome', {
                value(selector) {
                    $.get('./views/guest-home.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            return homeController;
        }());

        return homeController;
    });
}());