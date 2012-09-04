define(["backbone", "mustache", "text!templates/shared/sniDropDowns.htm", "collections/sniHeads"], function (Backbone, mustache, template, SniHeads) {
    var wireUpDropDowns = function () {
        $("#heads").change(function () {
            var items = $(this).find(":selected").data("items");
            if (items != undefined) {
                $("#items")
                        .show()
                        .find("option")
                        .remove();

                $.each(items, function (index, item) {
                    var $option = $("<option>")
                            .text(item.Title)
                            .val(item.SniNo);

                    $("#items").append($option);
                });
            }
        });
    };

    return Backbone.View.extend({
        initialize: function () {
            this.collection = new SniHeads();
        },
        render: function () {
            var that = this;
            this.collection.fetch({
                success: function () {
                    that.collection.each(function (sniHead) {
                        sniHead = sniHead.toJSON();
                        var $option = $("<option>")
                                    .text(sniHead.Title)
                                    .val(sniHead.SniHeadId)
                                    .data("items", sniHead.Items);
                        $("#heads").append($option);
                    });
                }
            });

            this.$el.html(template);

            wireUpDropDowns();
        }
    });
});