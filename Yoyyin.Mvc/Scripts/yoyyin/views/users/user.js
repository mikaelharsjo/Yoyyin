define(["underscore", "backbone", "mustache", "text!../../../../Templates/Member/User/image.htm", "text!../../../../Templates/Member/User/details.htm", "text!../../../../Templates/Shared/idea.htm", "text!../../../../Templates/Shared/userTypeLabel.htm", "text!../../../../Templates/Shared/competenceLabel.htm"], function (_, Backbone, mustache, imageTemplate, detailsTemplate, ideaTemplate, userTypeLabelTemplate, competenceLabelTemplate) {
    var UserView = Backbone.View.extend({
        initialize: function () {
            this.render();
        },
        render: function () {
            var user = this.model.toJSON();
            user.Image = mustache.render(imageTemplate, user);

            user.IdeasMarkup = "";
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

            var markup = mustache.render(detailsTemplate, user);
            $(this.el).html(markup);
        }
    });

    return UserView;
});