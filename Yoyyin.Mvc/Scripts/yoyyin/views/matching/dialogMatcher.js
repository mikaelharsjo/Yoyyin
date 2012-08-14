define(["underscore", "backbone", "mustache", "models/matching/match", "text!templates/matching/singleMatchContainer.htm", "text!templates/User/image.htm", "text!templates/Shared/modal.htm", "text!templates/matching/result.htm", "text!templates/shared/competenceLabel.htm"], function (_, Backbone, mustache, Match, containerTemplate, imageTemplate, modalTemplate, resultTemplate, competenceTemplate) {
    return Backbone.View.extend({
        initialize: function () {
            var that = this;
            this.model = new Match();
            this.model.id = this.options.userId;
            this.model.fetch({
                success: function () {
                    that.render();
                }
            });
        },
        render: function () {
            var currentUser = this.model.get("currentUser");
            var userToMatch = this.model.get("userToMatchWith");
            var currentUserImageMarkup = mustache.render(imageTemplate, { Src: currentUser.ProfileImageSrc + "?width=50" });
            var userToMatchImageMarkup = mustache.render(imageTemplate, { Src: userToMatch.ProfileImageSrc + "?width=50" });
            var currentUserViewModel = { ImageMarkup: currentUserImageMarkup, Name: currentUser.DisplayName };
            var userToMatchViewModel = { ImageMarkup: userToMatchImageMarkup, Name: userToMatch.DisplayName };

            var resultMarkup = "";
            var resultViewModel = {};
            var result = this.model.get("matchResult");
            resultViewModel.CompetencesMarkup = "";
            resultViewModel.NeededCompetencesMarkup = "";
            console.log(result);

            // render competences
            $.each(result.CompetencesResult.Competences, function (index, competence) {
                resultViewModel.CompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });
            $.each(result.CompetencesResult.NeededCompetencesFlattened, function (index, competence) {
                resultViewModel.NeededCompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });
            var competencesMarkup = mustache.render(resultTemplate, { firstColMarkup: resultViewModel.CompetencesMarkup, secondColMarkup: resultViewModel.NeededCompetencesMarkup });

            // render usertypes
            var userTypeMarkup = "";
            $.each(result.UserTypeMatch.SecondUserTypes, function (index, userType) {
                userTypeMarkup += userType;
            });
            var userTypesMarkup = mustache.render(resultTemplate, { firstColMarkup: result.UserTypeMatch.UserType, secondColMarkup: userTypeMarkup });

            resultMarkup += competencesMarkup + userTypesMarkup;

            var bodyMarkup = mustache.render(containerTemplate, { currentUser: currentUserViewModel, userToMatch: userToMatchViewModel, resultMarkup: resultMarkup });
            var modalMarkup = mustache.render(modalTemplate, { title: "Matchning", body: bodyMarkup });

            $(modalMarkup).modal("show");
        }

    });
});