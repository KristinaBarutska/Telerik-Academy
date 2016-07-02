(function () {
    'use strict';

    define(['requester', 'url', 'header'], (requester, url, header) => {
        let storage = (function () {
            let storage = {};

            Object.defineProperty(storage, 'setSessionToken', {
                value(data) {
                    sessionStorage.setItem('authToken', data._kmd.authtoken);
                }
            });

            Object.defineProperty(storage, 'getSessionToken', {
                value() {
                    return sessionStorage.getItem('authToken');
                }
            });

            Object.defineProperty(storage, 'setUserId', {
               value(data) {
                   sessionStorage.setItem('userId', data._id);
               }
            });

            Object.defineProperty(storage, 'getUserId', {
                value() {
                    return sessionStorage.getItem('userId');
                }
            });

            Object.defineProperty(storage, 'setUsername', {
                value(data) {
                    sessionStorage.setItem('username', data.username);
                }
            });

            Object.defineProperty(storage, 'getUsername', {
                value() {
                    return sessionStorage.getItem('username');
                }
            });
            
            Object.defineProperty(storage, 'clear', {
               value() {
                   sessionStorage.clear();
               } 
            });

            return storage;
        }());

        return storage;
    });
}());