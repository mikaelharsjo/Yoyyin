(function ($) {
    $.widget("yoyyin.quickSearch", {
        options: {
            $placeHolder: null
        },
        _init: function () {
            var that = this;
            var $input = this.element.find("input");

            $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                $input.typeahead({
                    source: items
                });
            });

            $input.keydown(function (event) {
                if (event.keyCode == 13) {
                    $.get("/Search/Quick/", { term: $(this).val() }, function (result) {
                        that.options.$placeHolder.html(result);
                        // hide hero
                        $(".featured").html("");
                        $(".featured + .main-content").css("background", "none");
                        $("#searchInfo").find("a").click(function () {
                            $.getJSON("/Search/QuickJson", { term: $(this).val() }, function (users) {
                                $("#quickSearchMap")
                                    .goMap({
                                        latitude: users[0].Latitude,
                                        longitude: users[0].Longitude,
                                        maptype: 'ROADMAP'
                                    });
                            });
                        });
                    });

                    event.preventDefault();
                    return false;
                }
                return true;
            });
        }
    });

} (jQuery));