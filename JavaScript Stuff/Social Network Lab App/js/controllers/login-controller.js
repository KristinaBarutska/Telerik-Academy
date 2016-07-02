(function() {
    'use strict';

    define(['loginView'], (loginView) => {
        let loginController = (function() {
            let loginController = {};

            Object.defineProperty(loginController, 'loadLogin', {
                value(selector) {
                    loginView.render(selector);
                }
            });

            return loginController;
        }());

        return loginController;
    });
}());
