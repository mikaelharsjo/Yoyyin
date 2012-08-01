(function ($, mustache) {
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
                        $("#searchInfo").find("a#showOnMap").click(function () {
                            $("#quickSearchMap").show();
                            $.getJSON("/Search/QuickJson", { term: $(this).val() }, function (users) {
                                var markers = [];
                                require(["mustache"], function(mustache) {
                                    $.each(users, function(index, user) {
                                        var marker = {
                                            latitude: user.Latitude,
                                            longitude: user.Longitude,
                                            html: {
                                                content: mustache.render("{{FirstIdea.Title}}<br/>{{FirstIdea.Description}}", user)
                                            }
                                        };
                                        markers.push(marker);
                                    });
                                });

                                $("#quickSearchMap")
                                    .goMap({
                                        markers: markers,
                                        latitude: users[0].Latitude,
                                        longitude: users[0].Longitude,
                                        maptype: 'ROADMAP',
                                        hideByClick: true
                                    });
                                $input.focus();
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