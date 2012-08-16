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
        renderUserTypesNeeded: function (result) {
            var userTypeMarkup = "";
            $.each(result.UserTypesNeeded.UserTypesFlattened, function (index, ut) {
                userTypeMarkup += ut;
            });
            return mustache.render(resultTemplate, { title: "Titlar/roller du söker:", firstColMarkup: result.UserTypesNeeded.UserType, secondColMarkup: userTypeMarkup });
        },
        renderUserTypes: function (result) {
            var userTypeMarkup = "";
            $.each(result.UserType.SecondUserTypes, function (index, userType) {
                userTypeMarkup += userType;
            });
            return mustache.render(resultTemplate, { title: "Titlar/roller du har:", firstColMarkup: result.UserType.UserType, secondColMarkup: userTypeMarkup });
        },
        renderCompetencesNeeded: function (result) {
            var resultViewModel = {};
            resultViewModel.CompetencesMarkup = "";
            resultViewModel.NeededCompetencesMarkup = "";

            $.each(result.CompetencesResult.Competences, function (index, competence) {
                resultViewModel.CompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });
            $.each(result.CompetencesResult.NeededCompetencesFlattened, function (index, competence) {
                resultViewModel.NeededCompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });
            return mustache.render(resultTemplate, { title: "Kompetenser du söker:", firstColMarkup: resultViewModel.CompetencesMarkup, secondColMarkup: resultViewModel.NeededCompetencesMarkup });
        },
        render: function () {
            var currentUser = this.model.get("currentUser");
            var userToMatch = this.model.get("userToMatchWith");
            var currentUserImageMarkup = mustache.render(imageTemplate, { Src: currentUser.ProfileImageSrc + "?width=50" });
            var userToMatchImageMarkup = mustache.render(imageTemplate, { Src: userToMatch.ProfileImageSrc + "?width=50" });
            var currentUserViewModel = { ImageMarkup: currentUserImageMarkup, Name: currentUser.DisplayName };
            var userToMatchViewModel = { ImageMarkup: userToMatchImageMarkup, Name: userToMatch.DisplayName };

            var result = this.model.get("matchResult");
            var resultMarkup = this.renderCompetencesNeeded(result) + this.renderUserTypes(result) + this.renderUserTypesNeeded(result);

            var bodyMarkup = mustache.render(containerTemplate, { currentUser: currentUserViewModel, userToMatch: userToMatchViewModel, resultMarkup: resultMarkup });
            var modalMarkup = mustache.render(modalTemplate, { title: "Matchning", body: bodyMarkup });

            $(modalMarkup).modal("show");
        }
    });
});