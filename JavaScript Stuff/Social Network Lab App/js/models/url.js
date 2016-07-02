(function () {
    'use strict';

    define([], () => {
        let appId = 'kid_rJqjWZVI/';
        let baseUrl = 'https://baas.kinvey.com/';
        let loginUrl = `${baseUrl}user/${appId}login/`;
        let currentUserUrl = `${baseUrl}user/${appId}_me`;
        let baseUserUrl = `${baseUrl}user/${appId}`;
        let logoutUrl = baseUserUrl + '_logout';
        let basePostsUrl = baseUrl + 'appdata/' + appId + 'posts/';

        return {
            baseUrl: baseUrl,
            loginUrl: loginUrl,
            currentUserUrl: currentUserUrl,
            baseUserUrl: baseUserUrl,
            logoutUrl: logoutUrl,
            basePostsUrl: basePostsUrl
        };
    });
}());