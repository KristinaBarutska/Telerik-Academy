(function() {
    'use strict';

    define(['homeView'], (homeView) => {
        let homeController = (function() {
            let homeController = {};

            Object.defineProperty(homeController, 'loadHome', {
                value(selector) {
                    homeView.render(selector);
                }
            });

            return homeController;
        }());

        return homeController;
    });
}());
