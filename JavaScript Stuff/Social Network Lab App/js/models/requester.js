(function () {
    'use strict';

    define(['jquery'], $ => {
        function makeRequest(method, url, headers, data) {
            let promise = new Promise((resolve, reject) => {
                $.ajax({
                    method: method,
                    url: url,
                    headers: headers,
                    data: JSON.stringify(data),
                    success(data) {
                        resolve(data)
                    },
                    error(error) {
                        reject(error);
                    }
                });
            });

            return promise;
        }

        let requester = (function () {
            let requester = {};

            Object.defineProperty(requester, 'get', {
                value(url, headers) {
                    return makeRequest('GET', url, headers, {});
                }
            });

            Object.defineProperty(requester, 'post', {
                value(url, headers, data) {
                    return makeRequest('POST', url, headers, data);
                }
            });

            Object.defineProperty(requester, 'put', {
                value(url, headers, data) {
                    return makeRequest('PUT', url, headers, data);
                }
            });

            Object.defineProperty(requester, 'delete', {
                value(url, headers) {
                    return makeRequest('DELETE', url, headers, data);
                }
            });
            
            return requester;
        }());

        return Object.create(requester);
    });
}());