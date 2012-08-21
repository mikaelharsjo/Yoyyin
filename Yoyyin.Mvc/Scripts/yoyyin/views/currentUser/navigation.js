define(["backbone", "mustache", "text!templates/currentUser/navigation.htm", "collections/megaMatch", "views/matching/megaMatch"], function (Backbone, mustache, navigationTemplate, MatchCollection, MegaMatchView) {
    return Backbone.View.extend({
        collection: MatchCollection,
        initialize: function () {
            this.collection = new MatchCollection();
        },
        render: function () {
            var that = this;
            this.collection.fetch({
                success: function () {
                    that.$el.html(mustache.render(navigationTemplate, { matchCount: that.collection.length }));
                }
            });
        },
        events: {
            "click a#megaMatch": "megaMatch"
        },
        megaMatch: function () {
            var view = new MegaMatchView({ el: $("#body"), collection: this.collection });
            view.render();
            console.log(this.collection.length);
        }
    });
});