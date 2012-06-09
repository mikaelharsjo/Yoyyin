(function ($) {
    $.widget("yoyyin.quickSearch", {
        options: {
            $placeHolder: null
        },
        _init: function () {
            var that = this;
            this.element.find("input").keydown(function (event) {
                if (event.keyCode == 13) {
                    $.get("/User/QuickSearch/", { term: $(this).val() }, function (result) {
                        that.options.$placeHolder.html(result);
                    });

                    event.preventDefault();
                    return false;
                }
                return true;
            });
        }
    });

} (jQuery));