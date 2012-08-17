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

            var viewData = { title: "Titlar/roller du söker:", firstColMarkup: result.UserTypesNeeded.UserType, secondColMarkup: userTypeMarkup };
            return mustache.render(resultTemplate, this.renderMatch(result, viewData));
        },
        renderUserTypes: function (result) {
            var userTypeMarkup = "";
            $.each(result.UserType.SecondUserTypes, function (index, userType) {
                userTypeMarkup += userType;
            });

            var viewData = { title: "Titlar/roller du har:", firstColMarkup: result.UserType.UserType, secondColMarkup: userTypeMarkup };
            return mustache.render(resultTemplate, this.renderMatch(result, viewData));
        },
        renderCompetences: function (competencesResult, title) {
            var resultViewModel = {};
            resultViewModel.CompetencesMarkup = "";
            resultViewModel.NeededCompetencesMarkup = "";

            $.each(competencesResult.Competences, function (index, competence) {
                resultViewModel.CompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });
            $.each(competencesResult.NeededCompetencesFlattened, function (index, competence) {
                resultViewModel.NeededCompetencesMarkup += mustache.render(competenceTemplate, { Competence: competence });
            });

            var viewData = { title: title, firstColMarkup: resultViewModel.CompetencesMarkup, secondColMarkup: resultViewModel.NeededCompetencesMarkup };
            return mustache.render(resultTemplate, this.renderMatch(competencesResult, viewData));
        },
        renderSni: function (sniResult, title) {
            var sni = {
                title: title,
                firstColMarkup: sniResult.FirstSniHead,
                secondColMarkup: sniResult.SecondSniHead
            };

            return mustache.render(resultTemplate, this.renderMatch(sniResult, sni));
        },
        renderMatch: function (result, viewData) {
            viewData.imageName = result.IsMatch ? "glyphicons_206_ok_2.png" : "glyphicons_207_remove_2.png";
            viewData.cssClass = result.IsMatch ? "alert-success" : "";
            return viewData;
        },
        render: function () {
            var currentUser = this.model.get("currentUser");
            var userToMatch = this.model.get("userToMatchWith");
            var currentUserImageMarkup = mustache.render(imageTemplate, { Src: currentUser.ProfileImageSrc + "?width=50&height=50" });
            var userToMatchImageMarkup = mustache.render(imageTemplate, { Src: userToMatch.ProfileImageSrc + "?width=50&height=50" });
            var currentUserViewModel = { ImageMarkup: currentUserImageMarkup, Name: currentUser.DisplayName };
            var userToMatchViewModel = { ImageMarkup: userToMatchImageMarkup, Name: userToMatch.DisplayName };

            var result = this.model.get("matchResult");
            console.log(result);
            var resultMarkup = this.renderCompetences(result.Competences, "Kompetenser du söker:") +
                this.renderCompetences(result.CompetencesNeeded, "Kompetenser du har:") +
                    this.renderUserTypes(result) +
                        this.renderUserTypesNeeded(result) +
                            this.renderSni(result.SniHeadMatch, "Bransch");

            var bodyMarkup = mustache.render(containerTemplate, { currentUser: currentUserViewModel, userToMatch: userToMatchViewModel, resultMarkup: resultMarkup });
            var modalMarkup = mustache.render(modalTemplate, { title: "Matchning", body: bodyMarkup });

            $(modalMarkup).modal("show");
        }
    });
});