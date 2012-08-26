define(["backbone", "mustache", "text!templates/shared/pageHeader.htm", "text!templates/currentUser/editIdea.htm", "views/shared/tags/competences", "views/shared/tags/searchWords"], function (Backbone, mustache, pageHeaderTemplate, editIdeaTemplate, CompetencesTagsView, SearchWordsTagsView) {
    return Backbone.View.extend({
        render: function () {
            var pageHeader = mustache.render(pageHeaderTemplate, { Heading: "Redigera din affärsidé" });
            var firstIdea = this.model.get("Ideas")[0];
            console.log(firstIdea);
            firstIdea.competencesNeededMarkup = "";
            $.each(firstIdea.SearchProfile.CompetencesNeeded, function (index, competence) {
                firstIdea.competencesNeededMarkup += "<li>" + competence + "</li>";
            });

            firstIdea.searchWordsMarkup = "";
            $.each(firstIdea.SearchProfile.SearchWords, function (index, word) {
                firstIdea.searchWordsMarkup += "<li>" + word + "</li>";
            });

            var body = mustache.render(editIdeaTemplate, firstIdea);
            this.$el.html(pageHeader + body);
            
            var cmpView = new CompetencesTagsView({ el: $("#competencesNeeded") });
            var swView = new SearchWordsTagsView({ el: $("#tags") });
        },
        events: {
            "click a.btn": "save"
        },
        save: function () {
            var ideas = this.model.get("Ideas");
            ideas[0].SearchProfile.CompetencesNeeded = $("#competencesNeeded").tagit("assignedTags");

            this.model.save();
        }
    });
});