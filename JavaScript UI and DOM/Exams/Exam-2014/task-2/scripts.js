/// <reference path="../typings/globals/jquery/index.d.ts" />

/* globals $ */
$.fn.gallery = function (colsCount) {
    'use strict';

    var columns = colsCount || 4;
    var $gallery = this;
    var $galleryList = $gallery.children('.gallery-list');
    var $selectedImages = $gallery.find('.selected');
    var $currentImage = $selectedImages.find('#current-image');
    var $prevImage = $selectedImages.find('#previous-image');
    var $nextImage = $selectedImages.find('#next-image');

    function buildTabledView() {
        var $imageContainers = $gallery.find('.image-container');

        $imageContainers.each(function (index, element) {
            if (index % columns === 0) {
                $(element).addClass('clearfix');
            }
        });

        $gallery.addClass('gallery');
        $selectedImages.hide();

    }

    function showSelectedImages() {
        $gallery.on('click', '.image-container', function () {
            var $target = $(this);
            var imagesDataInfo = getSelectedImagesDataInfo($target);
            var imageSources = getImageSources($target, imagesDataInfo);

            setSelectedImageSources(imageSources, imagesDataInfo);
            $galleryList.addClass('disabled-background blurred');
            $selectedImages.show();
        });
    }

    function changeToPreviousImage() {
        $selectedImages.on('click', '.previous-image', function () {
            var imagesDataInfo = getSelectedImagesDataInfo($(this));
            var imageSources = getImageSources($(this), imagesDataInfo);

            setSelectedImageSources(imageSources, imagesDataInfo);
        });
    }

    function changeToNextImage() {
        $selectedImages.on('click', '.next-image', function () {
            var imagesDataInfo = getSelectedImagesDataInfo($(this));
            var imageSources = getImageSources($(this), imagesDataInfo);

            setSelectedImageSources(imageSources, imagesDataInfo);
        });
    }

    function getSelectedImagesDataInfo($currentImageContainer) {
        var currentImageData = Number($currentImageContainer.find('img').attr('data-info'));
        var prevImageData = currentImageData - 1;
        var nextImageData = currentImageData + 1;

        return {
            currentImageData: currentImageData,
            prevImageData: prevImageData < 1 ? $galleryList.children().length : prevImageData,
            nextImageData: nextImageData > $galleryList.children().length ? 1 : nextImageData
        };
    }

    function returnToNormalState() {
        $currentImage.on('click', function () {
            $galleryList.removeClass('disabled-background blurred');
            $selectedImages.hide(); 
        });
    }

    function getImageSources($currentImageContainer, imagesDataInfo) {
        return {
            currentImageSrc: $currentImageContainer.find('img').attr('src'),
            nextImageSrc: $galleryList.find('img[data-info="' + imagesDataInfo.nextImageData + '"]').attr('src'),
            prevImageSrc: $galleryList.find('img[data-info="' + imagesDataInfo.prevImageData + '"]').attr('src')
        };
    }

    function setSelectedImageSources(imageSources, imagesDataInfo) {
        $currentImage.attr('src', imageSources.currentImageSrc).attr('data-info', imagesDataInfo.currentImageData);
        $nextImage.attr('src', imageSources.nextImageSrc).attr('data-info', imagesDataInfo.nextImageData);
        $prevImage.attr('src', imageSources.prevImageSrc).attr('data-info', imagesDataInfo.prevImageData);
    }

    buildTabledView();
    showSelectedImages();
    changeToPreviousImage();
    changeToNextImage();
    returnToNormalState();
};