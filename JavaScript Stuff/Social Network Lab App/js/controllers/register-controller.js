(function() {
    'use strict';

    define(['registerView'], (registerView) => {
        let registerController = (function() {
            let registerController = {};

            Object.defineProperty(registerController, 'loadRegister', {
                value(selector) {
                    registerView.render(selector);
                }
            });

            return registerController;
        }());

        return registerController;
    });
}());
