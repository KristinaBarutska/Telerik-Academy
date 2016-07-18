function createImagesPreviewer(selector, items) {
    'use strict';

    var root = document.querySelector(selector);
    var mainWindow;
    var sideWindow;
    var mainImage;
    var mainHeading;
    var len, i;

    function buildMainWindow() {
        mainWindow = document.createElement('div');

        mainImage = document.createElement('img');
        mainHeading = document.createElement('h1');

        Object.assign(mainWindow.style, {
            width: '80%',
            float: 'left'
        });
        Object.assign(mainImage.style, {
            display: 'block',
            margin: '0 auto',
            borderRadius: '20px',
            width: '80%'
        });
        mainHeading.style.textAlign = 'center';
        mainHeading.innerText = items[0].title;
        mainImage.setAttribute('src', items[0].url);
        mainWindow.classList.add('image-preview');
        mainWindow.appendChild(mainHeading);
        mainWindow.appendChild(mainImage);
        root.appendChild(mainWindow);
    }

    function buildSideWindow() {
        sideWindow = document.createElement('div');

        var searchHolder = document.createElement('div');
        var input = document.createElement('input');
        var searchHeading = document.createElement('p');
        var imagesContainer = document.createElement('ul');
        var imageHolder = document.createElement('li');
        var image = document.createElement('img');
        var imageHeading = document.createElement('h3');

        searchHeading.innerText = 'Search';
        searchHeading.style.display = 'inline-block';
        searchHeading.style.marginLeft = '100px';
        searchHolder.appendChild(searchHeading);
        searchHolder.appendChild(input);
        input.style.marginLeft = '50px';
        Object.assign(imagesContainer.style, {
            listStyleType: 'none',
            height: '600px',
            overflowY: 'scroll'
        });
        imagesContainer.classList.add('image-container');
        Object.assign(image.style, {
            display: 'block',
            margin: '0 auto',
            borderRadius: '10px',
            width: '90%'
        });
        imageHeading.style.textAlign = 'center';

        for (i = 0, len = items.length; i < len; i += 1) {
            var currentImageHeading = imageHeading.cloneNode(true);
            var currentImage = image.cloneNode(true);
            var currentImageHolder = imageHolder.cloneNode(true);

            currentImageHeading.innerText = items[i].title;
            currentImage.setAttribute('src', items[i].url);
            currentImageHolder.appendChild(currentImageHeading);
            currentImageHolder.appendChild(currentImage);
            imagesContainer.appendChild(currentImageHolder);
        }

        Object.assign(sideWindow.style, {
            width: '20%',
            float: 'left'
        });
        sideWindow.appendChild(searchHolder);
        sideWindow.appendChild(imagesContainer);
        root.appendChild(sideWindow);
    }

    function changeSelectedImage() {
        sideWindow.addEventListener('click', function (event) {
            var target = event.target;

            if (target.nodeName === 'IMG') {
                mainImage.setAttribute('src', target.getAttribute('src'));
                mainHeading.innerText = target.previousSibling.innerText;
            } else if (target.nodeName === 'H3') {
                mainImage.setAttribute('src', target.nextSibling.getAttribute('src'));
                mainHeading.innerText = target.innerText;
            } else if (target.nodeName === 'LI') {
                mainImage.setAttribute('src', target.childNodes.firstChild.getAttribute('src'));
                mainHeading.innerText = target.childNodes.lastChild.innerText;
            }
        });
    }

    function changeBackgroundOnHover() {
        sideWindow.addEventListener('mouseover', function (event) {
            var target = event.target;

            if (target.nodeName === 'IMG' || target.nodeName === 'H3') {
                target.parentNode.style.backgroundColor = 'lightgray';
            } else if (target.nodeName === 'LI') {
                target.style.backgroundColor = 'lighgray';
            }

            target.style.cursor = 'pointer';
        });

        sideWindow.addEventListener('mouseout', function (event) {
            var target = event.target;

            if (target.nodeName === 'IMG' || target.nodeName === 'H3') {
                target.parentNode.style.backgroundColor = 'white';
            } else if (target.nodeName === 'LI') {
                target.style.backgroundColor = 'white';
            }
        });
    }

    function filterSearches() {
        sideWindow.addEventListener('keyup', function (event) {
            var target = event.target;
            var text;
            var images = sideWindow.getElementsByTagName('img');

            if (target.nodeName === 'INPUT') {
                text = target.value;

                for (i = 0, len = images.length; i < len; i += 1) {
                    if (images[i].previousSibling.innerText.toLowerCase().indexOf(text.toLowerCase()) === -1) {
                        images[i].parentNode.style.display = 'none';
                    } else {
                        images[i].parentNode.style.display = 'block';
                    }
                }
            }
        });
    }

    buildMainWindow();
    buildSideWindow();
    changeSelectedImage();
    changeBackgroundOnHover();
    filterSearches();
}