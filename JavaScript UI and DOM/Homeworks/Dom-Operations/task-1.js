module.exports = function () {
    const elementString = 'Element';
    const contentsString = 'Contents';
    const divString = 'div';
    const string = 'string';
    const number = 'number';
    const emptyString = '';
    const nullOrUndefinedParameter = ' must not be null or undefined!';
    const invalidElementType = 'Element must be a string or DOM element!';
    const nonArrayContents = 'Contents must be of type array!';
    const invalidContentsElement = 'Contents elements must be a string or a number!';

    function checkIfNullOrUndefined(parameter, valueName) {
        if (parameter === null || parameter === undefined) {
            throw new Error(`${valueName} ${nullOrUndefinedParameter}`);
        }
    }

    function validateElement(element) {
        checkIfNullOrUndefined(element, elementString);

        if (typeof element !== string && !(element instanceof HTMLElement)) {
            throw new Error(invalidElementType);
        }
    }

    function validateContents(contents) {
        checkIfNullOrUndefined(contents, contentsString);

        if (!Array.isArray(contents)) {
            throw new Error(nonArrayContents);
        }

        contents.forEach(element => {
            if (typeof element !== string && typeof element !== number) {
                throw new Error(invalidContentsElement);
            }
        });
    }

    function appendContents(element, contents) {
        validateElement(element);
        validateContents(contents);

        element = typeof element === string ? document.getElementById(element) : element;
        element.innerHTML = emptyString;

        let div = document.createElement(divString);
        let fragment = document.createDocumentFragment();

        for (let i = 0, len = contents.length; i < len; i += 1) {
            let currentDiv = div.cloneNode(true);

            currentDiv.innerHTML = contents[i];
            fragment.appendChild(currentDiv);
        }

        element.appendChild(fragment);
    }

    return function (element, contents) {
        appendContents(element, contents);
    };
};