(function () {
    'use strict';

    require.config({
        paths: {
            'jquery': '../bower_components/jquery/dist/jquery.min',
            'sammy': '../bower_components/sammy/lib/sammy',
            'mustache': '../bower_components/mustache.js/mustache',
            'requester': './models/requester',
            'header': './models/header',
            'url': './models/url',
            'storage': './models/storage',
            'user': './models/user',
            'posts': './models/posts',
            'homeController': './controllers/home-controller',
            'loginController': './controllers/login-controller',
            'registerController': './controllers/register-controller'
        }
    });

    require(['sammy', 'homeController', 'loginController', 'registerController'],
        (Sammy, homeController, loginController, registerController) => {
        let mainSelector = '#main';
        
        let router = Sammy(function () {
            this.get('#/', function () {
                homeController.loadHome(mainSelector);
            });

            this.get('#/login', function () {
                loginController.loadLogin(mainSelector);
            });

            this.get('#/register', function () {
                registerController.loadRegister(mainSelector);
            });
        });

        router.run('#/');
    });
}());
