define(["backbone", "mustache", "text!templates/Shared/pageHeader.htm", "text!templates/user/image.htm", "text!templates/matching/megaMatchItem.htm", "text!templates/Shared/alertInfo.htm", "views/matching/dialogMatcher"], function (Backbone, mustache, pageHeaderTemplate, imageTemplate, itemTemplate, alertInfoTemplate, DialogMatcher) {
    return Backbone.View.extend({
        render: function () {
            var markup = mustache.render(pageHeaderTemplate, { Heading: "Matchande medlemmar", SubHeading: "Sorterat och klart" });
            markup += mustache.render(alertInfoTemplate, { text: "Siffran anger hur väl ni matchar, ju högre desto bättre. Max är 100." });
            this.collection.each(function (match) {
                var user = match.get("User");
                var result = match.get("MatchResult");
                var imageMarkup = mustache.render(imageTemplate, { Src: user.ProfileImageSrc + "?width=50" });

                markup += mustache.render(itemTemplate, { imageMarkup: imageMarkup, name: user.DisplayName, score: result.Score, id: user.id });
            });

            this.$el.html(markup);
        },
        events: {
            "click button.btn": "match"
        },
        match: function (e) {
            console.log($(e.target).data("userid"));
            var view = new DialogMatcher({ userId: $(e.target).data("userid") });
        }
    });
});