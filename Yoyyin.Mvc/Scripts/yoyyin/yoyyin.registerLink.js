(function ($, register) {
    $.widget("yoyyin.registerLink", {
        // These options will be used as defaults
        options: {
            clear: null
        },

        _init: function () {
            this.element.click(function () {
                register.open();
            });
        }
    });

} (jQuery, yoyyin.register));

