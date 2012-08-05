define(["backbone", "models/idea"], function (Backbone, Idea) {
    return Backbone.Collection.extend({
        url: "/Idea/All",
        model: Idea,
        initialize: function () {
        }
    });
});
