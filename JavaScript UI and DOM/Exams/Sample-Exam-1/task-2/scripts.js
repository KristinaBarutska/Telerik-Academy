$.fn.tabs = function () {
    let $root = this;

    $root.addClass('tabs-container');
    $root.find('.tab-item-content').hide();
    $root.on('click', '.tab-item', function () {
        let $this = $(this);
        
        $root.find('.tab-item-content').hide();
        $root.find('.tab-item.current').removeClass('current');
        $this.addClass('current');
        $this.find('.tab-item-content').show();
    });
};