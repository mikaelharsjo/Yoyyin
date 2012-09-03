define(["views/registration/step", "views/shared/tags/competences", "views/shared/tags/searchWords", "text!templates/registration/tags.htm"], function (StepView, CompetencesTagsView, SearchWordsTagsView, template) {
    return StepView.extend({
        render: function () {
            this.setHero({ Headline: "Vilka kompetenser söker du?" });            
            this.appendButtons({ markup: template, previousStep: "userTypesNeeded", nextStep: "upload" });

            var competencesTagsView = new CompetencesTagsView({ el: $("#competencesNeeded") });
            competencesTagsView.render();

            var searchWordsTagsView = new SearchWordsTagsView({ el: $("#tags") });
            searchWordsTagsView.render();
        }
    });
});