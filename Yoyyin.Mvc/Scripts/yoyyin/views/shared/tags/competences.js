define(["backbone"], function (Backbone) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            $.get("/Tagging/Competences/", function(competences) {
                that.$el.tagit({ availableTags: competences });
            });
        }
    });
});