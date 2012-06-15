(function ($) {
    $.widget("yoyyin.quickSearch", {
        options: {
            $placeHolder: null
        },
        _init: function () {
            var that = this;
            var $input = this.element.find("input");
            $input.typeahead({
                source: ["apa", "kossa"]
            });
            $input.keydown(function (event) {
                if (event.keyCode == 13) {
                    $.get("/User/QuickSearch/", { term: $(this).val() }, function (result) {
                        console.log(result);
                        debugger;
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