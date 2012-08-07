define(["backbone", "mustache", "collections/ideas", "models/idea", "views/ideas/idea", "text!templates/Shared/pageHeader.htm", "text!templates/Shared/container.htm", "text!templates/idea/item.htm", "text!templates/User/image.htm", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/competenceLabel.htm"], function (Backbone, mustache, IdeaCollection, IdeaModel, IdeaView, pageHeaderTemplate, containerTemplate, itemTemplate, imageTemplate, userTypeLabelTemplate, ideaTemplate, competenceLabelTemplate) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.collection = new IdeaCollection();
            this.collection.fetch({
                success: function () {
                    that.render();
                }
            });
        },
        render: function () {
            var markup = mustache.render(pageHeaderTemplate, {
                IconMarkup: "<img src='/Images/glyphicons_064_lightbulb.png' />",
                Heading: "Alla affärsidéer",
                SubHeading: "Kanske söker dom just din kompetens?"
            });

            this.collection.each(function (userModel) {
                var user = userModel.toJSON();
                user.UserType = mustache.to_html(userTypeLabelTemplate, { Title: user.UserType });
                user.ImageMarkup = mustache.render(imageTemplate, { Src: user.SmallProfileImageSrc });

                user.IdeasMarkup = "";

                $.each(user.Ideas, function (index, idea) {
                    var $ideaEl = $("<div></div>");
                    var model = new IdeaModel();
                    model.set(idea);
                    var ideaView = new IdeaView({ model: model, el: $ideaEl });
                    ideaView.render();

                    user.IdeasMarkup += $ideaEl.html();
                });

                markup += mustache.render(itemTemplate, user);
            });

            $(this.el).html(mustache.to_html(containerTemplate, { items: markup }));
        }
    });
});