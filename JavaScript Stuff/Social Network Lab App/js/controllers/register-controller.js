(function() {
    'use strict';

    define(['registerView', 'user'], (registerView, user) => {
        let registerController = (function() {
            let registerController = {};

            Object.defineProperty(registerController, 'loadRegister', {
                value(selector, eventSelector) {
                    registerView.render(selector)
                        .then(
                            success => this.attachEventHandlers(eventSelector),
                            error => console.error(error)
                        );
                }
            });

            Object.defineProperty(registerController, 'attachEventHandlers', {
                value(selector) {
                    $(selector).on('click', () => {
                        let userData = registerView.getRegisterInfo();

                        user
                            .register(userData)
                            .then(
                                success => window.location.replace('http://127.0.0.1:8080/#/login'),
                                error => console.log(error)
                            );
                    });
                }
            });

            return registerController;
        }());

        return registerController;
    });
}());
