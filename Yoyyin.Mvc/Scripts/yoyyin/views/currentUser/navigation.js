define(["backbone", "mustache", "text!templates/currentUser/navigation.htm", "collections/megaMatch", "views/matching/megaMatch", "views/currentUser/editIdea"], function (Backbone, mustache, navigationTemplate, MatchCollection, MegaMatchView, EditIdeaView) {
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
            "click a#megaMatch": "megaMatch",
            "click a#editIdea": "editIdea"
        },
        megaMatch: function () {
            var view = new MegaMatchView({ el: $("#body"), collection: this.collection });
            view.render();
            console.log(this.collection.length);
        },
        editIdea: function () {
            var view = new EditIdeaView({ el: $("#body"), model: this.model });
            view.render();
        }
    });
});