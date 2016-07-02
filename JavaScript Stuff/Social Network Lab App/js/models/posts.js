(function() {
    'use strict';

    define(['requester', 'header', 'url'], (requester, header, url) => {
        let posts = (function() {
            let posts = {};

            Object.defineProperty(posts, 'addPost', {
                value(data) {
                    let headers = header.getAuthTokenCredentials();
                    return requester.post(url.basePostsUrl, headers, data);
                }
            });

            Object.defineProperty(posts, 'getPostById', {
               value(id) {
                   let headers = header.getAuthTokenCredentials();
                   return requester.get(url.basePostsUrl + id, headers);
               }
            });

            Object.defineProperty(posts, 'getAllPosts', {
               value() {
                   let headers = header.getAuthTokenCredentials();
                   return requester.get(url.basePostsUrl, headers);
               } 
            });

            return posts;
        }());

        return posts;
    });
}());