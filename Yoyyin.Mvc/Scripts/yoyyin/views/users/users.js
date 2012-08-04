﻿define(["backbone", "mustache", "collections/users", "text!templates/Shared/pageHeader.htm", "text!templates/User/container.htm", "text!templates/User/item.htm", "text!templates/Shared/competenceLabel.htm", "text!templates/User/image.htm", "text!templates/Shared/userTypeLabel.htm"], function (Backbone, mustache, UserCollection, pageHeaderTemplate, containerTemplate, itemTemplate, competenceTemplate, imageTemplate, userTypeLabelTemplate) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.collection = new UserCollection();
            this.collection.fetch({
                success: function () {
                    that.render();
                }
            });
            this.collection.on("sync", this.render, this);
        },
        render: function () {
            var that = this;
            require(["mustache"], function (mustache2) {
                $(that.el).html(mustache2.render(pageHeaderTemplate, { Heading: "Alla användare", SubHeading: "Kanske din nästa affärspartner?" }));
            });
            var markup = "";

            this.collection.each(function (user) {
                user = user.toJSON();
                user.CompetencesNeededMarkup = "";

                $.each(user.CompetencesNeeded, function (index, competence) {
                    user.CompetencesNeededMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                });

                user.CompetencesMarkup = "";
                $.each(user.Competences, function (index, competence) {
                    user.CompetencesMarkup += mustache.to_html(competenceTemplate, { Competence: competence });
                });

                user.UserType = mustache.to_html(userTypeLabelTemplate, { Title: user.UserType });

                user.UserTypesNeededMarkup = "";
                $.each(user.UserTypesNeeded, function (index, userType) {
                    user.UserTypesNeededMarkup += mustache.to_html(userTypeLabelTemplate, { Title: userType });
                });

                var imageMarkup = mustache.render(imageTemplate, { Src: user.SmallProfileImageSrc });
                user.ImageMarkup = imageMarkup;

                markup += mustache.render(itemTemplate, user);
            });

            markup = mustache.to_html(containerTemplate, { items: markup });
            $(this.el).html(markup);
        }
    });
});