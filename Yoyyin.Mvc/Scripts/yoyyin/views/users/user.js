define(["underscore", "backbone", "mustache", "models/user", "text!templates/User/image.htm", "text!templates/User/details.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/competenceLabel.htm", "text!templates/Shared/comment.htm"], function (_, Backbone, mustache, UserModel, imageTemplate, detailsTemplate, ideaTemplate, userTypeLabelTemplate, competenceLabelTemplate, commentTemplate) {
    var UserView = Backbone.View.extend({
        initialize: function () {
            //this.model = new UserModel();
            this.render();
        },
        render: function () {
            var user = this.model.toJSON();
            user.Image = mustache.render(imageTemplate, user);

            // make idea own view?
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

                idea.CommentsMarkup = "<div class='page-header'><h2>Kommentarer. <small>Här får man tycka vad man vill, men var snälla<small></h2></div>";
                $.each(idea.Comments, function (index, comment) {
                    idea.CommentsMarkup += mustache.render(commentTemplate, comment);
                });

                user.IdeasMarkup += mustache.render(ideaTemplate, idea);
            });

            var markup = mustache.render(detailsTemplate, user);
            $(this.el).html(markup);
        }
    });

    return UserView;
});