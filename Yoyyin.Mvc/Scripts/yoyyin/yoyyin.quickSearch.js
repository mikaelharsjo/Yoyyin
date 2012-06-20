﻿(function ($) {
    $.widget("yoyyin.quickSearch", {
        options: {
            $placeHolder: null
        },
        _init: function () {
            var that = this;
            var $input = this.element.find("input");

            $.get("/Matching/GetQuickSearchTypeAheadItems/", function(items) {
                $input.typeahead({
                    source: items
                });
            });

            $input.keydown(function (event) {
                if (event.keyCode == 13) {
                    $.get("/User/QuickSearch/", { term: $(this).val() }, function (result) {
                        that.options.$placeHolder.html(result);
                        // hide hero
                        $(".featured").html("");
                        $(".featured + .main-content").css("background", "none");
                    });

                    event.preventDefault();
                    return false;
                }
                return true;
            });
        }
    });

} (jQuery));