/* globals module, document, HTMLElement, console */
// element.className += 'class1 class2';

function solve() {
    var selectedElement,
        header,
        search,
        results,
        itemsList = document.createElement('ul');

    function createHeader() {
        header = document.createElement('div');
        var enterText = document.createElement('span');
        var inputAdd = document.createElement('input');
        var btnAdd = document.createElement('button');

        header.setAttribute('class', 'add-controls');
        enterText.innerHTML = 'Enter text';
        btnAdd.innerHTML = 'Add';
        btnAdd.setAttribute('class', 'button');

        header.appendChild(enterText);
        header.appendChild(inputAdd);
        header.appendChild(btnAdd);
        selectedElement.appendChild(header);
    }

    function createSearch() {
        search = document.createElement('div');
        var searchText = document.createElement('span');
        var inputSearch = document.createElement('input');

        search.setAttribute('class', 'search-controls');
        searchText.innerHTML = 'Search';

        search.appendChild(searchText);
        search.appendChild(inputSearch);
        selectedElement.appendChild(search);
    }

    function createResults() {
        results = document.createElement('div');

        results.setAttribute('class', 'result-controls');
        selectedElement.appendChild(results);
    }

    function addItem() {
        var btn = document.querySelector('.add-controls .button');
        var input = btn.previousElementSibling;

        btn.addEventListener('click', function (event) {
            var item = document.createElement('li');
            var btnRemove = document.createElement('button');
            var textHolder = document.createElement('span');
            var text = input.value;

            btnRemove.innerHTML = 'X';
            btnRemove.setAttribute('class', 'button');
            textHolder.innerHTML = text;
            item.setAttribute('class', 'list-item');
            item.appendChild(btnRemove);
            item.appendChild(textHolder);
            itemsList.appendChild(item);
        });
    }

    function removeItem() {
        results.addEventListener('click', function (event) {
            var target = event.target;

            if (target.nodeName === 'BUTTON') {
                var parent = target.parentNode;
                parent.parentNode.removeChild(parent);
            }
        });
    }

    function searchElement(isCaseSensitive) {
        search.addEventListener('input', function (event) {
            var target = event.target;

            if (target.nodeName === 'INPUT') {
                var text = target.value;
                var liElements = itemsList.childNodes;

                for (var i = 0, len = liElements.length; i < len; i += 1) {
                    var currentLiText = liElements[i].lastChild.innerHTML;

                    if (isCaseSensitive) {
                        if (currentLiText.indexOf(text) === -1) {
                            liElements[i].style.display = 'none';
                        } else {
                            liElements[i].style.display = 'block';
                        }
                    } else {
                        if (currentLiText.toLowerCase().indexOf(text.toLocaleLowerCase()) === -1) {
                            liElements[i].style.display = 'none';
                        } else {
                            liElements[i].style.display = 'block';
                        }
                    }
                }
            }
        });
    }

    return function (selector, isCaseSensitive) {
        selectedElement = document.querySelector(selector);

        createHeader();
        createSearch();
        createResults();

        selectedElement.setAttribute('class', 'items-control');
        itemsList.setAttribute('class', 'items-list');
        results.appendChild(itemsList);

        addItem();
        removeItem();
        searchElement(isCaseSensitive);
    }
}

module.exports = solve();
