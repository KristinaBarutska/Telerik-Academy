(function () {
    'use strict';

    define(['requester', 'url', 'header', 'storage'], (requester, url, header, storage) => {
        let user = (function () {
            let user = {};
            let appCredentials = header.getAppCredentials();

            Object.defineProperty(user, 'login', {
                value(username, password) {
                    let data = {
                        username: username,
                        password: password
                    };

                    requester.post(url.loginUrl, appCredentials, data)
                        .then(
                            data => {
                                storage.setSessionToken(data);
                                storage.setUsername(data);
                                storage.setUserId(data);
                            },
                            error => console.error(error)
                        );
                }
            });

            Object.defineProperty(user, 'register', {
                value(username, password) {
                    let data = {
                        username: username,
                        password: password
                    };

                    return requester.post(url.baseUserUrl, appCredentials, data);
                }
            });

            Object.defineProperty(user, 'editProfile', {
                value(data) {
                    let headers = header.getAuthTokenCredentials();
                    let id = storage.getUserId();
                    let updateUrl = url.baseUserUrl + id;

                    return requester.put(updateUrl, headers, data);
                }
            });

            Object.defineProperty(user, 'getById', {
                value(userId) {
                    let headers = header.getUserCredentials('gabo', '123');
                    return requester.get(url.baseUserUrl + userId, headers);
                }
            });

            Object.defineProperty(user, 'getCurrentUserData', {
                value() {
                    return {
                        authToken: sessionStorage.getItem('authToken'),
                        userId: sessionStorage.getItem('userId'),
                        username: sessionStorage.getItem('username')
                    };
                }
            });

            Object.defineProperty(user, 'logout', {
                value() {
                    let headers = header.getAuthTokenCredentials();
                    storage.clear();
                    return requester.post(url.logoutUrl, headers, {});
                }
            });

            return user;
        }());

        return user;
    });
}());