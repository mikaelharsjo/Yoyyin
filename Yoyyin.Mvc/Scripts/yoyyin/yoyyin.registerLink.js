(function ($) {
    $.widget("yoyyin.registerLink", {
        // These options will be used as defaults
        options: {
            clear: null
        },

        _init: function () {
            this.element.click(function () {
                $("<h1>Bli medlem</h1>").dialog({ title: "Bli medlem", modal: true });
            });
        }
    });

} (jQuery));

