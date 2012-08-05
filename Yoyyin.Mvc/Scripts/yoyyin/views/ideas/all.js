define(["backbone", "mustache", "collections/ideas", "text!templates/Shared/pageHeader.htm", "text!templates/User/container.htm", "text!templates/idea/item.htm", "text!templates/User/image.htm", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/competenceLabel.htm"], function (Backbone, mustache, IdeaCollection, pageHeaderTemplate, containerTemplate, itemTemplate, imageTemplate, userTypeLabelTemplate, ideaTemplate, competenceLabelTemplate) {
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
            
            this.collection.each(function (user) {
                user = user.toJSON();
                user.UserType = mustache.to_html(userTypeLabelTemplate, { Title: user.UserType });
                user.ImageMarkup = mustache.render(imageTemplate, { Src: user.SmallProfileImageSrc });

                // make idea own view?
                user.IdeasMarkup = "";
                console.log(user.Ideas);
                $.each(user.Ideas, function (index, idea) {
                    idea.UserTypesNeededMarkup = "";
                    $.each(idea.UserTypesNeeded, function (index, userType) {
                        idea.UserTypesNeededMarkup += mustache.render(userTypeLabelTemplate, { Title: userType });
                    });

                    idea.CompetencesNeededMarkup = "";
                    console.log(idea);
                    $.each(idea.CompetencesNeeded, function (index, competence) {
                        idea.CompetencesNeededMarkup += mustache.render(competenceLabelTemplate, { Competence: competence });
                    });

                    user.IdeasMarkup += mustache.render(ideaTemplate, idea);
                });

                markup += mustache.render(itemTemplate, user);
            });
            
            $(this.el).html(mustache.to_html(containerTemplate, { items: markup }));
        }
    });
});