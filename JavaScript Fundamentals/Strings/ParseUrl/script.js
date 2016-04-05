/*  
    Problem 7. Parse URL
    Write a script that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
    Return the elements in a JSON object.
*/

(function () {
    var url = 'http://telerikacademy.com/Courses/Courses/Details/239';
    var len = url.length;
    var protocol = '';
    var server = '';
    var resource = '';
    var indexOfColon = url.indexOf(':', 0);
    var endOfProtocol = '://';
    var endOfServer = '/';
    var inProtocol = false;
    var inServer = false;
    var inResource = false;

    for (let i = 0; i < len; i += 1) {
        if (i < indexOfColon) {
            inProtocol = true;
        }

        if (url.substr(i, endOfProtocol.length) === endOfProtocol) {
            inServer = true;
            inProtocol = false;
            i += endOfProtocol.length;
        }

        if (url.substr(i, endOfServer.length) === endOfServer && inServer) {
            inResource = true;
            inServer = false;
          
        }

        if (inProtocol) {
            protocol += url[i];
        }

        if (inServer) {
            server += url[i];
        }

        if (inResource) {
            resource += url[i];
        }
    }

    console.log(`protocol: ${protocol}`);
    console.log(`server: ${server}`);
    console.log(`resource: ${resource}`);
})();