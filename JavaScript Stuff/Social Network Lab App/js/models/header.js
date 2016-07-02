(function () {
    'use strict';

    define(['storage'], (storage) => {
        let header = (function () {
            let header = {};

            Object.defineProperty(header, 'init', {
                value() {
                    this.appKey = 'kid_rJqjWZVI';
                    this.appSecret = 'c009b5a5051f4ad791cf67c3be419dd9';
                    this.masterScret = 'acc98faeb5ba436783632588f1e5b624';
                    return this;
                }
            });

            Object.defineProperty(header, 'getAppCredentials', {
                value() {
                    let encodedAppCredentials = window.btoa(`${this.appKey}:${this.appSecret}`);
                    let appCredentials = `Basic ${encodedAppCredentials}`;

                    return {
                        'Content-Type': 'application/json',
                        'Authorization': appCredentials
                    };
                }
            });

            Object.defineProperty(header, 'getUserCredentials', {
                value(username, password) {
                    let encodedUserCredentials = window.btoa(`${username}:${password}`);
                    let userCredentials = `Basic ${encodedUserCredentials}`;

                    return {
                        'Content-Type': 'application/json',
                        'Authorization': userCredentials
                    };
                }
            });

            Object.defineProperty(header, 'getAuthTokenCredentials', {
                value() {
                    let authToken = storage.getSessionToken();
                    return {
                        'Content-Type': 'application/json',
                        'Authorization': `Kinvey ${authToken}`
                    };
                }
            });

            return header;
        }());

        return Object
            .create(header)
            .init();
    });
}());