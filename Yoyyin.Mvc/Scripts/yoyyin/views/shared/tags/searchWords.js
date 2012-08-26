define(["backbone"], function (Backbone) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            $.get("/Matching/GetQuickSearchTypeAheadItems/", function (items) {
                that.$el.tagit({ availableTags: items });
            });
        }
    });
});