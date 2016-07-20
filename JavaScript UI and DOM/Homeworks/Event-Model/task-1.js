function solve() {
    'use strict';

    const string = 'string';
    const buttonClass = 'button';
    const contentClass = 'content';
    const none = 'none';
    const hide = 'hide';
    const show = 'show';
    const click = 'click';
    const emptyString = '';
    const nonSelectableItem = 'The selector does not select anything!';
    const nullOrUndefinedParameter = 'Parameter cannot be null or undefined!';
    const invalidParameterType = 'Parameter must be a string or DOM element!';

    function validateParameter(parameter) {
        if (parameter === undefined || parameter === null) {
            throw new Error(nullOrUndefinedParameter);
        } else if (typeof parameter !== string && !(parameter instanceof HTMLElement)) {
            throw new Error(invalidParameterType);
        }
    }

    function getElement(selector) {
        validateParameter(selector);

        if (typeof selector === string) {
            let element = document.getElementById(selector);

            if (element === null) {
                throw new Error(nonSelectableItem);
            }

            return element;
        }

        return selector;
    }

    function getContent(event) {
        let content = event.target.nextElementSibling;

        while (content.className !== contentClass) {
            content = content.nextElementSibling;
        }

        return content;
    }

    function getButton(event, content) {
        let button = event.target.nextElementSibling;

        if (content && content.className === contentClass) {
            while (button.className !== buttonClass) {
                button = button.nextElementSibling;
            }
        }

        return button;
    }

    function buttonClick(event) {
        let content = getContent(event);
        let button = getButton(event, content);

        if (button.className === buttonClass) {
            if (content.style.display === none) {
                content.style.display = emptyString;
                event.target.innerHTML = hide;
            } else {
                content.style.display = none;
                event.target.innerHTML = show;
            }
        }
    }

    return function (selector) {
        let element = getElement(selector);
        let buttons = []
            .slice
            .call(element.children)
            .filter(e => e.className === buttonClass)
            .forEach(e => {
                e.innerHTML = hide;
                e.addEventListener(click, buttonClick);
            });
    };
}

module.exports = solve;