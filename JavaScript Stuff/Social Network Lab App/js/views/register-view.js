(function() {
    'use strict';

    define(['jquery', 'mustache'], ($, Mustache) => {
        let registerView = (function() {
            let registerView = {};

            Object.defineProperty(registerView, 'render', {
                value(selector) {
                    return $.get('./views/register.html', view => {
                        let output = Mustache.render(view, {});
                        $(selector).empty();
                        $(selector).append(output);
                    });
                }
            });

            Object.defineProperty(registerView, 'getRegisterInfo', {
                value() {
                    return {
                        username: $('#reg-username').val(),
                        password: $('#reg-password').val(),
                        name: $('#reg-name').val(),
                        aboutMe: $('#reg-about').val(),
                        gender: $('input[name=gender-radio]:checked').val()
                    };
                }
            });

            return registerView;
        }());

        return registerView;
    });
}());
