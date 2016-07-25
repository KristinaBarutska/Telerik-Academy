function solve() {
    var selectedElement;
    var mainContainer = document.createElement('div');
    var mainImage = document.createElement('img');
    var mainImageHeader = document.createElement('h1');
    var aside = document.createElement('div');

    function createMainContainer(items) {
        mainContainer.setAttribute('class', 'image-preview');
        mainContainer.style.cssText = 'width: 80%; float: left;';

        mainImage.setAttribute('src', items[0].url);
        mainImage.style.cssText = 'display: block; margin: 0 auto; width: 80%;';

        mainImageHeader.innerHTML = items[0].title;
        mainImageHeader.style.textAlign = 'center';

        mainContainer.appendChild(mainImageHeader);
        mainContainer.appendChild(mainImage);
        selectedElement.appendChild(mainContainer);
    }

    function createAsideContainer(items) {
        var searchContainer = document.createElement('div');
        var inputSearch = document.createElement('input');
        var searchHeader = document.createElement('span');

        searchContainer.style.cssText = 'width: 75%; margin-left: 35px;';

        searchHeader.innerHTML = 'Filter';
        searchHeader.style.display = 'block';

        searchContainer.appendChild(searchHeader);
        searchContainer.appendChild(inputSearch);

        var ul = document.createElement('ul');
        var li = document.createElement('li');
        var img = document.createElement('img');
        var imgHeader = document.createElement('h3');

        li.setAttribute('class', 'image-container');
        ul.style.cssText = 'list-style-type: none; overflow-y: scroll; height: 650px;';
        img.style.width = '90%';
        aside.style.cssText = 'width: 20%; float: left;';
        imgHeader.style.textAlign = 'center';

        for (var i = 0, len = items.length; i < len; i += 1) {
            var currentItem = items[i];
            var currentImage = img.cloneNode(true);
            var currentImageHeader = imgHeader.cloneNode(true);
            var currentLi = li.cloneNode(true);

            currentImage.setAttribute('src', currentItem.url);
            currentImageHeader.innerHTML = currentItem.title;
            currentLi.appendChild(currentImageHeader);
            currentLi.appendChild(currentImage);
            ul.appendChild(currentLi);
        }

        aside.appendChild(searchContainer);
        aside.appendChild(ul);
        selectedElement.appendChild(aside);
    }

    function attachHoverEvent() {
        aside.addEventListener('mouseover', function (event) {
            var target = event.target;

            if (target.nodeName == 'LI') {
                target.style.backgroundColor = 'lightgray';
            } else if (target.nodeName === 'IMG' || target.nodeName === 'H3') {
                target.parentNode.style.backgroundColor = 'lightgray';
            }
        });

        aside.addEventListener('mouseout', function (event) {
            var target = event.target;

            if (target.nodeName == 'LI') {
                target.style.backgroundColor = 'white';
            } else if (target.nodeName === 'IMG' || target.nodeName === 'H3') {
                target.parentNode.style.backgroundColor = 'white';
            }
        });
    }

    function attachClickEvent() {
        aside.addEventListener('click', function (event) {
            var imgSrc;
            var title;
            var target = event.target;

            if (target.nodeName === 'LI') {
                imgSrc = target.lastChild.getAttribute('src');
                title = target.firstChild.innerHTML;
            } else if (target.nodeName === 'IMG') {
                imgSrc = target.getAttribute('src');
                title = target.previousElementSibling.innerHTML;
            } else if (target.nodeName === 'H3') {
                imgSrc = target.nextElementSibling.getAttribute('src');
                title = target.innerHTML;
            } else {
                return;
            }

            mainImage.setAttribute('src', imgSrc);
            mainImageHeader.innerHTML = title;
        });
    }

    function filterElements() {
        aside.addEventListener('input', function (event) {
            var target = event.target;

            if (target.nodeName === 'INPUT') {
                var text = target.value;
                var liElements = aside.getElementsByTagName('ul')[0].childNodes;

                for (var i = 0, len = liElements.length; i < len; i += 1) {
                    var currentLi = liElements[i];
                    var currentTitle = currentLi.firstChild.innerHTML;

                    if (currentTitle.toLowerCase().indexOf(text.toLowerCase()) === -1) {
                        currentLi.style.display = 'none';
                    } else {
                        currentLi.style.display = 'block';
                    }
                }
            }
        });
    }

    return function (selector, items) {
        selectedElement = document.querySelector(selector);

        createMainContainer(items);
        createAsideContainer(items);

        attachHoverEvent();
        attachClickEvent();
        filterElements();
    };
}

module.exports = solve;