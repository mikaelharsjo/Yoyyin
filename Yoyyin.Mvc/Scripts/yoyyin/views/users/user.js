﻿define(["underscore", "backbone", "mustache", "models/user", "models/idea", "views/ideas/idea", "text!templates/User/image.htm", "text!templates/User/details.htm", "text!templates/Shared/idea.htm", "text!templates/Shared/userTypeLabel.htm", "text!templates/Shared/competenceLabel.htm", "text!templates/Shared/comment.htm"], function (_, Backbone, mustache, UserModel, IdeaModel, IdeaView, imageTemplate, detailsTemplate, ideaTemplate, userTypeLabelTemplate, competenceLabelTemplate, commentTemplate) {
    return Backbone.View.extend({
        initialize: function () {
            this.render();
        },
        render: function () {
            var user = this.model.toJSON();
            user.Image = mustache.render(imageTemplate, user);

            user.IdeasMarkup = "";
            $.each(user.Ideas, function (index, idea) {
                var $ideaEl = $("<div></div>");
                var model = new IdeaModel();
                model.set(idea);
                var ideaView = new IdeaView({ model: model, el: $ideaEl });
                ideaView.render();

                user.IdeasMarkup += $ideaEl.html();

                idea.CommentsMarkup = "<div class='page-header'><h2>Kommentarer. <small>Här får man tycka vad man vill, men var snälla<small></h2></div>";
                $.each(idea.Comments, function (index, comment) {
                    idea.CommentsMarkup += mustache.render(commentTemplate, comment);
                });
                idea.CommentsMarkup += "<button class='btn'><i class='text-icon icon-comment'></i> Lägg till kommentar</button>";

                user.IdeasMarkup += mustache.render(ideaTemplate, idea);
            });

            var markup = mustache.render(detailsTemplate, user);
            $(this.el).html(markup);
        }
    });
});