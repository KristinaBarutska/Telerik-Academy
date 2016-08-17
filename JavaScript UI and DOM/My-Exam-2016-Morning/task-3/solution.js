function solve() {
    return function () {
        var template = [
            '<h1>{{title}}</h1>'+
            '<ul>'+
            '{{#posts}}'+
            '<li>'+
            '<div class="post">'+
            '<p class="author">'+
            '<a class="{{#if author}}user{{else}}anonymous{{/if}}" {{#if author}}href="/user/{{author}}"{{/if}}>{{#if author}}{{author}}{{else}}Anonymous{{/if}}</a>&nbsp;'+
            '</p>'+
            '<pre class="content">{{{text}}}</pre>'+
            '</div>'+
            '<ul>'+
            '{{#comments}}'+
            '{{#unless deleted}}' +
            '<li>'+
            '<div class="comment">'+
            '<p class="author">'+
            '<a class="{{#if author}}user{{else}}anonymous{{/if}}" {{#if author}}href="/user/{{author}}"{{/if}}>{{#if author}}{{author}}{{else}}Anonymous{{/if}}</a>&nbsp;'+
            '</p>'+
            '<pre class="content">{{{text}}}</pre>'+
            '</div>'+
            '</li>'+
            '{{/unless}}' +
            '{{/comments}}'+
            '</ul>'+
            '</li>'+
            '{{/posts}}'+
            '</ul>'
        ].join('\n');

        return template;
    }
}

// submit the above

if (typeof module !== 'undefined') {
    module.exports = solve;
}
